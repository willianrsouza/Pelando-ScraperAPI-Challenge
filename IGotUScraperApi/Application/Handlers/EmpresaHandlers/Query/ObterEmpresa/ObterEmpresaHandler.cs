using AutoMapper;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa
{
    public class ObterEmpresaHandler : IRequestHandler<ObterEmpresaQuery, EmpresaDto>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ILogger<ObterEmpresaHandler> _logger;
        private readonly IMapper _mapper;

        public ObterEmpresaHandler(IEmpresaRepository empresaRepository, ILogger<ObterEmpresaHandler> logger, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmpresaDto> Handle(ObterEmpresaQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler ObterProduto.");

            var result = await _empresaRepository.ObterEmpresa(request.Id);

            _logger.LogInformation("Finalizando Handler ObterProduto.");

            return await Task.FromResult(_mapper.Map<EmpresaDto>(result));
        }
    }
}
