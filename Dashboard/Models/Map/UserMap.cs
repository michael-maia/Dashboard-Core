using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Models.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        // Definindo as configurações das propriedades para o banco de dados
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Definindo o campo como chave primária
            builder.HasKey(b => b.UserID);

            // Definindo requisitos das propriedades não primárias
            builder.Property(b => b.FirstName).IsRequired().HasMaxLength(30).HasColumnName("FIRST_NAME");
            builder.Property(b => b.LastName).IsRequired().HasMaxLength(50).HasColumnName("LAST_NAME");
            builder.Property(b => b.BirthDate).IsRequired().HasColumnType("date").HasColumnName("BIRTH_DATE");            
            builder.Property(b => b.Password).IsRequired().HasMaxLength(50).HasColumnName("PASSWORD");
            builder.Property(b => b.CreatedDate).IsRequired().HasColumnName("CREATED_DATE");
            builder.Property(b => b.Email).IsRequired().HasMaxLength(50).HasColumnName("EMAIL");

            // Esta propriedade é única e não pode ser repetida
            builder.HasIndex(b => b.Email).IsUnique();

            // Declarando as relações entre entidades
            // 1-n (Role / Site / Gender)
            builder.HasOne(b => b.Role).WithMany(b => b.Users).HasForeignKey(b => b.RoleID).HasConstraintName("ROLE_ID");                       
            builder.HasOne(b => b.Site).WithMany(b => b.Users).HasForeignKey(b => b.SiteID).HasConstraintName("SITE_ID");
            builder.HasOne(b => b.Gender).WithMany(b => b.Users).HasForeignKey(b => b.GenderID).HasConstraintName("GENDER_ID");

            // n-n (Department)
            builder.HasMany(b => b.Departments).WithMany(b => b.Users).UsingEntity(m => m.ToTable("USER_DEPARTMENT"));
        }
    }
}
