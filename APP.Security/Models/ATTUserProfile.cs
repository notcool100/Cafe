using System;

namespace Entity.Security
{
    public class ATTUserProfile
    {
        private DateTime _dateTime;
        public int? user_id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? is_admin { get; set; }
        public decimal? credit { get; set; }
        public bool isLoginSucess { get; set; }
        public ATTUserProfile()
        {
            this.isLoginSucess = false;
        }
    }

}
