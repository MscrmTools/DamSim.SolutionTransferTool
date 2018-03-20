using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace DamSim.SolutionTransferTool.AppCode
{
    internal class SolutionInfo
    {
        public Guid ImportJobId { get; set; }
        public string Name { get; set; }
        public bool Processed { get; set; }
        public decimal Progress { get; set; }
        public ImportSolutionRequest Request { get; set; }
    }

    internal class TargetOrganization
    {
        public TargetOrganization()
        {
            Solutions = new List<SolutionInfo>();
        }

        public IOrganizationService Service { get; set; }
        public List<SolutionInfo> Solutions { get; set; }
    }

    internal class TransfertSettings
    {
        public TransfertSettings()
        {
            Organizations = new List<TargetOrganization>();
            ExportRequests = new List<ExportSolutionRequest>();
        }

        public List<ExportSolutionRequest> ExportRequests { get; set; }

        public List<TargetOrganization> Organizations { get; set; }
    }
}