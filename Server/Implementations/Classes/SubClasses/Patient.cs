
namespace AzureADBlazor.Server.Implementations.Classes.SubClasses
{
    public class Patient
    {
        public Name? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Id { get; set; }
        public Address? Address { get; set; }
        public string? HomePhone { get; set; }
    }
}