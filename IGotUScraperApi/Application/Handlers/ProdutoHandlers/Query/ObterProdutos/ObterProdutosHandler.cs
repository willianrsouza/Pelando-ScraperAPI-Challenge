using AutoMapper;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto
{
    public class ObterProdutosHandler : IRequestHandler<ObterProdutosQuery, IEnumerable<ProdutoDto>>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ObterProdutosHandler> _logger;
        private readonly IMapper _mapper;

        public ObterProdutosHandler(IProdutoRepository produtoRepository, ILogger<ObterProdutosHandler> logger, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDto>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler ObterProdutos.");

            var result = await _produtoRepository.ObterProdutos();

            _logger.LogInformation("Finalizando Handler ObterProdutos.");

            return await Task.FromResult(_mapper.Map<IEnumerable<ProdutoDto>>(result));
        }
    }
}
