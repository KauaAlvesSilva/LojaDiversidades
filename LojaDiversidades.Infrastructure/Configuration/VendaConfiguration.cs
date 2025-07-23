using LojaDiversidades.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaDiversidades.Infrastructure.Data.Configurations
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(v => v.Itens)
            .WithOne(iv => iv.Venda)
            .HasForeignKey(iv => iv.VendaId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
