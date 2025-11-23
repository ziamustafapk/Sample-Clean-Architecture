namespace SampleCleanArchitecture.Dto.Admin.Company
{
    public record CompanyDto
    {
       
        public Guid Id { get; init; }

        public Guid? ParentCompanyId { get; init; }

        public string? CompanyCode { get; init; }

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

        public bool EmailVerified { get; init; }

        public bool IsActive { get; init; }

        public bool IsDeleted { get; init; }

        public string CreatedBy { get; init; } = null!;

        public DateTime CreatedDate { get; init; }

        public string? ModifiedBy { get; init; }

        public DateTime? ModifiedDate { get; init; }

        public byte[] RowVersion { get; init; } = null!;

    
        //public virtual Company? ParentCompany { get; init; }
    }
}
