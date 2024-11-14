using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Core.Domain.Interfaces
{
    public interface IUpdate<Entity>
    {
        Entity Update(Entity entity);
    }
}
