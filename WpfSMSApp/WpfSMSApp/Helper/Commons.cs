using NLog;
using WpfSMSApp.Model;

namespace WpfSMSApp
{
    class Commons
    {
        // NLog 정적 인스턴스 생성
        public static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        // 로그인한 유저 정보
        public static User LOGINED_USER;
    }
}
