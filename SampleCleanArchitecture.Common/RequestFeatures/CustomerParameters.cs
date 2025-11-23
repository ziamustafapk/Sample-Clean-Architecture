namespace SampleCleanArchitecture.Common.RequestFeatures;

public class CustomerParameters : RequestParameters
{
    public CustomerParameters() => OrderBy = "FirstName";
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public string? FullName { get; set; }
    public bool? IsDeleted { get; set; } =false;
    public int? RefCustomerTypeId { get; set; }
}