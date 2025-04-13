using GerenciamentoZoo.Domain.Entidade;

namespace GerenciamentoZoo.Contrato.Animais
{
    public interface IAnimaisRepository
    {
        public Task<AnimaisEntity> AddAsync(AnimaisEntity animal);
        public Task<List<AnimaisEntity>> GetAllAsync();
        public Task<AnimaisEntity> GetByIdAsync(int id);
        public Task<AnimaisEntity> UpdateAsync(int id,AnimaisEntity cuidado);
        public Task<AnimaisEntity> AddCuidados(AnimaisEntity cuidado);
        public Task<AnimaisEntity> DeleteAnimal(int animalId);
        public Task<AnimaisEntity> RemoverCuidadoAnimal(int animalId, int cuidadoId);
    }
}
