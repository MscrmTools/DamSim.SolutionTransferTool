using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;

namespace DamSim.SolutionTransferTool
{
    public class BaseToProcess
    {
        public string Ago
        {
            get
            {
                var ts = DateTime.Now - StartedOn;
                return $"Started {(ts.Hours > 0 ? ts.Hours + "h" : "")}{ts.Minutes}m{ts.Seconds}s ago";
            }
        }

        public DateTime CompletedOn { get; set; }

        public ConnectionDetail Detail { get; set; }

        public string FinishedOn
        {
            get
            {
                var ts = DateTime.Now - StartedOn;
                return $"Completed in {ts.Minutes}m{ts.Seconds}s ({StartedOn:hh:mm:ss} / {CompletedOn:hh:mm:ss})";
            }
        }

        public bool IsProcessed { get; set; }
        public bool IsProcessing { get; set; }
        public OrganizationRequest Request { get; set; }
        public DateTime StartedOn { get; set; }
        public bool Succeeded { get; set; }

        public class ExportToProcess : ToProcess
        {
            public Guid AsyncOperationId { get; internal set; }
            public Guid ExportJobId { get; internal set; }
            public bool IsSolutionDownload { get; internal set; }

            public override string ToString()
            {
                return $"Export of solution {Solution.GetAttributeValue<string>("friendlyname")}";
            }
        }

        public class ImportToProcess : ToProcess
        {
            public Guid AsyncOperationId { get; set; }

            public ExportToProcess Export { get; set; }

            public override string ToString()
            {
                return $"Import of solution {Export.Solution.GetAttributeValue<string>("friendlyname")}";
            }
        }

        public class PublishToProcess : BaseToProcess
        {
        }

        public class ToProcess : BaseToProcess
        {
            public ToProcess Previous { get; set; }

            public Entity Solution { get; set; }
            public byte[] SolutionContent { get; set; }
        }
    }
}