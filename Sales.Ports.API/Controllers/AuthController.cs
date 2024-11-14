using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;

using Microsoft.AspNetCore.Authorization;
using Sales.Adapters.SQLDataAccess.Contexts;
using Sales.Core.Infraestructure.Repository.Concrete;
using Sales.Core.Application.UseCases;
using Sales.Core.Domain.Models;
using Newtonsoft.Json;

namespace Sales.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly IConfiguration configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration;
        }
        public AuthUseCase CreateService()
        {
            SalesDB db = new SalesDB();
            //Instanciando el contexto
            AuthRepository repository = new AuthRepository(db);
            AuthUseCase service = new AuthUseCase(repository);
            return service;
        }

        [AllowAnonymous]
        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Running" };
            logger.LogInformation($"Status: {responseObject.Status}");

            return responseObject;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] User user)
        {
            AuthUseCase service = CreateService();
            var auth = service.Login(user, configuration["JWT:Secret"]);

            if (auth == null)
            {
                return Unauthorized();
            }

            return Ok(JsonConvert.DeserializeObject(auth));
        }
    }
}
