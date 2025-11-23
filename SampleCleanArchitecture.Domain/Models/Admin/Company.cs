namespace SampleCleanArchitecture.Domain.Models.Admin;

public partial class Company :BaseEntities
{
 
    public Guid? ParentCompanyId { get; set; }

    public string? CompanyCode { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? CountryId { get; set; }

    public string? PostCode { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Website { get; set; }

    public string? Facebook { get; set; }

    public string? LinkedIn { get; set; }

    public string? Twitter { get; set; }

    public string? Youtube { get; set; }

    public int? RefCurrencyId { get; set; }

    public string? Logo { get; set; }

    public bool EmailVerified { get; set; }

 
 
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Company> InverseParentCompany { get; set; } = new List<Company>();

    public virtual Company? ParentCompany { get; set; }
   
}

