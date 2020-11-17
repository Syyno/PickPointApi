using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PickPointAPI.Models;

namespace PickPointAPI.Services
{
    public interface IOrderOperations
    {
        void CreateOrder(OrderStore newOrder);
        void UpdateOrder(OrderStore newOrder);
        void CancelOrder(int orderId);
        bool IsOrderExists(int oderId);
        OrderStore GetOrder(int orderId);
        List<OrderStore> GetOrders();
    }
}
