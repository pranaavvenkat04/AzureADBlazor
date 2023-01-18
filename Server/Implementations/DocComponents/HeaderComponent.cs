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
			column.Item().LineHorizontal(0.50f);
			column.Item().Element(HeaderTestElement);
		});
	}

	public void HeaderMainElement(IContainer container)
	{
		container.Row(row =>
		{
			row.RelativeItem().Element(HeaderMainLogoElement);
			row.RelativeItem().Element(HeaderMainInfoElement);
			row.RelativeItem().Element(HeaderMainTitleElement);
		});
	}

	public void HeaderMainLogoElement(IContainer container)
	{
		container.Column(column =>
		{
			column.Spacing(2.00f);

			var imagesFolder = "C:\\Users\\Pvenkatsubramanian\\AzureADBlazor\\Server\\Images\\";

            column.Item().Width(150).Image(Path.Combine(imagesFolder, "NYIT_LOGO.png"), ImageScaling.FitArea);

		});
	}
    public void HeaderMainInfoElement(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(0.00f);
            column.Item().Container().Row(row =>
            {
                row.RelativeItem().Column(addressColumn =>
                {
                    addressColumn.Spacing(-3.00f);

                    addressColumn.Item().Text(text =>
                    {
                        text.Hyperlink(companyAddress.Phone.Name, companyAddress.Phone.Url).Style(TextStyle.Default.FontFamily("Roboto-Bold").FontSize(10.00f));
                    });

                    addressColumn.Item().Text(text =>
                    {
                        text.Hyperlink(companyAddress.Email.Name, companyAddress.Email.Url).Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(10.00f));
                    });

                    addressColumn.Item().Text(text =>
                    {
                        text.Hyperlink(companyAddress.Website.Name, companyAddress.Website.Url).Style(TextStyle.Default.FontFamily("Roboto-Medium").FontSize(10.00f));
                    });
                });
            });
        });
    }
    public void HeaderMainTitleElement(IContainer container)
	{
		container.AlignRight().AlignBottom().Column(column =>
		{
			column.Item().Text(text =>
			{
				var textStyle = TextStyle.Default.FontFamily("Roboto-Medium").FontSize(22.00f);

				text.Span("Semester Transcript").Style(textStyle);
			});
		});
	}

	public void HeaderTestElement(IContainer container)
	{
		container.Row(row =>
		{
            var titleTextStyle = TextStyle.Default.FontFamily("Roboto-Bold").FontSize(10.00f);
            var labelTextStyle = TextStyle.Default.FontFamily("Roboto-Regular").FontSize(10.00f);
			var valueTextStyle = TextStyle.Default.FontFamily("Roboto-Light").FontSize(10.00f);

			row.Spacing(50.00f);

			var labelColumnSize = 60;
			var ColumnHeaderSize = 120;

			row.RelativeItem().Column(column =>
			{
				column.Item().Row(row =>
				{
					row.ConstantItem(ColumnHeaderSize).Text("Student Information").Style(titleTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Name:").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Patient.Name.Last}, {test.Patient.Name.First}").Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Date of Birth:").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.DateOfBirth.ToString(@"MM\/dd\/yyyy")).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Gender:").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.Gender.ToString()).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("ID:").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.Id).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Phone:").Style(labelTextStyle);
					row.RelativeItem().Text(test.Patient.HomePhone).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Address:").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Patient.Address.Address1} {test.Patient.Address.City} {test.Patient.Address.State}, {test.Patient.Address.Zip} ").Style(valueTextStyle);
				});

			});

			row.RelativeItem().Column(column =>
			{
				column.Item().Row(row =>
				{
					row.ConstantItem(ColumnHeaderSize).Text("Advisor Information").Style(titleTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Name:").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Doctor.Name.First} {test.Doctor.Name.Last}").Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Position:").Style(labelTextStyle);
					row.RelativeItem().Text(test.Organization.Name).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("Phone:").Style(labelTextStyle);
					row.RelativeItem().Text(test.Organization.Phone).Style(valueTextStyle);
				});

				column.Item().Row(row =>
				{
					row.ConstantItem(labelColumnSize).Text("NYIT Address:").Style(labelTextStyle);
					row.RelativeItem().Text($"{test.Organization.Address.Address1} {test.Organization.Address.City} {test.Organization.Address.State}, {test.Organization.Address.Zip}").Style(valueTextStyle);
				});
			});
		});
	}
}
