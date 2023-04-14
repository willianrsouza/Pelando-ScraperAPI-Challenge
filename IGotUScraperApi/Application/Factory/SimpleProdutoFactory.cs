namespace IGotUScraper.Application.Factory
{
    public class SimpleProdutoFactory : ISimpleProdutoFactory
    {
        public ProdutoFactory ObterFactory(int idEmpresa)
        {
            ProdutoFactory? produto;

            switch (idEmpresa)
            {
                case 1:
                    produto = new ProdutoSaraivaFactory();
                    break;

                case 2:
                    produto = new ProdutoAmaroFactory();
                    break;

                default:
                    produto = null;
                    break;
            }

            return produto;
        }
    }
}
