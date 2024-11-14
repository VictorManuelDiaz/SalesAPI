using System;

using Sales.Core.Domain.Models;
using Sales.Adapters.SQLDataAccess.Contexts;
using System.Linq;

namespace Sales.Core.Infraestructure.Repository.Concrete
{
    public class CommerceRepository
    {
        private SalesDB db;
        public CommerceRepository(SalesDB db)
        {
            this.db = db;
        }

        public Commerce Create(Commerce commerce)
        {
            commerce.commerce_id = Guid.NewGuid();
            commerce.created_at = DateTime.Now;
            commerce.updated_at = DateTime.Now;
            db.Commerces.Add(commerce);
            return commerce;
        }

        public void Delete(Guid commerceId)
        {
            var selectedCommerce = db.Commerces
               .Where(c => c.commerce_id == commerceId).FirstOrDefault();
            
            if (selectedCommerce != null)
                db.Commerces.Remove(selectedCommerce);
        }

    
        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
