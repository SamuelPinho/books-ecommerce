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
    public class ValidarExistenciaLivroPedido : IStrategy
    {
        private readonly DAOLivro daoLivro;

        public ValidarExistenciaLivroPedido(IDAO _daoLivro)
        {
            daoLivro = (DAOLivro)_daoLivro;
        }

        public string Processar(IEntity entity)
        {
            Pedido pedido = (Pedido)entity;

            if(pedido.alterarLivros != false || pedido.alterarLivros == null)
            {
                // para cada livro recalcula os valores
                foreach (var livro in pedido.LivrosDoPedidoParaAlterar)
                {
                    var livroBanco = (Livro)daoLivro.Consultar(livro.Livro).FirstOrDefault();

                    // verifica se retornou um livro
                    if (livroBanco == null)
                    {
                        return "O livro passado não está cadastrado.";
                    }

                    livro.hpl_valor = livroBanco.liv_valor_venda;
                    livro.Livro = livroBanco;
                    livro.Id = livroBanco.Id;

                }
            }

            return null;
        }

    }
}
