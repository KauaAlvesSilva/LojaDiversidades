using LojaDiversidades.Application.Services;
using LojaDiversidades.Domain.Entities;
using LojaDiversidades.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaDiversidades.Web.Controllers;

public class VendaController : Controller
{
    private readonly VendaService _vendaService;
    private readonly ProdutoService _Produtoservice;
    private readonly UsuarioService _usuarioService;

    public VendaController(VendaService VendaService, ProdutoService produtoservice , UsuarioService usuarioService)
    {
        _vendaService = VendaService;
        _Produtoservice = produtoservice;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var role = HttpContext.Session.GetString("Role");
        if (role != "Cliente")
        {
            return RedirectToAction("Login", "Usuario");
        }

        var produtos = await _Produtoservice.ListarProdutosAsync();
        return View(produtos);
    }

    [HttpPost]
    public async Task<IActionResult> Finalizar([FromBody] List<ItemVenda> itens)
    {
        var email = HttpContext.Session.GetString("Email");

        if (string.IsNullOrEmpty(email))
            return Unauthorized("Usuário não autenticado.");

        var usuario = await _usuarioService.ObterPorEmailAsync(email);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        var novaVenda = new Venda
        {
            Cliente = usuario.Email,
            Data = DateTime.Now,
            Itens = itens
        };

        await _vendaService.CriarVendaAsync(novaVenda);

        return Ok();
    }


    public IActionResult Confirmacao()
    {
        return View();
    }
}
