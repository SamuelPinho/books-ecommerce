using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.DAO.Implementacao
{
    public class DAOEndereco : IDAO
    {
        private readonly ECommerceDeLivrosContext _context;

        public DAOEndereco(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Endereco endereco = (Endereco)entity;

            // Se não possuir Id | retorna livros
            if (endereco.Id == 0)
            {
                var enderecos = _context.Enderecos
                    .Include(e => e.TipoDeLogradouro)
                    .Include(e => e.Pais)
                    .Include(e => e.Estado)
                    .Include(e => e.EnderecosDoUsuario)
                        .ThenInclude(rel => rel.Usuario);

                // Se não possui titulo do livro | retorna todos os livros
                if (endereco.apelido == null)
                {
                    return enderecos.ToList();
                }

                // Se possui o titulo do livro | retorna todos os livros que correspondem à ele
                return enderecos.Where(c => c.apelido == endereco.apelido).ToList();
            }
            else
            {
                // Foi informado um Id para pesquisa
                return _context.Enderecos
                    .Include(e => e.TipoDeLogradouro)
                    .Include(e => e.Pais)
                    .Include(e => e.Estado)
                    .Include(e => e.EnderecosDoUsuario)
                        .ThenInclude(rel => rel.Usuario);
            }
        }

        public IEntity Salvar(IEntity entity)
        {
            Endereco endereco = (Endereco) entity;

            _context.Add(endereco);

            _context.SaveChanges();

            return endereco;
        }

        public IEntity Alterar(IEntity entity)
        {
            Endereco endereco = (Endereco) entity;

            _context.Update(endereco);

            _context.SaveChanges();

            return endereco;
        }

        public void Excluir(IEntity entity)
        {
            Endereco endereco = (Endereco)entity;

            _context.Remove(endereco);

            _context.SaveChanges();
        }
    }
}
