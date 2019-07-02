using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOEditora : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOEditora(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Editora editora = (Editora)entity;

            // faz um select no banco de dados
            var editoras = _context.Editoras;

            // Se foi passado um Id | retorna uma lista de entidades
            if (editora.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (editora.edi_nome == null)
                {
                    return editoras.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return editoras.Where(l => l.edi_nome == editora.edi_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return editoras.Where(l => l.Id == editora.Id).ToList();
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
