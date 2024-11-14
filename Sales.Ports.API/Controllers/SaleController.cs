using Microsoft.AspNetCore.Mvc;

using Sales.Adapters.SQLDataAccess.Contexts;
using Sales.Core.Application.UseCases;
using Sales.Core.Infraestructure.Repository.Concrete;
using Sales.Core.Domain.Models;
using System;
using System.Collections.Generic;
using Sales.Core.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Ports.API.Controllers
{
    [Authorize]
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

        [HttpGet]
        [Route("getByUser/{userId}")]
        public ActionResult<List<Sale>> GetByUser(Guid userId)
        {
            SaleUseCase service = CreateService();

            try
            {
                var sales = service.GetByUser(userId);

                if (sales == null || sales.Count == 0)
                {
                    return NotFound(new { message = "No sales found for this user." });
                }

                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getByState/{state}")]
        public ActionResult<List<Sale>> GetByState(StateType state)
        {
            SaleUseCase service = CreateService();

            try
            {
                var sales = service.GetByState(state);

                if (sales == null || sales.Count == 0)
                {
                    return NotFound(new { message = "No sales found for this state." });
                }

                return Ok(sales);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
