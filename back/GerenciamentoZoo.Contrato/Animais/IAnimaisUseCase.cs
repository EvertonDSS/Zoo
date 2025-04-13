using GerenciamentoZoo.Contrato.Animais.DTO;
using GerenciamentoZoo.Contrato.Cuidados.DTO;

namespace GerenciamentoZoo.Contrato.Animais
{
    public interface IAnimaisUseCase
    {
        public Task<List<AnimaisDto>> ListarTodosAnimais();
        public Task<AnimaisDto> BuscarAnimalPorId(int id);
        public Task<AnimaisDto> AdicionarAnimal(AnimaisCreateDto dto);
        public Task<AnimaisDto> AlterarAnimal(int id, AnimaisDto dto);
        public Task<AnimaisDto> RemoverAnimal(int id);
        public Task<AnimaisDto> AdicionarCuidadoAnimal(int animalId, int cuidadoId);
        public Task<AnimaisDto> RemoverCuidadoAnimal(int animalId, int cuidadoId);
    }
}
