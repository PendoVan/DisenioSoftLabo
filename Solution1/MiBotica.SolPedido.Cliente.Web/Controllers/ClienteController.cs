using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using MiBotica.SolPedido.Entidades.Core;






namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ClienteController : Controller
    {
        string RutaApi = "http://localhost:53810/api/"; // define la ruta de la Api
        string jsonMediaType = "application/json"; // define el tipo de dato
        // GET: Clientes
        public ActionResult Index()
        {
            string metodo = "Cliente"; // refiere al controlador del la Api
            string accion = "Get";     // refiere a la Accion de que se ejecuta
            List<Clientes> lista = new List<Clientes>();
            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear(); // borra datos anteriores de la cabecera
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType; // tipo de dato
                cliente.Encoding = UTF8Encoding.UTF8; // tipo de decodificación textos en chino ñ y otros
                string rutacompleta = RutaApi + metodo;
                var data = cliente.DownloadString(new Uri(rutacompleta));
                lista = JsonConvert.DeserializeObject<List<Clientes>>(data);
            }
            return View(lista);
        }





        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
