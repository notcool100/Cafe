using APP.Admin.Repo.Interface;
using APP.COMMON;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Admin.Repo.Implimentation
{
    public class MenuItemRepo : IMenuItems
    {
        private readonly IConfiguration _configuration;
        public MenuItemRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JsonResponse createmenu(ATTMenuitems items)
        {
            ATTMenuitems? menu = new ATTMenuitems();
            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Menu.ADDItems";
                    using (SqlTransaction tran = connection.BeginTransaction())
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("P_ItemName", items.ItemName.Trim());
                        param.Add("P_price", items.price);

                        menu = connection.Query<ATTMenuitems>(sql, param, tran, commandType: CommandType.StoredProcedure)?.FirstOrDefault();
                        //var result = connection.Execute(sql, param, tran, commandType: CommandType.StoredProcedure);
                        tran.Commit();
                        if (menu == null)
                        {
                            response.IsSuccess = false;
                            response.HasError = true;
                            response.Message = "Cannot Insert the item";
                        }
                        else
                        {
                            response.IsSuccess = true;
                            response.ResponseData = menu;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ATTMessages.USER.LOGIN_FAILURE);
               
            }
            return response;
        }

       
    }
}
