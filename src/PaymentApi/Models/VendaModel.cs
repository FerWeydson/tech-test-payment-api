using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApi.Core;
using PaymentApi.Utils;

namespace PaymentApi.Models
{
    public class VendaModel
    {  
        private List<Venda> _vendas;
        public VendaModel()
        {
            _vendas = new List<Venda>
            {
                    new Venda
                    {
                        Id = 1,
                        Responsavel = new Vendedor
                        {
                            Id = 1,
                            Nome = "",
                            Cpf = "",
                            Email = "",
                            Telefone = "",
                        },
                        Produtos = new List<Produto>
                            {
                            new Produto
                                {
                                    Id = 1,
                                    Nome = "",
                                    Descricao = "",
                                    Valor = 0
                                },
                            new Produto
                                {
                                    Id = 2,
                                    Nome = "",
                                    Descricao = "",
                                    Valor = 0
                                }
                            },
                        DataVenda = new DateTime(2010, 1, 1, 8, 0, 15),
                        Status = Utils.StatusVenda.Enviado
                    },
                    new Venda
                    {
                        Id = 2,
                        Responsavel = new Vendedor
                        {
                            Id = 1,
                            Nome = "",
                            Cpf = "",
                            Email = "",
                            Telefone = "",
                        },
                        Produtos = new List<Produto>
                            {
                            new Produto
                                {
                                    Id = 1,
                                    Nome = "",
                                    Descricao = "",
                                    Valor = 0
                                },
                            new Produto
                                {
                                    Id = 3,
                                    Nome = "",
                                    Descricao = "",
                                    Valor = 0
                                }
                            },
                        DataVenda = new DateTime(2010, 1, 1, 8, 0, 15),
                        Status = Utils.StatusVenda.Enviado
                    }
            };
        }
        
        public async Task<List<Venda>> GetAll()
        {
            var content = await Task.Run(() => _vendas);
            return content;
        }
        public async Task<bool> Create(Venda venda)
        {
            int listLenght = await Task.Run(() => _vendas.Count());
            await Task.Run(() => _vendas.Add(venda));
            var count = await Task.Run(() => _vendas.Count());

            if(listLenght < count)
                return true;
            
            return false;
        }
        public async Task<long> GetValidId()
        {
            var content = await Task.Run(() => _vendas.Count + 1);
            return content;
        }
        public async Task<Venda> GetVenda(long Id)
        {
            var content = await Task.Run(() => _vendas.Find(x => x.Id == Id));
            return content;
            
        }
        public async Task Update(long id, StatusVenda status)
        {            
            var content = await Task.Run(() => _vendas.Find(x => x.Id == id));
            content.Status = status;
        }
    }
}
