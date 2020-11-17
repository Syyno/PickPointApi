using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickPointAPI.Models
{
    public enum OrderStatus 
    {
        Registered = 1,
        InStock,
        IssuedToCourier,
        DeliveredToPostamat,
        DeliveredToCustomer,
        Cancelled
    }
}
