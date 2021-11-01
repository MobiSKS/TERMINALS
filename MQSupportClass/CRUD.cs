using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPCL_DP_Terminal.MQSupportClass
{

    public class CRUD
    {
        public static string GetConnection()
        {
            return ConfigurationManager.AppSettings["ConnectionString"].ToString();
        }
        public static bool FunCRUD(string StrQuery)
        {
            bool IsStatus;
            try
            {
                SqlConnection conn = new SqlConnection(GetConnection());
                conn.Open();
                SqlCommand cmd = new SqlCommand(StrQuery, conn)
                {
                    CommandTimeout = 0,
                    CommandType = CommandType.Text
                };

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    IsStatus = true;
                else
                    IsStatus = false;
                conn.Close();
                conn.Dispose();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return IsStatus;
        }

        public static DataSet ReturnDataSet(string StrQuery)
        {
            DataSet Ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(GetConnection());
                conn.Open();
                SqlCommand cmd = new SqlCommand(StrQuery, conn)
                {
                    CommandTimeout = 0,
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                Adp.Fill(Ds);
                conn.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return Ds;
        }

        public static DataSet ReturnDataSet_Text(string StrQuery)
        {
            DataSet Ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(GetConnection());
                conn.Open();
                SqlCommand cmd = new SqlCommand(StrQuery, conn)
                {
                    CommandTimeout = 0,
                    CommandType = CommandType.Text
                };

                SqlDataAdapter Adp = new SqlDataAdapter(cmd);
                Adp.Fill(Ds);
                conn.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return Ds;
        }

        public static void InsertAPIEntryLogFile(string Method_Name, object Request, string ExceptionMessage,string Useragent,string Userip,string Userid)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tbl_api_entry(api_flag,input_json,error_message_value,useragent,Userip,userid) values('" + Method_Name + "','" + Request.ToString()
                        + "','" + ExceptionMessage + "','" + Useragent + "','" + Userip + "','" + Userid + "')";
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


    }
}