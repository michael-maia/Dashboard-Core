#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dashboard.Models;
using Dashboard.Models.Map;

namespace Dashboard.Data
{
    public class DashboardContext : DbContext
    {
        public DashboardContext (DbContextOptions<DashboardContext> options) : base(options) { }

        // Entidades a serem criadas no DB
        public DbSet<User> User { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Site> Locations { get; set; }
        public DbSet<Gender> Genders { get; set; }

        // Definindo propriedades para a criação das tabelas
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Nome das tabelas para cada entidade
            builder.Entity<User>().ToTable("USER");
            builder.Entity<Department>().ToTable("DEPARTMENT");
            builder.Entity<Gender>().ToTable("GENDER");
            builder.Entity<Site>().ToTable("SITE");
            builder.Entity<Role>().ToTable("ROLE");

            // Aplicar configuração de mapeamento
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new DepartmentMap());
            builder.ApplyConfiguration(new GenderMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new SiteMap());
        }
    }
}
