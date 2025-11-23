namespace SampleCleanArchitecture.Dto.Admin.Company
{
    public record CompanyForManipulationDto
    {
        public Guid? ParentCompanyId { get; init; }

        public string CompanyName { get; init; } = null!;

        public string? Address { get; init; }

        public string? City { get; init; }

        public string? State { get; init; }

        public int? CountryId { get; init; }

        public string? PostCode { get; init; }

        public string? Email { get; init; }

        public string? Phone { get; init; }

        public string? Fax { get; init; }

        public string? Website { get; init; }

        public string? Facebook { get; init; }

        public string? LinkedIn { get; init; }

        public string? Twitter { get; init; }

        public string? Youtube { get; init; }

        public int? RefCurrencyId { get; init; }

        public string? Logo { get; init; }
    }
}
