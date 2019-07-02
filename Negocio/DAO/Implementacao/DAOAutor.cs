using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOAutor : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOAutor(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Autor autor = (Autor)entity;

            // faz um select no banco de dados
            var autores = _context.Autores;

            // Se foi passado um Id | retorna uma lista de entidades
            if (autor.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (autor.aut_nome == null)
                {
                    return autores.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return autores.Where(l => l.aut_nome == autor.aut_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return autores.Where(l => l.Id == autor.Id).ToList();
            }
        }

        public void Excluir(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Salvar(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
