using GerenciamentoZoo.Contrato.Animais;
using GerenciamentoZoo.Contrato.Animais.DTO;
using GerenciamentoZoo.Contrato.Cuidados.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoZoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {

        private readonly IAnimaisUseCase _animaisUseCase;

        public AnimaisController(IAnimaisUseCase animaisUseCase)
        {
            _animaisUseCase = animaisUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animais = await _animaisUseCase.ListarTodosAnimais();
            return Ok(animais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _animaisUseCase.BuscarAnimalPorId(id);
          
            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimaisCreateDto createDto)
        {
            var animalCriado = await _animaisUseCase.AdicionarAnimal(createDto);
            return CreatedAtAction(
                nameof(GetById), 
                new { id = animalCriado.Id },
                animalCriado
            );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AnimaisDto updateDto)
        {
            var animal = await _animaisUseCase.AlterarAnimal(id,updateDto);
           
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animaisUseCase.RemoverAnimal(id);

            return Ok(animal);
        }


        [HttpPost("{animalId}/Cuidado/{cuidadoId}")]
        public async Task<IActionResult> AddCuidado(int animalId, int cuidadoId)
        {
            var animal = await _animaisUseCase.AdicionarCuidadoAnimal(animalId, cuidadoId);
           
            return Ok(animal);
        }

        [HttpDelete("{animalId}/Cuidado/{cuidadoId}")]
        public async Task<IActionResult> RemoveCuidadoFromAnimal(int animalId, int cuidadoId)
        {
            var result = await _animaisUseCase.RemoverCuidadoAnimal(animalId, cuidadoId);

            return Ok(result); 
        }
    }
}
