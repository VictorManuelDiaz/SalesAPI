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
    public class SaleController : ControllerBase
    {
        [NonAction]
        public SaleUseCase CreateService()
        {
            SalesDB db = new SalesDB();
            SaleRepository repository = new SaleRepository(db);
            SaleUseCase service = new SaleUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Sale> Post([FromBody] Sale sale)
        {
            SaleUseCase service = CreateService();

            var result = service.Create(sale);

            return Ok(result);
        }
    }
}
