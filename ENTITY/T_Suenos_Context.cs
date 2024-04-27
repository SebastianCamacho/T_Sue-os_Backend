using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ENTITY
{
    public class T_Suenos_Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public T_Suenos_Context(DbContextOptions<T_Suenos_Context> options) : base(options)
        {

        }

    }
}
