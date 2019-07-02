using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Modelo.Cadastros;
using Negocio.DAO;
using Negocio.DAO.Implementacao;

namespace Negocio.Strategy.Implementacao
{
    public class ValidarPrecoVenda : IStrategy
    {
        private readonly DAOCategoriaInativacao daoCategoriaInativacao;
        private readonly DAOPrecificacao daoPrecificacao;
        private readonly DAOLivro daoLivro;

        public ValidarPrecoVenda(IDAO _daoLivro, IDAO _daoCategoriaInativacao, IDAO _daoPrecificacao)
        {
            daoCategoriaInativacao = (DAOCategoriaInativacao) _daoCategoriaInativacao;
            daoPrecificacao = (DAOPrecificacao) _daoPrecificacao;
            daoLivro = (DAOLivro) _daoLivro;
        }

        public string Processar(IEntity entity)
        {
            Livro livro = (Livro)entity;

            var precificacaoSelecionada = (Precificacao) daoPrecificacao
                .Consultar(new Precificacao() { Id = livro.liv_precificacao_id }).FirstOrDefault() ;

            if (livro.liv_valor_venda_temp != 0)
            {
                if (livro.liv_valor_venda_temp < (livro.liv_custo * precificacaoSelecionada.pre_porcentagem))
                {
                    // inativa o livro
                    livro.liv_status = 0;

                    // busca no banco por uma categoria com a descrição passada
                    var categorias = (IList<CategoriaInativacao>) daoCategoriaInativacao
                        .Consultar(new CategoriaInativacao()
                            { cati_descricao = "Abaixo da Precificação Base" }
                        );

                    if (categorias.Count() == 0)
                    {
                        return "ocorreu um erro ao alterar o produto<br>";
                    }

                    // atribui ao livro a categoria encontrada
                    livro.liv_categoria_inativacao = categorias.FirstOrDefault().Id;
                }

                livro.liv_valor_venda = livro.liv_valor_venda_temp;

                return null;
            }

            return null;
        }
    }
}
