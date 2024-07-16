using APP.Admin.Repo.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Admin.Repo.Implimentation
{
    public class UserRepo: IUser
    {
        private readonly IConfiguration _configuration;
        public UserRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
}
