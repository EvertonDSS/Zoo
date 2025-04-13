using GerenciamentoZoo.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
