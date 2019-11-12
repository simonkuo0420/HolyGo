using Dapper;
using HolyGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HolyGo.Repository
{
    public class HomeRepository
    {
        #region 建構式
        public static string connString;
        public SqlConnection conn;

        public HomeRepository()
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

        /// <summary>
        /// 搜尋前8筆旅遊
        /// </summary>
        /// <returns>前8筆旅遊</returns>
        public List<TopTravelViewModel> topTravel()
        {
            List<TopTravelViewModel> getTopTravel = null;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"";
                getTopTravel = conn.Query<TopTravelViewModel>(sql).ToList();
            }
            return getTopTravel;
        }
    }
}