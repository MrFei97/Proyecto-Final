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
      ,[Descripciones]
      ,[Costo]
      ,[PrecioVenta]
      ,[Stock]
      ,[IdUsuario]
  FROM [SistemaGestion].[dbo].[Producto]


    */

    public class Producto
    {

        public long Id { get; set; }

        public string Descripciones { get; set; }

        public Decimal Costo { get; set; }

        public Decimal PrecioVenta { get; set; }

        public int Stock { get; set; }

        public long IdUsuario { get; set; }


    }
}