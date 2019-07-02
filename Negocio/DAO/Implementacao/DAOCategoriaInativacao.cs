using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DAO.Implementacao
{
    public class DAOCategoriaInativacao : IDAO
    {
        private ECommerceDeLivrosContext _context;

        public DAOCategoriaInativacao(ECommerceDeLivrosContext context)
        {
            _context = context;
        }

        public IEntity Alterar(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> Consultar(IEntity entity)
        {
            CategoriaInativacao categoriaInativacao = (CategoriaInativacao)entity;

            if (categoriaInativacao.Id == 0)
            {
                var categorias = _context.Categorias_Inativacaos;

                if (categoriaInativacao.cati_descricao == null)
                {
                    return categorias.ToList();
                }

                return categorias.Where(l => l.cati_descricao == categoriaInativacao.cati_descricao).ToList();
            }
            else
            {
                return _context.Categorias_Inativacaos.Where(l => l.Id == categoriaInativacao.Id).ToList();
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
