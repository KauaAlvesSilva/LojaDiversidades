using Microsoft.AspNetCore.Mvc;
using LojaDiversidades.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LojaDiversidades.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController (UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email)
        {
            var usuario = await _usuarioService.ObterPorEmailAsync(email);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Role", usuario.Role);

                if (usuario.Role == "Cliente")
                {
                    return RedirectToAction("Index", "Venda");

                }
                else
                {
                    return RedirectToAction("Index","Produto");
                }
            }
            ModelState.AddModelError("", "Usúario não encontrado.");
            return RedirectToAction("Cadastro", new { email });
        }

        [HttpGet]
        public async Task<IActionResult> Cadastro(string? email)
        {
            ViewBag.Email = email;
            return View("Cadastro");
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(string email, string role)
        {
            var usuario = await _usuarioService.CadastrarUsuarioAsync(new Usuario { Email = email, Role = role });
            if (usuario == true)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Usuário já cadastrado.");
            return View("Cadastro");
        }
    }
}
