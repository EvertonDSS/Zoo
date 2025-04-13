using GerenciamentoZoo.Domain.ExceptionConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoZoo.Domain.Entidade
{
    public class CuidadosEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeCuidado { get; set; }
        public string Descricao { get; set; }
        public int Frequencia { get; set; }
        public int UnidadeFrequencia { get; set; }
        public List<AnimaisEntity> Animais { get; set; }

        public CuidadosEntity() { } 
        public static CuidadosEntity CriarCuidado(string nomeCuidado, string descricao, int frequencia, int unidadeFrequencia)
        {
            if (string.IsNullOrWhiteSpace(nomeCuidado))
            throw new DomainException("Nome do cuidado é obrigatório", 400);

            if (frequencia is 0)
                throw new DomainException("Frequência do cuidado não pode ser 0", 400);

            if (unidadeFrequencia is 0)
                throw new DomainException("Unidade de frequência do cuidado não pode ser 0", 400);

            return new CuidadosEntity
            {
                NomeCuidado = nomeCuidado,
                Descricao = descricao,
                Frequencia = frequencia,
                UnidadeFrequencia = unidadeFrequencia,
            };
        }

        public void AtualizarCuidados(string nomeCuidado, string descricao, int frequencia, int unidadeFrequencia)
        {
            if (!string.IsNullOrWhiteSpace(nomeCuidado))
                NomeCuidado = nomeCuidado;

            if (!string.IsNullOrWhiteSpace(descricao))
                Descricao = descricao;

            if (frequencia is not 0)
                Frequencia = frequencia;

            if (unidadeFrequencia is not 0)
                UnidadeFrequencia = unidadeFrequencia;
        }




    }
}
