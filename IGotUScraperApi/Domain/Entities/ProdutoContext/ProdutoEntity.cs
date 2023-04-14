namespace IGotUScraper.Domain.Entities.ProdutoContext
{
    public class ProdutoEntity
    {
        public int? Id { get; protected set; }
        public string? Titulo { get; protected set; }
        public string? Imagem { get; set; }
        public string Preco { get; protected set; }
        public string? Descricao { get; protected set; }
        public string? Url { get; protected set; }
        public DateTime DataExtracao { get; protected set; }

        public ProdutoEntity(int? id, string? titulo, string? imagem, string preco, string? descricao, string? url, DateTime dataExtracao)
        {
            Id = id;
            Titulo = titulo;
            Imagem = imagem;
            Preco = preco;
            Descricao = descricao;
            Url = url;
            DataExtracao = dataExtracao;
        }
    }
}
