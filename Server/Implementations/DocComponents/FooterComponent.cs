using QuestPDF.Fluent;
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

			parentColumn.Item().LineHorizontal(0.50f).LineColor("61B1B0");

			parentColumn.Item().Row(row =>
			{
				row.RelativeItem().AlignRight().Column(column =>
				{
					column.Item().AlignRight().Text($"Printed: {printDate.ToString(@"MM\/dd\/yyyy hh:mm tt")}").Style(textStyle);

					column.Item().AlignRight().Text(text =>
					{
						text.Span("Page ").Style(textStyle);
						text.CurrentPageNumber().Style(textStyle);
						text.Span(" of ").Style(textStyle);
						text.TotalPages().Style(textStyle);
					});
				});
			});
		});
	}
}
