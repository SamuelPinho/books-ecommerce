using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOPapel : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOPapel(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Papel papel = (Papel)entity;

            // faz um select no banco de dados
            var papeis = _context.Papeis;

            // Se foi passado um Id | retorna uma lista de entidades
            if (papel.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (papel.pap_nome == null)
                {
                    return papeis.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return papeis.Where(l => l.pap_nome == papel.pap_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return papeis.Where(l => l.Id == papel.Id).ToList();
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
