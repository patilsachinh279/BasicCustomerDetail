using Customer.Business.Application.Feature.Building.Shared;
using Customer.Business.Application.Feature.Order.Command;
using Customer.Business.Constant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.WebApi.Controllers
{
    [Route(Routes.OrderRoute.ControllerName)]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.OrderRoute.GetOrder)]
        public Task<List<Business.Domain.Entities.Order>> GetOrders()
        {
            return _mediator.Send(new OrderRequest());
        }

        [HttpPost(Routes.OrderRoute.AddOrderDetail)]
        public Task<string> AddOrderDetail([FromBody] AddOrder request)
        {
            return _mediator.Send(request);
        }
    }
}
