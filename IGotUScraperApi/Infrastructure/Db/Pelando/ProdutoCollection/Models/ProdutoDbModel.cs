namespace IGotUScraper.Infrastructure.Db.Pelando.ProdutoRepository.Models
{
    internal record ProdutoDbModel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string? Titulo { get; set; }
        public string? Imagem { get; set; }
        public string? Preco { get; set; }
        public string? Descricao { get; set; }
        public string? Url { get; set; }
        public DateTime DataExtracao { get; set; }
    }
}
