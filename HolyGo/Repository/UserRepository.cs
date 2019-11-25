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
        public MemberViewModel SelectUsers(string id)
        {
            MemberViewModel getAspUsers = new MemberViewModel();
            using (conn = new SqlConnection(connString))
            {
                string sql = $"Select FirstName, LastName, Gender, Birthday, Country, Phone, Email " +
                             $"From AspNetUsers " +
                             $"Where Id = '{id}' ";
                getAspUsers = conn.Query<MemberViewModel>(sql).FirstOrDefault();
            }
            return getAspUsers;
        }

        /// <summary>
        /// 更新使用者資料
        /// </summary>
        /// <param name="memberView"></param>
        /// <param name="id"></param>
        public void UpdateUsers(MemberViewModel memberView, string id)
        {
            using (conn = new SqlConnection(connString))
            {
                string sql = $"Update AspNetUsers " +
                             $"SET LastName=@LastName, FirstName=@FirstName, Birthday=@Birthday, Country=@Country, Phone=@Phone " +
                             $"WHERE Id= '{id}' ";
                conn.Execute(sql, new
                {
                    LastName = memberView.LastName,
                    FirstName = memberView.FirstName,
                    Birthday = memberView.Birthday,
                    Country = memberView.Country,
                    Phone = memberView.Phone
                });
            }
        }

        //Select a.User_guid, a.Datetime, c.Title, c.Contents, c.Images, c.Time, c.Country, b.Cost
        //From Travel_Order a
        //INNER JOIN Travel_Combo b
        //ON b.Guid = a.Combo_guid
        //INNER JOIN Travel c
        //ON c.Guid = b.Travel_guid
        //WHERE User_guid = '417cd80d-a994-4835-9d91-31c2955f31a1'

        /// <summary>
        /// 個別使用者訂單資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UsersOrderViewModel> SelectUsersOrder(string id,string date)
        {
            List<UsersOrderViewModel> getUsersOrder;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"Select a.User_guid, a.Datetime, c.Title, c.Contents, c.Images, c.Time, c.Country, b.Cost " +
                             $"From Travel_Order a " +
                             $"INNER JOIN Travel_Combo b ON b.Guid = a.Combo_guid " +
                             $"INNER JOIN Travel c ON c.Guid = b.Travel_guid " +
                             $"WHERE User_guid = '{id}' AND Datetime < '{date}'" ;
                getUsersOrder = conn.Query<UsersOrderViewModel>(sql).ToList();
                return getUsersOrder;
            }
        }

        public List<UsersOrderViewModel> SelectUsersGoOrder(string id, string date)
        {
            List<UsersOrderViewModel> getUsersGoOrder;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"Select a.User_guid, a.Datetime, c.Title, c.Contents, c.Images, c.Time, c.Country, b.Cost " +
                             $"From Travel_Order a " +
                             $"INNER JOIN Travel_Combo b ON b.Guid = a.Combo_guid " +
                             $"INNER JOIN Travel c ON c.Guid = b.Travel_guid " +
                             $"WHERE User_guid = '{id}' AND Datetime >= '{date}'";
                getUsersGoOrder = conn.Query<UsersOrderViewModel>(sql).ToList();
                return getUsersGoOrder;
            }
        }
    }
}