using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.COMMON;
using Entity.Security;


namespace APP.Security
{
    public interface ILoginUser
    {
        public JsonResponse Login(ATTUserProfile profile);
        public JsonResponse CreateUser(ATTUserProfile aTTUserProfile);
        public JsonResponse GetUser();
        public JsonResponse UpdateUser(ATTUserProfile? profile);

    }
}
