namespace Thread.Modules.UserAccess.Infrastructure.Persistence.EntityTypeConfig;

internal sealed class UserRegistrationEntityTypeConfiguration : IEntityTypeConfiguration<UserRegistration>
{
    public void Configure(EntityTypeBuilder<UserRegistration> builder)
    {
        builder.ToTable("Registrations");

        builder.OwnsOne(r => r.Status)
            .Property(r => r.Value).HasColumnName("Status")
            .IsRequired();

        builder.Property(r => r.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(r => r.PasswordHash)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(r => r.RegisteredOn).IsRequired();

        builder.Ignore(r => r.DomainEvents);
    }
}