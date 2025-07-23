using LojaDiversidades.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task AdicionarAsync(Usuario usuario);
}
