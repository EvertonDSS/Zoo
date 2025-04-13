using GerenciamentoZoo.Contrato.Animais;
using GerenciamentoZoo.Domain.Entidade;
using GerenciamentoZoo.Domain.ExceptionConfig;
using GerenciamentoZoo.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoZoo.Infra.Animais
{
    public class AnimaisRepository : IAnimaisRepository
    {
        private readonly AppDbContext _dbContext;

        public AnimaisRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AnimaisEntity> AddAsync(AnimaisEntity animais)
        {
            await _dbContext.Animais.AddAsync(animais);
            await _dbContext.SaveChangesAsync();
            return animais;
        }
        public async Task<AnimaisEntity> DeleteAnimal(int animalId)
        {
            var animal = await _dbContext.Animais.FindAsync(animalId);
            if (animal == null)
                throw new DomainException("Animal não encontrado para ser removido", 404);

            _dbContext.Animais.Remove(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<List<AnimaisEntity>> GetAllAsync()
        {
            return await _dbContext.Animais
                .Include(a => a.Cuidados)
                .ToListAsync();
        }

        public async Task<AnimaisEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Animais
                .Include(a => a.Cuidados)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AnimaisEntity> UpdateAsync(int id,AnimaisEntity animais)
        {
            await _dbContext.SaveChangesAsync();
            return animais;
        }

        public async Task<AnimaisEntity> AddCuidados(AnimaisEntity animais)
        {
            _dbContext.Animais.Update(animais);
            await _dbContext.SaveChangesAsync();
            return animais;
        }
        public async Task<AnimaisEntity> RemoverCuidadoAnimal(int animalId, int cuidadoId)
        {
            var animal = await _dbContext.Animais
                .Include(a => a.Cuidados)
                .FirstOrDefaultAsync(a => a.Id == animalId);
            if (animal == null)
                return null;
          
            animal.RemoverCuidados(cuidadoId);

            _dbContext.Animais.Update(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }
    }
}
