using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1ReEntrega.Models;

namespace WebApplication1ReEntrega.Repository
{
    public class ADO_ProductosVendidos
    {

        public static List<ProductosVendidos> ListarProductosVendidos()
        {

            string connectionString = @"Server =DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";

            var listaProductosVendidos = new List<ProductosVendidos>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var productoVendido = new ProductosVendidos();
                            productoVendido.Id = Convert.ToInt64(dr["Id"]);
                            productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                            productoVendido.IdProducto = Convert.ToInt64(dr["IdProducto"]);
                            productoVendido.IdVenta = Convert.ToInt64(dr["IdVenta"]);
                            listaProductosVendidos.Add(productoVendido);
                        }

                    }
                }
            }

            return listaProductosVendidos;

        }

        public ProductosVendidos GetProductoVendido(int id)
        {
            string connectionString = @"Server=DESKTOP-0MNSSFT\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido WHERE Id=@pId";

            var productoVendido = new ProductosVendidos();

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

                            productoVendido.Id = Convert.ToInt64(dr["Id"]);
                            productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                            productoVendido.IdProducto = Convert.ToInt64(dr["IdProducto"]);
                            productoVendido.IdVenta = Convert.ToInt64(dr["IdVenta"]);

                        }


                    }


                }

                return productoVendido;


            }



        }
    }
}