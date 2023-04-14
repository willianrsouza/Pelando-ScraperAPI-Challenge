using IGotUScraper.Api.UnitTests.Mapper;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresas;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace IGotUScraper.Api.UnitTests.Application.EmpresaTests.Query
{
    [Collection("Application")]
    public class ObterEmpresasQueryHandlerTest
    {
        private Mock<IEmpresaRepository> _empresaRepository;
        private Mock<ILogger<ObterEmpresasHandler>> _mockLogger;

        public ObterEmpresasHandler  ObterHandler() 
        {
            _empresaRepository = new Mock<IEmpresaRepository>();
            _mockLogger = new Mock<ILogger<ObterEmpresasHandler>>();

            return new ObterEmpresasHandler(_empresaRepository.Object, _mockLogger.Object, new MapperFixture().Mapper);
        }

        [Fact(DisplayName = "Sucesso")]
        public async Task ObterEmpresaSucesso()
        {
            var empresaX = new EmpresaEntity(1, "Nome", "UrlBase");
            var empresaY = new EmpresaEntity(1, "Nome", "UrlBase");

            var empresaEntity = new List<EmpresaEntity>
            {
                empresaX,
                empresaY
            };

            var obterHandler = ObterHandler();

            _empresaRepository.Setup(x => x.ObterEmpresas()).ReturnsAsync(empresaEntity);

            var result = await obterHandler.Handle(new ObterEmpresasQuery(), new CancellationToken());

            Assert.True(result != null);
            _empresaRepository.Verify(x => x.ObterEmpresas(), Times.Once);
        }
    }
}
