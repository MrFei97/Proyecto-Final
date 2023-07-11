using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1ReEntrega.Models
{
    /*
* Datos figurados en la base de datos
* 
SELECT TOP (1000) [Id]
      ,[Stock]
      ,[IdProducto]
      ,[IdVenta]
  FROM [SistemaGestion].[dbo].[ProductoVendido]

*/

    public class ProductosVendidos
    {
        public long Id { get; set; }

        public int Stock { get; set;}

        public long IdProducto { get; set; }

        public long IdVenta { get; set;}


    }
}