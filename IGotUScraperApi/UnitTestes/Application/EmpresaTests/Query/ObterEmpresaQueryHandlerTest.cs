using IGotUScraper.Api.UnitTests.Mapper;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace IGotUScraper.Api.UnitTests.Application.EmpresaTests.Query
{
    [Collection("Application")]
    public class ObterEmpresaQueryHandlerTest
    {
        private Mock<IEmpresaRepository> _empresaRepository;
        private Mock<ILogger<ObterEmpresaHandler>> _mockLogger;

        public ObterEmpresaHandler  ObterHandler() 
        {
            _empresaRepository = new Mock<IEmpresaRepository>();
            _mockLogger = new Mock<ILogger<ObterEmpresaHandler>>();

            return new ObterEmpresaHandler(_empresaRepository.Object, _mockLogger.Object, new MapperFixture().Mapper);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterEmpresaSucesso()
        {
            var empresaEntity = new EmpresaEntity(1, "Nome", "UrlBase");

            var obterHandler = ObterHandler();

            _empresaRepository.Setup(x => x.ObterEmpresa(1)).ReturnsAsync(empresaEntity);

            var result = await obterHandler.Handle(new ObterEmpresaQuery(1), new CancellationToken());

            Assert.True(result != null);
            _empresaRepository.Verify(x => x.ObterEmpresa(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Nulo")]
        public async Task ObterEmpresaNaoEncontrada()
       {
            var obterHandler = ObterHandler();

            var result = await obterHandler.Handle(new ObterEmpresaQuery(5), new CancellationToken());

            _empresaRepository.Setup(x => x.ObterEmpresa(5)).ReturnsAsync(It.IsAny<EmpresaEntity>());

            Assert.Null(result);

            _empresaRepository.Verify(x => x.ObterEmpresa(It.IsAny<int>()), Times.Once);
        }
    }
}
