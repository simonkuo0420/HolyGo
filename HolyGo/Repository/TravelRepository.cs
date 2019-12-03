using Dapper;
using HolyGo.Models;
using HolyGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HolyGo.Repository
{
    public class TravelRepository
    {
        #region 建構式
        public static string connString;
        public SqlConnection conn;

        public TravelRepository()
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
        public List<TravelViewModel> SelectTravel(Guid Guid)
        {
            List<TravelViewModel> getTravel;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"SELECT * " +
                             $"FROM Travel " +
                             $"WHERE Guid = '{Guid}'";
                getTravel = conn.Query<TravelViewModel>(sql).ToList();
                return getTravel;
            }
        }

        public List<Travel_Combo> SelectCombo(Guid Guid)
        {
            List<Travel_Combo> getTravelCombo;
            using (conn = new SqlConnection(connString))
            {
                string sql = $"SELECT * " +
                             $"FROM Travel_Combo " +
                             $"WHERE Travel_guid = '{Guid}' " +
                             $"ORDER BY Cost";
                getTravelCombo = conn.Query<Travel_Combo>(sql).ToList();
                return getTravelCombo;
            }
        }

        public void AddCart(Guid Guid, string User_guid, Guid Travel_guid)
        {
            using (conn = new SqlConnection(connString))
            {
                string sql = $"INSERT INTO Favorite(Guid, User_guid, Travel_guid) " +
                             $"VALUES ('{Guid}','{User_guid}','{Travel_guid}')";
                conn.Execute(sql);
            }
        }

        //public List<Ticket> SelectTicket(Guid Guid)
        //{
        //    List<Ticket> getTicket;
        //    using (conn = new SqlConnection(connString))
        //    {
        //        string sql = $"SELECT * " +
        //                     $"FROM Ticket " +
        //                     $"WHERE Guid = '{Guid}'";
        //        getTicket = conn.Query<Ticket>(sql).ToList();
        //        return getTicket;
        //    }
        //}

        //public List<Ticket_Combo> SelectTicketCombo(Guid Guid)
        //{
        //    List<Ticket_Combo> getTicket;
        //    using (conn = new SqlConnection(connString))
        //    {
        //        string sql = $"SELECT * " +
        //                     $"FROM Ticket_Combo " +
        //                     $"WHERE Ticket_guid = '{Guid}' " +
        //                     $"ORDER BY Cost";
        //        getTicket = conn.Query<Ticket_Combo>(sql).ToList();
        //        return getTicket;
        //    }
        //}
    }
}