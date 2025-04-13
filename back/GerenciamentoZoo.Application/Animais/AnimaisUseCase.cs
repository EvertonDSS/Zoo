using GerenciamentoZoo.Contrato.Animais;
using GerenciamentoZoo.Contrato.Animais.DTO;
using GerenciamentoZoo.Contrato.Cuidados;
using GerenciamentoZoo.Contrato.Cuidados.DTO;
using GerenciamentoZoo.Domain.Entidade;
using GerenciamentoZoo.Domain.ExceptionConfig;
using Mapster;

namespace GerenciamentoZoo.Application.Animais
{
    public class AnimaisUseCase : IAnimaisUseCase
    {
        private readonly IAnimaisRepository _animaisRepository;
        private readonly ICuidadosRepository _cuidadosRepository;

        public AnimaisUseCase(IAnimaisRepository animaisRepository, ICuidadosRepository cuidadosRepository)
        {
            _animaisRepository = animaisRepository;
            _cuidadosRepository = cuidadosRepository;
        }

        public async Task<AnimaisDto> AdicionarAnimal(AnimaisCreateDto dto)
        {
            var entity = AnimaisEntity.Criar(dto.Nome, dto.Descricao, dto.DataNascimento, dto.Especie, dto.Habitat, dto.PaisOrigem);
            var response = await _animaisRepository.AddAsync(entity);
            return response.Adapt<AnimaisDto>();
        }


        public async Task<AnimaisDto> AlterarAnimal(int id,AnimaisDto dto)
        {
            var animais = await _animaisRepository.GetByIdAsync(id);
            if (animais is null)
                throw new DomainException($"Nenhum animal encontrado com o id {id}", 404);
            
            animais.Atualizar(dto.Nome, dto.Descricao, dto.DataNascimento, dto.Especie, dto.Habitat, dto.PaisOrigem);

            var response = await _animaisRepository.UpdateAsync(id, animais);
            return response.Adapt<AnimaisDto>();
        }

        public async Task<AnimaisDto> BuscarAnimalPorId(int id)
        {
            var entity = await _animaisRepository.GetByIdAsync(id);
            if(entity is null)
                throw new DomainException($"Nenhum animal encontrato com o id {id}", 404);


            return entity.Adapt<AnimaisDto>();
        }

        public async Task<List<AnimaisDto>> ListarTodosAnimais()
        {
            var animais = await _animaisRepository.GetAllAsync();

            if (animais is null || !animais.Any())
                throw new DomainException("Nenhum animal encontrado", 204);

            return animais.Adapt<List<AnimaisDto>>();
        }

        public async Task<AnimaisDto> RemoverAnimal(int id)
        {
            
            var response = await _animaisRepository.DeleteAnimal(id);
            return response.Adapt<AnimaisDto>();
        }

        public async Task<AnimaisDto> AdicionarCuidadoAnimal(int animalId, int cuidadoId)
        {
            var animal = await _animaisRepository.GetByIdAsync(animalId);
            if (animal is null)
                throw new DomainException("Animal não encontrado para adicionar cuidado", 400);

            var cuidado = await _cuidadosRepository.GetByIdAsync(cuidadoId);
            if (cuidado is null)
                throw new DomainException("Cuidado não existe para ser adicionado ao animal", 400);

            animal.AdicionarCuidados(cuidado);
            var response = await _animaisRepository.AddCuidados(animal);
            return response.Adapt<AnimaisDto>();
        }
        public async Task<AnimaisDto> RemoverCuidadoAnimal(int animalId, int cuidadoId)
        {
            var response = await _animaisRepository.RemoverCuidadoAnimal(animalId, cuidadoId);

            if (response is null)
                throw new DomainException($"Não foi encontrado animal com id {animalId}", 404);
            return response.Adapt<AnimaisDto>();
        }

       
    }
}
