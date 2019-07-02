using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOBandeira : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOBandeira(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Bandeira bandeira = (Bandeira)entity;

            // faz um select no banco de dados
            var bandeiras = _context.Bandeiras;

            // Se foi passado um Id | retorna uma lista de entidades
            if (bandeira.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (bandeira.ban_nome == null)
                {
                    return bandeiras.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return bandeiras.Where(b => b.ban_nome == bandeira.ban_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return bandeiras.Where(b => b.Id == bandeira.Id).ToList();
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
