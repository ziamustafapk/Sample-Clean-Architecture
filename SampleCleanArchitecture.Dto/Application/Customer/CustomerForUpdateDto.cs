namespace SampleCleanArchitecture.Dto.Application.Customer
{
    public record CustomerForUpdateDto : CustomerForManipulationDto
    {
        public bool IsDeleted { get; init; }

        public byte[] RowVersion { get; init; } = null!;


        
    }
}
