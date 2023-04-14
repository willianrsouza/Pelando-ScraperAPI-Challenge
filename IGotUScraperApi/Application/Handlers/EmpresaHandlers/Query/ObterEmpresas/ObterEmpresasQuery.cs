using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using MediatR;

namespace IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa
{
    public record ObterEmpresasQuery() : IRequest<IEnumerable<EmpresaDto>>;
}
