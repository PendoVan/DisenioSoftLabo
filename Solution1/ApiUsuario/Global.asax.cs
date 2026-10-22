using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ApiUsuario
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Variables.ListaClientes = new List<Clientes>();
            Variables.ListaClientes.Add(new Clientes() { Codigo = 1, NombreCompleto = "Ricaardo Gutarra", Zona = "Callao" });
            Variables.ListaClientes.Add(new Clientes() { Codigo = 2, NombreCompleto = "David Espinoza", Zona = "Jesus Maria" });
            Variables.ListaClientes.Add(new Clientes() { Codigo = 3, NombreCompleto = "Victor Hidalgo", Zona = "San Martin" });
            Variables.ListaClientes.Add(new Clientes() { Codigo = 4, NombreCompleto = "Gladys Gutierrez", Zona = "Pueblo Libre" });
            Variables.ListaClientes.Add(new Clientes() { Codigo = 5, NombreCompleto = "Mariza Zegarra", Zona = "San Juan" });
        }
    }
}
