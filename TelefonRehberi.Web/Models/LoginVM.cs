using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Web.Models {
    public class LoginVM {
        public int loginID { get; set; }
        public string username { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}