using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AzureADBlazor.Server.Implementations;

public class ReportDocument : IDocument
{
	public StiReportModel Model { get; init; }

	public ReportDocument(StiReportModel model)
	{
		Model = model;
	}

	public DocumentMetadata GetMetadata()
	{
        var dm = new DocumentMetadata
        {
            Author = "Acutis",
            CreationDate = DateTime.Now
        };

        return DocumentMetadata.Default;
	}

    public void Compose(IDocumentContainer container)
	{
		var fontsFolder = "C:\\Users\\Pvenkatsubramanian\\AzureADBlazor\\Server\\Fonts\\";
		FontManager.RegisterFontType("Roboto-Light", File.OpenRead(Path.Combine(fontsFolder, "Roboto-Light.ttf")));
		FontManager.RegisterFontType("Roboto-Regular", File.OpenRead(Path.Combine(fontsFolder, "Roboto-Regular.ttf")));
		FontManager.RegisterFontType("Roboto-Medium", File.OpenRead(Path.Combine(fontsFolder, "Roboto-Medium.ttf")));
		FontManager.RegisterFontType("Roboto-MediumItalic", File.OpenRead(Path.Combine(fontsFolder, "Roboto-MediumItalic.ttf")));
		FontManager.RegisterFontType("Roboto-Bold", File.OpenRead(Path.Combine(fontsFolder, "Roboto-Bold.ttf")));
		FontManager.RegisterFontType("Roboto-BoldItalic", File.OpenRead(Path.Combine(fontsFolder, "Roboto-BoldItalic.ttf")));

		container.Page(page =>
		{
			page.Size(PageSizes.Letter);

			page.MarginTop(15);
			page.MarginRight(25);
			page.MarginBottom(5);
			page.MarginLeft(25);

			// dynamic pathogen detected
			var isPathogenDetected = true;

			page.Header().Component(new HeaderComponent(Model.CompanyAddress, Model.ReportStatus, isPathogenDetected, Model.Test));
			page.Content().PaddingVertical(15.00f).Component(new BodyComponent(Model.Test,Model.StiPanelTestResults));
			page.Footer().Component(new FooterComponent(Model.PrintDate));
		});
	}
}
