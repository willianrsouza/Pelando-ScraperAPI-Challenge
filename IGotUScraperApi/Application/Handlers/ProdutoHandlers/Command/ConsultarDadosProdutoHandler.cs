using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Factory.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.ProdutoRepository;
using IGotUScraper.Utilities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Command
{
    public class ConsultarDadosProdutoHandler : IRequestHandler<ConsultarDadosProdutoCommand, ProdutoDto>
    {
        private readonly ILogger<ConsultarDadosProdutoHandler> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public ConsultarDadosProdutoHandler(ILogger<ConsultarDadosProdutoHandler> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> Handle(ConsultarDadosProdutoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

            ProdutoFactory factory = SimpleProdutoFactory.ObterFactory("saraiva");
            var produto = factory.MontarProduto(request.Url);

            var result = MapearProduto(produto);

            _logger.LogInformation("Finalizando Handler.");

            return await Task.FromResult(result);
        }

        private ProdutoDto MapearProduto(FactoryDto factoryDto)
        {
            return new ProdutoDto(factoryDto.Titulo, "", 50, factoryDto.Descricao, factoryDto.UrlBase); ;
        }
    }
}
