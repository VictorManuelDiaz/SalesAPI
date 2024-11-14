using Microsoft.AspNetCore.Mvc;

using Sales.Adapters.SQLDataAccess.Contexts;
using Sales.Core.Application.UseCases;
using Sales.Core.Infraestructure.Repository.Concrete;

using Sales.Core.Domain.Models;
using System.Collections.Generic;
using System;

namespace Sales.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserUseCase CreateService()
        {
            SalesDB db = new SalesDB();
            //Instanciando el contexto
            UserRepository repository = new UserRepository(db);
            //Llamando al repositorio concreto y mandando como argumento el contexto
            UserUseCase service = new UserUseCase(repository);
            //Definiendo el servicio y pasando como parámetro el repositorio

            return service;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            UserUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            UserUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            UserUseCase service = CreateService();

            var result = service.Create(user);

            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] User user)
        {
            UserUseCase service = CreateService();
            user.user_id = id;
            service.Update(user);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UserUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}


