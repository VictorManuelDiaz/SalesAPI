﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Core.Domain.Interfaces
{
    public interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}