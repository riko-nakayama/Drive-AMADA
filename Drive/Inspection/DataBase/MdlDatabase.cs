// -------------------------------------------------------------------------------
// 
// ＤＢ共通処理
// 
// -------------------------------------------------------------------------------
using System;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Motion_Designer
{
    static public class MdlDatabase
    {

        // DB接続object
        public static SqlConnection gsconDB = new SqlConnection();

        // -------------------------------------------------------------------------------
        // Database接続文字列の作成
        // 
        // strServer:      (i) 接続先サーバ名
        // strDataBase:    (i) 接続先データベース名
        // strUsr:         (i) 接続ユーザ名
        // strPwd:         (i) 接続パスワード
        // -------------------------------------------------------------------------------
        public static string gstrGetDBConString(string strServer, string strDataBase, string strUsr, string strPwd)
        {
            string strTmp;

            strTmp = string.Empty;
            strTmp += @"workstation id=" + strServer + ";";
            strTmp += @"user id=" + strUsr + ";";
            strTmp += @"password=" + strPwd + ";";
            strTmp += @"data source=" + strServer + ";";
            strTmp += @"persist security info=TRUE;";
            strTmp += @"initial catalog=" + strDataBase;

            return strTmp;
        }

        // -------------------------------------------------------------------------------
        // Database接続準備
        // 
        // scnDb:          (i) SqlConnection
        // strServer:      (i) 接続先サーバ名
        // strDataBase:    (i) 接続先データベース名
        // strUsr:         (i) 接続ユーザ名
        // strPwd:         (i) 接続パスワード
        // -------------------------------------------------------------------------------
        public static bool gblnDBConPrep(ref SqlConnection scnDb, string strServer, string strDataBase, string strUsr, string strPwd)
        {
            try
            {
                scnDb.ConnectionString = gstrGetDBConString(strServer, strDataBase, strUsr, strPwd);
            }
            catch
            {
                return false;
            }

            return true;
        }

        // -------------------------------------------------------------------------------
        // 汎用クエリ実行
        // 
        // strsql:クエリ文
        // 
        // 関数値  正=成功(0:行無し 1:行有り) / 負=失敗
        // -------------------------------------------------------------------------------
        public static int giDbQuery(string strsql)
        {
            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null;

            try
            {
                gsconDB.Open();
                scmdTmp = new SqlCommand(strsql, gsconDB);
                sdrdTmp = scmdTmp.ExecuteReader();

                if (sdrdTmp.HasRows == true)
                    return 1;
                else
                    return 0;
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        public static int giDbQueryList(string strsql, ref ArrayList lst)
        {
            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null; ;

            lst.Clear();

            try
            {
                gsconDB.Open();

                scmdTmp = new SqlCommand(strsql, gsconDB);
                sdrdTmp = scmdTmp.ExecuteReader();

                while (!(sdrdTmp.Read() == false))
                    lst.Add(sdrdTmp.GetValue(0));

                if (sdrdTmp.HasRows == true)
                    return 1;
                else
                    return 0;
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        public static int giDbQueryArrayList(string strsql, ref List<MdlDatabaseDefine.ST_DB_QUERY> lst)
        {
            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null;

            MdlDatabaseDefine.ST_DB_QUERY squery;

            lst.Clear();

            try
            {
                gsconDB.Open();

                scmdTmp = new SqlCommand(strsql, gsconDB);
                sdrdTmp = scmdTmp.ExecuteReader();

                while (!(sdrdTmp.Read() == false))
                {
                    squery = new MdlDatabaseDefine.ST_DB_QUERY();
                    squery.field_name = new List<string>();
                    squery.data_record = new List<string>();

                    for (var i = 0; i <= sdrdTmp.FieldCount - 1; i++)
                    {
                        squery.field_name.Add(sdrdTmp.GetName(i).ToString());
                        squery.data_record.Add(sdrdTmp[i].ToString());
                    }

                    lst.Add(squery);
                }

                if (sdrdTmp.HasRows == true)
                    return 1;
                else
                    return 0;
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        // -------------------------------------------------------------------------------
        // mSpec より 指定モータ形式 の 設定値を取得する
        // 
        // strModel:              (i) モータ形式
        // ST_DB_SPEC:             (o) 仕様値
        // 
        // 関数値  正=取得レコード数 / 負=異常終了
        // -------------------------------------------------------------------------------
        public static int giDbGetSpec(string strModel, ref MdlDatabaseDefine.ST_DB_SPEC stSpec)
        {
            bool blnRinf;

            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null;

            string strSql = "select * from " + MdlDatabaseDefine.DB_M_SPEC + 
                            " where " + MdlDatabaseDefine.DF_SPEC_MODEL + " = '" + strModel + "'";

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();
         
                sdrdTmp = scmdTmp.ExecuteReader();

                blnRinf = sdrdTmp.Read();
                if (sdrdTmp.HasRows == false)
                {
                    Close(scmdTmp, sdrdTmp);
                    return 0;
                }
                else
                {
                    stSpec.strModel = sdrdTmp[MdlDatabaseDefine.DF_SPEC_MODEL].ToString().Trim();        // モータ形式
                    stSpec.strModelID = sdrdTmp[MdlDatabaseDefine.DF_SPEC_MODELID].ToString().Trim();    // 機種ID
                    
                    return 1;
                }
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        // -------------------------------------------------------------------------------
        // mSpec より 指定機種ID の 設定値を取得する
        // 
        // strModeID:              (i) 機種ID
        // ST_DB_SPEC:             (o) 仕様値
        // 
        // 関数値  正=取得レコード数 / 負=異常終了
        // -------------------------------------------------------------------------------
        public static int giDbGetSpecWithID(string strModelID, ref MdlDatabaseDefine.ST_DB_SPEC stSpec)
        {
            bool blnRinf;

            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null; ;

            string strSql = "select * from " + MdlDatabaseDefine.DB_M_SPEC + 
                            " where " + MdlDatabaseDefine.DF_SPEC_MODELID + " = '" + strModelID + "'";

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                sdrdTmp = scmdTmp.ExecuteReader();

                blnRinf = sdrdTmp.Read();

                if (sdrdTmp.HasRows == false)
                {
                    Close(scmdTmp, sdrdTmp);
                    return 0;
                }
                else
                {
                    stSpec.strModel = sdrdTmp[MdlDatabaseDefine.DF_SPEC_MODEL].ToString().Trim();     // モータ形式
                    stSpec.strModelID = sdrdTmp[MdlDatabaseDefine.DF_SPEC_MODELID].ToString().Trim(); // 機種ID
                    
                    return 1;
                }
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        // -------------------------------------------------------------------------------
        // mDriveTestSetting より 指定モータ形式の 設定値を１件取得する
        // 
        // strModel:               (i) モータ形式
        // ST_DB_DRVTEST_SETTING:  (o) ドライブ動作確認
        // 
        // 関数値  正=取得レコード数 / 負=異常終了
        // -------------------------------------------------------------------------------
        public static int giDbGetDrvTestSetting(string strModel, ref MdlDatabaseDefine.ST_DB_DRVTEST_SETTING stDrvSetting)
        {
            bool blnRinf;
            
            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null; ;

            string strSql = "select * from " + MdlDatabaseDefine.DB_M_DRVTEST_SETTING + 
                            " where " + MdlDatabaseDefine.DF_DTSET_MODEL + " = '" + strModel + "' and " + MdlDatabaseDefine.DF_DTSET_PCNAME + " = '" + Dns.GetHostName() + "'";

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();
           

                sdrdTmp = scmdTmp.ExecuteReader();

                blnRinf = sdrdTmp.Read();

                if (sdrdTmp.HasRows == false)
                {
                    Close(scmdTmp, sdrdTmp);
                    return 0;
                }
                else
                {
                    // モータ形式
                    stDrvSetting.strModel = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MODEL].ToString().Trim();

                    // ドライバ動作確認試験装置用 モータ中継ケーブルNo
                    stDrvSetting.strMotorCableSpec = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTERCABLE_SPEC].ToString().Trim();

                    // ドライバ動作確認試験装置用 センサ中継ケーブルNo
                    stDrvSetting.strSECableSpec = sdrdTmp[MdlDatabaseDefine.DF_DTSET_SECABLE_SPEC].ToString().Trim();

                    // ドライバ動作確認試験装置用 接続ドライバ形式  
                    stDrvSetting.strDriverModel = sdrdTmp[MdlDatabaseDefine.DF_DTSET_DRVMODEL].ToString().Trim();

                    // 低速回転_速度指定[rpm]
                    stDrvSetting.strMotorSetSpeedLow = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_LOW].ToString().Trim();  
                    
                    if (stDrvSetting.strMotorSetSpeedLow != string.Empty)
                        stDrvSetting.strMotorSetSpeedLow = Convert.ToInt32(stDrvSetting.strMotorSetSpeedLow).ToString("D4");

                    // 低速回転_加速度制限設定[x10rpm/s]
                    stDrvSetting.strMotorAcLmtLow = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_LOW].ToString().Trim();        
                      
                    if (stDrvSetting.strMotorAcLmtLow != string.Empty)
                        stDrvSetting.strMotorAcLmtLow = Convert.ToInt32(stDrvSetting.strMotorAcLmtLow).ToString("D4");

                    // 高速回転_速度指定[rpm]
                    stDrvSetting.strMotorSetSpeedHi = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_HI].ToString().Trim();     

                    if (stDrvSetting.strMotorSetSpeedHi != string.Empty)
                        stDrvSetting.strMotorSetSpeedHi = Convert.ToInt32(stDrvSetting.strMotorSetSpeedHi).ToString("D4");

                    // 高速回転_加速度制限設定[x10rpm/s]
                    stDrvSetting.strMotorAcLmtHi = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_HI].ToString().Trim();           
                    
                    if (stDrvSetting.strMotorAcLmtHi != string.Empty)
                        stDrvSetting.strMotorAcLmtHi = Convert.ToInt32(stDrvSetting.strMotorAcLmtHi).ToString("D4");

                    // キー合わせ工程有無： 0=工程なし/1=あり
                    stDrvSetting.strKeyAdjust = sdrdTmp[MdlDatabaseDefine.DF_DTSET_KEY_ADJUST].ToString().Trim();

                    // キー合わせ回転_速度指定[rpm]
                    stDrvSetting.strMotorSetSpeedKey = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_KEY].ToString().Trim();  
                    
                    if ((stDrvSetting.strMotorSetSpeedKey != string.Empty))
                        stDrvSetting.strMotorSetSpeedKey = System.Convert.ToInt32(stDrvSetting.strMotorSetSpeedKey).ToString("D4");

                    // キー合わせ回転_加速度制限設定[x10rpm/s]
                    stDrvSetting.strMotorAcLmtKey = sdrdTmp[MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_KEY].ToString().Trim();        

                    if ((stDrvSetting.strMotorAcLmtKey != string.Empty))
                        stDrvSetting.strMotorAcLmtKey = Convert.ToInt32(stDrvSetting.strMotorAcLmtKey).ToString("D4");

                    // ブレーキ電圧規格値[V] なし：non
                    stDrvSetting.strBrakeVoltageSpec = sdrdTmp[MdlDatabaseDefine.DF_DTSET_BRAKEVOLTAGE_SPEC].ToString().Trim();

                    // 出力軸回転方向判定基準_CCW回転指令時(AUX1)
                    stDrvSetting.strDirectionCcw = sdrdTmp[MdlDatabaseDefine.DF_DTSET_DIRECTION_CCW].ToString().Trim();


                    // 出力軸回転方向判定基準_CW回転指令時(AUX2)
                    stDrvSetting.strDirectionCw = sdrdTmp[MdlDatabaseDefine.DF_DTSET_DIRECTION_CW].ToString().Trim();

                    // センサ種別
                    stDrvSetting.strSensorType = sdrdTmp[MdlDatabaseDefine.DF_DTSET_SENSOR_TYPE].ToString().Trim();

                    // TA8110の場合の位置ループゲイン(KP1)_Pno.0x0001
                    stDrvSetting.strTA8110Kp1 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_KP1].ToString().Trim();                  
                    
                    if (stDrvSetting.strTA8110Kp1 != string.Empty)
                        stDrvSetting.strTA8110Kp1 = Convert.ToInt32(stDrvSetting.strTA8110Kp1).ToString("D4");

                    // TA8110の場合の速度ループゲイン(KV1)_Pno.0x0002
                    stDrvSetting.strTA8110Kv1 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_KV1].ToString().Trim();                  
                    
                    if (stDrvSetting.strTA8110Kv1 != string.Empty)
                        stDrvSetting.strTA8110Kv1 = Convert.ToInt32(stDrvSetting.strTA8110Kv1).ToString("D4");

                    // TA8110の場合の位置ループゲイン(KI1)_Pno.0x0003
                    stDrvSetting.strTA8110Ki1 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_KI1].ToString().Trim();                  
                    
                    if (stDrvSetting.strTA8110Ki1 != string.Empty)
                        stDrvSetting.strTA8110Ki1 = Convert.ToInt32(stDrvSetting.strTA8110Ki1).ToString("D4");

                    // TA8110の場合の電流リミット(TLMT1)_Pno.0x0007
                    stDrvSetting.strTA8110TLmt1 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_TLMT1].ToString().Trim();
                    
                    if (stDrvSetting.strTA8110TLmt1 != string.Empty)
                        stDrvSetting.strTA8110TLmt1 = Convert.ToInt32(stDrvSetting.strTA8110TLmt1).ToString("D4");

                    // TA8110の場合のセンサ番号/軸倍角
                    stDrvSetting.strTA8110Pno0060 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_PNO0060].ToString().Trim();          
                    
                    if (stDrvSetting.strTA8110Pno0060 != string.Empty)
                        stDrvSetting.strTA8110Pno0060 = Convert.ToInt32(stDrvSetting.strTA8110Pno0060).ToString("X4");

                    // TA8110の場合の極数
                    stDrvSetting.strTA8110Pno0062 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_PNO0062].ToString().Trim();          
                    
                    if (stDrvSetting.strTA8110Pno0062 != string.Empty)
                        stDrvSetting.strTA8110Pno0062 = Convert.ToInt32(stDrvSetting.strTA8110Pno0062).ToString("D4");

                    // TA8110の場合のロックパターン
                    stDrvSetting.strTA8110Pno0069 = sdrdTmp[MdlDatabaseDefine.DF_DTSET_TA8110_PNO0069].ToString().Trim();          
                    
                    if (stDrvSetting.strTA8110Pno0069 != string.Empty)
                        stDrvSetting.strTA8110Pno0069 = Convert.ToInt32(stDrvSetting.strTA8110Pno0069).ToString("X4");

                    return 1;
                }
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        // -------------------------------------------------------------------------------
        // mDriveTestSetting より 指定機種IDの 設定値を更新する
        // 
        // withBlock:           (i) ドライブ動作確認
        // 
        // 関数値  TRUE=正常終了 / FALSE=異常終了
        // -------------------------------------------------------------------------------
        public static bool gblnDbUpdateDrvTestSetting(MdlDatabaseDefine.ST_DB_DRVTEST_SETTING stDrvSetting)
        {
            int iRinf;
            string strSql = string.Empty;

            SqlCommand scmdTmp = null;

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                // 対象機種IDのレコード有無確認
                strSql = "select count(*) from " + MdlDatabaseDefine.DB_M_DRVTEST_SETTING +
                         " where " + MdlDatabaseDefine.DF_DTSET_MODEL + " = '" + stDrvSetting.strModel + "' and " + MdlDatabaseDefine.DF_DTSET_PCNAME + " = '" + Dns.GetHostName() + "'";

                scmdTmp = new SqlCommand(strSql, gsconDB);

                int cnt = Convert.ToInt32(scmdTmp.ExecuteScalar());

                StringBuilder strCmd = new StringBuilder();

                // レコード作成/更新

                if ((cnt == 0))
                {
                    strCmd.AppendLine("insert into " + MdlDatabaseDefine.DB_M_DRVTEST_SETTING + " ( ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MODEL + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_EDITDTIME + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_PCNAME + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTERCABLE_SPEC + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_SECABLE_SPEC + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DRVMODEL + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_LOW + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_LOW + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_HI + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_HI + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_KEY_ADJUST + ", ");

                    if (stDrvSetting.strMotorSetSpeedKey != string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_KEY + ", ");

                    if (stDrvSetting.strMotorAcLmtKey != string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_KEY + ", ");

                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_BRAKEVOLTAGE_SPEC + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DIRECTION_CCW + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DIRECTION_CW + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_SENSOR_TYPE + ", ");

                    if (stDrvSetting.strTA8110Kp1 != string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KP1 + ", ");

                    if (stDrvSetting.strTA8110Kv1 != string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KV1 + ", ");

                    if (stDrvSetting.strTA8110Ki1 != string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KI1 + ", ");

                    if (stDrvSetting.strTA8110TLmt1 != string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_TLMT1 + ", ");

                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0060 + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0062 + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0069);
                    strCmd.AppendLine(" ) values ( ");
                    strCmd.AppendLine("'" + stDrvSetting.strModel + "', ");
                    // strCmd.AppendLine("'" + Format(Now(), "yyyy/MM/dd HH:mm:ss") + "', ")
                    strCmd.AppendLine("getdate(), ");
                    strCmd.AppendLine("'" + Dns.GetHostName() + "', ");
                    strCmd.AppendLine("'" + stDrvSetting.strMotorCableSpec + "', ");
                    strCmd.AppendLine("'" + stDrvSetting.strSECableSpec + "', ");
                    strCmd.AppendLine("'" + stDrvSetting.strDriverModel + "', ");
                    strCmd.AppendLine(stDrvSetting.strMotorSetSpeedLow + ", ");
                    strCmd.AppendLine(stDrvSetting.strMotorAcLmtLow + ", ");
                    strCmd.AppendLine(stDrvSetting.strMotorSetSpeedHi + ", ");
                    strCmd.AppendLine(stDrvSetting.strMotorAcLmtHi + ", ");
                    strCmd.AppendLine(stDrvSetting.strKeyAdjust + ", ");

                    if (stDrvSetting.strMotorSetSpeedKey != string.Empty)
                        strCmd.AppendLine(stDrvSetting.strMotorSetSpeedKey + ", ");

                    if (stDrvSetting.strMotorAcLmtKey != string.Empty)
                        strCmd.AppendLine(stDrvSetting.strMotorAcLmtKey + ", ");

                    strCmd.AppendLine("'" + stDrvSetting.strBrakeVoltageSpec + "', ");
                    strCmd.AppendLine("'" + stDrvSetting.strDirectionCcw + "', ");
                    strCmd.AppendLine("'" + stDrvSetting.strDirectionCw + "', ");
                    strCmd.AppendLine("'" + stDrvSetting.strSensorType + "', ");

                    if (stDrvSetting.strTA8110Kp1 != string.Empty)
                        strCmd.AppendLine(stDrvSetting.strTA8110Kp1 + ", ");

                    if (stDrvSetting.strTA8110Kv1 != string.Empty)
                        strCmd.AppendLine(stDrvSetting.strTA8110Kv1 + ", ");

                    if (stDrvSetting.strTA8110Ki1 != string.Empty)
                        strCmd.AppendLine(stDrvSetting.strTA8110Ki1 + ", ");

                    if (stDrvSetting.strTA8110TLmt1 != string.Empty)
                        strCmd.AppendLine(stDrvSetting.strTA8110TLmt1 + ", ");

                    strCmd.AppendLine(Convert.ToInt32(stDrvSetting.strTA8110Pno0060, 16).ToString() + ", ");
                    strCmd.AppendLine(Convert.ToInt32(stDrvSetting.strTA8110Pno0062, 10).ToString() + ", ");
                    strCmd.AppendLine(Convert.ToInt32(stDrvSetting.strTA8110Pno0069, 16).ToString());
                    strCmd.AppendLine(" )");
                }
                else
                {
                    strCmd.AppendLine("update " + MdlDatabaseDefine.DB_M_DRVTEST_SETTING + " set ");
                    // strCmd.AppendLine(DF_DTSET_EDITDTIME + " = '" + Format(Now(), "yyyy/MM/dd HH:mm:ss") + "', ")
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_EDITDTIME + " = getdate() , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_PCNAME + " = '" + Dns.GetHostName() + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTERCABLE_SPEC + " = '" + stDrvSetting.strMotorCableSpec + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_SECABLE_SPEC + " = '" + stDrvSetting.strSECableSpec + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DRVMODEL + " = '" + stDrvSetting.strDriverModel + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_LOW + " = " + stDrvSetting.strMotorSetSpeedLow + " , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_LOW + " = " + stDrvSetting.strMotorAcLmtLow + " , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_HI + " = " + stDrvSetting.strMotorSetSpeedHi + " , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_HI + " = " + stDrvSetting.strMotorAcLmtHi + " , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_KEY_ADJUST + " = " + stDrvSetting.strKeyAdjust + " , ");

                    if (stDrvSetting.strMotorSetSpeedKey == string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_KEY + " = NULL , ");
                    else
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_KEY + " = " + stDrvSetting.strMotorSetSpeedKey + " , ");

                    if (stDrvSetting.strMotorAcLmtKey == string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_KEY + " = NULL , ");
                    else
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_KEY + " = " + stDrvSetting.strMotorAcLmtKey + " , ");

                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_BRAKEVOLTAGE_SPEC + " = '" + stDrvSetting.strBrakeVoltageSpec + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DIRECTION_CCW + " = '" + stDrvSetting.strDirectionCcw + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DIRECTION_CW + " = '" + stDrvSetting.strDirectionCw + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_SENSOR_TYPE + " = '" + stDrvSetting.strSensorType + "' , ");

                    if (stDrvSetting.strTA8110Kp1 == string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KP1 + " = NULL , ");
                    else
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KP1 + " = " + stDrvSetting.strTA8110Kp1 + " , ");

                    if (stDrvSetting.strTA8110Kv1 == string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KV1 + " = NULL , ");
                    else
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KV1 + " = " + stDrvSetting.strTA8110Kv1 + " , ");

                    if (stDrvSetting.strTA8110Ki1 == string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KI1 + " = NULL , ");
                    else
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KI1 + " = " + stDrvSetting.strTA8110Ki1 + " , ");

                    if (stDrvSetting.strTA8110TLmt1 == string.Empty)
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_TLMT1 + " = NULL , ");
                    else
                        strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_TLMT1 + " = " + stDrvSetting.strTA8110TLmt1 + " , ");

                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0060 + " = " + (Convert.ToInt32(stDrvSetting.strTA8110Pno0060, 16)).ToString() + " , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0062 + " = " + (Convert.ToInt32(stDrvSetting.strTA8110Pno0062, 10)).ToString() + " , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0069 + " = " + (Convert.ToInt32(stDrvSetting.strTA8110Pno0069, 16)).ToString());
                    strCmd.AppendLine(" where " + MdlDatabaseDefine.DF_DTSET_MODEL + " = '" + stDrvSetting.strModel + "' and " + MdlDatabaseDefine.DF_DTSET_PCNAME + " = '" + Dns.GetHostName() + "'");
                }

                strSql = strCmd.ToString();
                scmdTmp = new SqlCommand(strSql, gsconDB);
                iRinf = scmdTmp.ExecuteNonQuery();

                return true;
            }
            catch
            {
                Close(scmdTmp, null);
                return false;
            }
        }

        // -------------------------------------------------------------------------------
        // dDriverTestSettingBak に 指定機種IDの 設定値を追加する
        // 
        // stDrvSetting:           (i) ドライブ動作確認
        // 
        // 関数値  TRUE=正常終了 / FALSE=異常終了
        // -------------------------------------------------------------------------------
        public static bool gblnDbUpdateDrvTestSettingBak(MdlDatabaseDefine.ST_DB_DRVTEST_SETTING stDrvSetting)
        {

            int iRinf;
            string strSql = string.Empty;

            SqlCommand scmdTmp = null;

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                StringBuilder strCmd = new StringBuilder();

                // レコード作成/更新

                strCmd.AppendLine("insert into " + MdlDatabaseDefine.DB_M_DRVTEST_SETTING_BAK + " ( ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MODEL + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_EDITDTIME + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_PCNAME + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTERCABLE_SPEC + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_SECABLE_SPEC + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DRVMODEL + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_LOW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_LOW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_HI + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_HI + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_KEY_ADJUST + ", ");

                if (stDrvSetting.strMotorSetSpeedKey != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_SETSPEED_KEY + ", ");

                if (stDrvSetting.strMotorAcLmtKey != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_MOTOR_ACLMT_KEY + ", ");

                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_BRAKEVOLTAGE_SPEC + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DIRECTION_CCW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_DIRECTION_CW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_SENSOR_TYPE + ", ");
                
                if (stDrvSetting.strTA8110Kp1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KP1 + ", ");
                
                if (stDrvSetting.strTA8110Kv1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KV1 + ", ");
                
                if (stDrvSetting.strTA8110Ki1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_KI1 + ", ");
                
                if (stDrvSetting.strTA8110TLmt1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_TLMT1 + ", ");
                
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0060 + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0062 + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTSET_TA8110_PNO0069);
                strCmd.AppendLine(" ) values ( ");
                strCmd.AppendLine("'" + stDrvSetting.strModel + "', ");
                // strCmd.AppendLine("'" + Format(Now(), "yyyy/MM/dd HH:mm:ss") + "', ")
                strCmd.AppendLine("getdate(), ");
                strCmd.AppendLine("'" + Dns.GetHostName() + "', ");
                strCmd.AppendLine("'" + stDrvSetting.strMotorCableSpec + "', ");
                strCmd.AppendLine("'" + stDrvSetting.strSECableSpec + "', ");
                strCmd.AppendLine("'" + stDrvSetting.strDriverModel + "', ");
                strCmd.AppendLine(stDrvSetting.strMotorSetSpeedLow + ", ");
                strCmd.AppendLine(stDrvSetting.strMotorAcLmtLow + ", ");
                strCmd.AppendLine(stDrvSetting.strMotorSetSpeedHi + ", ");
                strCmd.AppendLine(stDrvSetting.strMotorAcLmtHi + ", ");
                strCmd.AppendLine(stDrvSetting.strKeyAdjust + ", ");

                if (stDrvSetting.strMotorSetSpeedKey != string.Empty)
                    strCmd.AppendLine(stDrvSetting.strMotorSetSpeedKey + ", ");
                
                if (stDrvSetting.strMotorAcLmtKey != string.Empty)
                    strCmd.AppendLine(stDrvSetting.strMotorAcLmtKey + ", ");
                
                strCmd.AppendLine("'" + stDrvSetting.strBrakeVoltageSpec + "', ");
                strCmd.AppendLine("'" + stDrvSetting.strDirectionCcw + "', ");
                strCmd.AppendLine("'" + stDrvSetting.strDirectionCw + "', ");
                strCmd.AppendLine("'" + stDrvSetting.strSensorType + "', ");
                
                if (stDrvSetting.strTA8110Kp1 != string.Empty)
                    strCmd.AppendLine(stDrvSetting.strTA8110Kp1 + ", ");
                
                if (stDrvSetting.strTA8110Kv1 != string.Empty)
                    strCmd.AppendLine(stDrvSetting.strTA8110Kv1 + ", ");
                
                if (stDrvSetting.strTA8110Ki1 != string.Empty)
                    strCmd.AppendLine(stDrvSetting.strTA8110Ki1 + ", ");
                
                if (stDrvSetting.strTA8110TLmt1 != string.Empty)
                    strCmd.AppendLine(stDrvSetting.strTA8110TLmt1 + ", ");
                
                strCmd.AppendLine(Convert.ToInt32(stDrvSetting.strTA8110Pno0060, 16).ToString() + ", ");
                strCmd.AppendLine(Convert.ToInt32(stDrvSetting.strTA8110Pno0062, 10).ToString() + ", ");
                strCmd.AppendLine(Convert.ToInt32(stDrvSetting.strTA8110Pno0069, 16).ToString());
                strCmd.AppendLine(" )");

                strSql = strCmd.ToString();
                scmdTmp = new SqlCommand(strSql, gsconDB);
                iRinf = scmdTmp.ExecuteNonQuery();

                return true;
            }
            catch
            {
                Close(scmdTmp, null);
                return false;
            }      
        }

        // -------------------------------------------------------------------------------
        // dDriverTest に 検査結果レコードを追加する
        // 
        // stDrvTest:      (i) ドライブ動作確認
        // 
        // 関数値  TRUE=正常終了 / FALSE=異常終了
        // -------------------------------------------------------------------------------
        public static bool gblnDbUpdateDrvTestResult(MdlDatabaseDefine.ST_DB_DRVTEST stDrvTest)
        {
          
            bool blnRinf;
            int iRinf;
            int iRecNum = 0;

            SqlCommand scmdTmp = null;

            // --------------
            // record check
            // --------------
            string strSql = "select count(*) from " + MdlDatabaseDefine.DB_D_DRVTEST + 
                            " where " + MdlDatabaseDefine.DF_DTEST_MODEL + " = '" + stDrvTest.strModel + "' and " + MdlDatabaseDefine.DF_DTEST_BARCODE + " = '" + stDrvTest.strBarcode + "' and " + MdlDatabaseDefine.DF_DTEST_LATESTONE + " = 1";

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                SqlDataReader sdrdTmp = scmdTmp.ExecuteReader();

                blnRinf = sdrdTmp.Read();
                if (sdrdTmp.HasRows == false)
                {
                    sdrdTmp.Close();
                    Close(scmdTmp, null);
                    return false;
                }
                else
                {
                    iRecNum = Convert.ToInt32(sdrdTmp[0].ToString());
                }

                sdrdTmp.Close();

                if (iRecNum != 0)
                {
                    // -------
                    // update 
                    // -------
                    strSql = "update " + MdlDatabaseDefine.DB_D_DRVTEST + " set " + MdlDatabaseDefine.DF_DTEST_LATESTONE + " = 0" +
                             " where " + MdlDatabaseDefine.DF_DTEST_MODEL + " = '" + stDrvTest.strModel + "' and " + MdlDatabaseDefine.DF_DTEST_BARCODE + " = '" + stDrvTest.strBarcode + "' and " + MdlDatabaseDefine.DF_DTEST_LATESTONE + " = 1";

                    scmdTmp = new SqlCommand(strSql, gsconDB);
                    iRinf = scmdTmp.ExecuteNonQuery();
                }

                // -------
                // insert
                // -------
                StringBuilder strCmd = new StringBuilder();

                // レコード作成/更新

                strCmd.AppendLine("insert into " + MdlDatabaseDefine.DB_D_DRVTEST + " ( ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MODEL + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_BARCODE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TESTDTIME + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_LATESTONE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TOTALJUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_PCNAME + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTORCABLE_NO + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_SECABLE_NO + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_DRIVER_MODEL + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_CABLECHK_JUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_BRAKEVOLTAGE_SPEC + ", ");

                if (stDrvTest.strBrakeVoltage != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_BRAKEVOLTAGE + ", ");

                if (stDrvTest.strBrakeVoltageJudge != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_BRAKEVOLTAGE_JUDGE + ", ");

                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_DIRECTION_CCW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_DIRECTION_CCW_JUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_DIRECTION_CW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_DIRECTION_CW_JUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_NOISE_CCWLOW_JUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_NOISE_CWLOW_JUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_NOISE_CCWHI_JUDGE + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_NOISE_CWHI_JUDGE + ", ");

                if (stDrvTest.strKeyAdjustJudge != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_KEYADJUST_JUDGE + ", ");

                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTOR_SETSPEED_LOW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTOR_ACLMT_LOW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTOR_SETSPEED_HI + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTOR_ACLMT_HI + ", ");

                if (stDrvTest.strMotorSetSpeedKey != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTOR_SETSPEED_KEY + ", ");

                if (stDrvTest.strMotorAcLmtKey != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_MOTOR_ACLMT_KEY + ", ");

                if (stDrvTest.strTA8110Kp1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_KP1 + ", ");

                if (stDrvTest.strTA8110Kv1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_KV1 + ", ");

                if (stDrvTest.strTA8110Ki1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_KI1 + ", ");

                if (stDrvTest.strTA8110TLmt1 != string.Empty)
                    strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_TLMT1 + ", ");

                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_PNO0060 + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_PNO0062 + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_DTEST_TA8110_PNO0069);

                strCmd.AppendLine(" ) values ( ");

                strCmd.AppendLine("'" + stDrvTest.strModel + "', ");
                strCmd.AppendLine("'" + stDrvTest.strBarcode + "', ");
                // strCmd.AppendLine("'" + Format(Now(), "yyyy/MM/dd HH:mm:ss") + "', ")
                strCmd.AppendLine("getdate(), ");
                strCmd.AppendLine("1, ");
                strCmd.AppendLine(stDrvTest.strTotalJudge + ", ");
                strCmd.AppendLine("'" + System.Net.Dns.GetHostName() + "', ");
                strCmd.AppendLine("'" + stDrvTest.strMotorCableNo + "', ");
                strCmd.AppendLine("'" + stDrvTest.strSECableNo + "', ");
                strCmd.AppendLine("'" + stDrvTest.strDriverModel + "', ");
                strCmd.AppendLine(stDrvTest.strCableChkJudge + ", ");
                strCmd.AppendLine("'" + stDrvTest.strBrakeVoltageSpec + "', ");

                if (stDrvTest.strBrakeVoltage != string.Empty)
                    strCmd.AppendLine(stDrvTest.strBrakeVoltage + ", ");

                if (stDrvTest.strBrakeVoltageJudge != string.Empty)
                    strCmd.AppendLine(stDrvTest.strBrakeVoltageJudge + ", ");

                strCmd.AppendLine("'" + stDrvTest.strDirectionCcw + "', ");
                strCmd.AppendLine(stDrvTest.strDirectionCcwJudge + ", ");
                strCmd.AppendLine("'" + stDrvTest.strDirectionCw + "', ");
                strCmd.AppendLine(stDrvTest.strDirectionCwJudge + ", ");
                strCmd.AppendLine(stDrvTest.strNoiseCcwLowJudge + ", ");
                strCmd.AppendLine(stDrvTest.strNoiseCwLowJudge + ", ");
                strCmd.AppendLine(stDrvTest.strNoiseCcwHiJudge + ", ");
                strCmd.AppendLine(stDrvTest.strNoiseCwHiJudge + ", ");

                if ((stDrvTest.strKeyAdjustJudge != ""))
                    strCmd.AppendLine(stDrvTest.strKeyAdjustJudge + ", ");

                strCmd.AppendLine(stDrvTest.strMotorSetSpeedLow + ", ");
                strCmd.AppendLine(stDrvTest.strMotorAcLmtLow + ", ");
                strCmd.AppendLine(stDrvTest.strMotorSetSpeedHi + ", ");
                strCmd.AppendLine(stDrvTest.strMotorAcLmtHi + ", ");

                if (stDrvTest.strMotorSetSpeedKey != string.Empty)
                    strCmd.AppendLine(stDrvTest.strMotorSetSpeedKey + ", ");

                if (stDrvTest.strMotorAcLmtKey != string.Empty)
                    strCmd.AppendLine(stDrvTest.strMotorAcLmtKey + ", ");

                if (stDrvTest.strTA8110Kp1 != string.Empty)
                    strCmd.AppendLine(stDrvTest.strTA8110Kp1 + ", ");

                if (stDrvTest.strTA8110Kv1 != string.Empty)
                    strCmd.AppendLine(stDrvTest.strTA8110Kv1 + ", ");

                if (stDrvTest.strTA8110Ki1 != string.Empty)
                    strCmd.AppendLine(stDrvTest.strTA8110Ki1 + ", ");

                if (stDrvTest.strTA8110TLmt1 != string.Empty)
                    strCmd.AppendLine(stDrvTest.strTA8110TLmt1 + ", ");

                strCmd.AppendLine((Convert.ToInt32(stDrvTest.strTA8110Pno0060, 16)).ToString() + ", ");
                strCmd.AppendLine((Convert.ToInt32(stDrvTest.strTA8110Pno0062, 10)).ToString() + ", ");
                strCmd.AppendLine((Convert.ToInt32(stDrvTest.strTA8110Pno0069, 16)).ToString());
                strCmd.AppendLine(" )");


                strSql = strCmd.ToString();
                scmdTmp = new SqlCommand(strSql, gsconDB);
                iRinf = scmdTmp.ExecuteNonQuery();

                return true;
            }
            catch
            {
                Close(scmdTmp, null);
                return false;
            }
        }

        // -------------------------------------------------------------------------------
        // mCableMaintenance より 指定ケーブルNo.の ケーブル管理情報を１件取得する
        // 
        // strCableNo:             (i) ケーブルNo.
        // ST_CABLE_MAINTENANCE:   (o) ケーブル管理情報
        // 
        // 関数値  正=取得レコード数 / 負=異常終了
        // -------------------------------------------------------------------------------
        public static int giDbGetCableMaintenanceData(string strCableNo, ref MdlDatabaseDefine.ST_DB_CABLE_MAINTENANCE stCableMainteData)
        {
            bool blnRinf;

            SqlCommand scmdTmp = null;
            SqlDataReader sdrdTmp = null;

            string strSql = "select * from " + MdlDatabaseDefine.DB_M_CABLE_MAINTENANCE +
                            " where " + MdlDatabaseDefine.DF_CABLE_CABLENO + " = '" + strCableNo + "'";

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                sdrdTmp = scmdTmp.ExecuteReader();

                blnRinf = sdrdTmp.Read();
                if (sdrdTmp.HasRows == false)
                {
                    Close(scmdTmp, sdrdTmp);
                    return 0;
                }
                else
                {
                    stCableMainteData.strCableNo = sdrdTmp[MdlDatabaseDefine.DF_CABLE_CABLENO].ToString().Trim();                       // ケーブルNo.
                    stCableMainteData.strUsageCountMax = sdrdTmp[MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_MAX].ToString().Trim();         // ケーブル使用回数許容上限値
                    stCableMainteData.strUsageCountNow = sdrdTmp[MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_NOW].ToString().Trim();         // ケーブル使用回数
                    stCableMainteData.strResetDTime = sdrdTmp[MdlDatabaseDefine.DF_CABLE_RESETDTIME].ToString();                        // ケーブル使用回数リセット日時

                    return 1;
                }
            }
            catch
            {
                Close(scmdTmp, sdrdTmp);
                return -1;
            }
        }

        // -------------------------------------------------------------------------------
        // mCableMaintenance に 指定ケーブルNo.の 管理情報を更新する
        // 
        // stCableMainteData:           (i) ケーブル管理情報
        // 
        // 関数値  TRUE=正常終了 / FALSE=異常終了
        // -------------------------------------------------------------------------------
        public static bool gblnDbUpdateCableMaintenanceData(MdlDatabaseDefine.ST_DB_CABLE_MAINTENANCE stCableMainteData)
        {
            int iRinf;
            string strSql = string.Empty;
            
            SqlCommand scmdTmp = null;

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                // 対象機種IDのレコード有無確認
                strSql = "select count(*) from " + MdlDatabaseDefine.DB_M_CABLE_MAINTENANCE +
                         " where " + MdlDatabaseDefine.DF_CABLE_CABLENO + " = '" + stCableMainteData.strCableNo + "'";

                scmdTmp = new SqlCommand(strSql, gsconDB);

                int cnt = Convert.ToInt32(scmdTmp.ExecuteScalar());

                StringBuilder strCmd = new StringBuilder();

                // レコード作成/更新


                if (cnt == 0)
                {
                    strCmd.AppendLine("insert into " + MdlDatabaseDefine.DB_M_CABLE_MAINTENANCE + " ( ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_CABLENO + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_EDITDTIME + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_MAX + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_NOW + ", ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_RESETDTIME);
                    strCmd.AppendLine(" ) values ( ");
                    strCmd.AppendLine("'" + stCableMainteData.strCableNo + "', ");
                    strCmd.AppendLine("getdate(), ");
                    strCmd.AppendLine("'" + stCableMainteData.strUsageCountMax + "', ");
                    strCmd.AppendLine("'" + stCableMainteData.strUsageCountNow + "', ");
                    strCmd.AppendLine("getdate() ");
                    strCmd.AppendLine(" )");
                }
                else
                {
                    strCmd.AppendLine("update " + MdlDatabaseDefine.DB_M_CABLE_MAINTENANCE + " set ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_EDITDTIME + " = getdate() , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_MAX + " = '" + stCableMainteData.strUsageCountMax + "' , ");
                    strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_NOW + " = '" + stCableMainteData.strUsageCountNow + "'");

                    if ((stCableMainteData.strUsageCountNow == "0"))
                        strCmd.AppendLine(" , " + MdlDatabaseDefine.DF_CABLE_RESETDTIME + " = getdate()");

                    strCmd.AppendLine(" where " + MdlDatabaseDefine.DF_CABLE_CABLENO + " = '" + stCableMainteData.strCableNo + "'");
                }

                strSql = strCmd.ToString();
                scmdTmp = new SqlCommand(strSql, gsconDB);
                iRinf = scmdTmp.ExecuteNonQuery();

                return true;
            }
            catch
            {
                Close(scmdTmp, null);
                return false;
            }
        }

        // -------------------------------------------------------------------------------
        // dCableMaintenanceBak に 指定ケーブルNo.の 管理情報を更新する
        // 
        // stCableMainteData:           (i) ケーブル管理情報
        // 
        // 関数値  TRUE=正常終了 / FALSE=異常終了
        // -------------------------------------------------------------------------------
        public static bool gblnDbUpdateCableMaintenanceDataBak(MdlDatabaseDefine.ST_DB_CABLE_MAINTENANCE stCableMainteData)
        {
           
            int iRinf;
            string strSql = string.Empty;

            SqlCommand scmdTmp = null;

            try
            {
                scmdTmp = new SqlCommand(strSql, gsconDB);
                gsconDB.Open();

                StringBuilder strCmd = new System.Text.StringBuilder();

                // レコード作成/更新
                strCmd.AppendLine("insert into " + MdlDatabaseDefine.DB_M_CABLE_MAINTENANCE_BAK + " ( ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_CABLENO + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_EDITDTIME + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_MAX + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_USAGE_COUNT_NOW + ", ");
                strCmd.AppendLine(MdlDatabaseDefine.DF_CABLE_RESETDTIME);
                strCmd.AppendLine(" ) values ( ");
                strCmd.AppendLine("'" + stCableMainteData.strCableNo + "', ");
                strCmd.AppendLine("getdate(), ");
                strCmd.AppendLine("'" + stCableMainteData.strUsageCountMax + "', ");
                strCmd.AppendLine("'" + stCableMainteData.strUsageCountNow + "', ");
                strCmd.AppendLine("'" + stCableMainteData.strResetDTime + "'");
                strCmd.AppendLine(" )");

                strSql = strCmd.ToString();
                scmdTmp = new SqlCommand(strSql, gsconDB);
                iRinf = scmdTmp.ExecuteNonQuery();

                return true;
            }
            catch
            {
                Close(scmdTmp, null);
                return false;
            }
        }

        private static void Close(SqlCommand _scmdTmp, SqlDataReader _sdrdTmp)
        {
            if (_sdrdTmp != null)
            {
                if (_sdrdTmp != null)
                    _sdrdTmp.Close();
            }

            if (_scmdTmp != null)
                _scmdTmp.Dispose();

            if (gsconDB.State != System.Data.ConnectionState.Closed)
                gsconDB.Close();
        }
    }
}
