using System;

namespace DamSim.SolutionTransferTool.AppCode
{
    public class DownloadLogEventArgs : EventArgs
    {
        public Guid ImportJobId { get; set; }
    }
}