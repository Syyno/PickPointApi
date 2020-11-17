using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickPointAPI.Models;

namespace PickPointAPI.Util
{
    public static class AddDataToOrders
    {
        public static void GetInitialOrders(this List<OrderStore> orders)
        {
            orders.AddRange(new List<OrderStore>()
            {
                new OrderStore((int)OrderStatus.IssuedToCourier)
                {
                    Number = 1,  
                    Content = new string[] {"item1", "item2", "item3"},
                    Cost = 100,
                    CustomerFullName = "Brenden Mckay",
                    CustomerTelephoneNumber = "+7999-111-11-11",
                    PostamatNumber = 1
                },
                new OrderStore((int)OrderStatus.DeliveredToPostamat)
                {
                    Number = 2, 
                    Content = new string[] {"item1", "item2", "item3", "item4", "item5"},
                    Cost = 200,
                    CustomerFullName = "Marvin Wallis",
                    CustomerTelephoneNumber = "+7999-222-22-22",
                    PostamatNumber = 2
                },
                new OrderStore((int)OrderStatus.InStock)
                {
                    Number = 3, 
                    Content = new string[] {"item1"},
                    Cost = 555.55m,
                    CustomerFullName = "Delilah Fitzgerald",
                    CustomerTelephoneNumber = "+7999-333-33-33",
                    PostamatNumber = 2
                }
            });
           
        }
    }
}
