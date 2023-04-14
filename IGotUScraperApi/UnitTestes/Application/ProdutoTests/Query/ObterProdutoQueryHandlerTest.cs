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
    public class ObterProdutoQueryHandlerTest
    {
        private Mock<IProdutoRepository> _produtoRepository;
        private Mock<ILogger<ObterProdutoHandler>> _mockLogger;

        public ObterProdutoHandler ObterHandler() 
        {
            _produtoRepository = new Mock<IProdutoRepository>();
            _mockLogger = new Mock<ILogger<ObterProdutoHandler>>();

            return new ObterProdutoHandler(_produtoRepository.Object, _mockLogger.Object, new MapperFixture().Mapper);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterProdutoSucesso()
        {
            var produto = new ProdutoEntity(1, "Titulo", "Imagem","R$5,90","Descricao","Ulr", DateTime.Now);

            var obterHandler = ObterHandler();

            _produtoRepository.Setup(x => x.ObterPorId(1)).ReturnsAsync(produto);

            var result = await obterHandler.Handle(new ObterProdutoQuery(1), new CancellationToken());

            Assert.True(result != null);
            _produtoRepository.Verify(x => x.ObterPorId(It.IsAny<int>()), Times.Once);
        }


    }
}
