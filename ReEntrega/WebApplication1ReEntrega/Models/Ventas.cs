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
      ,[Comentarios]
  FROM [SistemaGestion].[dbo].[Venta]



  */

    public class Ventas
    {

        public long Id { get; set; }

        public string Comentarios { get; set; }

    }
}