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
      ,[Nombre]
      ,[Apellido]
      ,[NombreUsuario]
      ,[Contraseña]
      ,[Mail]
  FROM [SistemaGestion].[dbo].[Usuario]
     
     */
    public class Usuario
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set;}

        public string NombreUsuario { get; set;}

        public string Password { get; set;}

        public string Mail { get; set; }


    }



}