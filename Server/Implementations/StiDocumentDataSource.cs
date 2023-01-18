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
                        Name = "(800) 345-6948",
                        Url = "8003456948"
                    },
                    Website = new Website
                    {
                        Name = "www.nyit.edu",
                        Url = "https://www.nyit.edu/"
                    },
                    Email = new Email
                    {
                        Name = "asknyit@nyit.edu",
                        Url = "asknyit@nyit.edu"
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
                            First = "Pranaav",
                            Last = "Venkat"
                        },
                        DateOfBirth = new DateTime(2004, 11, 17),
                        Gender = "Male",
                        Id = "1309853",
                        Address = new Address
                        {
                            Address1 = "671 Lincoln Ave",
                            City = "Winnetka",
                            State = "IL",
                            Zip = "60093",
                        },
                        HomePhone = "(567) 257-1634"

                    },
                    Doctor = new Doctor
                    {
                        Name = new Name
                        {
                            First = "Pam",
                            Last = "Halpert"
                        }
                    },
                    Organization = new Organization
                    {
                        Name = "Freshman Advisor",
                        Phone = "(932) 443-7721",
                        Address = new Address
                        {
                            City = "Old Westbury",
                            Address1 = "Northern Boulvard, Valentines Lane",
                            State = "NY",
                            Zip = "11568"
                        }
                    }
                },
                PrintDate = DateTime.Now,
                StiPanelTestResults = new HashSet<TestResult<Organism>>
                {
                    new TestResult<Organism>(){Result = "A" , Test = new Organism{Name = "Computer Programming II" , CourseCode = "CSCI 185", Credits = 3}},
                    new TestResult<Organism>(){Result = "A" , Test = new Organism{Name = "Calculus II", CourseCode = "MATH 180", Credits = 4} },
                    new TestResult<Organism>(){Result = "A" , Test = new Organism{Name = "General Physics I", CourseCode = "PHYS 170", Credits = 4} },
                    new TestResult<Organism>(){Result = "A" , Test = new Organism{Name = "Foundations of Writing Composition", CourseCode = "FCWR 101", Credits = 3} },
                    new TestResult<Organism>(){Result = "A" , Test = new Organism{Name = "Career Discovery", CourseCode = "ETCS 105", Credits = 2} }
                }

            };
        }
    }
}