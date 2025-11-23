namespace SampleCleanArchitecture.Dto.Application.Customer
{
    public record CustomerForManipulationDto
    {
        public int RefCustomerTypeId { get; set; }
        public string Title { get; init; } = null!;

        public string FirstName { get; init; } = null!;

        public string? MiddleName { get; init; }

        public string LastName { get; init; } = null!;

        public string? Suffix { get; init; }

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


    }

}
