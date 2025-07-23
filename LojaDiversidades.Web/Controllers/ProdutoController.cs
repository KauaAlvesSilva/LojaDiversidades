using LojaDiversidades.Application.Services;
using LojaDiversidades.Domain.Entities;
using LojaDiversidades.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaDiversidades.Web.Controllers;

public class ProdutoController : Controller
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    public async Task<IActionResult> Index()
    {
        var role = HttpContext.Session.GetString("Role");
        if (role == "Administrador")
        {
            return RedirectToAction("Login", "Usuario");
        }

        var produtos = await _produtoService.ListarProdutosAsync();
        return View(produtos);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Produto produto)
    {
        await _produtoService.CriarAsync(produto);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remover(int id)
    {
        await _produtoService.RemoverAsync(id);
        return RedirectToAction("Index");
    }
}
