using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBotica.SolPedido.Entidades.Core;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class UsuarioDA
    {
        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioLista", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entidad = LlenarEntidad(reader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }
            return listaEntidad;
        }

        public Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario();
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdUsuario"]))
                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clave'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Clave"]))
                {
                    // usuario.Clave  = reader["Clave"];
                }
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["CodUsuario"]))
                    usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Nombres"]))
                    usuario.Nombres = Convert.ToString(reader["Nombres"]);
            }
            return usuario;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioInsertar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    // Pasamos los parámetros al Procedimiento Almacenado
                    comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);

                    conexion.Open();
                    comando.ExecuteNonQuery(); // Ejecuta la inserción sin retornar filas
                    conexion.Close();
                }
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioModificar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioEliminar", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
    }
}
