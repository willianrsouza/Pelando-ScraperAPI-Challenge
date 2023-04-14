using AutoMapper;
using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
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

        public ConsultarDadosProdutoHandler(ILogger<ConsultarDadosProdutoHandler> logger, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> Handle(ConsultarDadosProdutoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

            var factory = SimpleProdutoFactory.ObterFactory("saraiva");
            var produto = factory.MontarProduto(request.Url);

            await _produtoRepository.Inserir(_mapper.Map<ProdutoEntity>(produto), 2);

            _logger.LogInformation("Finalizando Handler.");

            return await Task.FromResult(produto);
        }
    }
}
