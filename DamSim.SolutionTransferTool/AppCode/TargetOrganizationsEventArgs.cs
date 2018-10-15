using McTools.Xrm.Connection;
using System;
using System.Collections.Generic;

namespace DamSim.SolutionTransferTool.AppCode
{
    public class TargetOrganizationsEventArgs : EventArgs
    {
        public List<ConnectionDetail> TargetOrganizations { get; set; }
    }
}