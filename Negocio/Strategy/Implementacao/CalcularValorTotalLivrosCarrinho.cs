using Modelo;
using Modelo.Cadastros;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Strategy.Implementacao
{
    public class CalcularValorTotalItensCarrinho : IStrategy
    {
        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            if(pedido.alterarLivros != false || pedido.alterarLivros == null)
            {
                //Verifica se a alteração pretendida é enquanto o pedido é um carrinho
                if (pedido.StatusPedido.sta_ped_descricao == "Carrinho")
                {
                    // para cada livro novo adicionado, recalcula os valores
                    if (pedido.LivrosDoPedido == null || pedido.LivrosDoPedido.Count() == 0)
                    {
                        foreach (var livro in pedido.LivrosDoPedidoParaAlterar)
                        {
                            livro.hpl_preco_total = livro.hpl_quantidade * livro.hpl_valor;
                        }
                    }
                    else
                    {
                        foreach (var livro in pedido.LivrosDoPedido)
                        {
                            livro.hpl_preco_total = livro.hpl_quantidade * livro.hpl_valor;
                        }
                    }
                }
            }

            return null;
        }

    }
}
