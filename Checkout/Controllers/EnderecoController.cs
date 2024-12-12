//using Checkout.Applicattion.Interface;
//using Checkout.Dominio.Entidades;
//using Microsoft.AspNetCore.Mvc;

//namespace Checkout.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EnderecoController : ControllerBase
//    {
//        private readonly IEnderecoService _enderecoService;

//        public EnderecoController(IEnderecoService enderecoService)
//        {
//            _enderecoService = enderecoService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Endereco>>> ListarEnderecos()
//        {
//            var enderecos = await _enderecoService.ListarEnderecos();
//            return Ok(enderecos);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Endereco>> ConsultarEnderecoPorId(int id)
//        {
//            var endereco = await _enderecoService.ConsultarEnderecoPorId(id);
//            if (endereco == null)
//            {
//                return NotFound();
//            }
//            return Ok(endereco);
//        }

//        [HttpPost]
//        public async Task<ActionResult> SalvarEndereco(Endereco endereco)
//        {
//            await _enderecoService.SalvarEndereco(endereco);
//            return CreatedAtAction(nameof(ConsultarEnderecoPorId), new { id = endereco.Id }, endereco);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> AtualizarEndereco(int id, Endereco endereco)
//        {
//            var atualizado = await _enderecoService.AtualizarEndereco(id, endereco);
//            if (!atualizado)
//            {
//                return NotFound();
//            }
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeletarEndereco(int id)
//        {
//            var endereco = await _enderecoService.ConsultarEnderecoPorId(id);
//            if (endereco == null)
//            {
//                return NotFound();
//            }

//            var deletado = await _enderecoService.DeletarEndereco(id, endereco);
//            if (!deletado)
//            {
//                return BadRequest();
//            }
//            return NoContent();
//        }
//    }
//}
