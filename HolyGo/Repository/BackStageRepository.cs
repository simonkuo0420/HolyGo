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
    }
}