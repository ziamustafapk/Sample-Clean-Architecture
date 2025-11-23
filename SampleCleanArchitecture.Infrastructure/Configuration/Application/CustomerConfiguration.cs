namespace SampleCleanArchitecture.Infrastructure.Configuration.Application
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            {
                entity.ToTable("Customer", Schemas.Application);

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()")
                    .HasColumnName("CustomerId");
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Company).HasMaxLength(150);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IsShippingAddress).HasDefaultValueSql("((1))");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Notes).HasMaxLength(1000);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PostCode).HasMaxLength(50);
                entity.Property(e => e.RefCompanyId).HasColumnName("RefCompanyID");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.ShippingAddress)
                    .HasMaxLength(500)
                    .HasColumnName("Shipping_Address");
                entity.Property(e => e.ShippingCity)
                    .HasMaxLength(50)
                    .HasColumnName("Shipping_City");
                entity.Property(e => e.ShippingCountry)
                    .HasMaxLength(50)
                    .HasColumnName("Shipping_Country");
                entity.Property(e => e.ShippingPostCode)
                    .HasMaxLength(50)
                    .HasColumnName("Shipping_PostCode");
                entity.Property(e => e.ShippingState)
                    .HasMaxLength(50)
                    .HasColumnName("Shipping_State");
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.Suffix)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TaxRegNo)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RefCompany).WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RefCompanyId)
                    .HasConstraintName("FK_Customer_Company");
            }
        }
    }
}
