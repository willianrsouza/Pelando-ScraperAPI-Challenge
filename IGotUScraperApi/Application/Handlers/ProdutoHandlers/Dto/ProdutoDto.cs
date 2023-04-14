namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Dto
{
    public record ProdutoDto
    {
        public string? Titulo { get; set; }
        public string? Imagem { get; set; }
        public string? Preco { get; set; }
        public string? Descricao { get; set; }
        public string? Url { get; set; }

        public ProdutoDto() { }

        public ProdutoDto(string? titulo, string? imagem, string? preco, string? descricao, string? url)
        {
            Titulo = titulo;
            Imagem = imagem;
            Preco = preco;
            Descricao = descricao;
            Url = url;
        }

    }
}
