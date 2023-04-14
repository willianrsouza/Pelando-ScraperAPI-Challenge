using AutoMapper;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query
{
    public class ObterProdutoHandler : IRequestHandler<ObterProdutoQuery, ProdutoDto>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ObterProdutoHandler> _logger;
        private readonly IMapper _mapper;

        public ObterProdutoHandler(IProdutoRepository produtoRepository, ILogger<ObterProdutoHandler> logger, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler ObterProduto.");

            var produto = await _produtoRepository.ObterPorId(request.Id);

            var result = _mapper.Map<ProdutoDto>(produto);

            _logger.LogInformation("Finalizando Handler ObterProduto.");

            return await Task.FromResult<ProdutoDto>(result);
        }
    }
}
