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
    public class UserRepository
    {
        #region 建構式
        public static string connString;
        public SqlConnection conn;
        public UserRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            if (conn == null)
            {
                conn = new SqlConnection(connString);
            }
        }
        #endregion

        /// <summary>
        /// 取得登入後個別使用者資料
        /// </summary>
        public List<MemberViewModel> SelectUsers(string id)
        {
            List<MemberViewModel> getAspUsers;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"SELECT * From AspNetUsers WHERE Id = {id} ";
                getAspUsers = conn.Query<MemberViewModel>(sql).ToList();
            }
            return getAspUsers;
        }
    }
}