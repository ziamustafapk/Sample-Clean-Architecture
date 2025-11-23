namespace SampleCleanArchitecture.Domain.Models.Application;

public partial class Customer:BaseEntities
{
   public Guid RefCompanyId { get; set; }

    public int RefCustomerTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Suffix { get; set; }

    public string Company { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Fax { get; set; }

    public string? Website { get; set; }

    public string? TaxRegNo { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostCode { get; set; }

    public bool? IsShippingAddress { get; set; }

    public string? ShippingAddress { get; set; }

    public string? ShippingCity { get; set; }

    public string? ShippingState { get; set; }

    public string? ShippingCountry { get; set; }

    public string? ShippingPostCode { get; set; }

    public string? Notes { get; set; }

    public string? Password { get; set; }

    
    public virtual Company RefCompany { get; set; } = null!;

    public virtual CustomerType RefCustomerType { get; set; } = null!;
    
}