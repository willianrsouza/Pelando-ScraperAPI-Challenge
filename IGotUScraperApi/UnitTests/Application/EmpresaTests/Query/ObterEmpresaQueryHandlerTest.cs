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

            _empresaRepository.Setup(x => x.ObterEmpresa(1)).ReturnsAsync(empresaEntity);

            var obterHandler = ObterHandler();

            var result = await obterHandler.Handle(new ObterEmpresaQuery(1), new CancellationToken());

            Assert.True(result != null);
            _empresaRepository.Verify(x => x.ObterEmpresa(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "InputInvalido")]
        public async Task ObterEmpresaError()
        {
            var obterHandler = ObterHandler();

            var empresaEntity = new EmpresaEntity(1, "Nome", "UrlBase");

            var result = await obterHandler.Handle(new ObterEmpresaQuery(0), new CancellationToken());

            Assert.True(result == null);
            _empresaRepository.Verify(x => x.ObterEmpresa(It.IsAny<int>()), Times.Never);
        }
    }
}
