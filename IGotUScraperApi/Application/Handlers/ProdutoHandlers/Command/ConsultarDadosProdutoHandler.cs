using AutoMapper;
using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using IGotUScraper.Utilities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Command
{
    public class ConsultarDadosProdutoHandler : IRequestHandler<ConsultarDadosProdutoCommand, ProdutoDto>
    {
        private readonly ILogger<ConsultarDadosProdutoHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ConsultarDadosProdutoHandler(ILogger<ConsultarDadosProdutoHandler> logger, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> Handle(ConsultarDadosProdutoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

            if (string.IsNullOrEmpty(request.Url))
                return await Task.FromException<ProdutoDto>(new Exception("A 'URL' é inválida."));

            var produtoCadastrado = await _produtoRepository.ObterProdutoPorUrl(request.Url);

            if (produtoCadastrado != null)
                return await Task.FromResult(_mapper.Map<ProdutoDto>(produtoCadastrado)); 

            var factory = SimpleProdutoFactory.ObterFactory(request.Url);
            var produtoFactory = factory.MontarProduto(request.Url);

            await _produtoRepository.Inserir(_mapper.Map<ProdutoEntity>(produtoFactory), 2);

            _logger.LogInformation("Finalizando Handler.");

            return await Task.FromResult(produtoFactory);
        }
    }
}
