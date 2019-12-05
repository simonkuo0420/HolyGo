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

        public string CreateTravel(Travel travel)
        {

        }

    }
}