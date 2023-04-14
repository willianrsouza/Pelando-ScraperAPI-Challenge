using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa
{
    public record ObterEmpresaQuery([property: SwaggerSchema("Id Empresa")] int Id) : IRequest<EmpresaDto>;
}
