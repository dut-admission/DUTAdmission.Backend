namespace DUTAdmissionSystem.App_Resources.Constants
{
    public static class AppMessage
    {
        public static string BadRequestNotFound
        {
            get { return "Cannot found"; }
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
            get { return "Succeeded"; }
        }

        public static string BadRequestFailed
        {
            get { return "Failed"; }
        }

    }
}