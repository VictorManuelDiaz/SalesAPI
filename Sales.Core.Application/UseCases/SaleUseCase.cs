using System;
using System.Collections.Generic;
using Sales.Core.Domain.Enums;
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

        public List<Sale> GetByUser(Guid userId)
        {
            try
            {
                var sales = repository.GetByUser(userId);

                if (sales == null || sales.Count == 0)
                {
                    Console.WriteLine("No sales found for the specified user.");
                    return new List<Sale>();
                }

                return sales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Sale>();
            }
        }

        public List<Sale> GetByState(StateType saleState)
        {
            try
            {
                var sales = repository.GetByState(saleState);
                return sales;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Sale>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<Sale>();
            }
        }
    }
}
