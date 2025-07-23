using LojaDiversidades.Domain.Entities;
using LojaDiversidades.Domain.Interfaces;

namespace LojaDiversidades.Application.Services;

public class ProdutoService 
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Produto>> ListarProdutosAsync() => await _repo.ListarAsync();
    public async Task<Produto?> ObterProdutoAsync(int id) => await _repo.ObterPorIdAsync(id);
    public async Task CriarAsync(Produto p) => await _repo.AdicionarAsync(p);
    public async Task AtualizarAsync(Produto p) => await _repo.AtualizarAsync(p);
    public async Task RemoverAsync(int id) => await _repo.RemoverAsync(id);
}
