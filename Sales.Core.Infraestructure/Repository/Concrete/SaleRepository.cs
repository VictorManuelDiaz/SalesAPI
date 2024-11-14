using System;
using Sales.Core.Domain.Models;
using Sales.Adapters.SQLDataAccess.Contexts;
using System.Linq;
using System.Collections.Generic;
using Sales.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Sales.Core.Infraestructure.Repository.Concrete
{
    public class SaleRepository
    {
        private SalesDB db;
        public SaleRepository(SalesDB db)
        {
            this.db = db;
        }

        public Sale Create(Sale sale)
        {
            sale.sale_id = Guid.NewGuid();
            sale.created_at = DateTime.UtcNow;
            sale.updated_at = DateTime.UtcNow;

            db.Sales.Add(sale);
            return sale;
        }

        public List<Sale> GetByUser(Guid userId)
        {
            var sales = db.Sales
                .Where(s => s.user_id == userId)
                .Include(s => s.User)
                .Include(s => s.Commerce)
                .Include(s => s.State)
                .Include(s => s.SaleDetails)
                .ToList();
            return sales;
        }

        private bool StateExists(StateType state)
        {
            return db.States
                .Any(s => s.name == state);
        }

        public List<Sale> GetByState(StateType state)
        {
            if (!StateExists(state))
            {
                throw new ArgumentException($"State {state} does not exist in the database.");
            }

            var sales = db.Sales
                .Where(s => s.State.name == state)
                .Include(s => s.User)
                .Include(s => s.Commerce)
                .Include(s => s.State)
                .Include(s => s.SaleDetails)
                .ToList();

            return sales;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}


