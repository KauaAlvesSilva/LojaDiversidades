using LojaDiversidades.Application.Services;
using LojaDiversidades.Domain.Interfaces;
using LojaDiversidades.Infrastructure.Data;
using LojaDiversidades.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Adiciona suporte a controllers
builder.Services.AddControllers();

// Configuração básica de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

 builder.Services.AddScoped<ProdutoService>();
 builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>(); 

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<VendaService>();

var app = builder.Build();

// Middlewares
app.UseCors("AllowAll");

app.UseAuthorization(); // mantém se futuramente quiser usar políticas simples

app.MapControllers();

app.Run();
