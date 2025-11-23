namespace SampleCleanArchitecture.Infrastructure.Configuration.LookUp;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
{
    public void Configure(EntityTypeBuilder<CustomerType> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK_PU_CustomerType");

        entity.ToTable("CustomerType", Schemas.LookUp);

        entity.Property(e => e.Id).HasColumnName("CustomerTypeId");
        entity.Property(e => e.Code)
            .HasMaxLength(2)
            .IsUnicode(false);
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}