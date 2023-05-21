using MediatR;

namespace Customer.Business.Application.Feature.Apartment.Shared
{
    public class CustomerRequest : IRequest<List<Domain.Entities.Customer>>
    {
    }
}
