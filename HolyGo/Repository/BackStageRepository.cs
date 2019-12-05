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
    }
}