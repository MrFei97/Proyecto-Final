﻿using System;
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

        //Traer Nombres
        public static List<Usuario> ListarNombres()
        {

            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido FROM Usuario";

            var listaNombres = new List<Usuario>();

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
                            listaNombres.Add(usuario);
                        }

                    }

                }


            }

            return listaNombres;

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

        //Crear Usuario
        public static double CrearUsuario(Usuario usuario)
        {
            double IdUsuario = 0;
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"Insert into usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail)
                                Values(@Nombre, @Apellido, @NombreUsuario,@Password,@mail); select @@IDENTIFY";

                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Password", SqlDbType.VarChar) { Value = usuario.Password });
                    comando.Parameters.Add(new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Mail });

                }
                conect.Close();

            }

            return IdUsuario;



        }


        //Modificar Usuario

        public static void ModificarUsuario(Usuario usuario)
    {
        string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        using (SqlConnection conect = new SqlConnection(connectionString))
        {

            var query = @"UPDATE usuario 

                                SET Nombre = @Nombre,
                                Apellido = @Apellido,
                                NombreUsuario = @NombreUsuario,
                                Contraseña = @Password,
                                Mail = mail
                                WHERE Id = @Id";


            conect.Open();

            using (SqlCommand comando = new SqlCommand(query, conect))
            {
                comando.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                comando.Parameters.Add(new SqlParameter("Password", SqlDbType.VarChar) { Value = usuario.Password });
                comando.Parameters.Add(new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Mail });
                comando.ExecuteNonQuery();
            }
            conect.Close();

        }

    }


        //Eliminar Usuario

        public static void EliminarUsuario(Usuario usuario)
        {

            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"DELETE usuario 
                                WHERE Id = @Id";


                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                    comando.ExecuteNonQuery();
                }
                conect.Close();

            }

        }



    }
}
 
