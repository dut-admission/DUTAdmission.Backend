namespace DUTAdmissionSystem.Commons
{
    public static class Constants
    {
        public const string TokenSecretKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        public const string UsernameClaimKey = "username";

        public const string UserIdClaimKey = "user_id";

        public const string GroupNameClaimKey = "group_name";

        public const string GroupIdClaimKey = "group_id";

        public const string IsStudentClaimKey = "is_student";

        public const string ValidAudience = "dut_team_audience";

        public const string ValidIssuer = "dut_team_issuer";

    }
}