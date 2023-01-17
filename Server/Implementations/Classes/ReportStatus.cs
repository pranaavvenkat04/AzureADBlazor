using System.ComponentModel;

namespace AzureADBlazor.Server.Implementations.Classes
{
    public enum ReportStatus
    {
        Unknown,
        [Description("Pathogen Not Detected")]
        PathogenNotDetected,
        [Description("Pathogen Detected")]
        PathogenDetected,
        [Description("Abnormality Not Detected")]
        AbnormalityNotDetected,
        [Description("Abnormality Detected")]
        AbnormalityDetected,
        [Description("Contamination Suspected")]
        ContaminationSuspected
    }
}