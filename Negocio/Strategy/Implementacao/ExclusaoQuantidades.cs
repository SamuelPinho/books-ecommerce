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
    public class ExclusaoQuantidades : IStrategy
    {
        private readonly DAOPedido daoPedido;
        private readonly DAOLivro daoLivro;

        public ExclusaoQuantidades(IDAO _daoPedido, IDAO _daoLivro)
        {
            daoPedido = (DAOPedido)_daoPedido;
            daoLivro = (DAOLivro)_daoLivro;
        }

        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            var pedidoAntigo = (Pedido)daoPedido.Consultar(pedido).FirstOrDefault();

            // para cada livro novo adicionado, recalcula os valores
            foreach (var item in pedidoAntigo.LivrosDoPedido)
            {
                // se um item do carrinho está com quantidade zero | remover ele do carrinho
                pedido.LivrosDoPedidoParaAlterar.FirstOrDefault(r => r.Id == item.Id).Livro.liv_quantidade += item.hpl_quantidade;

                // aplica as modificações necessárias ao livro
                daoLivro.Alterar(pedido.LivrosDoPedidoParaAlterar.FirstOrDefault(r => r.Id == item.Id).Livro);

                pedido.LivrosDoPedidoParaAlterar.Remove(item);
            }

            pedidoAntigo = null;

            return null;
        }

    }
}
