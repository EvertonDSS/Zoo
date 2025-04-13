using GerenciamentoZoo.Contrato.Enums;

namespace GerenciamentoZoo.Contrato.Cuidados.DTO
{

    public class CuidadosDto
    {
        public int Id { get; set; }
        public string NomeCuidado { get; set; }
        public string Descricao { get; set; }
        public int Frequencia { get; set; }
        public FrequenciaEnum UnidadeFrequencia { get; set; }
    }
}
