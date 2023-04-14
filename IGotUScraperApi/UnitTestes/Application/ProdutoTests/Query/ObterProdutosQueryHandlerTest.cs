using IGotUScraper.Api.UnitTests.Mapper;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace IGotUScraper.Api.UnitTests.Application.ProdutoTests.Query
{
    [Collection("Application")]
    public class ObterProdutosQueryHandlerTest
    {
        private Mock<IProdutoRepository> _produtoRepository;
        private Mock<ILogger<ObterProdutosHandler>> _mockLogger;

        public ObterProdutosHandler ObterHandler() 
        {
            _produtoRepository = new Mock<IProdutoRepository>();
            _mockLogger = new Mock<ILogger<ObterProdutosHandler>>();

            return new ObterProdutosHandler(_produtoRepository.Object, _mockLogger.Object, new MapperFixture().Mapper);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterProdutosSucesso()
        {
            var produtoX = new ProdutoEntity(1, "Titulo", "Imagem", "R$5,90", "Descricao", "Ulr", DateTime.Now);
            var produtoY = new ProdutoEntity(1, "Titulo", "Imagem", "R$5,90", "Descricao", "Ulr", DateTime.Now);

            var produtos = new List<ProdutoEntity>
            {
                produtoX,
                produtoY
            };

            var obterHandler = ObterHandler();

            _produtoRepository.Setup(x => x.ObterProdutos()).ReturnsAsync(produtos);

            var result = await obterHandler.Handle(new ObterProdutosQuery(), new CancellationToken());

            Assert.True(result.Count() > 1);
            _produtoRepository.Verify(x => x.ObterProdutos(), Times.Once);
        }
    }
}
