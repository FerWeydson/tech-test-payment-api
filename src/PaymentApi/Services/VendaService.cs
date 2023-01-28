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
    public class VendaService : IVendaService
    {
        private readonly VendaModel _vendaModel;
        public VendaService(VendaModel vendaModel) 
        {
            _vendaModel = vendaModel;
        }
        public async Task<List<Venda>> GetAll()
        {
            var response = await _vendaModel.GetAll();
            if(response == null)
                throw new Exception("Problema na base de dados.");
            return response;
        }
        
        public async Task<Venda> Create(VendaRequest request)
        {
            if(request == null)
                throw new Exception("Erro na criação da requisição");

            var Id = await _vendaModel.GetValidId();
            var instance = new Venda(request, Id);
            var repsonse = await _vendaModel.Create(instance);

            if(repsonse == true)
            {
                return instance;
            }
            else
            {
                throw new Exception("Erro na inserção da base de dados");
            }
            
        }
        
        public async Task Update(long id, StatusVenda status)
        {
            var venda = await _vendaModel.GetVenda(id);
            if (venda != null)
                throw new Exception("Esta venda não existe");

            if (venda.Status == StatusVenda.AguardandoPagamento)
            {
                if (status != StatusVenda.PagamentoAprovado || status != StatusVenda.Cancelado)
                {
                    throw new Exception("Mudança de status inválida");
                }
                await _vendaModel.Update(id, status);
            }
            else if (venda.Status == StatusVenda.PagamentoAprovado)
            {
                if (status != StatusVenda.EnviadoParaTransportadora || status != StatusVenda.Cancelado)
                {
                    throw new Exception("Mudança de status inválida");
                }
                await _vendaModel.Update(id, status);
            }
            else if (venda.Status == StatusVenda.EnviadoParaTransportadora)
            {
                if (status != StatusVenda.Entregue)
                {
                    throw new Exception("Mudança de status inválida");
                }
                await _vendaModel.Update(id, status);
            }
        }
    }
}