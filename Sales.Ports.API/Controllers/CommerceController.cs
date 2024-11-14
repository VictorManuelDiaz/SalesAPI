using Microsoft.AspNetCore.Mvc;

using Sales.Adapters.SQLDataAccess.Contexts;
using Sales.Core.Application.UseCases;
using Sales.Core.Infraestructure.Repository.Concrete;
using Sales.Core.Domain.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommerceController : ControllerBase
    {
        [NonAction]
        public CommerceUseCase CreateService()
        {
            SalesDB db = new SalesDB();
            CommerceRepository repository = new CommerceRepository(db);
            CommerceUseCase service = new CommerceUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Sale> Post([FromBody] Commerce commerce)
        {
            CommerceUseCase service = CreateService();

            var result = service.Create(commerce);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(Guid id)
        {
            CommerceUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
