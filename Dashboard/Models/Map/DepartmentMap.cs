using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Models.Map
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        // Definindo as configurações das propriedades para o banco de dados
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Definindo o campo como chave primária
            builder.HasKey(b => b.DepartmentID);

            // Definindo requisitos das propriedades não primárias
            builder.Property(b => b.Name).IsRequired().HasMaxLength(30).HasColumnName("NAME");
        }
    }
}
