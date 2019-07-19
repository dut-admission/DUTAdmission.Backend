using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;

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

        /// <summary>
        /// Chuyển đổi từ base64String về Image
        /// Author       :   HoangNM - 03/04/2019 - create
        /// </summary>
        /// <param name="base64String">
        /// base64String
        /// </param>
        /// <returns>
        /// file ảnh
        /// </returns>
        static private Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            Bitmap tempBmp;
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                using (Image image = Image.FromStream(ms, true))
                {
                    //Create another object image for dispose old image handler
                    tempBmp = new Bitmap(image.Width, image.Height);
                    Graphics g = Graphics.FromImage(tempBmp);
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                }
            }
            return tempBmp;
        }

        /// <summary>
        /// Lưu ảnh vào thư mục đinh trước
        /// Author       :   HoangNM - 03/04/2019 - create
        /// </summary>
        /// <param name="imagerPath">
        /// đường dẫn hình ảnh
        /// </param>
        /// <param name="IdCommon">
        /// Id đối tượng
        /// </param>
        /// <returns>
        /// file ảnh
        /// </returns>
        static public string SaveImage(string imagerPath, int IdCommon, string name)
        {
            string strFileName = null;
            if (!string.IsNullOrEmpty(imagerPath))
            {
                using (Image image = Base64ToImage(imagerPath))
                {
                    strFileName = "Imagers/" + DateTime.Now.ToString("yyyyMMddHHmmss_") + IdCommon + "_" + name + ".jpg";
                    image.Save(HttpContext.Current.Server.MapPath("~/" + strFileName), ImageFormat.Jpeg);
                }
            }
            return strFileName;
        }

        /// <summary>
        /// Chuyển đổi từ Image về base64String 
        /// Author       :   HoangNM - 03/04/2019 - create
        /// </summary>
        /// <param name="image">
        /// file ảnh cần chuyển đổi
        /// </param>
        /// <returns>
        /// chuổi base 64
        /// </returns>
        private string ImageToBase64(System.Drawing.Image image, ImageFormat format)
        {
            string base64String;
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                ms.Position = 0;
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                base64String = Convert.ToBase64String(imageBytes);
            }
            return base64String;
        }

        public string GetImgager(string linkAnh)
        {
            string imagePath;
            string base64String = null;
            try
            {
                imagePath = HostingEnvironment.MapPath("~/" + linkAnh);
                if (File.Exists(imagePath))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromFile(imagePath))
                    {
                        if (img != null)
                        {
                            base64String = ImageToBase64(img, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return base64String;
        }

        /// <summary>
        /// Lưu file pdf vào thư mục
        /// Author       :   AnMT - 16/05/2019 - create
        /// </summary>
        /// <param name="stringPath">
        /// đường dẫn của file
        /// </param>
        /// <param name="IdCommon">
        /// Id đối tượng
        /// </param>
        /// <returns>
        /// file ảnh
        /// </returns>
        static public string SaveFile(string stringPath, int IdCommon, string name)
        {
            string strFileName = null;
            if (!string.IsNullOrEmpty(stringPath))
            {
                byte[] bytes = Convert.FromBase64String(stringPath);
                strFileName = "Document/" + DateTime.Now.ToString("yyyyMMddHHmmss_") + IdCommon + "_" + name;
                File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/" + strFileName), bytes);

            }
            return strFileName;
        }

        /// <summary>
        /// Xóa file theo danh sách url đã cung cấp.
        /// Author       :    AnMT - 18/05/2019 - create
        /// </summary>
        /// <param name="fileUrl">url file sẽ xóa</param>
        /// <returns>True nếu xóa thành công tất cả ccs file. Exception nếu có lỗi.</returns>
        public static bool DeleteFile(string fileUrl)
        {
            try
            {
                string path = HostingEnvironment.MapPath("~" + fileUrl);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get id user by token
        /// Author: HangNTD - 17/07/2019
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>return IdUser</returns>
        public static int GetIdUserByToken(string token)
        {
            return JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
        }

        /// <summary>
        /// Lưu file ảnh vào thư mục
        /// Author       :   AnMT - 16/05/2019 - create
        /// </summary>
        /// <param name="stringPath">
        /// đường dẫn của file
        /// </param>
        /// <param name="IdCommon">
        /// Id đối tượng
        /// </param>
        /// <returns>
        /// file ảnh
        /// </returns>
        static public string SaveFileImager(string stringPath, int IdCommon, string name)
        {
            string strFileName = null;
            if (!string.IsNullOrEmpty(stringPath))
            {
                byte[] bytes = Convert.FromBase64String(stringPath);
                strFileName = "Avatar/" + DateTime.Now.ToString("yyyyMMddHHmmss_") + IdCommon + "_" + name;
                File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/" + strFileName), bytes);

            }
            return strFileName;
        }

        
    }
}