using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiUsuario.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<Clientes> Get()
        {
            return Variables.ListaClientes;
        }

        // GET: api/Cliente/5
        public Clientes Get(int id)
        {
            return (from x in Variables.ListaClientes
                    where x.Codigo == id
                    select x).FirstOrDefault();
        }

        // POST: api/Cliente
        public void Post([FromBody] Clientes value)
        {
            Variables.ListaClientes.Add(value);
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody] Clientes value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}

