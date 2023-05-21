using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Customer.Business.Data.Model;

namespace Customer.Business.Data.DAL
{
    public interface IDataAccessLayer
    {
        public DataTable GetDataFromStoredProcedure(string procedureName, List<InputParam> inputParams = null);
        public int InsertData(string procedureName, List<InputParam> inputParams);
    }

    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly IConfiguration _configuration;
        SqlConnection Conn;
        SqlDataAdapter DA = new SqlDataAdapter();
        SqlCommandBuilder CB;
        DataTable DT;

        public DataAccessLayer(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public string DatabaseConnectionString =>
            _configuration.GetConnectionString("DbContext");

        public SqlConnection OpenConnection()
        {
            //TODO: Connection sring from appsetting.json file
            Conn = new SqlConnection("data source=IND-L490;initial catalog=Customer;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True");
            return Conn;
        }

        public DataTable GetDataFromStoredProcedure(string procedureName, List<InputParam> inputParams = null)
        {
            Conn = OpenConnection();
            SqlCommand cm = new SqlCommand(procedureName, Conn);
            cm.CommandType = CommandType.StoredProcedure;
            
            if(inputParams != null)
            {
                foreach(var item in inputParams)
                {
                    cm.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            DA.SelectCommand = cm;
            DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }

        public int InsertData(string procedureName, List<InputParam> inputParams)
        {
            Conn = OpenConnection();
            SqlCommand cm = new SqlCommand(procedureName, Conn);
            cm.CommandType = CommandType.StoredProcedure;

            if (inputParams != null)
            {
                foreach (var item in inputParams)
                {
                    cm.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            Conn.Open();
            int count = cm.ExecuteNonQuery();
            Conn.Close();
            return count;
        }
    }
}
