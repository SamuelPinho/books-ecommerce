using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOPrecificacao : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOPrecificacao(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Precificacao precificacao = (Precificacao)entity;

            // faz um select no banco de dados
            var precificacoes = _context.Precificacoes;

            // Se foi passado um Id | retorna uma lista de entidades
            if (precificacao.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (precificacao.pre_nome == null)
                {
                    return precificacoes.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return precificacoes.Where(l => l.pre_nome == precificacao.pre_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return precificacoes.Where(l => l.Id == precificacao.Id).ToList();
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
