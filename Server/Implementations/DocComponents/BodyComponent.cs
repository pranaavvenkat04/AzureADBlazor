using AzureADBlazor.Server.Implementations.Classes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AzureADBlazor.Server.Implementations;

public class BodyComponent : IComponent
{
	private readonly Test test;
	private readonly IReadOnlySet<TestResult<Organism>> stiPanelTestResults;

	public BodyComponent(Test test, IReadOnlySet<TestResult<Organism>> stiPanelTestResults)
	{
		this.test = test;
		this.stiPanelTestResults = stiPanelTestResults;
	}

	public void Compose(IContainer container)
	{
		var textStyle = TextStyle.Default.FontFamily("Roboto-Medium").FontSize(9.00f).FontColor("61B1B0");

		container.Layers(layer =>
		{
			layer.Layer().AlignBottom().AlignRight().Column(column =>
			{
				column.Item().PaddingBottom(-10.00f).PaddingRight(-35.00f).Row(row =>
				{
					row.AutoItem().RotateLeft().Text(text =>
					{
						var textStyle = TextStyle.Default.FontFamily("Roboto-Medium").FontSize(96.00f).FontColor("F6F6F6");

						text.Span("REVEAL").Style(textStyle);
						text.Span("TM").Superscript().Style(textStyle);
					});
				});
			});

			layer.Layer().AlignBottom().AlignCenter().Column(column =>
			{
				column.Item().AlignLeft().Text("Test System Details:").Style(textStyle);
				column.Item().AlignBottom().AlignCenter().Element(ComposeDisclaimer);
			});

			layer.PrimaryLayer().Column(column =>
			{
				column.Spacing(15.00f);

				column.Item().AlignLeft().Element(ComposeResults);

				column.Item().AlignRight().Element(ComposeNotes);
			});
		});
	}

	private void ComposeDisclaimer(IContainer container)
	{ 
		var textSytle = TextStyle.Default.FontFamily("Roboto-Light").FontSize(8.00f).FontColor("0D787B");

		container.Column(column =>
		{
			column.Item().AlignCenter().Text("STI:").Style(textSytle);
			column.Item().AlignCenter().Text("The Acutis Reveal STI Panel is FDA approved. This is qualitative test that utilize nucleic acid amplification technology(NAAT) methodology to").Style(textSytle);
			column.Item().AlignCenter().Text("detect specific nucleic acid targets.The acceptable samples type for this test are urine collected in Aptima Urine Collection Kit and vaginal").Style(textSytle);
			column.Item().AlignCenter().Text("swabs collected in the Aptima Multitest Swab Specimen Collection Kit.Patient - collected vaginal swab specimens are not an acceptable sample").Style(textSytle);
			column.Item().AlignCenter().Text("for this test.").Style(textSytle);
			column.Item().AlignCenter().Text("Results from this test should be interpreted in conjunction with all available laboratory and clinical data.Reliable results are dependent on").Style(textSytle);
			column.Item().AlignCenter().Text("adequate specimen collection.Therapeutic failure or success cannot be determined since nucleic acid may persist following appropriate").Style(textSytle);
			column.Item().AlignCenter().Text("antimicrobial therapy.A negative result does not preclude a possible infection because results are dependent on adequate specimen collection.").Style(textSytle);
			column.Item().AlignCenter().Text("Test results may be affected by improper specimen collection or target levels below the assay limit of detection.Mucus, vaginal moisturizing").Style(textSytle);
			column.Item().AlignCenter().Text("cream / gel and tioconazole may potentially interfere with this test.If negative results from the specimen do not fit with the clinical impression, a").Style(textSytle);
			column.Item().AlignCenter().Text("new specimen may be necessary.A positive test result does not necessarily indicate the presence of viable organisms.Public health").Style(textSytle);
			column.Item().AlignCenter().Text("recommendations should be consulted regarding testing for additional sexually transmitted infections for positive patients.").Style(textSytle);
			column.Item().AlignCenter().Text("This assay is not intended for the evaluation of suspected sexual abuse or for other medico-legal indications.For those patients for whom a false").Style(textSytle);
			column.Item().AlignCenter().Text("positive result may have adverse psycho - social impact, the CDC recommends retesting.This test has not been evaluated in adolescents less").Style(textSytle);
			column.Item().AlignCenter().Text("than 15 years of age.").Style(textSytle);
			column.Item().AlignCenter().Text("Laboratory Director: Marjorie Bon Homme, PhD, DABCC").Style(textSytle);
			column.Item().AlignCenter().Text("Acutis Diagnostics; CLIA ID # 33D2087537; 400 Karin Ln., Hicksville, NY 11801").Style(textSytle);
		});
	}

	private void ComposeNotes(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(3.00f);

			column.Item().Background(Colors.Grey.Darken1).Text("Notes:").Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(11.00f).FontColor(Colors.White));

			column.Item()
		   .Height(250)
		   .Width(150)
		   .Background("EDF5F4")
		   .Text("Test Notes").FontSize(9)
		   .Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(8.00f).FontColor("3A727F"));
		});

	}

	private void ComposeResults(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(3.00f);

			column.Item().Text("Sexually Transmitted Infection (STI) - PCR/NAAT").Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(11.00f).FontColor("3A727F"));

			column.Item().Width(400f).Border(0.50f).BorderColor("3A727F").Table(table =>
			{
				table.ColumnsDefinition(columnDefinition =>
				{
					columnDefinition.RelativeColumn(300);
					columnDefinition.RelativeColumn(100);
				});

				table.Header(header =>
				{
					var headerTextStyle = TextStyle.Default.FontFamily("Roboto-Regular").FontSize(9.00f).FontColor("007174");

					header.Cell().Border(0.10f).BorderColor("3A727F").Background("EDF5F4").PaddingVertical(1.00f).PaddingHorizontal(3.00f).Text("Test Name").Style(headerTextStyle);

					header.Cell().Border(0.10f).BorderColor("3A727F").Background("EDF5F4").PaddingVertical(1.00f).PaddingHorizontal(3.00f).Text("Outcome").Style(headerTextStyle);
				});

				var textStyle = TextStyle.Default.FontSize(8.50f);

				foreach (var stiPanelTestResult in stiPanelTestResults.Where(stiPanelTestResult => stiPanelTestResult.Result == "Detected"))
				{
					table.Cell().Border(0.10f).BorderColor("3A727F").AlignLeft().AlignMiddle().Text(stiPanelTestResult.Test.Name).Style(TextStyle.Default.FontFamily("Roboto").FontColor("007174").FontSize(9.00f));
					table.Cell().Border(0.10f).BorderColor("3A727F").AlignCenter().AlignMiddle().Text(stiPanelTestResult.Result).Style(textStyle.FontFamily("Roboto")).FontColor("007174").FontSize(9.00f);
				}
			});
		});
	}
}