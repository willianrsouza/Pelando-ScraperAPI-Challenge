
using IGotUScraper.Domain.Entities.EmpresaContext;

namespace IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa
{
    public interface IEmpresaRepository
    {
        Task<EmpresaEntity> ObterEmpresa(int id);
    }
}
