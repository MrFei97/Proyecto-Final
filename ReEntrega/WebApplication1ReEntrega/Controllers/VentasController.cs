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
    public class VentasController : ApiController
    {
        [HttpGet]

        public List<Ventas> GetVentas()
        {


            return ADO_Ventas.ListarVentas();


        }

        [HttpPost]

        public void CargarVenta([FromBody] Ventas venta)
        {

            ADO_Ventas.CrearVenta(venta);

        }

        [HttpDelete]

        public void CancelarVenta([FromBody] Ventas venta)
        {


            ADO_Ventas.CancelarVenta(venta);


        }



        /* No consegui hacer funcionar esta linea
         * Ejercicio clase 15
        [HttpPost]

        public void NuevaVenta([FromBody] Ventas venta)
        {


            ADO_Producto.ListarProductos();

            ADO_Ventas.CrearVenta(venta);

            ADO_ProductosVendidos.ModificarProductoVendido([FromBody] venta);




        }*/

    }
}

