using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1ReEntrega.Models;

namespace WebApplication1ReEntrega.Repository
{
    public class ADO_Ventas
    {

        public static List<Ventas> ListarVentas()
        {

            string connectionString = @"Server =DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios FROM Venta";

            var listaVentas = new List<Ventas>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var Ventas = new Ventas();
                            Ventas.Id = Convert.ToInt64(dr["Id"]);
                            Ventas.Comentarios = (dr["Comentarios"]).ToString();

                            listaVentas.Add(Ventas);
                        }

                    }
                }
            }

            return listaVentas;

        }

        public Ventas GetVentas(int id)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios FROM Venta WHERE Id=@pId";

            var Ventas = new Ventas();

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

                            Ventas.Id = Convert.ToInt64(dr["Id"]);
                            Ventas.Comentarios = (dr["Comentarios"]).ToString();

                        }


                    }


                }

                return Ventas;


            }



        }

    }
}