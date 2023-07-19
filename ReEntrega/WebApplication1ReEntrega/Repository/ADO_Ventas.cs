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

        //Cargar
        public static double CrearVenta(Ventas ventas)
        {
            double IdVenta = 0;
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"Insert into Venta (Comentarios)
                                Values(@Comentarios); select @@IDENTIFY";

                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    comando.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar) { Value = ventas.Comentarios });



                }
                conect.Close();

            }

            return IdVenta;



        }

        //Eliminar venta
        public static void CancelarVenta(Ventas ventas)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"DELETE Venta
                                WHERE Id = @Id";


                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = ventas.Id });
                    comando.ExecuteNonQuery();
                }
                conect.Close();

            }



        }

    }
}