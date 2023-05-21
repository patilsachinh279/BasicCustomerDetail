using Customer.Business.Application.Feature.Customer.Command;
using Customer.Business.Application.Feature.Order.Command;
using Customer.Business.Tests.Application.Repository;

namespace Customer.Business.Tests.Application.Feature.Order.Command
{
    public class AddOrderHandlerTest
    {
        private readonly MockOrderRepository _mockOrderRepository;

        public AddOrderHandlerTest()
        {
            _mockOrderRepository= new MockOrderRepository();
            _mockOrderRepository.ArrageAddOrder();
        }

        [Fact]
        public void AddOrder_Success_Result()
        {
            //Arrange
            var orderRequest = new AddOrder
            {
                CustomerId = new Guid(),
                ProductName = "Test",
                PurchaseDate = DateTime.Now,
            };

            var handler = new AddOrderHandler(_mockOrderRepository.MockObject);

            //Act
            var result = handler.Handle(orderRequest, CancellationToken.None);

            //Assert
            Assert.Equal(result.Result, "Data inserted sucessfully");
        }
    }
}
