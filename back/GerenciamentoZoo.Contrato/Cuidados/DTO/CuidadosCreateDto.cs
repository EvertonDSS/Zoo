using GerenciamentoZoo.Contrato.Enums;

namespace GerenciamentoZoo.Contrato.Cuidados.DTO
{
    public class CuidadosCreateDto
    {
        public string NomeCuidado { get; set; }
        public string Descricao { get; set; }
        public int Frequencia { get; set; }
        public FrequenciaEnum UnidadeFrequencia { get; set; }
    }
}
