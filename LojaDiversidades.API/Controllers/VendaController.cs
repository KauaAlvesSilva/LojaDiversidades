using LojaDiversidades.Application.Services;
using LojaDiversidades.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LojaDiversidades.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly VendaService _service;

    public VendaController(VendaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.ListarVendasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var venda = await _service.ObterVendaAsync(id);
        return venda is null ? NotFound() : Ok(venda);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Venda venda)
    {
        await _service.CriarVendaAsync(venda);
        return CreatedAtAction(nameof(Get), new { id = venda.Id }, venda);
    }
}
