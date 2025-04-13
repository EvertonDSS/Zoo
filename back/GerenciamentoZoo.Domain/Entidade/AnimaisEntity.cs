using GerenciamentoZoo.Domain.ExceptionConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoZoo.Domain.Entidade
{
    public class AnimaisEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Especie { get; set; }
        public string Habitat { get; set; }
        public string PaisOrigem { get; set; }
        public List<CuidadosEntity>? Cuidados { get; set; }

        private AnimaisEntity() { }

        public static AnimaisEntity Criar(string nome, string descricao, DateOnly data, string especie, string habitat, string paisOrigem)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome é obrigatório", 401);

            return new AnimaisEntity
            {
                Nome = nome,
                Descricao = descricao,
                DataNascimento = data,
                Especie = especie,
                Habitat = habitat,
                PaisOrigem = paisOrigem,
            };
        }

        public AnimaisEntity AdicionarCuidados(CuidadosEntity cuidado)
        {

            if (Cuidados.Any(c => c.Id == cuidado.Id))
                throw new DomainException("Cuidado já associado ao animal", 400);

            if (cuidado is null)
                throw new DomainException("Cuidado não pode ser nulo", 400);

            Cuidados ??= new List<CuidadosEntity>();
            Cuidados.Add(cuidado);
            return this;
        }

        public void Atualizar(string nome, string descricao, DateOnly data, string especie, string habitat, string paisOrigem)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                Nome = nome;
            if (!string.IsNullOrWhiteSpace(descricao))
                Descricao = descricao;
            if (data != default)
                DataNascimento = data;
            if (!string.IsNullOrWhiteSpace(especie))
                Especie = especie;
            if (!string.IsNullOrWhiteSpace(habitat))
                Habitat = habitat;
            if (!string.IsNullOrWhiteSpace(paisOrigem))
                PaisOrigem = paisOrigem;
        }

        public void RemoverCuidados(int cuidadoId)
        {
            var cuidado = Cuidados.FirstOrDefault(c => c.Id == cuidadoId);
            if (cuidado is null)
                throw new DomainException("Animal não possui o cuidado a ser removido.", 404);
            Cuidados.Remove(cuidado);
        }
    }
}
