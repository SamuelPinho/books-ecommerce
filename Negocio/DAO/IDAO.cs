using Modelo;
using System.Collections.Generic;

namespace Negocio.DAO
{
    public interface IDAO
    {
        IEntity Salvar(IEntity entity);
        IEnumerable<IEntity> Consultar(IEntity entity);
        IEntity Alterar(IEntity entity);
        void Excluir(IEntity entity);
    }
}
