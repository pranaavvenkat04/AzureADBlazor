using System.Numerics;
using AzureADBlazor.Server.Implementations.Classes.SubClasses;

namespace AzureADBlazor.Server.Implementations.Classes
{
    public record Test
    {
        public long AccessionId { get; init; }
        public bool IsCustomPdfOrdered { get; init; }
        public int LocationId { get; init; }
        public bool DropRequired { get; init; }
        public bool FaxRequired { get; init; }
        public bool EmailRequired { get; init; }
        public string SampleId { get; init; } = default!;
        public string Matrix { get; init; } = default!;
        public string Name { get; init; } = default!;
        public DateTime CreatedDate { get; init; }
        public DateTime OrderDate { get; init; }
        public DateTime CollectionDate { get; init; }
        public DateTime ReceivedDate { get; init; }
        public DateTime? ReportedDate { get; init; }
        public Patient Patient { get; init; } = default!;
        public Doctor Doctor { get; init; } = default!;
        public Organization Organization { get; init; } = default!;
    }

}
