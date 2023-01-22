using DesafioNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace DesafioNet.Controllers
{
    public class productsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Product> retorno = new List<Product>();
            try
            {
                retorno = Product.findProducts(null);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to find products"));
                }
            }
            catch
            { 
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to find products"));
            }
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<Product> retorno = new List<Product>();
            try
            {
                retorno = Product.findProducts(id);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to find product"));
                }
            }
            catch
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to find product"));
            }
        }

        [HttpPost]
        public IHttpActionResult Post(ModelProduct modelProduct)
        {
            try
            {
                Product produto = Product.insertProduct(modelProduct.name, modelProduct.brand, modelProduct.price);
                if (produto != null)
                {
                    return Ok(produto);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to Post product"));
                }
            }
            catch
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to Post product"));
            }
        }

        [HttpPut]
        public IHttpActionResult Put(ModelProduct modelProduct)
        {
            try
            {
                Product produto = Product.updateProduct(modelProduct.id, modelProduct.name, modelProduct.brand, modelProduct.price);
                if (produto != null)
                {
                    return Ok(produto);
                }
                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to update product"));
                }
            }
            catch
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Failure to update product"));
            }
        }
    }
}