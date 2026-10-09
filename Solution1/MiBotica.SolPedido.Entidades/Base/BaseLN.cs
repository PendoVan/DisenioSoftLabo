using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using System.Web.Mvc;            

namespace MiBotica.SolPedido.Entidades.Base
{
    public class BaseLN : Controller   
    {
        protected log4net.ILog Log
        {
            get
            {
                return
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().GetType());
            }
        }
    }
}