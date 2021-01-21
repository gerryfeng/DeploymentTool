using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Data;

namespace Identity.ApplicationCore
{
    public class DBService : IDBService
    {
        private readonly ILogger<DBService> _logger;

        public DBService(ILogger<DBService> logger)
        {
            _logger = logger;
        }

        public bool ConnectionTest(string ip, string dbName, string userName, string password, out string errMsg)
        {
            DataTable dt = new DataTable();
            errMsg = "";
            try
            {
                ip = ip.Trim();
                dbName = dbName.Trim();
                userName = userName.Trim();
                password = password.Trim();

                using (SqlConnection connection = new SqlConnection("server=" + ip + ";database='" + dbName + "';User id=" + userName + ";password=" + password + ";Integrated Security=false"))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT Name FROM SysObjects Where XType='U' ORDER BY Name";
                        command.CommandTimeout = 10;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);

                        command.Dispose();
                    }

                    connection.Close();
                    connection.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
    }
}
