using GerenciamentoZoo.Contrato.Cuidados;
using GerenciamentoZoo.Contrato.Cuidados.DTO;
using GerenciamentoZoo.Domain.Entidade;
using GerenciamentoZoo.Domain.ExceptionConfig;
using Mapster;

namespace GerenciamentoZoo.Application.Cuidados
{
    public class CuidadosUseCase : ICuidadosUseCase
    {
        private readonly ICuidadosRepository _cuidadosRepository;

        public CuidadosUseCase(ICuidadosRepository cuidadosRepository)
        {
            _cuidadosRepository = cuidadosRepository;
        }
        public async Task<CuidadosDto> AdicionarCuidado(CuidadosCreateDto dto)
        {
            var entity = CuidadosEntity.CriarCuidado(dto.NomeCuidado, dto.Descricao, dto.Frequencia, (int)dto.UnidadeFrequencia);

            var response = await _cuidadosRepository.AddAsync(entity);
            return response.Adapt<CuidadosDto>();
        }

        public async Task<CuidadosDto> AlterarCuidado(int id,CuidadosDto dto)
        {
            var entity = dto.Adapt<CuidadosEntity>();
            var response = await _cuidadosRepository.UpdateAsync(id,entity);
            return response.Adapt<CuidadosDto>();
        }

        public async Task<CuidadosDto> BuscarCuidadoPorId(int id)
        {
            var entity = await _cuidadosRepository.GetByIdAsync(id);
            if (entity is null)
                throw new DomainException($"Não foi encontrado cuidado com id {id}", 404);

            return entity.Adapt<CuidadosDto>();

        }

        public async Task<List<CuidadosDto>> ListarTodosCuidados()
        {
            var cuidados = await _cuidadosRepository.GetAllAsync();
            if (cuidados is null || !cuidados.Any())
                throw new DomainException("Não foi encontrado nenhum cuidado cadastrado", 204);
            return cuidados.Adapt<List<CuidadosDto>>();
        }

        public async Task<CuidadosDto> RemoverCuidadoCuidado(int id)
        {
            var response = await _cuidadosRepository.RemoverCuidadoCuidado(id);
            if (response is null)
                throw new DomainException($"Não foi encontrado cuidado com id {id}", 404);
            return response.Adapt<CuidadosDto>();
        }
    }
}
