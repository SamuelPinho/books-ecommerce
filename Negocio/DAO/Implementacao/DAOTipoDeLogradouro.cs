using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOTipoDeLogradouro : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOTipoDeLogradouro(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            TipoDeLogradouro tipo = (TipoDeLogradouro)entity;

            // faz um select no banco de dados
            var tipos = _context.TipoDeLogradouro;

            // Se foi passado um Id | retorna uma lista de entidades
            if (tipo.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (tipo.nome == null)
                {
                    return tipos.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return tipos.Where(l => l.nome == tipo.nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return tipos.Where(l => l.Id == tipo.Id).ToList();
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
