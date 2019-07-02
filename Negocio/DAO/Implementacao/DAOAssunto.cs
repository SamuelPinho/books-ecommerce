using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOAssunto : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOAssunto(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Assunto assunto = (Assunto)entity;

            // faz um select no banco de dados
            var assuntos = _context.Assuntos.Include(e=>e.Livros);

            // Se foi passado um Id | retorna uma lista de entidades
            if (assunto.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (assunto.ass_descricao == null)
                {
                    return assuntos.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return assuntos.Where(l => l.ass_descricao == assunto.ass_descricao).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return assuntos.Where(l => l.Id == assunto.Id).ToList();
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
