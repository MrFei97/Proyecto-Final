using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1ReEntrega.Models;

namespace WebApplication1ReEntrega.Repository
{
    public class ADO_Usuario
    {
        //Inicio de sesion
        public static Usuario IniciarSesion(string NombreUsuario, string password)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();

                const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario
                   WHERE NombreUsuario = @NombreUsuario AND Contraseña = @password";

                using (var command = new SqlCommand(query, connection))

                {

                    command.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);

                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())

                    {

                        if (reader.Read())

                        {

                            return new Usuario

                            {

                                Id = reader.GetInt64(0),

                                Nombre = reader.GetString(1),

                                Apellido = reader.GetString(2),

                                NombreUsuario = reader.GetString(3),

                                Password = reader.GetString(4),

                                Mail = reader.GetString(5)

                            };

                        }

                        else

                        {

                            return null;

                        }

                    }

                }

            }

        }

        //Traer Usuarios
        public static List<Usuario> ListarUsuarios()
        {

            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario";

            var listaUsuarios = new List<Usuario>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(dr["Id"]);
                            usuario.Nombre = (dr["Nombre"]).ToString();
                            usuario.Apellido = (dr["Apellido"]).ToString();
                            usuario.NombreUsuario = (dr["NombreUsuario"]).ToString();
                            usuario.Password = (dr["Contraseña"]).ToString();
                            usuario.Mail = (dr["Mail"]).ToString();
                            listaUsuarios.Add(usuario);
                        }

                    }

                }


            }

            return listaUsuarios;

        }




        public static Usuario GetUsuarios(int id)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario WHERE Id=@pId";

            var usuario = new Usuario();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "@pId";
                    parametro.DbType = DbType.Int32;
                    parametro.Value = id;
                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            usuario.Id = Convert.ToInt32(dr["Id"]);
                            usuario.Nombre = (dr["Nombre"]).ToString();
                            usuario.Apellido = (dr["Apellido"]).ToString();
                            usuario.NombreUsuario = (dr["NombreUsuario"]).ToString();
                            usuario.Password = (dr["Contraseña"]).ToString();
                            usuario.Mail = (dr["Mail"]).ToString();

                        }


                    }


                }

                return usuario;


            }



        }

    }
}