using System.Data;
using Customer.Business.Data.DAL;
using Customer.Business.Data.Model;
using Customer.Business.Domain.Entities;

namespace Customer.Business.Data.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrder();
        Task<string> AddOrderDetail(Order orderDetail);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public OrderRepository(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer= dataAccessLayer;
        }

        public Task<string> AddOrderDetail(Order orderDetail)
        {
            List<InputParam> inputParams = new List<InputParam>()
            {
                new InputParam()
                {
                    Key = "CustomerId",
                    Value = orderDetail.CustomerId.ToString()
                },
                new InputParam()
                {
                    Key = "ProductName",
                    Value = orderDetail.ProductName.ToString()
                },
                new InputParam()
                {
                    Key = "PurchaseDate",
                    Value = orderDetail.PurchaseDate.ToString()
                },
            };

            int count = _dataAccessLayer.InsertData("usp_InsertOrderDetails", inputParams);
            string result = "Data inserted sucessfully";

            return Task.Run(() =>
                result
            );
        }

        public Task<List<Order>> GetOrder()
        {
            List<Order> orderList = new List<Order>();

            DataTable dt = _dataAccessLayer.GetDataFromStoredProcedure("usp_GetOrderDetails");
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                Order order = new Order();
                order.Id = (Guid) dt.Rows[i]["Id"];
                order.CustomerId = (Guid)dt.Rows[i]["CustomerId"];
                order.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                order.PurchaseDate = Convert.ToDateTime(dt.Rows[i]["PurchaseDate"]);

                orderList.Add(order);
            }

            return Task.FromResult(orderList);
        }
    }
}
