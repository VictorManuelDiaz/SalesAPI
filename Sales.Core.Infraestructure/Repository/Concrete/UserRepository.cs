using System;
using System.Collections.Generic;
using System.Text;

using Sales.Core.Domain.Models;
using Sales.Core.Infraestructure.Repository.Abstract;
using Sales.Adapters.SQLDataAccess.Contexts;
using System.Linq;

namespace Sales.Core.Infraestructure.Repository.Concrete
{
    public class UserRepository : IBaseRepository<User, Guid>
    {
        private SalesDB db;
        public UserRepository(SalesDB db)
        {
            this.db = db;
        }
        public User Create(User user)
        {
            user.user_id = Guid.NewGuid();
            //Define nuevo identificador único
            db.Users.Add(user);
            return user;
        }

        public void Delete(Guid entityId)
        {
            var selectedUser = db.Users
                .Where(u => u.user_id == entityId).FirstOrDefault();
            //Selecciona el usuario a través del Id
            if (selectedUser != null)
            //Verifica si el usuario existe
                db.Users.Remove(selectedUser);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(Guid entityId)
        {
            var selectedUser = db.Users
                .Where(u => u.user_id == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public User Update(User user)
        {
            var selectedUser = db.Users
                .Where(u => u.user_id == user.user_id)
                .FirstOrDefault();
            //Selecciona el usuario por Id desde la BD
            if (selectedUser != null)
                //Verifica que el usuario existe
            {
                selectedUser.name = user.name;
                selectedUser.password = user.password;
                selectedUser.role = user.role;
                selectedUser.state_id = user.state_id;
                selectedUser.updated_at = DateTime.Now;
                //Modifica los datos del usuario con los valores del parámetro

                db.Entry(selectedUser).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedUser;
        }
    }
}


