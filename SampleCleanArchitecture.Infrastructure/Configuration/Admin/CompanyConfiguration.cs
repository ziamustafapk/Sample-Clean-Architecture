namespace SampleCleanArchitecture.Infrastructure.Configuration.Admin
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.ToTable("Company", Schemas.Admin);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()")
                .HasColumnName("CompanyId");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Facebook)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LinkedIn)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.Logo).IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ParentCompanyId).HasColumnName("ParentCompanyID");
            entity.Property(e => e.Phone)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefCurrencyId).HasColumnName("RefCurrencyID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Twitter)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.Youtube)
                .HasMaxLength(550)
                .IsUnicode(false);

            entity.HasOne(d => d.ParentCompany).WithMany(p => p.InverseParentCompany)
                .HasForeignKey(d => d.ParentCompanyId)
                .HasConstraintName("FK_Company_Company");
        }
    }
}
