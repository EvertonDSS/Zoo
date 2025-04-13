using GerenciamentoZoo.Contrato.Animais.DTO;
using GerenciamentoZoo.Contrato.Cuidados.DTO;

namespace GerenciamentoZoo.Contrato.Cuidados
{
    public interface ICuidadosUseCase
    {
        public Task<List<CuidadosDto>> ListarTodosCuidados();
        public Task<CuidadosDto> BuscarCuidadoPorId(int id);
        public Task<CuidadosDto> AdicionarCuidado(CuidadosCreateDto dto);
        public Task<CuidadosDto> AlterarCuidado(int id,CuidadosDto dto);
        public Task<CuidadosDto> RemoverCuidadoCuidado(int id);

    }
}
