using Negocio.DAO;

namespace Negocio.Factory
{
    public interface IFactory
    {
        IDAO Factory(string dao);
    }
}
