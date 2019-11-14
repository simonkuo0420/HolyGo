﻿using Dapper;
using HolyGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HolyGo.Repository
{
    public class HomeRepository
    {
        #region 建構式
        public static string connString;
        public SqlConnection conn;
        public HomeRepository()
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

        /// <summary>
        /// 搜尋前8筆旅遊
        /// </summary>
        /// <returns>前8筆旅遊</returns>
        /// 
        public List<TopTravelViewModel> topTravel()
        {
            List<TopTravelViewModel> getTopTravel;
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = @"SELECT * FROM Travel LEFT JOIN Travel_Combo ON Travel.Guid = Travel_Combo.Travel_guid;";
                getTopTravel = conn.Query<TopTravelViewModel>(sql).ToList();
            }
            //conn.Close();
            return getTopTravel;
        }
    }
}