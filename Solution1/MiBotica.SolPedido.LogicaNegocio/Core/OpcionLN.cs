using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.AccesoDatos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class OpcionLN : BaseLN
    {
        public List<Opcion> ListaOpciones()
        {
            try
            {
                return new OpcionDA().ListaOpciones();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
