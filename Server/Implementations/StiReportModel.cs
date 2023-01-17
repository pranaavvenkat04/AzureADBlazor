using AzureADBlazor.Server.Implementations.Classes;
using AzureADBlazor.Server.Implementations.Classes.SubClasses;

namespace AzureADBlazor.Server.Implementations;

public class StiReportModel
{
    public Address CompanyAddress { get; set; }
    public ReportStatus ReportStatus { get; set; }
    public Test Test { get; set; }
    public DateTime PrintDate { get; set; }
    public IReadOnlySet<TestResult<Organism>> StiPanelTestResults { get; set; }
}