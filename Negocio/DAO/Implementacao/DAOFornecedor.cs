using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOFornecedor : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOFornecedor(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Fornecedor fornecedor = (Fornecedor)entity;

            // faz um select no banco de dados
            var fornecedores = _context.Fornecedores;

            // Se foi passado um Id | retorna uma lista de entidades
            if (fornecedor.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (fornecedor.for_nome == null)
                {
                    return fornecedores.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return fornecedores.Where(l => l.for_nome == fornecedor.for_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return fornecedores.Where(l => l.Id == fornecedor.Id).ToList();
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
