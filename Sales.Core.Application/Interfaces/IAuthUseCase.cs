using System;
using System.Collections.Generic;
using System.Text;
using Sales.Core.Domain.Models;

namespace Sales.Core.Application.Interfaces
{
    public interface IAuthUseCase
    {
        string Login(User user, string key);
    }
}





