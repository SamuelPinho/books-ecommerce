using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOGenero : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOGenero(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Genero genero = (Genero)entity;

            // faz um select no banco de dados
            var generos = _context.Generos;

            // Se foi passado um Id | retorna uma lista de entidades
            if (genero.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (genero.gen_nome == null)
                {
                    return generos.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return generos.Where(l => l.gen_nome == genero.gen_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return generos.Where(l => l.Id == genero.Id).ToList();
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
