using AutoMapper;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresas
{
    public class ObterEmpresasHandler : IRequestHandler<ObterEmpresasQuery, IEnumerable<EmpresaDto>>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ILogger<ObterEmpresasHandler> _logger;
        private readonly IMapper _mapper;

        public ObterEmpresasHandler(IEmpresaRepository empresaRepository, ILogger<ObterEmpresasHandler> logger, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpresaDto>> Handle(ObterEmpresasQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler ObterProduto.");

            var result = await _empresaRepository.ObterEmpresas();

            _logger.LogInformation("Finalizando Handler ObterProduto.");

            return await Task.FromResult(_mapper.Map<IEnumerable<EmpresaDto>>(result));
        }
    }
}
