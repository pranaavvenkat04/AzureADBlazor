using AzureADBlazor.Server.Implementations;
using QuestPDF.Fluent;

namespace AzureADBlazor.Server.Implementations
{
    public class GenerateService
    {
        public byte[] GeneratePDF()
        {
            
            var model = StiDocumentDataSource.GetStiDetails();
            var document = new ReportDocument(model);
            var pdf = document.GeneratePdf();
            /*var document = new CreatePDF();
            var pdf = document.createPDF();*/
            return pdf;
        }
    }
}
