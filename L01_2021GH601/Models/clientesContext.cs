using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2021GH601.Models
{
    public class restuaranteDBContext : DbContext
    {
        public restuaranteDBContext(DbContextOptions<restuaranteDBContext> options) : base(options)
        {

        }

        public DbSet<clientes> clientes { get; set; }
        public DbSet<motorista> motorista { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<platos> platos { get; set; }
    }
}
