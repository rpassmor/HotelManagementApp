using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            CommandType commandType = CommandType.Text;
            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sql, parameters, commandType: commandType).ToList();
                return rows;
            }
        }
        public void SaveData<T>(string sql, T parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            CommandType commandType = CommandType.Text;
            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            string connectionString = _config.GetConnectionString(connectionStringName);
            using (IDbConnection connections = new SqlConnection(connectionString))
            {
                connections.Execute(sql, parameters, commandType: commandType);
            }
        }
    }
}
