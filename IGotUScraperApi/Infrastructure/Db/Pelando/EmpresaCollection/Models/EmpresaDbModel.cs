namespace IGotUScraper.Infrastructure.Db.Pelando.Empresa.Models
{
    internal record EmpresaDbModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? UrlBase { get; set; }
    }
}
