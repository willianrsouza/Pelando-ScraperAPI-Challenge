using IGotUScraper.Application.Handlers.ProdutoHandlers.Command;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
using IGotUScraperApi.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IGotUScraper.Api.UnitTests.Controller
{

    [Collection("Controller")]
    public class ProdutoControllerTest
    {
        private Mock<IMediator> _mockMediator;
        private readonly ProdutoController _controller;

        public ProdutoControllerTest()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new ProdutoController(_mockMediator.Object);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterProduto()
        {
            var produto = new ProdutoDto("Titulo", "Imagem", "R$50,30", "Descricao", "URL");
            var query = new ObterProdutoQuery(1);

            _mockMediator.Setup(x => x.Send(query, It.IsAny<CancellationToken>()))
               .Returns(Task<ProdutoDto>.FromResult(produto));

            var result = await _controller.ObterProduto(query) as OkObjectResult;

            Assert.True(result != null);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterProdutos()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<ObterProdutosQuery>(), It.IsAny<CancellationToken>()))
               .Returns(Task<IEnumerable<ProdutoDto>>.FromResult(It.IsAny<IEnumerable<ProdutoDto>>()));

            var result = await _controller.ObterProdutos() as OkObjectResult;

            Assert.True(result != null);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ConsultarDadosProduto()
        {
            var produto = new ProdutoDto("Titulo", "Imagem", "R$50,30", "Descricao", "URL");
            var url = "www.url.com";

            _mockMediator.Setup(x => x.Send(It.IsAny<ConsultarDadosProdutoCommand>(), It.IsAny<CancellationToken>()))
               .Returns(Task<ProdutoDto>.FromResult(produto));

            var result = await _controller.ConsultarProduto(new ConsultarDadosProdutoCommand(url)) as OkObjectResult;

            Assert.True(result != null);
        }

        [Fact(DisplayName = "Error")]
        public async Task ObterProdutoError()
        {
            var query = new ObterProdutoQuery(0);

            var result = await _controller.ObterProduto(query) as BadRequestResult;

            Assert.True(result == null);
        }

        [Fact(DisplayName = "Error")]
        public async Task ConsultarDadosProdutoError()
        {
            var result = await _controller.ConsultarProduto(new ConsultarDadosProdutoCommand("")) as BadRequestResult;

            Assert.True(result == null);
        }

    }
}
