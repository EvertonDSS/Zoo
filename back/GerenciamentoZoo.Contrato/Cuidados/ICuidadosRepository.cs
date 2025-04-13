using GerenciamentoZoo.Domain.Entidade;

namespace GerenciamentoZoo.Contrato.Cuidados
{
    public interface ICuidadosRepository
    {
        public Task<CuidadosEntity> AddAsync(CuidadosEntity campeonato);

        public Task<List<CuidadosEntity>> GetAllAsync();
        public Task<CuidadosEntity> UpdateAsync(int id,CuidadosEntity campeonato);

        public Task<CuidadosEntity> GetByIdAsync(int id);
        public Task<CuidadosEntity> RemoverCuidadoCuidado(int id);
    }
}
