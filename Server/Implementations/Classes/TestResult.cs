using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection.Metadata.Ecma335;

namespace AzureADBlazor.Server.Implementations.Classes
{
   
    public record Organism
    {
        
        public string Name { get; set; }

        public string CourseCode { get; set; }
        public int Credits { get; set; }

        
        
    }
    public class TestResult<Organism>
    {
        public Organism Test { get; init; }
        public string Result { get; set; }
    }
}
