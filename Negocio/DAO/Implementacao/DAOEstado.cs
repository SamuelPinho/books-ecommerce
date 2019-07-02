using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOEstado : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOEstado(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Estado estado = (Estado)entity;

            // faz um select no banco de dados
            var estados = _context.Estados;

            // Se foi passado um Id | retorna uma lista de entidades
            if (estado.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (estado.est_sigla == null)
                {
                    return estados.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return estados.Where(l => l.est_sigla == estado.est_sigla).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return estados.Where(l => l.Id == estado.Id).ToList();
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
