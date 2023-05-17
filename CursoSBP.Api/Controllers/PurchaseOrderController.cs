using CursoSBP.Common.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursoSBP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Response> Get()
        {
            var response1 = new Response()
            {
                IsSuccess = true,
                Message = "OK",
                Result = "Este es el primero"
            };
            var response2 = new Response()
            {
                IsSuccess = false,
                Message = "Error",
                Result = "Este es el segundo"
            };

            List<Response> listResult = new List<Response>(){ response1,response2};

            return listResult;
        }


        [HttpGet("{id}")]
        public ActionResult<Response> Get(int id)
        {
            var respuesta =  new Response() 
            { 
                IsSuccess = true, 
                Message = "OK Http",
                Result= $"Usted está consultando el Registro Nro. {id} "
            };
            return Ok();
        }

        // POST api/<PurchaseOrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PurchaseOrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
