using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Motion_Designer
{
	public partial class AutoTuningForm : Form
	{
        
        #region TuningParameter Class
	
		static private class TuningParameter
		{
			#region Tuning Parameter

			//�Q�C���Ɋւ���ݒ�

			static public int TitleGain = -1;

			static public int InitKcp_23B_OBS = 9420;				//23B�G���R�[�_�{�u�����x�I�u�U�[�o�g�p����Kcp�ݒ�l
			static public int InitKcp_17B_OBS = 9420;				//17B�G���R�[�_�{�u�����x�I�u�U�[�o�g�p����Kcp�ݒ�l
			static public int InitKcp_INC_OBS = 6280;				//INC�G���R�[�_�{�u�����x�I�u�U�[�o�g�p����Kcp�ݒ�l
			static public int InitKcp_RES_OBS = 6280;				//���]���o�{�u�����x�I�u�U�[�o�g�p����Kcp�ݒ�l

			static public int InitKcp_23B = 9420;					//23B�G���R�[�_�g�p����Kcp�ݒ�l
			static public int InitKcp_17B = 9420;					//17B�G���R�[�_�g�p����Kcp�ݒ�l
			static public int InitKcp_INC = 6280;					//INC�G���R�[�_�g�p����Kcp�ݒ�l
			static public int InitKcp_RES = 6280;					//���]���o�g�p����Kcp�ݒ�l

			static public int InitKci_23B = 400;					//23B�G���R�[�_�g�p����Kci�ݒ�l
			static public int InitKci_17B = 100;					//17B�G���R�[�_�g�p����Kci�ݒ�l
			static public int InitKci_INC = 100;					//INC�G���R�[�_�g�p����Kci�ݒ�l
			static public int InitKci_RES = 100;					//���]���o�g�p����Kci�ݒ�l

			static public int InitKpp = 63;							//�����Q�C��Kpp
			static public int InitKvp = 314;						//�����Q�C��Kvp
			static public int InitKvi = 63;							//�����Q�C��Kvi

			static public int UpKpp = 12;							//Kpp�㏸��
			static public int UpKvp = 48;							//Kvp�㏸��
			static public int UpKvi = 12;							//Kvi�㏸��

			static public int UpKppMax = 30;						//Kpp�㏸���i�ő�l)
			static public int UpKvpMax = 120;						//Kvp�㏸���i�ő�l)
			static public int UpKviMax = 30;						//Kvi�㏸���i�ő�l)

			static public int UpKppDelta = 1;						//Kpp�㏸���i�����j
			static public int UpKvpDelta = 4;						//Kvp�㏸���i����)
			static public int UpKviDelta = 1;						//Kvi�㏸���i����)

			//static public int MaxKvp_Belt = 200;					//�����@�B�F�x���g�@Kvp�ő�l[Hz]
			//static public int MaxKvp_Screw = 200;					//�����@�B�F�˂��@�@Kvp�ő�l[Hz]
			//static public int MaxKvp_Disk = 200;					//�����@�B�F�~�Ձ@�@Kvp�ő�l[Hz]

			static public int MaxKvi_Belt = 200;					//�����@�B�F�x���g�@Kvi�ő�l[1/s]
			static public int MaxKvi_Screw = 250;					//�����@�B�F�˂��@�@Kvi�ő�l[1/s]
			static public int MaxKvi_Disk = 200;					//�����@�B�F�~�Ձ@�@Kvi�ő�l[1/s]

			static public int CoeffInitGain_Belt = 50;				//�����@�B�F�x���g�@�����Q�C���~%
			static public int CoeffInitGain_Screw = 100;			//�����@�B�F�˂��@�@�����Q�C���~%
			static public int CoeffInitGain_Disk = 100;				//�����@�B�F�~�Ձ@�@�����Q�C���~%

			static public int CoeffUpGain_Belt = 80;				//�����@�B�F�x���g�@�Q�C���㏸���~%
			static public int CoeffUpGain_Screw = 100;				//�����@�B�F�˂��@�@�Q�C���㏸���~%
			static public int CoeffUpGain_Disk = 100;				//�����@�B�F�~�Ձ@�@�Q�C���㏸���~%

			static public int CoeffKpp_Normal = 25;					//�������[�h�F�W���@�@�@Kvp��Kpp�̔䗦
			static public int CoeffKpp_Position = 30;				//�������[�h�F�ʒu���߁@Kvp��Kpp�̔䗦
			static public int CoeffKpp_Stiffness = 20;				//�������[�h�F�����D��@Kvp��Kpp�̔䗦

			static public int CoeffKvi_Belt = 20;					//�����@�B�F�x���g�@�@Kvp��Kvi�̔䗦
			static public int CoeffKvi_Screw = 20;					//�����@�B�F�˂��@�@�@Kvp��Kvi�̔䗦
			static public int CoeffKvi_Disk = 20;					//�����@�B�F�~�Ձ@�@�@Kvp��Kvi�̔䗦

			//�t�B���^�Ɋւ���ݒ�

			static public int TitleFillter = -1;

			static public int NotchMaxFrq = 5500;					//�m�b�`�t�B���^�K�p�ő���g��
			static public int NotchMinFrq = 50;						//�m�b�`�t�B���^�K�p�ŏ����g��
			static public int NotchApplyAmp = 0;					//�m�b�`�t�B���^�K�p�ŏ��U���idb�j

			static public int NotchDefWidth = 50;					//�ŏ��Ƀm�b�`�t�B���^��K�p�������̕�
			static public int NotchDefDepth = 40;					//�ŏ��Ƀm�b�`�t�B���^��K�p�������̐[��

			static public int NotchSubWidth = 10;					//2��ڈȍ~�Ƀm�b�`�t�B���^��ݒ肷�鎞�̕��i�����j
			static public int NotchSubDepth = 20;					//2��ڈȍ~�Ƀm�b�`�t�B���^��ݒ肷�鎞�̐[���i�����j

			static public int LpfMaxFrq = 4000;						//LPF�K�p�ő���g��
			static public int LpfMinFrq = 850;						//LPF�K�p�ő���g��
			static public int LpfFrqCoeff = 85;						//LPF�K�p���̌��o���g���Ɋ|����W���@1000Hz�̐U�������o������850Hz

			static public int LpfInit_23B = 2000;					//23B�G���R�[�_�F���[�p�X�t�B���^�����l
			static public int LpfInit_17B = 1500;					//17B�G���R�[�_�F���[�p�X�t�B���^�����l
			static public int LpfInit_INC = 1000;					//INC�G���R�[�_�F���[�p�X�t�B���^�����l
			static public int LpfInit_RES = 600;					//���]���o�F���[�p�X�t�B���^�����l

			static public int LpfInit_23B_VelObs = 2000;			//23B�G���R�[�_�i���xOBS�L���j�F���[�p�X�t�B���^�����l
			static public int LpfInit_17B_VelObs = 1500;			//17B�G���R�[�_�i���xOBS�L���j�F���[�p�X�t�B���^�����l
			static public int LpfInit_INC_VelObs = 1000;			//INC�G���R�[�_�i���xOBS�L���j�F���[�p�X�t�B���^�����l
			static public int LpfInit_RES_VelObs = 600;				//���]���o�i���xOBS�L���j�F���[�p�X�t�B���^�����l

			static public int C_FB_Lpf_23B = 0;						//23B�G���R�[�_�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int C_FB_Lpf_17B = 0;						//17B�G���R�[�_�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int C_FB_Lpf_INC = 0;						//INC�G���R�[�_�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int C_FB_Lpf_RES = 0;						//���]���o     �F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_23B = 800;					//23B�G���R�[�_�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_17B = 400;					//17B�G���R�[�_�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_INC = 400;					//INC�G���R�[�_�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_RES = 400;					//���]���o     �F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_23B = 0;						//23B�G���R�[�_�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_17B = 4;						//17B�G���R�[�_�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_INC = 4;						//INC�G���R�[�_�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_RES = 4;						//���]���o     �F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j

			static public int C_FB_Lpf_23B_VelObs = 0;				//23B�G���R�[�_�i���xOBS�L���j�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int C_FB_Lpf_17B_VelObs = 0;				//17B�G���R�[�_�i���xOBS�L���j�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int C_FB_Lpf_INC_VelObs = 0;				//INC�G���R�[�_�i���xOBS�L���j�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int C_FB_Lpf_RES_VelObs = 0;				//���]���o     �i���xOBS�L���j�F�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_23B_VelObs = 0;				//23B�G���R�[�_�i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_17B_VelObs = 0;				//17B�G���R�[�_�i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_INC_VelObs = 0;				//INC�G���R�[�_�i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf_RES_VelObs = 0;				//���]���o     �i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_23B_VelObs = 0;				//23B�G���R�[�_�i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_17B_VelObs = 0;				//17B�G���R�[�_�i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_INC_VelObs = 0;				//INC�G���R�[�_�i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n_RES_VelObs = 0;				//���]���o     �i���xOBS�L���j�F���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j

			static public int FFT10dbSearchMaxFrq_Belt = 1000;		//�����@�B�F�x���g�@FFT�s�[�N���o�i10db�ȏ�j�ő���g��
			static public int FFT10dbSearchMinFrq_Belt = 50;		//�����@�B�F�x���g�@FFT�s�[�N���o�i10db�ȏ�j�ŏ����g��
			static public int FFT10dbSearchMaxFrq_Screw = 2000;		//�����@�B�F�˂��@�@FFT�s�[�N���o�i10db�ȏ�j�ő���g��
			static public int FFT10dbSearchMinFrq_Screw = 150;		//�����@�B�F�˂��@�@FFT�s�[�N���o�i10db�ȏ�j�ŏ����g��
			static public int FFT10dbSearchMaxFrq_Disk = 2000;		//�����@�B�F�~�Ձ@�@FFT�s�[�N���o�i10db�ȏ�j�ő���g��
			static public int FFT10dbSearchMinFrq_Disk = 150;		//�����@�B�F�~�Ձ@�@FFT�s�[�N���o�i10db�ȏ�j�ŏ����g��

			static public int FFT6dbSearchMaxFrq_Belt = 750;		//�����@�B�F�x���g�@FFT�s�[�N���o�i6db�ȏ�j�ő���g��
			static public int FFT6dbSearchMinFrq_Belt = 50;			//�����@�B�F�x���g�@FFT�s�[�N���o�i6db�ȏ�j�ŏ����g��
			static public int FFT6dbSearchMaxFrq_Screw = 750;		//�����@�B�F�˂��@�@FFT�s�[�N���o�i6db�ȏ�j�ő���g��
			static public int FFT6dbSearchMinFrq_Screw = 150;		//�����@�B�F�˂��@�@FFT�s�[�N���o�i6db�ȏ�j�ŏ����g��
			static public int FFT6dbSearchMaxFrq_Disk = 750;		//�����@�B�F�~�Ձ@�@FFT�s�[�N���o�i6db�ȏ�j�ő���g��
			static public int FFT6dbSearchMinFrq_Disk = 150;		//�����@�B�F�~�Ձ@�@FFT�s�[�N���o�i6db�ȏ�j�ŏ����g��

			static public int NotchMaxNum_Light = 4;				//�������x�F��@�m�b�`�t�B���^�ő��
			static public int NotchMaxNum_Middle = 5;				//�������x�F���@�m�b�`�t�B���^�ő��
			static public int NotchMaxNum_Strong = 5;				//�������x�F���@�m�b�`�t�B���^�ő��

			//�I�u�U�[�o�Ɋւ���ݒ�

			static public int TitleObserver = -1;

			static public int VelObsTime_23B_High = 1;				//23Bit�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_17B_High = 2;				//17Bit�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_INC_High = 3;				//�Ȑ�INC�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_RES_High = 5;				//���]���o�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��

			static public int VelObsTime_23B_Mid = 1;				//23Bit�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_17B_Mid = 3;				//17Bit�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_INC_Mid = 4;				//�Ȑ�INC�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_RES_Mid = 8;				//���]���o�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��

			static public int VelObsTime_23B_Low = 1;				//23Bit�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_17B_Low = 5;				//17Bit�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_INC_Low = 6;				//�Ȑ�INC�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��
			static public int VelObsTime_RES_Low = 10;				//���]���o�G���R�[�_�̏u�����x�I�u�U�[�o�덷���莞��

			//�p���X����Ɋւ���ݒ�

			static public int TitlePulse = -1;

			static public int SplitErrorPulse_23B = 256;			//23bit�G���R�[�_  �F�΍����ꔻ��p���X��
			static public int SplitErrorPulse_17B = 4;				//17bit�G���R�[�_  �F�΍����ꔻ��p���X��
			static public int SplitErrorPulse_INC = 2;				//�Ȑ�INC�G���R�[�_�F�΍����ꔻ��p���X��
			static public int SplitErrorPulse_RES = 2;				//���]���o         �F�΍����ꔻ��p���X��

			static public int FastOvershootTime = 150;				// �@�@�@�@�@�@�@�@�F�����I�[�o�[�V���[�g�񕜎��ԁ@msec		20170131 add

			static public int OvershootErrorPulse_23B = 2;			//23bit�G���R�[�_  �F�I�[�o�[�V���[�g����p���X���@�C���|�W�p���X�^N
			static public int OvershootErrorPulse_17B = 2;			//17bit�G���R�[�_  �F�I�[�o�[�V���[�g����p���X���@�C���|�W�p���X�^N
			static public int OvershootErrorPulse_INC = 2;			//�Ȑ�INC�G���R�[�_�F�I�[�o�[�V���[�g����p���X���@�C���|�W�p���X�^N
			static public int OvershootErrorPulse_RES = 2;			//���]���o         �F�I�[�o�[�V���[�g����p���X���@�C���|�W�p���X�^N

			static public int PerrVBPulse_23B = 256;				//23bit�G���R�[�_  �F�΍��̐U�����o�p���X
			static public int PerrVBPulse_17B = 4;					//17bit�G���R�[�_  �F�΍��̐U�����o�p���X
			static public int PerrVBPulse_INC = 2;					//�Ȑ�INC�G���R�[�_�F�΍��̐U�����o�p���X
			static public int PerrVBPulse_RES = 1;					//���]���o         �F�΍��̐U�����o�p���X

			static public int PerrVBIsSafeStopCount_Light = 1;			//�������x�F��@���S�ɒ�~����������s���΍��U���񐔂̉����@1�Ȃ�1��܂ł̕΍��U���͈��S��~
			static public int PerrVBIsSafeStopCount_Middle = 1;			//�������x�F���@���S�ɒ�~����������s���΍��U���񐔂̉����@1�Ȃ�1��܂ł̕΍��U���͈��S��~
			static public int PerrVBIsSafeStopCount_Strong = 2;			//�������x�F���@���S�ɒ�~����������s���΍��U���񐔂̉����@1�Ȃ�1��܂ł̕΍��U���͈��S��~

			//�I�������Ɋւ���ݒ�

			static public int TitleFinish = -1;

			static public int FinishGainAdjustCount = 15;			//�Q�C������������ȏ�s�����ꍇ�ɏI�����邩
			
			static public int FinishSafeStopCount_Light = 3;		//�������x�F��@���S�ɒ�~��������O�̐��莞�Ԃ��r���邩
			static public int FinishSafeStopCount_Middle = 4;		//�������x�F���@���S�ɒ�~��������O�̐��莞�Ԃ��r���邩
			static public int FinishSafeStopCount_Strong = 5;		//�������x�F���@���S�ɒ�~��������O�̐��莞�Ԃ��r���邩

			static public int FinishSafeStopKppLimit_Light = 20;	//�������x�F��@���S�ɒ�~��������Ɖ��񂩑O��Kpp�l���r���Đ��莞�Ԃɕω����Ȃ���
			static public int FinishSafeStopKppLimit_Middle = 30;	//�������x�F���@���S�ɒ�~��������Ɖ��񂩑O��Kpp�l���r���Đ��莞�Ԃɕω����Ȃ���
			static public int FinishSafeStopKppLimit_Strong = 40;	//�������x�F���@���S�ɒ�~��������Ɖ��񂩑O��Kpp�l���r���Đ��莞�Ԃɕω����Ȃ���

			static public int FinishSafeStopKvpLimit_Light = 240;	//�������x�F��@���S�ɒ�~���Ȃ��Ԃ�Kvp���ǂ̂��炢�㏸������
			static public int FinishSafeStopKvpLimit_Middle = 360;	//�������x�F���@���S�ɒ�~���Ȃ��Ԃ�Kvp���ǂ̂��炢�㏸������
			static public int FinishSafeStopKvpLimit_Strong = 480;	//�������x�F���@���S�ɒ�~���Ȃ��Ԃ�Kvp���ǂ̂��炢�㏸������

			static public int FinishSafeStopTime_Light = 2;			//�������x�F��@���S�ɒ�~�������񂩑O�̐��莞�Ԃ̕ω��ʂ��r
			static public int FinishSafeStopTime_Middle = 1;		//�������x�F���@���S�ɒ�~�������񂩑O�̐��莞�Ԃ̕ω��ʂ��r
			static public int FinishSafeStopTime_Strong = 1;		//�������x�F���@���S�ɒ�~�������񂩑O�̐��莞�Ԃ̕ω��ʂ��r


			//�U�����o�Ɋւ���ݒ�

			static public int TitleVibration = -1;

			static public int CurVBKvpLimit_Light = 20;				//�������x�F��@Kvp���E�l=Kvp���ݒl�~�W��<�U�����g��
			static public int CurVBKvpLimit_Middle = 25;			//�������x�F���@Kvp���E�l=Kvp���ݒl�~�W��<�U�����g��
			static public int CurVBKvpLimit_Strong = 35;			//�������x�F���@Kvp���E�l=Kvp���ݒl�~�W��<�U�����g��

			static public int CurVBNFLimitCount = 3;				//���݂�Kvp�l�̈�����g���ȉ��Ƀm�b�`�t�B���^�ݒ肵�悤�Ƃ�����
			static public int CurVBKvpLimitCount = 3;				//���݂�Kvp�l�̈�����g���ȉ��ɓd���U�������o������
			static public int CurVBFFTLimitCount = 2;				//�U�����o���FFT��K�p����܂ł̉�

			static public int PerrVBNumLimitCount = 5;				//�΍��̐U�����o�̉�

			static public int CurVBDetectDiv00 = 1;					//�U�����o����d���l�i��i�d����Div�j	�C�i�[�V����10�{����
			static public int CurVBDetectCnt00 = 10;				//�U�����o�d�����z������				�C�i�[�V����10�{����
			static public int CurVBDetectDiv10 = 1;					//�U�����o����d���l�i��i�d����Div�j	�C�i�[�V����10�{�ȏ�20�{����
			static public int CurVBDetectCnt10 = 5;					//�U�����o�d�����z������				�C�i�[�V����10�{�ȏ�20�{����
			static public int CurVBDetectDiv20 = 2;					//�U�����o����d���l�i��i�d����Div�j	�C�i�[�V����20�{�ȏ�
			static public int CurVBDetectCnt20 = 5;					//�U�����o�d�����z������				�C�i�[�V����20�{�ȏ�

		
			//���g���C�Ɋւ���ݒ�

			static public int TitleRetry = -1;

			static public int RetryCountPerrVB = 2;					//�΍��U�����o���̃��g���C��

			static public int RetryCountCurVB = 2;					//�d���U�����o���̃��g���C��
			static public int RetryCountCurVBInitGain = 3;			//�Q�C�����������̓d���U�����o���̃��g���C��

			static public int RetryCoeffInitGain = 75;				//�����Q�C�������ĊJ���̏����Q�C���~�W��
			static public int RetryCoeffUpGain = 75;				//�����Q�C�������ĊJ���̏㏸�Q�C���~�W��

			static public int RetryNumInitGain = 10;				//�����Q�C���Đݒ肪�L���ȉ񐔁i�Q�C�����������ݒ肳�ꂽ�񐔁j
			static public int RetryNumNotch = 3;					//�O��ƍ���̃m�b�`�t�B���^�ݒ�񐔂̔���@�m�b�`�t�B���^�ݒ�シ���ɓ������g���ɋ��U���������ꍇ�͖����Ƃ���ׁB

			//���ׂɊւ���ݒ�

			static public int TitleLoad = -1;

			static public int LoadTuningAfterGainDiv = 4;
			static public int InitGainLoadRatioDiv = 5;
			static public int UpGainLoadRatioDiv = 5;

			static public int SpringConstant_Belt = 100;
			static public int SpringConstant_Screw = 250;
			static public int SpringConstant_Disk = 500;
	
			//���[���o�b�N�Ɋւ���ݒ�

			static public int TitleRollback = -1;

			static public int RollbackPerrVBCount_Light = 1;		//�������x�F��@�����������̃��[���o�b�N�΍��U�����o��
			static public int RollbackPerrVBCount_Middle = 2;		//�������x�F���@�����������̃��[���o�b�N�΍��U�����o��
			static public int RollbackPerrVBCount_Strong = 3;		//�������x�F���@�����������̃��[���o�b�N�΍��U�����o��

			static public int RollbackVBGain_Light = 80;			//�������x�F��@�d���E�΍��U�����o�������̃��[���o�b�NKvp�l�@�ŏIKvp�l<����Kvp�l�~�W��
			static public int RollbackVBGain_Middle = 85;			//�������x�F���@�d���E�΍��U�����o�������̃��[���o�b�NKvp�l�@�ŏIKvp�l<����Kvp�l�~�W��
			static public int RollbackVBGain_Strong = 95;			//�������x�F���@�d���E�΍��U�����o�������̃��[���o�b�NKvp�l�@�ŏIKvp�l<����Kvp�l�~�W��

			static public int RollbackCurVBdB_Light = 3;			//�������x�F��@�����������̃��[���o�b�NFFT dB�l�@FFT dB<3.0dB
			static public int RollbackCurVBdB_Middle = 6;			//�������x�F���@�����������̃��[���o�b�NFFT dB�l�@FFT dB<6.0dB
			static public int RollbackCurVBdB_Strong = 6;			//�������x�F���@�����������̃��[���o�b�NFFT dB�l�@FFT dB<6.0dB

			#endregion
		}

		static private class JudgeParameter
		{
			static public double KvpLimitCurrentVB = new double();		//Kvp���E�l=Kvp���ݒl�~�W��<�U�����g��

			static public int SplitErrorPulse = new int();				//�΍����ꔻ��p���X��
			static public int OvershootErrorPulse = new int();			//�I�[�o�[�V���[�g����p���X��
			static public int PerrVibrationPulse = new int();			//�΍��U�����o�p���X��

			static public int FastOvershootTime = new int();			//�����I�[�o�[�V���[�g�񕜎���		20170131 add

			static public int UpKppStart = new int();					//Kpp�㏸���i�J�n��)
			static public int UpKvpStart = new int();					//Kvp�㏸���i�J�n��)
			static public int UpKviStart = new int();					//Kvi�㏸���i�J�n��)

			static public double CoeffKpp = new double();				//Kvp��Kpp�̔䗦�@�W���E�ʒu���ߗD��E�����D���Kpp�㏸�̔䗦
			static public double CoeffKvi = new double();				//Kvp��Kvi�̔䗦�@�x���g�E�˂��E�f�B�X�N��Kvi�㏸�̔䗦

			static public double MaxKvi = new double();					//Kvi�ő�l

			static public int VelObsTime = new int();					//�u�����x�I�u�U�[�o�덷���莞��

			static public int Kcp = new int();							//�d�����[�v���Q�C��
			static public int Kci = new int();							//�d�����[�v�ϕ��Q�C��

			static public int LpfInit = new int();						//���[�p�X�t�B���^�����l�i�Z���T�ɂ��قȂ�j

			static public int C_FB_Lpf = new int();						//�d���t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_Lpf = new int();						//���x�t�B�[�h�o�b�N�t�B���^LPF���g���i�u�����x�I�u�U�[�o�L�����͖����j
			static public int V_FB_n = new int();						//���x�t�B�[�h�o�b�N�t�B���^���ω񐔁i�u�����x�I�u�U�[�o�L�����͖����j

			static public int SpringCosntat = new int();

			static public int FFT10dbSearchMaxFrq = new int();			//FFT�s�[�N���o�i10db�ȏ�j�ő���g��
			static public int FFT10dbSearchMinFrq = new int();			//FFT�s�[�N���o�i10db�ȏ�j�ŏ����g��

			static public int FFT6dbSearchMaxFrq = new int();			//FFT�s�[�N���o�i6db�ȏ�j�ő���g��
			static public int FFT6dbSearchMinFrq = new int();			//FFT�s�[�N���o�i6db�ȏ�j�ŏ����g��

			static public int FFT10dbApplyMaxFrq = new int();			//�m�b�`�t�B���^�K�p�i10db�ȏ�j�ő���g��
			static public int FFT10dbApplyMinFrq = new int();			//�m�b�`�t�B���^�K�p�i10db�ȏ�j�ŏ����g��

			static public int FFT6dbApplyMaxFrq = new int();			//�m�b�`�t�B���^�K�p�i6db�ȏ�j�ő���g��
			static public int FFT6dbApplyMinFrq = new int();			//�m�b�`�t�B���^�K�p�i6db�ȏ�j�ŏ����g��

			static public int MaxNotchNum = new int();					//�m�b�`�t�B���^�K�p�ő��

			static public int PerrVBIsSafeStopCount = new int();		//���S�ɒ�~����������s���΍��U���񐔂̉����@1�Ȃ�1��܂ł̕΍��U���͈��S��~

			static public int FinishGainAdjustCount = new int();		//�Q�C������������ȏ�s�����ꍇ�ɏI�����邩
			static public int FinishSafeStopCount = new int();			//���S�ɒ�~��������O�̐��莞�Ԃ��r���邩
			static public int FinishSafeStopKppLimit = new int();		//���S�ɒ�~��������Ɖ��񂩑O��Kpp�l���r���Đ��莞�Ԃɕω����Ȃ���
			static public int FinishSafeStopKvpLimit = new int();		//���S�ɒ�~���Ȃ��Ԃ�Kvp���ǂ̂��炢�㏸������

			static public int FinishSafeStopTime = new int();			//���S�ɒ�~�������񂩑O�̐��莞�Ԃ̕ω��ʂ��r

			static public int RollbackPerrVBCount = new int();			//�΍��U���������̃��[���o�b�N�΍��ʁ@�΍��U�����o�񐔁�3
			static public double RollbackCurVBGain = new double();		//�d���U���������̃��[���o�b�NKvp�l�@�ŏIKvp�l<����Kvp�l�~�W��
			static public double RollbackCurVBdB = new double();		//�������x�F��@�d���U���������̃��[���o�b�NdB�l�@�d���U��dB<3.0dB
		}

		static private class UserParameter
		{
			static public double MotorInertia = new double();
			static public double LoadInertia = new double();
			static public double InertiaRatio = new double();
			static public double InertiaRatioReal = new double();

			static public TuningStrength Strength = TuningStrength.Light;
			static public TuningMachine Machine = TuningMachine.Disk;
			static public TuningPriorty Priorty = TuningPriorty.Normal;

			static public TuningEncder EncderType = TuningEncder.Enc17B;

			static public int EncderResolution = new int();

			static public int TargetPosition = new int();
			static public int StartPosition = new int();
			static public int TargetInposition = new int();
			static public double TargetTime = new double();

			static public bool IsUseVelObserver = new bool();

			static public bool IsTuningTruboEnable = new bool();

			static public bool IsControlNew = true;

		}

		#endregion

		#region Servo Gain Adjust Member

		private int PositionError = new int();

		private bool  IsInposition = new bool();
		private int   InposCount = new int();
		private int   InposDelay = new int();
		private int[] InposTime = new int[10];

		private bool IsSplitError = new bool();
		private bool IsSlowOvershootError = new bool();
		private bool IsFastOvershootError = new bool();
		private bool IsPerrVB = new bool();
		private int  PerrVBCount = new int();

		private int  InposCountP = new int();
		private bool IsSplitErrorP = new bool();
		private bool IsSlowOvershootErrorP = new bool();
		private bool IsFastOvershootErrorP = new bool();
		private bool IsPerrVB_P = new bool();
		private int  PerrVBCountP = new int();
	
		private int  InposCountN = new int();
		private bool IsSplitErrorN = new bool();
		private bool IsSlowOvershootErrorN = new bool();
		private bool IsFastOvershootErrorN = new bool();
		private bool IsPerrVB_N = new bool();
		private int  PerrVBCountN = new int();
	
		private int  InposTimeP = new int();
		private int  InposTimeN = new int();

		private bool FFT_MeasStart = new bool();
		private bool FFT_MeasEnd = new bool();
		private int FFT_MeasCount = new int();
		private int FFT_AveCount = new int();

        private double[] fftBuf_in = new double[FFT_C.FFT_max];
        private double[] fftBuf_ref = new double[FFT_C.FFT_max];
        private double[] fftBuf_ave = new double[FFT_C.FFT_max];
        private double[] fftBuf_smp = new double[FFT_C.FFT_max];
        private double[] fftBuf_sub = new double[FFT_C.FFT_max];

		private FFT_IF fft_if = new FFT_IF();

		private List<HappyTuning> listHappyTuning = new List<HappyTuning>();

		private List<FFT_Member> listPeekFrq10db = new List<FFT_Member>();
		private List<FFT_Member> listPeekFrq6db = new List<FFT_Member>();
		private List<FFT_Member> listPeekFrq3db = new List<FFT_Member>();

		private List<FFT_Member> listInitPeekMax = new List<FFT_Member>();
		private List<FFT_Member> listInitPeekMin = new List<FFT_Member>();

		private List<int> listInitPeekFrq = new List<int>();

		private int IndexNF = new int();
		private int IndexLPF = new int();
		private int FrqLPF = new int();

		private List<NotchMember> listNF = new List<NotchMember>();
		private List<LpfMember> listLPF = new List<LpfMember>();

		private const int PeekFrq10db = 10;			//10dB
		private const int PeekFrq6db = 6;			//6dB
		private const int PeekFrq3db = 3;			//3dB

		private bool IsApplyLPF = new bool();
		private bool IsApplyNF = new bool();
		private bool IsSameNF = new bool();
		private bool IsMaxNF = new bool();
		private bool IsLimitNF = new bool();

		private bool IsKvpLimitNF = new bool();
		private bool IsKvpLimitVB = new bool();
		private bool IsAdjustWait = new bool();
		private bool IsFFTWait = new bool();

		private bool IsWaitVB = new bool();
		private int FrqVB = new int();

		private int ApplyCountNF = new int();
		private int ApplyCountVB = new int();
		private int ApplyCountFFT = new int();

		private int AdjustMeasDir = new int();
		private int AdjustMeasWait = new int();
		private int AdjustSq = new int();
	
		private int AdjustSqBackup = new int();
		private int AdjustSqWait = new int();

		private int GainAdjustCount = new int();
		private int AdjustActCount = new int();

		private int PositionVBCount = new int();

		private int CurrentVBCount = new int();
		private int CurrentVBCountInitGain = new int();

		private int StartMinute = new int();
		private int StartSecond = new int();

		private class HappyTuning
		{
			public GainMember HappyGain = new GainMember();
			public List<NotchMember> HappyNotch = new List<NotchMember>();
			public List<LpfMember> HappyLpf = new List<LpfMember>();
			public List<FFT_Member> listPeekFrq10db = new List<FFT_Member>();
			public List<FFT_Member> listPeekFrq6db = new List<FFT_Member>();
			public List<FFT_Member> listPeekFrq3db = new List<FFT_Member>();
			public int PerrVibrationCount = new int();
			public double InpositionTime = new double();

			public HappyTuning(GainMember gain,
								List<NotchMember> notch,
								List<LpfMember> lpf,
								List<FFT_Member> peek10db,
								List<FFT_Member> peek6db,
								List<FFT_Member> peek3db,
								int perr_vb,
								double inpos_t)
			{
				HappyGain = new GainMember(gain);

				for (int i = 0; i < notch.Count; i++)
				{
					HappyNotch.Add(new NotchMember(notch[i]));
				}

				for (int i = 0; i < lpf.Count; i++)
				{
					HappyLpf.Add(new LpfMember(lpf[i]));
				}

				for (int i = 0; i < peek10db.Count; i++)
				{
					listPeekFrq10db.Add(new FFT_Member(peek10db[i]));
				}

				for (int i = 0; i < peek6db.Count; i++)
				{
					listPeekFrq6db.Add(new FFT_Member(peek6db[i]));
				}

				for (int i = 0; i < peek3db.Count; i++)
				{
					listPeekFrq3db.Add(new FFT_Member(peek3db[i]));
				}

				PerrVibrationCount = perr_vb;

				InpositionTime = inpos_t;
			}

		}

		private GainMember NowGain = new GainMember();

		private TuningResult NowResult = new TuningResult();

		private class TuningResult
		{
			private bool _IsPositionErrorSplit = new bool();
			private bool _IsPositionErrorOvershoot = new bool();

			private bool _IsInpositionSplit = new bool();

			private int _PositiveInpositionTime = new int();
			private int _NegativeInpositionTime = new int();

			public TuningResult()
			{

			}

			public TuningResult(TuningResult result)
			{
				IsPositionErrorSplit = result.IsPositionErrorSplit;
				IsPositionErrorOvershoot = result.IsPositionErrorOvershoot;
				IsInpositionSplit = result.IsInpositionSplit;
				PositiveInpositionTime = result.PositiveInpositionTime;
			}

			public bool IsPositionErrorSplit
			{
				set { _IsPositionErrorSplit = value; }
				get { return _IsPositionErrorSplit; }
			}

			public bool IsPositionErrorOvershoot
			{
				set { _IsPositionErrorOvershoot = value; }
				get { return _IsPositionErrorOvershoot; }
			}

			public bool IsInpositionSplit
			{
				set { _IsInpositionSplit = value; }
				get { return _IsInpositionSplit; }
			}

			public int PositiveInpositionTime
			{
				set { _PositiveInpositionTime = value; }
				get { return _PositiveInpositionTime; }
			}

			public int NegativeInpositionTime
			{
				set { _NegativeInpositionTime = value; }
				get { return _NegativeInpositionTime; }
			}

			public bool IsSafeStop()
			{
				if (!IsPositionErrorSplit && !IsPositionErrorOvershoot)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			public bool IsCompleteStop()
			{
				if (!IsPositionErrorSplit && !IsPositionErrorOvershoot && !IsInpositionSplit)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

		}

		private class TuningGain
		{
			public GainMember HappyGain = new GainMember();
			public List<NotchMember> HappyNotch = new List<NotchMember>();
			public List<LpfMember> HappyLpf = new List<LpfMember>();

			public TuningGain(GainMember gain, List<NotchMember> notch, List<LpfMember> lpf)
			{
				HappyGain = new GainMember(gain);

				for (int i = 0; i < notch.Count; i++)
				{
					HappyNotch.Add(new NotchMember(notch[i]));
				}

				for (int i = 0; i < lpf.Count; i++)
				{
					HappyLpf.Add(new LpfMember(lpf[i]));
				}

			}

		}

		private class TuningHistory
		{
			private TuningAction _ThisAction;

			private TuningResult _ThisResult;

			private GainMember _ThisGain;

			private List<LpfMember> _ThisLpf = new List<LpfMember>();

			private List<NotchMember> _ThisNotch = new List<NotchMember>();

			public TuningHistory(TuningAction action, TuningResult result, GainMember gain, List<LpfMember> lpf, List<NotchMember> notch)
			{
				ThisAction = action;
				ThisResult = result;
				ThisGain = gain;
				ThisLpf = lpf;
				ThisNotch = notch;
			}

			public TuningAction ThisAction
			{
				set { _ThisAction = value; }
				get { return _ThisAction; }
			}

			public TuningResult ThisResult
			{
				set { _ThisResult = new TuningResult(value); }
				get { return _ThisResult; }
			}

			public GainMember ThisGain
			{
				set { _ThisGain = new GainMember(value); }
				get { return _ThisGain; }
			}

			public List<LpfMember> ThisLpf
			{
				set
				{
					_ThisLpf.Clear();

					for (int i = 0; i < value.Count; i++)
					{
						_ThisLpf.Add(new LpfMember(value[i]));
					}
				}
				get { return _ThisLpf; }
			}

			public List<NotchMember> ThisNotch
			{
				set
				{
					_ThisNotch.Clear();

					for (int i = 0; i < value.Count; i++)
					{
						_ThisNotch.Add(new NotchMember(value[i]));
					}
				}
				get { return _ThisNotch; }
			}

		}

		List<TuningHistory> listTuningHistory = new List<TuningHistory>();

		#endregion

		private void StartAutoTuning()
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (!CheckTheOtherSequence()) { return; }

			if (!CheckTheTuningSetting()) { return; }

			if (JogControlForm.ThisForm != null) { JogControlForm.ThisForm.JogStop(); }		//20161031 add

			DialogResult ret = UserMessageBox.AutoTuningAdjustServoGain();

			if (ret == DialogResult.Cancel) { return; }

			BodeGraphForm.ThisForm.IsViewHold = false;

			tabTuning.SelectTab("tabPageTuningOutput");

			this.Refresh();

			TimerAutoTuing.Enabled = false;

			//�`���[�j���O��~�t���O�N���A
			ClearPauseAndRepeat();

			//�T�[�{�I�t
			ServoOff();

			Thread.Sleep(500);

			//�X�g�b�v�r�b�g�N���A
			ClearStop();

			//���݂̃Q�C�����t�B���^�ݒ�l��ۑ�
			if (!StoreServoParameter()) { return; }

			//�`���[�j���O��Ɍ��ɖ߂��p�����[�^��ۑ�		20170822 update
			if (!BackupOtherParameter(true, 10)) { return; }

			if (chkInc.Checked)
			{
				NowPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);		//20170215 update feedback��command 20170222 update command��feedback
			}
			else
			{
				NowPosition = ctlNumStartPosition.IntValue;
			}

			UserParameter.StartPosition = NowPosition;

			int now = ctlNumStartPosition.IntValue;
			int pos = ctlNumTargetPosition.IntValue;
			int vel = ctlNumTargetVelocity.IntValue;
			int acc = ctlNumTargetAcceleration.IntValue;
			int dcc = ctlNumTargetDeceleration.IntValue;
			int wait = ctlNumWaitTime.IntValue;
			int inpos = ctlNumInposition.IntValue;

			//�v���t�@�C���f�[�^�ݒ�
			WriteProfileData(pos, vel, acc, dcc);

			//�C���|�W�V�������o�p���X���ݒ�@�����[�U�[�ݒ荀��
			WriteInpositionWidth(inpos);

			//�ʒu�����
			WriteControlMode(1);

			Thread.Sleep(500);

			//�I�[�g�`���[�j�������ݒ�擾
			InitTuningParameter();

			//���[�U�[�ݒ�擾
			InitUserParameter();

			//�T�[�{�Q�C�������ݒ�
            // ������ 20210324 Kimura update ������
            InitTuningGain(CDataTool.GetInertiaDiameter(CMonitor.GetParameter(CParamID.Load)));
            //InitTuningGain(CMonitor.GetParameter(CParamID.Load));
            // ������ 20210324 Kimura update ����

			//����p�����[�^�쐬
			InitJudgeParameter();

			//�t�B���^�ݒ�N���A
			ClearFillter();

			int motor = CMonitor.GetParameter(CParamID.MotorNo);	//20171114 update
			int model = CMonitor.GetParameter(CParamID.ModelNo);	//20171114 update

			if (model == 8810 && motor >= 20 && motor < 50)			//20171114 update
			{
				//TBL_mini���[�^�͓d�����[�v�Q�C�����Đݒ肵�Ȃ�
			}
			else
			{
				//�d�����[�v�Q�C���ݒ�
				WriteCurrentGain(JudgeParameter.Kcp, JudgeParameter.Kci);
			}

			//�u�����x�I�u�U�[�o�ݒ�
			WriteVelocityObserver(UserParameter.IsUseVelObserver, false, JudgeParameter.VelObsTime);

			//�t�B�[�h�o�b�N�t�B���^�ݒ�
			if (MainForm.DriverRevision >= AppConst.UpTadVer520)		//20161031 update
			{
				WriteFeedbackLowpassFillter(JudgeParameter.C_FB_Lpf, JudgeParameter.V_FB_Lpf);
			}
			else
			{
				WriteFeedbackMovingFillter(JudgeParameter.V_FB_n);
			}

			Thread.Sleep(500);

			//���O�f�[�^���I�[�g�`���[�j���O�p�ɐݒ�i�ʒu�΍��A���j�^���x�A���j�^�d���j
			WriteLogKindAutoTuning();

			//�v���t�@�C���r�b�g�����N���A
			ProfileBitAutoClear();

			//�T�[�{�I��
			ServoOn();

			Thread.Sleep(500);		//20160406 add

			//�U�����o�ݒ�
			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				if (UserParameter.InertiaRatio >= 20.0)
				{
					WriteTuningVibrationSetting(TuningParameter.CurVBDetectDiv20, TuningParameter.CurVBDetectCnt20);
				}
				else if (UserParameter.InertiaRatio >= 10.0)
				{
					WriteTuningVibrationSetting(TuningParameter.CurVBDetectDiv10, TuningParameter.CurVBDetectCnt10);
				}
				else
				{
					WriteTuningVibrationSetting(TuningParameter.CurVBDetectDiv00, TuningParameter.CurVBDetectCnt00);
				}
			}

			//�I�[�g�`���[�j���O�V�[�P���X�ݒ�
			SetAutoTuningSq(3);

			fft_if.ClearFFT_Buffer();

			for (int i = 0; i < FFT_C.FFT_max; i++)
			{
				fftBuf_in[i] = 0.0;
				fftBuf_ref[i] = 0.0;
				fftBuf_ave[i] = 0.0;
				fftBuf_smp[i] = 0.0;
			}

			AdjustSq       = 0;
			AdjustSqWait   = 0;
			AdjustSqBackup = 0;
			GainAdjustCount  = 0;
			AdjustActCount = 0;
			AdjustMeasWait = 0;
			AdjustMeasDir  = 0;

			IndexNF = 0;
			IndexLPF = 0;

			listNF.Clear();
			listLPF.Clear();

			listInvalidNF.Clear();

			listInitPeekMax.Clear();
			listInitPeekMin.Clear();
			listInitPeekFrq.Clear();

			listHappyTuning.Clear();
			listTuningHistory.Clear();

			ApplyCountNF = 0;
			ApplyCountVB = 0;
			ApplyCountFFT = 0;
		
			ClearVibration();

			ClearTuningResult();

			OutputTuningSetting();

			//���胍�[�p�X�t�B���^�ݒ�
			AddLowpassFillter(JudgeParameter.LpfInit);
			SetTuningHistory(TuningAction.LpfNew);

			AppendResultText("\n");
	
			MoveAutoTuning(true);

			TimerAutoTuing.Enabled = true;

		}

		private bool CheckTheTuningSetting()
		{
			if (AutoTuningSq != 0)
			{
				UserMessageBox.AutoTuningExecOther(AutoTuningSq);
				return false;
			}

			if (ctlNumTargetVelocity.IntValue <= 0)
			{
				UserMessageBox.WizardTuningVelocityWarning();
				return false;
			}

			if (ctlNumTargetAcceleration.IntValue <= 10)
			{
				UserMessageBox.WizardTuningAccelerationWarning();
				return false;
			}

			if (ctlNumTargetDeceleration.IntValue <= 10)
			{
				UserMessageBox.WizardTuningDecelerationWarning();
				return false;
			}

			if (ctlNumInposition.IntValue < 1)
			{
				UserMessageBox.WizardTuningInPositionWidthWarning();
				return false;
			}

			return true;
		}

		private void OutputTuningSetting()
		{
			rtxtResult.Clear();
			rtxtFFT_Peek.Clear();

			ResultText = string.Empty;

			StartMinute = DateTime.Now.Minute;
			StartSecond = DateTime.Now.Second;

			lblStopWatch.Text = "00:00";

			AppendResultText(UserText.AutoTuningAdjustStartServoGainAdjust + "\n" + "\n");

			AppendResultText(UserText.AutoTuningAdjustTuningSetting + "\n" + "\n");

			AppendResultText(UserText.TuningParameterInertiaRatio + UserParameter.InertiaRatioReal.ToString("F2") + UserText.AutoTuningAdjustDouble + "\n");

			switch (UserParameter.Machine)
			{
				case TuningMachine.Disk:
					AppendResultText(UserText.TuningParameterMachineTypeDisk + "\n");
					break;

				case TuningMachine.Belt:
					AppendResultText(UserText.TuningParameterMachineTypeBelt + "\n");
					break;

				case TuningMachine.Screw:
					AppendResultText(UserText.TuningParameterMachineTypeScrew + "\n");
					break;
			}

			switch (UserParameter.Strength)
			{
				case TuningStrength.Light:
					AppendResultText(UserText.TuningParameterTuningStrengthLight + "\n");
					break;

				case TuningStrength.Middle:
					AppendResultText(UserText.TuningParameterTuningStrengthMiddle + "\n");
					break;

				case TuningStrength.Strong:
					AppendResultText(UserText.TuningParameterTuningStrengthStrong + "\n");
					break;
			}

			switch (UserParameter.Priorty)
			{
				case TuningPriorty.Normal:
					AppendResultText(UserText.TuningParameterTuningPriortyNormal + "\n");
					break;

				case TuningPriorty.Position:
					AppendResultText(UserText.TuningParameterTuningPriortyPosition + "\n");
					break;

				case TuningPriorty.Stiffness:
					AppendResultText(UserText.TuningParameterTuningPriortyStiffness + "\n");
					break;
			}

			if (UserParameter.IsUseVelObserver)
			{
				AppendResultText(UserText.TuningParameterLoadStable + "\n");
			}
			else
			{
				AppendResultText(UserText.TuningParameterLoadUnstable + "\n");
			}

			if (UserParameter.IsTuningTruboEnable)
			{
				AppendResultText(UserText.TuningParameterTurboEnable + "\n");
			}
			else
			{
				AppendResultText(UserText.TuningParameterTurboDisable + "\n");
			}

			int now = ctlNumStartPosition.IntValue;
			int pos = ctlNumTargetPosition.IntValue;
			int vel = ctlNumTargetVelocity.IntValue;
			int acc = ctlNumTargetAcceleration.IntValue;
			int dcc = ctlNumTargetDeceleration.IntValue;
			int wait = ctlNumWaitTime.IntValue;
			int inpos = ctlNumInposition.IntValue;
			int time = ctlNumTargetTime.IntValue;

			AppendResultText(UserText.TuningParameterInpositionRange + inpos.ToString() + " [pulse]" + "\n");
			AppendResultText(UserText.TuningParameterTargetTime + time.ToString() + " [msec]" + "\n");
			AppendResultText(UserText.TuningParameterTargetVelocity + vel.ToString() + " [rpm]" + "\n");
			AppendResultText(UserText.TuningParameterTargetAcceleration + acc.ToString() + " [10rpm/sec]" + "\n");
			AppendResultText(UserText.TuningParameterTargetDeceleration + dcc.ToString() + " [10rpm/sec]" + "\n");
			AppendResultText(UserText.TuningParameterWaitTime + wait.ToString() + " [msec]" + "\n");
			AppendResultText(UserText.TuningParameterStartPosition + now.ToString() + " [pulse]" + "\n");
			AppendResultText(UserText.TuningParameterTargetPosition + pos.ToString() + " [pulse]" + "\n");

			AppendResultText("\n");

			AppendResultText(UserText.AutoTuningAdjustInitGainSetting + "\n" + "\n");

			AppendResultText(UserText.AutoTuningAdjustInitKpSetting + TuningParameter.InitKpp.ToString() + " [rad/s]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustInitKvSetting + TuningParameter.InitKvp.ToString() + " [rad/s]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustInitKiSetting + TuningParameter.InitKvi.ToString() + " [1/s]" + "\n");

			AppendResultText("\n");

			AppendResultText(UserText.AutoTuningAdjustKpUpRatio + TuningParameter.UpKpp.ToString() + " [rad/s]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustKvUpRatio + TuningParameter.UpKvp.ToString() + " [rad/s]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustKiUpRatio + TuningParameter.UpKvi.ToString() + " [1/s]" + "\n");

			AppendResultText("\n");

			AppendResultText(UserText.AutoTuningAdjustMinimumNotchFillter + JudgeParameter.FFT10dbApplyMinFrq.ToString() + " [Hz]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustMaximumNotchFillter + JudgeParameter.FFT10dbApplyMaxFrq.ToString() + " [Hz]" + "\n");
			

			AppendResultText("\n" + UserText.AutoTuningAdjustInitGainChecking + "\n" + "\n");

		}

		private void MoveAutoTuning(bool cw)
		{

			int pos = new int();
		
			if (cw)
			{
				if (chkInc.Checked)
				{
					pos = NowPosition + ctlNumTargetPosition.IntValue;
				}
				else
				{
					pos = ctlNumTargetPosition.IntValue;
				}
			}
			else
			{
				pos = NowPosition;
			}

			UserParameter.TargetPosition = pos;

			//now_pos + 2rev
			WriteTargetPosition(pos);

			StartProfile();

		}

		private void MeasureLogData(bool cw)
		{
			try
			{
				int log_ptr = new int();
				int log_max = new int();
				int[,] log_buf;

				log_buf = DigitalOsilloForm.GetLogBufPointer(ref log_ptr, ref log_max);

				int cmd_ptr = new int();
				int cmd_end = new int();

				bool cmd_on = new bool();

				if (log_ptr > log_max) { log_ptr = log_max; }

				for (int i = log_ptr - 1, j = 0; j < log_max; i--, j++)
				{
					if (i < 0) { i = log_max - 1; }

					if (cmd_on)
					{
						if ((log_buf[LogWork.STS, i] & 0x02) == 0x00)		//�w�ߒl�L��M��
						{
							cmd_ptr = i;
							break;
						}
					}
					else
					{
						if ((log_buf[LogWork.STS, i] & 0x02) == 0x02)		//�w�ߒl�L��M��
						{
							cmd_end = i;
							cmd_on = true;
						}
					}
				}

				if (cmd_end < cmd_ptr) { cmd_end = log_max + cmd_end; }

				#region FFT�f�[�^�擾

				BodeGraphForm bodeForm = BodeGraphForm.ThisForm;

				int FFT_n = FFT_C.FFT_n / FFT_C.LOG_n;		//16384/(20*50usec) = 819msec
				int fft_ptr = new int();
				int fft_num = new int();
				int fft_end = new int();

				int fft_mod = 400 / LogWork.LogPeriod;

				fft_end = cmd_end + fft_mod;

				if (fft_end - cmd_ptr < FFT_n)
				{
					fft_num = 2;
					fft_ptr = fft_end - fft_num * FFT_n;
				}
				else
				{
					fft_num = 2;
					fft_ptr = fft_end - fft_num * FFT_n;
				}

				if (fft_ptr < 0) { fft_ptr = log_max + fft_ptr; }
				if (fft_ptr >= log_max) { fft_ptr = fft_ptr - log_max; }

				if (AdjustSq <= 10)
				{
					if (FFT_MeasStart)
					{
						FFT_MeasCount++;

						if (FFT_MeasCount < FFT_C.FFT_Buf_n)
						{
							for (int f = 0; f < fft_num; f++)
							{
								for (int i = 0; i < FFT_n; i++)
								{
									int n = i * FFT_C.LOG_n;

									for (int j = 0; j < FFT_C.LOG_n; j++)
									{
										fftBuf_in[n + j] = (double)((short)log_buf[LogWork.LOG1 + j, fft_ptr]);
									}

									fft_ptr++;

									if (fft_ptr >= log_max) { fft_ptr = 0; }
								}

								if (FFT_AveCount >= FFT_C.FFT_Buf_n) { FFT_AveCount = 0; }

								fft_if.CalcFFT_CS(FFT_AveCount, FFT_C.FFT_Buf_n, fftBuf_in, false);
								fft_if.CalcFFT_AverageAdd(FFT_C.FFT_Buf_n, ref fftBuf_ref);
								fft_if.CalcFFT_PeekFillter(ref fftBuf_ref, ref fftBuf_ref);
								FFT_AveCount++;
							}

							if (bodeForm != null)
							{
								bodeForm.ctlBodeGain.SetBodeData(1, FFT_C.Bode_n, fftBuf_ref);
							}
						}
						else
						{
							fft_if.SearchFFT_Peek(fftBuf_ref);

							listInitPeekMax = fft_if.GetFFT_PeekMax();
							listInitPeekMin = fft_if.GetFFT_PeekMin();

							rtxtFFT_Peek.Clear();

							rtxtFFT_Peek.AppendText(UserText.AutoTuningAdjustResonanceFrequency + "\n" + "\n");

							for (int i = 0; i < listInitPeekMax.Count; i++)
							{
								int frq = FFT_C.F2Real(listInitPeekMax[i].Hz);		//FFT���g���ϊ�

								rtxtFFT_Peek.AppendText((i + 1).ToString() + ".  " + frq.ToString() + " [Hz] " + " (" + listInitPeekMax[i].Hz.ToString("f1") + ") " + listInitPeekMax[i].dB.ToString("f2") + "[db] " + "\n");
							}

							rtxtFFT_Peek.AppendText("\n");

							rtxtFFT_Peek.AppendText(UserText.AutoTuningAdjustAntiResonanceFrequency + "\n" + "\n");

							for (int i = 0; i < listInitPeekMin.Count; i++)
							{
								int frq = FFT_C.F2Real(listInitPeekMin[i].Hz);		//FFT���g���ϊ�

								rtxtFFT_Peek.AppendText((i + 1).ToString() + ".  " + frq.ToString() + " [Hz] " + " (" + listInitPeekMin[i].Hz.ToString("f1") + ") " + listInitPeekMin[i].dB.ToString("f2") + "[db] " + "\n");
							}

							FFT_MeasEnd = true;
						}
					}
					else
					{

					}
				}
				else
				{
					for (int f = 0; f < fft_num; f++)
					{
						for (int i = 0; i < FFT_n; i++)
						{
							int n = i * FFT_C.LOG_n;

							for (int j = 0; j < FFT_C.LOG_n; j++)
							{
								fftBuf_in[n + j] = (double)((short)log_buf[LogWork.LOG1 + j, fft_ptr]);
							}

							fft_ptr++;

							if (fft_ptr >= log_max) { fft_ptr = 0; }
						}

						if (FFT_AveCount >= FFT_C.FFT_Buf_n) { FFT_AveCount = 0; }

						fft_if.CalcFFT_CS(FFT_AveCount, FFT_C.FFT_Buf_n, fftBuf_in, false);
						fft_if.CalcFFT_AverageAdd(FFT_C.FFT_Buf_n, ref fftBuf_smp);
						fft_if.CalcFFT_PeekFillter(ref fftBuf_smp, ref fftBuf_smp);

						FFT_AveCount++;
					}

					//�ŐVFFT�`��
					if (bodeForm != null)
					{
						bodeForm.ctlBodeGain.SetBodeData(0, FFT_C.Bode_n, fftBuf_smp);
					}

					//�FFT�ĕ`��
					if (bodeForm != null)
					{
						bodeForm.ctlBodeGain.SetBodeData(1, FFT_C.Bode_n, fftBuf_ref);
					}

					listPeekMax.Clear();
					listPeekMin.Clear();

					fft_if.SearchFFT_Peek(fftBuf_smp);

					listPeekMax = fft_if.GetFFT_PeekMax();
					listPeekMin = fft_if.GetFFT_PeekMin();
				}

				#endregion

				#region Feedback�f�[�^���

				int sub = (cmd_end - cmd_ptr) / 2;
				int vel = ctlNumTargetVelocity.IntValue;
				int dcc = ctlNumTargetDeceleration.IntValue;

				//�������p�����[�^�iID34�AID35�j�X�P�[���`�F�b�N�@20161205 add
				float mul = 10.0F;

				if ((CMonitor.GetParameter(CParamID.ControlSwitch2) & 0x80) == 0x80) { mul = 100.0F; }

				vel = (int)Math.Abs(vel);
				dcc = (int)((vel / (dcc * mul) * 1000.0F)) / LogWork.LogPeriod;

				int dcc_ptr = new int();

				if (dcc > sub)						//20161202 update
				{
					dcc_ptr = cmd_end - sub;		//�X���[�����[�V�����i�����斳���j
				}
				else
				{
					dcc_ptr = cmd_end - dcc;		//���[�W���[�V�����i������L��j
				}

				if (dcc_ptr < 0) { dcc_ptr = log_max + dcc_ptr; }

				bool move_puls = new bool();
				bool move_on = new bool();
				int move_ptr = new int();

				int max_perr_p = 0;
				int max_perr_n = 0;
				int min_perr_p = EncderResolution;
				int min_perr_n = EncderResolution;

				int overshot_time = new int();

				for (int i = dcc_ptr, j = 0; ; i++, j++)
				{
					if (i >= log_max) { i = 0; }

					if (i == log_ptr) { break; }

					PositionError = log_buf[LogWork.POS, i];

					if (i == dcc_ptr)
					{
						if (log_buf[LogWork.VEL, i] > 0)
						{
							move_puls = true;
						}
					}

					if (move_puls)
					{
						//��������]
						if (PositionError > max_perr_p)
						{
							max_perr_p = PositionError;
							min_perr_p = PositionError;
						}

						if (PositionError > JudgeParameter.OvershootErrorPulse)
						{
							if (PositionError < min_perr_p)
							{
								min_perr_p = PositionError;
							}

							if (PositionError < max_perr_p)
							{
								if (min_perr_p < (PositionError - JudgeParameter.SplitErrorPulse))
								{
									if (j >= 10)
									{
										//�ʒu�΍�����
										IsSplitError = true;
									}
								}
							}
						}

						if (PositionError < -JudgeParameter.OvershootErrorPulse)
						{
							//�ʒu�΍��I�[�o�[�V���[�g�i�΍�0���z���I�[�o�[�V���[�g�j
							//IsSlowOvershootError = true;
							overshot_time++;
						}
						else
						{
							if (overshot_time >= 5)
							{
								if (overshot_time <= JudgeParameter.FastOvershootTime)
								{
									IsFastOvershootError = true;
								}
								else
								{
									IsSlowOvershootError = true;
								}

								overshot_time = 0;	
							}
						}

						if (PositionError < -JudgeParameter.PerrVibrationPulse)
						{
							if (IsPerrVB == false)
							{
								IsPerrVB = true;
								PerrVBCount++;
							}
						}
						else if (PositionError > JudgeParameter.PerrVibrationPulse)
						{
							IsPerrVB = false;
						}
					}
					else
					{
						//��������]
						if (PositionError < max_perr_n)
						{
							max_perr_n = PositionError;
							min_perr_n = PositionError;
						}

						if (PositionError < -JudgeParameter.OvershootErrorPulse)
						{
							if (PositionError > min_perr_n)
							{
								min_perr_n = PositionError;
							}

							if (PositionError > max_perr_n)
							{
								if (min_perr_n > (PositionError + JudgeParameter.SplitErrorPulse))
								{
									if (j >= 10)
									{
										//�ʒu�΍�����
										IsSplitError = true;
									}
								}
							}
						}

						if (PositionError > JudgeParameter.OvershootErrorPulse)
						{
							//�ʒu�΍��I�[�o�[�V���[�g�i�΍�0���z���I�[�o�[�V���[�g�j
							//IsSlowOvershootError = true;
							overshot_time++;
						}
						else
						{
							if (overshot_time >= 5)
							{
								if (overshot_time <= JudgeParameter.FastOvershootTime)
								{
									IsFastOvershootError = true;
								}
								else
								{
									IsSlowOvershootError = true;
								}

								overshot_time = 0;
							}
						}

						if (PositionError > JudgeParameter.PerrVibrationPulse)
						{
							if (IsPerrVB == false)
							{
								IsPerrVB = true;
								PerrVBCount++;
							}
						}
						else if (PositionError < -JudgeParameter.PerrVibrationPulse)
						{
							IsPerrVB = false;
						}

					}

					if ((log_buf[LogWork.STS, i] & 0x02) == 0x00)
					{
						if (move_on == false)
						{
							move_on = true;
							move_ptr = j;
						}

						//�w�ߊ���
						//if (Math.Abs(PositionError) <= UserParameter.TargetInposition)
						if ((log_buf[LogWork.STS, i] & 0x04) == 0x04)
						{
							if (!IsInposition)
							{
								IsInposition = true;

								int n = InposCount;

								if (n < 10)
								{
									//TuningInpositionTime[n] = TuningInpositionDelay;
									InposTime[n] = j;
									InposCount++;
								}
							}
						}
						else
						{
							IsInposition = false;
						}

						InposDelay++;
					}
					else
					{
						//�w�ߊ����O
						//if (Math.Abs(PositionError) <= UserParameter.TargetInposition)
						if ((log_buf[LogWork.STS, i] & 0x04) == 0x04)
						{
							if (!IsInposition)
							{
								IsInposition = true;

								int n = InposCount;

								if (n < 10)
								{
									InposTime[n] = j;
									InposCount++;
								}
							}
						}
						else
						{
							IsInposition = false;
						}
					}
				}

				for (int n = 0; n < InposCount; n++)
				{
					InposTime[n] = InposTime[n] - move_ptr;
				}

				#endregion

				#region ���ʔ���

				bool is_perr_vb = new bool();

				if (AdjustSq != 60)
				{
					if (IsSplitError)
					{
						AppendResultText(UserText.AutoTuningAdjustPerrSplitDetect + "\n");
					}

					if (IsSlowOvershootError)
					{
						AppendResultText(UserText.AutoTuningAdjustPerrOvershootDetect + "\n");
					}

					if (IsFastOvershootError)
					{
						AppendResultText(UserText.AutoTuningAdjustPerrOvershootDetect + "+" + "\n");
					}

					if (InposCount > 1)
					{
						AppendResultText(UserText.AutoTuningAdjustInpositionSplitDetect + "\n");
					}

					if (PerrVBCount > TuningParameter.PerrVBNumLimitCount &&
						GainAdjustCount > TuningParameter.RetryNumInitGain)
					{
						AppendResultText(UserText.AutoTuningAdjustPerrVibrationDetect + "\n");
						is_perr_vb = true;
					}
				}

				if (InposCount <= 0)
				{
					AppendResultText(UserText.AutoTuningAdjustInpositionTime + UserText.AutoTuningAdjustInpositionTimeError + "\n");
				}
				else
				{
					if (IsInposition == false)
					{
						AppendResultText(UserText.AutoTuningAdjustInpositionTime + UserText.AutoTuningAdjustInpositionTimeError + "\n");
					}
					else
					{
						int inpos = InposTime[InposCount - 1] * LogWork.LogPeriod;
						AppendResultText(UserText.AutoTuningAdjustInpositionTime + inpos.ToString() + " [msec]" + "\n");
					}
				}

				if (cw)
				{
					if (InposCount > 0)
					{
						InposTimeP = InposTime[InposCount - 1];
					}
					else
					{
						InposTimeP = 1000;
					}

					InposCountP = InposCount;
					IsSplitErrorP = IsSplitError;
					IsSlowOvershootErrorP = IsSlowOvershootError;
					IsFastOvershootErrorP = IsFastOvershootError;
					IsPerrVB_P = is_perr_vb;
					PerrVBCountP = PerrVBCount;
				}
				else
				{
					if (InposCount > 0)
					{
						InposTimeN = InposTime[InposCount - 1];
					}
					else
					{
						InposTimeN = 1000;
					}

					InposCountN = InposCount;
					IsSplitErrorN = IsSplitError;
					IsSlowOvershootErrorN = IsSlowOvershootError;
					IsFastOvershootErrorN = IsFastOvershootError;
					IsPerrVB_N = is_perr_vb;
					PerrVBCountN = PerrVBCount;
				}

				#endregion
			}
			catch (Exception ex)
			{
				btnStop.PerformClick();
				UserMessageBox.CommonCatchErrorMessage(ex);
			}

		}

		private bool AdjustServoGain()
		{
			int n = new int();

			GainMember gain = new GainMember();
			gain.Kpp = CMonitor.GetParameter(CParamID.Kp1);
			gain.Kvp = CMonitor.GetParameter(CParamID.Kv1);
			gain.Kvi = CMonitor.GetParameter(CParamID.Ki1);
			gain.PositiveInposTime = InposTimeP;
			gain.NegativeInposTime = InposTimeN;

			NowResult.IsPositionErrorSplit = IsPerrSplit;
			NowResult.IsPositionErrorOvershoot = IsPerrSlowOvershoot;
			NowResult.IsInpositionSplit = IsInposSplit;
			NowResult.PositiveInpositionTime = InposTimeP;
			NowResult.NegativeInpositionTime = InposTimeN;

			switch (AdjustSq)
			{
				#region �����Q�C������

				case 0:		//�����Q�C���m�F

					AppendResultText("\n" + UserText.AutoTuningAdjustInitGainChecking + "\n" + "\n");

					AdjustSq = 10;
					FFT_MeasStart = false;

					break;

				case 10:

					if (FFT_MeasStart == false)
					{
						PushTuningSafeGain(gain);

						AppendResultText("\n" + UserText.AutoTuningAdjustInitGainCheckFinish + "\n");

						AppendResultText("\n" +  UserText.AutoTuningAdjustInitGainFFTdataGetting + "\n" + "\n");

						FFT_MeasStart = true;
						FFT_MeasEnd = false;

						FFT_MeasCount = 0;
						FFT_AveCount = 0;
					}

					if (FFT_MeasEnd)
					{
						FFT_MeasStart = false;
						FFT_MeasEnd = false;
						AdjustSq = 20;
					}

					break;

				#endregion

				#region �œK�Q�C�������@KP,KV,KI�e����

				case 20:	//�œK�Q�C�������@KP,KV,KI�e����

					AppendResultText("\n" + UserText.AutoTuningAdjustBestGainAdjusting + "\n" + "\n");

					AdjustSqBackup = AdjustSq;
					AdjustSqWait = 0;

					if (IsPerrVibration)
					{
						PositionVBCount++;

						if (PositionVBCount >= TuningParameter.RetryCountPerrVB)
						{
							AppendResultText(UserText.AutoTuningAdjustPerrVibrationDetectGainLimit + "\n");
							PopTuningSafeGain(true);
							AdjustSq = 30;
							break;
						}
					}
					else
					{
						PositionVBCount = 0;
					}

					if (IsSafeStop)
					{
						PushTuningSafeGain(gain);

						int x = listHappyTuning.Count;
						int y = x - 1;
						int c = y - 1;

						int kpp_sub = new int();
						double tim_sub = new double();

						if (GainAdjustCount > JudgeParameter.FinishGainAdjustCount)
						{
							while (c >= 0)
							{
								kpp_sub = listHappyTuning[y].HappyGain.Kpp - listHappyTuning[c].HappyGain.Kpp;

								if (kpp_sub > JudgeParameter.FinishSafeStopKppLimit)
								{
									tim_sub = listHappyTuning[c].InpositionTime - listHappyTuning[y].InpositionTime;

									if (tim_sub <= (double)JudgeParameter.FinishSafeStopTime)
									{
										//Kpp�㏸�Ő��莞�Ԃɕω������B�Q�C�����E�B
										AppendResultText(UserText.AutoTuningAdjustInpositionTimeLimit + "\n");
										PopTuningSafeGain(false);
										AdjustSq = 50;
									}

									break;
								}
								c--;
							}
						}
					}
					else
					{
						int x = listHappyTuning.Count;
						int y = x - 1;
						int c = y - 1;

						int kvp_sub = new int();
					
						kvp_sub = listHappyTuning[y].HappyGain.Kvp - gain.Kvp;

						if (GainAdjustCount > JudgeParameter.FinishGainAdjustCount)
						{
							if (kvp_sub > JudgeParameter.FinishSafeStopKvpLimit)
							{
								//Kvp�㏸�Ő��莞�Ԃɕω������B�Q�C�����E�B
								AppendResultText(UserText.AutoTuningAdjustServoStiffnessLimit + "\n");
								PopTuningSafeGain(true);
								AdjustSq = 50;
							}
						}
					}

					if (AdjustSq == 50) { break; }		//�Q�C�����E

					AdjustActCount++;

					AdjustSq = FFT_Analysis();

					if (AdjustSq == 99) { break; }		//�t�B���^�ݒ���FFT����҂�

					if (AdjustSq == 100) { break; }		//���x���[�v�Q�C��������E

					if (AdjustSq == 200)				//���x���[�v�Q�C���ݒ���EFFT����҂�
					{
						AdjustSq = 99;
						break;
					}

					bool kvp_up = true;

					if (IsSafeStop)
					{
						AppendResultText(UserText.AutoTuningAdjustSafeStop + "\n");

						if (UserParameter.IsTuningTruboEnable)
						{
							TuningParameter.UpKpp += TuningParameter.UpKppDelta;
							TuningParameter.UpKvp += TuningParameter.UpKvpDelta;
							TuningParameter.UpKvi += TuningParameter.UpKviDelta;

							if (TuningParameter.UpKpp > TuningParameter.UpKppMax) { TuningParameter.UpKpp = TuningParameter.UpKppMax; }
							if (TuningParameter.UpKvp > TuningParameter.UpKvpMax) { TuningParameter.UpKvp = TuningParameter.UpKvpMax; }
							if (TuningParameter.UpKvi > TuningParameter.UpKviMax) { TuningParameter.UpKvi = TuningParameter.UpKviMax; }
						}

						if (IsHappyInpotionTime)
						{
							//�ڕW���莞�ԓ��B
							AppendResultText(UserText.AutoTuningAdjustAchieveInpositionTime + "\n");

							AdjustSq = 50;
							break;
						}

						if (EnableUpKpp(gain))
						{
							SetKpp(gain.Kpp + TuningParameter.UpKpp);		//up kpp
							SetTuningHistory(TuningAction.KppUp);

							AdjustSq =  99;

							kvp_up = false;
						}

					}

					if (kvp_up)
					{
						if( EnableUpKvi(gain) )
						{
							SetKvi(gain.Kvi + TuningParameter.UpKvi);		//up kvi
							SetTuningHistory(TuningAction.KviUp);
						}
						else
						{
							SetKvp(gain.Kvp + TuningParameter.UpKvp);		//up kvp
							SetTuningHistory(TuningAction.KvpUp);
						}

						if (IsKvpUpLimit)
						{
							AppendResultText(UserText.AutoTuningAdjustAchieveKvLimit + "\n");
							PopTuningSafeGain(false);		//20170127 update true��false
							AdjustSq = 30;
							break;
						}
						else
						{
							AdjustSq = 99;
						}

						AdjustSq = 99;
		
					}

					GainAdjustCount++;

					//if (GainAdjustCount == TuningParameter.RetryNumInitGain) { AdjustSq = 10; }		//FFT�ď�����

					break;

				#endregion

				case 30:	//�Q�C����������


					//SetKpp((int)((double)NowGain.Kpp * TuningParameter.GainCoeff));
					//SetKvp((int)((double)NowGain.Kvp * TuningParameter.GainCoeff));
					//SetKvi((int)((double)NowGain.Kvi * TuningParameter.GainCoeff));

					AdjustSq = 50;

					break;

				case 50:

					AppendResultText("\n" + UserText.AutoTuningAdjustFinalGainCheck + "\n" + "\n");
					AdjustSq = 60;

					break;

				case 60:

					AdjustSqWait++;

					n = 2;

					if (AdjustSqWait < n)
					{
						break;
					}

					if (IsSafeStop)
					{
						AppendResultText("\n" + UserText.AutoTuningAdjustGainAdjustSuccessful + "\n");
						ClearAutoTuningSq();
					}
					else
					{
						//AppendResultText("\n" + UserText.AutoTuningAdjustGainAdjustFailed + "\n");
						AppendResultText("\n" + UserText.AutoTuningAdjustGainAdjustSuccessful + "\n");
						ClearAutoTuningSq();
					}

					TimerAutoTuing.Enabled = false;

					BodeGraphForm.ThisForm.IsViewHold = true;

					AutoTuningSaveDialog f = new AutoTuningSaveDialog();

					f.ShowDialog();

					if (AutoTuningSaveDialog.SaveMemory)
					{
						//FLASH�ۑ�
						if (!CCommandTx.WriteSvNet(17, 1)) { UserMessageBox.CommonUsbError(); return false; }

						SaveMsg = new SaveProgressDialog();

						SaveMsg.StartFlashMemorySave(this.Location, this.Size, 1);

						SaveMsg.Close();
					}

					if (AutoTuningSaveDialog.SaveFile)
					{
						string time = System.DateTime.Now.ToString();

						time = time.Replace("/", "");
						time = time.Replace(":", "");
						time = time.Replace(" ", "_");

						SaveFileDialog.FileName = "tuning_result" + "_" + time;
						SaveFileDialog.Filter = "Auto Tuning Result File (*.txt)|*.txt";

						//�����t�H���_��ݒ肷��
						SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

						ChildFormControl.SetOpacity(0.0);

						DialogResult ret = SaveFileDialog.ShowDialog();

						ChildFormControl.SetOpacity(1.0);
		
						//�ۑ��_�C�A���O��ݒ肷��
						if (ret == DialogResult.OK)
						{
							this.Cursor = Cursors.WaitCursor;

							System.IO.StreamWriter file;

							file = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode);

							file.Write(rtxtResult.Text);
							file.Write("\n");
							file.Write(rtxtGainNow.Text);

							file.Close();

							this.Cursor = Cursors.Default;
						}
					}

					break;

				case 99:	//�t�B���^�ݒ���FFT�X�V�҂�

					AdjustSqWait++;

					n = FFT_C.FFT_Ave_n / 2 - 1;

					if (AdjustSqWait >= n)
					{
						AdjustSqWait = 0;
						AdjustSq = AdjustSqBackup;
					}

					break;

				case 100:

					//���x���[�v�Q�C���ݒ���E
					PopTuningSafeGain(true);

					AdjustSq = 30;
					break;

				case 101:
					//FFT����҂��B�������Ȃ��B
					break;
			}


			return true;

		}

		private void SetTuningHistory(TuningAction action)
		{
			listTuningHistory.Add(new TuningHistory(action, NowResult, NowGain, listLPF, listNF));
		}

		private void InitTuningParameter()
		{
			int row = new int();

			//�Q�C���Ɋւ���ݒ�

			row++;		//+++ Gain Setting +++

			TuningParameter.InitKcp_23B_OBS = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKcp_17B_OBS = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKcp_INC_OBS = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKcp_RES_OBS = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.InitKcp_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKcp_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKcp_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKcp_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.InitKci_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKci_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKci_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKci_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.InitKpp = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKvp = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitKvi = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.UpKpp = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpKvp = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpKvi = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.UpKppMax = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpKvpMax = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpKviMax = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.UpKppDelta = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpKvpDelta = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpKviDelta = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.CoeffInitGain_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffInitGain_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffInitGain_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.CoeffUpGain_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffUpGain_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffUpGain_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.CoeffKpp_Normal = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffKpp_Position = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffKpp_Stiffness = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.CoeffKvi_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffKvi_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CoeffKvi_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.MaxKvi_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.MaxKvi_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.MaxKvi_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//�t�B���^�Ɋւ���ݒ�

			row++;		//+++ Fillter Setting +++

			TuningParameter.NotchMaxFrq = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchMinFrq = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchApplyAmp = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.NotchDefWidth = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchDefDepth = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchSubWidth = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchSubDepth = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.LpfMaxFrq = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfMinFrq = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfFrqCoeff = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.LpfInit_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfInit_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfInit_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfInit_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.LpfInit_23B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfInit_17B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfInit_INC_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.LpfInit_RES_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.C_FB_Lpf_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.C_FB_Lpf_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.C_FB_Lpf_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.C_FB_Lpf_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.C_FB_Lpf_23B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.C_FB_Lpf_17B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.C_FB_Lpf_INC_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.C_FB_Lpf_RES_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_23B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_17B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_INC_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_Lpf_RES_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_23B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_17B_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_INC_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.V_FB_n_RES_VelObs = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FFT10dbSearchMaxFrq_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT10dbSearchMinFrq_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT10dbSearchMaxFrq_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT10dbSearchMinFrq_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT10dbSearchMaxFrq_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT10dbSearchMinFrq_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FFT6dbSearchMaxFrq_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT6dbSearchMinFrq_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT6dbSearchMaxFrq_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT6dbSearchMinFrq_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT6dbSearchMaxFrq_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FFT6dbSearchMinFrq_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.NotchMaxNum_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchMaxNum_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.NotchMaxNum_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//�I�u�U�[�o�Ɋւ���ݒ�

			row++;		//+++ Observer Setting +++

			TuningParameter.VelObsTime_23B_High = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_17B_High = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_INC_High = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_RES_High = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.VelObsTime_23B_Mid = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_17B_Mid = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_INC_Mid = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_RES_Mid = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.VelObsTime_23B_Low = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_17B_Low = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_INC_Low = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.VelObsTime_RES_Low = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//�p���X����Ɋւ���ݒ�

			row++;		//+++ Pulse Setting +++

			TuningParameter.SplitErrorPulse_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.SplitErrorPulse_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.SplitErrorPulse_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.SplitErrorPulse_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FastOvershootTime = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.OvershootErrorPulse_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.OvershootErrorPulse_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.OvershootErrorPulse_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.OvershootErrorPulse_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.PerrVBPulse_23B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.PerrVBPulse_17B = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.PerrVBPulse_INC = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.PerrVBPulse_RES = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.PerrVBIsSafeStopCount_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.PerrVBIsSafeStopCount_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.PerrVBIsSafeStopCount_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//�I�������Ɋւ���ݒ�

			row++;		//+++ Finish Setting +++

			TuningParameter.FinishGainAdjustCount = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FinishSafeStopCount_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopCount_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopCount_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FinishSafeStopKppLimit_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopKppLimit_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopKppLimit_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FinishSafeStopKvpLimit_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopKvpLimit_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopKvpLimit_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.FinishSafeStopTime_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopTime_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.FinishSafeStopTime_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//�U�����o�Ɋւ���ݒ�

			row++;		//+++ Vibration Setting +++

			TuningParameter.CurVBKvpLimit_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBKvpLimit_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBKvpLimit_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.CurVBKvpLimitCount = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBNFLimitCount = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBFFTLimitCount = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.PerrVBNumLimitCount = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.CurVBDetectDiv00 = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBDetectCnt00 = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBDetectDiv10 = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBDetectCnt10 = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBDetectDiv20 = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.CurVBDetectCnt20 = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
		
			//���g���C�Ɋւ���ݒ�

			row++;		//+++ Retry Setting +++

			TuningParameter.RetryCountPerrVB = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RetryCountCurVB = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RetryCountCurVBInitGain = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RetryCoeffInitGain = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RetryCoeffUpGain = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RetryNumInitGain = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RetryNumNotch = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//���׃C�i�[�V���Ɋւ���ݒ�

			row++;		//+++ Load Setting +++

			TuningParameter.LoadTuningAfterGainDiv = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.InitGainLoadRatioDiv = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.UpGainLoadRatioDiv = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.SpringConstant_Belt = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.SpringConstant_Screw = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.SpringConstant_Disk = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			//���[���o�b�N�Ɋւ���ݒ�

			row++;		//+++ Rollback Setting +++

			TuningParameter.RollbackPerrVBCount_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RollbackPerrVBCount_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RollbackPerrVBCount_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.RollbackVBGain_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RollbackVBGain_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RollbackVBGain_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);

			TuningParameter.RollbackCurVBdB_Light = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RollbackCurVBdB_Middle = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);
			TuningParameter.RollbackCurVBdB_Strong = Convert.ToInt32(dgvSetting.Rows[row++].Cells[VALUE_COLUMN].Value);


		}

		private void InitUserParameter()
		{
			UserParameter.TargetInposition = ctlNumInposition.IntValue;
			UserParameter.TargetTime = ctlNumTargetTime.IntValue;

			if (rdoDisk.Checked)
			{
				UserParameter.Machine = TuningMachine.Disk;
			}
			else if (rdoBelt.Checked)
			{
				UserParameter.Machine = TuningMachine.Belt;
			}
			else if (rdoScrew.Checked)
			{
				UserParameter.Machine = TuningMachine.Screw;
			}

			if (rdoLight.Checked)
			{
				UserParameter.Strength = TuningStrength.Light;
			}
			else if (rdoMiddle.Checked)
			{
				UserParameter.Strength = TuningStrength.Middle;
			}
			else if (rdoStrong.Checked)
			{
				UserParameter.Strength = TuningStrength.Strong;
			}

			if (rdoNormalPriorty.Checked)
			{
				UserParameter.Priorty = TuningPriorty.Normal;
			}
			else if (rdoPositionPriorty.Checked)
			{
				UserParameter.Priorty = TuningPriorty.Position;
			}
			else if (rdoStiffnessPriorty.Checked)
			{
				UserParameter.Priorty = TuningPriorty.Stiffness;
			}

			//�u�����x�I�u�U�[�o�ݒ�
			if( rdoVelObsEnable.Checked)
			{
				UserParameter.IsUseVelObserver = true;
			}
			else
			{
				UserParameter.IsUseVelObserver = false;
			}

			//�^�[�{�@�\�ݒ�
			if (rdoTurboEnable.Checked)
			{
				UserParameter.IsTuningTruboEnable = true;
			}
			else
			{
				UserParameter.IsTuningTruboEnable = false;
			}

			//�G���R�[�_�^�C�v�ݒ�
			switch (EncderType)
			{
				case ENC_TYP_RESOLVER:

					switch (RDType)
					{
						default:
						case 0:
							UserParameter.EncderType = TuningEncder.Resolver;
							UserParameter.EncderResolution = 2048;
							break;

						case 2:
							UserParameter.EncderType = TuningEncder.Resolver2X;
							UserParameter.EncderResolution = 4096;
							break;

						case 4:
							UserParameter.EncderType = TuningEncder.Resolver4X;
							UserParameter.EncderResolution = 8192;
							break;

						case 5:
							UserParameter.EncderType = TuningEncder.Resolver5X;
							UserParameter.EncderResolution = 10240;
							break;

						case 8:

							UserParameter.EncderType = TuningEncder.Resolver8X;
							UserParameter.EncderResolution = 16384;
							break;
					}

					break;

				case ENC_TYP_COUNT_INC:

					switch (IncCount)
					{
						default:
						case 8000:

							UserParameter.EncderType = TuningEncder.Enc2000;
							UserParameter.EncderResolution = 8000;
							break;

						case 8192:

							UserParameter.EncderType = TuningEncder.Enc2048;
							UserParameter.EncderResolution = 8192;
							break;

						case 10000:

							UserParameter.EncderType = TuningEncder.Enc2500;
							UserParameter.EncderResolution = 10000;
							break;

					}
					break;

				case ENC_TYP_17BIT_INC:
				case ENC_TYP_17BIT_ABS:

					UserParameter.EncderType = TuningEncder.Enc17B;
					UserParameter.EncderResolution = 131072;
					break;

				case ENC_TYP_20BIT_INC:
				case ENC_TYP_20BIT_ABS:

					UserParameter.EncderType = TuningEncder.Enc20B;
					UserParameter.EncderResolution = 1048576;
					break;

				case ENC_TYP_23BIT_INC:
				case ENC_TYP_23BIT_ABS:

					UserParameter.EncderType = TuningEncder.Enc23B;
					UserParameter.EncderResolution = 8388608;
					break;
			}

		}

		private void InitLoadGain(int load)
		{
			int motor = new int();

            // ������ 20210324 Kimura update ������
			//motor = CMonitor.GetParameter(CParamID.MotorInertia);
            motor = (int)(CMonitor.GetParameter(CParamID.MotorInertia) * Math.Pow(10 , CMonitor.GetParameter(CParamID.InertiaManif)));

            UserParameter.MotorInertia = CDataTool.Inertiagcm2Tokgm2(motor);
            UserParameter.LoadInertia = CDataTool.Inertiagcm2Tokgm2(load);

			//UserParameter.MotorInertia = motor * 0.0000001;
			//UserParameter.LoadInertia = load * 0.0000001;

            // ������ 20210324 Kimura update ������

			UserParameter.InertiaRatio = (double)load / (double)motor;
			UserParameter.InertiaRatioReal = UserParameter.InertiaRatio;

			if (UserParameter.InertiaRatio <= 1.0) { UserParameter.InertiaRatio = 1.0; }

			int init_kp = TuningParameter.InitKpp;
			int init_kv = TuningParameter.InitKvp;
			int init_ki = TuningParameter.InitKvi;

			double init_div = UserParameter.InertiaRatio / TuningParameter.InitGainLoadRatioDiv;

			if (init_div <= 1.0) { init_div = 1.0; }

			init_kp = (int)((double)init_kp / init_div);
			init_kv = (int)((double)init_kv / init_div);
			init_ki = (int)((double)init_ki / init_div);

			init_kp = (int)((double)init_kp / TuningParameter.LoadTuningAfterGainDiv);
			init_kv = (int)((double)init_kv / TuningParameter.LoadTuningAfterGainDiv);
			init_ki = (int)((double)init_ki / TuningParameter.LoadTuningAfterGainDiv);

			if (init_kp <= 2) { init_kp = 2; }
			if (init_kv <= 10) { init_kv = 5; }
			if (init_ki <= 2) { init_ki = 2; }

			SetServoGain(init_kp, init_kv, init_ki);
		}

		private void InitTuningGain(int load)
		{
			int motor = new int();

            // ������ 20210324 Kimura update ������
            //motor = CMonitor.GetParameter(CParamID.MotorInertia);
            motor = (int)(CMonitor.GetParameter(CParamID.MotorInertia) * Math.Pow(10, CMonitor.GetParameter(CParamID.InertiaManif)));

            UserParameter.MotorInertia = CDataTool.Inertiagcm2Tokgm2(motor);
            UserParameter.LoadInertia = CDataTool.Inertiagcm2Tokgm2(load);

            //UserParameter.MotorInertia = motor * 0.0000001;
            //UserParameter.LoadInertia = load * 0.0000001;

            // ������ 20210324 Kimura update ������

			UserParameter.InertiaRatio = (double)load / (double)motor;
			UserParameter.InertiaRatioReal = UserParameter.InertiaRatio;

			if (UserParameter.InertiaRatio <= 1.0) { UserParameter.InertiaRatio = 1.0; }

			int init_kp = TuningParameter.InitKpp;
			int init_kv = TuningParameter.InitKvp;
			int init_ki = TuningParameter.InitKvi;

			//20160330 update �C�i�[�V����5�{�܂ł͏����Q�C�����W��1
			double init_div = UserParameter.InertiaRatio / TuningParameter.InitGainLoadRatioDiv;

			if (init_div <= 1.0) { init_div = 1.0; }

			init_kp = (int)((double)init_kp / init_div);
			init_kv = (int)((double)init_kv / init_div);
			init_ki = (int)((double)init_ki / init_div);

			double d = new double();
		
			//20160330 update
			switch (UserParameter.Machine)
			{
				default:
				case TuningMachine.Belt:

					d = TuningParameter.CoeffInitGain_Belt * 0.01;
					break;

				case TuningMachine.Screw:

					d = TuningParameter.CoeffInitGain_Screw * 0.01;
					break;

				case TuningMachine.Disk:

					d = TuningParameter.CoeffInitGain_Disk * 0.01;
					break;
			}

			init_kp = (int)((double)init_kp * d);
			init_kv = (int)((double)init_kv * d);
			init_ki = (int)((double)init_ki * d);

			if (init_kp <= 2) { init_kp = 2; }
			if (init_kv <= 8) { init_kv = 8; }
			if (init_ki <= 2) { init_ki = 2; }

			SetServoGain(init_kp, init_kv, init_ki);

			//20160329 update
			TuningParameter.InitKpp = init_kp;
			TuningParameter.InitKvp = init_kv;
			TuningParameter.InitKvi = init_ki;


			int up_kp = TuningParameter.UpKpp;
			int up_kv = TuningParameter.UpKvp;
			int up_ki = TuningParameter.UpKvi;


			//20160330 update �C�i�[�V����5�{�܂ł̓Q�C���㏸�����W��1
			double up_div = UserParameter.InertiaRatio / TuningParameter.UpGainLoadRatioDiv;

			if (up_div <= 1.0) { up_div = 1.0; }

			up_kp = (int)((double)up_kp / up_div);
			up_kv = (int)((double)up_kv / up_div);
			up_ki = (int)((double)up_ki / up_div);

			//20160330 update
			switch (UserParameter.Machine)
			{
				default:
				case TuningMachine.Belt:

					d = TuningParameter.CoeffUpGain_Belt * 0.01;
					break;

				case TuningMachine.Screw:

					d = TuningParameter.CoeffUpGain_Screw * 0.01;
					break;

				case TuningMachine.Disk:

					d = TuningParameter.CoeffUpGain_Disk * 0.01;
					break;

			}

			up_kp = (int)((double)up_kp * d);
			up_kv = (int)((double)up_kv * d);
			up_ki = (int)((double)up_ki * d);

			if (up_kp <= 1) { up_kp = 1; }
			if (up_kv <= 4) { up_kv = 4; }
			if (up_ki <= 1) { up_ki = 1; }

			TuningParameter.UpKpp = up_kp;
			TuningParameter.UpKvp = up_kv;
			TuningParameter.UpKvi = up_ki;

			JudgeParameter.UpKppStart = up_kp;
			JudgeParameter.UpKvpStart = up_kv;
			JudgeParameter.UpKviStart = up_ki;

		}

		private void InitJudgeParameter()
		{
			switch (UserParameter.Strength)
			{
				case TuningStrength.Light:

					JudgeParameter.PerrVBIsSafeStopCount = TuningParameter.PerrVBIsSafeStopCount_Light;
					JudgeParameter.KvpLimitCurrentVB = TuningParameter.CurVBKvpLimit_Light * 0.01;
					JudgeParameter.FinishSafeStopCount = TuningParameter.FinishSafeStopCount_Light;
					JudgeParameter.FinishSafeStopKppLimit = TuningParameter.FinishSafeStopKppLimit_Light;
					JudgeParameter.FinishSafeStopKvpLimit = TuningParameter.FinishSafeStopKvpLimit_Light;
					JudgeParameter.FinishSafeStopTime = TuningParameter.FinishSafeStopTime_Light;
					JudgeParameter.RollbackPerrVBCount = TuningParameter.RollbackPerrVBCount_Light;
					JudgeParameter.RollbackCurVBGain = TuningParameter.RollbackVBGain_Light * 0.01;
					JudgeParameter.MaxNotchNum = TuningParameter.NotchMaxNum_Light;
					break;

				case TuningStrength.Middle:

					JudgeParameter.PerrVBIsSafeStopCount = TuningParameter.PerrVBIsSafeStopCount_Middle;
					JudgeParameter.KvpLimitCurrentVB = TuningParameter.CurVBKvpLimit_Middle * 0.01;
					JudgeParameter.FinishSafeStopCount = TuningParameter.FinishSafeStopCount_Middle;
					JudgeParameter.FinishSafeStopKppLimit = TuningParameter.FinishSafeStopKppLimit_Middle;
					JudgeParameter.FinishSafeStopKvpLimit = TuningParameter.FinishSafeStopKvpLimit_Middle;
					JudgeParameter.FinishSafeStopTime = TuningParameter.FinishSafeStopTime_Middle;
					JudgeParameter.RollbackPerrVBCount = TuningParameter.RollbackPerrVBCount_Middle;
					JudgeParameter.RollbackCurVBGain = TuningParameter.RollbackVBGain_Middle * 0.01;
					JudgeParameter.MaxNotchNum = TuningParameter.NotchMaxNum_Middle;
					break;

				case TuningStrength.Strong:

					JudgeParameter.PerrVBIsSafeStopCount = TuningParameter.PerrVBIsSafeStopCount_Strong;
					JudgeParameter.KvpLimitCurrentVB = TuningParameter.CurVBKvpLimit_Strong * 0.01;
					JudgeParameter.FinishSafeStopCount = TuningParameter.FinishSafeStopCount_Strong;
					JudgeParameter.FinishSafeStopKppLimit = TuningParameter.FinishSafeStopKppLimit_Strong;
					JudgeParameter.FinishSafeStopKvpLimit = TuningParameter.FinishSafeStopKvpLimit_Strong;
					JudgeParameter.FinishSafeStopTime = TuningParameter.FinishSafeStopTime_Strong;
					JudgeParameter.RollbackPerrVBCount = TuningParameter.RollbackPerrVBCount_Strong;
					JudgeParameter.RollbackCurVBGain = TuningParameter.RollbackVBGain_Strong * 0.01;
					JudgeParameter.MaxNotchNum = TuningParameter.NotchMaxNum_Strong;
					break;

				default:
					break;
			}

			switch (UserParameter.Machine)
			{
				case TuningMachine.Belt:

					JudgeParameter.CoeffKvi = TuningParameter.CoeffKvi_Belt * 0.01;
					JudgeParameter.MaxKvi = TuningParameter.MaxKvi_Belt;
					JudgeParameter.FFT10dbSearchMaxFrq = TuningParameter.FFT10dbSearchMaxFrq_Belt;
					JudgeParameter.FFT10dbSearchMinFrq = TuningParameter.FFT10dbSearchMinFrq_Belt;
					JudgeParameter.FFT6dbSearchMaxFrq = TuningParameter.FFT6dbSearchMaxFrq_Belt;
					JudgeParameter.FFT6dbSearchMinFrq = TuningParameter.FFT6dbSearchMinFrq_Belt;
					JudgeParameter.SpringCosntat = TuningParameter.SpringConstant_Belt;
					break;

				case TuningMachine.Screw:

					JudgeParameter.CoeffKvi = TuningParameter.CoeffKvi_Screw * 0.01;
					JudgeParameter.MaxKvi = TuningParameter.MaxKvi_Screw;
					JudgeParameter.FFT10dbSearchMaxFrq = TuningParameter.FFT10dbSearchMaxFrq_Screw;
					JudgeParameter.FFT10dbSearchMinFrq = TuningParameter.FFT10dbSearchMinFrq_Screw;
					JudgeParameter.FFT6dbSearchMaxFrq = TuningParameter.FFT6dbSearchMaxFrq_Screw;
					JudgeParameter.FFT6dbSearchMinFrq = TuningParameter.FFT6dbSearchMinFrq_Screw;
					JudgeParameter.SpringCosntat = TuningParameter.SpringConstant_Screw;
					break;

				case TuningMachine.Disk:

					JudgeParameter.CoeffKvi = TuningParameter.CoeffKvi_Disk * 0.01;
					JudgeParameter.MaxKvi = TuningParameter.MaxKvi_Disk;
					JudgeParameter.FFT10dbSearchMaxFrq = TuningParameter.FFT10dbSearchMaxFrq_Disk;
					JudgeParameter.FFT10dbSearchMinFrq = TuningParameter.FFT10dbSearchMinFrq_Disk;
					JudgeParameter.FFT6dbSearchMaxFrq = TuningParameter.FFT6dbSearchMaxFrq_Disk;
					JudgeParameter.FFT6dbSearchMinFrq = TuningParameter.FFT6dbSearchMinFrq_Disk;
					JudgeParameter.SpringCosntat = TuningParameter.SpringConstant_Disk;
					break;
			}


			JudgeParameter.FFT10dbApplyMaxFrq = JudgeParameter.FFT10dbSearchMaxFrq;
			JudgeParameter.FFT10dbApplyMinFrq = JudgeParameter.FFT10dbSearchMinFrq;
			JudgeParameter.FFT6dbApplyMaxFrq = JudgeParameter.FFT6dbSearchMaxFrq;
			JudgeParameter.FFT6dbApplyMinFrq = JudgeParameter.FFT6dbSearchMinFrq;

			int frq = JudgeParameter.FFT10dbSearchMaxFrq;

			if (UserParameter.LoadInertia >= 0.0000001)
			{
				frq = (int)(Math.Sqrt(JudgeParameter.SpringCosntat / UserParameter.LoadInertia) / (Math.PI * 2.0));
			}

			if (frq >= JudgeParameter.FFT10dbApplyMinFrq) { JudgeParameter.FFT10dbApplyMinFrq = frq; }
			if (frq >= JudgeParameter.FFT10dbApplyMaxFrq) { JudgeParameter.FFT10dbApplyMinFrq = JudgeParameter.FFT10dbApplyMaxFrq; }
			if (frq >= JudgeParameter.FFT6dbApplyMinFrq) { JudgeParameter.FFT6dbApplyMinFrq = frq; }
			if (frq >= JudgeParameter.FFT6dbApplyMaxFrq) { JudgeParameter.FFT6dbApplyMinFrq = JudgeParameter.FFT6dbApplyMaxFrq; }
		
			switch (UserParameter.EncderType)
			{
				case TuningEncder.Resolver:
				case TuningEncder.Resolver2X:

					JudgeParameter.SplitErrorPulse = TuningParameter.SplitErrorPulse_RES;
					JudgeParameter.OvershootErrorPulse = UserParameter.TargetInposition / TuningParameter.OvershootErrorPulse_RES;
					JudgeParameter.PerrVibrationPulse = TuningParameter.PerrVBPulse_RES;

					if (UserParameter.InertiaRatio <= 5.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_RES_High;
					}
					else if (UserParameter.InertiaRatio <= 15.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_RES_Mid;
					}
					else
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_RES_Low;
					}
					
					break;

				case TuningEncder.Resolver4X:
				case TuningEncder.Resolver5X:
				case TuningEncder.Resolver8X:
				case TuningEncder.Enc2000:
				case TuningEncder.Enc2048:
				case TuningEncder.Enc2500:

					JudgeParameter.SplitErrorPulse = TuningParameter.SplitErrorPulse_INC;
					JudgeParameter.OvershootErrorPulse = UserParameter.TargetInposition / TuningParameter.OvershootErrorPulse_INC;
					JudgeParameter.PerrVibrationPulse = TuningParameter.PerrVBPulse_INC;

					if (UserParameter.InertiaRatio <= 5.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_INC_High;
					}
					else if (UserParameter.InertiaRatio <= 15.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_INC_Mid;
					}
					else
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_INC_Low;
					}

					break;

				default:
				case TuningEncder.Enc17B:

					JudgeParameter.SplitErrorPulse = TuningParameter.SplitErrorPulse_17B;
					JudgeParameter.OvershootErrorPulse = UserParameter.TargetInposition / TuningParameter.OvershootErrorPulse_17B;
					JudgeParameter.PerrVibrationPulse = TuningParameter.PerrVBPulse_17B;

					if (UserParameter.InertiaRatio <= 5.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_17B_High;
					}
					else if (UserParameter.InertiaRatio <= 15.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_17B_Mid;
					}
					else
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_17B_Low;
					}
					
					break;

				case TuningEncder.Enc23B:

					JudgeParameter.SplitErrorPulse = TuningParameter.SplitErrorPulse_23B;
					JudgeParameter.OvershootErrorPulse = UserParameter.TargetInposition / TuningParameter.OvershootErrorPulse_23B;
					JudgeParameter.PerrVibrationPulse = TuningParameter.PerrVBPulse_23B;

					if (UserParameter.InertiaRatio <= 5.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_23B_High;
					}
					else if (UserParameter.InertiaRatio <= 15.0)
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_23B_Mid;
					}
					else
					{
						JudgeParameter.VelObsTime = TuningParameter.VelObsTime_23B_Low;
					}
					
					break;
			}

			if (UserParameter.Machine == TuningMachine.Belt)
			{
				JudgeParameter.SplitErrorPulse *= 2;
				JudgeParameter.OvershootErrorPulse = UserParameter.TargetInposition;
				JudgeParameter.PerrVibrationPulse *= 2;
			}

			switch (UserParameter.Priorty)
			{
				case TuningPriorty.Normal:

					JudgeParameter.CoeffKpp = TuningParameter.CoeffKpp_Normal * 0.01;
					break;

				case TuningPriorty.Position:

					JudgeParameter.CoeffKpp = TuningParameter.CoeffKpp_Position * 0.01;

					JudgeParameter.SplitErrorPulse *= 2;
					JudgeParameter.OvershootErrorPulse = JudgeParameter.OvershootErrorPulse * 3 / 2;
					break;

				case TuningPriorty.Stiffness:

					JudgeParameter.CoeffKpp = TuningParameter.CoeffKpp_Stiffness * 0.01;

					JudgeParameter.SplitErrorPulse /= 2;
					JudgeParameter.OvershootErrorPulse /= 2;
					break;
			}

			if (UserParameter.IsUseVelObserver)
			{
				JudgeParameter.C_FB_Lpf = 0;
				JudgeParameter.V_FB_Lpf = 0;

				switch (UserParameter.EncderType)
				{
					case TuningEncder.Resolver:
					case TuningEncder.Resolver2X:

						JudgeParameter.Kcp = TuningParameter.InitKcp_RES_OBS;
						JudgeParameter.Kci = TuningParameter.InitKci_RES;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_RES_VelObs;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_RES_VelObs;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_RES_VelObs;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_RES_VelObs;
						break;

					case TuningEncder.Resolver4X:
					case TuningEncder.Resolver5X:
					case TuningEncder.Resolver8X:
					case TuningEncder.Enc2000:
					case TuningEncder.Enc2048:
					case TuningEncder.Enc2500:

						JudgeParameter.Kcp = TuningParameter.InitKcp_INC_OBS;
						JudgeParameter.Kci = TuningParameter.InitKci_INC;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_INC_VelObs;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_INC_VelObs;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_INC_VelObs;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_INC_VelObs; 
						break;

					default:
					case TuningEncder.Enc17B:
					
						JudgeParameter.Kcp = TuningParameter.InitKcp_17B_OBS;
						JudgeParameter.Kci = TuningParameter.InitKci_17B;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_17B_VelObs;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_17B_VelObs;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_17B_VelObs;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_17B_VelObs;
						break;
					
					case TuningEncder.Enc23B:

						JudgeParameter.Kcp = TuningParameter.InitKcp_23B_OBS;
						JudgeParameter.Kci = TuningParameter.InitKci_23B;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_23B_VelObs;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_23B_VelObs;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_23B_VelObs;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_23B_VelObs; 
						break;
				}
			}
			else
			{
				switch (UserParameter.EncderType)
				{
					case TuningEncder.Resolver:
					case TuningEncder.Resolver2X:

						JudgeParameter.Kcp = TuningParameter.InitKcp_RES;
						JudgeParameter.Kci = TuningParameter.InitKci_RES;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_RES;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_RES;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_RES;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_RES;
						break;

					case TuningEncder.Resolver4X:
					case TuningEncder.Resolver5X:
					case TuningEncder.Resolver8X:
					case TuningEncder.Enc2000:
					case TuningEncder.Enc2048:
					case TuningEncder.Enc2500:

						JudgeParameter.Kcp = TuningParameter.InitKcp_INC;
						JudgeParameter.Kci = TuningParameter.InitKci_INC;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_INC;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_INC;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_INC;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_INC;
						break;

					default:
					case TuningEncder.Enc17B:
				
						JudgeParameter.Kcp = TuningParameter.InitKcp_17B;
						JudgeParameter.Kci = TuningParameter.InitKci_17B;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_17B;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_17B;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_17B;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_17B;
						break;

					case TuningEncder.Enc23B:

						JudgeParameter.Kcp = TuningParameter.InitKcp_23B;
						JudgeParameter.Kci = TuningParameter.InitKci_23B;
						JudgeParameter.C_FB_Lpf = TuningParameter.C_FB_Lpf_23B;
						JudgeParameter.V_FB_Lpf = TuningParameter.V_FB_Lpf_23B;
						JudgeParameter.V_FB_n = TuningParameter.V_FB_n_23B;
						JudgeParameter.LpfInit = TuningParameter.LpfInit_23B;
						break;
				}
			}

			JudgeParameter.FinishGainAdjustCount = TuningParameter.FinishGainAdjustCount;
			JudgeParameter.FastOvershootTime = (TuningParameter.FastOvershootTime / LogWork.LogPeriod);			//20170131 add

		}

		private void ClearTuningResult()
		{
			IsSplitError = false;
			IsSlowOvershootError = false;
			IsFastOvershootError = false;
			IsPerrVB = false;
			PerrVBCount = 0;

			IsInposition = false;
			InposCount = 0;
			InposDelay = 0;

			for (int i = 0; i < InposTime.Length; i++)
			{
				InposTime[i] = 0;
			}
		}

		private void CheckTheCurrentVibration()
		{
			int cmd = new int();

			if (IsWaitVB)
			{
				if (IsCurrentVibration) { return; }

				if (!CCommandTx.WriteSvNet(CParamID.TargetPosition, UserParameter.StartPosition)) { return; }

				if (!CCommandTx.WriteSvNet(CParamID.ControlMode, 1)) { return; }

				cmd = ReadServoCommand();

				cmd |= 0x01;				//ServoOn bit Set
				cmd |= 0x02;				//Profile Start bit Set
				cmd &= ~0x20;				//Smooth Stop bit Clear

				if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

				IsWaitVB = false;

				return;
			}

			bool roll_back = new bool();

			if (IsCurrentVibration)
			{
				AppendResultText("\n" + UserText.AutoTuningAdjustCurrentVibrationDetect + "\n" + "\n");

				cmd = ReadServoCommand();

				cmd &= ~0x02;		//Profile Start bit Clear
				cmd |= 0x20;		//Smooth Stop bit Set

				AppendResultText(UserText.AutoTuningAdjustSmoothStop + "\n" + "\n");

				if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

				Thread.Sleep(500);

				AppendResultText(UserText.AutoTuningAdjustServoOff + "\n" + "\n");

				cmd &= ~0x01;		//ServoOn bit Clear
				if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

				Thread.Sleep(500);

				//�Q�C����������������
				if (GainAdjustCount <= TuningParameter.RetryNumInitGain)
				{
					//�����Q�C���Đݒ�\��
					if (CurrentVBCountInitGain < TuningParameter.RetryCountCurVBInitGain)
					{
						CurrentVBCountInitGain++;
						//�����Q�C���s��
						GainAdjustCount = 0;

						if (TuningParameter.InitKpp <= 2 ||
							TuningParameter.InitKvp <= 4 ||
							TuningParameter.InitKvi <= 2)
						{
							//�����Q�C���������s
							AppendResultText(UserText.AutoTuningAdjustInitGainReset + "\n" + "\n");
							AppendResultText("\n" + UserText.AutoTuningAdjustInitGainAdjustFailed + "\n" + "\n");
							AppendResultText("\n" + UserText.AutoTuningAdjustGainAdjustFailed + "\n");

							AdjustSq = 0;				//�Q�C�������I��

							ClearAutoTuningSq();
							TimerAutoTuing.Enabled = false;
						}
						else
						{
							double coeff = (double)TuningParameter.RetryCoeffInitGain * 0.01;

							TuningParameter.InitKpp = (int)((double)TuningParameter.InitKpp * coeff);
							TuningParameter.InitKvp = (int)((double)TuningParameter.InitKvp * coeff);
							TuningParameter.InitKvi = (int)((double)TuningParameter.InitKvi * coeff);

							//�T�[�{�Q�C���Đݒ�
							SetServoGain(TuningParameter.InitKpp, TuningParameter.InitKvp, TuningParameter.InitKvi);

							//�t�B���^�ݒ�N���A
							ClearFillter();
							//���x�t�B�[�h�o�b�N�t�B���^�Đݒ�
							if (MainForm.DriverRevision >= AppConst.UpTadVer520)
							{
								CCommandTx.WriteSvNet(CParamID.V_FB_Lpf, CMonitor.GetParameter(CParamID.V_FB_Lpf));
							}

							//20150315 add
							//�u�����x�I�u�U�[�o�ݒ�
							WriteVelocityObserver(UserParameter.IsUseVelObserver, false, JudgeParameter.VelObsTime);

							IndexNF = 0;
							IndexLPF = 0;

							listNF.Clear();
							listLPF.Clear();

							listInvalidNF.Clear();

							//���胍�[�p�X�t�B���^�ݒ�
							AddLowpassFillter(JudgeParameter.LpfInit);
							SetTuningHistory(TuningAction.LpfNew);

							AppendResultText("\n");

							coeff = (double)TuningParameter.RetryCoeffUpGain * 0.01;

							//TuningParameter.UpKpp = (int)((double)JudgeParameter.UpKppStart * coeff);
							//TuningParameter.UpKvp = (int)((double)JudgeParameter.UpKvpStart * coeff);
							//TuningParameter.UpKvi = (int)((double)JudgeParameter.UpKviStart * coeff);

							int up_kpp = TuningParameter.UpKpp;
							int up_kvp = TuningParameter.UpKvp;
							int up_kvi = TuningParameter.UpKvi;

							up_kpp = (int)((double)up_kpp * coeff + 0.5);
							up_kvp = (int)((double)up_kvp * coeff + 0.5);
							up_kvi = (int)((double)up_kvi * coeff + 0.5);

							if (up_kpp == TuningParameter.UpKpp) { up_kpp -= 1; }
							if (up_kvp == TuningParameter.UpKvp) { up_kvp -= 1; }
							if (up_kvi == TuningParameter.UpKvi) { up_kvi -= 1; }

							TuningParameter.UpKpp = up_kpp;
							TuningParameter.UpKvp = up_kvp;
							TuningParameter.UpKvi = up_kvi;

							if (TuningParameter.UpKpp <= 1) { TuningParameter.UpKpp = 1; }
							if (TuningParameter.UpKvp <= 1) { TuningParameter.UpKvp = 1; }
							if (TuningParameter.UpKvi <= 1) { TuningParameter.UpKvi = 1; }

							AdjustSq = 0;				//�����Q�C���m�F
							AdjustSqWait = 0;

							AppendResultText(UserText.AutoTuningAdjustInitGainReset + "\n" + "\n");

							AppendResultText(UserText.AutoTuningAdjustInitKpSetting + TuningParameter.InitKpp.ToString() + " [rad/s]" + "\n");
							AppendResultText(UserText.AutoTuningAdjustInitKvSetting + TuningParameter.InitKvp.ToString() + " [rad/s]" + "\n");
							AppendResultText(UserText.AutoTuningAdjustInitKiSetting + TuningParameter.InitKvi.ToString() + " [1/s]" + "\n");

							AppendResultText("\n");

							AppendResultText(UserText.AutoTuningAdjustKpUpRatio + TuningParameter.UpKpp.ToString() + " [rad/s]" + "\n");
							AppendResultText(UserText.AutoTuningAdjustKvUpRatio + TuningParameter.UpKvp.ToString() + " [rad/s]" + "\n");
							AppendResultText(UserText.AutoTuningAdjustKiUpRatio + TuningParameter.UpKvi.ToString() + " [1/s]" + "\n");

							AppendResultText("\n" + UserText.AutoTuningAdjustInitGainChecking + "\n" + "\n");

							UpdateGainNowText();
						}
					}
					else
					{
						roll_back = true;
					}
				}
				else
				{

					if (CurrentVBCount < TuningParameter.RetryCountCurVB)
					{
						CurrentVBCount++;

						if(CheckTheNotchVibration())
						{
							for (int i = 0; i < listNF.Count; i++)
							{
								SetNotchFillter(i, listNF[i].Hz, listNF[i].Depth, listNF[i].Width);
							}

							SetServoGain(NowGain.Kpp, NowGain.Kvp, NowGain.Kvi);

							AdjustSq = 99;				//�t�B���^�ݒ��̈��艻�҂�
							AdjustSqWait = 0;

						}
						else
						{
							roll_back = true;
						}
					}
					else
					{
						roll_back = true;
					}
				}

				if (roll_back)
				{
					int sts = new int();

					CDataTool.SetNow(CDataTool.VIB_TIME);

					do
					{
						CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts);

						if (CDataTool.IsTimerLimit(CDataTool.VIB_TIME, 10)) { break; }

					} while ((sts & 0x40000) == 0x40000);

					PopTuningSafeGain(true);

					AdjustSq = 50;				//�Q�C����������
					AdjustSqWait = 0;

				}

				IsWaitVB = true;

			}
		}

		private bool CheckTheNotchVibration()
		{
			bool ret = new bool();

			int n = listTuningHistory.Count - 1;

			if (n >= 0)
			{
				//�m�b�`�t�B���^�ݒ��ɐU��
				if (listTuningHistory[n].ThisAction == TuningAction.Nf1New)
				{
					listInvalidNF.Add(new FFT_Member(listNF[0].Hz, listNF[0].fftResult.dB, listNF[0].fftResult.dBsub));
					ReConfigNotchFillter(0);
					SetTuningHistory(TuningAction.Nf1Del);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf2New)
				{
					listInvalidNF.Add(new FFT_Member(listNF[1].Hz, listNF[1].fftResult.dB, listNF[1].fftResult.dBsub));
					ReConfigNotchFillter(1);
					SetTuningHistory(TuningAction.Nf2Del);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf3New)
				{
					listInvalidNF.Add(new FFT_Member(listNF[2].Hz, listNF[2].fftResult.dB, listNF[2].fftResult.dBsub));
					ReConfigNotchFillter(2);
					SetTuningHistory(TuningAction.Nf3Del);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf4New)
				{
					listInvalidNF.Add(new FFT_Member(listNF[3].Hz, listNF[3].fftResult.dB, listNF[3].fftResult.dBsub));
					ReConfigNotchFillter(3);
					SetTuningHistory(TuningAction.Nf4Del);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf5New)
				{
					listInvalidNF.Add(new FFT_Member(listNF[4].Hz, listNF[4].fftResult.dB, listNF[4].fftResult.dBsub));
					ReConfigNotchFillter(4);
					SetTuningHistory(TuningAction.Nf5Del);
					ret = true;
				}
				//�m�b�`�t�B���^�X�V��ɐU��
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf1Update)
				{
					listInvalidNF.Add(new FFT_Member(listNF[0].Hz, listNF[0].fftResult.dB, listNF[0].fftResult.dBsub));
					listNF[0].Depth += TuningParameter.NotchSubDepth;
					SetTuningHistory(TuningAction.Nf1Update);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf2Update)
				{
					listInvalidNF.Add(new FFT_Member(listNF[1].Hz, listNF[1].fftResult.dB, listNF[1].fftResult.dBsub));
					listNF[1].Depth += TuningParameter.NotchSubDepth;
					SetTuningHistory(TuningAction.Nf2Update);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf3Update)
				{
					listInvalidNF.Add(new FFT_Member(listNF[2].Hz, listNF[2].fftResult.dB, listNF[2].fftResult.dBsub));
					listNF[2].Depth += TuningParameter.NotchSubDepth;
					SetTuningHistory(TuningAction.Nf3Update);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf4Update)
				{
					listInvalidNF.Add(new FFT_Member(listNF[3].Hz, listNF[3].fftResult.dB, listNF[3].fftResult.dBsub));
					listNF[3].Depth += TuningParameter.NotchSubDepth;
					SetTuningHistory(TuningAction.Nf4Update);
					ret = true;
				}
				else if (listTuningHistory[n].ThisAction == TuningAction.Nf5Update)
				{
					listInvalidNF.Add(new FFT_Member(listNF[4].Hz, listNF[4].fftResult.dB, listNF[4].fftResult.dBsub));
					listNF[4].Depth += TuningParameter.NotchSubDepth;
					SetTuningHistory(TuningAction.Nf5Update);
					ret = true;
				}
			}

			return ret;
		}

		private List<FFT_Member> listPeekMax = new List<FFT_Member>();
		private List<FFT_Member> listPeekMin = new List<FFT_Member>();

		private List<FFT_Member> listInvalidNF = new List<FFT_Member>();	//20160330 update <int>��<FFT_Member>

		private int FFT_PeekCountAll
		{
			get
			{
				return listPeekFrq10db.Count;
			}
		}

		private int FFT_PeekCountLess1KHz
		{
			get
			{
				int n = new int();

				for (int i = 0; i < listPeekFrq10db.Count; i++)
				{
					int frq = FFT_C.F2Real(listPeekFrq10db[i].Hz);

					if (frq <= 1000)
					{
						n++;
					}
				}

				return n;
			}
		}

		private bool ApplyTuningFillter
		{
			get
			{
				if (IsApplyNF || IsApplyLPF)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private int FFT_Analysis()
		{
			//if (GainAdjustCount <= TuningParameter.RetryNumInitGain) { return AdjustSq; }

			IsApplyLPF = false;
			IsApplyNF = false;
			IsSameNF = false;
			IsMaxNF = false;
			IsKvpLimitNF = false;
			IsLimitNF = false;
			IsKvpLimitVB = false;
			IsAdjustWait = false;
			IsFFTWait = false;
			FrqVB = 0;

			SearchPeekFrequency();

			switch (LogWork.LogPeriod)
			{
				default:
				case 1:
					SearchAvailableFillter(ref listPeekFrq10db, JudgeParameter.FFT10dbApplyMinFrq);
					break;
				case 2:
					SearchAvailableFillter(ref listPeekFrq6db, JudgeParameter.FFT6dbApplyMinFrq);
					break;
				case 4:
					SearchAvailableFillter(ref listPeekFrq3db, JudgeParameter.FFT6dbApplyMinFrq);
					break;
			}

			if (IsSameNF)
			{
				//�m�b�`�t�B���^�ݒ�l����
				return AdjustSq;
			}

			if (ApplyTuningFillter)
			{
				//���[�p�X�t�B���^�܂��̓m�b�`�t�B���^���ݒ肳�ꂽ
				if (GainAdjustCount <= TuningParameter.RetryNumInitGain)		//20170217 add
				{
					//�����Q�C���������Ƀm�b�`�t�B���^���ݒ肳�ꂽ�BFFT�����l�Ď擾�B
					AdjustSq = 10;
					AdjustSqBackup = AdjustSq;
				}
				return 99;
			}

			if (IsAdjustWait)
			{
				//FFT����҂�
				AppendResultText(UserText.AutoTuningAdjustWaitKvLimit + "\n");
				AppendResultText(UserText.AutoTuningAdjustWaitFFT + "\n");
				return 200;
			}

			if (IsFFTWait)
			{
				//FFT����҂�
				AppendResultText(UserText.AutoTuningAdjustWaitFFT + "\n");
				return 200;
			}

			if (IsKvpLimitVB)
			{
				//�m�b�`�t�B���^�ݒ�Q�C�����E
				AppendResultText(UserText.AutoTuningAdjustKvLimitCurrentVibration + "\n");
				return 100;
			}

			if (IsKvpLimitNF)
			{
				//�m�b�`�t�B���^�ݒ���g�����E
				AppendResultText(UserText.AutoTuningAdjustKvLimitNotchFillterFrequecy + "\n");
				return 100;
			}

			if (IsLimitNF)
			{
				//�ݒ�l���E�͌p��
				//�m�b�`�t�B���^�ݒ�l���E
				//AppendResultText(UserText.AutoTuningAdjustNotchFillterFrequecyLimit + "\n");
				//return 100;
			}

			if (IsMaxNF)
			{
				//�m�b�`�t�B���^�ݒ�����E
				AppendResultText(UserText.AutoTuningAdjustNotchFillterNumLimit + "\n");
				return 100;
			}

			if (FFT_PeekCountLess1KHz >= 1)
			{
				//�s�[�N���o�Ńt�B���^�K�p����Ȃ��ꍇ�͌p���@�m�b�`�t�B���^�ݒ�l�����E�̏ꍇ�B
				//�s�[�N�����o���Ă���̂Ƀt�B���^���ݒ肳��Ă��Ȃ�
				//if (ApplyTuningFillter == false)
				//{
				//    AppendResultText(UserText.AutoTuningAdjustFillterSetupFailed + "\n");
				//    return 100;
				//}
			}

			return AdjustSq;
		}

		private void SearchPeekFrequency()
		{
			int max10db = FFT_C.R2FFT(JudgeParameter.FFT10dbSearchMaxFrq);
			int min10db = FFT_C.R2FFT(JudgeParameter.FFT10dbSearchMinFrq);

			int max6db = FFT_C.R2FFT(JudgeParameter.FFT6dbSearchMaxFrq);
			int min6db = FFT_C.R2FFT(JudgeParameter.FFT6dbSearchMinFrq);

			listPeekFrq10db.Clear();
			listPeekFrq6db.Clear();
			listPeekFrq3db.Clear();

			double _0db = 0.0F;

			for (int i = 0; i < listPeekMax.Count; i++)
			{
				if (listPeekMax[i].Hz < min10db) { continue; }
				if (listPeekMax[i].Hz > max10db) { break; }

				int idx = listPeekMax[i].Hz;

				if (listPeekMax[i].Hz <= max6db && listPeekMax[i].Hz >= min6db)
				{
					//3db
					if (listPeekMax[i].dB - PeekFrq3db > fftBuf_ref[idx] && listPeekMax[i].dB >= _0db)
					{
						listPeekFrq3db.Add(new FFT_Member(listPeekMax[i].Hz, listPeekMax[i].dB, listPeekMax[i].dB - fftBuf_ref[idx]));
					}
					//6db
					if (listPeekMax[i].dB - PeekFrq6db > fftBuf_ref[idx] && listPeekMax[i].dB >= _0db)
					{
						listPeekFrq6db.Add(new FFT_Member(listPeekMax[i].Hz, listPeekMax[i].dB, listPeekMax[i].dB - fftBuf_ref[idx]));
					}
				}

				//10db
				if (listPeekMax[i].dB - PeekFrq10db > fftBuf_ref[idx] && listPeekMax[i].dB >= _0db)
				{
					listPeekFrq10db.Add(new FFT_Member(listPeekMax[i].Hz, listPeekMax[i].dB, listPeekMax[i].dB - fftBuf_ref[idx]));
				}
			}

			switch(LogWork.LogPeriod)
			{
				default:
				case 1:
					if (listPeekFrq10db.Count > 0)
					{
						AppendResultText(UserText.AutoTuningAdjustFFTpeekDetect + "\n");

						for (int i = 0; i < listPeekFrq10db.Count; i++)
						{
							int frq = FFT_C.F2Real(listPeekFrq10db[i].Hz);
							double db = listPeekFrq10db[i].dB;

							AppendResultText(UserText.AutoTuningAdjustDot + frq.ToString() + " (" + listPeekFrq10db[i].Hz.ToString() + ") " + " [Hz]" + " ");
							AppendResultText(UserText.AutoTuningAdjustDot + db.ToString("F1") + " [dB]" + "\n");
						}
					}
					break;

				case 2:
					if (listPeekFrq6db.Count > 0)
					{
						AppendResultText(UserText.AutoTuningAdjustFFTpeekDetect + "\n");

						for (int i = 0; i < listPeekFrq6db.Count; i++)
						{
							int frq = FFT_C.F2Real(listPeekFrq6db[i].Hz);
							double db = listPeekFrq6db[i].dB;

							AppendResultText(UserText.AutoTuningAdjustDot + frq.ToString() + " (" + listPeekFrq6db[i].Hz.ToString() + ") " + " [Hz]" + " ");
							AppendResultText(UserText.AutoTuningAdjustDot + db.ToString("F1") + " [dB]" + "\n");
						}
					}
					break;
		
				case 4:
					if (listPeekFrq3db.Count > 0)
					{
						AppendResultText(UserText.AutoTuningAdjustFFTpeekDetect + "\n");

						for (int i = 0; i < listPeekFrq3db.Count; i++)
						{
							int frq = FFT_C.F2Real(listPeekFrq3db[i].Hz);
							double db = listPeekFrq3db[i].dB;

							AppendResultText(UserText.AutoTuningAdjustDot + frq.ToString() + " (" + listPeekFrq3db[i].Hz.ToString() + ") " + " [Hz]" + " ");
							AppendResultText(UserText.AutoTuningAdjustDot + db.ToString("F1") + " [dB]" + "\n");
						}
					}
					break;
			}

		}

		private bool SerchKvpLimit(List<FFT_Member> listPeek)
		{
			bool notch_exsist = new bool();

			int kvp_lim = (int)((double)NowGain.Kvp / 6.28 / JudgeParameter.KvpLimitCurrentVB);

			int frq = FFT_C.F2Real(listPeek[0].Hz);

			if (frq <= kvp_lim)	//���x���[�v�Q�C���Ւf���g����4�{�ȉ��ɋ��U�_
			{
				ApplyCountVB++;

				if (ApplyCountVB >= TuningParameter.CurVBKvpLimitCount)
				{
					//KV���E
					IsKvpLimitVB = true;
					FrqVB = frq;
				}
				else
				{
					IsAdjustWait = true;
				}

				for (int j = 0; j < listNF.Count; j++)
				{
					int sub = (int)((double)listNF[j].Hz * 0.1);	//10%

					int min = listNF[j].Hz - sub;
					int max = listNF[j].Hz + sub;

					if (frq >= min && frq <= max)
					{
						//���Ƀm�b�`�t�B���^���ݒ肳��Ă���
						notch_exsist = true;
						break;
					}
				}

				if (!notch_exsist) { return true; }
			}
			else
			{
				ApplyCountVB = 0;
			}

			return false;
		}

		private void SerchInvalidFrequency(ref List<FFT_Member> listPeek)
		{
			for (int i = 0; i < listPeek.Count; i++)
			{
				int frq = FFT_C.F2Real(listPeek[i].Hz);
				int sub = (int)((double)frq * 0.1);

				for (int n = 0; n < listInvalidNF.Count; n++)
				{
					int min = listInvalidNF[n].Hz - sub;
					int max = listInvalidNF[n].Hz + sub;

					if (frq >= min && frq <= max)
					{
						if ((listPeek[i].dB - listInvalidNF[n].dB) <= 6.0)
						{
							//�m�b�`�t�B���^�������Ȃ����U
							listPeek.RemoveAt(i);
							i--;
							break;
						}
						else
						{
							//�m�b�`�t�B���^�Đݒ�m�b�`�t�B���^�������X�g����폜
							listInvalidNF.RemoveAt(n);
						}
					}
				}
			}
		}

		private void SortPeekFrequency(ref List<FFT_Member> listPeek)
		{
			List<FFT_Member> peek_frq = new List<FFT_Member>();

			for (int i = 0; i < listPeek.Count; i++)
			{
				if (i == 0)
				{
					peek_frq.Add(listPeek[i]);
					continue;
				}

				int num = peek_frq.Count;
				int sub = (int)((double)peek_frq[num - 1].Hz* 0.1);

				if (listPeek[i].Hz > peek_frq[num - 1].Hz + sub)
				{
					peek_frq.Add(new FFT_Member(listPeek[i]));
				}
				else
				{
					if (listPeek[i].dB > peek_frq[num - 1].dB)
					{
						peek_frq.RemoveAt(num - 1);
						peek_frq.Add(new FFT_Member(listPeek[i]));
					}
				}
			}

			if (peek_frq.Count > 0)
			{
				AppendResultText(UserText.AutoTuningAdjustFFTpeekExtract + "\n");

				for (int i = 0; i < peek_frq.Count; i++)
				{
					int frq = FFT_C.F2Real(peek_frq[i].Hz);
					double db = peek_frq[i].dB;

					AppendResultText(UserText.AutoTuningAdjustDot + frq.ToString() + " (" + peek_frq[i].Hz.ToString() + ") " + " [Hz]" + " ");
					AppendResultText(UserText.AutoTuningAdjustDot + db.ToString("F1") + " [dB]" + "\n");
				}
			}

			listPeek.Clear();

			for (int i = 0; i < peek_frq.Count; i++)
			{
				listPeek.Add(new FFT_Member(peek_frq[i]));
			}

		}

		private void SerchAvailableLowpassFillter(List<FFT_Member> listPeek)
		{
			for (int i = 0; i < listPeek.Count; i++)
			{
				bool lpf_on = true;

				int frq = FFT_C.F2Real(listPeek[i].Hz);		//FFT���g���ϊ�
				double db  = listPeek[i].dB;

				if (frq >= TuningParameter.LpfMinFrq && UserParameter.Machine != TuningMachine.Belt)
				{
					int lpf = (int)((double)frq * (TuningParameter.LpfFrqCoeff * 0.01));		//85%�Ŗ�-5db����

					if (lpf <= 1000)	//LPF 1KHz�ȉ�
					{
						for (int n = 0; n < listNF.Count; n++)
						{
							if (listNF[n].Hz <= 1000)
							{
								if (listNF[n].Hz >= lpf)
								{
									//LPF�ݒ���g���t�߂Ƀm�b�`�t�B���^
									//LPF�Ւf���g������Ƀm�b�`�t�B���^���ݒ肳��Ă���
									lpf_on = false;
								}
							}
						}
					}

					if (lpf_on)
					{
						if (IndexLPF == 0)
						{
							AddLowpassFillter(lpf);
							SetTuningHistory(TuningAction.LpfNew);
							break;
						}
						else
						{
							if (lpf < FrqLPF)
							{
								SetLowpassFillter(lpf);
								SetTuningHistory(TuningAction.LpfUpdate);
								break;
							}
							else
							{
								if (db < TuningParameter.NotchApplyAmp || frq >= TuningParameter.NotchMaxFrq)
								{
									break;
								}
								else
								{
									//0db�ȏォ��5.5KHz�ȉ��Ȃ�m�b�`�t�B���^�ݒ�
								}
							}
						}
					}
				}
			}
		}

		private void SerchAvailableNotchFillter(List<FFT_Member> listPeek, int min_frq)
		{
			int kvp_lim = (int)((double)NowGain.Kvp / 6.28 / JudgeParameter.KvpLimitCurrentVB);

			for (int i = 0; i < listPeek.Count; i++)
			{
				int frq = FFT_C.F2Real(listPeek[i].Hz);	//FFT���g���ϊ�
				double db  = listPeek[i].dB;
				double sub = listPeek[i].dBsub;

				bool notch_exist = new bool();
				bool notch_limit = new bool();

				int notch_idx = new int();
				int notch_depth = new int();
				int notch_width = new int();

				for (int j = 0; j < listNF.Count; j++)
				{
					double notch_frq = (double)listNF[j].Hz;
					double notch_sub = notch_frq * 0.1;

					int min = listNF[j].Hz - (int)(notch_sub);
					int max = listNF[j].Hz + (int)(notch_sub);

					int m20 = (int)((double)listNF[j].Hz - notch_sub * 0.20);
					int m40 = (int)((double)listNF[j].Hz - notch_sub * 0.40);
					int m60 = (int)((double)listNF[j].Hz - notch_sub * 0.60);
					int m80 = (int)((double)listNF[j].Hz - notch_sub * 0.80);

					int p20 = (int)((double)listNF[j].Hz + notch_sub * 0.20);
					int p40 = (int)((double)listNF[j].Hz + notch_sub * 0.40);
					int p60 = (int)((double)listNF[j].Hz + notch_sub * 0.60);
					int p80 = (int)((double)listNF[j].Hz + notch_sub * 0.80);

					if (frq >= min && frq <= max)
					{
						notch_exist = true;
				
						notch_idx = j;

						if (frq >= m20 && frq <= p20)
						{
							notch_width = 50;
						}
						else if (frq >= m40 && frq <= p40)
						{
							notch_width = 50 + TuningParameter.NotchSubWidth;
						}
						else if (frq >= m60 && frq <= p60)
						{
							notch_width = 60 + TuningParameter.NotchSubWidth;
						}
						else if (frq >= m80 && frq <= p80)
						{
							notch_width = 70 + TuningParameter.NotchSubWidth;
						}
						else
						{
							notch_width = 100;
						}

						if (notch_width <= listNF[j].Width) { notch_width = listNF[j].Width; }

						if (listNF[j].Depth <= 0 && (notch_width == listNF[j].Width))
						{
							//�m�b�`�t�B���^�̐ݒ�l�[�������E�i�����������Ȃ��j
							notch_limit = true;
							IsLimitNF = true;
							break;
						}
			
						notch_depth = listNF[j].Depth - TuningParameter.NotchSubDepth;

						if (notch_depth <= 0) { notch_depth = 0; }

						break;
					}
				}

				if (notch_limit) { continue; }

				if (notch_exist == true)
				{
					int n = AdjustActCount - listNF[notch_idx].Count;

					if (n <= TuningParameter.RetryNumNotch)
					{
						if ((listNF[notch_idx].fftResult.dB - listPeek[i].dB) <= 6.0)
						{
							//�m�b�`�t�B���^�������Ȃ����U
							listInvalidNF.Add(new FFT_Member(frq, db, sub));

							ReConfigNotchFillter(notch_idx);

							SetTuningHistory(TuningAction.Nf1Del + notch_idx);

							continue;
						}
					}
				}

				if (notch_exist == false)
				{
					notch_width = TuningParameter.NotchDefWidth;
					notch_depth = TuningParameter.NotchDefDepth;
				}

				if (frq <= kvp_lim)	//���x���[�v�Q�C���Ւf���g����n�{�ȉ��Ƀm�b�`�t�B���^
				{
					ApplyCountNF++;

					if (ApplyCountNF >= TuningParameter.CurVBNFLimitCount)
					{
						//KV���E
						IsKvpLimitNF = true;
						FrqVB = frq;
					}
					else
					{
						IsAdjustWait = true;
					}
				}
				else
				{
					ApplyCountFFT++;

					if (ApplyCountFFT < TuningParameter.CurVBFFTLimitCount)
					{
						//FFT����҂�
						IsFFTWait = true;
						return;
					}
					
					ApplyCountFFT = 0;

					//if (frq >= TuningParameter.NotchMinFrq)
					if (frq >= min_frq)
					{
						int idx = AddNotchFillter(notch_exist, notch_idx, frq, notch_depth, notch_width, listPeek[i]);

						if (idx >= 0)
						{
							if (notch_exist)
							{
								SetTuningHistory(TuningAction.Nf1Update + idx);
							}
							else
							{
								SetTuningHistory(TuningAction.Nf1New + idx);
							}

							break;
						}
					}
				}
			}
		}

		private void SearchAvailableFillter(ref List<FFT_Member> listPeek, int min_frq)
		{
			if (listPeek.Count <= 0)
			{
				ApplyCountVB = 0;
				ApplyCountNF = 0;
				ApplyCountFFT = 0;
	
				return;
			}

			if (SerchKvpLimit(listPeek)) { return; }		//KV Limit Serch

			SerchInvalidFrequency(ref listPeek);

			SortPeekFrequency(ref listPeek);

			//SerchAvailableLowpassFillter(listPeek);		//20161006 del

			SerchAvailableNotchFillter(listPeek, min_frq);
		}

		private int AddNotchFillter(bool notch_exist, int notch_idx, int notch_frq, int notch_depth, int notch_width, FFT_Member fft)
		{
			int idx = new int();

			if (notch_exist)
			{
				switch (notch_idx)
				{
					case 0:
						idx = CParamID.C_NF1_f;
						break;
					case 1:
						idx = CParamID.C_NF2_f;
						break;
					case 2:
						idx = CParamID.C_NF3_f;
						break;
					case 3:
						idx = CParamID.C_NF4_f;
						break;
					case 4:
						idx = CParamID.C_NF5_f;
						break;
				}
			}
			else
			{
				if (IndexNF >= JudgeParameter.MaxNotchNum)
				{
					IsMaxNF = true;
					return -1;
				}

				switch (IndexNF)
				{
					case 0:
						idx = CParamID.C_NF1_f;
						break;
					case 1:
						idx = CParamID.C_NF2_f;
						break;
					case 2:
						idx = CParamID.C_NF3_f;
						break;
					case 3:
						idx = CParamID.C_NF4_f;
						break;
					case 4:
						idx = CParamID.C_NF5_f;
						break;
				}
			}

			int depth = new int();
			int width = new int();

			if (notch_exist)
			{
				//2��ڈȍ~
				if (listNF[notch_idx].Depth == 0 && listNF[notch_idx].Width == 100)
				{
					//�m�b�`�t�B���^�ݒ�l���E
					IsLimitNF = true;
					return -2;
				}

				if (listNF[notch_idx].Depth == notch_depth && listNF[notch_idx].Width == notch_width)
				{
					//�m�b�`�t�B���^�ݒ�l����
					IsSameNF = true;
					return -3;
				}
				else
				{
					listNF[notch_idx].Hz = notch_frq;
					listNF[notch_idx].Depth = notch_depth;
					listNF[notch_idx].Width = notch_width;
					listNF[notch_idx].fftResult.dB = fft.dB;
					listNF[notch_idx].fftResult.dBsub = fft.dBsub;

					if (!CCommandTx.WriteSvNet(idx, notch_frq)) { return -10; }
					if (!CCommandTx.WriteSvNet(idx + 1, listNF[notch_idx].Depth)) { return -10; }
					if (!CCommandTx.WriteSvNet(idx + 2, listNF[notch_idx].Width)) { return -10; }
				}
			}
			else
			{
				//����
				if (!CCommandTx.WriteSvNet(idx, notch_frq)) { return -10; }
				if (!CCommandTx.WriteSvNet(idx + 1, notch_depth)) { return -10; }
				if (!CCommandTx.WriteSvNet(idx + 2, notch_width)) { return -10; }

				listNF.Add(new NotchMember(notch_frq, notch_depth, notch_width, IndexNF, AdjustActCount, fft));
				notch_idx = IndexNF;
				IndexNF++;
			}

			notch_frq = listNF[notch_idx].Hz;
			depth = listNF[notch_idx].Depth;
			width = listNF[notch_idx].Width;

			AppendResultText(UserText.AutoTuningAdjustNotchFillter + (notch_idx + 1).ToString() + UserText.AutoTuningAdjustEstablish + "\n");
			AppendResultText(UserText.AutoTuningAdjustNotchFillterFrequency + notch_frq.ToString() + " (" + FFT_C.R2FFT(notch_frq).ToString() + ") " + " [Hz]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustNotchFillterDepth + depth.ToString() + "\n");
			AppendResultText(UserText.AutoTuningAdjustNotchFillterWidth + width.ToString() + "\n");

			IsApplyNF = true;

			return notch_idx;
		}

		private void SetNotchFillter(int idx, int frq, int depth, int width)
		{
			if (idx >= CParamID.MAX_NOTCH_C) { return; }

			int n = new int();

			switch (idx)
			{
				case 0:
					n = CParamID.C_NF1_f;
					break;
				case 1:
					n = CParamID.C_NF2_f;
					break;
				case 2:
					n = CParamID.C_NF3_f;
					break;
				case 3:
					n = CParamID.C_NF4_f;
					break;
				case 4:
					n = CParamID.C_NF5_f;
					break;
			}

			if (!CCommandTx.WriteSvNet(n, frq)) { return; }
			if (!CCommandTx.WriteSvNet(n + 1, depth)) { return; }
			if (!CCommandTx.WriteSvNet(n + 2, width)) { return; }

			AppendResultText(UserText.AutoTuningAdjustNotchFillter + (idx + 1).ToString() + UserText.AutoTuningAdjustEstablish + "\n");
			AppendResultText(UserText.AutoTuningAdjustNotchFillterFrequency + frq.ToString() + " (" + FFT_C.R2FFT(frq).ToString() + ") " + " [Hz]" + "\n");
			AppendResultText(UserText.AutoTuningAdjustNotchFillterDepth + depth.ToString() + "\n");
			AppendResultText(UserText.AutoTuningAdjustNotchFillterWidth + width.ToString() + "\n");

			IsApplyNF = true;
		}

		private void ReConfigNotchFillter(int idx)
		{
			int c = listNF.Count;
			int e = c - 1;

			AppendResultText(UserText.AutoTuningAdjustNotchFillterReconstruct + "\n");

			if (idx == e)
			{
				//�ŏI�̃��X�g
				SetNotchFillter(idx, 0, 0, 50);

				listNF.RemoveAt(idx);
				IndexNF--;
			}
			else
			{
				//�r���̃��X�g
				SetNotchFillter(idx, 0, 0, 50);

				listNF.RemoveAt(idx);
				IndexNF--;

				for (int i = idx; i < listNF.Count; i++)
				{
					listNF[i].Index--;
					SetNotchFillter(listNF[i].Index, listNF[i].Hz, listNF[i].Depth, listNF[i].Width);
				}

				SetNotchFillter(e, 0, 0, 50);

			}
		}

		private void AddLowpassFillter(int frq)
		{
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_f, frq)) { return; }

			listLPF.Add(new LpfMember(frq, IndexLPF));

			IndexLPF++;
			FrqLPF = frq;

			IsApplyLPF = true;

			AppendResultText(UserText.AutoTuningAdjustLowpassFillterSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustLowpassFillterFrequency + frq.ToString() + " (" + FFT_C.R2FFT(frq).ToString() + ") " + " [Hz]" + "\n");

		}

		private void SetLowpassFillter(int frq)
		{
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_f, frq)) { return; }

			if (listLPF.Count > 0)
			{
				listLPF[0].Hz = frq;
			}

			FrqLPF = frq;

			IsApplyLPF = true;

			AppendResultText(UserText.AutoTuningAdjustLowpassFillterSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustLowpassFillterFrequency + frq.ToString() + " (" + FFT_C.R2FFT(frq).ToString() + ") " + " [Hz]" + "\n");

		}

		private bool IsPerrOvershoot
		{
			get
			{
				if (IsPerrSlowOvershoot || IsPerrFastOvershoot)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool IsPerrSlowOvershoot
		{
			get
			{
				if (IsSlowOvershootErrorP || IsSlowOvershootErrorN)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool IsPerrFastOvershoot
		{
			get
			{
				if (IsFastOvershootErrorP || IsFastOvershootErrorN)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool IsPerrSplit
		{
			get
			{
				if (IsSplitErrorP || IsSplitErrorN)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool IsInposSplit
		{
			get
			{
				if (InposCountP > 1 || InposCountN > 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool _IsCurrentVB = new bool();

		private void ClearVibration()
		{
			_IsCurrentVB = false;

			PositionVBCount = 0;
			
			CurrentVBCount = 0;
			CurrentVBCountInitGain = 0;
		}

		private bool IsCurrentVibration
		{
			get
			{
				if (_IsCurrentVB)
				{
					_IsCurrentVB = false;
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool IsPerrVibration
		{
			get
			{
				if (IsPerrVB_P || IsPerrVB_N)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool IsJudgePerrVibaration
		{
			get
			{
				if (PerrVibrationCount > JudgeParameter.PerrVBIsSafeStopCount)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private int PerrVibrationCount
		{
			get
			{
				int p = PerrVBCountP;
				int n = PerrVBCountN;

				if (p > n)
				{
					return p;
				}
				else
				{
					return n;
				}
			}
		}

		private bool IsKvpUpLimit
		{
			get
			{
				int min = 2000;

				for (int i = 0; i < listNF.Count; i++)
				{
					if (listNF[i].Hz < min)
					{
						min = listNF[i].Hz;
					}
				}

				double notch = (double)min;
				double kvp = (double)NowGain.Kvp / 6.28;

				//if (kvp >= JudgeParameter.MaxKvpUpLimit)
				//{
				//    return true;
				//}

				if (notch <= (kvp / JudgeParameter.KvpLimitCurrentVB))		//���x���[�v�Q�C���Ւf���g����n�{�ȉ��Ƀm�b�`�t�B���^
				{
					//KV���E
					return true;
				}
				else
				{
					return false;
				}

			}
		}

		private bool IsKviUpLimit
		{
			get
			{
				double lim = NowGain.Kvp * JudgeParameter.CoeffKvi;

				if (NowGain.Kvi >= lim && NowGain.Kvi >= JudgeParameter.MaxKvi)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private bool EnableUpKpp(GainMember gain)
		{
			double kpp = (double)gain.Kpp;
			double kvp = (double)gain.Kvp * JudgeParameter.CoeffKpp;

			if (kpp < kvp)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool EnableUpKvi(GainMember gain)
		{
			double kvi = (double)gain.Kvi;
			double kvp = (double)gain.Kvp * JudgeParameter.CoeffKvi;

			//if (kvi < kvp && !IsPerrOvershoot && !IsJudgePerrVibaration && kvi < JudgeParameter.MaxKvi)		//20161202 update kvi < JudgeParameter.MaxKvi
			if (kvi < kvp && !IsPerrFastOvershoot && !IsJudgePerrVibaration && kvi < JudgeParameter.MaxKvi)		//20170131 update
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool IsSafeStop
		{
			get
			{
				if (IsPerrOvershoot || IsPerrSplit || IsJudgePerrVibaration)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		private bool IsCompleteStop
		{
			get
			{
				if (IsInposSplit || IsPerrOvershoot || IsPerrSplit || PerrVibrationCount > 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		private bool IsHappyInpotionTime
		{
			get
			{
				if (InposTimeP <= UserParameter.TargetTime &&
					InposTimeN <= UserParameter.TargetTime)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		private double InpositionTimeAve
		{
			get
			{
				return (double)(InposTimeP + InposTimeN) / 2.0;
			}
		}

		private void PushTuningSafeGain(GainMember gain)
		{
			listHappyTuning.Add(new HappyTuning(gain, listNF, listLPF, listPeekFrq10db, listPeekFrq6db, listPeekFrq3db, PerrVibrationCount, InpositionTimeAve));
		}

		private void PopTuningSafeGain(bool is_vb)
		{
			int c = listHappyTuning.Count;
			int n = c - 1;

			if (c <= 0) { return; }

			int perr_cnt = new int();
			int kv_limit = new int();

			switch (UserParameter.Strength)
			{
				case TuningStrength.Light:

					perr_cnt = JudgeParameter.RollbackPerrVBCount;
					kv_limit = (int)((double)NowGain.Kvp * JudgeParameter.RollbackCurVBGain);
					break;

				case TuningStrength.Middle:

					perr_cnt = JudgeParameter.RollbackPerrVBCount;
					kv_limit = (int)((double)NowGain.Kvp * JudgeParameter.RollbackCurVBGain);
					break;

				case TuningStrength.Strong:

					perr_cnt = JudgeParameter.RollbackPerrVBCount;
					kv_limit = (int)((double)NowGain.Kvp * JudgeParameter.RollbackCurVBGain);
					break;
			}


			while (true)
			{
				if (is_vb)
				{
					if (listHappyTuning[n].PerrVibrationCount <= perr_cnt &&
						listHappyTuning[n].HappyGain.Kvp <= kv_limit)
					{
						break;
					}
					else
					{
						n--;
						if (n <= 0) { break; }
					}
				}
				else
				{
					if (listHappyTuning[n].PerrVibrationCount <= perr_cnt)
					{
						break;
					}
					else
					{
						n--;
						if (n <= 0) { break; }
					}
				}
			}

            if (n < 0) { return; }

			AppendResultText("\n" + UserText.AutoTuningAdjustRollbackStart + "\n" + "\n");

			SetKpp(listHappyTuning[n].HappyGain.Kpp);
			SetKvp(listHappyTuning[n].HappyGain.Kvp);
			SetKvi(listHappyTuning[n].HappyGain.Kvi);

			List<NotchMember> notch = listHappyTuning[n].HappyNotch;
			List<LpfMember> lpf = listHappyTuning[n].HappyLpf;

			for (int i = 0; i < CParamID.MAX_NOTCH_C; i++)
			{
				if (i < notch.Count)
				{
					SetNotchFillter(notch[i].Index, notch[i].Hz, notch[i].Depth, notch[i].Width);
				}
				else
				{
					SetNotchFillter(i, 0, 0, 50);
				}
			}

			for (int i = 0; i < CParamID.MAX_LPF_C; i++)
			{
				if (i < lpf.Count)
				{
					SetLowpassFillter(lpf[i].Hz);
				}
				else
				{
					SetLowpassFillter(0);
				}
			}

			IndexNF = 0;
			IndexLPF = 0;

			listNF.Clear();
			listLPF.Clear();

			listInvalidNF.Clear();

			for (int i = 0; i < notch.Count; i++)
			{
				listNF.Add(new NotchMember(notch[i]));
				IndexNF++;
			}

			for (int i = 0; i < lpf.Count; i++)
			{
				listLPF.Add(new LpfMember(lpf[i]));
				IndexLPF++;
			}

			listHappyTuning.RemoveRange(n + 1, c - n - 1);


			AppendResultText("\n" + UserText.AutoTuningAdjustRollbackFinish + "\n");

			AppendResultText("\n" + UserText.AutoTuningAdjustDot + (c - 1 - n).ToString() + UserText.AutoTuningAdjustRollbackNum + "\n");
			AppendResultText("\n");

			UpdateGainNowText();

		}

	}
}
