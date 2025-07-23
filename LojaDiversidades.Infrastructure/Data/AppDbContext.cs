using LojaDiversidades.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<ItemVenda> ItensVenda { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(iv => iv.Venda)
            .WithMany(v => v.Itens)
            .HasForeignKey(iv => iv.VendaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(iv => iv.Produto)
            .WithMany()
            .HasForeignKey(iv => iv.ProdutoId);
    }
}
