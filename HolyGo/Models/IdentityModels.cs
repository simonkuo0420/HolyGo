using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HolyGo.Models
{
    // 您可將更多屬性新增至 ApplicationUser 類別，藉此為使用者新增設定檔資料，如需深入了解，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 姓氏
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 地區
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 個人照片
        /// </summary>
        public string ProfilePicture { get; set; }

        public bool Status { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}