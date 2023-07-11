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



        [HttpGet]

        public void InicioSesion(string usuario, string password)
        {
          

            ADO_Usuario.IniciarSesion(usuario, password);
        }

        [HttpPut]

        public void ModUsuario([FromBody]Usuario user)
        {


            ADO_Usuario.ModificarUsuario(user);
        }

    }
     

    }
