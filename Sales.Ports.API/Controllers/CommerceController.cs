using Microsoft.AspNetCore.Mvc;

using Sales.Adapters.SQLDataAccess.Contexts;
using Sales.Core.Application.UseCases;
using Sales.Core.Infraestructure.Repository.Concrete;

using Sales.Core.Domain.Models;
using System.Collections.Generic;
using System;

using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommerceController : ControllerBase
    {
        public CommerceUseCase CreateService()
        {
            SalesDB db = new SalesDB();
            CommerceRepository repository = new CommerceRepository(db);
            CommerceUseCase service = new CommerceUseCase(repository);

            return service;
        }

        // POST api/<CommerceController>
        [HttpPost]
        public ActionResult<Commerce> Post([FromBody] Commerce commerce)
        {
            CommerceUseCase service = CreateService();

            var result = service.Create(commerce);

            return Ok(result);
        }

        // DELETE api/<CommerceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CommerceUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
