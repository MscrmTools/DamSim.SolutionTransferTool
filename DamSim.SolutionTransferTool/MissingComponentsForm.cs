using System;
using System.Collections.Generic;

using System.Data;

using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace DamSim.SolutionTransferTool
{
    public partial class MissingComponentsForm : Form
    {
        #region Fields
        string solutionName;
        IOrganizationService _sourceService;
        #endregion
        public MissingComponentsForm()
        {
            InitializeComponent();
        }

        public void ShowMissingComponents(Form parent,KeyValuePair<string,IOrganizationService> targetService,IOrganizationService sourceService,Guid? jobId)
        {
            _sourceService = sourceService;

            var importQuery = new QueryByAttribute("importjob")
            {
                ColumnSet = new ColumnSet(true),
                Attributes = { "importjobid" },
                Values = { jobId },
                Orders = { new OrderExpression("createdon", OrderType.Descending) }
            };

            var lastFailedImportQuery = new QueryExpression("importjob")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                   Conditions =
                   {
                      new ConditionExpression("progress",ConditionOperator.NotEqual,100)
                   }
                },

                Orders = { new OrderExpression("createdon", OrderType.Descending) }
            };

            Entity jobLog;
            if (jobId == null)
            {
                jobLog = targetService.Value.RetrieveMultiple(lastFailedImportQuery).Entities.FirstOrDefault();
            }
            else
            {
                jobLog = targetService.Value.RetrieveMultiple(importQuery).Entities.FirstOrDefault();
            }

            if (jobLog == null)
            {
                MessageBox.Show(parent, "This feature is only available after a failed solution import");
                return;
            }

            solutionName = jobLog.GetAttributeValue<string>("solutionname");

            var dataxml = new XmlDocument();
            dataxml.LoadXml(jobLog.GetAttributeValue<string>("data"));


            var innerDataXml = new XmlDocument();

            var resultParams = dataxml["importexportxml"]["solutionManifests"]["solutionManifest"]["result"]["parameters"];

            if (resultParams == null)
            {
                MessageBox.Show(@"The solution import did not failed because of missing dependencies", "No missing dependencies", MessageBoxButtons.OK);
                return;
            }
            innerDataXml.LoadXml(resultParams.ChildNodes[1].ChildNodes[0].Value);

            var componentTypesRequest = new RetrieveOptionSetRequest
            {
                Name = "componenttype"
            };

            var options = ((OptionSetMetadata)((RetrieveOptionSetResponse)_sourceService.Execute(componentTypesRequest)).OptionSetMetadata).Options.Select(x => new KeyValuePair<int?, string>(x.Value, x.Label.UserLocalizedLabel.Label));
            var nodes = innerDataXml.FirstChild.ChildNodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i].FirstChild;

                var schemaName = node.Attributes["schemaName"]?.Value;
                var parentSchemaName = node.Attributes["parentSchemaName"]?.Value;
                var type = int.Parse(node.Attributes["type"]?.Value);
                var typeLabel = options.First(x => x.Key == type).Value;
                var id = node.Attributes["id"]?.Value;
                

                var solutionValue = node.Attributes["solution"]?.Value;
                if (solutionValue != null && solutionValue != "Active")
                {
                    MessageBox.Show($"Environment \"{targetService.Key}\" needs solution \"{solutionValue}\" to be installed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var componentId = Guid.Empty;
                switch (type)
                {
                    case 10:
                        {
                            var RetrieveRelationShip = new RetrieveRelationshipRequest
                            {
                                Name = schemaName
                            };
                            componentId = (Guid)((RetrieveRelationshipResponse)_sourceService.Execute(RetrieveRelationShip)).RelationshipMetadata.MetadataId;
                            break;
                        }
                    case 2:
                        {
                            var RetrieveAttribute = new RetrieveAttributeRequest
                            {
                                LogicalName = schemaName,
                                EntityLogicalName = parentSchemaName
                            };
                            componentId = (Guid)((RetrieveAttributeResponse)_sourceService.Execute(RetrieveAttribute)).AttributeMetadata.MetadataId;
                            break;
                        }
                    case 60:
                    case 61:
                        {
                            if (id != null)
                            {
                                componentId = new Guid(id);
                            }
                            else if(schemaName!=null)
                            {
                                var webResourceQuery = new QueryByAttribute("webresource");
                                webResourceQuery.AddAttributeValue("name",schemaName);

                                var rWebResource = _sourceService.RetrieveMultiple(webResourceQuery).Entities.FirstOrDefault();

                                if (rWebResource != null)
                                    componentId = rWebResource.Id;
                            }
                            break;
                        }
                    case 9:
                        {
                            var optionSetRequest = new RetrieveOptionSetRequest
                            {
                                Name = schemaName
                            };

                            componentId = (Guid)((RetrieveOptionSetResponse)_sourceService.Execute(optionSetRequest)).OptionSetMetadata.MetadataId;
                            break;
                        }
                    case 1:
                        {
                            var entityMetadata = new RetrieveEntityRequest
                            {
                                LogicalName = schemaName,
                                EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Entity
                            };

                            componentId = (Guid)((RetrieveEntityResponse)_sourceService.Execute(entityMetadata)).EntityMetadata.MetadataId;
                            break;
                        }
            
                }

                var item = new ListViewItem
                {
                    Tag = new Tuple<int,Guid>(type,componentId),
                    Name = schemaName
                };
                if(componentId==Guid.Empty)
                {
                    item.BackColor = Color.Red;
                }           
                item.SubItems.Add(parentSchemaName);
                item.SubItems.Add(typeLabel);
                lstMissingComponents.Items.Add(item);          
            }

            Show();
        }

        private void btnFixMissing_Click(Object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstMissingComponents.Items)
            {
                var typedTag = (Tuple<int, Guid>)item.Tag;
                if (typedTag.Item2 == Guid.Empty)
                    continue;
                try
                {
                    item.BackColor = Color.Yellow;

                    var req = new AddSolutionComponentRequest
                    {
                        ComponentId = typedTag.Item2,
                        ComponentType = typedTag.Item1,
                        SolutionUniqueName = solutionName
                    };

                    if (typedTag.Item1 == 1)
                        req.DoNotIncludeSubcomponents = false;

                    _sourceService.Execute(req);
                }
                catch (Exception ex)
                {
                
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                item.BackColor = Color.Green;
            }

            _sourceService.Execute(new PublishAllXmlRequest());
           
            MessageBox.Show("Missing components were successfully added to solution", "Success", MessageBoxButtons.OK);
            Dispose();
        }

    }
}
