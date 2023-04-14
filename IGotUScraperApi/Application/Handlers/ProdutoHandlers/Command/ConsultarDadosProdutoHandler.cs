using AutoMapper;
using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Command
{
    public class ConsultarDadosProdutoHandler : IRequestHandler<ConsultarDadosProdutoCommand, ProdutoDto>
    {
        private readonly ILogger<ConsultarDadosProdutoHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ISimpleProdutoFactory _simpleProdutoFactory;

        public ConsultarDadosProdutoHandler(ILogger<ConsultarDadosProdutoHandler> logger, IMapper mapper, IProdutoRepository produtoRepository, ISimpleProdutoFactory simpleProdutoFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _simpleProdutoFactory = simpleProdutoFactory;
        }

        public async Task<ProdutoDto> Handle(ConsultarDadosProdutoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

            var obterProduto = await _produtoRepository.ObterProdutoPorUrl(request.Url);

            if (obterProduto != null)
                return await Task.FromResult(_mapper.Map<ProdutoDto>(obterProduto));

            var factory = _simpleProdutoFactory.ObterFactory(request.Url);
            var produtoFactory = factory.MontarProduto(request.Url);

           if (produtoFactory != null)
              await _produtoRepository.Inserir(_mapper.Map<ProdutoEntity>(produtoFactory), 2);

            _logger.LogInformation("Finalizando Handler.");

            return await Task.FromResult(produtoFactory);
        }
    }
}
