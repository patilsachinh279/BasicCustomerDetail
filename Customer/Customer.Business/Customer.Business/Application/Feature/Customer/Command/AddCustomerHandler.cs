using MediatR;
using Customer.Business.Data.Repository;

namespace Customer.Business.Application.Feature.Customer.Command
{
    public class AddCustomerHandler : IRequestHandler<AddCustomer, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<string> Handle(AddCustomer request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer = new Domain.Entities.Customer
            {
                Address= request.Address,
                City= request.City,
                Name= request.Name,
                PhoneNumber= request.PhoneNumber,
            };

            return _customerRepository.AddCustomerDetail(customer);
        }
    }

    public class AddCustomer : IRequest<string>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
