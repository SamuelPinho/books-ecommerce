using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOLivro : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOLivro(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Livro livro = (Livro)entity;

            // Se não possuir Id | retorna livros
            if (livro.Id == 0)
            {
                var livros = _context.Livros
                    .Include(l => l.Assunto)
                    .Include(l => l.LivrosDoPedido)
                        .ThenInclude(rel => rel.Pedido)
                            .ThenInclude(p => p.StatusPedido);

                // Se não possui titulo do livro | retorna todos os livros
                if (livro.liv_titulo == null)
                {
                    return livros.ToList();
                }

                // Se possui o titulo do livro | retorna todos os livros que correspondem à ele
                return livros.Where(l => l.liv_titulo == livro.liv_titulo).ToList();
            }
            else
            {
                // Foi informado um Id para pesquisa
                return _context.Livros
                    .Include(l => l.Assunto)
                    .Include(l => l.Precificacao)
                    .Include(l => l.AutoresDoLivro)
                        .ThenInclude(autor => autor.Autor)
                    .Include(l => l.EditorasDoLivro)
                        .ThenInclude(editora => editora.Editora)
                    .Include(l => l.CategoriasDoLivro)
                        .ThenInclude(categoria => categoria.Categoria)
                    .Include(l => l.Fornecedores)
                        .ThenInclude(fornecedor => fornecedor.Fornecedor)
                    .Where(l => l.Id == livro.Id).ToList();
            }
        }

        public IEntity Salvar(IEntity entity)
        {
            Livro livro = (Livro) entity;

            _context.Add(livro);

            _context.SaveChanges();

            return livro;
        }

        public IEntity Alterar(IEntity entity)
        {
            Livro livro = (Livro) entity;

            _context.Update(livro);

            _context.SaveChanges();

            return livro;
        }

        public void Excluir(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
