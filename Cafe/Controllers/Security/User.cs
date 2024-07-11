
using APP.COMMON;
using APP.Security;
using Entity.Security;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers.Security
{
    public class User : Controller
    {
        public readonly ILoginUser  _loginUser;
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
        public async Task<JsonResponse>CreateRecord(ATTUserProfile request)
        {
            JsonResponse response = null;
            try
            {
                response =  _loginUser.CreateUser(request);
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
        public async Task<JsonResponse>LoginUser(ATTUserProfile profile)
        {
            JsonResponse response = null;
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
        public async Task<JsonResponse> GetUser()
        {
            JsonResponse response = null;
            try
            {
                response = _loginUser.GetUser();
            }
            catch (Exception ex){
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<JsonResponse> UpdateUser(ATTUserProfile? profile)
        {
            JsonResponse response = null;
            try
            {
                response = _loginUser.UpdateUser(profile);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseData = ex.Message;
            }
            return response;
        }
    }
}
