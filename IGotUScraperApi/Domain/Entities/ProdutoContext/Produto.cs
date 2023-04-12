using IGotUScraper.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGotUScraper.Domain.Entities.ProdutoContext
{
    public class Produto : Entity
    {
        public int Id { get; protected set; }
        public string Titulo { get; protected set; }
        public double Preco { get; protected set; }
        public string Descricao { get; protected set; }
        public string Url { get; protected set; }


        public Produto(string titulo, double preco, string descricao, string url)
        {
            Titulo = titulo;
            Preco = preco;
            Descricao = descricao;
            Url = url;
        }

        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
