namespace IGotUScraper.Domain.Entities.EmpresaContext
{
    public class EmpresaEntity
    {
        public int Id { get; protected set; }
        public string? Nome { get; protected set; }
        public string? UrlBase { get; protected set; }

        public EmpresaEntity(int id, string nome, string urlBase)
        {
            Id = id;
            Nome = nome;
            UrlBase = urlBase;
        }
    }
}
