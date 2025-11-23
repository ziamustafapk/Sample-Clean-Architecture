namespace SampleCleanArchitecture.Domain.Models.Base;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public byte[]? RowVersion { get; set; }
}




public class Entity<TKey>
{
    //[Key, Identity]
    [Column(Order = 0)]
    public virtual TKey Id { get; set; }
}
public interface IEntity<TKey>
{
    public TKey Id { get; set; }
    
}