using Modelo.Cadastros;
using Modelo.Infra;
using Negocio.DAO;
using Negocio.DAO.Implementacao;

using System.Collections.Generic;

namespace Negocio.Factory.Implementacao
{
    public class FactoryDAO : IFactory {

        private static ECommerceDeLivrosContext _context;
        private readonly DAOUsuario _daoUsuario;

         public FactoryDAO(ECommerceDeLivrosContext context, DAOUsuario daoUsuario)
        {
            _context = context;
            _daoUsuario = daoUsuario;
        }

        public IDAO Factory(string dao)
        {
            var daos = new Dictionary<string, IDAO>
            {
                [nameof(Livro)] = new DAOLivro(_context),
                [nameof(CategoriaAtivacao)] = new DAOCategoriaAtivacao(_context),
                [nameof(CategoriaInativacao)] = new DAOCategoriaInativacao(_context),
                [nameof(Autor)] = new DAOAutor(_context),
                [nameof(Editora)] = new DAOEditora(_context),
                [nameof(Categoria)] = new DAOCategoria(_context),
                [nameof(Assunto)] = new DAOAssunto(_context),
                [nameof(Precificacao)] = new DAOPrecificacao(_context),
                [nameof(Fornecedor)] = new DAOFornecedor(_context),
                [nameof(StatusPedido)] = new DAOStatusPedido(_context),
                [nameof(Pedido)] = new DAOPedido(_context),
                [nameof(Usuario)] = _daoUsuario,
                [nameof(Bandeira)] = new DAOBandeira(_context),
                [nameof(Pais)] = new DAOPais(_context),
                [nameof(Estado)] = new DAOEstado(_context),
                [nameof(TipoDeLogradouro)] = new DAOTipoDeLogradouro(_context),
                [nameof(Genero)] = new DAOGenero(_context),
                [nameof(Papel)] = new DAOPapel(_context),
                [nameof(Cupom)] = new DAOCupom(_context),
                [nameof(Cartao)] = new DAOCartao(_context),
                [nameof(Endereco)] = new DAOEndereco(_context),
            };

            return daos[dao];
        }
    }
}
