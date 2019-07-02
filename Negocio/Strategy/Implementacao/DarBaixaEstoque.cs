using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using Negocio.DAO;
using Negocio.DAO.Implementacao;
using Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Negocio.Strategy.Implementacao
{
    public class DarBaixaEstoque : IStrategy
    {
        private readonly DAOPedido daoPedido;

        public DarBaixaEstoque(IDAO _daoPedido)
        {
            daoPedido = (DAOPedido)_daoPedido;
        }

        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            if (pedido.alterarLivros != false || pedido.alterarLivros == null)
            {

                Pedido pedidoBanco = null;

                if (pedido.Id != 0)
                {
                    pedidoBanco = (Pedido)daoPedido.Consultar(new Pedido() { Id = pedido.Id }).FirstOrDefault();
                }
                var itensBanco = new List<Rel_Pedido_Livro>();
                var quantidadeDoBanco = 0;
                if (pedidoBanco != null)
                {
                    itensBanco = pedidoBanco.LivrosDoPedido.ToList();
                }

                //Verifica se a alteração pretendida é enquanto o pedido é um carrinho
                if (pedido.StatusPedido.sta_ped_descricao == "Carrinho")
                {
                    foreach (var itemPassado in pedido.LivrosDoPedidoParaAlterar)
                    {
                        // 1
                        var quantidadePassada = itemPassado.hpl_quantidade;
                        if (pedidoBanco != null)
                        {
                            if (itensBanco.FirstOrDefault(i => i.Id == itemPassado.Id) != null)
                            {
                                quantidadeDoBanco = itensBanco.FirstOrDefault(i => i.Id == itemPassado.Id).hpl_quantidade;
                            }
                        }

                        // Verifica se a quantidade para alteração é diferente de zero
                        if (quantidadePassada != 0)
                        {
                            itemPassado.Livro.liv_quantidade -= quantidadePassada;
                        }
                    }
                }

                pedidoBanco = null;
            }

            return null;
        }

    }
}
