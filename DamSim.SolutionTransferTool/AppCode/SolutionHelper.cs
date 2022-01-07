using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DamSim.SolutionTransferTool.AppCode
{
    internal static class SolutionHelper
    {
        public static bool CheckForNewConnectionReferences(string solutionUniqueName, IOrganizationService sourceService, IOrganizationService targetService)
        {
            var sourceConnectionReferences = GetConnectionReferences(solutionUniqueName, sourceService);
            var targetConnectionReferences = GetConnectionReferences(solutionUniqueName, targetService);

            if (sourceConnectionReferences.Any(scr => targetConnectionReferences.All(tcr => tcr.GetAttributeValue<string>("connectionreferencelogicalname") != scr.GetAttributeValue<string>("connectionreferencelogicalname"))))
            {
                return true;
            }

            return false;
        }

        private static int GetConnectionReferenceComponentType(IOrganizationService service)
        {
            return service.RetrieveMultiple(new QueryExpression("solutioncomponentdefinition")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("solutioncomponenttype"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("primaryentityname", ConditionOperator.Equal, "connectionreference")
                    }
                }
            }).Entities.First().GetAttributeValue<int>("solutioncomponenttype");
        }

        private static List<Entity> GetConnectionReferences(string solutionUniqueName, IOrganizationService service)
        {
            var crType = GetConnectionReferenceComponentType(service);

            return service.RetrieveMultiple(new QueryExpression("connectionreference")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("connectionreferencelogicalname"),
                LinkEntities =
                {
                    new LinkEntity
                    {
                        LinkFromEntityName ="connectionreference",
                        LinkFromAttributeName = "connectionreferenceid",
                        LinkToAttributeName = "objectid",
                        LinkToEntityName = "solutioncomponent",
                        LinkCriteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("componenttype", ConditionOperator.Equal, crType)
                            }
                        },
                        LinkEntities =
                        {
                            new LinkEntity
                            {
                                LinkFromEntityName ="solutioncomponent",
                                LinkFromAttributeName = "solutionid",
                                LinkToAttributeName = "solutionid",
                                LinkToEntityName = "solution",
                                LinkCriteria = new FilterExpression
                                {
                                    Conditions =
                                    {
                                        new ConditionExpression("uniquename", ConditionOperator.Equal, solutionUniqueName)
                                    }
                                }
                            }
                        }
                    }
                }
            }).Entities.ToList();
        }
    }
}