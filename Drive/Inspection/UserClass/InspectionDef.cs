
namespace Motion_Designer
{
    static public class InspectionDef
    {
        public const long WAIT_10ms = 10;                          // 待ち時間 [10ms]
        public const long WAIT_200ms = 200;                        // 待ち時間 [200ms]
        public const long WAIT_500ms = 500;                        // 待ち時間 [500ms]

        public const long WAIT_1s = 1000;                          // 待ち時間 [1s]
        public const long WAIT_2s = 2000;                          // 待ち時間 [2s]
        public const long WAIT_3s = 3000;                          // 待ち時間 [3s]
        public const long WAIT_5s = 5000;                          // 待ち時間 [5s]
        public const long WAIT_10s = 10000;                        // 待ち時間 [10s]

        public const long WAIT_10m = 600000;                       // 待ち時間 [10min]

        /// <summary>
        /// 環境設定変更パスワード
        /// </summary>
        public const string PASSWORD = "AMADA";

        /// <summary>
        /// パラメータ最大個数(10個)
        /// </summary>
        public const int MAX_PARA = 10;

        /// <summary>
        /// フォトセンサ取付／動作確認パラメータ
        /// </summary>
        static public PhotoParamters[] pHotoParamters = new PhotoParamters[MAX_PARA];

        /// <summary>
        /// データベース情報
        /// </summary>
        static public DBParamters dBParamters = new DBParamters();
    }

}
