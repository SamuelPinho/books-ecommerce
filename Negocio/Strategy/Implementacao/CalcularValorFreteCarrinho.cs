using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using Negocio.DAO.Implementacao;
using Negocio.Strategy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Negocio.Strategy.Implementacao
{
    public class CalcularValorFreteCarrinho : IStrategy
    {
        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            //Verifica se a alteração pretendida é enquanto o pedido é um carrinho
            if (pedido.StatusPedido.sta_ped_descricao == "Carrinho")
            {
                // para cada livro novo adicionado, recalcula os valores
                if (pedido.LivrosDoPedido == null || pedido.LivrosDoPedido.Count() == 0)
                {
                    foreach (var livro in pedido.LivrosDoPedidoParaAlterar)
                    {
                        livro.hpl_valor_frete = livro.hpl_preco_total * 0.05;
                    }
                }
                else
                {
                    foreach (var livro in pedido.LivrosDoPedido)
                    {
                        livro.hpl_valor_frete = livro.hpl_preco_total * 0.05;
                    }
                }
                
            }

            return null;
        }

    }
}
