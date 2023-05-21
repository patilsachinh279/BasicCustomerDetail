namespace Customer.Business.Constant
{
    public class Routes
    {
        public const string RoutePrefix = "/api/customerapp";

        public class CustomerRoute
        {
            public const string ControllerName = $"{RoutePrefix}/customer";

            public const string GetCustomer = "";

            public const string AddCustomerDetail = $"{RoutePrefix}/customerdetail/addcustomer";
        }

        public class OrderRoute
        {
            public const string ControllerName = $"{RoutePrefix}/order";

            public const string GetOrder = "";

            public const string AddOrderDetail = $"{RoutePrefix}/orderdetail/addorder";
        }
    }
}
