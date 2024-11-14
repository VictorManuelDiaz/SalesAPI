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

            var userState = db.States.Local.FirstOrDefault(s => s.state_id == commerce.User.state_id);
            if (userState == null)
            {
                userState = db.States.Find(commerce.User.state_id);
                if (userState != null)
                {
                    db.Entry(userState).State = EntityState.Unchanged;
                }
            }
            commerce.User.State = userState;

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
