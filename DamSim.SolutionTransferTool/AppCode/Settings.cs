using System;
using System.ComponentModel;
using System.Xml.Serialization;
using XrmToolBox.Extensibility;

namespace DamSim.SolutionTransferTool.AppCode
{
    public enum ImportModeEnum
    {
        [Description("Update")]
        Update,

        [Description("Stage for upgrade")]
        StageForUpgrade,

        [Description("Upgrade")]
        Upgrade
    }

    public enum UpdateVersionEnum
    {
        [Description("No")]
        No,

        [Description("Yes")]
        Yes,

        [Description("Prompt")]
        Prompt
    }

    public enum VersionType
    {
        [Description("Major (x.0.0.0)")]
        Major,

        [Description("Minor (0.x.0.0)")]
        Minor,

        [Description("Build (0.0.x.0)")]
        Build,

        [Description("Revision (0.0.0.x)")]
        Revision,

        [Description("Manual")]
        Manual,

        [Description("Date (yyyy.MM.dd.x)")]
        Date
    }

    public class Settings : ICloneable
    {
        public Settings()
        {
        }

        [Category("\tGeneral Settings")]
        [DisplayName("Auto save path")]
        [Description("Sets where solutions should be auto saved")]
        public string AutoExportSolutionsFolderPath { get; set; }

        [Category("\tGeneral Settings")]
        [DisplayName("\tAuto save solutions")]
        [Description("Sets wether to save exported solutions to disk")]
        public bool AutoExportSolutionsToDisk { get; set; }

        [Category("Import Settings")]
        [DisplayName("Check for missing dependencies")]
        [Description("Checks the missing dependencies in target environment before trying to import the solution")]
        public bool CheckForMissingDependencies { get; set; }

        [Category("Import Settings")]
        [DisplayName("Convert to managed")]
        [Description("Direct the system to convert any matching unmanaged customizations into your managed solution")]
        public bool ConvertToManaged { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export asynchronously")]
        [Description("Sets whether solution must be exported asynchronously")]
        public bool ExportAsynchronously { get; set; } = true;

        [Category("Export Settings")]
        [DisplayName("Export Autonumbers Settings")]
        [Description("Sets whether auto numbering settings should be included in the solution being exported")]
        public bool ExportAutoNumberingSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Calendar Settings")]
        [Description("Sets whether calendar settings should be included in the solution being exported")]
        public bool ExportCalendarSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Customization Settings")]
        [Description("Sets whether customization settings should be included in the solution being exported.")]
        public bool ExportCustomizationSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Email Tracking Settings")]
        [Description("Sets whether email tracking settings should be included in the solution being exported")]
        public bool ExportEmailTrackingSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export External Applications")]
        [Description("")]
        public bool ExportExternalApplications { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export General Settings")]
        [Description("Sets whether general settings should be included in the solution being exported")]
        public bool ExportGeneralSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export ISV Config")]
        [Description("Sets whether ISV.Config settings should be included in the solution being exported")]
        public bool ExportIsvConfig { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Marketing Settings")]
        [Description("Sets whether marketing settings should be included in the solution being exported")]
        public bool ExportMarketingSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Outlook Synchronization Settings")]
        [Description("Sets whether outlook synchronization settings should be included in the solution being exported")]
        public bool ExportOutlookSynchronizationSettings { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Relationship Roles")]
        [Description("Sets whether relationship role settings should be included in the solution being exported")]
        public bool ExportRelationshipRoles { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export Sales")]
        [Description("Sets whether sales settings should be included in the solution being exported")]
        public bool ExportSales { get; set; }

        [Category("Import Settings")]
        [DisplayName("Import Mode")]
        [Description(@"Update: Updates solution components but does not remove any
Stage for upgrade: Install a new version of the solution and keep the old one
Upgrade: Install a new version of the solution and remove missing components")]
        [TypeConverter(typeof(VersionTypeConverter))]
        public ImportModeEnum ImportMode { get; set; }

        [Category("Export Settings")]
        [DisplayName("Export as managed")]
        [Description("Sets whether the solution should be exported as a managed solution")]
        public bool Managed { get; set; } = true;

        [Category("Import Settings")]
        [DisplayName("Overwrite Unmanaged Customizations")]
        [Description("Sets whether any unmanaged customizations that have been applied over existing managed solution components should be overwritten")]
        public bool OverwriteUnmanagedCustomizations { get; set; } = true;

        [Category("Publish Settings")]
        [DisplayName("Publish Customizations")]
        public bool Publish { get; set; }

        [Category("Import Settings")]
        [DisplayName("Publish Workflows")]
        [Description("Sets whether any processes (workflows) included in the solution should be activated after they are imported")]
        public bool PublishWorkflows { get; set; } = true;

        [Browsable(false)]
        public long RefreshInterval
        {
            get => RefreshIntervalProp.Ticks;
            set => RefreshIntervalProp = new TimeSpan(value);
        }

        [Category("\tGeneral Settings")]
        [DisplayName("Refresh interval")]
        [Description("Interval to check for progress. Interval is used to start next step of solutions import so do not put a number too high here")]
        [XmlIgnore]
        public TimeSpan RefreshIntervalProp { get; set; } = new TimeSpan(0, 0, 0, 10);

        [Category("\tGeneral Settings")]
        [DisplayName("Pre Import Summary")]
        [Description("Shows a pre import summary before running import")]
        public bool ShowPreImportSummary { get; set; } = true;

        [Category("Import Settings")]
        [DisplayName("Skip Product Update Dependencies")]
        [Description("Sets whether enforcement of dependencies related to product updates should be skipped")]
        public bool SkipProductUpdateDependencies { get; set; }

        [Browsable(false)]
        [Obsolete("Replaced by UpdateSourceSolutionVersionNew")]
        public bool UpdateSourceSolutionVersion { get; set; }

        [Category("Solution Version")]
        [DisplayName("Update solution version")]
        [Description("Sets wether solution from source environement must be updated before export")]
        public UpdateVersionEnum UpdateSourceSolutionVersionNew { get; set; }

        [Category("\tGeneral Settings")]
        [DisplayName("Use Windows Toast Notification")]
        [Description("Sets where to use Windows Toast Notifications to report solution import success or failure")]
        public bool UseWindowsToastNotification { get; set; } = true;

        [Category("Solution Version")]
        [DisplayName("Date Version mask")]
        [Description("A mask like yyyy.MM.dd.x where x is an incremental figure")]
        public string VersionDateMask { get; set; }

        [Category("Solution Version")]
        [DisplayName("Version update policy")]
        [Description("Defines which part of the solution number must be incremented")]
        [TypeConverter(typeof(VersionTypeConverter))]
        public VersionType VersionSchema { get; set; }

        public object Clone()
        {
            return new Settings
            {
                AutoExportSolutionsFolderPath = AutoExportSolutionsFolderPath,
                AutoExportSolutionsToDisk = AutoExportSolutionsToDisk,
                CheckForMissingDependencies = CheckForMissingDependencies,
                ConvertToManaged = ConvertToManaged,
                ExportAsynchronously = ExportAsynchronously,
                ExportAutoNumberingSettings = ExportAutoNumberingSettings,
                ExportCalendarSettings = ExportCalendarSettings,
                ExportCustomizationSettings = ExportCustomizationSettings,
                ExportEmailTrackingSettings = ExportEmailTrackingSettings,
                ExportExternalApplications = ExportExternalApplications,
                ExportGeneralSettings = ExportGeneralSettings,
                ExportIsvConfig = ExportIsvConfig,
                ExportMarketingSettings = ExportMarketingSettings,
                ExportOutlookSynchronizationSettings = ExportOutlookSynchronizationSettings,
                ExportRelationshipRoles = ExportRelationshipRoles,
                ExportSales = ExportSales,
                ImportMode = ImportMode,
                Managed = Managed,
                OverwriteUnmanagedCustomizations = OverwriteUnmanagedCustomizations,
                Publish = Publish,
                PublishWorkflows = PublishWorkflows,
                RefreshIntervalProp = RefreshIntervalProp,
                SkipProductUpdateDependencies = SkipProductUpdateDependencies,
                UpdateSourceSolutionVersionNew = UpdateSourceSolutionVersionNew,
                VersionSchema = VersionSchema,
                VersionDateMask = VersionDateMask,
                ShowPreImportSummary = ShowPreImportSummary
            };
        }

        public void Save(string name = null)
        {
            SettingsManager.Instance.Save(typeof(SolutionTransferTool), this, name);
        }
    }
}