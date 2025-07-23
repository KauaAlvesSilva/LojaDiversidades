using LojaDiversidades.Domain.Entities;
using LojaDiversidades.Domain.Interfaces;
using LojaDiversidades.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaDiversidades.Infrastructure.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Venda>> ListarAsync()
    {
        return await _context.Vendas
            .Include(v => v.Itens)
            .ToListAsync();
    }

    public async Task<Venda?> ObterPorIdAsync(int id)
    {
        return await _context.Vendas
            .Include(v => v.Itens)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task AdicionarAsync(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
    }
}
