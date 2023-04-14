using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
using IGotUScraperApi.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IGotUScraper.Api.UnitTests.Controller
{

    [Collection("Controller")]
    public class EmpresaControllerTest
    {
        private Mock<IMediator> _mockMediator;
        private readonly EmpresaController _controller;

        public EmpresaControllerTest()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new EmpresaController(_mockMediator.Object);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterEmpresa()
        {
            var produto = new EmpresaDto(1, "Nome", "www.urlbase.com");
            var query = new ObterEmpresaQuery(1);

            _mockMediator.Setup(x => x.Send(query, It.IsAny<CancellationToken>()))
               .Returns(Task<EmpresaDto>.FromResult(produto));

            var result = await _controller.ObterEmpresa(query) as OkObjectResult;

            Assert.True(result != null);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterEmpresas()
        {
            _mockMediator.Setup(x => x.Send(new ObterEmpresasQuery(), It.IsAny<CancellationToken>()))
               .Returns(Task<IEnumerable<EmpresaDto>>.FromResult(It.IsAny<IEnumerable<EmpresaDto>>()));

            var result = await _controller.ObterEmpresas() as OkObjectResult;

            Assert.True(result != null);
        }

        [Fact(DisplayName = "Error")]
        public async Task ObterEmpresaError()
        {
            var produto = new EmpresaDto(1, "Nome", "www.urlbase.com");
            var query = new ObterEmpresaQuery(1);

            _mockMediator.Setup(x => x.Send(query, It.IsAny<CancellationToken>()))
               .Returns(Task<EmpresaDto>.FromResult(produto));

            var result = await _controller.ObterEmpresa(query) as BadRequestResult;

            Assert.True(result == null);
        }
    }
}
