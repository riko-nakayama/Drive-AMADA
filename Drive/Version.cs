
namespace Motion_Designer
{
    class Version
    {
        /// <summary>
        ///		・バージョン管理開始	20160128
        /// 
        ///		■■■■■VER.0.10リリース20160128■■■■■
        /// 
        ///     ■■■■■VER.0.20リリース20160304■■■■■
        #region VER.0.20
        ///     ・中国言語リソース対応
        /// 
        ///		1.	CtlJogCntrol.cs
        ///			目標速度初期値変更。500→100
        ///			加速度減速度初期値変更。500→100
        ///			TargetVelocityプロパティ追加。									//20160315 update
        /// 
        ///		2.	JogControlForm.cs
        ///			制御モード切り替え時に目標速度変更処理追加。
        ///			電流制御モードに切り替ったら0とする。							//20160315 update
        /// 
        ///		3.	AutoTuningForm.cs
        ///			負荷推定動作パターン変更機能追加。								//20160315 update
        /// 
        ///		4.	AutoTuningAdjust.cs
        ///			振動検出後の初期ゲイン再設定時に速度オブザーバ設定追加。		//20160315 update
        /// 
        ///		5.	DigitalOsilloForm.cs
        ///			時間計測が表示されない件、lblTimeMeas2の表示を最前面に変更。	//20160317 update
        ///			
        ///		6.	ParameterForm.cs
        ///			読み込み専用ID書き込み時に、
        ///			プログレスバーが表示される件を修正。							//20160328 update
        ///			
        ///		7.	CtlJogControl.cs
        ///			位置制御動作中に目標速度が”0”に設定されたら、
        ///			動作停止（タイマ停止）する処理を追加。							//20160328 add
        /// 
        ///		8.	CtlJogControl.cs
        ///			位置制御時に目標速度入力コントロールの符号を無効化。
        ///			位置制御時の目標速度を絶対値設定とする。						//20160328 add
        /// 
        ///		9.	JogControlForm.cs
        ///			フォームロード時にViewCultureResouceChanged()で、
        ///			制御モードが”制御無し”に強制的に変更される件を修正。			//20160328 update
        /// 
        ///		10.	GainControlForm.cs
        ///			USB切断状態でゲインコントロールの値を変更した後、
        ///			USB接続後にゲイン値が更新されない件を修正。						//20160328 update
        /// 
        ///		11.	AutoTuningAdjust.cs WizardForm.cs
        ///			オートチューニング設定で移動距離が短い時に、
        ///			設定エラーとなる件を修正。										//20160329 del
        /// 
        ///		12.	AutoTuningAdjust.cs
        ///			初期ゲイン見直し。
        ///			ベルト機構時に初期ゲイン、ゲイン上昇幅1/2設定。					//20160329 update
        #endregion
        ///     ■■■■■VER.0.21リリース20160329■■■■■
        #region VER.0.21
        ///		1.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			初期ゲイン見直し。
        ///			初期ゲイン、ゲイン上昇数の初期設定値に、
        ///			負荷イナーシャ比と機構毎のパラメータを追加。
        ///			イナーシャ比5倍まで係数1（初期ゲインのまま）。
        ///			機構毎に係数変更。ベルトのみ0.5．								//20160330 update
        /// 
        ///		2.	AutoTuningAdjust.cs
        ///			listInvalidNF<>型変更。<int>→<FFT_Member>
        ///			ノッチフィルタ再構成後に再度フィルタ設定可能とした。			//20160330 update
        /// 
        ///		3.	AutoTuningForm.cs WizardForm.cs
        ///			ティーチングゲイン修正。
        ///			ティーチング画面起動時＋イナーシャ大時に、
        ///			異音発生する件の対策。											//20160330 update
        /// 
        ///		4.	AutoTuningAdjust.cs
        ///			電流振動検出時に前回アクションがノッチフィルタ設定の場合、
        ///			ノッチフィルタ再構成（無効）して調整再開する処理を追加。		//20160330 update
        /// 
        ///		5.	AutoTuningAdjust.cs
        ///			ノッチフィルタ再構成が無限に続く件の対策。
        ///			3回連続で再構成が発生した場合は、再構成を無視する。				//20160330 add
        /// 
        ///		6.	ParameterForm.cs
        ///			ID：6番通信速度変更出来ない件を修正。							//20160401 update
        /// 
        ///		7.	GainControlForm.cs
        ///			位置FFのMax値を誤記修正。500%→100%。							//20160404 update
        /// 
        ///		8.	DigitalOsilloForm.cs
        ///			画像保存のフォーマット識別修正。
        ///			saveFileDialog1.FilterIndexの判定文を修正。						//20160404 update
        /// 
        ///		9.	ManualNavigatorForm.cs
        ///			マニュアルNaviフォーム追加。中国語設定。
        ///			TAD8811取扱説明書（日本語）リンク追加。							//20160404 add
        /// 
        ///		10.	WizardForm.cs
        ///			オートチューニングウィザードから自動摩擦補正調整タブを削除。	//20160404 del
        /// 
        ///		11.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			SetAutoTuningSq()、ClearAutoTuningSq()追加。					//20160405 update
        /// 
        ///		12.	AutoTuningForm.cs
        ///			ServoErrorCounter追加。
        ///			オートチューニング中のサーボオフ誤検出対策。					//20160405 add
        /// 
        ///		13.	AutoTuningAdjust.cs
        ///			InitLoadGain()見直し。
        ///			ティーチング後の初期ゲイン最適化の為。							//20160405 update
        /// 
        ///		14.	AutoTuningAdjust.cs
        ///			オートチューニング開始時に位置偏差エラー範囲設定を廃止。
        ///			ユーザーが設定するパラメータの為。								//20160405 del
        /// 
        ///		15.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			負荷イナーシャ推定、ゲイン調整、周波数スイープ、テスト運転
        ///			開始時のサーボオン処理後に500msec待ち追加。
        ///			ブレーキ付きモータの解放時間待ち対応。							//20160406 add
        ///			
        ///		16.	MainForm.cs CMonitor.cs AutoTuningForm.cs
        ///			レゾルバ分解能追加。（2X,4X,5X,8X）								//20160406 update
        /// 
        ///		17.	AutoTuningForm.cs
        ///			負荷イナーシャ仮推定後に1sec待ち追加。
        ///			仮推定後の初回の負荷イナーシャ値が安定しない為。				//20160406 add
        /// 
        ///		18.	DigitalOsilloForm.cs
        ///			トリガ有効時もリアルタイムFFTを有効とした。						//20160412 update
        /// 
        ///		19.	CtlPlotMenu.cs CtlBodePlot.cs
        ///			ツールバーに描画停止機能追加。									//20160412 add
        ///	
        ///		20.	AutoTuningForm.cs
        ///			負荷イナーシャ推定処理最適化。									//20160412 update
        /// 
        ///		21.	AutoTuningForm.cs FreqencySweepForm.cs
        ///			周波数スイープ処理追加。
        ///			周波数スイープ設定画面追加。									//20160412 update
        /// 
        ///		22.	CtlJogControl.cs Message.cs
        ///			速度データ変更時に1000rpm以上の変更なら
        ///			注意メッセージを出力。											//20160413 add
        /// 
        ///		23.	JogControlForm.cs
        ///			制御モードに簡易プログラムモード追加。							//20160413 add
        /// 
        ///		24.	ParameterForm.cs
        ///			ID120番誤記修正。
        ///			（誤）01：正方向パルス＋負方向パルスモード
        ///			（正）01：パルス＋回転方向モード								//20160414 update
        /// 
        ///		25.	TeachingForm.cs
        ///			ティーチング完了時にサーボオフ要求メッセージ追加。
        ///			速度制御から位置制御切り替りの振動対策。						//20160418 update
        /// 
        ///		26.	ParameterForm.cs
        ///			パラメータ自動更新処理を初期値で有効とした。UI向上。			//20160420 update							
        /// 
        ///		27.	WizardForm.cs
        ///			目標速度、目標加減速設定時に加減速時間の表示を追加。UI向上。	//20160420 update
        /// 
        ///		28.	CtlJogControl.cs
        ///			速度制御時に現在位置ティーチング機能追加。						//20160420 update
        #endregion
        ///     ■■■■■VER.0.22リリース20160421■■■■■
        #region VER.0.22
        ///		1.	AboutBox.cs
        ///			ラベルサイズが不正。AutoSizeプロパティをTureへ。				//20160420 update
        /// 
        ///		2.	GainControlForm.cs
        ///			ノッチフィルタ2周波数の単位テキストの表示不正。
        ///			resources.GetObject()修正。										//20160422 update
        /// 
        ///		3.	CtlJogControl.cs
        ///			位置決めモードを”相対位置”を既定の設定に変更。
        ///			安全確保のため、絶対位置だと”0”の位置へ動作してしまう。		//20160425 update
        /// 
        ///		4.	JogControlForm.cs
        ///			電流制御切り替え時のサーボオフ実行処理漏れ。					//20160426 update
        /// 
        ///		5.	CtlBodePlot.cs
        ///			FFT画面にクイックモニター機能追加。								//20160427 update
        /// 
        ///		6.	DigitalOsilloForm.cs
        ///			FormLoadイベント後のViewCultureResouceChanged()処理修正。
        ///			カルチャー変更時のみ実行。
        /// 　　　　リソースパラメータがコンボ設定に反映されない為。				//20160427 update
        /// 
        ///		7.	CUsb.cs
        ///			USB R/W処理にCDCデバイス接続チェック追加。
        ///			USBケーブル切断時のアプリケーションエラー対策。					//20160427 add
        /// 
        ///		8.	AutoTuningForm.cs TuningControlForm.cs
        ///			個別チューニング機能追加。										//20160427 add
        /// 
        ///		9.	MainForm.cs CMonitro.cs AutoTuningForm.cs
        ///			省線INC2500対応。												//20160509 add
        /// 
        ///		10. TuningControlForm.cs AutoTuningForm.cs
        ///			 FrictionControlForm.cs追加。
        ///			個別チューニングに摩擦補正機能追加。							//20160510 add
        /// 
        ///		11.	AutoTuningAdjust.cs
        ///			オートチューニング完了後にFFT表示停止処理追加。					//20160510 add
        #endregion
        ///     ■■■■■VER.0.23リリース20160510■■■■■
        #region VER.0.23
        ///		1.	TuningControlForm.cs FreqencySweepForm.cs
        ///			フォーム文字列中文対応。										//20160511 update
        /// 
        ///		2.	MainForm.cs
        ///			省線INCエンコーダの分解能が反映されない件を修正。				//20160513 update
        #endregion
        ///     ■■■■■VER.0.24リリース20160513■■■■■
        #region VER.0.24
        ///		1.	AutoTuningForm.cs
        ///			省線INCエンコーダの分解能が反映されない件を修正。				//20160513 update
        /// 
        ///		2.	CUsb.cs
        ///			USBケーブル切断時のアプリケーションエラー対策強化。				//20160513 update
        #endregion
        ///     ■■■■■VER.0.25リリース20160513■■■■■
        #region VER.0.25
        ///		1.	IoMonitorForm.cs ServoMonitorForm.cs
        ///			モニターコントロール追加。										//20160516 add
        ///			
        ///		2.	Message.cs
        ///			ChildFormControlクラス追加。	
        ///			Dialog起動処理にChildFormの表示・非表示処理追加。
        ///			上記に伴いプロジェクトフォルダ等を整理。						//20160517 update
        /// 
        ///		3.	CUsb.cs
        ///			ReadFile() WriteFile()
        ///			例外処理のUnInitUsb()を削除。									//20160525 update
        /// 
        ///		4.	DigitalOsilloForm.cs
        ///			ログ取得時間のパラメータを追加。
        ///			波形表示停止時に経過時間表示を追加＋
        ///			パネルリサイズイベント時の表示を最適化＋
        ///			波形描画位置（目盛線）最適化。									//20160526 add
        /// 
        ///		5.	CtlJogControl.cs
        ///			往復動作時の最小待ち時間修正。
        ///			100→500msec													//20160526 update
        /// 
        ///		6.	OptionSettingDialog.cs
        ///			通信周期のパラメータを追加。リソース化。						//20160526 add
        ///			
        ///		7.	OptionSettingDialog.cs
        ///			OK,Cancelボタン追加。
        ///			OKボタンで設定変更反映、Cancelボタンで無効の処理を追加。		//20160527 update
        ///			
        ///		8.	OptionsettingDialog.cs
        ///			ログ周期のパラメータ追加。リソース化。							//20160527 add
        /// 
        ///		9.	MainForm.cs DigitalOsilloForm.cs AutoTuningForm.cs
        ///			AutoTuningAdjust.cs FFT_IF.cs BodeGraphForm.cs
        ///			ログ周期変更に伴い、
        ///			描画処理、チューニング判定処理等を修正。						//20160527 update
        ///		
        ///		10.	BodeGraphForm.cs
        ///			”停止”ボタンを”波形表示停止”ボタンへ名称及び配置変更。
        ///			オートチューニング時にEnable処理追加。
        ///			ツールバーのフォームアクティブ処理追加。						//20160530 update
        /// 
        ///		11.	MainForm.cs ViewMainForm.cs AutoTuningForm.cs
        ///			オートチューニング時の終了処理で、
        ///			チューニング中止メッセージを追加。								//20160530 update
        /// 
        ///		12.	AutoTuningAdjust.cs
        ///			UserParameter.InertiaRatioに最小値判定処理追加。
        /// 　　　　テキスト出力用にUserParameter.InertiaRatioReal追加。			//20160530 update
        /// 
        ///		13.	DigitalOsilloForm.cs
        ///			トリガ時の計測線の描画とトリガON・OFF切り替え処理で、
        ///			データ初期化処理追加。描画処理を最適化。						//20160530 update
        /// 
        ///		14.	GainControlForm.cs
        ///			Kv最大値拡張。3000→9999。
        ///			Ki最大値拡張。1000→3000。										//20160530 update
        ///
        ///		15.	AutoTuningForm.cs
        ///			仮イナーシャ係数変更。5%→2%。									//20160530 update
        /// 
        ///		16.	DigtalOsilloForm.cs MainForm.cs AutoTuningAdjust.cs
        ///			FFTデータ取得前後の時間にログ周期（LogPeriod)を反映。
        ///			FFT描画数をFFT_Cクラスにパラメータ化。							//20160530 update
        /// 
        ///		17.	AutoTuningAdjust.cs
        ///			FFT描画ログ周期可変対応の為、バッファ初期化処理追加。			//20160531 add
        /// 
        ///		18.	CtlJogControl.cs
        ///			プログラムモードから位置・速度・電流制御切り替え時、
        ///			正転・逆転・停止ボタンが使用不可状態を修正。					//20160531 update
        /// 
        ///		19.	CtlPlotMenu.cs CtlBodePlot.cs
        ///			計測バー追加。													//20160531 add
        /// 
        ///		20.	FFT_IF.cs AutoTuningAdjust.cs
        ///			ログ周期2msec、4msecオートチューニング対応。
        ///			FFT検出レベル等を調整。											//20160601 update
        /// 
        ///		21.	GainControlForm.cs
        ///			モデル追従制御タブ削除。										//20160602 update
        /// 
        ///		22.	MainForm.cs
        ///			Drive終了時のサーボオン状態注意メッセージ追加。
        ///			サーボオフするかの選択肢を追加。								//20160606 add
        /// 
        ///		23.	ManualNavi.cs
        ///			Driveソフトウェアマニュアル追加。								//20160606 add
        #endregion
        ///     ■■■■■VER.0.30リリース20160606■■■■■
        #region VER.0.30
        ///		1.	frmBasicProgramOperations.cs他
        ///			簡易プログラム移植。											//20160712 add
        /// 
        ///		2.	CtlJogControl.cs AutoTuningForm.cs
        ///			UpdateAccDccTime()をFormLoad_Event()に追加。					//20160714 update
        /// 
        ///		3.	Form
        ///			Formテキストを英文化。											//20160714 update
        /// 
        ///		4.	Mesage.cs
        ///			英文化対応。													//20160715 update
        /// 
        ///		5.	CtlJogControl.cs
        ///			アラーム発生時、JogStop()処理追加。								//20160715 update
        /// 
        ///		6.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			オートチューニング実行時に軸動作中判定処理を追加。
        ///			CheckTheOtherSequence()追加。
        ///			※軸動作中判定処理は削除。
        ///			※上位がいつ動作させるのか分からない。							//20160719 add
        #endregion
        ///     ■■■■■VER.0.31リリース20160719■■■■■
        #region VER.0.31
        ///		1.	DigitalOsilloForm.cs
        ///			リアルタイムFFTかつデジタルオシロ波形停止時に
        ///			デジタルオシロの波形が更新されてしまう件を修正。				//20160722 update
        ///
        ///		2.	AutoTuningAdjust.cs
        ///			StartAutoTuning()でログデータをオートチューニング用に再設定。
        ///			（位置偏差、モニタ速度、モニタ電流）							//20160726 update
        ///
        ///		3.	FirmwareUpgradeDialog.cs
        ///			DfuSeCommand.exeを管理者権限で実行。
        ///			dfuファイルをProgramFiles(x86)からUser\\AppData\\Localへ
        ///			コピーしてから実行するように変更。								//20160726 update
        /// 
        ///		4.	AutoTuningAdjust.cs
        ///			振動検出後の初期ゲイン再初期化で、
        ///			ローパスフィルタ初期化漏れ。									//20160907 update
        /// 
        ///		5.	Form他
        ///			TRIから英文指摘事項を反映。										//20160907 update
        /// 
        ///		6.	MainForm.cs CtlJogControl.cs
        ///			制御モードが簡易コントロールモード時に
        ///			サーボオン機能禁止、オートチューニング機能禁止処理追加。		//20160908 update
        ///
        #endregion
        ///     ■■■■■VER.0.32リリース20160908■■■■■
        #region VER.0.32
        ///		1.	AutoTuningAdjust.cs
        ///			CheckTheCurrentVibration()
        ///			初期ゲイン再調整時のゲイン上昇率再初期化不正のため修正。		//20160926 update
        /// 
        ///		2.	frmBasicProgramOperation2.cs
        ///			Helpボタン名称変更。日本語、中国語画面をHelp→HELP。			//20160926 update
        /// 
        ///		3.	MainForm.cs TimerMain_Tick()
        ///			起動後のレイアウト選択画面でキャンセル時にエラー発生。
        ///			AutoTuningFormのEnableUpadate判定処理を追加。					//20160926 update
        ///			
        ///		4.	DigitalOsilloForm.cs
        ///			波形表示全面的に機能強化。										//20161004 update
        /// 
        ///		5.	MainForm.cs JogControlForm.cs
        ///			プログラムモード（プログラム実行状態）から、
        ///			他制御モードへの切り替え時に、サーボオンする件を修正。
        ///			メインツールバーのオートチューニングボタン、
        ///			Enable/Disable処理を修正。										//20161005 update
        /// 
        ///		6.	全フォームのツールバー
        ///			LayoutStyleをStackOverflowからFlowへ変更。						//20161006 update
        /// 
        ///		7.	DigitalOsilloForm.cs
        ///			ログ項目にモデル追従制御モニタ追加。（位置・速度・電流）		//20161012 add
        ///		
        ///		8.	ParameterForm.cs
        ///			パラメータ全書き込み時にプログラスバーが消えない件を修正。		//20161013 update
        ///		
        #endregion
        ///     ■■■■■VER.0.33リリース20161013■■■■■
        #region VER.0.33
        /// 
        ///		1.	ParameterForm.cs
        ///			日本語パラメタHelpを取説最新版に更新。							//20161019 update
        /// 
        ///		2.	MainFrom.cs
        ///			PCのスタンバイ、休止状態サポート。
        ///			スタンバイ、休止状態中はUSBの切断処理を追加。
        ///			復帰時は特に何もしない。MainTimerからUSBが接続される。			//20161031 add
        /// 
        ///		3.	JogControlForm.cs CtlJogControl.cs
        ///			AutoTuningForm.cs AutoTuningAdjust.cs
        ///			PublicメソッドJogStop()関数を追加。
        ///			オートチューニング実行時にJogStop()をCall。						//20161031 add
        /// 
        ///		4.	MainForm.cs
        ///			DriverModel、DriverRevisionプロパティを追加。					//20161031 add
        /// 
        ///		5.	MainForm.cs GainControlForm.cs
        ///			AutoTuningAdjust.cs AutoTuningForm.cs
        ///			ゲインコントロール及びオートチューニンの
        ///			速度フィードバックデータの切り替え。
        ///			旧バージョンは速度フィードバックフィルタが移動平均。
        ///			新バージョンは速度フィードバックフィルタが1次IIR_LPF。
        ///			正式なバージョンはドライバ本体ソフト更新後に確定する。			//20161031 update
        /// 
        ///		6.	PrameterForm.cs
        ///			bRead()内のCMonitor.SetParameter()引数修正。
        /// 
        ///		7.	MainForm.cs ParameterForm.cs DigitalOsilloForm.cs
        ///			Winodws OS Versionチェック追加。
        ///			Winodws7未満のOSは、
        ///			オートチューニング、デジタルオシロ、FFTを禁止。					//20161102 update
        /// 
        ///		8.	OptionSettingDialog.cs ParameterForm.cs
        ///			パスワード追加。（リソース追加）
        ///			55555　　　 一時解除
        ///			5555555555　永久解除
        ///			パスワードを誤ると再度ロックされる。							//20161102 add
        /// 
        ///		9.	FirmwareUpgradeDialog.cs
        ///			テキストブリンク制御、ボタン文字等の少修正。					//20161107 update
        /// 
        ///		10.	MainForm.cs frmBasicProgramOperation2.cs
        ///			プログラム実行時の終了処理を修正。								//20161108 update
        /// 
        ///		11.	MainForm.cs CUsb.cs AutoTuningFom.cs CtlJogControl.cs
        ///			USB例外処理全面的に見直し。
        ///			Windowsがデバイスを切り離すモードは、
        ///			devcon.exeを使用してデバイスの有効・無効処理を追加。
        ///			ドライバが停止するモードは、Sコマンドを追加。
        ///			USB接続時とリトライ処理でSコマンド実行。
        ///			ドライバ停止モードで、COMデバイスが認識している状態で、
        ///			アプリケーション停止（停止時間長い）する件は、
        ///			COMのOpen、Close処理をスレッド化。
        ///			COMのDispose処理は念のため廃止。
        ///			旧バージョンでDispose処理で例外発生していた為。
        ///			オートチューニング及びジョグ連続動作で、
        ///			USB切断処理で動作停止する件は、
        ///			IsUsbWaitフラグを追加して延命する処理を追加。					//20161115 update
        /// 
        ///		12.	CtlJogControl.cs
        ///			アラーム発生時にJogStop()から、ServoCommand全クリアに変更。
        ///			アラーム発生時にJogStop()処理でSmoothStopビットがONするため、
        ///			パルス指令モードでアラーム発生後に動作出来ない件を修正。		//20161118 update
        /// 
        ///		13.	ManualNavigatorForm.cs
        ///			Drive_SoftwareManual_US対応。
        /// 
        ///		14.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			振動検出設定追加。tuning_config.txt修正。						//20161124 update
        #endregion
        ///     ■■■■■VER.0.40リリース20161125■■■■■
        #region VER.0.40
        /// 
        ///		1.	AutoTuningForm.cs
        ///			Wizard完了後に加減速時間が更新されない件を修正。				//20161202 update
        /// 
        ///		2.	DigitalOsilloForm.cs
        ///			時間計測、トリガ位置の時間軸描画ズレ修正。						//20161202 update
        /// 
        ///		3.	AutoTuningAdjust.cs
        ///			サーボパラメータ TAD88xx Ver.5.20対応。							//20161202 update
        /// 
        ///		4.	frmBasicProgramOperation2.cs
        ///			ドライバ内部プログラムが空の状態で、
        ///			CurrentStepNo、PrevStepNoが不正になる件を修正。					//20161202 update
        /// 
        ///		5.	AutoTuningAdjust.cs
        ///			スモールモーション（等速域無し）のオートチューニング対応。		//20161202 update
        ///			
        ///		6.	AutoTuningAdjust.cs
        ///			チューニングパラメータ修正。
        ///			17B速度フィードバック　600→1000
        ///			17B電流ローパスフィルタ　0→2000（但し速度OBS有効時は0）
        ///			積分ゲイン最大値復活。											//20161202 update
        /// 
        ///		7.	FirmwareUpgradeDialog.cs CUsb.cs
        ///			外部exe起動処理修正。
        ///			C:\\Users\\User\\AppData\\Local\\Drive 以下に外部exeを配置。	//20161205 update
        ///			
        ///		8.	AutoTuningAdjust.cs
        ///			MeasureLogData()
        ///			ドライバパラメータID256番、加減速時間（ID34、ID35）
        ///			スケール（10倍、100倍）対応。
        ///			オートチューニングの偏差割れ判定開始位置が不正になる件を修正。	//20161205 update
        #endregion
        ///     ■■■■■VER.0.41リリース20161206■■■■■
        #region VER.0.41
        /// 
        ///		1.	ParameterForm.cs
        ///			パラメータヘルプ英文化。
        ///			パラメータヘルプ日本語見直し。									//20170116 update
        /// 
        ///		2.	ManualNavigatorForm.cs
        ///			取扱説明書英語版追加。日本語版更新。
        ///			簡易コントロール操作マニュアル追加。日本語版のみ。				//20170116 update
        ///			
        ///		3.	ParameterForm.cs
        ///			パラメータファイル保存時の現在値読み込みチェックを、
        ///			先頭行のみから全ての行に変更。									//20170123 update
        /// 
        ///		4.	ParameterForm.cs DigitalOsilloForm.cs
        ///			ファイル保存及び開く処理の初期ディレクトリ記憶処理追加。		//20170123 update
        /// 
        ///		5.	ParameterForm.cs
        ///			ID360、ID361チューニングフリー機能パラメータHELP追加。
        ///			日本語のみ。													//20170123 update
        /// 
        ///		6.	CUsb.cs MainForm.cs DigitalOsilloForm.cs ParameterForm.cs
        ///			CUsb.csデバイスマネージャー監視スレッド停止処理追加。
        ///			常にスレッド起動状態の場合、WinodwsXPや低性能PCで、
        ///			USB通信が遅くなる（待ち状態）ため必要な時だけ起動する。
        ///			スレッド処理最適化により、Winodws7判定処理削除。				//20170123 update
        ///			
        ///		7.	FirmwareUpgradeDialog.cs
        ///			DFUオンラインアップデート Windows Xp対応。						//20170125 update
        ///			
        ///		8.	frmBasicProgramOperation2.cs
        ///			実行中ステップハイライト表示クリア機能追加。
        ///			運転開始、ダウンロード、アップロード．．．etc					//20170125 update
        /// 
        ///		9.	Drive
        ///			トリガ位置、オシロ横軸縮尺、アプリケーション設定最適化。		//20170125 update
        ///	
        ///		10.	OptionSettingDialog.cs DigitalOsilloForm.cs
        ///			アプリケーション初期化後にデジタルオシロ再設定処理追加。		//20170125 update
        /// 
        ///		11.	MainForm.cs ViewMainForm.cs IoMonitorForm.cs ServoMonitorForm.cs
        ///			ViewMainFormにサーボモニターとIOモニターラベルを追加。			//20170125 add
        /// 
        ///		12.	AutoTuningForm.cs
        ///			ユーザーに関係ない設定の為、チューニングパラメータ表示OFF。
        ///			パスワード解除で表示ON。										//20170125 update
        ///			
        #endregion
        ///     ■■■■■VER.0.50リリース20170124■■■■■
        #region VER.0.50
        /// 
        ///		1.	OpenDriveForm.cs
        ///			縮小レイアウトプロパティ反映漏れ。								//20170126 update
        /// 
        ///		2.	MainForm.cs
        ///			縮小レイアウト時にメニューテキスト変更。
        ///			ジョグコントロール→ジョグ。
        ///			オートチューニング→チューニング。								//21070126 update
        /// 
        ///		3.	CUsb.cs
        ///			USB切断時のデバイスマネージャー検索スレッドを最適化。
        ///			低スペックPCだと負荷が重い為、
        ///			無限ループではなく一定周期毎に実行するように修正。				//20170126 update
        /// 
        ///		4.	AutoTuningForm.cs
        ///			オートチューニング時のUSB通信切断判定処理変更。
        ///			USB通信断から10秒間回復待ち。TAD8810対策。						//20170127 update
        /// 
        ///		5.	AutoTuningAdjust.cs
        ///			ノッチフィルタ設定済みかつKvp設定限界で、
        ///			チューニング強度毎にKvp*係数のロールバック処理を修正。
        ///			剛性低い機械の場合、最初にKvpだけ上昇する場合があるため、
        ///			ロールバックで初期ゲインまで戻ってしまう。						//20170127 update
        /// 
        ///		6.	AutoTuningAdjust.cs
        ///			EnableUpKvi()
        ///			オーバーシュート判定を削除。初期ゲインでゲインが低い場合に、
        ///			オーバーシュートが収束せずに積分ゲインが上がらない件の対策。
        ///			高ゲインでオーバーシュート時は積分ゲインを上げない。
        ///			低ゲインでオーバーシュート時は積分ゲインを上げる。				//20170130 updata
        /// 
        ///		7.	AutoTuningAdjust.cs
        ///			振動検出後のロールバック処理前に振動検出ステータス判定追加。	//20170131 update
        /// 
        ///		8.	AutoTuningForm.cs
        ///			USB切断時の負荷イナーシャ推定処理修正。							//20170131 update
        /// 
        ///		9.	AutoTuningAdjust.cs
        ///			チューニングパラメータ追加。速いオーバーシュート時間。
        ///			速いオーバーシュートは積分ゲイン上昇禁止。
        ///			遅いオーバーシュートは積分ゲイン上昇許可。
        ///			速いオーバーシュート判定時間の初期値は100msec					//20170131 update
        /// 
        ///		10.	CUsb.cs MainForm.cs
        ///			USB切断時の回復処理追加。TA8810対策。
        ///			COMオープン後にUSB通信確認しエラーならDevcon処理追加。
        ///			その他、通信処理整理、不要な処理削除。							//20170201 update
        ///			
        #endregion
        ///     ■■■■■VER.0.60リリース20170202■■■■■
        #region VER.0.60
        ///		
        #endregion
        ///		★★★★★VER.1.00リリース20170209★★★★★
        #region VER.1.00
        ///
        ///		1.	AutoTuningForm.cs
        ///			オートチューニング初期設定変更。
        ///			機械：ベルト　速度安定化：無効									//20170210 update
        /// 
        ///		2.	WizardDialog.cs
        ///			速度安定化制御の注記を追加。
        ///			速度計算精度向上・・・
        ///			日本語、英語、中国語。											//20170213 update
        /// 
        ///		3.	CUsb.cs StartComClose()
        ///			USBケーブル切断時にアプリケーションエラーとなる件。
        ///			ComClose()前にバッファークリア処理追加。
        ///			ComClose()前にバッファークリア処理追加。
        ///			ThreadSerchCDC.Abort()処理修正。
        ///			ComOpen及びComClose処理をスレッド化。
        ///			UsbWrite及びUsbRead処理でCUsbのnull判定追加。					//20170210_13 update
        ///			
        #endregion
        ///     ■■■■■VER.1.01リリース20170213■■■■■
        #region VER.1.01
        ///			
        ///		1.	ProfileMovementTableForm.cs
        ///			簡易プログラム位置決めテーブル機能追加。						//20170215 add
        /// 
        ///		2.	frmBasicProgramOperation2.cs OptionSettingDialog.cs
        ///			簡易プログラム位置決めテーブル対応。
        ///			パスワード”TRI”で位置決めテーブル表示有効。					//20170215 add
        /// 
        #endregion
        ///     ■■■■■VER.1.02リリース20170215■■■■■
        #region VER.1.02
        ///
        ///		1.	AutoTuningForm.cs
        ///			負荷イナーシャ推定MIN速度変更。
        ///			100rpm→20rpm。	円盤高イナーシャ時危険。						//20170215 update
        ///		
        ///		2.	CtlNumericUpDown.cs
        ///			btnUp_Click() btnDown_Click()を、
        ///			btnUp_MouseClick() btnDown_MouseClick()イベントへ変更。
        ///			Enterキー、Spaceキーで数値が変更される件を修正。				//20170215 update
        /// 
        ///		3.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			位置偏差エラー検出パルス、ダイナミックブレーキ駆動条件を、
        ///			チューニング前に設定しチューニング完了後に元の設定に戻す。
        ///			位置偏差エラー検出パルスはエンコーダ分解能×10。
        ///			ダイナミックブレーキ駆動条件はアラームで有効。					//20170215 update
        /// 
        ///		4.	ProfileMovementTableForm.cs
        ///			位置決めテーブル表示の時はAutoTuningFormをDisable。				//20170216 update
        /// 
        ///		5.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			チューニング時の位置決め開始位置を
        ///			FeedbackPositionからCommandPositionへ変更。						//20170215 update
        /// 
        ///		6.	AutoTuningAdjust.cs
        ///			初期ゲイン調整中にノッチフィルタが設定された場合、
        ///			FFT初期値を再設定するようにシーケンスを変更。					//20170217 update
        /// 
        ///		7.	AutoTuningForm.cs
        ///			USB切断判定10秒から3秒へ修正。									//20170217 update
        /// 
        ///		8.	AutoTuningForm.cs
        ///			負荷イナーシャ推定時の位置偏差エラー閾値を修正。
        ///			エンコーダ分解能×10から×1へ。									//20170217 update
        ///		
        #endregion
        ///     ■■■■■VER.1.03リリース20170220■■■■■
        #region VER.1.03
        ///		
        ///		1.	ParameterForm.cs
        ///			ファイル保存前に全パラメータ読み込み処理追加。					//20170221 update
        ///		
        ///		2.	GainControlForm.cs
        ///			タブオーダー修正。												//20170222 update
        /// 
        ///		3.	MainForm.cs他
        ///			縮小レイアウトサイズ見直し。350→300。
        ///			他フォームのメニュー背景色等見直し。							//20170222 update
        /// 
        ///		4.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			ローパルフィルタ関連の速度オブザーバ有効時の設定追加。			//20170222 update
        ///		
        #endregion
        ///     ■■■■■VER.1.04リリース20170222■■■■■
        #region VER.1.04
        /// 
        ///		1.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			チューニング時の位置決め開始位置を
        ///			CommandPositionからFeedbackPositionへ変更。						//20170222 update
        /// 
        ///		2.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			機械タイプの表現変更。
        ///			高剛性、中剛性、低剛性へ。										//20170223 update
        /// 
        #endregion
        ///     ■■■■■VER.1.05リリース20170224■■■■■
        #region VER.1.05
        /// 
        ///		1.	ParameterForm.cs
        ///			パラメータ全書き込み後に自動更新処理を回復する処理を追加。		//20170309 update
        /// 
        #endregion
        ///		★★★★★VER.1.10リリース20170315★★★★★
        #region VER.1.10
        ///
        ///		1.	CUsb.cs
        ///			Windows 10 対応のため、デバイスマネージャーの検索処理と、
        ///			USB切断処理（COM Close）を見直し。
        /// 
        #endregion
        ///     ■■■■■VER.1.11リリース20170321■■■■■
        #region VER.1.11
        ///
        /// 	1.	CCommandTx.cs
        ///			ログ取得の最後（ログ30個未満=リングバッファ最終）の場合に,
        ///			ログ個数が1個少ない（抜ける）件を修正。
        ///			本体ソフトを修正するのが正しいがDrive側を修正しても問題無い。
        ///			但し、本体側が正しい処理になった場合は注意が必要。
        ///			バージョン＋形式で管理する必要がある。							//20170711 update
        ///
        ///		2.	CtlJogControl.cs
        ///			JogCtrl()
        ///			PTP動作開始後に移動距離を0から変更（移動有り）にした場合に、
        ///			動作する件を修正。移動距離が0の場合PTP動作を終了処理追加。		//20170711 update
        /// 
        ///		3.	CtlJogControl.cs
        ///			JogCtrl()
        ///			アラームまたはリミット検出した場合にPTP動作を終了処理追加。		//20170711 update
        /// 
        ///		4.	CUsb.cs
        ///			DevCon.exe廃止。
        ///			既にUSB通信は安定。試験的に廃止してみる。						//20170711 update
        ///			
        #endregion
        ///     ■■■■■VER.1.12リリース20170711■■■■■
        #region VER.1.12
        /// 
        ///		1.	DigitalOsilloForm.cs
        ///			HoldEvent()
        ///			連続波形再生時にLogPtr=0を追加。
        ///			停止時波形の続きから再生するよう修正。波形の見た目改善。		//20170802 update
        /// 
        ///		2.	DigitalOsilloForm.cs
        ///			DrawWaveLine()
        ///			描画基準線（上横線）描画位置最適化。見た目改善。				//20170809 update
        /// 
        ///		3.	DigitalOsilloForm.cs
        ///			DrawWaveOscillo() HoldEvent() UpdateHoldView()
        ///			連続波形再生・波形停止時の描画エリア最適化。
        ///			再生・停止に関わらず、描画サイズを一定とした。
        ///			横軸スクロールバーは常に表示するように変更し、
        ///			波形再生時：Disable、波形停止時：Enableとした。					//20170809 update
        ///			
        ///		4.	DigitalOsilloForm.cs
        ///			DrawWaveOscillo()
        ///			縦軸拡大時に描画範囲から波形がはみ出る件を修正。				//20170809 update
        /// 
        ///		5.	DigitalOsilloForm.cs
        ///			VerticalZoom()
        ///			Y_Divリミット時にProperties.Settings.Default.WAVE_YScaleに
        ///			保存されない件を修正。											//20170809 update
        /// 
        ///		6.	DigitalOsilloForm.cs
        ///			DrawWaveOscillo() TimeMeasDraw()
        ///			波形項目の単位[]内のスペース削除。
        ///			波形停止時の時間表示のフォントサイズ変更。
        ///			波形描画エリアの下側オフセット最適化。（位置を詰めた）
        ///			位置、パラメタ1-3の項目表示位置最適化。
        ///			波形描画エリアの上側オフセット追加。							//20170810 update
        /// 
        ///		7.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			BackupOtherParameter()追加。
        ///			負荷イナーシャ推定、ゲイン調整、周波数スイープ前に、
        ///			位置・速度指令選択の内容を判定する処理を追加。
        ///			その他の保存パラメータをBackupOtherParameter()に整理。			//20170822 update
        ///		
        ///		8.	DigitalOsilloForm.cs
        ///			LogTimeValueChanged() BackupLogLength 追加。
        ///			保存したログデータの長さとDriveログデータ長さが異なる場合に、
        /// 		正しくログデータを読み込めない件を修正。
        ///			USB未接続状態でログデータ読み込み時に、
        ///			波形データがスクロール出来ない件を修正。						//20170825 add
        /// 
        ///		9.	DigitalOsilloForm.cs
        ///			InitAppParameter()
        ///			スクロールバーの動作許可初期値をDisableへ。
        ///			起動後の見た目改善。
        ///			トリガポジションのコンボテキストに、
        ///			"+1"～"+6"のAPP保存データが反映されない件を修正。				//20170926 add
        /// 
        ///		10.	DigitalOsilloForm.cs
        ///			トリガ＋波形表示停止でスクロール可能とした。
        /// 　　　　但し、トリガ後に波形表示停止するまでの時間が長すぎる場合は、
        ///			（バッファー長さ以上）最新ログデータで上書きされる仕様。
        ///			上記の修正に伴い、クイックモニター及び描画位置調整。			//20170927 update
        ///			
        ///		11.	DigitalOsilloForm.cs
        ///			InitAppParameter()
        ///			ComboLogKind_SelectedIndexChanged() numLogPrm_ValueChanged()
        ///			ログID1～3をアプリケーション設定へ。
        ///			ドライバの値が0でAPP設定が0以外の場合はAPP設定で書き換える。
        ///			位置ログ、速度ログ、電流ログについては従来通り。
        ///			初期値はモニタ値（平均値）が良いため。							//20170928 update
        /// 
        ///		12.	DigitalOsilloForm.cs
        ///			ComboScale_Enter() ComboScale_Leave() ComboScale_TextChanged()
        ///			波形表示スケールを数値入力可能に変更。							//20170928 update
        /// 
        ///		13.	MainForm.cs OptionSettingDialog.cs app.config
        ///			ToolStripMenuItemOption_Click()
        ///			DevCon機能をプロパティ化。										//20170928 add
        /// 
        ///		14.	MainForm.cs ParameterForm.cs OptionSettingDialog.cs他
        ///			ART-HIKARIモード対応。木村さん追加ソフト。						//20170928 add  //ART HIKARI Mode 20170919 Kimura add
        ///			
        ///		15.	MainForm.cs
        ///			LoadJogControl()
        ///			起動後のレイアウト選択画面でJogControlFormが
        ///			表示されない時がある件を修正。USB接続＋モニタ確立待ちを削除。	//20171002 del
        ///
        ///		16.	ManualNavigatorForm.cs
        ///			TAD8810取扱説明書追加。（日本語のみ）							//20171002 add
        ///
        #endregion
        ///     ■■■■■VER.1.13リリース20171002■■■■■
        #region VER.1.13
        ///		1.	CUsb.cs
        ///			StartSerchCDC()
        ///			PID_0101追加。トヨタPロボ対応。									//20171031 update
        /// 
        ///		2.	frmBasicProgramOperation2.cs
        ///			btnPrgSave_Click()
        ///			コメントに2バイト文字を追加した時、
        ///			Enter入力でコメント文字が確定しない件を修正。
        ///			GridProgram_CellValueChanged()
        ///			コメント入力後にコマンド変更すると、
        ///			コメント文が初期化（文字無し）される件を修正。					//20171114 update
        ///	
        ///		3.	AutoTuningAdjust.cs
        ///			StartAutoTuning()
        ///			TAD8810 + TBL-mini motor は電流ループゲインを
        ///			再設定しないように修正。
        ///			TBL-mini motor は抵抗、インダクタの設定が非常に小さいため、
        ///			通常の電流ループゲインの計算では応答が低すぎるから、
        ///			既定値で高めの電流ループゲインが設定されている。				//20171114 update
        /// 
        #endregion
        ///		★★★★★VER.1.20リリース20171115★★★★★
        #region VER.1.20
        ///		1.	ParameterForm.cs
        ///			ViewParameterResouce()
        ///			ID118、ID119（モニタ設定1or2）Help誤記訂正。
        ///			
        ///		2.	CUsb.cs
        ///			StartSerchCDC()
        ///			USBデバイス名の(COM**)が認識されない場合のエラー対策。			//20180807 add
        ///
        ///		3.	CUsb.cs
        ///			StartComOpen()
        ///			USBケーブル切断時のアプリケーションエラー対策。					//20180807 add
        ///		
        ///		4.	CtlJogControl.cs
        ///			ViewCultureResouceChanged()
        ///			言語設定を英語に変更後、
        ///			JogControlの特殊設定が日本語の件の修正。						//20180807 update
        /// 
        #endregion
        ///     ■■■■■VER.1.21リリース20180807■■■■■
        #region VER1.21
        /// 
        ///		1.	ctlCommandMOVE_END.cs
        ///			中国語画面で、txtDecelerationとtxtTargetPosの位置が
        ///			反対になっている件を修正。										//20180925 update
        /// 
        ///		2.	SimpleControl
        ///			簡易コントロールの全入力画面のタブオーダー整理。				//20180925 update
        /// 
        ///		3.	CCommandTx.cs
        ///			WriteSvNet()
        ///			簡易プログラム消去、保存待ち時間修正。1秒→2秒待ち。			//20180925 update
        ///			
        #endregion
        ///     ■■■■■VER.1.22リリース20180926■■■■■
        #region VER1.22
        /// 
        ///		1.	Message.cs OptionSettingDialog.cs
        ///			IoMonitorForm.cs IoMonitorHikariForm ServoMonitorForm.cs
        ///			MainForm.cs ParameterForm.cs
        ///			アートヒカリ追加英文対応。										//20181212 update
        /// 
        #endregion
        ///     ■■■■■VER.1.23リリース20181212（アートヒカリ向け）■■■■■
        #region VER1.23
        /// 
        ///		1.	CtlJogControl.cs
        ///			JogCtrl()
        ///			絶対位置往復動作で目標位置1と目標位置2の差分が0の時、
        /// 　　　　位置決め動作しない件を修正。
        ///			目標位置1へは必ず移動命令出力するように修正。
        ///			目標位置2へ移動時、差分が0の場合は移動命令停止。				//20190311 update
        /// 
        ///		2.	CtlJogControl.cs
        ///			RadioButton_CheckedChanged()
        ///			絶対位置・相対位置切り替え時、移動命令停止。					//20190311 update
        /// 
        #endregion
        ///     ■■■■■VER.1.24リリース20190311■■■■■
        #region VER1.24
        /// 
        ///		1.	GainControlForm.cs
        ///			ctlNumExPosFFGainのMAX値修正。500→100．						//20190426 update
        /// 
        ///		2.	CtlJogControl.cs
        ///			JogCtrl()
        ///			位置制御モードで位置決め動作開始時、
        ///			速度加減速リミットビット設定処理追加。
        ///			TAD8830（標準ソフト）対応。										//20190522 add
        /// 
        ///		3.	Drive_KASHIYAMA_Mode.txt参照
        ///			樫山工業向けレイアウト対応。									//20190626 add
        /// 
        #endregion
        ///     ■■■■■VER.1.25リリース20190626■■■■■
        #region VER1.25
        /// 
        ///		1.	FFT_IF.cs 他
        ///			本体標準ソフト対応によるFFT周期変更対応。
        ///			パラメタID509番にFFTログ収集周期が追加。						//20190801 update
        /// 
        ///		2.	Drive_KASHIYAMA_MODE_UPDATE.txt参照
        ///			樫山工業向けレイアウト対応。（2回目）							//20191001 update
        /// 
        ///		3.	AlarmHistoryForm.cs
        ///			GetAlarmInfoContent()
        ///			アラーム履歴の総サーボオン時間、トータルオン時間、
        ///			サーボ状態表示の表現修正。										//20191010 update
        ///			
        #endregion
        ///     ■■■■■VER.1.26リリース20191010■■■■■
        #region VER1.26
        ///
        ///     1.	ParameterForm.cs
        ///     	アートヒカリパラメータ文言修正。							    //20191220 update
        ///   
        ///     2.  MainForm.cs/ParameterForm.cs
        ///         アートヒカリモードでサーボ中は、[パラメータ保存]不可とする。    //20191220 update
        ///     	
        #endregion
        ///     ■■■■■VER.1.27リリース20191220■■■■■
        #region VER1.27
        /// 
        ///     1.  CtlBodePlot.cs  CtlPlotMenu.cs  
        ///         BodeGraphForm.cs FFT_IF.cs MainForm.cs 
        ///         樫山工業向け FFTグラフホールド機能追加。                        //20200214 Kimura update
        ///         
        ///     2.  MainForm.cs 
        ///         樫山モードは通信データ量低減処理 を無条件に実施する様に修正。   //20200330 Kimura add  
        #endregion
        ///     ■■■■■VER.1.28リリース20200330■■■■■
        #region VER1.28
        ///     	
        ///     1.  SplashForm.cs ParameterForm.cs OptionSettingDialog.cs  
        ///         アマダ向け専用パラメータ名称追加。
        /// 
        #endregion
        ///  ■■■■■VER.1.29リリース20200601■■■■■
        #region VER1.29
        /// 
        ///     1.  ParameterForm.cs  
        ///         アマダ向け専用パラメータ名称変更。                              //20210318 Kimura update
        /// 
        #endregion
        ///  ■■■■■VER.1.30リリース20210318■■■■■
        #region VER1.30
        /// 
        ///     1.  AutoTuningAdjust.cs AutoTuningForm.cs CMonitor.cs
        ///         Message.cs WizardDialog.cs GainControlForm.cs                   //20210324  
        ///         イナーシャ倍率設定対応。
        ///         
        ///     2.  MainForm.cs FirmwareUpgradeDialog.cs CCommandTx.cs              //20220106 
        ///         CUsb.cs Message.cs
        ///         ＲＺＴ１用シリアルブートローダ対応
        ///         
        ///     3.  DigitalOsilloForm.cs                                            //20220106
        ///     　　波形表示停止後、表示中のログ時間より小さい値に変更すると
        ///     　　例外エラー(IndexOutOfRangeException)が発生する件を修正。
        ///     　　
        ///         現象発生例) ・ログ時間を600secでオシロ表示
        ///                             ↓
        ///     　　            ・波形表示停止
        ///     　　                    ↓
        ///     　　            ・ログ時間を10secに変更
        ///     　　                    ↓  
        ///     　　            ・マウスカーソルをデジタルオシロ画面に移動 ※エラー発生!
        ///         
        /// 
        #endregion
        ///  ■■■■■VER.1.31リリース20220106■■■■■
        #region VER1.31
        /// 
        ///     1.  TAD8821暫定対応。(USB機能限定)
        ///     
        ///     2.　アマダ向け専用パラメータ名称及び説明追加及び変更。
        ///     
        ///     3.  パラメータ一括書込み機能追加。
        ///         (変更値が赤文字表示されている部分を一括書込み)
        ///         → ウィンドウ上部の［一括書き込み］ボタンまたは、
        ///         右クリックでショートメニューの［一括書き込み］ボタンクリックで実行。
        ///         
        ///     4.  デジタルオシロにアラーム発生時波形自動停止機能追加。
        ///         →［トリガ設定］- [アラーム時波形停止]をチェックで有効。          
        /// 
        ///     5.  デジタルオシロの初期表示設定変更。
        ///         速度ログ初期設定：瞬時速度
        ///         電流ログ初期設定：瞬時電流
        ///         
        ///     6.  簡易プログラム実行中、ドライバアラームが発生した場合、
        ///     　　[運転停止]ボタンを[運転開始]ボタンに戻す様に修正。　
        /// 
        #endregion
        ///  ■■■■■VER.1.32リリース20221108■■■■■
        #region VER1.32
        /// 
        ///     1.  デジタルオシロのログファイルの開く及び保存の処理に時間がかかる件を修正。
        ///     　　(10分のログデータ保存に約10分もかかってしまう。)
        ///     　　
        ///     2. アマダ向けモータ負荷試験対応。(パスワード:AMADATESTで有効)
        ///    
        /// 
        #endregion
        ///  ■■■■■VER.1.33リリース20230203■■■■■
        #region VER1.33
        /// 
        ///     1.  モータラインレゾルバ取り付け装置対応。
        ///     
        ///     2.  デジタルオシロの初期表示設定修正。
        ///         Properties.Settings.Default.WAVE_Cur_Idx = 1;       //速度ログ初期設定：瞬時速度
        ///         Properties.Settings.Default.WAVE_Vel_Idx = 1;       //電流ログ初期設定：瞬時電流
        ///         
        ///     3.  ＲＺＴ１用シリアルブートローダ正式対応
        ///         
        ///
        #endregion
        ///  ■■■■■VER.1.34リリース20230406■■■■■
        /// </summary>
    }
}
