using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Models;

namespace PickPointAPI.Util
{
    public class OrdersStorage
    {
        public List<OrderStore> Orders { get; private set; } = new List<OrderStore>();

        public OrdersStorage()
        {
           Orders.GetInitialOrders();
        }
    }
}
