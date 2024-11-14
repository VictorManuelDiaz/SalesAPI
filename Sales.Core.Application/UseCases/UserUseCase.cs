using System;
using System.Collections.Generic;
using System.Text;

using Sales.Core.Domain.Models;
using Sales.Core.Application.Interfaces;

using Sales.Core.Infraestructure.Repository.Concrete;

namespace Sales.Core.Application.UseCases
{
    public class UserUseCase : IBaseUseCase<User, Guid>
    {

        private readonly UserRepository repository;

        public UserUseCase(UserRepository repository)
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

        public List<User> GetByCommerce(Guid commerceId)
        {
            if (commerceId == Guid.Empty)
                throw new ArgumentException("Commerce ID cannot be empty.");

            var users = repository.GetByCommerce(commerceId);

            if (users == null || users.Count == 0)
                throw new Exception("No users found for the given commerce.");

            return users;
        }
    }
}

