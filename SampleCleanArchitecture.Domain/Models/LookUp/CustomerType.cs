namespace SampleCleanArchitecture.Domain.Models.LookUp;

public partial class CustomerType: BaseEntity<int>
{
       
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}