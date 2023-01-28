using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Utils;

namespace PaymentApi.Core
{
    public class Venda
    {
        public long Id { get; set; }
        public Vendedor Responsavel { get; set; }
        public DateTime DataVenda { get; set; }
        public List<Produto> Produtos { get; set; }
        public StatusVenda Status { get; set; }
        public Venda(Vendedor responsavel, List<Produto> produtos)
        {
            Responsavel = responsavel;
            Produtos = produtos;
            DataVenda = DateTime.Now;
            Status = StatusVenda.AguardandoPagamento;
        }
    }
}