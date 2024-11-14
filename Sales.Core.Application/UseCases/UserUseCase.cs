using System;
using System.Collections.Generic;
using System.Text;

using Sales.Core.Domain.Models;
using Sales.Core.Application.Interfaces;

using Sales.Core.Infraestructure.Repository.Abstract;

namespace Sales.Core.Application.UseCases
{
    public class UserUseCase : IBaseUseCase<User, Guid>
    {

        private readonly IBaseRepository<User, Guid> repository;

        public UserUseCase(IBaseRepository<User, Guid> repository)
        {
            this.repository = repository;
        }

        public User Create(User entity)
        {
            if (entity != null)
                //Verifica que el objeto sea válido
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                //Devuelve nueva excepción en caso de error
                throw new Exception("Error. El usuario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<User> GetAll()
        {
            return repository.GetAll();
        }

        public User GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public User Update(User entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}

