using Microsoft.AspNetCore.Mvc;
using Checkout.Applicattion.Interface;
using Checkout.Dominio.Entidades;
using Checkout.Applicattion.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Checkout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteComEnderecosDto>>> ListarClientesComEnderecos(int userIds)
        {
            var clientes = await _clienteService.ListarClientesComEnderecos(userIds);
            return Ok(clientes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ConsultarClientePorId(int id)
        {
            var cliente = await _clienteService.ConsultarClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> SalvarCliente([FromBody] Cliente cliente)
        {

            await _clienteService.SalvarCliente(cliente);
            return CreatedAtAction(nameof(ConsultarClientePorId), new { id = cliente.Id }, cliente);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> AtualizarCliente(int id, [FromBody] Cliente cliente)
        //{
        //    if (cliente == null || string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.CPF))
        //    {
        //        return BadRequest("Nome e CPF são obrigatórios.");
        //    }

        //    var atualizado = await _clienteService.AtualizarCliente(id);
        //    if (!atualizado)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeletarCliente(int id)
        //{
        //    var cliente = await _clienteService.ConsultarClientePorId(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    var deletado = await _clienteService.DeletarCliente(id, cliente);
        //    if (!deletado)
        //    {
        //        return BadRequest();
        //    }
        //    return NoContent();
        //}
    }
}
