using MediatR;
using Customer.Business.Application.Feature.Building.Shared;
using Customer.Business.Data.Repository;

namespace Customer.Business.Application.Feature.Building.Query
{
    public class GetOrderHandler : IRequestHandler<OrderRequest, List<Domain.Entities.Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Domain.Entities.Order>> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrder();
        }
    }
}
