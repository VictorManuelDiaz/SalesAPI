using System;

using Sales.Core.Domain.Models;
using Sales.Adapters.SQLDataAccess.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            commerce.created_at = DateTime.UtcNow;
            commerce.updated_at = DateTime.UtcNow;

            var user = commerce.User;
            user.user_id = Guid.NewGuid();
            commerce.User = user;

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
