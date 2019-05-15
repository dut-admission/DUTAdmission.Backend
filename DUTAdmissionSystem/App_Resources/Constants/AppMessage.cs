namespace DUTAdmissionSystem.App_Resources.Constants
{
    public static class AppMessage
    {
        public static string BadRequestNotFound
        {
            get { return "Không tìm thấy"; }
        }

        public static string NeverPassword
        {
            get { return "Bạn nhập mật khẩu cũ không chính xác, vui lòng kiểm tra lại"; }
        }

        public static string NoAccount
        {
            get { return "Không tồn tại tài khoản, bạn vui lòng kiểm tra lại username và email"; }
        }

        public static string OkSucceeded
        {
            get { return "Thành công"; }
        }

        public static string BadRequestFailed
        {
            get { return "Thất bại"; }
        }
        public static string NotAllowed
        {
            get { return "Không cho phép truy cập"; }
        }

        public static string NotAccept
        {
            get { return "Không chấp nhận được thực hiện quyền này"; }
        }
    }
}