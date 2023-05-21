using System.Data;
using Customer.Business.Data.DAL;
using Customer.Business.Data.Model;

namespace Customer.Business.Data.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Domain.Entities.Customer>> GetCustomer();
        Task<string> AddCustomerDetail(Domain.Entities.Customer customerDetail);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public CustomerRepository(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public Task<string> AddCustomerDetail(Domain.Entities.Customer customerDetail)
        {
            List<InputParam> inputParams = new List<InputParam>()
            {
                new InputParam()
                {
                    Key = "Name",
                    Value = customerDetail.Name.ToString()
                },
                new InputParam()
                {
                    Key = "City",
                    Value = customerDetail.City.ToString()
                },
                new InputParam()
                {
                    Key = "Address",
                    Value = customerDetail.Address.ToString()
                },
                new InputParam()
                {
                    Key = "PhoneNumber",
                    Value = customerDetail.PhoneNumber.ToString()
                },
            };

            int count = _dataAccessLayer.InsertData("usp_InsertCustomerDetails", inputParams);
            string result = "Data inserted sucessfully";

            return Task.Run(() =>
                result
            );
        }

        public Task<List<Domain.Entities.Customer>> GetCustomer()
        {
            List<Domain.Entities.Customer> customerList = new List<Domain.Entities.Customer>();
            List<InputParam> inputParams = new List<InputParam>();

            DataTable dt = _dataAccessLayer.GetDataFromStoredProcedure("usp_GetCustomerDetails");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Domain.Entities.Customer customer = new Domain.Entities.Customer();
                customer.Id = (Guid)dt.Rows[i]["Id"];
                customer.Name = Convert.ToString(dt.Rows[i]["Name"]);
                customer.Address = Convert.ToString(dt.Rows[i]["Address"]);
                customer.City = Convert.ToString(dt.Rows[i]["City"]);
                customer.PhoneNumber = Convert.ToString(dt.Rows[i]["PhoneNumber"]);

                customerList.Add(customer);
            }

            return Task.FromResult(customerList);
        }
    }
}
