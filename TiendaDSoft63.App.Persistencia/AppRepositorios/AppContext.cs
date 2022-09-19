using Microsoft.EntityFrameworkCore;
using TiendaDSoft63.App.Dominio;

namespace TiendaDSoft63.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Administrador> Administradores {get;set;}
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Producto> Productos {get;set;}
        public DbSet<Tienda> Tiendas {get;set;}
        public DbSet<Vendedor> Vendedores {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TiendaDSoft63Data");
            }
        }
    }
}