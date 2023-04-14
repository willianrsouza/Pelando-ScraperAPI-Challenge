namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Dto
{
    public record ProdutoDto
    {
        public string? Titulo { get; set; }
        public string? Imagem { get; set; }
        public string? Preco { get; set; }
        public string? Descricao { get; set; }
        public string? UrlBase { get; set; }

        public ProdutoDto() { }

        public ProdutoDto(string? titulo, string? imagem, string? preco, string? descricao, string? urlBase)
        {
            Titulo = titulo;
            Imagem = imagem;
            Preco = preco;
            Descricao = descricao;
            UrlBase = urlBase;
        }
    }
}
