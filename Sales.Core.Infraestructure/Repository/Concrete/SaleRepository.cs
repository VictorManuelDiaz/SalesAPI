using System;
using Sales.Core.Domain.Models;
using Sales.Adapters.SQLDataAccess.Contexts;

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

            db.Sales.Add(sale);
            return sale;
        }
       
        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}


