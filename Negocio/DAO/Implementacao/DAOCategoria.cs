using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOCategoria : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOCategoria(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Categoria categoria = (Categoria)entity;

            // faz um select no banco de dados
            var categorias = _context.Categorias;

            // Se foi passado um Id | retorna uma lista de entidades
            if (categoria.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (categoria.cat_nome == null)
                {
                    return categorias.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return categorias.Where(l => l.cat_nome == categoria.cat_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return categorias.Where(l => l.Id == categoria.Id).ToList();
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
