using MediatR;
using Customer.Business.Application.Feature.Apartment.Shared;
using Customer.Business.Data.Repository;

namespace Customer.Business.Application.Feature.Apartment.Query
{
    public class GetCustomerHandler : IRequestHandler<CustomerRequest, List<Domain.Entities.Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<Domain.Entities.Customer>> Handle(CustomerRequest request, CancellationToken cancellationToken)
        {
            return _customerRepository.GetCustomer();
        }
    }
}
