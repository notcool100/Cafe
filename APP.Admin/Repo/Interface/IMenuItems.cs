using APP.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Admin.Repo.Interface
{
    public interface IMenuItems
    {
        public JsonResponse createmenu(ATTMenuitems items);
    }
}
