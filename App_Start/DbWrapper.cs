using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace HPCL_DP_Terminal.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbWrapper
    {
        public static async Task<DataSet> ExecuteSP(string spName, Dictionary<string, object> keyValues)
        {           

            try
            {                
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                    {
                        using (SqlCommand cmd = new SqlCommand(spName, con))
                        {
                            foreach (KeyValuePair<string, object> keyVal in keyValues)
                            {
                                if (!string.IsNullOrWhiteSpace(keyVal.Key))
                                    cmd.Parameters.AddWithValue("@" + keyVal.Key, keyVal.Value);
                            }
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;

                            DataSet ds = new DataSet();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                await Task.Run(() => da.Fill(ds));
                            }

                            return ds;
                        }
                    }

                
            }
            catch (Exception ex)
            {
                throw (new Exception("Error in sp: " + spName + " Detail: " + ex.Message.ToString()));
            }

        }

        public static async Task<int> ExecuteNonquerySP(string spName, Dictionary<string, object> keyValues)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        foreach (KeyValuePair<string, object> keyVal in keyValues)
                        {
                            if (!string.IsNullOrWhiteSpace(keyVal.Key))
                                cmd.Parameters.AddWithValue("@" + keyVal.Key, keyVal.Value);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        await con.OpenAsync();
                        int flag = await cmd.ExecuteNonQueryAsync();

                        return flag;
                    }
                }

            }
            catch (Exception ex)
            {
                throw (new Exception("Error in sp : " + spName + " Detail: " + ex.Message.ToString()));
            }
        }
    }
       

    public class DefaultContext : DbContext
    {
        public DefaultContext() : base("name=DefaultConnection")
        {

        }
    }

    public static class MultipleResultSets
    {
        public static MultipleResultSetWrapper MultipleResults(this DbContext db,string spname, Dictionary<string, object> keyValues)
        {
            var command = new SqlCommand()
            {
                CommandText = spname,
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0                
            };

            foreach (KeyValuePair<string, object> keyVal in keyValues)
            {
                if (!string.IsNullOrWhiteSpace(keyVal.Key))
                    command.Parameters.AddWithValue("@" + keyVal.Key, keyVal.Value);
            }

            return new MultipleResultSetWrapper(db, command);
        }

        public class MultipleResultSetWrapper
        {
            private readonly DbContext _db;
            private readonly SqlCommand _storedProcedure;
            public List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>> _resultSets;

            public MultipleResultSetWrapper(DbContext db, SqlCommand storedProcedure)
            {
                _db = db;
                _storedProcedure = storedProcedure;
                _resultSets = new List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>>();
            }

            public MultipleResultSetWrapper With<TResult>()
            {
                _resultSets.Add((adapter, reader) => adapter
                    .ObjectContext
                    .Translate<TResult>(reader)
                    .ToList());

                return this;
            }

            public List<IEnumerable> Execute()
            {
                var results = new List<IEnumerable>();

                using (var connection = _db.Database.Connection)
                {
                    connection.Open();
                    _storedProcedure.Connection = (SqlConnection)connection;
                    using (var reader = _storedProcedure.ExecuteReader())
                    {
                        var adapter = ((IObjectContextAdapter)_db);
                        foreach (var resultSet in _resultSets)
                        {
                            results.Add(resultSet(adapter, reader));
                            reader.NextResult();
                        }
                    }
                    return results;
                }
            }
        }
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}
