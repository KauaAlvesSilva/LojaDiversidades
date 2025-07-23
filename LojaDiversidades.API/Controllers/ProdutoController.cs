using LojaDiversidades.Application.Services;
using LojaDiversidades.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LojaDiversidades.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.ListarProdutosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var produto = await _service.ObterProdutoAsync(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Produto produto)
    {
        await _service.CriarAsync(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Produto produto)
    {
        if (id != produto.Id) return BadRequest("ID não confere.");
        await _service.AtualizarAsync(produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }
}
