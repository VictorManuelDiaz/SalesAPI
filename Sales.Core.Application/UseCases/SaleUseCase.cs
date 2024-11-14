using System;
using Sales.Core.Domain.Models;
using Sales.Core.Infraestructure.Repository.Concrete;

namespace Sales.Core.Application.UseCases
{
    public class SaleUseCase
    {
        private readonly SaleRepository repository;

        public SaleUseCase(SaleRepository repository)
        {
            this.repository = repository;
        }

        public Sale Create(Sale entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. The sale cannot be null");
        }
    }
}
