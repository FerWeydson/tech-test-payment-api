using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Core;
using PaymentApi.Models;
using PaymentApi.Requests;
using PaymentApi.Utils;

namespace PaymentApi.Services
{
    public interface IVendaService
    {
        
        public Task<List<Venda>> GetAll();

        public Task<Venda> Create(VendaRequest request);

        public Task Update(long id, StatusVenda status);
        public Task<Venda> GetById(long id);

    }
}