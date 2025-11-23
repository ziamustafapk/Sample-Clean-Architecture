namespace SampleCleanArchitecture.Dto.LookUp
{
     public record CustomerTypeDto
    {
        public int Id { get; init; }

        public string Code { get; init; }

        public string Name { get; init; } 
    }
}
