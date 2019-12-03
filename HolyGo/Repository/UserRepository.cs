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

        //public void UpdateUsers(MemberViewModel memberView, string id)
        //{
        //    using (conn = new SqlConnection(connString))
        //    {
        //        string sql = $"Update AspNetUsers " +
        //                     $"SET LastName= '{memberView.LastName}', FirstName='{memberView.FirstName}', Birthday='{memberView.Birthday}', Country='{memberView.Country}', Phone='{memberView.Phone}' " +
        //                     $"WHERE Id= '{id}' ";
        //        conn.Execute(sql);
        //    }
        //}

        //Select a.User_guid, a.Datetime, c.Title, c.Contents, c.Images, c.Time, c.Country, b.Cost
        //From Travel_Order a
        //INNER JOIN Travel_Combo b
        //ON b.Guid = a.Combo_guid
        //INNER JOIN Travel c
        //ON c.Guid = b.Travel_guid
        //WHERE User_guid = '417cd80d-a994-4835-9d91-31c2955f31a1'

        /// <summary>
        /// 已出發訂單資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<UsersOrderViewModel> SelectUsersOrder(string id, string date)
        {
            List<UsersOrderViewModel> getUsersOrder;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"Select a.User_guid, a.Datetime, c.Title, c.Contents, c.Images, c.Time, c.Country, b.Cost " +
                             $"From Travel_Order a " +
                             $"INNER JOIN Travel_Combo b ON b.Guid = a.Combo_guid " +
                             $"INNER JOIN Travel c ON c.Guid = b.Travel_guid " +
                             $"WHERE User_guid = '{id}' AND Datetime < '{date}'  AND a.Status = 0";
                getUsersOrder = conn.Query<UsersOrderViewModel>(sql).ToList();
                return getUsersOrder;
            }
        }
        /// <summary>
        /// 即將出發訂單資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 取消訂單
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UsersOrderViewModel> SelectCancleOrder(string id)
        {
            List<UsersOrderViewModel> getCancleOrder;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"Select a.User_guid, a.Datetime, c.Title, c.Contents, c.Images, c.Time, c.Country, b.Cost " +
                             $"From Travel_Order a " +
                             $"INNER JOIN Travel_Combo b ON b.Guid = a.Combo_guid " +
                             $"INNER JOIN Travel c ON c.Guid = b.Travel_guid " +
                             $"WHERE User_guid = '{id}' AND a.Status = 1";
                getCancleOrder = conn.Query<UsersOrderViewModel>(sql).ToList();
                return getCancleOrder;
            }
        }
        //SELECT c.Title, c.Contents, c.Time, c.Country, c.Images, min(d.Cost) AS Cost
        //FROM Favorite a
        //INNER JOIN AspNetUsers b ON b.id = a.User_guid
        //INNER JOIN Travel c ON c.Guid = a.Travel_guid
        //INNER JOIN Travel_Combo d ON d.Travel_Guid = c.Guid
        //WHERE User_Guid = '417cd80d-a994-4835-9d91-31c2955f31a1'
        //GROUP BY c.Title, c.Contents, c.Time, c.Country, c.Images
        //ORDER BY Cost, c.Title
        /// <summary>
        /// 訂單收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UsersOrderViewModel> SelectFavorite(string user_id)
        {
            List<UsersOrderViewModel> getFavorite;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"select t.Guid, t.Title, t.Contents, t.Images, t.Time, t.Country, min(tc.Cost) as Cost " +
                             $"from Favorite f " +
                             $"inner join Travel t on t.Guid = f.Travel_guid " +
                             $"inner join Travel_Combo tc on tc.Travel_guid = t.Guid " +
                             $"where f.User_guid = '{user_id}' "+
                             $"group by t.Guid, t.Title, t.Contents, t.Images, t.Time, t.Country "+
                             $"order by Cost, t.Title";
                getFavorite = conn.Query<UsersOrderViewModel>(sql).ToList();
                return getFavorite;
            }
        }

        public void DelFavorite(Guid Guid)
        {
            using (conn = new SqlConnection(connString))
            {
                string sql = $"DELETE FROM Favorite " +
                             $"WHERE Guid = '{Guid}'";
                conn.Execute(sql);
            }
        }
    }
}