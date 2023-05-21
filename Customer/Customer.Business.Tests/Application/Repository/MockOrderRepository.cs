using Customer.Business.Data.Repository;
using Moq;

namespace Customer.Business.Tests.Application.Repository
{
    public class MockOrderRepository
    {
        public Mock<IOrderRepository> mockRepo;

        public IOrderRepository MockObject { get { return mockRepo.Object; } }

        public MockOrderRepository()
        {
            mockRepo = new Mock<IOrderRepository>();
        }

        #region Mock Data
        public List<Domain.Entities.Order> GetOrder()
        {
            var order = new List<Domain.Entities.Order>();
            order.Add(new Domain.Entities.Order
            {
                CustomerId = new Guid(),
                Id = new Guid(),
                ProductName = "Test",
                PurchaseDate = new DateTime()
            });

            return order;
        }
        #endregion

        #region Mock Methods
        public void ArrageGetOrder() => mockRepo.Setup(x => x.GetOrder()).ReturnsAsync(GetOrder());

        public void ArrageAddOrder() => mockRepo.Setup(x => x.AddOrderDetail(It.IsAny<Domain.Entities.Order>())).ReturnsAsync("Data inserted sucessfully");
        #endregion
    }
}
