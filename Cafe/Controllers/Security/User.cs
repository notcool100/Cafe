using APP.COMMON;
using APP.Security;
using Entity.Security;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers.Security
{
    public class User : Controller
    {
        private readonly ILoginUser _loginUser;

        public User(ILoginUser loginUser)
        {
            _loginUser = loginUser;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateRecord")]
        public JsonResponse CreateRecord(ATTUserProfile request)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _loginUser.CreateUser(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("LoginUser")]
        public JsonResponse LoginUser([FromBody] ATTUserProfile profile)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _loginUser.Login(profile);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetUser")]
        public JsonResponse GetUser()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _loginUser.GetUser();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public JsonResponse UpdateUser(ATTUserProfile profile)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _loginUser.UpdateUser(profile);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseData = ex.Message;
            }
            return response;
        }
    }
}
