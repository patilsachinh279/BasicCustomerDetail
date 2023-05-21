using MediatR;

namespace Customer.Business.Application.Feature.Building.Shared
{
    public class OrderRequest : IRequest<List<Domain.Entities.Order>>
    {
    }
}
