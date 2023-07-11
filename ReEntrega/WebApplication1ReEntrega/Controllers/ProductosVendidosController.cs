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
    public class ProductosVendidosController : ApiController
    {

        [HttpGet]

        public List<ProductosVendidos> GetProductosVendidos()
        {


            return ADO_ProductosVendidos.ListarProductosVendidos();


        }

    }

}

