using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using BloodInNeed.Data.Models;

namespace BloodInNeed.Data.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        private string _connString;

        //public SqlDataAccess()

        //{
        //}

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
            this._connString = _config.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "DefaultConnection")
        {

            // Get the connection string from configuration
            string connectionString = this._connString;

            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }


        //public async Task SaveData<T>(string spName, T parameters)
        //{
        //    using(var connection = OpenConnection())
        //     await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        //}


        private IDbConnection OpenConnection()
        {
            var test = this._connString;
            return new SqlConnection(this._connString);
        }

        public IEnumerable<T> ExecuteAsList<T>(string query, DynamicParameters p = null)
        {
            string connectionString = this._connString;

            using (var con = OpenConnection())
            {
                return con.Query<T>(query, p, commandType: CommandType.StoredProcedure, commandTimeout: 240);
            }
        }

        public T ExecuteAsObject<T>(string query, DynamicParameters p = null)
        {
            using (var con = OpenConnection())
            {
                return con.QuerySingleOrDefault<T>(query, p, commandType: CommandType.StoredProcedure, commandTimeout: 240);
            }
        }

        public int ExecuteNonQuery(string query, DynamicParameters p = null)
        {
            using (var con = OpenConnection())
            {
                return con.Execute(query, p, commandType: CommandType.StoredProcedure, commandTimeout: 240);
            }
        }

        public DbMessage ExecuteNonQueryResult(string query, DynamicParameters p = null)
        {
            using (var con = OpenConnection())
            {
                con.Execute(query, p, commandType: CommandType.StoredProcedure, commandTimeout: 240);
                return new DbMessage
                {
                    MsgType = p.Get<string>("@MsgType"),
                    Msg = p.Get<string>("@Msg")
                };
            }
        }

        //public BossDataReader ExecuteMultiple(string query, DynamicParameters p = null)
        //{
        //    var con = OpenConnection();
        //    var reader = con.QueryMultiple(query, p, commandType: CommandType.StoredProcedure, commandTimeout: 240);

        //    return new BossDataReader
        //    {
        //        Reader = reader,
        //        Connection = con
        //    };
        //}

        //public DbMessage BulkInsert<T1>(IEnumerable<T1> data, string tableName, int batchSize, int timeout, params string[] columns)
        //{
        //    var con = OpenConnection();

        //    try
        //    {
        //        con.Open();
        //        using (var bulkCopy = new SqlBulkCopy(_connString))
        //        {
        //            using (var reader = ObjectReader.Create(data, columns))
        //            {
        //                bulkCopy.DestinationTableName = tableName;
        //                bulkCopy.BulkCopyTimeout = timeout;
        //                bulkCopy.BatchSize = batchSize;

        //                bulkCopy.WriteToServer(reader);
        //            }
        //        }

        //        if (con.State == ConnectionState.Open)
        //            con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (con.State == ConnectionState.Open)
        //            con.Close();

        //        throw ex;
        //    }

        //    return new DbMessage
        //    {
        //        MsgType = "success",
        //        Msg = "Bulk copy successfull",
        //    };
        //}



    }
}
