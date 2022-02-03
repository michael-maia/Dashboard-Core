using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Models.Map
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        // Definindo as configurações das propriedades para o banco de dados
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            // Definindo o campo como chave primária
            builder.HasKey(b => b.GenderID);

            // Definindo requisitos das propriedades não primárias
            builder.Property(b => b.Name).IsRequired().HasMaxLength(30).HasColumnName("NAME");

            // Declarando as relações entre entidades
            // n-1 (User)
            //builder.HasMany(b => b.Users).WithOne(b => b.Gender).HasForeignKey(b => b.GenderID).HasConstraintName("USER_ID");
        }
    }
}
