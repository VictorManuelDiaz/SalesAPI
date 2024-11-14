using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Sales.Core.Application.Interfaces;
using Sales.Core.Domain.Models;
using Sales.Core.Infraestructure.Repository.Abstract;

namespace Sales.Core.Application.UseCases
{
    public class AuthUseCase : IAuthUseCase
    {
        private readonly IAuthRepository<User, string> repository;
        public AuthUseCase(IAuthRepository<User, string> repository)
        {
            this.repository = repository;
        }
        public string Login(User user, string key)
        {
            var currentUser = repository.Login(user);
            if (currentUser == null)
            {
                return null;
            }
            var token = repository.GetToken(user, key);
            string result = JsonConvert.SerializeObject(new { token });
            return result;
        }
    }
}


