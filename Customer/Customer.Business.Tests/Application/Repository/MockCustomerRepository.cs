using Customer.Business.Data.Repository;
using Moq;

namespace Customer.Business.Tests.Application.Repository
{
    public class MockCustomerRepository
    {
        public Mock<ICustomerRepository> mockRepo;

        public ICustomerRepository MockObject { get { return mockRepo.Object; } }

        public MockCustomerRepository()
        {
            mockRepo= new Mock<ICustomerRepository>();
        }

        #region Mock Data
        public List<Domain.Entities.Customer> GetCustomer()
        {
            var cust = new List<Domain.Entities.Customer>();
            cust.Add(new Domain.Entities.Customer 
            {
                Address = "Pune, Maharashtra",
                City = "Pune",
                Id  = new Guid(),
                Name= "Sachin Patil",
                PhoneNumber = "9960549863"
            }); 

            return cust;
        }
        #endregion

        #region Mock Methods
        public void ArrageGetCustomer() => mockRepo.Setup(x => x.GetCustomer()).ReturnsAsync(GetCustomer());

        public void ArrageAddCustomer() => mockRepo.Setup(x => x.AddCustomerDetail(It.IsAny<Domain.Entities.Customer>())).ReturnsAsync("Data inserted sucessfully");
        #endregion
    }
}
