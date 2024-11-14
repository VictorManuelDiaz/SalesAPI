using System;

using Sales.Core.Domain.Models;
using Sales.Adapters.SQLDataAccess.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sales.Core.Domain.Enums;

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
            Guid activeStateId = GetActiveStateId();

            commerce.commerce_id = Guid.NewGuid();
            commerce.created_at = DateTime.UtcNow;
            commerce.updated_at = DateTime.UtcNow;

            commerce.state_id = activeStateId;

            if (commerce.Users != null && commerce.Users.Count > 0)
            {
                foreach (var user in commerce.Users)
                {
                    user.user_id = Guid.NewGuid();
                    user.role = RoleType.Owner;
                    user.state_id = activeStateId;
                    user.created_at = DateTime.UtcNow;
                    user.updated_at = DateTime.UtcNow;
                }

                db.Users.AddRange(commerce.Users);
            }

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

        private Guid GetActiveStateId()
        {
            var activeState = db.States.FirstOrDefault(s => s.name == StateType.Active);
            return activeState != null ? activeState.state_id : Guid.Empty;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
