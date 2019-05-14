using System;
using System.Linq;
using System.Security.Cryptography;

namespace DUTAdmissionSystem.Commons
{
    /// <summary>
    /// Chứa các function sẽ sử dụng chung và nhiều lần trong dự án.
    /// Author       :   AnMT - 30/04/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   DUTAdmissionSystem
    /// Copyright    :   Team DUTAdmissionSystem
    /// Version      :   1.0.0
    /// </remarks>
    public class FunctionCommon
    {
        private static string _secretKey = "DUTAdmissionSystem";

        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi có thêm chuối khóa đầu và cuối.
        /// Author       :   AnMT - 30/04/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa.
        /// </returns>
        public static string GetMd5(string str)
        {
            str = $"{_secretKey}{str}{_secretKey}";
            var arrBytes = System.Text.Encoding.UTF8.GetBytes(str);
            var myMd5 = new MD5CryptoServiceProvider();
            arrBytes = myMd5.ComputeHash(arrBytes);
            return arrBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
        }

        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi không có thêm chuối khóa đầu và cuối.
        /// Author       :   AnMT - 30/04/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa
        /// </returns>
        public static string GetSimpleMd5(string str)
        {
            var arrBytes = System.Text.Encoding.UTF8.GetBytes(str);
            var myMd5 = new MD5CryptoServiceProvider();
            arrBytes = myMd5.ComputeHash(arrBytes);
            return arrBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
        }

        public static bool ValidatePermission(string token, int userId)
        {
            var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
            if (tokenInformation == null) return false;
            return tokenInformation.GroupName == "Admin" ||
                   tokenInformation.GroupName == "Mod" ||
                   tokenInformation.UserId == userId;
        }

        /// <summary>
        /// Tạo mật khẩu mới cho tài khoản
        /// Author       :   AnMT - 12/05/2019 - create
        /// </summary>
        /// <returns>
        /// mật khẩu tài khoản
        /// </returns>
        ///
        public static string AutoPassword()
        {
            string pass = "";
            Random ran = new Random();
            string tmp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            pass += tmp.Substring(ran.Next(0, 25), 1);
            tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 7; i++)
            {
                pass += tmp.Substring(ran.Next(0, 61), 1);
            }

            return pass;
        }
    }
}