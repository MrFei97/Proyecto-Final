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
    public class ProductoController : ApiController
    {
        [HttpGet]

        public List<Producto> GetProductos()
        {


            return ADO_Producto.ListarProductos();


        }

        [HttpPost]

        public void CrearProductos([FromBody] Producto producto)
        {


            ADO_Producto.CrearProducto(producto);


        }

        [HttpPut]

        public void ModProducto([FromBody] Producto producto)
        {


            ADO_Producto.ModificarProducto(producto);


        }

        [HttpDelete]

        public void EliminarProducto([FromBody] Producto producto)
        {


            ADO_Producto.EliminarProducto(producto);


        }



    }
}

