﻿using System;
using Sales.Core.Domain.Models;
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
                throw new Exception("Error. The commerce cannot be null");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }
    }
}
