using DUTAdmissionSystem.Database;
using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Linq;

namespace DUTAdmissionSystem.Commons
{
    /// <summary>
    /// Tổng hợp các phương thức hay dùng để xác thực các vấn đền liên quan đến tài khoản.
    /// Author       :   AnTM - 30/04/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   DUTAdmissionSystem
    /// Copyright    :   Team DUTAdmissionSystem
    /// Version      :   1.0.0
    /// </remarks>
    public class AccountVerification
    {
        /// <summary>
        /// Kiểm tra quyền truy cập một action trong controller.
        /// Author      :    AnTM - 30/04/2019 - create
        /// </summary>
        /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="controller">
        /// controller cần kiểm tra.
        /// </param>
        /// <param name="action">
        /// action trong controller cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, string controller, string action)
        {
            try
            {
                DataContext context = new DataContext();
                int GroupId = JwtAuthenticationExtensions.ExtractTokenInformation(token).GroupId;
                Permission permission = context.Permissions.FirstOrDefault(x => !x.DelFlag && x.AccountGroupId == GroupId && x.FunctionInScreen.ControllerName.Equals(controller) && x.FunctionInScreen.ActionName.Equals(action));
                if (permission == null || !permission.IsActived)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra quyền truy cập một chức năng theo mã chức năng.
        /// Author       :   AnTM - 30/04/2019 - create
        /// </summary>
        /// /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="functionId">
        /// Mã chức năng cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, int functionId)
        {
            try
            {
                DataContext context = new DataContext();
                int GroupId = JwtAuthenticationExtensions.ExtractTokenInformation(token).GroupId;
                Permission permission = context.Permissions.FirstOrDefault(x => !x.DelFlag && x.FunctionInScreenId == functionId && x.AccountGroupId == GroupId);
                if (permission != null && !permission.IsActived)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}