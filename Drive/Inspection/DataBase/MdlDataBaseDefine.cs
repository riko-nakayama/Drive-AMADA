using System.Collections.Generic;

namespace Motion_Designer
{
    static public class MdlDatabaseDefine
    {

        // -----------
        // table name
        // -----------

        // master tables
        public const string DB_M_SPEC = "mSpec";
        public const string DB_M_DRVTEST_SETTING = "mDriverTestSetting";
        public const string DB_M_DRVTEST_SETTING_BAK = "mDriverTestSettingBak";           // #1
        public const string DB_M_CABLE_MAINTENANCE = "mCableMaintenance";
        public const string DB_M_CABLE_MAINTENANCE_BAK = "mCableMaintenanceBak";          // #1

        public const string DB_M_OPERATOR_LIST = "mOperatorList";
        public const string DB_M_OPERATOR_LIST_BAK = "mOperatorListBak";
        public const string DB_M_RETRY_REASON = "mRetryReason";
        public const string DB_M_RETRY_REASON_BAK = "mRetryReasonBak";
        public const string DB_M_MACHINE_LIST = "mMachineList";
        public const string DB_M_MACHINE_LIST_BAK = "mMachineListBak";
        public const string DB_M_SPEC_LIST = "mSpecList";
        public const string DB_M_SPEC_LIST_BAK = "mSpecListBak";
        public const string DB_M_MACHINE_SPEC_LIST = "mMachineSpecList";
        public const string DB_M_MACHINE_SPEC_LIST_BAK = "mMachineSpecListBak";
        public const string DB_M_TEST_SETTING = "mTestSetting";
        public const string DB_M_TEST_SETTING_BAK = "mTestSettingBak";

        // data tables
        public const string DB_D_FINAL = "dFinal";
        public const string DB_D_DRVTEST = "dDriverTest";

        // -----------
        // structures
        // -----------

        // mSpec
        public struct ST_DB_SPEC
        {
            public string strEditDTime;                          // レコード更新日時
            public string strModel;                              // モータ形式
            public string strModelID;                            // 機種ID モータ形式を3桁で表現したもの、keyとしないがユニークである。
            public string strKeSpec;                             // 誘起電圧：仕様値 [V]    1000rpmでの電圧を設定
            public string strKeTolPerctNega;                     // 誘起電圧：許容範囲（－側パーセント） [%]
            public string strKeTolPerctPosi;                     // 誘起電圧：許容範囲（＋側パーセント） [%]
            public string strRaSpec;                             // 電機子抵抗：仕様値 [Ω]      Raで設定のこと、一部図面でRl が記載されているので注意 ( Ra=1.5*Rl )
            public string strRaTolPerctNega;                     // 電機子抵抗：許容範囲（－側パーセント） [%]
            public string strRaTolPerctPosi;                     // 電機子抵抗：許容範囲（＋側パーセント） [%]
            public string struvwDevTolPerctMax;                  // 電機子抵抗：各層の振れ： 判定基準： 許容最大値 [%]
            public string strLaSpec;                             // インダクタンス：仕様値 [mH]
            public string strLaTolPerctNega;                     // インダクタンス：許容範囲（－側パーセント） [%] 
            public string strLaTolPerctPosi;                     // インダクタンス：許容範囲（＋側パーセント） [%]
        }


        // mDriverTestSetting
        public struct ST_DB_DRVTEST_SETTING
        {
            public string strModel;                              // モータ型式
            public string strMotorCableSpec;                     // ドライバ動作確認試験装置用 モータ中継ケーブルNo(採番仕様は3桁)[接続ポカよけ照合元]
            public string strSECableSpec;                        // ドライバ動作確認試験装置用 センサ中継ケーブルNo(採番仕様は3桁)[接続ポカよけ照合元]
            public string strDriverModel;                        // ドライバ動作確認試験装置用 接続ドライバ形式(最大16桁)[接続ポカよけ照合元]
            public string strMotorSetSpeedLow;                   // 低速回転_速度指定[rpm]
            public string strMotorAcLmtLow;                      // 低速回転_加速度制限設定[x10rpm/s]
            public string strMotorSetSpeedHi;                    // 高速回転_速度指定[rpm]
            public string strMotorAcLmtHi;                       // 高速回転_加速度制限設定[x10rpm/s]
            public string strKeyAdjust;                          // キー合わせ工程有無： 0=工程なし/1=あり
            public string strMotorSetSpeedKey;                   // キー合わせ回転_速度指定[rpm]
            public string strMotorAcLmtKey;                      // キー合わせ回転_加速度制限設定[x10rpm/s]
            public string strBrakeVoltageSpec;                   // ブレーキ電圧規格値[V] なし：non
            public string strDirectionCcw;                       // 出力軸回転方向判定基準_CCW回転指令時(AUX1)
            public string strDirectionCw;                        // 出力軸回転方向判定基準_CW回転指令時(AUX2)
            public string strSensorType;                         // センサ種別
            public string strTA8110Kp1;                          // TA8110の場合の位置ループゲイン(KP1)_Pno.0x0001
            public string strTA8110Kv1;                          // TA8110の場合の速度ループゲイン(KV1)_Pno.0x0002
            public string strTA8110Ki1;                          // TA8110の場合の位置ループゲイン(KI1)_Pno.0x0003
            public string strTA8110TLmt1;                        // TA8110の場合の電流リミット(TLMT1)_Pno.0x0007
            public string strTA8110Pno0060;                      // TA8110の場合のセンサ番号/軸倍角
            public string strTA8110Pno0062;                      // TA8110の場合の極数
            public string strTA8110Pno0069;                      // TA8110の場合のロックパターン
        }


        // mCableMaintenance
        public struct ST_DB_CABLE_MAINTENANCE
        {
            public string strCableNo;                            // ケーブルNo.
            public string strUsageCountMax;                      // ケーブル使用回数許容上限値
            public string strUsageCountNow;                      // ケーブル使用回数
            public string strResetDTime;                         // ケーブル使用回数リセット日時
        }


        // dFinal
        public struct ST_DB_FINAL
        {
            public string strModel;                              // モータ形式
            public string strBarcode;                            // データ管理番号(採番仕様では11桁)
            public string strTestDTime;                          // 試験日時(レコード作成時、更新時に書き換え)
            public string strTotalJudge;                         // [将来用]総合判定： 合格=1 / 不合格=0 / 未試験=-1
            public string strPCName;                             // [将来用]試験を実施(SerialNoを登録)した計算機名 領域に収まるようtrimのこと。
            public string strSerialNo;                           // [将来用]製品シリアル番号
            public string strProductionNo;                       // [将来用]工事番号
        }


        // dDriverTest
        public struct ST_DB_DRVTEST
        {
            public string strModel;                              // モータ形式
            public string strBarcode;                            // データ管理番号
            public string strTotalJudge;                         // 総合判定： 合格=1 / 不合格=0
            public string strMotorCableNo;                       // 使用したモータケーブルNo.(採番仕様は5桁)
            public string strSECableNo;                          // 使用したセンサケーブルNo.(採番仕様は5桁)
            public string strDriverModel;                        // 使用したドライバ形式
            public string strCableChkJudge;                      // 段替え時の接続ケーブルチェック判定： 合格=1 / 不合格=0
            public string strBrakeVoltageSpec;                   // ブレーキ電圧規格値[V] なし：non
            public string strBrakeVoltage;                       // マルチメータで測定された、ブレーキ電圧[V]
            public string strBrakeVoltageJudge;                  // ブレーキ電圧確認判定： 合格=1 / 不合格=0
            public string strDirectionCcw;                       // 出力軸回転方向判定基準_CCW回転指令時(AUX1)
            public string strDirectionCcwJudge;                  // 出力軸回転方向CCW指令 ： 判定： 合格=1 / 不合格=0
            public string strDirectionCw;                        // 出力軸回転方向判定基準_CW回転指令時(AUX2)
            public string strDirectionCwJudge;                   // 出力軸回転方向CW指令 ： 判定： 合格=1 / 不合格=0
            public string strNoiseCcwLowJudge;                   // 低速回転CCW 異音判定： 合格=1 / 不合格=0
            public string strNoiseCwLowJudge;                    // 低速回転CW 異音判定： 合格=1 / 不合格=0
            public string strNoiseCcwHiJudge;                    // 高速回転CCW 異音判定： 合格=1 / 不合格=0
            public string strNoiseCwHiJudge;                     // 高速回転CW 異音判定： 合格=1 / 不合格=0
            public string strKeyAdjustJudge;                     // キー合わせ判定： 合格=1 / 不合格=0
            public string strMotorSetSpeedLow;                   // 低速回転_速度指定[rpm]
            public string strMotorAcLmtLow;                      // 低速回転_加速度制限設定[x10rpm/s]
            public string strMotorSetSpeedHi;                    // 高速回転_速度指定[rpm]
            public string strMotorAcLmtHi;                       // 高速回転_加速度制限設定[x10rpm/s]
            public string strMotorSetSpeedKey;                   // キー合わせ回転_速度指定[rpm]
            public string strMotorAcLmtKey;                      // キー合わせ回転_加速度制限設定[x10rpm/s]
            public string strTA8110Kp1;                          // TA8110の場合の位置ループゲイン(KP1)_Pno.0x0001
            public string strTA8110Kv1;                          // TA8110の場合の速度ループゲイン(KV1)_Pno.0x0002
            public string strTA8110Ki1;                          // TA8110の場合の位置ループゲイン(KI1)_Pno.0x0003
            public string strTA8110TLmt1;                        // TA8110の場合の電流リミット(TLMT1)_Pno.0x0007
            public string strTA8110Pno0060;                      // TA8110の場合のセンサ番号/軸倍角
            public string strTA8110Pno0062;                      // TA8110の場合の極数
            public string strTA8110Pno0069;                      // TA8110の場合のロックパターン
        }


        // mTestSetting
        public struct ST_DB_TEST_SETTING
        {
            public string strModel;                              // モータ形式
            public string strEditDTime;                          // レコード更新日時
            public string strTestNo;                             // 試験順序番号
            public string strSpecNo;                             // 試験項目番号
            public string strJudgeEnable;                        // 判定フラグ
            public string strFirstLotEnable;                     // 初品フラグ
            public string strPrintDetailEnable;                  // 詳細印刷フラグ
            public string strRetryEnable;                        // 再試験可否フラグ
            public string strTestCondition;                      // 試験条件
            public string strSpecValueLo;                        // 数値組立管理規格Lo
            public string strSpecValueHi;                        // 数値組立管理規格Hi
            public string strSpecValueLo1;                       // 数値仕様規格Lo
            public string strSpecValueHi1;                       // 数値仕様規格Hi
            public string strSpecValueUnit;                      // 数値単位
            public string strSpecValueType;                      // 数値種別
            public string strSpecValueDecimalPoint;              // 数値少数点以下桁数
            public string strSpecValueBitNum;                    // HEX数値ビット数

            public string strSpecTextLenMax;                     // 文字列長さ下限
            public string strSpecTextLenMin;                     // 文字列長さ上限
            public string strSpecTextCompare;                    // 照合文字列

            public string strPrintMode;                          // 印刷モード
            public string strPrintNormalFile;                    // 標準印刷ファイル名
            public string strPrintDetailFile;                    // 詳細印刷ファイル名
        }

        // dResult
        public struct ST_DB_RESULT
        {
            public string strModel;                              // モータ形式
            public string strBarcode;                            // バーコード
            public string strBarcode1;                           // 作業指示書バーコード(先頭工程のみ)
            public string strBarcode2;                           // ロータ用バーコード(先頭工程のみ)
            public string strTestDTime;                          // レコード更新日時
            public string strLastOne;                            // 最終実施レコードフラグ

            public string strResultJudge;                        // 総合判定
            public string strPCName;                             // 試験実施したPC名
            public string strInputValue;                         // 試験結果データ
            public string strInputComment;                       // 試験時コメント
            public string strInputRetryReason;                   // 再試験理由

            public string strTestNo;                             // 試験順序番号

            public string strSpecNo;                             // 試験項目番号
            public string strProcName;                           // 工程名
            public string strSpecName;                           // 試験項目名
            public string strSpecType;                           // 試験項目種別

            public string strMachineNo;                          // 装置番号
            public string strMachineName;                        // 装置名
            public string strMachineType;                        // 装置種別

            public string strOperatorCode;                       // オペレータコード
            public string strOperatorName;                       // オペレータ氏名
            public string strOperatorCode1;                      // オペレータコード
            public string strOperatorName1;                      // オペレータ氏名
            public string strOperatorCode2;                      // オペレータコード
            public string strOperatorName2;                      // オペレータ氏名

            public string strJudgeEnable;                        // 判定フラグ
            public string strFirstLotEnable;                     // 初品フラグ
            public string strPrintDetailEnable;                  // 詳細印刷フラグ
            public string strRetryEnable;                        // 再試験可否フラグ
            public string strTestCondition;                      // 試験条件
            public string strSpecValueLo;                        // 数値組立管理規格Lo
            public string strSpecValueHi;                        // 数値組立管理規格Hi
            public string strSpecValueLo1;                       // 数値仕様規格Lo
            public string strSpecValueHi1;                       // 数値仕様規格Hi
            public string strSpecValueUnit;                      // 数値単位
            public string strSpecValueType;                      // 数値種別
            public string strSpecValueDecimalPoint;              // 数値少数点以下桁数
            public string strSpecValueBitNum;                    // HEX数値ビット数

            public string strSpecTextLenMax;                     // 文字列長さ下限
            public string strSpecTextLenMin;                     // 文字列長さ上限
            public string strSpecTextCompare;                    // 照合文字列

            public string strPrintMode;                          // 印刷モード
            public string strPrintNormalFile;                    // 標準印刷ファイル名
            public string strPrintDetailFile;                    // 詳細印刷ファイル名
        }


        // 汎用
        public struct ST_DB_QUERY
        {
            public List<string> field_name;
            public List<string> data_record;
        }

        // -----------
        // fieldname
        // -----------

        // mSpec
        public const string DF_SPEC_EDITDTIME = "EditDTime";
        public const string DF_SPEC_MODEL = "Model";
        public const string DF_SPEC_MODELID = "ModelID";
        public const string DF_SPEC_KE_SPEC = "KeSpec";
        public const string DF_SPEC_KE_TOLPERCT_NEGA = "KeTolPerctNega";
        public const string DF_SPEC_KE_TOLPERCT_POSI = "KeTolPerctPosi";
        public const string DF_SPEC_RA_SPEC = "RaSpec";
        public const string DF_SPEC_RA_TOLPERCT_NEGA = "RaTolPerctNega";
        public const string DF_SPEC_RA_TOLPERCT_POSI = "RaTolPerctPosi";
        public const string DF_SPEC_UVWDEV_TOLPERCT_MAX = "uvwDevTolPerctMax";
        public const string DF_SPEC_LA_SPEC = "LaSpec";
        public const string DF_SPEC_LA_TOLPERCT_NEGA = "LaTolPerctNega";
        public const string DF_SPEC_LA_TOLPERCT_POSI = "LaTolPerctPosi";


        // mDriverTestSetting
        public const string DF_DTSET_MODEL = "Model";
        public const string DF_DTSET_EDITDTIME = "EditDTime";
        public const string DF_DTSET_PCNAME = "PCName";
        public const string DF_DTSET_MOTERCABLE_SPEC = "MotorCableSpec";
        public const string DF_DTSET_SECABLE_SPEC = "SECableSpec";
        public const string DF_DTSET_DRVMODEL = "DriverModel";
        public const string DF_DTSET_MOTOR_SETSPEED_LOW = "MotorSetSpeedLow";
        public const string DF_DTSET_MOTOR_ACLMT_LOW = "MotorAcLmtLow";
        public const string DF_DTSET_MOTOR_SETSPEED_HI = "MotorSetSpeedHi";
        public const string DF_DTSET_MOTOR_ACLMT_HI = "MotorAcLmtHi";
        public const string DF_DTSET_KEY_ADJUST = "KeyAdjust";
        public const string DF_DTSET_MOTOR_SETSPEED_KEY = "MotorSetSpeedKey";
        public const string DF_DTSET_MOTOR_ACLMT_KEY = "MotorAcLmtKey";
        public const string DF_DTSET_BRAKEVOLTAGE_SPEC = "BrakeVoltageSpec";
        public const string DF_DTSET_DIRECTION_CCW = "DirectionCcw";
        public const string DF_DTSET_DIRECTION_CW = "DirectionCw";
        public const string DF_DTSET_SENSOR_TYPE = "SensorType";
        public const string DF_DTSET_TA8110_KP1 = "TA8110Kp1";
        public const string DF_DTSET_TA8110_KV1 = "TA8110Kv1";
        public const string DF_DTSET_TA8110_KI1 = "TA8110Ki1";
        public const string DF_DTSET_TA8110_TLMT1 = "TA8110TLMT1";
        public const string DF_DTSET_TA8110_PNO0060 = "TA8110Pno0060";
        public const string DF_DTSET_TA8110_PNO0062 = "TA8110Pno0062";
        public const string DF_DTSET_TA8110_PNO0069 = "TA8110Pno0069";


        // mCableMaintenance
        public const string DF_CABLE_CABLENO = "CableNo";
        public const string DF_CABLE_EDITDTIME = "EditDTime";
        public const string DF_CABLE_USAGE_COUNT_MAX = "UsageCountMax";
        public const string DF_CABLE_USAGE_COUNT_NOW = "UsageCountNow";
        public const string DF_CABLE_RESETDTIME = "ResetDTime";


        // dFinal
        public const string DF_FINAL_MODEL = "Model";
        public const string DF_FINAL_BARCODE = "Barcode";
        public const string DF_FINAL_TESTDTIME = "TestDTime";
        public const string DF_FINAL_TOTALJUDGE = "TotalJudge";
        public const string DF_FINAL_PCNAME = "PCName";
        public const string DF_FINAL_SERIALNO = "SerialNo";
        public const string DF_FINAL_PRODUCTIONNO = "ProductionNo";


        // dDriverTest
        public const string DF_DTEST_MODEL = "Model";
        public const string DF_DTEST_BARCODE = "Barcode";
        public const string DF_DTEST_TESTDTIME = "TestDTime";
        public const string DF_DTEST_LATESTONE = "LatestOne";
        public const string DF_DTEST_TOTALJUDGE = "TotalJudge";
        public const string DF_DTEST_PCNAME = "PCName";
        public const string DF_DTEST_MOTORCABLE_NO = "MotorCableNo";
        public const string DF_DTEST_SECABLE_NO = "SECableNo";
        public const string DF_DTEST_DRIVER_MODEL = "DriverModel";
        public const string DF_DTEST_CABLECHK_JUDGE = "CableChkJudge";
        public const string DF_DTEST_BRAKEVOLTAGE_SPEC = "BrakeVoltageSpec";
        public const string DF_DTEST_BRAKEVOLTAGE = "BrakeVoltage";
        public const string DF_DTEST_BRAKEVOLTAGE_JUDGE = "BrakeVoltageJudge";
        public const string DF_DTEST_DIRECTION_CCW = "DirectionCcw";
        public const string DF_DTEST_DIRECTION_CCW_JUDGE = "DirectionCcwJudge";
        public const string DF_DTEST_DIRECTION_CW = "DirectionCw";
        public const string DF_DTEST_DIRECTION_CW_JUDGE = "DirectionCwJudge";
        public const string DF_DTEST_NOISE_CCWLOW_JUDGE = "NoiseCcwLowJudge";
        public const string DF_DTEST_NOISE_CWLOW_JUDGE = "NoiseCwLowJudge";
        public const string DF_DTEST_NOISE_CCWHI_JUDGE = "NoiseCcwHiJudge";
        public const string DF_DTEST_NOISE_CWHI_JUDGE = "NoiseCwHiJudge";
        public const string DF_DTEST_KEYADJUST_JUDGE = "KeyAdjustJudge";
        public const string DF_DTEST_MOTOR_SETSPEED_LOW = "MotorSetSpeedLow";
        public const string DF_DTEST_MOTOR_ACLMT_LOW = "MotorAcLmtLow";
        public const string DF_DTEST_MOTOR_SETSPEED_HI = "MotorSetSpeedHi";
        public const string DF_DTEST_MOTOR_ACLMT_HI = "MotorAcLmtHi";
        public const string DF_DTEST_MOTOR_SETSPEED_KEY = "MotorSetSpeedKey";
        public const string DF_DTEST_MOTOR_ACLMT_KEY = "MotorAcLmtKey";
        public const string DF_DTEST_TA8110_KP1 = "TA8110Kp1";
        public const string DF_DTEST_TA8110_KV1 = "TA8110Kv1";
        public const string DF_DTEST_TA8110_KI1 = "TA8110Ki1";
        public const string DF_DTEST_TA8110_TLMT1 = "TA8110TLMT1";
        public const string DF_DTEST_TA8110_PNO0060 = "TA8110Pno0060";
        public const string DF_DTEST_TA8110_PNO0062 = "TA8110Pno0062";
        public const string DF_DTEST_TA8110_PNO0069 = "TA8110Pno0069";


        // -----------
        // value
        // -----------
        public const string DBTEXT_SENSORTYPE_17BIT_ABS_INC = "17bit-ABS/INC";
        public const string DBTEXT_SENSORTYPE_RESOLVER = "レゾルバ";
        public const string DBTEXT_SENSORTYPE_INC = "INC-SE";
        public const string DBTEXT_BRAKECHECK_NONE = "non";
    }
}