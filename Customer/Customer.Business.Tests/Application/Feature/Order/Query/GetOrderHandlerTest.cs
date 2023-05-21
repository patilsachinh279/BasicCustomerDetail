using Customer.Business.Application.Feature.Building.Query;
using Customer.Business.Application.Feature.Building.Shared;
using Customer.Business.Tests.Application.Repository;

namespace Customer.Business.Tests.Application.Feature.Order.Query
{
    public class GetOrderHandlerTest
    {
        private readonly MockOrderRepository _mockOrderRepository;

        public GetOrderHandlerTest() => _mockOrderRepository = new MockOrderRepository();

        [Fact]
        public void GetOrder_Success_Result()
        {
            //Arrange 
            var handler = new GetOrderHandler(_mockOrderRepository.MockObject);
            _mockOrderRepository.ArrageGetOrder();

            //Act
            var result = handler.Handle(new OrderRequest { }, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
        }
    }
}
