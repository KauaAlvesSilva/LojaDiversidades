using LojaDiversidades.Domain.Entities;
using System.Threading.Tasks;

public class UsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email) => await _repo.ObterPorEmailAsync(email);

    public async Task<bool> ValidarLoginAsync(string email)
    {
        var usuario = await _repo.ObterPorEmailAsync(email);
        if (usuario == null) return false;

        // Aqui pode ter hash de senha se quiser, por enquanto compara simples
        return true;
    }

    public async Task<bool> CadastrarUsuarioAsync(Usuario usuario)
    {
        var existente = await _repo.ObterPorEmailAsync(usuario.Email);
        if (existente != null)
            return false; // Já existe usuário com esse email

        await _repo.AdicionarAsync(usuario);
        return true;
    }
}
