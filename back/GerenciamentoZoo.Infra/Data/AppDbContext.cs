using GerenciamentoZoo.Domain.Entidade;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoZoo.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnimaisEntity> Animais { get; set; }
        public DbSet<CuidadosEntity> Cuidados { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
