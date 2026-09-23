using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().ListaUsuarios();

            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // 1. Ciframos el texto plano y lo asignamos a la propiedad binaria
                usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);

                // 2. Invocamos a la capa de negocio para registrar (Nota: se creará en el paso siguiente)
                new UsuarioLN().InsertarUsuario(usuario);

                // 3. Si todo sale bien, redirige al listado
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            // Buscamos al usuario actual para cargar sus datos en el formulario
            Usuario usuario = new UsuarioLN().ListaUsuarios().Find(x => x.IdUsuario == id);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = id;

                // Si escribió clave, la encriptamos a byte[]
                if (!string.IsNullOrEmpty(usuario.ClaveTexto))
                {
                    usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                }
                else
                {
                    // Si NO escribió clave, traemos los bytes de la clave actual de la BD
                    Usuario usuarioActual = new UsuarioLN().ListaUsuarios().Find(x => x.IdUsuario == id);
                    if (usuarioActual != null)
                    {
                        usuario.Clave = usuarioActual.Clave;
                    }
                }

                new UsuarioLN().ModificarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            // Buscamos el usuario para mostrar la pantalla de confirmación de borrado
            Usuario usuario = new UsuarioLN().ListaUsuarios().Find(x => x.IdUsuario == id);
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                new UsuarioLN().EliminarUsuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
