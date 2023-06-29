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
        const string connectionString = "ConnectionString";

        public DataAccessLayer(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public SqlConnection OpenConnection()
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", false)
                    .Build();

            var connectionString = config.GetConnectionString("CustomerContext");

            Conn = new SqlConnection(connectionString);
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
