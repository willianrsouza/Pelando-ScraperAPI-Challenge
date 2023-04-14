using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGotUScraper.Application.Factory
{
    public interface ISimpleProdutoFactory
    {
        public ProdutoFactory ObterFactory(string url);
    }
}
