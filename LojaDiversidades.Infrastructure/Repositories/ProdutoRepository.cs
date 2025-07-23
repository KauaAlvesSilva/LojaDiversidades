using LojaDiversidades.Domain.Entities;
using LojaDiversidades.Domain.Interfaces;
using LojaDiversidades.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaDiversidades.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ListarAsync() =>
        await _context.Produtos.ToListAsync();

    public async Task<Produto?> ObterPorIdAsync(int id) =>
        await _context.Produtos.FindAsync(id);

    public async Task AdicionarAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var produto = await ObterPorIdAsync(id);
        if (produto is not null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
