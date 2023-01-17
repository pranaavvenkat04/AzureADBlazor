using AzureADBlazor.Server.Implementations.Classes;
using AzureADBlazor.Server.Implementations.Classes.SubClasses;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace AzureADBlazor.Server.Implementations;

public class HeaderComponent : IComponent
{
	private readonly Address companyAddress;
	private readonly ReportStatus reportStatus;
	private readonly bool isPathogenDetected;
	private readonly Test test;

	public HeaderComponent(Address companyAddress, ReportStatus reportStatus, bool isPathogenDetected, Test test)
	{
		this.companyAddress = companyAddress;
		this.reportStatus = reportStatus;
		this.isPathogenDetected = isPathogenDetected;
		this.test = test;
	}

	public void Compose(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(3.00f);

			column.Item().Element(HeaderMainElement);
			column.Item().LineHorizontal(0.50f).LineColor("61B1B0");
			column.Item().Element(HeaderTestElement);
		});
	}

	public void HeaderMainElement(IContainer container)
	{
		container.Row(row =>
		{
			row.RelativeItem(1.25f).Element(HeaderMainLogoElement);
			row.RelativeItem(2).Element(HeaderMainTitleElement);
			row.RelativeItem(1.25f).Element(HeaderMainStatusElement);
		});
	}

	public void HeaderMainLogoElement(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(4.00f);

			var imagesFolder = "C:\\Users\\Pvenkatsubramanian\\AzureADBlazor\\Server\\Images\\";

            column.Item().Width(82).Image(Path.Combine(imagesFolder, "Acutis Logo.png"), ImageScaling.FitArea);

			column.Item().Container().Row(row =>
			{
				row.RelativeItem().Column(addressColumn =>
				{
					addressColumn.Spacing(-3.00f);

					addressColumn.Item().Text(text =>
					{
						text.Hyperlink(companyAddress.Phone.Name, companyAddress.Phone.Url).Style(TextStyle.Default.FontFamily("Roboto-Bold").FontSize(11.00f).FontColor("E22561"));
					});

					addressColumn.Item().Text(text =>
					{
						text.Hyperlink(companyAddress.Email.Name, companyAddress.Email.Url).Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(8.00f).FontColor("3A727F"));
					});

					addressColumn.Item().Text(text =>
					{
						text.Hyperlink(companyAddress.Website.Name, companyAddress.Website.Url).Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(8.00f).FontColor("3A727F"));
					});
				});
			});
		});
	}

	public void HeaderMainTitleElement(IContainer container)
	{
		container.AlignCenter().AlignMiddle().Column(column =>
		{
			column.Item().Text(text =>
			{
				var textStyle = TextStyle.Default.FontFamily("Roboto-Medium").FontSize(22.00f).FontColor("61B1B0");

				text.Span("Acutis Reveal").Style(textStyle);
				text.Span("TM").Superscript().Style(textStyle);
				text.Span("Report").Style(textStyle);
			});
		});
	}

	public void HeaderMainStatusElement(IContainer container)
	{
		container.AlignRight().AlignMiddle().Column(column =>
		{
			column.Spacing(15.00f);

			column.Item().AlignRight().Text(text =>
			{
				text.Span("Status - ").Style(TextStyle.Default.FontFamily("Roboto-Light").FontSize(12.00f).FontColor("007174"));
				text.Span(reportStatus.ToString().ToUpper()).Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(12.00f).FontColor("3A727F").Bold());
			});

			if (isPathogenDetected)
				column.Item().AlignRight().Text("Pathogen Detected").Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(14.00f).FontColor("E22561"));
			else
				column.Item().AlignRight().Text("Pathogen Not Detected").Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(14.00f).FontColor("007174"));
		});
	}

	public void HeaderTestElement(IContainer container)
	{
		container.Row(row =>
		{
			var labelTextStyle = TextStyle.Default.FontFamily("Roboto-Light").FontSize(8.00f).FontColor("0D787B");
			var valueTextStyle = TextStyle.Default.FontFamily("Roboto-Regular").FontSize(8.00f).FontColor("404040");

			row.Spacing(50.00f);

			var labelColumnSize = 60;
			var ColumnHeaderSize = 120;

			row.RelativeItem().Column(column =>
			{
				column.Item().Row(row =>
				{
					row.ConstantItem(ColumnHeaderSize).Text("Patient Demographics:").Style(labelTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Name").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Patient.Name.Last}, {test.Patient.Name.First}").Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Date of Birth").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.DateOfBirth.ToString(@"MM\/dd\/yyyy")).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Gender").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.Gender.ToString()).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("ID").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.Id).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Phone").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.HomePhone).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Address").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Patient.Address.Address1} {test.Patient.Address.City} {test.Patient.Address.State}, {test.Patient.Address.Zip} ").Style(valueTextStyle);
				});

			});

			row.RelativeItem().Column(column =>
			{
				column.Item().Row(row =>
				{
					row.ConstantItem(ColumnHeaderSize).Text("Sample Details:").Style(labelTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Accession#").Style(labelTextStyle);
					row.RelativeItem().Text(test.AccessionId.ToString()).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Sample ID").Style(labelTextStyle);
					row.RelativeItem().Text(test.SampleId ?? "None").Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Matrix").Style(labelTextStyle);
					row.RelativeItem().Text(test.Matrix).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Collection Date").Style(labelTextStyle);
					row.RelativeItem().Text(test.CollectionDate.ToString(@"MM\/dd\/yyyy hh:mm tt")).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Received Date").Style(labelTextStyle);
					row.RelativeItem().Text(test.ReceivedDate.ToString(@"MM\/dd\/yyyy hh:mm tt")).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Reported Date").Style(labelTextStyle);
					row.RelativeItem().Text((test.ReportedDate ?? DateTime.Now).ToString(@"MM\/dd\/yyyy hh:mm tt")).Style(valueTextStyle);
				});
			});

			row.RelativeItem().Column(column =>
			{
				column.Item().Row(row =>
				{
					row.ConstantItem(ColumnHeaderSize).Text("Organization Demographics:").Style(labelTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Doctor").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Doctor.Name.First} {test.Doctor.Name.Last}").Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Organization").Style(labelTextStyle);
					row.RelativeItem().Text(test.Organization.Name).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Phone").Style(labelTextStyle);
					row.RelativeItem().Text(test.Organization.Phone).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Address").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Organization.Address.Address1} {test.Organization.Address.City} {test.Organization.Address.State}, {test.Organization.Address.Zip}").Style(valueTextStyle);
				});
			});
		});
	}
}
