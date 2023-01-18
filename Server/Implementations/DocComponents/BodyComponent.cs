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
		var textStyle = TextStyle.Default.FontFamily("Roboto-Medium").FontSize(12.00f);

		container.Layers(layer =>
		{

			layer.PrimaryLayer().Column(column =>
			{
				column.Spacing(15.00f);

				column.Item().AlignLeft().Element(ComposeResults);
                column.Item().AlignLeft().Element(ComposeAverage);
            });
		});
	}

	private void ComposeResults(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(3.00f);

			column.Item().Text("Fall 2022").Style(TextStyle.Default.FontFamily("Roboto-Bold").FontSize(15.00f)); //Semester

			column.Item().Width(550f).Border(0.50f).Table(table =>
			{
				table.ColumnsDefinition(columnDefinition =>
				{
					columnDefinition.RelativeColumn(200);
                    columnDefinition.RelativeColumn(150);
                    columnDefinition.RelativeColumn(70);
                    columnDefinition.RelativeColumn(70);
                    
                });
		
				table.Header(header =>
				{
					var headerTextStyle = TextStyle.Default.FontFamily("Roboto-Bold").FontSize(12.00f).ExtraBold();

					header.Cell().Border(0.10f).AlignMiddle().PaddingVertical(7.00f).PaddingHorizontal(3.00f).Text("Course").Style(headerTextStyle);
                    header.Cell().Border(0.10f).AlignCenter().AlignMiddle().PaddingVertical(7.00f).PaddingHorizontal(3.00f).Text("Course Code").Style(headerTextStyle);
                    header.Cell().Border(0.10f).AlignCenter().AlignMiddle().PaddingVertical(7.00f).PaddingHorizontal(3.00f).Text("Credits").Style(headerTextStyle);
					header.Cell().Border(0.10f).AlignCenter().AlignMiddle().PaddingVertical(7.00f).PaddingHorizontal(3.00f).Text("Grade").Style(headerTextStyle);
                });

				var textStyle = TextStyle.Default.FontSize(8.50f);

				foreach (var stiPanelTestResult in stiPanelTestResults.Where(stiPanelTestResult => stiPanelTestResult.Result == "A"))
				{
					table.Cell().AlignLeft().AlignMiddle().PaddingVertical(3.00f).Text("  " + stiPanelTestResult.Test.Name).Style(TextStyle.Default.FontFamily("Roboto").FontSize(10.00f));
                    table.Cell().AlignCenter().AlignMiddle().PaddingVertical(3.00f).Text("  " + stiPanelTestResult.Test.CourseCode).Style(TextStyle.Default.FontFamily("Roboto").FontSize(10.00f));
                    table.Cell().AlignCenter().AlignMiddle().PaddingVertical(3.00f).Text("  " + stiPanelTestResult.Test.Credits).Style(TextStyle.Default.FontFamily("Roboto").FontSize(10.00f));
                    table.Cell().AlignCenter().AlignMiddle().PaddingVertical(3.00f).Text(stiPanelTestResult.Result).Style(textStyle.FontFamily("Roboto")).FontSize(10.00f);
                }
			});
		});
	}

    private void ComposeAverage(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(3.00f);

            column.Item().Width(550f).Table(table =>
            {
                table.ColumnsDefinition(columnDefinition =>
				{
                    columnDefinition.RelativeColumn(400);
                    columnDefinition.RelativeColumn(70);

                });

                var Average = 0.0;
				var TotalCredits = 0;
                table.Cell().AlignLeft().AlignMiddle().PaddingVertical(3.00f).Text("  Term GPA:" ).Style(TextStyle.Default.FontFamily("Roboto-Bold").FontSize(12.00f));
                foreach (var stiPanelTestResult in stiPanelTestResults)
                {
					Average += stiPanelTestResult.Test.Credits * 4.0;
					TotalCredits += stiPanelTestResult.Test.Credits;
                }
				Average = Math.Round((Average / TotalCredits) , 3);
				if(Average == 0.00 || Average == 1.00 || Average == 2.00 ||Average == 3.00 || Average == 4.00){
					table.Cell().AlignCenter().AlignMiddle().PaddingVertical(3.00f).Text("  " + Average + ".0").Style(TextStyle.Default.FontFamily("Roboto").FontSize(10.00f));
				}
				else
				{
					table.Cell().AlignCenter().AlignMiddle().PaddingVertical(3.00f).Text("  " + Average).Style(TextStyle.Default.FontFamily("Roboto").FontSize(10.00f));
				}
                
            });
        });
    }
}