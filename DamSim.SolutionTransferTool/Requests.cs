using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;

namespace DamSim.SolutionTransferTool
{
    public class BaseToProcess
    {
        public ConnectionDetail Detail { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsProcessing { get; set; }
        public OrganizationRequest Request { get; set; }
    }

    public class ExportToProcess : ToProcess
    {
        public override string ToString()
        {
            return $"Export de la solution {Solution.GetAttributeValue<string>("friendlyname")}";
        }
    }

    public class ImportToProcess : ToProcess
    {
        public Guid AsyncOperationId { get; set; }

        public ExportToProcess Export { get; set; }

        public override string ToString()
        {
            return $"Import de la solution {Export.Solution.GetAttributeValue<string>("friendlyname")}";
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