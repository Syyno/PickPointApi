using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PickPointAPI.Models;
using PickPointAPI.Util;

namespace PickPointAPI.Services
{
    public class OrderOperations : IOrderOperations
    {
        private readonly List<OrderStore> _orders;

        public OrderOperations(OrdersStorage orders)
        {
            _orders = orders.Orders;
        }

        public void CreateOrder(OrderStore newOrder)
        {
            _orders.Add(newOrder);
        }

        public void UpdateOrder(OrderStore newOrder)
        {
           OrderStore oldOrder = _orders.FirstOrDefault(o => o.Number == newOrder.Number);
           oldOrder = newOrder;
        }

        public void CancelOrder(int orderId)
        {
            OrderStore orderToRemove = _orders.FirstOrDefault(o => o.Number == orderId);
            _orders.Remove(orderToRemove);
        }

        public bool IsOrderExists(int oderId)
        {
            return _orders.Any(o => o.Number == oderId);
        }

        public OrderStore GetOrder(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Number == orderId);
        }

        public List<OrderStore> GetOrders()
        {
            return _orders;
        }
    }
}
