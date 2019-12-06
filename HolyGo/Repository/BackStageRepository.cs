using HolyGo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using HolyGo.ViewModels;

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

        public List<UserDataViewModel> QueryGetUserData ()
        {
            List<UserDataViewModel> getUserData = new List<UserDataViewModel>();
                string sql = @"select a.Id, a.FirstName, a.LastName, a.Gender, a.Birthday, a.Country, a.City, a.Phone, a.Email from AspNetUsers a";

            getUserData = conn.Query<UserDataViewModel>(sql).ToList();
            return getUserData;
        }

        public string CreateTravel(Travel travel, Guid Guid)
        {
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    string sql = $"INSERT INTO Travel (Guid, Title, Contents, Time, Country, City, Images, Status, Explain) " +
                                 $"VALUES ('{Guid}',N'{travel.Title}',N'{travel.Contents}','{travel.Time}',N'{travel.Country}',N'{travel.City}','{travel.Images}','1',N'{travel.Explain}')";
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

        public void CreateTravelCombo(Guid tcGuid, string tGuid, string Title, string Contents, string Cost)
        {
            using (conn = new SqlConnection(connString))
            {
                string sql = $"INSERT INTO Travel_Combo (Guid, Travel_Guid, Title, Contents, Cost) " +
                             $"VALUES ('{tcGuid}',N'{tGuid}',N'{Title}',N'{Contents}',{Cost})";
                conn.Execute(sql);
            }
        }

        public List<BackStageTravelList> SelectTravel()
        {
            List<BackStageTravelList> SelectTravel;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"select t.Guid, t.Title, t.Time, t.Country, t.City, Count(tc.Cost) as Count " +
                             $"from Travel t " +
                             $"left join Travel_Combo tc " +
                             $"on t.Guid = tc.Travel_guid " +
                             $"group by t.Guid, t.Title, t.Time, t.Country, t.City";
                SelectTravel =  conn.Query<BackStageTravelList>(sql).ToList();
                return SelectTravel;
            }
        }

        public List<Travel_Combo> SelectTravelCombo(Guid Guid)
        {
            List<Travel_Combo> SelectTravelCombo;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"SELECT * " +
                             $"FROM Travel_Combo " +
                             $"WHERE Travel_guid = '{Guid}' " +
                             $"ORDER BY Cost";
                SelectTravelCombo = conn.Query<Travel_Combo>(sql).ToList();
                return SelectTravelCombo;
            }
        }
    }
}