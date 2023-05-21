using Customer.Business.Application.Feature.Apartment.Query;
using Customer.Business.Tests.Application.Repository;

namespace Customer.Business.Tests.Application.Feature.Customer.Query
{
    public class GetCustomerHandlerTest
    {
        private readonly MockCustomerRepository _mockCustomerRepository;

        public GetCustomerHandlerTest() => _mockCustomerRepository = new MockCustomerRepository();

        [Fact]
        public void GetCustomer_Success_Result()
        {
            //Arrange 
            var handler = new GetCustomerHandler(_mockCustomerRepository.MockObject);
            _mockCustomerRepository.ArrageGetCustomer();

            //Act
            var result = handler.Handle(new Business.Application.Feature.Apartment.Shared.CustomerRequest { }, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
        }
    }
}
