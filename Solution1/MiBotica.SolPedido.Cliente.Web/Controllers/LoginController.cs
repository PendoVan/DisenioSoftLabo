using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.Utiles.Helpers;
using System.Web.Security;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Usuario u = new Usuario();
            return View(u);
        }
    }
}