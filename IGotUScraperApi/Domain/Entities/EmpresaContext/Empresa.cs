namespace IGotUScraper.Domain.Entities.EmpresaContext
{
    public class Empresa
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public int UrlBase { get; protected set; }

        public Empresa(int id, string nome, int urlBase)
        {
            Id = id;
            Nome = nome;
            UrlBase = urlBase;
        }
    }
}
