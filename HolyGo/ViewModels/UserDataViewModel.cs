using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    public class UserDataViewModel
    {
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gander { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}