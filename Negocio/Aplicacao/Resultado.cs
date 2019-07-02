using Modelo;
using System.Collections.Generic;

namespace Negocio.Aplicacao
{
    public class Resultado
    {
        public IEnumerable<IEntity> Entidades { get; set; }
        public string MensagensDeErro { get; set; }
    }
}
