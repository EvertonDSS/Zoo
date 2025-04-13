using GerenciamentoZoo.Contrato.Cuidados;
using GerenciamentoZoo.Contrato.Cuidados.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoZoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuidadosController : ControllerBase
    {
        private readonly ICuidadosUseCase _cuidadosUseCase;

        public CuidadosController(ICuidadosUseCase cuidadosUseCase)
        {
            _cuidadosUseCase = cuidadosUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animais = await _cuidadosUseCase.ListarTodosCuidados();
            return Ok(animais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _cuidadosUseCase.BuscarCuidadoPorId(id);
            
            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CuidadosCreateDto createDto)
        {
            var animalCriado = await _cuidadosUseCase.AdicionarCuidado(createDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = animalCriado.Id },
                animalCriado
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,CuidadosDto updateDto)
        {
            var animal = await _cuidadosUseCase.AlterarCuidado(id,updateDto);
           
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _cuidadosUseCase.RemoverCuidadoCuidado(id);
           
            return Ok(animal);
        }
    }
}
