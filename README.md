# CheckoutV1

**CheckoutV1** é uma API desenvolvida para gerenciar clientes e seus endereços, com o intuito de ser expandida para incluir a gestão de produtos e vendas, criando uma plataforma de venda completa.

## Índice

- [Introdução](#introdução)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints da API](#endpoints-da-api)
  - [Clientes](#clientes)
- [Configuração](#configuração)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Introdução

O **CheckoutV1** é uma API construída para gerir clientes e seus endereços, com a perspectiva de adicionar funcionalidades para produtos, permitindo uma gestão completa de vendas e estoque em uma plataforma integrada.

## Tecnologias Utilizadas

- **.NET Core**: Framework utilizado para construir a API.
- **Entity Framework Core**: ORM utilizado para o acesso ao banco de dados.
- **SQL Server**: Banco de dados relacional utilizado para armazenar os dados.
- **Swagger**: Ferramenta para documentação e teste da API.

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

CheckoutV1/
├── Checkout.Applicattion/
│   ├── DTOs/
│   ├── Interface/
│   ├── Service/
├── Checkout.Dominio/
│   ├── Entidades/
├── Checkout.Infrastructure/
│   ├── Interface/
│   ├── Persistence/
│   ├── Repository/
├── Checkout.Controllers/
├── Program.cs
├── Startup.cs
├── appsettings.json


## Endpoints da API

### Clientes

#### Listar Todos os Clientes com Endereços

- **Endpoint**: `/api/Cliente/ComEnderecos`
- **Método HTTP**: `GET`
- **Descrição**: Lista todos os clientes e seus endereços associados.

#### Consultar Cliente por ID

- **Endpoint**: `/api/Cliente/{id}`
- **Método HTTP**: `GET`
- **Descrição**: Consulta um cliente específico pelo seu ID.

#### Salvar Cliente

- **Endpoint**: `/api/Cliente`
- **Método HTTP**: `POST`
- **Descrição**: Salva um novo cliente com seus endereços.

#### Atualizar Cliente

- **Endpoint**: `/api/Cliente/{id}`
- **Método HTTP**: `PUT`
- **Descrição**: Atualiza os dados de um cliente existente.

#### Deletar Cliente

- **Endpoint**: `/api/Cliente/{id}`
- **Método HTTP**: `DELETE`
- **Descrição**: Deleta um cliente existente.

## Configuração

1. Clone o repositório:

   ```sh
   git clone https://github.com/Rafael-Oliveira-Gomes/CheckoutV1

2. Configure a string de conexão no arquivo appsettings.json:
    {
    "ConnectionStrings": {
        "ConnectionDB": "Server=SEU_SERVIDOR;Database=Checkout;Integrated Security=true;TrustServerCertificate=true;"
    }
}

3. Execute as migrações do Entity Framework para criar o banco de dados:
    Add-Migration Initial
    Update-Database



Contribuição
Contribuições são bem-vindas! Por favor, abra uma issue ou um pull request para sugestões de melhorias, correções de bugs ou novas funcionalidades.