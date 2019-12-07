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
            if (conn == null)
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
                        sql = @"SELECT t.Guid,t.Title,t.Contents,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
                                FROM Travel t
                                LEFT JOIN Travel_Combo v ON t.Guid = v.Travel_guid
                                Group BY t.Guid, t.Title, t.Contents, t.Country, t.City, t.Time, t.Images
                                Order BY t.Title, Cost";
                        break;
                    case "Taiwan":
                        sql = @"SELECT t.Guid,t.Title,t.Contents,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
                                FROM Travel t
                                LEFT JOIN Travel_Combo v ON t.Guid = v.Travel_guid
                                Where t.Country = N'台灣'
                                Group BY t.Guid, t.Title, t.Contents, t.Country, t.City, t.Time, t.Images
                                Order BY Cost";
                        break;
                    case "Japan":
                        sql = @"SELECT t.Guid,t.Title,t.Contents,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
                                FROM Travel t
                                LEFT JOIN Travel_Combo v ON t.Guid = v.Travel_guid
                                Where t.Country = N'日本'
                                Group BY t.Guid, t.Title, t.Contents, t.Country, t.City, t.Time, t.Images
                                Order BY Cost";
                        break;
                    case "Korea":
                        sql = @"SELECT t.Guid,t.Title,t.Contents,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
                                FROM Travel t
                                LEFT JOIN Travel_Combo v ON t.Guid = v.Travel_guid
                                Where t.Country = N'韓國'
                                Group BY t.Guid, t.Title, t.Contents, t.Country, t.City, t.Time, t.Images
                                Order BY Cost";
                        break;
                    case "Other":
                        sql = @"SELECT t.Guid,t.Title,t.Contents,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
                                FROM Travel t
                                LEFT JOIN Travel_Combo v ON t.Guid = v.Travel_guid
                                Where t.Country not like N'韓國' and t.Country not like N'台灣' and t.Country not like N'日本'
                                Group BY t.Guid, t.Title, t.Contents, t.Country, t.City, t.Time, t.Images
                                Order BY Cost";
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