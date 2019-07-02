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
    public class ValidarExistenciaLivroConsultar : IStrategy
    {
        private readonly DAOLivro daoLivro;

        public ValidarExistenciaLivroConsultar(IDAO _daoLivro)
        {
            daoLivro = (DAOLivro)_daoLivro;
        }

        public string Processar(IEntity entity)
        {
            Livro livro = (Livro)entity;

            var livros = (IList<Livro>)daoLivro.Consultar(livro);

            // Se a busca retornou resultados | retorna mensagem de erro
            if (livros.Count() == 0 || livros == null)
            {
                return "Não há nenhum livro cadastrado com estes parametros";
            }

            return null;
        }
    }
}
