using Core.Services.Orders;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Orders;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _createOrderService.Create(orderId, model.Address, model.Products);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _updateOrderService.Update(order, model.Address, model.Products);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, [FromBody] OrderModel model)
        {
            var orders = _getOrderService.GetList(model.Address, model.Products)
                                       .Skip(skip).Take(take)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(orders);
        }

        //[Route("clear")]
        //[HttpDelete]
        //public HttpResponseMessage DeleteAllOrders()
        //{
        //    _deleteOrderService.DeleteAll();
        //    return Found();
        //}
    }
}