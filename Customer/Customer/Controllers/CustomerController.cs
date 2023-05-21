using Customer.Business.Application.Feature.Apartment.Shared;
using Customer.Business.Application.Feature.Customer.Command;
using Customer.Business.Constant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.WebApi.Controllers
{
    [Route(Routes.CustomerRoute.ControllerName)]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.CustomerRoute.GetCustomer)]
        public Task<List<Business.Domain.Entities.Customer>> GetCustomers()
        {
            return _mediator.Send(new CustomerRequest());
        }

        [HttpPost(Routes.CustomerRoute.AddCustomerDetail)]
        public Task<string> AddGuestDetail([FromBody] AddCustomer request)
        {
            return _mediator.Send(request);
        }
    }
}
