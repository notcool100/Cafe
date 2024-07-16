using APP.Admin;
using APP.Admin.Repo.Interface;
using APP.COMMON;
using APP.Security;
using APP.Security.Repo.Implimantation;
using Entity.Security;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers.Admin.menuItems
{
    public class AddMenuItems : Controller
    {
        private readonly IMenuItems _Menu;

        public AddMenuItems(IMenuItems Menu)
        {
            _Menu = Menu;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateMenuitems")]
        public JsonResponse CreatemenuItems(ATTMenuitems items)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _Menu.createmenu(items);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
