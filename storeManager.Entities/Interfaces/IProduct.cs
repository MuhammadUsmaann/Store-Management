﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace storeManager.Entities.Interfaces
{
    public interface IProduct : IBaseEntity
    {
        decimal ItemPrice { get; }
        int ProdMeasurementID { get; }
    }
}
