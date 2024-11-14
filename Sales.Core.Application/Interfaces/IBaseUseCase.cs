using System;
using System.Collections.Generic;
using System.Text;

using Sales.Core.Domain.Interfaces;

namespace Sales.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {
    }
}

