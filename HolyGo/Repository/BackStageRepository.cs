using Dapper;
using HolyGo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HolyGo.Repository
{
    public class BackStageRepository
    {
        #region 建構式
        public static string connString;
        public SqlConnection conn;

        public BackStageRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            if(conn == null)
            {
                conn = new SqlConnection(connString);
            }
        }
        #endregion

        public string CreateTravel(Travel travel, Guid Guid)
        {
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    string sql = $"INSERT INTO Travel (Guid, Title, Contents, Time, Country, City, Images, Status, Explain) " +
                                 $"VALUES ('{Guid}','{travel.Title}','{travel.Contents}','{travel.Time}','{travel.Country}','{travel.City}','{travel.Images}','{travel.Status}','{travel.Explain}')";
                    conn.Execute(sql);
                    return "新增成功";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "新增失敗";
                }
            }
        }
    }
}