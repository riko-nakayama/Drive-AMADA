using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Motion_Designer
{

	public partial class GainControlForm : Form
	{
		static private Point FormPosition = new Point(300, 300);
		static private Size FormSize = new Size(650, 370);

		static private GainControlForm _ThisForm;

		private bool _IsGainChange = false;
		private bool _IsDisableEvent = false;

		private SaveProgressDialog SaveMsg = new SaveProgressDialog();

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		private ViewMainForm ThisParentForm;
		private MdiClient ThisMdiClient;

		private bool _IsExist = new bool();

		private bool UseNumInputEx = new bool();

		public GainControlForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

			ThisParentForm = ViewMainForm.ThisForm;

			ThisMdiClient = ViewMainForm.ThisForm.GetMdiClient();

			_IsDisableEvent = true;

			UseNumInputEx = true;

			#region Init GainControl

			if (UseNumInputEx)
			{
				ctlNumExKp.DataId = CParamID.Kp1;
				ctlNumExKp.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExKv.DataId = CParamID.Kv1;
				ctlNumExKv.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExKi.DataId = CParamID.Ki1;
				ctlNumExKi.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExLoad.DataId = CParamID.Load;
				ctlNumExLoad.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExTuningFree.DataId = CParamID.TuningFreeStrength;
				ctlNumExTuningFree.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurLpf.DataId = CParamID.C_LPF_f;
				ctlNumExCurLpf.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurNotch1_f.DataId = CParamID.C_NF1_f;
				ctlNumExCurNotch1_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch1_d.DataId = CParamID.C_NF1_d;
				ctlNumExCurNotch1_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch1_q.DataId = CParamID.C_NF1_q;
				ctlNumExCurNotch1_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurNotch2_f.DataId = CParamID.C_NF2_f;
				ctlNumExCurNotch2_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch2_d.DataId = CParamID.C_NF2_d;
				ctlNumExCurNotch2_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch2_q.DataId = CParamID.C_NF2_q;
				ctlNumExCurNotch2_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurNotch3_f.DataId = CParamID.C_NF3_f;
				ctlNumExCurNotch3_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch3_d.DataId = CParamID.C_NF3_d;
				ctlNumExCurNotch3_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch3_q.DataId = CParamID.C_NF3_q;
				ctlNumExCurNotch3_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurNotch4_f.DataId = CParamID.C_NF4_f;
				ctlNumExCurNotch4_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch4_d.DataId = CParamID.C_NF4_d;
				ctlNumExCurNotch4_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch4_q.DataId = CParamID.C_NF4_q;
				ctlNumExCurNotch4_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurNotch5_f.DataId = CParamID.C_NF5_f;
				ctlNumExCurNotch5_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch5_d.DataId = CParamID.C_NF5_d;
				ctlNumExCurNotch5_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExCurNotch5_q.DataId = CParamID.C_NF5_q;
				ctlNumExCurNotch5_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelLpf.DataId = CParamID.V_LPF_f;
				ctlNumExVelLpf.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelNotch1_f.DataId = CParamID.V_NF1_f;
				ctlNumExVelNotch1_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExVelNotch1_d.DataId = CParamID.V_NF1_d;
				ctlNumExVelNotch1_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExVelNotch1_q.DataId = CParamID.V_NF1_q;
				ctlNumExVelNotch1_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExPosLpf.DataId = CParamID.V_LPF_f;
				ctlNumExPosLpf.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExPosNotch1_f.DataId = CParamID.P_NF1_f;
				ctlNumExPosNotch1_f.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExPosNotch1_d.DataId = CParamID.P_NF1_d;
				ctlNumExPosNotch1_d.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExPosNotch1_q.DataId = CParamID.P_NF1_q;
				ctlNumExPosNotch1_q.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExModelGain1.DataId = CParamID.ModelControlGain1;
				ctlNumExModelGain1.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExModelGain2.DataId = CParamID.ModelControlGain2;
				ctlNumExModelGain2.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);
				ctlNumExModelGain3.DataId = CParamID.ModelControlGain3;
				ctlNumExModelGain3.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExModelFillter1.DataId = CParamID.ModelControlFillter1;
				ctlNumExModelFillter1.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExTrqObsGain.DataId = CParamID.TorqueObserverGain;
				ctlNumExTrqObsGain.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExTrqObsFrq.DataId = CParamID.TorqueObserverFreq;
				ctlNumExTrqObsFrq.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelObsTime.DataId = CParamID.VelocityObserverTime;
				ctlNumExVelObsTime.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelObsVelComp.DataId = CParamID.VelocityObserverGain1;
				ctlNumExVelObsVelComp.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelObsTdisComp.DataId = CParamID.VelocityObserverGain2;
				ctlNumExVelObsTdisComp.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCurLpfFB.DataId = CParamID.C_FB_Lpf;
				ctlNumExCurLpfFB.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelLpfFB.DataId = CParamID.V_FB_Lpf;
				ctlNumExVelLpfFB.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelFB.DataId = CParamID.V_FB_n;
				ctlNumExVelFB.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				//ctlNumExPosFB.DataId = CParamID.P_FB_n;
				//ctlNumExPosFB.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExPosFFGain.DataId = CParamID.KpffGain;
				ctlNumExPosFFGain.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelFFGain.DataId = CParamID.KvffGain;
				ctlNumExVelFFGain.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelFFPeriod.DataId = CParamID.KvffFillter;
				ctlNumExVelFFPeriod.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExVelFFFillter.DataId = CParamID.KvffFillter;
				ctlNumExVelFFFillter.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCwTrq.DataId = CParamID.FrictionCwTrq;
				ctlNumExCwTrq.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExCcwTrq.DataId = CParamID.FrictionCcwTrq;
				ctlNumExCcwTrq.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExDynamic.DataId = CParamID.FrictionDynamicTrq;
				ctlNumExDynamic.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				ctlNumExGravity.DataId = CParamID.FrictionGravityTrq;
				ctlNumExGravity.NumInputExValueCheange += new dNumInputExValueCheange(NumInputExValueCheange);

				fpnlFeedbackFillter.Visible = true;
				fpnlFeedbackFillter.Dock = DockStyle.Fill;
			}
			else
			{
				grpPosEx.Visible = false;
				grpVelEx.Visible = false;
				grpLoadEx.Visible = false;

				grpCurLpfEx.Visible = false;
				grpCurNotchEx1.Visible = false;
				grpCurNotchEx2.Visible = false;
				grpCurNotchEx3.Visible = false;
				grpCurNotchEx4.Visible = false;
				grpCurNotchEx5.Visible = false;

				grpVelLpfEx.Visible = false;
				grpVelNotchEx1.Visible = false;

				grpPosLpfEx.Visible = false;
				grpPosNotchEx1.Visible = false;

				grpModelEx.Visible = false;
				grpTrqOvsEx.Visible = false;
				grpVelOvsEx.Visible = false;

				fpnlFeedbackFillter.Visible = false;

			}

			#endregion

			if (!Properties.Settings.Default.PASSWORD_LOCK)
			{
				tabServoGain.TabPages.RemoveAt(7);		//モデル追従制御
			}

			TimerGain.Interval = 1000;
			TimerSave.Interval = 1000;

			_IsDisableEvent = false;
		}

		void NumInputExValueCheange(CtlNumericInputEx ctl)
		{
			if (_IsDisableEvent) { return; }

			int id = ctl.DataId;
			int val = ctl.IntValue;

			NumInputValueChange(id, val);
		}

		static public GainControlForm ThisForm
		{
			get { return _ThisForm; }
		}

		public void InitFormLayout()
		{
			if (ThisForm == null) { return; }

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ThisForm.Location = new Point(0, 0);
			ThisForm.Size = new Size(w, h);

			ThisForm.WindowState = FormWindowState.Normal;
		}

		public bool EnableUpdate
		{
			get
			{
				if (!this.Visible) { return false; }
				if (this.WindowState == FormWindowState.Minimized) { return false; }

				return true;
			}
		}

		public bool IsExist
		{
			set { _IsExist = value; }
			get { return _IsExist; }
		}

		#region Feedback

		public void SetServoGain()
		{
			if (this.WindowState == FormWindowState.Minimized) { return; }

			if (_IsGainChange) { return; }

			_IsDisableEvent = true;

			try
			{
		
				if (UseNumInputEx)
				{
					ctlNumExKp.IntValue = CMonitor.GetParameter(CParamID.Kp1);
					ctlNumExKv.IntValue = CMonitor.GetParameter(CParamID.Kv1);
					ctlNumExKi.IntValue = CMonitor.GetParameter(CParamID.Ki1);
					ctlNumExLoad.IntValue = CMonitor.GetParameter(CParamID.Load);

					ctlNumExTuningFree.IntValue = CMonitor.GetParameter(CParamID.TuningFreeStrength);
				
					ctlNumExCurLpf.IntValue = CMonitor.GetParameter(CParamID.C_LPF_f);
					ctlNumExCurNotch1_f.IntValue = CMonitor.GetParameter(CParamID.C_NF1_f);
					ctlNumExCurNotch1_d.IntValue = CMonitor.GetParameter(CParamID.C_NF1_d);
					ctlNumExCurNotch1_q.IntValue = CMonitor.GetParameter(CParamID.C_NF1_q);
					ctlNumExCurNotch2_f.IntValue = CMonitor.GetParameter(CParamID.C_NF2_f);
					ctlNumExCurNotch2_d.IntValue = CMonitor.GetParameter(CParamID.C_NF2_d);
					ctlNumExCurNotch2_q.IntValue = CMonitor.GetParameter(CParamID.C_NF2_q);
					ctlNumExCurNotch3_f.IntValue = CMonitor.GetParameter(CParamID.C_NF3_f);
					ctlNumExCurNotch3_d.IntValue = CMonitor.GetParameter(CParamID.C_NF3_d);
					ctlNumExCurNotch3_q.IntValue = CMonitor.GetParameter(CParamID.C_NF3_q);
					ctlNumExCurNotch4_f.IntValue = CMonitor.GetParameter(CParamID.C_NF4_f);
					ctlNumExCurNotch4_d.IntValue = CMonitor.GetParameter(CParamID.C_NF4_d);
					ctlNumExCurNotch4_q.IntValue = CMonitor.GetParameter(CParamID.C_NF4_q);
					ctlNumExCurNotch5_f.IntValue = CMonitor.GetParameter(CParamID.C_NF5_f);
					ctlNumExCurNotch5_d.IntValue = CMonitor.GetParameter(CParamID.C_NF5_d);
					ctlNumExCurNotch5_q.IntValue = CMonitor.GetParameter(CParamID.C_NF5_q);

					ctlNumExVelLpf.IntValue = CMonitor.GetParameter(CParamID.V_LPF_f);
					//ctlNumVelNotchEx1_f.IntValue = CMonitor.GetParameter(CParamID.V_NF1_f);
					//ctlNumVelNotchEx1_d.IntValue = CMonitor.GetParameter(CParamID.V_NF1_d);
					//ctlNumVelNotchEx1_q.IntValue = CMonitor.GetParameter(CParamID.V_NF1_q);

					//ctlNumPosLpfEx.IntValue = CMonitor.GetParameter(CParamID.P_LPF_f);
					//ctlNumPosNotchEx1_f.IntValue = CMonitor.GetParameter(CParamID.P_NF1_f);
					//ctlNumPosNotchEx1_d.IntValue = CMonitor.GetParameter(CParamID.P_NF1_d);
					//ctlNumPosNotchEx1_q.IntValue = CMonitor.GetParameter(CParamID.P_NF1_q);

					ctlNumExModelGain1.IntValue = CMonitor.GetParameter(CParamID.ModelControlGain1);
					ctlNumExModelGain2.IntValue = CMonitor.GetParameter(CParamID.ModelControlGain2);
					ctlNumExModelGain3.IntValue = CMonitor.GetParameter(CParamID.ModelControlGain3);

					ctlNumExModelFillter1.IntValue = CMonitor.GetParameter(CParamID.ModelControlFillter1);
			
					ctlNumExTrqObsGain.IntValue = CMonitor.GetParameter(CParamID.TorqueObserverGain);
					ctlNumExTrqObsFrq.IntValue = CMonitor.GetParameter(CParamID.TorqueObserverFreq);

					ctlNumExVelObsTime.IntValue = CMonitor.GetParameter(CParamID.VelocityObserverTime);
					ctlNumExVelObsVelComp.IntValue = CMonitor.GetParameter(CParamID.VelocityObserverGain1);
					ctlNumExVelObsTdisComp.IntValue = CMonitor.GetParameter(CParamID.VelocityObserverGain2);

					if (MainForm.DriverRevision >= AppConst.UpTadVer520)		//20161031 update
					{
						//フィードバックフィルタLPF遮断周波数
						grpCurLpfFB.Visible = true;
						grpVelLpfFB.Visible = true;
						ctlNumExCurLpfFB.IntValue = CMonitor.GetParameter(CParamID.C_FB_Lpf);
						ctlNumExVelLpfFB.IntValue = CMonitor.GetParameter(CParamID.V_FB_Lpf);

						grpVelFBEx.Visible = false;
					}
					else
					{
						//フィードバックフィルタ移動平均回数
						grpVelLpfEx.Visible = true;
						ctlNumExVelFB.IntValue = CMonitor.GetParameter(CParamID.V_FB_n);

						grpCurLpfFB.Visible = false;
						grpVelLpfFB.Visible = false;
					}
								
					//フィードフォワード
					ctlNumExPosFFGain.IntValue = CMonitor.GetParameter(CParamID.KpffGain);

					ctlNumExVelFFGain.IntValue = CMonitor.GetParameter(CParamID.KvffGain);

					int seg = CMonitor.GetParameter(CParamID.KvffFillter);

					ctlNumExVelFFPeriod.IntValue  =  seg & 0x000F;
					ctlNumExVelFFFillter.IntValue = (seg & 0x00F0) >> 4;

					//摩擦補正
					ctlNumExCwTrq.IntValue = CMonitor.GetParameter(CParamID.FrictionCwTrq);
					ctlNumExCcwTrq.IntValue = CMonitor.GetParameter(CParamID.FrictionCcwTrq);
					ctlNumExDynamic.IntValue = CMonitor.GetParameter(CParamID.FrictionDynamicTrq);
					ctlNumExGravity.IntValue = CMonitor.GetParameter(CParamID.FrictionGravityTrq);
					
				}

				//電流指令ローパスフィルタ次数
				if (CMonitor.GetParameter(CParamID.C_LPF_n) == 1)
				{
					chkCurLPF1.Checked = true;
				}
				else
				{
					chkCurLPF1.Checked = false;
				}

				//速度指令ローパスフィルタ次数
				if (CMonitor.GetParameter(CParamID.V_LPF_n) == 1)
				{
					chkVelLPF1.Checked = true;
				}
				else
				{
					chkVelLPF1.Checked = false;
				}

				//位置指令ローパスフィルタ次数
				if (CMonitor.GetParameter(CParamID.P_LPF_n) == 1)
				{
					chkPosLPF1.Checked = true;
				}
				else
				{
					chkPosLPF1.Checked = false;
				}

				int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

				int tune_free = CMonitor.GetParameter(CParamID.TuningFreeEnable);

				//チューニングフリー（負荷推定のみ）有効・無効
				if (tune_free == 1 || tune_free == 2)
				{
					chkTuningFree.Checked = true;
					if (tune_free == 1) { rdoLoadOnly.Checked = true; }
					if (tune_free == 2) { rdoLoadFriction.Checked = true; }
				}
				else
				{
					chkTuningFree.Checked = false;
				}

				//適応フィルタ1　有効・無効
				if ((obs_sw & 0x800) == 0x800)
				{
					chkAdaptiveFilter1.Checked = true;
				}
				else
				{
					chkAdaptiveFilter1.Checked = false;
				}

				//適応フィルタ2　有効・無効
				if ((obs_sw & 0x1000) == 0x1000)
				{
					chkAdaptiveFilter2.Checked = true;
				}
				else
				{
					chkAdaptiveFilter2.Checked = false;
				}

				//モデル追従制御
				if ((obs_sw & 0x100) == 0x100)
				{
					chkModelControlEnable1.Checked = true;
				}
				else
				{
					chkModelControlEnable1.Checked = false;
				}

				//モデル追従制御モータモデル
				if ((obs_sw & 0x200) == 0x200)
				{
					chkModelControlMotorModel1.Checked = true;
				}
				else
				{
					chkModelControlMotorModel1.Checked = false;
				}

				//外乱オブザーバ
				if ((obs_sw & 0x01) == 0x01)
				{
					chkTorqueObserverEnable1.Checked = true;
				}
				else
				{
					chkTorqueObserverEnable1.Checked = false;
				}

				//瞬時速度オブザーバ
				if ((obs_sw & 0x10) == 0x10)
				{
					chkVelocityObserverEnable1.Checked = true;
				}
				else
				{
					chkVelocityObserverEnable1.Checked = false;
				}

				//瞬時速度オブザーバ（外乱抑制機能有効）
				if ((obs_sw & 0x20) == 0x20)
				{
					chkVelocityObserverTdisEnable1.Checked = true;
				}
				else
				{
					chkVelocityObserverTdisEnable1.Checked = false;
				}

                // ↓↓↓ 20210324 Kimura add ↓↓
                lblInertiaUnit.Text = UserText.InertiaUnit;
                // ↑↑↑ 20210324 Kimura add ↑↑↑

				_IsDisableEvent = false;

			}
			catch
			{
				_IsDisableEvent = false;
			}
		}

		#endregion

		#region Callback NumericInput Event

		void NumInputValueChange(int id, int val)
		{
			if (_IsDisableEvent) { return; }

			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			if (id == CParamID.KvffFillter)
			{
				int seg0 = ctlNumExVelFFPeriod.IntValue;
				int seg1 = ctlNumExVelFFFillter.IntValue;
				
				val = (seg1 << 4) | seg0;

				if (!CCommandTx.WriteSvNet(id, val)) { return; }
			}
			else
			{
				if (!CCommandTx.WriteSvNet(id, val)) { return; }
			}

			TimerGain.Enabled = true;
			TimerGain.Start();
		}

		#endregion

		#region Form Event

		private void GainControlForm_Load(object sender, EventArgs e)
		{
			InitFormLayout();
            ViewCultureResouceChanged();
            
			tabServoGain.TabPages.RemoveAt(2);
			tabServoGain.TabPages.RemoveAt(2);

			fpnlServoGain.Select();

            // ↓↓↓ 20210324 Kimura add ↓↓↓
            ctlNumExLoad.UnitVisible = false;
            lblInertiaUnit.Text = UserText.InertiaUnit;
            // ↑↑↑ 20210324 Kimura add ↑↑↑
		}

		private void GainControlForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				FormPosition = this.Location;
				FormSize = this.Size;
			}

			if (e.CloseReason == CloseReason.MdiFormClosing)
			{
		
			}
			else
			{
				_IsExist = false;
			}
		}

		private void GainControlForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Normal;
				InitFormLayout();

				ResizeWidth = ThisMdiClient.ClientRectangle.Width;
				ResizeHeight = ThisMdiClient.ClientRectangle.Height;

				TimerResize.Enabled = true;
				TimerResize.Start();
			}
		}

		private void fpnlGain_Click(object sender, EventArgs e)
		{
			FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
			fpnl.Focus();
			this.Activate();
		}

		private void pnlGain_Click(object sender, EventArgs e)
		{
			Panel pnl = (Panel)sender;
			pnl.Focus();
			this.Activate();
		}

		#endregion

		#region Combobox Event

		private void tcmbGain_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void tcmbGain_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		#endregion

		#region Button Event

		private void tbtnSaveGain_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			fpnlServoGain.Select();

			DialogResult ret = UserMessageBox.CommonSaveFlash();
			
			if (ret == DialogResult.Yes)
			{
				//FLASH保存
				if (!CCommandTx.WriteSvNet(17, 1)) { UserMessageBox.CommonUsbError(); return; }

				TimerSave.Enabled = false;
				tbtnSaveGain.BackColor = SystemColors.Control;
				this.Refresh();

				SaveMsg = new SaveProgressDialog();

				SaveMsg.StartFlashMemorySave(ThisParentForm.Location, ThisParentForm.Size, 1);

				SaveMsg.Close();
			}
		}

		#endregion

		#region Checkbox Event

		private void chkVelocityObserverEnable_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				obs_sw |= 0x10;		//瞬時速度オブザーバ有効
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				obs_sw &= ~0x10;	//瞬時速度オブザーバ無効
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void chkVelocityObserverTdisEnable_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				obs_sw |= 0x20;		//瞬時速度オブザーバ外乱抑制機能有効
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				obs_sw &= ~0x20;		//瞬時速度オブザーバ外乱抑制機能無効
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void chkTorqueObserverEnable_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			CheckBox chk = (CheckBox)sender;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			if (chk.Checked)
			{
				obs_sw |= 0x01;		//外乱オブザーバ有効
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				obs_sw &= ~0x01;	//外乱オブザーバ無効
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void chkModelControlEnable_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				obs_sw |= 0x100;		//モデル追従制御有効
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				obs_sw &= ~0x100;		//モデル追従制御無効
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void chkModelControlMotorModel_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				obs_sw |= 0x200;		//モータ3相モデル有効
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				obs_sw &= ~0x200;		//モータ3相モデル無効
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void chkCurLPF_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int lpf_n = new int();

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				lpf_n = 1;		//ローパスフィルタ1次
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.C_LPF_n, lpf_n);
		}

		private void chkVelLPF_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int lpf_n = new int();

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				lpf_n = 1;		//ローパスフィルタ1次
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.V_LPF_n, lpf_n);
		}

		private void chkPosLPF_CheckStateChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }	//20160328 add

			_IsGainChange = true;

			int lpf_n = new int();

			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{
				lpf_n = 1;		//ローパスフィルタ1次
				chk.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chk.BackColor = AppFont.NormalBackColor;
			}

			WriteGain(CParamID.P_LPF_n, lpf_n);
		}

		private void chkTuningFree_CheckedChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			_IsGainChange = true;

			int tune_free = CMonitor.GetParameter(CParamID.TuningFreeEnable);

			if (chkTuningFree.Checked)
			{
				chkTuningFree.BackColor = Color.Gold;
				if (rdoLoadOnly.Checked) { tune_free = 1; }
				if (rdoLoadFriction.Checked) { tune_free = 2; }
			}
			else
			{
				chkTuningFree.BackColor = SystemColors.Control;
				tune_free = 0;
			}

			WriteGain(CParamID.TuningFreeEnable, tune_free);
		}

		private void chkAdaptiveFilter1_CheckedChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			_IsGainChange = true;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			if (chkAdaptiveFilter1.Checked)
			{
				chkAdaptiveFilter1.BackColor = Color.Gold;
				obs_sw |= 0x800;
			}
			else
			{
				chkAdaptiveFilter1.BackColor = SystemColors.Control;
				obs_sw &= ~0x800;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void chkAdaptiveFilter2_CheckedChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			_IsGainChange = true;

			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			if (chkAdaptiveFilter2.Checked)
			{
				chkAdaptiveFilter2.BackColor = Color.Gold;
				obs_sw |= 0x1000;
			}
			else
			{
				chkAdaptiveFilter2.BackColor = SystemColors.Control;
				obs_sw &= ~0x1000;
			}

			WriteGain(CParamID.ObserberSwitch, obs_sw);
		}

		private void WriteGain(int id, int data)
		{
			if (!_IsDisableEvent)
			{
				if (!CCommandTx.WriteSvNet(id, data)) { return; }

				TimerGain.Enabled = true;
				TimerGain.Start();
			}
			else
			{
				_IsGainChange = false;	
			}
		}

		#endregion

		#region Timer Event

		private void TimerGain_Tick(object sender, EventArgs e)
		{
			_IsGainChange = false;
			TimerGain.Enabled = false;

			if (!_IsDisableEvent)
			{
				//TimerSave.Enabled = true;
				//TimerSave.Start();
				tbtnSaveGain.BackColor = Color.Aqua;
			}
		}


		private int SaveReqSt = new int();

		private void TimerSave_Tick(object sender, EventArgs e)
		{
			switch (SaveReqSt)
			{
				case 0:
					tbtnSaveGain.BackColor = Color.LightCyan;
					break;
			}

			//if (tbtnSaveGain.BackColor == SystemColors.Control)
			//{
			//    tbtnSaveGain.BackColor = Color.Aqua;
			//}
			//else
			//{
			//    tbtnSaveGain.BackColor = SystemColors.Control;
			//}
		}

		private void TimerResize_Tick(object sender, EventArgs e)
		{
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			if (ResizeWidth != w || ResizeHeight != h)
			{
				InitFormLayout();
			}

			TimerResize.Enabled = false;
		}

		#endregion

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.Select();
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GainControlForm));

            this.Font = (Font)resources.GetObject("$this.Font");
            chkCurLPF1.Font = (Font)resources.GetObject("chkCurLPF1.Font");
            chkModelControlEnable1.Font = (Font)resources.GetObject("chkModelControlEnable1.Font");
            chkModelControlMotorModel1.Font = (Font)resources.GetObject("chkModelControlMotorModel1.Font");
            chkPosLPF1.Font = (Font)resources.GetObject("chkPosLPF1.Font");
            chkTorqueObserverEnable1.Font = (Font)resources.GetObject("chkTorqueObserverEnable1.Font");
            chkVelLPF1.Font = (Font)resources.GetObject("chkVelLPF1.Font");
            chkVelocityObserverEnable1.Font = (Font)resources.GetObject("chkVelocityObserverEnable1.Font");
            chkVelocityObserverTdisEnable1.Font = (Font)resources.GetObject("chkVelocityObserverTdisEnable1.Font");
            ctlNumExPosFB.TitleFont = (Font)resources.GetObject("ctlExNumPosFB.TitleFont");
            ctlNumExPosFB.UnitFont = (Font)resources.GetObject("ctlExNumPosFB.UnitFont");
            ctlNumExCcwTrq.TitleFont = (Font)resources.GetObject("ctlNumExCcwTrq.TitleFont");
            ctlNumExCcwTrq.UnitFont = (Font)resources.GetObject("ctlNumExCcwTrq.UnitFont");
			ctlNumExCurLpf.TitleFont = (Font)resources.GetObject("ctlNumExCurLpf.TitleFont");
			ctlNumExCurLpf.UnitFont = (Font)resources.GetObject("ctlNumExCurLpf.UnitFont");
			ctlNumExCurLpfFB.TitleFont = (Font)resources.GetObject("ctlNumExCurLpfFB.TitleFont");
			ctlNumExCurLpfFB.UnitFont = (Font)resources.GetObject("ctlNumExCurLpfFB.UnitFont");
			ctlNumExCurNotch1_d.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch1_d.TitleFont");
            ctlNumExCurNotch1_d.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch1_d.UnitFont");
            ctlNumExCurNotch1_f.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch1_f.TitleFont");
            ctlNumExCurNotch1_f.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch1_f.UnitFont");
            ctlNumExCurNotch1_q.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch1_q.TitleFont");
            ctlNumExCurNotch1_q.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch1_q.UnitFont");
            ctlNumExCurNotch2_d.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch2_d.TitleFont");
            ctlNumExCurNotch2_d.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch2_d.UnitFont");
            ctlNumExCurNotch2_f.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch2_f.TitleFont");
            ctlNumExCurNotch2_f.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch2_f.UnitFont");
            ctlNumExCurNotch2_q.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch2_q.TitleFont");
            ctlNumExCurNotch2_q.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch2_q.UnitFont");
            ctlNumExCurNotch3_d.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch3_d.TitleFont");
            ctlNumExCurNotch3_d.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch3_d.UnitFont");
            ctlNumExCurNotch3_f.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch3_f.TitleFont");
            ctlNumExCurNotch3_f.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch3_f.UnitFont");
            ctlNumExCurNotch3_q.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch3_q.TitleFont");
            ctlNumExCurNotch3_q.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch3_q.UnitFont");
            ctlNumExCurNotch4_d.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch4_d.TitleFont");
            ctlNumExCurNotch4_d.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch4_d.UnitFont");
            ctlNumExCurNotch4_f.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch4_f.TitleFont");
            ctlNumExCurNotch4_f.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch4_f.UnitFont");
            ctlNumExCurNotch4_q.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch4_q.TitleFont");
            ctlNumExCurNotch4_q.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch4_q.UnitFont");
            ctlNumExCurNotch5_d.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch5_d.TitleFont");
            ctlNumExCurNotch5_d.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch5_d.UnitFont");
            ctlNumExCurNotch5_f.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch5_f.TitleFont");
            ctlNumExCurNotch5_f.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch5_f.UnitFont");
            ctlNumExCurNotch5_q.TitleFont = (Font)resources.GetObject("ctlNumExCurNotch5_q.TitleFont");
            ctlNumExCurNotch5_q.UnitFont = (Font)resources.GetObject("ctlNumExCurNotch5_q.UnitFont");
            ctlNumExCwTrq.TitleFont = (Font)resources.GetObject("ctlNumExCwTrq.TitleFont");
            ctlNumExCwTrq.UnitFont = (Font)resources.GetObject("ctlNumExCwTrq.UnitFont");
            ctlNumExDynamic.TitleFont = (Font)resources.GetObject("ctlNumExDynamic.TitleFont");
            ctlNumExDynamic.UnitFont = (Font)resources.GetObject("ctlNumExDynamic.UnitFont");
            ctlNumExGravity.TitleFont = (Font)resources.GetObject("ctlNumExGravity.TitleFont");
            ctlNumExGravity.UnitFont = (Font)resources.GetObject("ctlNumExGravity.UnitFont");
            ctlNumExKi.TitleFont = (Font)resources.GetObject("ctlNumExKi.TitleFont");
            ctlNumExKi.UnitFont = (Font)resources.GetObject("ctlNumExKi.UnitFont");
            ctlNumExKp.TitleFont = (Font)resources.GetObject("ctlNumExKp.TitleFont");
            ctlNumExKp.UnitFont = (Font)resources.GetObject("ctlNumExKp.UnitFont");
            ctlNumExKv.TitleFont = (Font)resources.GetObject("ctlNumExKv.TitleFont");
            ctlNumExKv.UnitFont = (Font)resources.GetObject("ctlNumExKv.UnitFont");
            ctlNumExLoad.TitleFont = (Font)resources.GetObject("ctlNumExLoad.TitleFont");
            ctlNumExLoad.UnitFont = (Font)resources.GetObject("ctlNumExLoad.UnitFont");
			ctlNumExModelGain1.TitleFont = (Font)resources.GetObject("ctlNumExModelGain1.TitleFont");
			ctlNumExModelGain1.UnitFont = (Font)resources.GetObject("ctlNumExModelGain1.UnitFont");
			ctlNumExModelGain2.TitleFont = (Font)resources.GetObject("ctlNumExModelGain2.TitleFont");
			ctlNumExModelGain2.UnitFont = (Font)resources.GetObject("ctlNumExModelGain2.UnitFont");
			ctlNumExModelGain3.TitleFont = (Font)resources.GetObject("ctlNumExModelGain3.TitleFont");
			ctlNumExModelGain3.UnitFont = (Font)resources.GetObject("ctlNumExModelGain3.UnitFont");
			ctlNumExModelFillter1.TitleFont = (Font)resources.GetObject("ctlNumExModelFillter1.TitleFont");
			ctlNumExModelFillter1.UnitFont = (Font)resources.GetObject("ctlNumExModelFillter1.UnitFont");
			ctlNumExPosFFGain.TitleFont = (Font)resources.GetObject("ctlNumExPosFFGain.TitleFont");
            ctlNumExPosFFGain.UnitFont = (Font)resources.GetObject("ctlNumExPosFFGain.UnitFont");
            ctlNumExPosLpf.TitleFont = (Font)resources.GetObject("ctlNumExPosLpf.TitleFont");
            ctlNumExPosLpf.UnitFont = (Font)resources.GetObject("ctlNumExPosLpf.UnitFont");
            ctlNumExPosNotch1_d.TitleFont = (Font)resources.GetObject("ctlNumExPosNotch1_d.TitleFont");
            ctlNumExPosNotch1_d.UnitFont = (Font)resources.GetObject("ctlNumExPosNotch1_d.UnitFont");
            ctlNumExPosNotch1_f.TitleFont = (Font)resources.GetObject("ctlNumExPosNotch1_f.TitleFont");
            ctlNumExPosNotch1_f.UnitFont = (Font)resources.GetObject("ctlNumExPosNotch1_f.UnitFont");
            ctlNumExPosNotch1_q.TitleFont = (Font)resources.GetObject("ctlNumExPosNotch1_q.TitleFont");
            ctlNumExPosNotch1_q.UnitFont = (Font)resources.GetObject("ctlNumExPosNotch1_q.UnitFont");
            ctlNumExTrqObsFrq.TitleFont = (Font)resources.GetObject("ctlNumExTrqObsFrq.TitleFont");
            ctlNumExTrqObsFrq.UnitFont = (Font)resources.GetObject("ctlNumExTrqObsFrq.UnitFont");
            ctlNumExTrqObsGain.TitleFont = (Font)resources.GetObject("ctlNumExTrqObsGain.TitleFont");
            ctlNumExTrqObsGain.UnitFont = (Font)resources.GetObject("ctlNumExTrqObsGain.UnitFont");
            ctlNumExVelFB.TitleFont = (Font)resources.GetObject("ctlNumExVelFB.TitleFont");
            ctlNumExVelFB.UnitFont = (Font)resources.GetObject("ctlNumExVelFB.UnitFont");
            ctlNumExVelFFFillter.TitleFont = (Font)resources.GetObject("ctlNumExVelFFFillter.TitleFont");
            ctlNumExVelFFFillter.UnitFont = (Font)resources.GetObject("ctlNumExVelFFFillter.UnitFont");
            ctlNumExVelFFGain.TitleFont = (Font)resources.GetObject("ctlNumExVelFFGain.TitleFont");
            ctlNumExVelFFGain.UnitFont = (Font)resources.GetObject("ctlNumExVelFFGain.UnitFont");
            ctlNumExVelFFPeriod.TitleFont = (Font)resources.GetObject("ctlNumExVelFFPeriod.TitleFont");
            ctlNumExVelFFPeriod.UnitFont = (Font)resources.GetObject("ctlNumExVelFFPeriod.UnitFont");
			ctlNumExVelLpf.TitleFont = (Font)resources.GetObject("ctlNumExVelLpf.TitleFont");
			ctlNumExVelLpf.UnitFont = (Font)resources.GetObject("ctlNumExVelLpf.UnitFont");
			ctlNumExVelLpfFB.TitleFont = (Font)resources.GetObject("ctlNumExVelLpfFB.TitleFont");
			ctlNumExVelLpfFB.UnitFont = (Font)resources.GetObject("ctlNumExVelLpfFB.UnitFont");
			ctlNumExVelNotch1_d.TitleFont = (Font)resources.GetObject("ctlNumExVelNotch1_d.TitleFont");
            ctlNumExVelNotch1_d.UnitFont = (Font)resources.GetObject("ctlNumExVelNotch1_d.UnitFont");
            ctlNumExVelNotch1_f.TitleFont = (Font)resources.GetObject("ctlNumExVelNotch1_f.TitleFont");
            ctlNumExVelNotch1_f.UnitFont = (Font)resources.GetObject("ctlNumExVelNotch1_f.UnitFont");
            ctlNumExVelNotch1_q.TitleFont = (Font)resources.GetObject("ctlNumExVelNotch1_q.TitleFont");
            ctlNumExVelNotch1_q.UnitFont = (Font)resources.GetObject("ctlNumExVelNotch1_q.UnitFont");
            ctlNumExVelObsTdisComp.TitleFont = (Font)resources.GetObject("ctlNumExVelObsTdisComp.TitleFont");
            ctlNumExVelObsTdisComp.UnitFont = (Font)resources.GetObject("ctlNumExVelObsTdisComp.UnitFont");
            ctlNumExVelObsTime.TitleFont = (Font)resources.GetObject("ctlNumExVelObsTime.TitleFont");
            ctlNumExVelObsTime.UnitFont = (Font)resources.GetObject("ctlNumExVelObsTime.UnitFont");
            ctlNumExVelObsVelComp.TitleFont = (Font)resources.GetObject("ctlNumExVelObsVelComp.TitleFont");
            ctlNumExVelObsVelComp.UnitFont = (Font)resources.GetObject("ctlNumExVelObsVelComp.UnitFont");
			grpCurLpfEx.Font = (Font)resources.GetObject("grpCurLpfEx.Font");
			grpCurLpfFB.Font = (Font)resources.GetObject("grpCurLpfFB.Font");
			grpCurNotchEx1.Font = (Font)resources.GetObject("grpCurNotchEx1.Font");
            grpCurNotchEx2.Font = (Font)resources.GetObject("grpCurNotchEx2.Font");
            grpCurNotchEx3.Font = (Font)resources.GetObject("grpCurNotchEx3.Font");
            grpCurNotchEx4.Font = (Font)resources.GetObject("grpCurNotchEx4.Font");
            grpCurNotchEx5.Font = (Font)resources.GetObject("grpCurNotchEx5.Font");
            grpFriction.Font = (Font)resources.GetObject("grpFriction.Font");
            grpLoadEx.Font = (Font)resources.GetObject("grpLoadEx.Font");
            grpModelEx.Font = (Font)resources.GetObject("grpModelEx.Font");
            grpPosEx.Font = (Font)resources.GetObject("grpPosEx.Font");
            grpPosFBEx.Font = (Font)resources.GetObject("grpPosFBEx.Font");
            grpPosFF.Font = (Font)resources.GetObject("grpPosFF.Font");
            grpPosLpfEx.Font = (Font)resources.GetObject("grpPosLpfEx.Font");
            grpPosNotchEx1.Font = (Font)resources.GetObject("grpPosNotchEx1.Font");
            grpTrqOvsEx.Font = (Font)resources.GetObject("grpTrqOvsEx.Font");
            grpVelEx.Font = (Font)resources.GetObject("grpVelEx.Font");
            grpVelFBEx.Font = (Font)resources.GetObject("grpVelFBEx.Font");
            grpVelFF.Font = (Font)resources.GetObject("grpVelFF.Font");
			grpVelLpfEx.Font = (Font)resources.GetObject("grpVelLpfEx.Font");
			grpVelLpfFB.Font = (Font)resources.GetObject("grpVelLpfFB.Font");
			grpVelNotchEx1.Font = (Font)resources.GetObject("grpVelNotchEx1.Font");
            grpVelOvsEx.Font = (Font)resources.GetObject("grpVelOvsEx.Font");
            lblCurLPF3.Font = (Font)resources.GetObject("lblCurLPF3.Font");
            lblPosFBEx.Font = (Font)resources.GetObject("lblPosFBEx.Font");
            lblPosLPF3.Font = (Font)resources.GetObject("lblPosLPF3.Font");
            lblVelFBEx.Font = (Font)resources.GetObject("lblVelFBEx.Font");
            lblVelFFFillter.Font = (Font)resources.GetObject("lblVelFFFillter.Font");
            lblVelFFPeriod.Font = (Font)resources.GetObject("lblVelFFPeriod.Font");
            lblVelLPF3.Font = (Font)resources.GetObject("lblVelLPF3.Font");
            tabPageCurrentFillter.Font = (Font)resources.GetObject("tabPageCurrentFillter.Font");
            tabPageFeedback.Font = (Font)resources.GetObject("tabPageFeedback.Font");
            tabPageFeedforward.Font = (Font)resources.GetObject("tabPageFeedforward.Font");
            tabPageFriction.Font = (Font)resources.GetObject("tabPageFriction.Font");
            tabPageModel.Font = (Font)resources.GetObject("tabPageModel.Font");
            tabPagePositionFillter.Font = (Font)resources.GetObject("tabPagePositionFillter.Font");
            tabPageServoGain.Font = (Font)resources.GetObject("tabPageServoGain.Font");
            tabPageTorqueObserver.Font = (Font)resources.GetObject("tabPageTorqueObserver.Font");
            tabPageVelocityFillter.Font = (Font)resources.GetObject("tabPageVelocityFillter.Font");
            tabPageVelocityObserver.Font = (Font)resources.GetObject("tabPageVelocityObserver.Font");
            tbtnSaveGain.Font = (Font)resources.GetObject("tbtnSaveGain.Font");
            tabServoGain.Font = (Font)resources.GetObject("tabServoGain.Font");

            tabServoGain.ItemSize = (Size)resources.GetObject("tabServoGain.ItemSize");
            
            this.Text = resources.GetString("$this.Text");
            chkCurLPF1.Text = resources.GetString("chkCurLPF1.Text");
            chkModelControlEnable1.Text = resources.GetString("chkModelControlEnable1.Text");
            chkModelControlMotorModel1.Text = resources.GetString("chkModelControlMotorModel1.Text");
            chkPosLPF1.Text = resources.GetString("chkPosLPF1.Text");
            chkTorqueObserverEnable1.Text = resources.GetString("chkTorqueObserverEnable1.Text");
            chkVelLPF1.Text = resources.GetString("chkVelLPF1.Text");
            chkVelocityObserverEnable1.Text = resources.GetString("chkVelocityObserverEnable1.Text");
            chkVelocityObserverTdisEnable1.Text = resources.GetString("chkVelocityObserverTdisEnable1.Text");
            ctlNumExPosFB.TitleText = resources.GetString("ctlExNumPosFB.TitleText");
            ctlNumExPosFB.UnitText = resources.GetString("ctlExNumPosFB.UnitText");
            ctlNumExCcwTrq.TitleText = resources.GetString("ctlNumExCcwTrq.TitleText");
            ctlNumExCcwTrq.UnitText = resources.GetString("ctlNumExCcwTrq.UnitText");
            ctlNumExCurLpf.TitleText = resources.GetString("ctlNumExCurLpf.TitleText");
            ctlNumExCurLpf.UnitText = resources.GetString("ctlNumExCurLpf.UnitText");
			ctlNumExCurLpfFB.TitleText = resources.GetString("ctlNumExCurLpfFB.TitleText");
			ctlNumExCurLpfFB.UnitText = resources.GetString("ctlNumExCurLpfFB.UnitText");
			ctlNumExCurNotch1_d.TitleText = resources.GetString("ctlNumExCurNotch1_d.TitleText");
            ctlNumExCurNotch1_d.UnitText = resources.GetString("ctlNumExCurNotch1_d.UnitText");
            ctlNumExCurNotch1_f.TitleText = resources.GetString("ctlNumExCurNotch1_f.TitleText");
            ctlNumExCurNotch1_f.UnitText = resources.GetString("ctlNumExCurNotch1_f.UnitText");
            ctlNumExCurNotch1_q.TitleText = resources.GetString("ctlNumExCurNotch1_q.TitleText");
            ctlNumExCurNotch1_q.UnitText = resources.GetString("ctlNumExCurNotch1_q.UnitText");
            ctlNumExCurNotch2_d.TitleText = resources.GetString("ctlNumExCurNotch2_d.TitleText");
            ctlNumExCurNotch2_d.UnitText = resources.GetString("ctlNumExCurNotch2_d.UnitText");
            ctlNumExCurNotch2_f.TitleText = resources.GetString("ctlNumExCurNotch2_f.TitleText");
            ctlNumExCurNotch2_f.UnitText = resources.GetString("ctlNumExCurNotch2_f.UnitText");
            ctlNumExCurNotch2_q.TitleText = resources.GetString("ctlNumExCurNotch2_q.TitleText");
            ctlNumExCurNotch2_q.UnitText = resources.GetString("ctlNumExCurNotch2_q.UnitText");
            ctlNumExCurNotch3_d.TitleText = resources.GetString("ctlNumExCurNotch3_d.TitleText");
            ctlNumExCurNotch3_d.UnitText = resources.GetString("ctlNumExCurNotch3_d.UnitText");
            ctlNumExCurNotch3_f.TitleText = resources.GetString("ctlNumExCurNotch3_f.TitleText");
            ctlNumExCurNotch3_f.UnitText = resources.GetString("ctlNumExCurNotch3_f.UnitText");
            ctlNumExCurNotch3_q.TitleText = resources.GetString("ctlNumExCurNotch3_q.TitleText");
            ctlNumExCurNotch3_q.UnitText = resources.GetString("ctlNumExCurNotch3_q.UnitText");
            ctlNumExCurNotch4_d.TitleText = resources.GetString("ctlNumExCurNotch4_d.TitleText");
            ctlNumExCurNotch4_d.UnitText = resources.GetString("ctlNumExCurNotch4_d.UnitText");
            ctlNumExCurNotch4_f.TitleText = resources.GetString("ctlNumExCurNotch4_f.TitleText");
            ctlNumExCurNotch4_f.UnitText = resources.GetString("ctlNumExCurNotch4_f.UnitText");
            ctlNumExCurNotch4_q.TitleText = resources.GetString("ctlNumExCurNotch4_q.TitleText");
            ctlNumExCurNotch4_q.UnitText = resources.GetString("ctlNumExCurNotch4_q.UnitText");
            ctlNumExCurNotch5_d.TitleText = resources.GetString("ctlNumExCurNotch5_d.TitleText");
            ctlNumExCurNotch5_d.UnitText = resources.GetString("ctlNumExCurNotch5_d.UnitText");
            ctlNumExCurNotch5_f.TitleText = resources.GetString("ctlNumExCurNotch5_f.TitleText");
            ctlNumExCurNotch5_f.UnitText = resources.GetString("ctlNumExCurNotch5_f.UnitText");
            ctlNumExCurNotch5_q.TitleText = resources.GetString("ctlNumExCurNotch5_q.TitleText");
            ctlNumExCurNotch5_q.UnitText = resources.GetString("ctlNumExCurNotch5_q.UnitText");
            ctlNumExCwTrq.TitleText = resources.GetString("ctlNumExCwTrq.TitleText");
            ctlNumExCwTrq.UnitText = resources.GetString("ctlNumExCwTrq.UnitText");
            ctlNumExDynamic.TitleText = resources.GetString("ctlNumExDynamic.TitleText");
            ctlNumExDynamic.UnitText = resources.GetString("ctlNumExDynamic.UnitText");
            ctlNumExGravity.TitleText = resources.GetString("ctlNumExGravity.TitleText");
            ctlNumExGravity.UnitText = resources.GetString("ctlNumExGravity.UnitText");
            ctlNumExKi.TitleText = resources.GetString("ctlNumExKi.TitleText");
            ctlNumExKi.UnitText = resources.GetString("ctlNumExKi.UnitText");
            ctlNumExKp.TitleText = resources.GetString("ctlNumExKp.TitleText");
            ctlNumExKp.UnitText = resources.GetString("ctlNumExKp.UnitText");
            ctlNumExKv.TitleText = resources.GetString("ctlNumExKv.TitleText");
            ctlNumExKv.UnitText = resources.GetString("ctlNumExKv.UnitText");
            ctlNumExLoad.TitleText = resources.GetString("ctlNumExLoad.TitleText");
            ctlNumExLoad.UnitText = resources.GetString("ctlNumExLoad.UnitText");
			ctlNumExModelGain1.TitleText = resources.GetString("ctlNumExModelGain1.TitleText");
			ctlNumExModelGain1.UnitText = resources.GetString("ctlNumExModelGain1.UnitText");
			ctlNumExModelGain2.TitleText = resources.GetString("ctlNumExModelGain2.TitleText");
			ctlNumExModelGain2.UnitText = resources.GetString("ctlNumExModelGain2.UnitText");
			ctlNumExModelGain3.TitleText = resources.GetString("ctlNumExModelGain3.TitleText");
			ctlNumExModelGain3.UnitText = resources.GetString("ctlNumExModelGain3.UnitText");
			ctlNumExModelFillter1.TitleText = resources.GetString("ctlNumExModelFillter1.TitleText");
			ctlNumExModelFillter1.UnitText = resources.GetString("ctlNumExModelFillter1.UnitText");
			ctlNumExPosFFGain.TitleText = resources.GetString("ctlNumExPosFFGain.TitleText");
            ctlNumExPosFFGain.UnitText = resources.GetString("ctlNumExPosFFGain.UnitText");
            ctlNumExPosLpf.TitleText = resources.GetString("ctlNumExPosLpf.TitleText");
            ctlNumExPosLpf.UnitText = resources.GetString("ctlNumExPosLpf.UnitText");
            ctlNumExPosNotch1_d.TitleText = resources.GetString("ctlNumExPosNotch1_d.TitleText");
            ctlNumExPosNotch1_d.UnitText = resources.GetString("ctlNumExPosNotch1_d.UnitText");
            ctlNumExPosNotch1_f.TitleText = resources.GetString("ctlNumExPosNotch1_f.TitleText");
            ctlNumExPosNotch1_f.UnitText = resources.GetString("ctlNumExPosNotch1_f.UnitText");
            ctlNumExPosNotch1_q.TitleText = resources.GetString("ctlNumExPosNotch1_q.TitleText");
            ctlNumExPosNotch1_q.UnitText = resources.GetString("ctlNumExPosNotch1_q.UnitText");
            ctlNumExTrqObsFrq.TitleText = resources.GetString("ctlNumExTrqObsFrq.TitleText");
            ctlNumExTrqObsFrq.UnitText = resources.GetString("ctlNumExTrqObsFrq.UnitText");
            ctlNumExTrqObsGain.TitleText = resources.GetString("ctlNumExTrqObsGain.TitleText");
            ctlNumExTrqObsGain.UnitText = resources.GetString("ctlNumExTrqObsGain.UnitText");
            ctlNumExVelFB.TitleText = resources.GetString("ctlNumExVelFB.TitleText");
            ctlNumExVelFB.UnitText = resources.GetString("ctlNumExVelFB.UnitText");
            ctlNumExVelFFFillter.TitleText = resources.GetString("ctlNumExVelFFFillter.TitleText");
            ctlNumExVelFFFillter.UnitText = resources.GetString("ctlNumExVelFFFillter.UnitText");
            ctlNumExVelFFGain.TitleText = resources.GetString("ctlNumExVelFFGain.TitleText");
            ctlNumExVelFFGain.UnitText = resources.GetString("ctlNumExVelFFGain.UnitText");
            ctlNumExVelFFPeriod.TitleText = resources.GetString("ctlNumExVelFFPeriod.TitleText");
            ctlNumExVelFFPeriod.UnitText = resources.GetString("ctlNumExVelFFPeriod.UnitText");
			ctlNumExVelLpf.TitleText = resources.GetString("ctlNumExVelLpf.TitleText");
			ctlNumExVelLpf.UnitText = resources.GetString("ctlNumExVelLpf.UnitText");
			ctlNumExVelLpfFB.TitleText = resources.GetString("ctlNumExVelLpfFB.TitleText");
			ctlNumExVelLpfFB.UnitText = resources.GetString("ctlNumExVelLpfFB.UnitText");
			ctlNumExVelNotch1_d.TitleText = resources.GetString("ctlNumExVelNotch1_d.TitleText");
            ctlNumExVelNotch1_d.UnitText = resources.GetString("ctlNumExVelNotch1_d.UnitText");
            ctlNumExVelNotch1_f.TitleText = resources.GetString("ctlNumExVelNotch1_f.TitleText");
            ctlNumExVelNotch1_f.UnitText = resources.GetString("ctlNumExVelNotch1_f.UnitText");
            ctlNumExVelNotch1_q.TitleText = resources.GetString("ctlNumExVelNotch1_q.TitleText");
            ctlNumExVelNotch1_q.UnitText = resources.GetString("ctlNumExVelNotch1_q.UnitText");
            ctlNumExVelObsTdisComp.TitleText = resources.GetString("ctlNumExVelObsTdisComp.TitleText");
            ctlNumExVelObsTdisComp.UnitText = resources.GetString("ctlNumExVelObsTdisComp.UnitText");
            ctlNumExVelObsTime.TitleText = resources.GetString("ctlNumExVelObsTime.TitleText");
            ctlNumExVelObsTime.UnitText = resources.GetString("ctlNumExVelObsTime.UnitText");
            ctlNumExVelObsVelComp.TitleText = resources.GetString("ctlNumExVelObsVelComp.TitleText");
            ctlNumExVelObsVelComp.UnitText = resources.GetString("ctlNumExVelObsVelComp.UnitText");
			grpCurLpfEx.Text = resources.GetString("grpCurLpfEx.Text");
            grpCurLpfFB.Text = resources.GetString("grpCurLpfFB.Text");
            grpCurNotchEx1.Text = resources.GetString("grpCurNotchEx1.Text");
            grpCurNotchEx2.Text = resources.GetString("grpCurNotchEx2.Text");
            grpCurNotchEx3.Text = resources.GetString("grpCurNotchEx3.Text");
            grpCurNotchEx4.Text = resources.GetString("grpCurNotchEx4.Text");
            grpCurNotchEx5.Text = resources.GetString("grpCurNotchEx5.Text");
            grpFriction.Text = resources.GetString("grpFriction.Text");
            grpLoadEx.Text = resources.GetString("grpLoadEx.Text");
            grpModelEx.Text = resources.GetString("grpModelEx.Text");
            grpPosEx.Text = resources.GetString("grpPosEx.Text");
            grpPosFBEx.Text = resources.GetString("grpPosFBEx.Text");
            grpPosFF.Text = resources.GetString("grpPosFF.Text");
            grpPosLpfEx.Text = resources.GetString("grpPosLpfEx.Text");
            grpPosNotchEx1.Text = resources.GetString("grpPosNotchEx1.Text");
            grpTrqOvsEx.Text = resources.GetString("grpTrqOvsEx.Text");
            grpVelEx.Text = resources.GetString("grpVelEx.Text");
            grpVelFBEx.Text = resources.GetString("grpVelFBEx.Text");
            grpVelFF.Text = resources.GetString("grpVelFF.Text");
			grpVelLpfEx.Text = resources.GetString("grpVelLpfEx.Text");
			grpVelLpfFB.Text = resources.GetString("grpVelLpfFB.Text");
			grpVelNotchEx1.Text = resources.GetString("grpVelNotchEx1.Text");
            grpVelOvsEx.Text = resources.GetString("grpVelOvsEx.Text");
            lblCurLPF3.Text = resources.GetString("lblCurLPF3.Text");
            lblPosFBEx.Text = resources.GetString("lblPosFBEx.Text");
            lblPosLPF3.Text = resources.GetString("lblPosLPF3.Text");
            lblVelFBEx.Text = resources.GetString("lblVelFBEx.Text");
            lblVelFFFillter.Text = resources.GetString("lblVelFFFillter.Text");
            lblVelFFPeriod.Text = resources.GetString("lblVelFFPeriod.Text");
            lblVelLPF3.Text = resources.GetString("lblVelLPF3.Text");
            tabPageCurrentFillter.Text = resources.GetString("tabPageCurrentFillter.Text");
            tabPageFeedback.Text = resources.GetString("tabPageFeedback.Text");
            tabPageFeedforward.Text = resources.GetString("tabPageFeedforward.Text");
            tabPageFriction.Text = resources.GetString("tabPageFriction.Text");
            tabPageModel.Text = resources.GetString("tabPageModel.Text");
            tabPagePositionFillter.Text = resources.GetString("tabPagePositionFillter.Text");
            tabPageServoGain.Text = resources.GetString("tabPageServoGain.Text");
            tabPageTorqueObserver.Text = resources.GetString("tabPageTorqueObserver.Text");
            tabPageVelocityFillter.Text = resources.GetString("tabPageVelocityFillter.Text");
            tabPageVelocityObserver.Text = resources.GetString("tabPageVelocityObserver.Text");
            tbtnSaveGain.Text = resources.GetString("tbtnSaveGain.Text");
            tbtnSaveGain.ToolTipText = resources.GetString("tbtnSaveGain.ToolTipText");

            lblVelFBEx.Location = (Point)resources.GetObject("lblVelFBEx.Location");
            lblPosFBEx.Location = (Point)resources.GetObject("lblPosFBEx.Location");

        }

        #endregion

        #region タブオーナードロー

        /// <summary>
        /// サーボゲインタブオーナードローイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabServoGain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            string txt = tab.TabPages[e.Index].Text;

            Font font;

            LinearGradientBrush gb = new LinearGradientBrush(e.Bounds,
                                                             Color.Cyan,
                                                             Color.DodgerBlue,
                                                             LinearGradientMode.Vertical);

            //タブのテキストと背景を描画するためのブラシを決定する           
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                e.Graphics.FillRectangle(gb, e.Bounds);
            }
            else
            {
                //選択されていないタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
            }

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(txt, font, Brushes.Navy, e.Bounds, sf);

            gb.Dispose();
        }

        #endregion
	
    }
}