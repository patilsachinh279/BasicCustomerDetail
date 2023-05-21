using Customer.Business.Application.Feature.Customer.Command;
using Customer.Business.Tests.Application.Repository;

namespace Customer.Business.Tests.Application.Feature.Customer.Command
{
    public class AddCustomerHandlerTest
    {
        private readonly MockCustomerRepository _mockCustomerRepository;

        public AddCustomerHandlerTest()
        {
            _mockCustomerRepository= new MockCustomerRepository();
            _mockCustomerRepository.ArrageAddCustomer();
        }

        [Fact]
        public void AddCustomer_Success_Result()
        {
            //Arrange
            var customerRequest = new AddCustomer
            {
                Address = "Pune, Maharashtra",
                City = "Pune",
                Name= "Sachin",
                PhoneNumber = "9960549863"
            };

            var handler = new AddCustomerHandler(_mockCustomerRepository.MockObject);

            //Act
            var result = handler.Handle(customerRequest, CancellationToken.None);

            //Assert
            Assert.Equal(result.Result, "Data inserted sucessfully");
        }
    }
}
