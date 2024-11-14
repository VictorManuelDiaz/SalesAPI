using System;
using System.Collections.Generic;
using System.Text;

using Sales.Core.Domain.Models;
using Sales.Core.Application.Interfaces;

using Sales.Core.Infraestructure.Repository.Concrete;

namespace Sales.Core.Application.UseCases
{
    public class CommerceUseCase
    {
        private readonly CommerceRepository repository;

        public CommerceUseCase(CommerceRepository repository)
        {
            this.repository = repository;
        }

        public Commerce Create(Commerce entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El comercio no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }
    }
}
