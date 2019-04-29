using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstactions;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DUTAdmissionSystem.Database.Schema.Entity;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class ProfileService:IProfileService
    {
        private readonly DataContext db = new DataContext();

        public string UpdatePassWord(UpdatePassword updatePassword)
        {
            // Get tài khoản đang dùng ra, kiểm tra xem old pass có đúng không
            Account account = db.Accounts.FirstOrDefault(x => x.Password == updatePassword.OldPassWord && !x.DelFlag);// cái này chưa đúng, viết để lấy tạm account để update
            account.Password = updatePassword.NewPassWord;
            db.SaveChanges();
            //hỏi trả về cái gì luôn

            return "Cập nhật mật khẩu thành công";

        }
    }
}