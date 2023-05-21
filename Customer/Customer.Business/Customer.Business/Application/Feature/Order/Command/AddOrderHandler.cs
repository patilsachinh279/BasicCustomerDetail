using Customer.Business.Data.Repository;
using MediatR;

namespace Customer.Business.Application.Feature.Order.Command
{
    public class AddOrderHandler : IRequestHandler<AddOrder, string>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<string> Handle(AddOrder request, CancellationToken cancellationToken)
        {
            Domain.Entities.Order order = new Domain.Entities.Order
            {
                CustomerId= request.CustomerId,
                ProductName= request.ProductName,
                PurchaseDate= request.PurchaseDate,
            };

            return _orderRepository.AddOrderDetail(order);
        }
    }

    public class AddOrder :  IRequest<string>
    {
        public Guid? CustomerId { get; set; }
        public string? ProductName { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
