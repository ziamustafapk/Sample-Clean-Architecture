using SampleCleanArchitecture.Dto.LookUp;

namespace SampleCleanArchitecture.Dto.Application.Customer
{
    [Serializable]
    public record CustomerDto
    {
        //public Guid CustomerId { get; init; }
        public Guid Id { get; init; }
        public Guid? RefCompanyId { get; init; }
        public int RefCustomerTypeId { get; set; }

        public string Title { get; init; } = null!;

        public string FirstName { get; init; } = null!;

        public string? MiddleName { get; init; }

        public string LastName { get; init; } = null!;

        //public string? Suffix { get; init; }

        public string Company { get; init; } = null!;

        public string Email { get; init; } = null!;

        public string Phone { get; init; } = null!;

        public string? Mobile { get; init; }

        public string? Fax { get; init; }

        public string? Website { get; init; }

        public string? TaxRegNo { get; init; }

        public string? Address { get; init; }

        public string? City { get; init; }

        public string? State { get; init; }

        public string? Country { get; init; }

        public string? PostCode { get; init; }

        public bool? IsShippingAddress { get; init; }

        public string? ShippingAddress { get; init; }

        public string? ShippingCity { get; init; }

        public string? ShippingState { get; init; }

        public string? ShippingCountry { get; init; }

        public string? ShippingPostCode { get; init; }

        public string? Notes { get; init; }

        public string? Password { get; init; }

        public bool IsActive { get; init; }

        public bool IsDeleted { get; init; }

        public string CreatedBy { get; init; } = null!;

        public DateTime CreatedDate { get; init; }

        public string? ModifiedBy { get; init; }

        public DateTime? ModifiedDate { get; init; }

        public byte[] RowVersion { get; init; } = null!;
        // public  Company? RefCompany { get; init; }

        public virtual CustomerTypeDto RefCustomerType { get; set; } = null!;
    }

}
