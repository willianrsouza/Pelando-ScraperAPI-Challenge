using IGotUScraper.Api.UnitTests.Mapper;
using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Command;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IGotUScraper.Api.UnitTests.Application.ProdutoTests.Command
{
    public class ConsultarDadosProdutoCommandHandlerTests
    {
        private Mock<IProdutoRepository> _produtoRepository;
        private Mock<ISimpleProdutoFactory> _simpleProdutoFactory;
        private Mock<ILogger<ConsultarDadosProdutoHandler>> _mockLogger;
        private Mock<ProdutoAmaroFactory> _mockFactory;

        public ConsultarDadosProdutoHandler ObterHandler()
        {
            _mockLogger = new Mock<ILogger<ConsultarDadosProdutoHandler>>();
            _produtoRepository = new Mock<IProdutoRepository>();
            _simpleProdutoFactory = new Mock<ISimpleProdutoFactory>();
            _mockFactory = new Mock<ProdutoAmaroFactory>();

            return new ConsultarDadosProdutoHandler(_mockLogger.Object, new MapperFixture().Mapper, _produtoRepository.Object, _simpleProdutoFactory.Object);
        }

        [Fact(DisplayName = "Database Desatualizado")]
        public async Task ConsultarDadosProdutoDbDesatualizado()
         {
            var produto = new ProdutoEntity(1, "Titulo", "Imagem", "R$5,90", "Descricao", "Url", DateTime.Now);
            var produtoDto = new ProdutoDto("Titulo", "Imagem", "R$5,90", "Descricao", "Url");
            var url = "https://www.saraiva.com.br/mais-quente-que-fogo-sucesso-do-tik-tok--20122067/p";
            
            var obterHandler = ObterHandler();

            var produtoFactory = new ProdutoSaraivaFactory();

            _simpleProdutoFactory.Setup(x => x.ObterFactory(It.IsAny<String>())).Returns(produtoFactory);

            var mock = new Mock<ProdutoSaraivaFactory>();
            mock.Setup(abs => abs.ObterDados(It.IsAny<string>())).Returns(produtoDto);

            _produtoRepository.Setup(x => x.Inserir(It.IsAny<ProdutoEntity>(), 1)).Returns(Task.CompletedTask);

            var result = await obterHandler.Handle(new ConsultarDadosProdutoCommand(url), new CancellationToken());

            Assert.True(result != null);

            _produtoRepository.Verify(x => x.Inserir(It.IsAny<ProdutoEntity>(), It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Database Atualizado")]
        public async Task ConsultarDadosProdutoDbAtualizado()
        {
            var produto = new ProdutoEntity(1, "Titulo", "Imagem", "R$5,90", "Descricao", "Url", DateTime.Now);

            var obterHandler = ObterHandler();

            _produtoRepository.Setup(x => x.ObterProdutoPorUrl("www.url.com.br")).ReturnsAsync(produto);

            var result = await obterHandler.Handle(new ConsultarDadosProdutoCommand("www.url.com.br"), new CancellationToken());

            Assert.True(result != null);

            _produtoRepository.Verify(x => x.ObterProdutoPorUrl(It.IsAny<string>()), Times.Once);
        }
    }
}
