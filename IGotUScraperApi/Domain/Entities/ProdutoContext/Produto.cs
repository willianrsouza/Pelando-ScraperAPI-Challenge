namespace IGotUScraper.Domain.Entities.ProdutoContext
{
    public class Produto
    {
        public int Id { get; protected set; }
        public string? Titulo { get; protected set; }
        public string? Imagem { get; set; }
        public double Preco { get; protected set; }
        public string? Descricao { get; protected set; }
        public string? UrlComplementar { get; protected set; }
        public DateTime DataExtracao { get; protected set; }


        public Produto(int id, string titulo, string? imagem, double preco, string descricao, string urlComplementar, DateTime dataExtracao)
        {
            Id = id;
            Titulo = titulo;
            Imagem = imagem;
            Preco = preco;
            Descricao = descricao;
            UrlComplementar = urlComplementar;
            DataExtracao = dataExtracao;
        }
    }
}
