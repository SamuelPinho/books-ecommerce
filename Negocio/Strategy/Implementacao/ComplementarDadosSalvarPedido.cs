using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Modelo.Cadastros;

namespace Negocio.Strategy.Implementacao
{
    public class ComplementarDadosSalvarPedido : IStrategy
    {
        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido) entity;

            pedido.ped_data = DateTime.Now;
            pedido.ped_endereco_id = null;


            foreach (var livroAAlterar in pedido.LivrosDoPedidoParaAlterar)
            {
                if (pedido.LivrosDoPedido != null)
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
                else
                {
                    pedido.LivrosDoPedido = new List<Rel_Pedido_Livro> { livroAAlterar };
                }
            }

            foreach (var livro in pedido.LivrosDoPedido)
            {
                livro.hpl_trocado = false;
            }

            return null;
        }
    }
}
