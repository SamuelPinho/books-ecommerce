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
    public class AlterarItensCarrinho : IStrategy
    {
        private readonly DAOPedido daoPedido;

        public AlterarItensCarrinho(IDAO _daoPedido)
        {
            daoPedido = (DAOPedido)_daoPedido;
        }

        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;
            var livroDoPedidoFoiRemovido = false;

            if (pedido.alterarLivros != false || pedido.alterarLivros == null)
            {
                // Verifica se um Id foi passado (Id passado = carrinho já existe)
                if (pedido.Id != 0)
                {
                    var pedidoBanco = (Pedido)daoPedido.Consultar(pedido).FirstOrDefault();
                    var itensBanco = pedidoBanco.LivrosDoPedido.ToList();

                    // para cada livro novo adicionado, recalcula os valores
                    foreach (var itemBanco in itensBanco)
                    {
                        // busca pelo item passado pela view dentro da lista de itens do banco
                        var itemPassado = pedido.LivrosDoPedidoParaAlterar
                            .FirstOrDefault(i => i.Livro.Id == itemBanco.Id);

                        // Se foi encontrado algum item que já esteja adicionado aos itens do banco
                        if (itemPassado != null) // se encontrou no banco, já existe no carrinho
                        {
                            var quantidadePassada = itemPassado.hpl_quantidade;
                            var quantidadeDoBanco = itemBanco.hpl_quantidade;

                            // remove o livro se a quantidade passada for negativa e no mesmo valor que o que tem no pedido
                            if ((quantidadePassada + quantidadeDoBanco) == 0)
                            {
                                var pedidoARemover = pedido.LivrosDoPedido.Where(e => e.Id == itemPassado.Id).FirstOrDefault();
                                pedido.LivrosDoPedido.Remove(pedidoARemover);
                                livroDoPedidoFoiRemovido = true;
                            }
                            else
                            {
                                itemPassado.hpl_quantidade = quantidadeDoBanco + quantidadePassada;
                                itemPassado.Id = itemBanco.Id;
                                itemPassado.ped_id = itemBanco.ped_id;

                            }
                        }
                        else
                        {
                            // atribui o livro ao pedido a ser alterado
                            pedido.LivrosDoPedido.Add(itemBanco);
                        }
                    }

                    pedidoBanco = null;

                }

                foreach (var livroAAlterar in pedido.LivrosDoPedidoParaAlterar)
                {
                    if (pedido.LivrosDoPedido != null)
                    {
                        // Quando o item do pedido for removido, não adiciona novamente
                        if (!livroDoPedidoFoiRemovido)
                        {
                            var livroQueVaiAtualizar = pedido.LivrosDoPedido.Where(e => e.Id == livroAAlterar.Id).FirstOrDefault();

                            if (livroQueVaiAtualizar != null)
                            {
                                pedido.LivrosDoPedido.Remove(livroQueVaiAtualizar);


                                pedido.LivrosDoPedido.Add(livroAAlterar);
                            }
                            else
                            {
                                pedido.LivrosDoPedido.Add(livroAAlterar);
                            }
                        }
                    }
                    else
                    {
                        pedido.LivrosDoPedido = new List<Rel_Pedido_Livro> { livroAAlterar };
                    }
                }
            }

            return null;
        }

    }
}
