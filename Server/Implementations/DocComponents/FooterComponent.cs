using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AzureADBlazor.Server.Implementations;

public class FooterComponent : IComponent
{
	private readonly DateTime printDate;

	public FooterComponent(DateTime printDate)
	{
		this.printDate = printDate;
	}

	public void Compose(IContainer container)
	{
		container.Column(parentColumn =>
		{
			var textStyle = TextStyle.Default.FontFamily("Roboto-Regular").FontSize(6.50f).FontColor("0C0C0C");

			parentColumn.Item().LineHorizontal(0.50f).LineColor(Colors.Black);

			parentColumn.Item().Row(row =>
			{
				row.RelativeItem().AlignRight().Column(column =>
				{
                    column.Item().AlignRight().Text($"Hire Me, Pretty Please.").Style(textStyle);

                    column.Item().AlignRight().Text($"Printed: {printDate.ToString(@"MM\/dd\/yyyy hh:mm tt")}").Style(textStyle);
                });
			});
		});
	}
}
