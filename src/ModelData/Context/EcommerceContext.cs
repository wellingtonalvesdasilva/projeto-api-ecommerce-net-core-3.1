using Microsoft.EntityFrameworkCore;
using ModelData.Model;

namespace ModelData.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Disco> Disco { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaItem> VendaItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disco>().Property(d => d.Preco).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Venda>().Property(d => d.CashBackTotal).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<VendaItem>().Property(d => d.PrecoUnitario).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<VendaItem>().Property(d => d.CashBackUnitario).HasColumnType("decimal(10,2)");
            base.OnModelCreating(modelBuilder);
        }
    }
}
