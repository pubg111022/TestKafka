namespace TestKafka.Application
{
    public class Constants
    {
        public static string baseUrl;
        public static string AppName;
        public static int InstanceNumber;
        public static int TotalInstance;
        public const string CashSettingId = "Cash";
        public const string DefaultKafkaMessageKey = "0000000000";
        public const int ClientCodeLength = 10;
        public const int IndayBussinessType = 0;
        public const int EodBusinessType = -10;
        public const int UpdateBussinessType = -13;
        public const string EODFlagKeyPrefix = "Cash-";
        public const string SPDeleteCashHis = "spbcts_cash_his_id";
        public const string SPDeleteCashDaily = "spbcts_cash_daily_d";
    }
}
