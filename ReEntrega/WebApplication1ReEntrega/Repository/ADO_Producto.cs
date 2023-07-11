using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1ReEntrega.Models;

namespace WebApplication1ReEntrega.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> ListarProductos()
        {

            string connectionString = @"Server =DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Descripciones,Costo,PrecioVenta,Stock,IdUsuario FROM Producto WHERE Id=@pId";

            var listaProductos = new List<Producto>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "@pId";
                    parametro.DbType = DbType.Int32;
                    //parametro.Value = Id;
                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var producto = new Producto();
                            producto.Id = Convert.ToInt64(dr["Id"]);
                            producto.Descripciones = (dr["Descripciones"]).ToString();
                            producto.Costo = Convert.ToDecimal(dr["Costo"]);
                            producto.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(dr["Stock"]);
                            producto.IdUsuario = Convert.ToInt64(dr["IdUsuario"]);
                            listaProductos.Add(producto);
                        }

                    }

                }


            }

            return listaProductos;

        }

        public Producto GetProducto(int id)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Descripciones,Costo,PrecioVenta,Stock,IdUsuario FROM Producto WHERE Id=@pId";

            var producto = new Producto();

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

                            producto.Id = Convert.ToInt64(dr["Id"]);
                            producto.Descripciones = (dr["Descripciones"]).ToString();
                            producto.Costo = Convert.ToDecimal(dr["Costo"]);
                            producto.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(dr["Stock"]);
                            producto.IdUsuario = Convert.ToInt64(dr["IdUsuario"]);

                        }


                    }


                }

                return producto;


            }



        }

        //Crear producto
        public static double CrearProducto(Producto producto)
        {
            double IdProducto = 0;
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"Insert into producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario)
                                Values(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario); select @@IDENTIFY";

                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    comando.Parameters.Add(new SqlParameter("@Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                    comando.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Decimal) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.BigInt) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

                }
                conect.Close();

            }

            return IdProducto;



        }

        //Modificacion producto

        public static void ModificarProducto(Producto producto)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"UPDATE producto 

                                SET Descripciones = @Descripcion,
                                Costo = @Costo,
                                NombreUsuario = @NombreUsuario,
                                PrecioVenta = @PrecioVenta,
                                Stock = Stock
                                IdUsuario = @IdUsuario
                                WHERE Id = @Id";


                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.BigInt) { Value = producto.Id });
                    comando.Parameters.Add(new SqlParameter("@Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                    comando.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Decimal) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.BigInt) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });
                    comando.ExecuteNonQuery();
                }
                conect.Close();

            }

        }

        //Borrar producto
        public static void EliminarProducto(Producto producto)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            using (SqlConnection conect = new SqlConnection(connectionString))
            {

                var query = @"DELETE producto 
                                WHERE Id = @Id
                                INNER JOIN [ProductoVendido]
                                    ON Producto.Id = ProductoVendido.IdProducto";


                conect.Open();

                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });
                    comando.ExecuteNonQuery();
                }
                conect.Close();

            }



        }



    }
}

