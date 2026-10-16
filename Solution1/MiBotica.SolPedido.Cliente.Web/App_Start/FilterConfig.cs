using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Filter;
namespace MiBotica.SolPedido.Cliente.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilterAtributes()); // esto hace que el filtro de excepciones funcione en todaslas clases
        }
    }
}