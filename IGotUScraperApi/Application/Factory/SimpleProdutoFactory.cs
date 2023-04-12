using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGotUScraper.Application.Factory
{
    public class SimpleProdutoFactory
    {
        public static ProdutoFactory ObterFactory(string empresa) 
        {
            ProdutoFactory? produto;

            switch (empresa) 
            {
                case "amaro":
                    produto = new ProdutoAmaroFactory();
                break;

                case "saraiva":
                    produto = new ProdutoSaraivaFactory();
                    break;

                default:
                    produto = new ProdutoSaraivaFactory();
                    break;
            }

             return produto;
        } 
    }
}
