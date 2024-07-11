using APP.COMMON;
using Dapper;
using Entity.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static APP.COMMON.ATTMessages;

namespace APP.Security.Repo.Implimantation
{
    public class LoginUser : ILoginUser
    {
        private readonly IConfiguration _configuration;
        public LoginUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JsonResponse CreateUser(ATTUserProfile aTTUserProfile)
        {
            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Security.CreateUser";

                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("P_USERNAME", aTTUserProfile.UserName?.Trim());
                        param.Add("P_PASSWORD", aTTUserProfile.Password?.Trim());
                        param.Add("P_UserType", aTTUserProfile.is_admin == "Admin");


                        var result = connection.Execute(sql, param, tran, commandType: CommandType.StoredProcedure);
                        tran.Commit();
                        if (result == 1)
                        {
                            response.IsSuccess = true;
                            response.Message = "User Created Sucessfully";
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseData = ex;
                response.HasError = true;
                response.Message = ATTMessages.CANNOT_SAVE;
            }
            return response;
        }

        public JsonResponse Login(ATTUserProfile profile)
        {
            ATTUserProfile? user = new ATTUserProfile();

            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Security.LoginUser";

                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("P_USERNAME", profile.UserName?.Trim());

                        param.Add("P_PASSWORD", profile.Password?.Trim());

                        user = connection.Query<ATTUserProfile?>(sql, param, tran, commandType: CommandType.StoredProcedure)?.FirstOrDefault();
                        if (user == null)
                        {
                            throw new Exception(ATTMessages.USER.LOGIN_FAILURE);
                        }
                        else
                        {
                            if (user.UserName != null)
                            {
                                user.isLoginSucess = true;
                            }
                            response.IsSuccess = true;
                            response.ResponseData = user;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.HasError = true;
                response.Message = "Invilid UserName or Password";
            }
            return response;
        }

        public JsonResponse GetUser()
        {
            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "Security.GetUser";
                    var users = connection.Query<ATTUserProfile>(sql, commandType: CommandType.StoredProcedure).ToList();
                    if (users.Any())
                    {
                        response.ResponseData = users;
                        response.IsSuccess = true;
                        response.Message = "Users Found";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "No Users Found";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occurred";
            }
            return response;
        }
        public JsonResponse UpdateUser(ATTUserProfile? profile)
        {
            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "Security.UpdateUser";
                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("P_USERNAME", profile.UserName?.Trim());
                        param.Add("P_USERID", profile.user_id);
                        profile = connection.Query<ATTUserProfile>(sql, param, tran, commandType: CommandType.StoredProcedure).FirstOrDefault();
                        tran.Commit();
                        if(profile != null)
                        {
                            response.ResponseData = profile;
                            response.IsSuccess = true;
                            response.Message = "User Updated Sucessfully";
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "Unable to update User";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error Occure";
            }
            return response;
        }

    }
}
