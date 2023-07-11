using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1ReEntrega.Models;
using WebApplication1ReEntrega.Repository;

namespace WebApplication1ReEntrega.Controllers
{
   

    public class UsuarioController : ApiController
    {

        [HttpGet]

        public List<Usuario> GetUsuarios()
        {
        

            return ADO_Usuario.ListarUsuarios();


        }


        /*
         * Al habilitar esta linea de codigo, no se muestra el usuario en la API
         * 
         * 
        [HttpGet]
     
        public Usuario InicioSesion()
        {
            string user = Console.ReadLine();
            string password = Console.ReadLine();

            return ADO_Usuario.IniciarSesion(user, password);
        }

    }
       */

    }
