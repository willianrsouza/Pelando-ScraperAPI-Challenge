using AutoMapper;
using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
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
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ISimpleProdutoFactory _simpleProdutoFactory;

        public ConsultarDadosProdutoHandler(ILogger<ConsultarDadosProdutoHandler> logger, IMapper mapper, IProdutoRepository produtoRepository,
            IEmpresaRepository empresaRepository, ISimpleProdutoFactory simpleProdutoFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _empresaRepository = empresaRepository;
            _simpleProdutoFactory = simpleProdutoFactory;
        }

        public async Task<ProdutoDto> Handle(ConsultarDadosProdutoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

            var obterProdutoDb = await _produtoRepository.ObterProdutoPorUrl(request.Url);

            if (obterProdutoDb != null)
                return await Task.FromResult(_mapper.Map<ProdutoDto>(obterProdutoDb));

            var nomeEmpresa = ExtrairDados.ObterNomeEmpresa(request.Url);

            var empresa = await _empresaRepository.ObterEmpresaPorNome(nomeEmpresa);

            if (empresa == null)
                throw new ApplicationException("Empresa solicita não cadastrada.");

            var factoryResult = Fabricar(request.Url, empresa.Id);

            if (factoryResult == null)
                throw new ApplicationException("Não foi possivel realizar o processo de extração.");

            await _produtoRepository.Inserir(_mapper.Map<ProdutoEntity>(factoryResult), empresa.Id);

            _logger.LogInformation("Finalizando Handler.");

            return await Task.FromResult(factoryResult);
        }

        private ProdutoDto? Fabricar(string url, int idEmpresa)
        {
            var factory = _simpleProdutoFactory.ObterFactory(idEmpresa);
            return factory.FabricarProduto(url);
        }
    }
}
