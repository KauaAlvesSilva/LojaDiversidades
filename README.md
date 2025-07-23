# Loja de Diversidades

Sistema completo para uma loja online com gerenciamento de usuários, produtos e vendas, utilizando arquitetura em camadas e interface web com autenticação por perfil (Administrador e Cliente).

## Tecnologias Utilizadas

* ASP.NET Core 5.0
* Razor Pages (MVC)
* Entity Framework Core
* SQL Server
* C# Assíncrono (async/await)

## Estrutura do Projeto

### LojaDiversidades.API

* Controllers para Produtos, Vendas e Usuários
* Services e Repositórios com injeção de dependência

### LojaDiversidades.Domain

* Entidades: Usuario, Produto, Venda, ItemVenda
* Interfaces de Repositórios

### LojaDiversidades.Application

* Serviços de negócio intermediando controllers e repositórios
* Lógica de manipulação de dados (ex: cálculos, regras de negócio)

### LojaDiversidades.Infrastructure

* Implementações dos repositórios
* Contexto do banco de dados com Entity Framework

### LojaDiversidades.Web

* Razor Pages para Login, Cadastro, Compra e Gestão de Produtos
* Validação de sessão e redirecionamento por Role
* JavaScript para adição de itens ao carrinho e finalização da compra

## Como Executar

### Pré-requisitos

* Visual Studio 2022 ou superior
* .NET 5.0 SDK
* SQL Server LocalDB ou outro SQL Server disponível

### Configuração do Banco de Dados

Como não utilizamos Migrations, crie o banco manualmente com o script abaixo:

```sql
CREATE DATABASE LojaDiversidades;
GO

USE LojaDiversidades;
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(100) NOT NULL,
    Senha NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Produtos (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Preco DECIMAL(18,2) NOT NULL,
    Estoque INT NOT NULL
);

CREATE TABLE Vendas (
    Id INT PRIMARY KEY IDENTITY,
    Cliente NVARCHAR(100) NOT NULL,
    Data DATETIME NOT NULL,
    Total DECIMAL(18,2) NOT NULL
);

CREATE TABLE ItensVenda (
    Id INT PRIMARY KEY IDENTITY,
    VendaId INT NOT NULL,
    ProdutoId INT NOT NULL,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (VendaId) REFERENCES Vendas(Id),
    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
);
```

### Configuração

1. Altere a `ConnectionString` em `appsettings.json` da API e do projeto Web para apontar para o seu banco de dados SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LojaDiversidades;Trusted_Connection=True;"
}
```

2. Execute os o projeto Web:
   * **LojaDiversidades.Web**: interface do usuário via Razor Pages

## Funcionalidades

* Cadastro e login de usuários com validação por Role
* Clientes podem visualizar produtos e realizar compras
* Administradores podem gerenciar produtos
* Carrinho de compras com JavaScript
* Finalização de compra salvando venda e itens no banco

## Observações

* Todos os métodos são assíncronos (async/await)
* O sistema usa session para controle de login e Role
* O redirecionamento impede acesso a páginas administrativas por clientes

---
