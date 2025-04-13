namespace GerenciamentoZoo.Contrato.Animais.DTO
{
    public class AnimaisCreateDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Especie { get; set; }
        public string Habitat { get; set; }
        public string PaisOrigem { get; set; }
    }
}
