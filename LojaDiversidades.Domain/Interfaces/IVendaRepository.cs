using LojaDiversidades.Domain.Entities;

namespace LojaDiversidades.Domain.Interfaces;

public interface IVendaRepository
{
    Task<List<Venda>> ListarAsync();
    Task<Venda?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Venda venda);
}
