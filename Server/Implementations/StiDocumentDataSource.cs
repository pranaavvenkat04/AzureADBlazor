using AzureADBlazor.Server.Implementations.Classes;
using AzureADBlazor.Server.Implementations.Classes.SubClasses;

namespace AzureADBlazor.Server.Implementations
{
    public static class StiDocumentDataSource
    {
        public static StiReportModel GetStiDetails()
        {
            return new StiReportModel
            {
                CompanyAddress = new Address
                {
                    Address1 = "40 Karin St.",
                    City = "Hicksville",
                    State = "NY",
                    Zip = "11801",
                    Phone = new Phone
                    {
                        Name = "(844) 522-8847",
                        Url = "(844) 522-8847"
                    },
                    Website = new Website
                    {
                        Name = "https://www.acutis.com/",
                        Url = "https://www.acutis.com/"
                    },
                    Email = new Email
                    {
                        Name = "someone@acutis.com",
                        Url = "someone@acutis.com"
                    }
                },
                ReportStatus = new ReportStatus(),
                Test = new Test
                {
                    AccessionId = 0000,
                    IsCustomPdfOrdered = true,
                    LocationId = 1111,
                    DropRequired = true,
                    FaxRequired = true,
                    EmailRequired = true,
                    SampleId = "2222",
                    Matrix = "Something Matrixy",
                    CreatedDate = new DateTime(2022, 10, 24), // 10,24,2022
                    OrderDate = new DateTime(2022, 11, 10), // 11,10,2022
                    CollectionDate = new DateTime(2022, 12, 1, 12, 43, 21), // 12,1,2022
                    ReceivedDate = new DateTime(2022, 12, 13, 1, 32, 00), // 12,13,2022
                    ReportedDate = new DateTime(2023, 12, 23, 19, 09, 36), //12, 23, 2022
                    Patient = new Patient
                    {
                        Name = new Name
                        {
                            First = "Walter",
                            Last = "White"
                        },
                        DateOfBirth = new DateTime(1964, 1, 1),
                        Gender = "Male",
                        Id = "55",
                        Address = new Address
                        {
                            Address1 = "308 Belmont Avenue",
                            City = "Ontario",
                            State = "CA",
                            Zip = "91764",
                        },
                        HomePhone = "(567) 257-1634"

                    },
                    Doctor = new Doctor
                    {
                        Name = new Name
                        {
                            First = "Gregory",
                            Last = "House"
                        }
                    },
                    Organization = new Organization
                    {
                        Name = "Princeton–Plainsboro Teaching Hospital",
                        Phone = "(932) 443-7721",
                        Address = new Address
                        {
                            City = "Princeton",
                            Address1 = "25 Plainsboro Road",
                            State = "NJ",
                            Zip = "08540"
                        }
                    }
                },
                PrintDate = DateTime.Now,
                StiPanelTestResults = new HashSet<TestResult<Organism>>
                {
                    new TestResult<Organism>(){Result = "Detected" , Test = new Organism{Name = "Test 1"}},
                    new TestResult<Organism>(){Result = "Not Detected" , Test = new Organism{Name = "Test 2"} },
                    new TestResult<Organism>(){Result = "Detected" , Test = new Organism{Name = "Test 3"} },
                    new TestResult<Organism>(){Result = "Not Detected" , Test = new Organism{Name = "Test 4"} }
                }

            };
        }
    }
}