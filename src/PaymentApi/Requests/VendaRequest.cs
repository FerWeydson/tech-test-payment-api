using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Core;

namespace PaymentApi.Requests
{
    public class VendaRequest
    {
        public Vendedor Responsavel { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}