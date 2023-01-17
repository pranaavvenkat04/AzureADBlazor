using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
 
namespace AzureADBlazor.Server.Implementations
{
    public class CreatePDF
    {
        public byte[] createPDF()
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .AlignCenter()
                        .Text("Hello World!")
                        .SemiBold().FontSize(36);
                });
            }).GeneratePdf();
        }
    }
}
