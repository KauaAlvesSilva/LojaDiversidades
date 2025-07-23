using LojaDiversidades.Domain.Entities;
using LojaDiversidades.Domain.Interfaces;

namespace LojaDiversidades.Application.Services;

public class VendaService
{
    private readonly IVendaRepository _repo;

    public VendaService(IVendaRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Venda>> ListarVendasAsync() => await _repo.ListarAsync();

    public async Task<Venda?> ObterVendaAsync(int id) =>  await _repo.ObterPorIdAsync(id);

    public async Task CriarVendaAsync(Venda venda)
    {
        // Calcular total
        venda.Total = venda.Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        await _repo.AdicionarAsync(venda);
    }
}
