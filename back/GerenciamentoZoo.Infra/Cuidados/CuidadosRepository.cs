using GerenciamentoZoo.Contrato.Cuidados;
using GerenciamentoZoo.Domain.Entidade;
using GerenciamentoZoo.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoZoo.Infra.Cuidados
{
    public class CuidadosRepository : ICuidadosRepository
    {
        private readonly AppDbContext _dbContext;

        public CuidadosRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CuidadosEntity> AddAsync(CuidadosEntity cuidados)
        {
            await _dbContext.Cuidados.AddAsync(cuidados);
            await _dbContext.SaveChangesAsync();
            return cuidados;
        }

        public async Task<List<CuidadosEntity>> GetAllAsync()
        {
            return await _dbContext.Cuidados.ToListAsync();
        }

        public async Task<CuidadosEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Cuidados.FindAsync(id);
        }

        public async Task<CuidadosEntity> RemoverCuidadoCuidado(int id)
        {
            var entity = await _dbContext.Cuidados.FindAsync(id);
            if (entity == null)
                return null;
            _dbContext.Cuidados.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<CuidadosEntity> UpdateAsync(int id,CuidadosEntity cuidado)
        {
            var entity = await _dbContext.Cuidados.FindAsync(id);

            if (entity == null)
                return null;

            entity.AtualizarCuidados(cuidado.NomeCuidado, cuidado.Descricao, cuidado.Frequencia, cuidado.UnidadeFrequencia);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
