using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOPais : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOPais(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            Pais pais = (Pais)entity;

            // faz um select no banco de dados
            var paises = _context.Paises;

            // Se foi passado um Id | retorna uma lista de entidades
            if (pais.Id == 0)
            {
                // Se não foi passada uma descrição da entidade | retorna todas as entidades
                if (pais.pai_nome == null)
                {
                    return paises.ToList();
                }

                // Se foi passada uma descrição da entidade | retorna todas as entidades com a descrição
                return paises.Where(p => p.pai_nome == pais.pai_nome).ToList();
            }
            else
            {
                // Se foi passado um Id | retorna a entidade especificada
                return paises.Where(l => l.Id == pais.Id).ToList();
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
