using Microsoft.Xrm.Sdk;
using System;

namespace DamSim.SolutionTransferTool.AppCode
{
    public class DownloadLogEventArgs : EventArgs
    {
        public Guid ImportJobId { get; set; }

        public IOrganizationService Service { get; set; }
    }
}