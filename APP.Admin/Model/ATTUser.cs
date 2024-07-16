using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Admin
{
    public class ATTUser
    {
        private DateTime _dateTime;
        public int? user_id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? is_admin { get; set; }
        //public decimal? credit { get; set; }



    }
}
