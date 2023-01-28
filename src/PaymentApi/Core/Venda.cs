using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Requests;
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
        public Venda()
        {
            
        }
        public Venda(VendaRequest venda, long id)
        {
            Id = id;
            Responsavel = venda.Responsavel;
            Produtos = venda.Produtos;
            DataVenda = DateTime.Now;
            Status = StatusVenda.AguardandoPagamento;
        }
    }
}