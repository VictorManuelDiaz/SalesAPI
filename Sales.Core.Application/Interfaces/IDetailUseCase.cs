using System;
using System.Collections.Generic;
using System.Text;

using Sales.Core.Domain.Interfaces;

namespace Sales.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}

