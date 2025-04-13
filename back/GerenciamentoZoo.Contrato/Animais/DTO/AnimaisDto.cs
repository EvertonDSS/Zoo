using GerenciamentoZoo.Contrato.Cuidados.DTO;

namespace GerenciamentoZoo.Contrato.Animais.DTO
{
    public class AnimaisDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Especie { get; set; }
        public string Habitat { get; set; }
        public string PaisOrigem { get; set; }
        public List<CuidadosDto>? Cuidados { get; set; }
    }
}
