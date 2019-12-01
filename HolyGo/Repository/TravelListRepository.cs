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
        /// <returns></returns>
        public List<TravelListViewModel> QuerySelectTravel()
        {
            List<TravelListViewModel> getTravel;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"select * from Travel t order by t.Country";
                getTravel = conn.Query<TravelListViewModel>(sql).ToList();
                return getTravel;
            }
        }

        public List<TravelListViewModel> QuerySelectTravel(string id)
        {
            List<TravelListViewModel> getTravel = null;
            using (conn = new SqlConnection(connString))
            {
                string sql;
                switch (id)
                {
                    case "ALL":
                        sql = @"select tc.Title, tc.Contents, t.Time, t.Country, t.City, t.Images, tc.Cost 
                                from Travel t 
                                inner join Travel_Combo tc on t.Guid = tc.Travel_guid
                                order by t.Country";
                        break;
                    case "Taiwan":
                        sql = @"select tc.Title, tc.Contents, t.Time, t.Country, t.City, t.Images, tc.Cost 
                                from Travel t 
                                inner join Travel_Combo tc on t.Guid = tc.Travel_guid 
                                where t.Country = N'台灣'";
                        break;
                    case "Japan":
                        sql = @"select tc.Title, tc.Contents, t.Time, t.Country, t.City, t.Images, tc.Cost
                                from Travel t
                                inner join Travel_Combo tc on t.Guid = tc.Travel_guid 
                                where t.Country = N'日本'";
                        break;
                    case "Korea":
                        sql = @"select tc.Title, tc.Contents, t.Time, t.Country, t.City, t.Images, tc.Cost
                                from Travel t
                                inner join Travel_Combo tc on t.Guid = tc.Travel_guid 
                                where t.Country = N'韓國'";
                        break;
                    case "Other":
                        sql = @"select tc.Title, tc.Contents, t.Time, t.Country, t.City, t.Images, tc.Cost
                                from Travel t
                                inner join Travel_Combo tc on t.Guid = tc.Travel_guid 
                                where t.Country not like N'韓國' and t.Country not like N'台灣' and t.Country not like N'日本' 
                                order by t.Country";
                        break;
                    default:
                        return null;
                }
                getTravel = conn.Query<TravelListViewModel>(sql).ToList();

            }
            return getTravel;
        }
    }
}