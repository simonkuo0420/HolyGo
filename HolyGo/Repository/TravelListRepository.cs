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
    public class TravelListRepository
    {
        #region 建構式
        public static string connString;
        public SqlConnection conn;
        public TravelListRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            }
            if(conn == null)
            {
                conn = new SqlConnection(connString);
            }
        }
        #endregion
        /// <summary>
        /// 抓旅遊資料
        /// </summary>
        /// <param name="Country"></param>
        /// <param name="Time"></param>
        /// <param name="Cost"></param>
        /// <returns></returns>
        public List<TravelListViewModel> SelectTravel(string Country, string Time, int Cost)
        {
            List<TravelListViewModel> getTravel;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"";
                getTravel = conn.Query<TravelListViewModel>(sql).ToList();
                return getTravel;
            }
        }
    }
}