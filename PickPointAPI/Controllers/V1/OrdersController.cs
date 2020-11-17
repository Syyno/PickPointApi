using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PickPointAPI.Models;
using PickPointAPI.Models.DTO.Order_DTO_s;
using PickPointAPI.Services;
using PickPointAPI.Util;

namespace PickPointAPI.Controllers
{
    //Реализовать операции: создание заказа, получение информации о заказе(tracking), обновление информации о заказе, отмена заказа.

    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataManager _repository;
        private readonly IMapper _mapper;

        public OrdersController(DataManager repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Orders.GetAll)]
        public IActionResult GetOrders() //получить список заказов
        {
            List<OrderReturn> ordersToReturn = new List<OrderReturn>();
            foreach (var oderToStore in _repository.Orders.GetOrders())
            {
                ordersToReturn.Add(_mapper.Map<OrderReturn>(oderToStore));
            }
            return Ok(ordersToReturn);
        }

        [HttpPost(ApiRoutes.Orders.Create,Name = "CreateOrder")]
        public IActionResult CreateOrder(OrderCreate orderToCreate) //создание заказа
        {
            if (ModelState.IsValid)
            {
                if (!_repository.Orders.IsOrderExists(orderToCreate.Number))
                {
                    if (_repository.Postamats.IsPostamatExists(orderToCreate.PostamatNumber) &&
                        _repository.Postamats.IsPostamatActive(orderToCreate.PostamatNumber))
                    {
                        OrderStore orderToStore = _mapper.Map<OrderStore>(orderToCreate);
                        _repository.Orders.CreateOrder(orderToStore);
                        return NoContent();
                    }
                    return StatusCode(403);
                }
            }
            return BadRequest();

        }

        [HttpGet(ApiRoutes.Orders.Get, Name = "GetOrder")]
        public IActionResult GetOrder(int orderId) //получение информации о заказе
        {
            if (_repository.Orders.IsOrderExists(orderId))
            {
                OrderStore orderFromStore = _repository.Orders.GetOrder(orderId);
                OrderReturn orderToReturn = _mapper.Map<OrderReturn>(orderFromStore);
                return Ok(orderToReturn);
            } 
            return NotFound();
        }

        [HttpPatch(ApiRoutes.Orders.Update, Name = "UpdateOrderPatch")]
        public IActionResult UpdateOrderPatch(int orderId, JsonPatchDocument<OrderUpdate> patcher) //частичное обновление заказа
        {
            if (_repository.Orders.IsOrderExists(orderId))
            {
                OrderStore orderFromStore = _repository.Orders.GetOrder(orderId);
                OrderUpdate orderToPatch = _mapper.Map<OrderUpdate>(orderFromStore);
                patcher.ApplyTo(orderToPatch, ModelState);

                if (!TryValidateModel(orderToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(orderToPatch, orderFromStore);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut(ApiRoutes.Orders.Update, Name = "UpdateOrderPut")]
        public IActionResult UpdateOrderPut(OrderUpdate orderUpdate) //полное обновление заказа
        {
            if (_repository.Orders.IsOrderExists(orderUpdate.Number))
            {
                OrderStore orderFromStore = _repository.Orders.GetOrder(orderUpdate.Number);
                _mapper.Map(orderUpdate, orderFromStore);
                _repository.Orders.UpdateOrder(orderFromStore);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Orders.Delete, Name = "CancelOrder")]
        public IActionResult CancelOrder(int orderId) //отмена заказа
        {
            if (_repository.Orders.IsOrderExists(orderId))
            {
                _repository.Orders.CancelOrder(orderId);
                return NoContent();
            }
            return NotFound();
        }
    }
}
