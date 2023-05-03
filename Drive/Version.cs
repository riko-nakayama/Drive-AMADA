
namespace Motion_Designer
{
    class Version
    {
        /// <summary>
        ///		�E�o�[�W�����Ǘ��J�n	20160128
        /// 
        ///		����������VER.0.10�����[�X20160128����������
        /// 
        ///     ����������VER.0.20�����[�X20160304����������
        #region VER.0.20
        ///     �E�������ꃊ�\�[�X�Ή�
        /// 
        ///		1.	CtlJogCntrol.cs
        ///			�ڕW���x�����l�ύX�B500��100
        ///			�����x�����x�����l�ύX�B500��100
        ///			TargetVelocity�v���p�e�B�ǉ��B									//20160315 update
        /// 
        ///		2.	JogControlForm.cs
        ///			���䃂�[�h�؂�ւ����ɖڕW���x�ύX�����ǉ��B
        ///			�d�����䃂�[�h�ɐ؂�ւ�����0�Ƃ���B							//20160315 update
        /// 
        ///		3.	AutoTuningForm.cs
        ///			���א��蓮��p�^�[���ύX�@�\�ǉ��B								//20160315 update
        /// 
        ///		4.	AutoTuningAdjust.cs
        ///			�U�����o��̏����Q�C���Đݒ莞�ɑ��x�I�u�U�[�o�ݒ�ǉ��B		//20160315 update
        /// 
        ///		5.	DigitalOsilloForm.cs
        ///			���Ԍv�����\������Ȃ����AlblTimeMeas2�̕\�����őO�ʂɕύX�B	//20160317 update
        ///			
        ///		6.	ParameterForm.cs
        ///			�ǂݍ��ݐ�pID�������ݎ��ɁA
        ///			�v���O���X�o�[���\������錏���C���B							//20160328 update
        ///			
        ///		7.	CtlJogControl.cs
        ///			�ʒu���䓮�쒆�ɖڕW���x���h0�h�ɐݒ肳�ꂽ��A
        ///			�����~�i�^�C�}��~�j���鏈����ǉ��B							//20160328 add
        /// 
        ///		8.	CtlJogControl.cs
        ///			�ʒu���䎞�ɖڕW���x���̓R���g���[���̕����𖳌����B
        ///			�ʒu���䎞�̖ڕW���x���Βl�ݒ�Ƃ���B						//20160328 add
        /// 
        ///		9.	JogControlForm.cs
        ///			�t�H�[�����[�h����ViewCultureResouceChanged()�ŁA
        ///			���䃂�[�h���h���䖳���h�ɋ����I�ɕύX����錏���C���B			//20160328 update
        /// 
        ///		10.	GainControlForm.cs
        ///			USB�ؒf��ԂŃQ�C���R���g���[���̒l��ύX������A
        ///			USB�ڑ���ɃQ�C���l���X�V����Ȃ������C���B						//20160328 update
        /// 
        ///		11.	AutoTuningAdjust.cs WizardForm.cs
        ///			�I�[�g�`���[�j���O�ݒ�ňړ��������Z�����ɁA
        ///			�ݒ�G���[�ƂȂ錏���C���B										//20160329 del
        /// 
        ///		12.	AutoTuningAdjust.cs
        ///			�����Q�C���������B
        ///			�x���g�@�\���ɏ����Q�C���A�Q�C���㏸��1/2�ݒ�B					//20160329 update
        #endregion
        ///     ����������VER.0.21�����[�X20160329����������
        #region VER.0.21
        ///		1.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�����Q�C���������B
        ///			�����Q�C���A�Q�C���㏸���̏����ݒ�l�ɁA
        ///			���׃C�i�[�V����Ƌ@�\���̃p�����[�^��ǉ��B
        ///			�C�i�[�V����5�{�܂ŌW��1�i�����Q�C���̂܂܁j�B
        ///			�@�\���ɌW���ύX�B�x���g�̂�0.5�D								//20160330 update
        /// 
        ///		2.	AutoTuningAdjust.cs
        ///			listInvalidNF<>�^�ύX�B<int>��<FFT_Member>
        ///			�m�b�`�t�B���^�č\����ɍēx�t�B���^�ݒ�\�Ƃ����B			//20160330 update
        /// 
        ///		3.	AutoTuningForm.cs WizardForm.cs
        ///			�e�B�[�`���O�Q�C���C���B
        ///			�e�B�[�`���O��ʋN�����{�C�i�[�V���厞�ɁA
        ///			�ى��������錏�̑΍�B											//20160330 update
        /// 
        ///		4.	AutoTuningAdjust.cs
        ///			�d���U�����o���ɑO��A�N�V�������m�b�`�t�B���^�ݒ�̏ꍇ�A
        ///			�m�b�`�t�B���^�č\���i�����j���Ē����ĊJ���鏈����ǉ��B		//20160330 update
        /// 
        ///		5.	AutoTuningAdjust.cs
        ///			�m�b�`�t�B���^�č\���������ɑ������̑΍�B
        ///			3��A���ōč\�������������ꍇ�́A�č\���𖳎�����B				//20160330 add
        /// 
        ///		6.	ParameterForm.cs
        ///			ID�F6�ԒʐM���x�ύX�o���Ȃ������C���B							//20160401 update
        /// 
        ///		7.	GainControlForm.cs
        ///			�ʒuFF��Max�l����L�C���B500%��100%�B							//20160404 update
        /// 
        ///		8.	DigitalOsilloForm.cs
        ///			�摜�ۑ��̃t�H�[�}�b�g���ʏC���B
        ///			saveFileDialog1.FilterIndex�̔��蕶���C���B						//20160404 update
        /// 
        ///		9.	ManualNavigatorForm.cs
        ///			�}�j���A��Navi�t�H�[���ǉ��B������ݒ�B
        ///			TAD8811�戵�������i���{��j�����N�ǉ��B							//20160404 add
        /// 
        ///		10.	WizardForm.cs
        ///			�I�[�g�`���[�j���O�E�B�U�[�h���玩�����C�␳�����^�u���폜�B	//20160404 del
        /// 
        ///		11.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			SetAutoTuningSq()�AClearAutoTuningSq()�ǉ��B					//20160405 update
        /// 
        ///		12.	AutoTuningForm.cs
        ///			ServoErrorCounter�ǉ��B
        ///			�I�[�g�`���[�j���O���̃T�[�{�I�t�댟�o�΍�B					//20160405 add
        /// 
        ///		13.	AutoTuningAdjust.cs
        ///			InitLoadGain()�������B
        ///			�e�B�[�`���O��̏����Q�C���œK���ׁ̈B							//20160405 update
        /// 
        ///		14.	AutoTuningAdjust.cs
        ///			�I�[�g�`���[�j���O�J�n���Ɉʒu�΍��G���[�͈͐ݒ��p�~�B
        ///			���[�U�[���ݒ肷��p�����[�^�ׁ̈B								//20160405 del
        /// 
        ///		15.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			���׃C�i�[�V������A�Q�C�������A���g���X�C�[�v�A�e�X�g�^�]
        ///			�J�n���̃T�[�{�I���������500msec�҂��ǉ��B
        ///			�u���[�L�t�����[�^�̉�����ԑ҂��Ή��B							//20160406 add
        ///			
        ///		16.	MainForm.cs CMonitor.cs AutoTuningForm.cs
        ///			���]���o����\�ǉ��B�i2X,4X,5X,8X�j								//20160406 update
        /// 
        ///		17.	AutoTuningForm.cs
        ///			���׃C�i�[�V����������1sec�҂��ǉ��B
        ///			�������̏���̕��׃C�i�[�V���l�����肵�Ȃ��ׁB				//20160406 add
        /// 
        ///		18.	DigitalOsilloForm.cs
        ///			�g���K�L���������A���^�C��FFT��L���Ƃ����B						//20160412 update
        /// 
        ///		19.	CtlPlotMenu.cs CtlBodePlot.cs
        ///			�c�[���o�[�ɕ`���~�@�\�ǉ��B									//20160412 add
        ///	
        ///		20.	AutoTuningForm.cs
        ///			���׃C�i�[�V�����菈���œK���B									//20160412 update
        /// 
        ///		21.	AutoTuningForm.cs FreqencySweepForm.cs
        ///			���g���X�C�[�v�����ǉ��B
        ///			���g���X�C�[�v�ݒ��ʒǉ��B									//20160412 update
        /// 
        ///		22.	CtlJogControl.cs Message.cs
        ///			���x�f�[�^�ύX����1000rpm�ȏ�̕ύX�Ȃ�
        ///			���Ӄ��b�Z�[�W���o�́B											//20160413 add
        /// 
        ///		23.	JogControlForm.cs
        ///			���䃂�[�h�ɊȈՃv���O�������[�h�ǉ��B							//20160413 add
        /// 
        ///		24.	ParameterForm.cs
        ///			ID120�Ԍ�L�C���B
        ///			�i��j01�F�������p���X�{�������p���X���[�h
        ///			�i���j01�F�p���X�{��]�������[�h								//20160414 update
        /// 
        ///		25.	TeachingForm.cs
        ///			�e�B�[�`���O�������ɃT�[�{�I�t�v�����b�Z�[�W�ǉ��B
        ///			���x���䂩��ʒu����؂�ւ�̐U���΍�B						//20160418 update
        /// 
        ///		26.	ParameterForm.cs
        ///			�p�����[�^�����X�V�����������l�ŗL���Ƃ����BUI����B			//20160420 update							
        /// 
        ///		27.	WizardForm.cs
        ///			�ڕW���x�A�ڕW�������ݒ莞�ɉ��������Ԃ̕\����ǉ��BUI����B	//20160420 update
        /// 
        ///		28.	CtlJogControl.cs
        ///			���x���䎞�Ɍ��݈ʒu�e�B�[�`���O�@�\�ǉ��B						//20160420 update
        #endregion
        ///     ����������VER.0.22�����[�X20160421����������
        #region VER.0.22
        ///		1.	AboutBox.cs
        ///			���x���T�C�Y���s���BAutoSize�v���p�e�B��Ture�ցB				//20160420 update
        /// 
        ///		2.	GainControlForm.cs
        ///			�m�b�`�t�B���^2���g���̒P�ʃe�L�X�g�̕\���s���B
        ///			resources.GetObject()�C���B										//20160422 update
        /// 
        ///		3.	CtlJogControl.cs
        ///			�ʒu���߃��[�h���h���Έʒu�h������̐ݒ�ɕύX�B
        ///			���S�m�ۂ̂��߁A��Έʒu���Ɓh0�h�̈ʒu�֓��삵�Ă��܂��B		//20160425 update
        /// 
        ///		4.	JogControlForm.cs
        ///			�d������؂�ւ����̃T�[�{�I�t���s�����R��B					//20160426 update
        /// 
        ///		5.	CtlBodePlot.cs
        ///			FFT��ʂɃN�C�b�N���j�^�[�@�\�ǉ��B								//20160427 update
        /// 
        ///		6.	DigitalOsilloForm.cs
        ///			FormLoad�C�x���g���ViewCultureResouceChanged()�����C���B
        ///			�J���`���[�ύX���̂ݎ��s�B
        /// �@�@�@�@���\�[�X�p�����[�^���R���{�ݒ�ɔ��f����Ȃ��ׁB				//20160427 update
        /// 
        ///		7.	CUsb.cs
        ///			USB R/W������CDC�f�o�C�X�ڑ��`�F�b�N�ǉ��B
        ///			USB�P�[�u���ؒf���̃A�v���P�[�V�����G���[�΍�B					//20160427 add
        /// 
        ///		8.	AutoTuningForm.cs TuningControlForm.cs
        ///			�ʃ`���[�j���O�@�\�ǉ��B										//20160427 add
        /// 
        ///		9.	MainForm.cs CMonitro.cs AutoTuningForm.cs
        ///			�Ȑ�INC2500�Ή��B												//20160509 add
        /// 
        ///		10. TuningControlForm.cs AutoTuningForm.cs
        ///			 FrictionControlForm.cs�ǉ��B
        ///			�ʃ`���[�j���O�ɖ��C�␳�@�\�ǉ��B							//20160510 add
        /// 
        ///		11.	AutoTuningAdjust.cs
        ///			�I�[�g�`���[�j���O�������FFT�\����~�����ǉ��B					//20160510 add
        #endregion
        ///     ����������VER.0.23�����[�X20160510����������
        #region VER.0.23
        ///		1.	TuningControlForm.cs FreqencySweepForm.cs
        ///			�t�H�[�������񒆕��Ή��B										//20160511 update
        /// 
        ///		2.	MainForm.cs
        ///			�Ȑ�INC�G���R�[�_�̕���\�����f����Ȃ������C���B				//20160513 update
        #endregion
        ///     ����������VER.0.24�����[�X20160513����������
        #region VER.0.24
        ///		1.	AutoTuningForm.cs
        ///			�Ȑ�INC�G���R�[�_�̕���\�����f����Ȃ������C���B				//20160513 update
        /// 
        ///		2.	CUsb.cs
        ///			USB�P�[�u���ؒf���̃A�v���P�[�V�����G���[�΍􋭉��B				//20160513 update
        #endregion
        ///     ����������VER.0.25�����[�X20160513����������
        #region VER.0.25
        ///		1.	IoMonitorForm.cs ServoMonitorForm.cs
        ///			���j�^�[�R���g���[���ǉ��B										//20160516 add
        ///			
        ///		2.	Message.cs
        ///			ChildFormControl�N���X�ǉ��B	
        ///			Dialog�N��������ChildForm�̕\���E��\�������ǉ��B
        ///			��L�ɔ����v���W�F�N�g�t�H���_���𐮗��B						//20160517 update
        /// 
        ///		3.	CUsb.cs
        ///			ReadFile() WriteFile()
        ///			��O������UnInitUsb()���폜�B									//20160525 update
        /// 
        ///		4.	DigitalOsilloForm.cs
        ///			���O�擾���Ԃ̃p�����[�^��ǉ��B
        ///			�g�`�\����~���Ɍo�ߎ��ԕ\����ǉ��{
        ///			�p�l�����T�C�Y�C�x���g���̕\�����œK���{
        ///			�g�`�`��ʒu�i�ڐ����j�œK���B									//20160526 add
        /// 
        ///		5.	CtlJogControl.cs
        ///			�������쎞�̍ŏ��҂����ԏC���B
        ///			100��500msec													//20160526 update
        /// 
        ///		6.	OptionSettingDialog.cs
        ///			�ʐM�����̃p�����[�^��ǉ��B���\�[�X���B						//20160526 add
        ///			
        ///		7.	OptionSettingDialog.cs
        ///			OK,Cancel�{�^���ǉ��B
        ///			OK�{�^���Őݒ�ύX���f�ACancel�{�^���Ŗ����̏�����ǉ��B		//20160527 update
        ///			
        ///		8.	OptionsettingDialog.cs
        ///			���O�����̃p�����[�^�ǉ��B���\�[�X���B							//20160527 add
        /// 
        ///		9.	MainForm.cs DigitalOsilloForm.cs AutoTuningForm.cs
        ///			AutoTuningAdjust.cs FFT_IF.cs BodeGraphForm.cs
        ///			���O�����ύX�ɔ����A
        ///			�`�揈���A�`���[�j���O���菈�������C���B						//20160527 update
        ///		
        ///		10.	BodeGraphForm.cs
        ///			�h��~�h�{�^�����h�g�`�\����~�h�{�^���֖��̋y�єz�u�ύX�B
        ///			�I�[�g�`���[�j���O����Enable�����ǉ��B
        ///			�c�[���o�[�̃t�H�[���A�N�e�B�u�����ǉ��B						//20160530 update
        /// 
        ///		11.	MainForm.cs ViewMainForm.cs AutoTuningForm.cs
        ///			�I�[�g�`���[�j���O���̏I�������ŁA
        ///			�`���[�j���O���~���b�Z�[�W��ǉ��B								//20160530 update
        /// 
        ///		12.	AutoTuningAdjust.cs
        ///			UserParameter.InertiaRatio�ɍŏ��l���菈���ǉ��B
        /// �@�@�@�@�e�L�X�g�o�͗p��UserParameter.InertiaRatioReal�ǉ��B			//20160530 update
        /// 
        ///		13.	DigitalOsilloForm.cs
        ///			�g���K���̌v�����̕`��ƃg���KON�EOFF�؂�ւ������ŁA
        ///			�f�[�^�����������ǉ��B�`�揈�����œK���B						//20160530 update
        /// 
        ///		14.	GainControlForm.cs
        ///			Kv�ő�l�g���B3000��9999�B
        ///			Ki�ő�l�g���B1000��3000�B										//20160530 update
        ///
        ///		15.	AutoTuningForm.cs
        ///			���C�i�[�V���W���ύX�B5%��2%�B									//20160530 update
        /// 
        ///		16.	DigtalOsilloForm.cs MainForm.cs AutoTuningAdjust.cs
        ///			FFT�f�[�^�擾�O��̎��ԂɃ��O�����iLogPeriod)�𔽉f�B
        ///			FFT�`�搔��FFT_C�N���X�Ƀp�����[�^���B							//20160530 update
        /// 
        ///		17.	AutoTuningAdjust.cs
        ///			FFT�`�惍�O�����ϑΉ��ׁ̈A�o�b�t�@�����������ǉ��B			//20160531 add
        /// 
        ///		18.	CtlJogControl.cs
        ///			�v���O�������[�h����ʒu�E���x�E�d������؂�ւ����A
        ///			���]�E�t�]�E��~�{�^�����g�p�s��Ԃ��C���B					//20160531 update
        /// 
        ///		19.	CtlPlotMenu.cs CtlBodePlot.cs
        ///			�v���o�[�ǉ��B													//20160531 add
        /// 
        ///		20.	FFT_IF.cs AutoTuningAdjust.cs
        ///			���O����2msec�A4msec�I�[�g�`���[�j���O�Ή��B
        ///			FFT���o���x�����𒲐��B											//20160601 update
        /// 
        ///		21.	GainControlForm.cs
        ///			���f���Ǐ]����^�u�폜�B										//20160602 update
        /// 
        ///		22.	MainForm.cs
        ///			Drive�I�����̃T�[�{�I����Ԓ��Ӄ��b�Z�[�W�ǉ��B
        ///			�T�[�{�I�t���邩�̑I������ǉ��B								//20160606 add
        /// 
        ///		23.	ManualNavi.cs
        ///			Drive�\�t�g�E�F�A�}�j���A���ǉ��B								//20160606 add
        #endregion
        ///     ����������VER.0.30�����[�X20160606����������
        #region VER.0.30
        ///		1.	frmBasicProgramOperations.cs��
        ///			�ȈՃv���O�����ڐA�B											//20160712 add
        /// 
        ///		2.	CtlJogControl.cs AutoTuningForm.cs
        ///			UpdateAccDccTime()��FormLoad_Event()�ɒǉ��B					//20160714 update
        /// 
        ///		3.	Form
        ///			Form�e�L�X�g���p�����B											//20160714 update
        /// 
        ///		4.	Mesage.cs
        ///			�p�����Ή��B													//20160715 update
        /// 
        ///		5.	CtlJogControl.cs
        ///			�A���[���������AJogStop()�����ǉ��B								//20160715 update
        /// 
        ///		6.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�I�[�g�`���[�j���O���s���Ɏ����쒆���菈����ǉ��B
        ///			CheckTheOtherSequence()�ǉ��B
        ///			�������쒆���菈���͍폜�B
        ///			����ʂ������삳����̂�������Ȃ��B							//20160719 add
        #endregion
        ///     ����������VER.0.31�����[�X20160719����������
        #region VER.0.31
        ///		1.	DigitalOsilloForm.cs
        ///			���A���^�C��FFT���f�W�^���I�V���g�`��~����
        ///			�f�W�^���I�V���̔g�`���X�V����Ă��܂������C���B				//20160722 update
        ///
        ///		2.	AutoTuningAdjust.cs
        ///			StartAutoTuning()�Ń��O�f�[�^���I�[�g�`���[�j���O�p�ɍĐݒ�B
        ///			�i�ʒu�΍��A���j�^���x�A���j�^�d���j							//20160726 update
        ///
        ///		3.	FirmwareUpgradeDialog.cs
        ///			DfuSeCommand.exe���Ǘ��Ҍ����Ŏ��s�B
        ///			dfu�t�@�C����ProgramFiles(x86)����User\\AppData\\Local��
        ///			�R�s�[���Ă�����s����悤�ɕύX�B								//20160726 update
        /// 
        ///		4.	AutoTuningAdjust.cs
        ///			�U�����o��̏����Q�C���ď������ŁA
        ///			���[�p�X�t�B���^�������R��B									//20160907 update
        /// 
        ///		5.	Form��
        ///			TRI����p���w�E�����𔽉f�B										//20160907 update
        /// 
        ///		6.	MainForm.cs CtlJogControl.cs
        ///			���䃂�[�h���ȈՃR���g���[�����[�h����
        ///			�T�[�{�I���@�\�֎~�A�I�[�g�`���[�j���O�@�\�֎~�����ǉ��B		//20160908 update
        ///
        #endregion
        ///     ����������VER.0.32�����[�X20160908����������
        #region VER.0.32
        ///		1.	AutoTuningAdjust.cs
        ///			CheckTheCurrentVibration()
        ///			�����Q�C���Ē������̃Q�C���㏸���ď������s���̂��ߏC���B		//20160926 update
        /// 
        ///		2.	frmBasicProgramOperation2.cs
        ///			Help�{�^�����̕ύX�B���{��A�������ʂ�Help��HELP�B			//20160926 update
        /// 
        ///		3.	MainForm.cs TimerMain_Tick()
        ///			�N����̃��C�A�E�g�I����ʂŃL�����Z�����ɃG���[�����B
        ///			AutoTuningForm��EnableUpadate���菈����ǉ��B					//20160926 update
        ///			
        ///		4.	DigitalOsilloForm.cs
        ///			�g�`�\���S�ʓI�ɋ@�\�����B										//20161004 update
        /// 
        ///		5.	MainForm.cs JogControlForm.cs
        ///			�v���O�������[�h�i�v���O�������s��ԁj����A
        ///			�����䃂�[�h�ւ̐؂�ւ����ɁA�T�[�{�I�����錏���C���B
        ///			���C���c�[���o�[�̃I�[�g�`���[�j���O�{�^���A
        ///			Enable/Disable�������C���B										//20161005 update
        /// 
        ///		6.	�S�t�H�[���̃c�[���o�[
        ///			LayoutStyle��StackOverflow����Flow�֕ύX�B						//20161006 update
        /// 
        ///		7.	DigitalOsilloForm.cs
        ///			���O���ڂɃ��f���Ǐ]���䃂�j�^�ǉ��B�i�ʒu�E���x�E�d���j		//20161012 add
        ///		
        ///		8.	ParameterForm.cs
        ///			�p�����[�^�S�������ݎ��Ƀv���O���X�o�[�������Ȃ������C���B		//20161013 update
        ///		
        #endregion
        ///     ����������VER.0.33�����[�X20161013����������
        #region VER.0.33
        /// 
        ///		1.	ParameterForm.cs
        ///			���{��p�����^Help������ŐV�łɍX�V�B							//20161019 update
        /// 
        ///		2.	MainFrom.cs
        ///			PC�̃X�^���o�C�A�x�~��ԃT�|�[�g�B
        ///			�X�^���o�C�A�x�~��Ԓ���USB�̐ؒf������ǉ��B
        ///			���A���͓��ɉ������Ȃ��BMainTimer����USB���ڑ������B			//20161031 add
        /// 
        ///		3.	JogControlForm.cs CtlJogControl.cs
        ///			AutoTuningForm.cs AutoTuningAdjust.cs
        ///			Public���\�b�hJogStop()�֐���ǉ��B
        ///			�I�[�g�`���[�j���O���s����JogStop()��Call�B						//20161031 add
        /// 
        ///		4.	MainForm.cs
        ///			DriverModel�ADriverRevision�v���p�e�B��ǉ��B					//20161031 add
        /// 
        ///		5.	MainForm.cs GainControlForm.cs
        ///			AutoTuningAdjust.cs AutoTuningForm.cs
        ///			�Q�C���R���g���[���y�уI�[�g�`���[�j����
        ///			���x�t�B�[�h�o�b�N�f�[�^�̐؂�ւ��B
        ///			���o�[�W�����͑��x�t�B�[�h�o�b�N�t�B���^���ړ����ρB
        ///			�V�o�[�W�����͑��x�t�B�[�h�o�b�N�t�B���^��1��IIR_LPF�B
        ///			�����ȃo�[�W�����̓h���C�o�{�̃\�t�g�X�V��Ɋm�肷��B			//20161031 update
        /// 
        ///		6.	PrameterForm.cs
        ///			bRead()����CMonitor.SetParameter()�����C���B
        /// 
        ///		7.	MainForm.cs ParameterForm.cs DigitalOsilloForm.cs
        ///			Winodws OS Version�`�F�b�N�ǉ��B
        ///			Winodws7������OS�́A
        ///			�I�[�g�`���[�j���O�A�f�W�^���I�V���AFFT���֎~�B					//20161102 update
        /// 
        ///		8.	OptionSettingDialog.cs ParameterForm.cs
        ///			�p�X���[�h�ǉ��B�i���\�[�X�ǉ��j
        ///			55555�@�@�@ �ꎞ����
        ///			5555555555�@�i�v����
        ///			�p�X���[�h�����ƍēx���b�N�����B							//20161102 add
        /// 
        ///		9.	FirmwareUpgradeDialog.cs
        ///			�e�L�X�g�u�����N����A�{�^���������̏��C���B					//20161107 update
        /// 
        ///		10.	MainForm.cs frmBasicProgramOperation2.cs
        ///			�v���O�������s���̏I���������C���B								//20161108 update
        /// 
        ///		11.	MainForm.cs CUsb.cs AutoTuningFom.cs CtlJogControl.cs
        ///			USB��O�����S�ʓI�Ɍ������B
        ///			Windows���f�o�C�X��؂藣�����[�h�́A
        ///			devcon.exe���g�p���ăf�o�C�X�̗L���E����������ǉ��B
        ///			�h���C�o����~���郂�[�h�́AS�R�}���h��ǉ��B
        ///			USB�ڑ����ƃ��g���C������S�R�}���h���s�B
        ///			�h���C�o��~���[�h�ŁACOM�f�o�C�X���F�����Ă����ԂŁA
        ///			�A�v���P�[�V������~�i��~���Ԓ����j���錏�́A
        ///			COM��Open�AClose�������X���b�h���B
        ///			COM��Dispose�����͔O�̂��ߔp�~�B
        ///			���o�[�W������Dispose�����ŗ�O�������Ă����ׁB
        ///			�I�[�g�`���[�j���O�y�уW���O�A������ŁA
        ///			USB�ؒf�����œ����~���錏�́A
        ///			IsUsbWait�t���O��ǉ����ĉ������鏈����ǉ��B					//20161115 update
        /// 
        ///		12.	CtlJogControl.cs
        ///			�A���[����������JogStop()����AServoCommand�S�N���A�ɕύX�B
        ///			�A���[����������JogStop()������SmoothStop�r�b�g��ON���邽�߁A
        ///			�p���X�w�߃��[�h�ŃA���[��������ɓ���o���Ȃ������C���B		//20161118 update
        /// 
        ///		13.	ManualNavigatorForm.cs
        ///			Drive_SoftwareManual_US�Ή��B
        /// 
        ///		14.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�U�����o�ݒ�ǉ��Btuning_config.txt�C���B						//20161124 update
        #endregion
        ///     ����������VER.0.40�����[�X20161125����������
        #region VER.0.40
        /// 
        ///		1.	AutoTuningForm.cs
        ///			Wizard������ɉ��������Ԃ��X�V����Ȃ������C���B				//20161202 update
        /// 
        ///		2.	DigitalOsilloForm.cs
        ///			���Ԍv���A�g���K�ʒu�̎��Ԏ��`��Y���C���B						//20161202 update
        /// 
        ///		3.	AutoTuningAdjust.cs
        ///			�T�[�{�p�����[�^ TAD88xx Ver.5.20�Ή��B							//20161202 update
        /// 
        ///		4.	frmBasicProgramOperation2.cs
        ///			�h���C�o�����v���O��������̏�ԂŁA
        ///			CurrentStepNo�APrevStepNo���s���ɂȂ錏���C���B					//20161202 update
        /// 
        ///		5.	AutoTuningAdjust.cs
        ///			�X���[�����[�V�����i�����斳���j�̃I�[�g�`���[�j���O�Ή��B		//20161202 update
        ///			
        ///		6.	AutoTuningAdjust.cs
        ///			�`���[�j���O�p�����[�^�C���B
        ///			17B���x�t�B�[�h�o�b�N�@600��1000
        ///			17B�d�����[�p�X�t�B���^�@0��2000�i�A�����xOBS�L������0�j
        ///			�ϕ��Q�C���ő�l�����B											//20161202 update
        /// 
        ///		7.	FirmwareUpgradeDialog.cs CUsb.cs
        ///			�O��exe�N�������C���B
        ///			C:\\Users\\User\\AppData\\Local\\Drive �ȉ��ɊO��exe��z�u�B	//20161205 update
        ///			
        ///		8.	AutoTuningAdjust.cs
        ///			MeasureLogData()
        ///			�h���C�o�p�����[�^ID256�ԁA���������ԁiID34�AID35�j
        ///			�X�P�[���i10�{�A100�{�j�Ή��B
        ///			�I�[�g�`���[�j���O�̕΍����ꔻ��J�n�ʒu���s���ɂȂ錏���C���B	//20161205 update
        #endregion
        ///     ����������VER.0.41�����[�X20161206����������
        #region VER.0.41
        /// 
        ///		1.	ParameterForm.cs
        ///			�p�����[�^�w���v�p�����B
        ///			�p�����[�^�w���v���{�ꌩ�����B									//20170116 update
        /// 
        ///		2.	ManualNavigatorForm.cs
        ///			�戵�������p��Œǉ��B���{��ōX�V�B
        ///			�ȈՃR���g���[������}�j���A���ǉ��B���{��ł̂݁B				//20170116 update
        ///			
        ///		3.	ParameterForm.cs
        ///			�p�����[�^�t�@�C���ۑ����̌��ݒl�ǂݍ��݃`�F�b�N���A
        ///			�擪�s�݂̂���S�Ă̍s�ɕύX�B									//20170123 update
        /// 
        ///		4.	ParameterForm.cs DigitalOsilloForm.cs
        ///			�t�@�C���ۑ��y�ъJ�������̏����f�B���N�g���L�������ǉ��B		//20170123 update
        /// 
        ///		5.	ParameterForm.cs
        ///			ID360�AID361�`���[�j���O�t���[�@�\�p�����[�^HELP�ǉ��B
        ///			���{��̂݁B													//20170123 update
        /// 
        ///		6.	CUsb.cs MainForm.cs DigitalOsilloForm.cs ParameterForm.cs
        ///			CUsb.cs�f�o�C�X�}�l�[�W���[�Ď��X���b�h��~�����ǉ��B
        ///			��ɃX���b�h�N����Ԃ̏ꍇ�AWinodwsXP��ᐫ�\PC�ŁA
        ///			USB�ʐM���x���Ȃ�i�҂���ԁj���ߕK�v�Ȏ������N������B
        ///			�X���b�h�����œK���ɂ��AWinodws7���菈���폜�B				//20170123 update
        ///			
        ///		7.	FirmwareUpgradeDialog.cs
        ///			DFU�I�����C���A�b�v�f�[�g Windows Xp�Ή��B						//20170125 update
        ///			
        ///		8.	frmBasicProgramOperation2.cs
        ///			���s���X�e�b�v�n�C���C�g�\���N���A�@�\�ǉ��B
        ///			�^�]�J�n�A�_�E�����[�h�A�A�b�v���[�h�D�D�Detc					//20170125 update
        /// 
        ///		9.	Drive
        ///			�g���K�ʒu�A�I�V�������k�ځA�A�v���P�[�V�����ݒ�œK���B		//20170125 update
        ///	
        ///		10.	OptionSettingDialog.cs DigitalOsilloForm.cs
        ///			�A�v���P�[�V������������Ƀf�W�^���I�V���Đݒ菈���ǉ��B		//20170125 update
        /// 
        ///		11.	MainForm.cs ViewMainForm.cs IoMonitorForm.cs ServoMonitorForm.cs
        ///			ViewMainForm�ɃT�[�{���j�^�[��IO���j�^�[���x����ǉ��B			//20170125 add
        /// 
        ///		12.	AutoTuningForm.cs
        ///			���[�U�[�Ɋ֌W�Ȃ��ݒ�ׁ̈A�`���[�j���O�p�����[�^�\��OFF�B
        ///			�p�X���[�h�����ŕ\��ON�B										//20170125 update
        ///			
        #endregion
        ///     ����������VER.0.50�����[�X20170124����������
        #region VER.0.50
        /// 
        ///		1.	OpenDriveForm.cs
        ///			�k�����C�A�E�g�v���p�e�B���f�R��B								//20170126 update
        /// 
        ///		2.	MainForm.cs
        ///			�k�����C�A�E�g���Ƀ��j���[�e�L�X�g�ύX�B
        ///			�W���O�R���g���[�����W���O�B
        ///			�I�[�g�`���[�j���O���`���[�j���O�B								//21070126 update
        /// 
        ///		3.	CUsb.cs
        ///			USB�ؒf���̃f�o�C�X�}�l�[�W���[�����X���b�h���œK���B
        ///			��X�y�b�NPC���ƕ��ׂ��d���ׁA
        ///			�������[�v�ł͂Ȃ����������Ɏ��s����悤�ɏC���B				//20170126 update
        /// 
        ///		4.	AutoTuningForm.cs
        ///			�I�[�g�`���[�j���O����USB�ʐM�ؒf���菈���ύX�B
        ///			USB�ʐM�f����10�b�ԉ񕜑҂��BTAD8810�΍�B						//20170127 update
        /// 
        ///		5.	AutoTuningAdjust.cs
        ///			�m�b�`�t�B���^�ݒ�ς݂���Kvp�ݒ���E�ŁA
        ///			�`���[�j���O���x����Kvp*�W���̃��[���o�b�N�������C���B
        ///			�����Ⴂ�@�B�̏ꍇ�A�ŏ���Kvp�����㏸����ꍇ�����邽�߁A
        ///			���[���o�b�N�ŏ����Q�C���܂Ŗ߂��Ă��܂��B						//20170127 update
        /// 
        ///		6.	AutoTuningAdjust.cs
        ///			EnableUpKvi()
        ///			�I�[�o�[�V���[�g������폜�B�����Q�C���ŃQ�C�����Ⴂ�ꍇ�ɁA
        ///			�I�[�o�[�V���[�g�����������ɐϕ��Q�C�����オ��Ȃ����̑΍�B
        ///			���Q�C���ŃI�[�o�[�V���[�g���͐ϕ��Q�C�����グ�Ȃ��B
        ///			��Q�C���ŃI�[�o�[�V���[�g���͐ϕ��Q�C�����グ��B				//20170130 updata
        /// 
        ///		7.	AutoTuningAdjust.cs
        ///			�U�����o��̃��[���o�b�N�����O�ɐU�����o�X�e�[�^�X����ǉ��B	//20170131 update
        /// 
        ///		8.	AutoTuningForm.cs
        ///			USB�ؒf���̕��׃C�i�[�V�����菈���C���B							//20170131 update
        /// 
        ///		9.	AutoTuningAdjust.cs
        ///			�`���[�j���O�p�����[�^�ǉ��B�����I�[�o�[�V���[�g���ԁB
        ///			�����I�[�o�[�V���[�g�͐ϕ��Q�C���㏸�֎~�B
        ///			�x���I�[�o�[�V���[�g�͐ϕ��Q�C���㏸���B
        ///			�����I�[�o�[�V���[�g���莞�Ԃ̏����l��100msec					//20170131 update
        /// 
        ///		10.	CUsb.cs MainForm.cs
        ///			USB�ؒf���̉񕜏����ǉ��BTA8810�΍�B
        ///			COM�I�[�v�����USB�ʐM�m�F���G���[�Ȃ�Devcon�����ǉ��B
        ///			���̑��A�ʐM���������A�s�v�ȏ����폜�B							//20170201 update
        ///			
        #endregion
        ///     ����������VER.0.60�����[�X20170202����������
        #region VER.0.60
        ///		
        #endregion
        ///		����������VER.1.00�����[�X20170209����������
        #region VER.1.00
        ///
        ///		1.	AutoTuningForm.cs
        ///			�I�[�g�`���[�j���O�����ݒ�ύX�B
        ///			�@�B�F�x���g�@���x���艻�F����									//20170210 update
        /// 
        ///		2.	WizardDialog.cs
        ///			���x���艻����̒��L��ǉ��B
        ///			���x�v�Z���x����E�E�E
        ///			���{��A�p��A������B											//20170213 update
        /// 
        ///		3.	CUsb.cs StartComClose()
        ///			USB�P�[�u���ؒf���ɃA�v���P�[�V�����G���[�ƂȂ錏�B
        ///			ComClose()�O�Ƀo�b�t�@�[�N���A�����ǉ��B
        ///			ComClose()�O�Ƀo�b�t�@�[�N���A�����ǉ��B
        ///			ThreadSerchCDC.Abort()�����C���B
        ///			ComOpen�y��ComClose�������X���b�h���B
        ///			UsbWrite�y��UsbRead������CUsb��null����ǉ��B					//20170210_13 update
        ///			
        #endregion
        ///     ����������VER.1.01�����[�X20170213����������
        #region VER.1.01
        ///			
        ///		1.	ProfileMovementTableForm.cs
        ///			�ȈՃv���O�����ʒu���߃e�[�u���@�\�ǉ��B						//20170215 add
        /// 
        ///		2.	frmBasicProgramOperation2.cs OptionSettingDialog.cs
        ///			�ȈՃv���O�����ʒu���߃e�[�u���Ή��B
        ///			�p�X���[�h�hTRI�h�ňʒu���߃e�[�u���\���L���B					//20170215 add
        /// 
        #endregion
        ///     ����������VER.1.02�����[�X20170215����������
        #region VER.1.02
        ///
        ///		1.	AutoTuningForm.cs
        ///			���׃C�i�[�V������MIN���x�ύX�B
        ///			100rpm��20rpm�B	�~�Ս��C�i�[�V�����댯�B						//20170215 update
        ///		
        ///		2.	CtlNumericUpDown.cs
        ///			btnUp_Click() btnDown_Click()���A
        ///			btnUp_MouseClick() btnDown_MouseClick()�C�x���g�֕ύX�B
        ///			Enter�L�[�ASpace�L�[�Ő��l���ύX����錏���C���B				//20170215 update
        /// 
        ///		3.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�ʒu�΍��G���[���o�p���X�A�_�C�i�~�b�N�u���[�L�쓮�������A
        ///			�`���[�j���O�O�ɐݒ肵�`���[�j���O������Ɍ��̐ݒ�ɖ߂��B
        ///			�ʒu�΍��G���[���o�p���X�̓G���R�[�_����\�~10�B
        ///			�_�C�i�~�b�N�u���[�L�쓮�����̓A���[���ŗL���B					//20170215 update
        /// 
        ///		4.	ProfileMovementTableForm.cs
        ///			�ʒu���߃e�[�u���\���̎���AutoTuningForm��Disable�B				//20170216 update
        /// 
        ///		5.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�`���[�j���O���̈ʒu���ߊJ�n�ʒu��
        ///			FeedbackPosition����CommandPosition�֕ύX�B						//20170215 update
        /// 
        ///		6.	AutoTuningAdjust.cs
        ///			�����Q�C���������Ƀm�b�`�t�B���^���ݒ肳�ꂽ�ꍇ�A
        ///			FFT�����l���Đݒ肷��悤�ɃV�[�P���X��ύX�B					//20170217 update
        /// 
        ///		7.	AutoTuningForm.cs
        ///			USB�ؒf����10�b����3�b�֏C���B									//20170217 update
        /// 
        ///		8.	AutoTuningForm.cs
        ///			���׃C�i�[�V�����莞�̈ʒu�΍��G���[臒l���C���B
        ///			�G���R�[�_����\�~10����~1�ցB									//20170217 update
        ///		
        #endregion
        ///     ����������VER.1.03�����[�X20170220����������
        #region VER.1.03
        ///		
        ///		1.	ParameterForm.cs
        ///			�t�@�C���ۑ��O�ɑS�p�����[�^�ǂݍ��ݏ����ǉ��B					//20170221 update
        ///		
        ///		2.	GainControlForm.cs
        ///			�^�u�I�[�_�[�C���B												//20170222 update
        /// 
        ///		3.	MainForm.cs��
        ///			�k�����C�A�E�g�T�C�Y�������B350��300�B
        ///			���t�H�[���̃��j���[�w�i�F���������B							//20170222 update
        /// 
        ///		4.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			���[�p���t�B���^�֘A�̑��x�I�u�U�[�o�L�����̐ݒ�ǉ��B			//20170222 update
        ///		
        #endregion
        ///     ����������VER.1.04�����[�X20170222����������
        #region VER.1.04
        /// 
        ///		1.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�`���[�j���O���̈ʒu���ߊJ�n�ʒu��
        ///			CommandPosition����FeedbackPosition�֕ύX�B						//20170222 update
        /// 
        ///		2.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			�@�B�^�C�v�̕\���ύX�B
        ///			�������A�������A�ፄ���ցB										//20170223 update
        /// 
        #endregion
        ///     ����������VER.1.05�����[�X20170224����������
        #region VER.1.05
        /// 
        ///		1.	ParameterForm.cs
        ///			�p�����[�^�S�������݌�Ɏ����X�V�������񕜂��鏈����ǉ��B		//20170309 update
        /// 
        #endregion
        ///		����������VER.1.10�����[�X20170315����������
        #region VER.1.10
        ///
        ///		1.	CUsb.cs
        ///			Windows 10 �Ή��̂��߁A�f�o�C�X�}�l�[�W���[�̌��������ƁA
        ///			USB�ؒf�����iCOM Close�j���������B
        /// 
        #endregion
        ///     ����������VER.1.11�����[�X20170321����������
        #region VER.1.11
        ///
        /// 	1.	CCommandTx.cs
        ///			���O�擾�̍Ō�i���O30����=�����O�o�b�t�@�ŏI�j�̏ꍇ��,
        ///			���O����1���Ȃ��i������j�����C���B
        ///			�{�̃\�t�g���C������̂���������Drive�����C�����Ă���薳���B
        ///			�A���A�{�̑��������������ɂȂ����ꍇ�͒��ӂ��K�v�B
        ///			�o�[�W�����{�`���ŊǗ�����K�v������B							//20170711 update
        ///
        ///		2.	CtlJogControl.cs
        ///			JogCtrl()
        ///			PTP����J�n��Ɉړ�������0����ύX�i�ړ��L��j�ɂ����ꍇ�ɁA
        ///			���삷�錏���C���B�ړ�������0�̏ꍇPTP������I�������ǉ��B		//20170711 update
        /// 
        ///		3.	CtlJogControl.cs
        ///			JogCtrl()
        ///			�A���[���܂��̓��~�b�g���o�����ꍇ��PTP������I�������ǉ��B		//20170711 update
        /// 
        ///		4.	CUsb.cs
        ///			DevCon.exe�p�~�B
        ///			����USB�ʐM�͈���B�����I�ɔp�~���Ă݂�B						//20170711 update
        ///			
        #endregion
        ///     ����������VER.1.12�����[�X20170711����������
        #region VER.1.12
        /// 
        ///		1.	DigitalOsilloForm.cs
        ///			HoldEvent()
        ///			�A���g�`�Đ�����LogPtr=0��ǉ��B
        ///			��~���g�`�̑�������Đ�����悤�C���B�g�`�̌����ډ��P�B		//20170802 update
        /// 
        ///		2.	DigitalOsilloForm.cs
        ///			DrawWaveLine()
        ///			�`�����i�㉡���j�`��ʒu�œK���B�����ډ��P�B				//20170809 update
        /// 
        ///		3.	DigitalOsilloForm.cs
        ///			DrawWaveOscillo() HoldEvent() UpdateHoldView()
        ///			�A���g�`�Đ��E�g�`��~���̕`��G���A�œK���B
        ///			�Đ��E��~�Ɋւ�炸�A�`��T�C�Y�����Ƃ����B
        ///			�����X�N���[���o�[�͏�ɕ\������悤�ɕύX���A
        ///			�g�`�Đ����FDisable�A�g�`��~���FEnable�Ƃ����B					//20170809 update
        ///			
        ///		4.	DigitalOsilloForm.cs
        ///			DrawWaveOscillo()
        ///			�c���g�厞�ɕ`��͈͂���g�`���͂ݏo�錏���C���B				//20170809 update
        /// 
        ///		5.	DigitalOsilloForm.cs
        ///			VerticalZoom()
        ///			Y_Div���~�b�g����Properties.Settings.Default.WAVE_YScale��
        ///			�ۑ�����Ȃ������C���B											//20170809 update
        /// 
        ///		6.	DigitalOsilloForm.cs
        ///			DrawWaveOscillo() TimeMeasDraw()
        ///			�g�`���ڂ̒P��[]���̃X�y�[�X�폜�B
        ///			�g�`��~���̎��ԕ\���̃t�H���g�T�C�Y�ύX�B
        ///			�g�`�`��G���A�̉����I�t�Z�b�g�œK���B�i�ʒu���l�߂��j
        ///			�ʒu�A�p�����^1-3�̍��ڕ\���ʒu�œK���B
        ///			�g�`�`��G���A�̏㑤�I�t�Z�b�g�ǉ��B							//20170810 update
        /// 
        ///		7.	AutoTuningForm.cs AutoTuningAdjust.cs
        ///			BackupOtherParameter()�ǉ��B
        ///			���׃C�i�[�V������A�Q�C�������A���g���X�C�[�v�O�ɁA
        ///			�ʒu�E���x�w�ߑI���̓��e�𔻒肷�鏈����ǉ��B
        ///			���̑��̕ۑ��p�����[�^��BackupOtherParameter()�ɐ����B			//20170822 update
        ///		
        ///		8.	DigitalOsilloForm.cs
        ///			LogTimeValueChanged() BackupLogLength �ǉ��B
        ///			�ۑ��������O�f�[�^�̒�����Drive���O�f�[�^�������قȂ�ꍇ�ɁA
        /// 		���������O�f�[�^��ǂݍ��߂Ȃ������C���B
        ///			USB���ڑ���ԂŃ��O�f�[�^�ǂݍ��ݎ��ɁA
        ///			�g�`�f�[�^���X�N���[���o���Ȃ������C���B						//20170825 add
        /// 
        ///		9.	DigitalOsilloForm.cs
        ///			InitAppParameter()
        ///			�X�N���[���o�[�̓��싖�����l��Disable�ցB
        ///			�N����̌����ډ��P�B
        ///			�g���K�|�W�V�����̃R���{�e�L�X�g�ɁA
        ///			"+1"�`"+6"��APP�ۑ��f�[�^�����f����Ȃ������C���B				//20170926 add
        /// 
        ///		10.	DigitalOsilloForm.cs
        ///			�g���K�{�g�`�\����~�ŃX�N���[���\�Ƃ����B
        /// �@�@�@�@�A���A�g���K��ɔg�`�\����~����܂ł̎��Ԃ���������ꍇ�́A
        ///			�i�o�b�t�@�[�����ȏ�j�ŐV���O�f�[�^�ŏ㏑�������d�l�B
        ///			��L�̏C���ɔ����A�N�C�b�N���j�^�[�y�ѕ`��ʒu�����B			//20170927 update
        ///			
        ///		11.	DigitalOsilloForm.cs
        ///			InitAppParameter()
        ///			ComboLogKind_SelectedIndexChanged() numLogPrm_ValueChanged()
        ///			���OID1�`3���A�v���P�[�V�����ݒ�ցB
        ///			�h���C�o�̒l��0��APP�ݒ肪0�ȊO�̏ꍇ��APP�ݒ�ŏ���������B
        ///			�ʒu���O�A���x���O�A�d�����O�ɂ��Ă͏]���ʂ�B
        ///			�����l�̓��j�^�l�i���ϒl�j���ǂ����߁B							//20170928 update
        /// 
        ///		12.	DigitalOsilloForm.cs
        ///			ComboScale_Enter() ComboScale_Leave() ComboScale_TextChanged()
        ///			�g�`�\���X�P�[���𐔒l���͉\�ɕύX�B							//20170928 update
        /// 
        ///		13.	MainForm.cs OptionSettingDialog.cs app.config
        ///			ToolStripMenuItemOption_Click()
        ///			DevCon�@�\���v���p�e�B���B										//20170928 add
        /// 
        ///		14.	MainForm.cs ParameterForm.cs OptionSettingDialog.cs��
        ///			ART-HIKARI���[�h�Ή��B�ؑ�����ǉ��\�t�g�B						//20170928 add  //ART HIKARI Mode 20170919 Kimura add
        ///			
        ///		15.	MainForm.cs
        ///			LoadJogControl()
        ///			�N����̃��C�A�E�g�I����ʂ�JogControlForm��
        ///			�\������Ȃ��������錏���C���BUSB�ڑ��{���j�^�m���҂����폜�B	//20171002 del
        ///
        ///		16.	ManualNavigatorForm.cs
        ///			TAD8810�戵�������ǉ��B�i���{��̂݁j							//20171002 add
        ///
        #endregion
        ///     ����������VER.1.13�����[�X20171002����������
        #region VER.1.13
        ///		1.	CUsb.cs
        ///			StartSerchCDC()
        ///			PID_0101�ǉ��B�g���^P���{�Ή��B									//20171031 update
        /// 
        ///		2.	frmBasicProgramOperation2.cs
        ///			btnPrgSave_Click()
        ///			�R�����g��2�o�C�g������ǉ��������A
        ///			Enter���͂ŃR�����g�������m�肵�Ȃ������C���B
        ///			GridProgram_CellValueChanged()
        ///			�R�����g���͌�ɃR�}���h�ύX����ƁA
        ///			�R�����g�����������i���������j����錏���C���B					//20171114 update
        ///	
        ///		3.	AutoTuningAdjust.cs
        ///			StartAutoTuning()
        ///			TAD8810 + TBL-mini motor �͓d�����[�v�Q�C����
        ///			�Đݒ肵�Ȃ��悤�ɏC���B
        ///			TBL-mini motor �͒�R�A�C���_�N�^�̐ݒ肪���ɏ��������߁A
        ///			�ʏ�̓d�����[�v�Q�C���̌v�Z�ł͉������Ⴗ���邩��A
        ///			����l�ō��߂̓d�����[�v�Q�C�����ݒ肳��Ă���B				//20171114 update
        /// 
        #endregion
        ///		����������VER.1.20�����[�X20171115����������
        #region VER.1.20
        ///		1.	ParameterForm.cs
        ///			ViewParameterResouce()
        ///			ID118�AID119�i���j�^�ݒ�1or2�jHelp��L�����B
        ///			
        ///		2.	CUsb.cs
        ///			StartSerchCDC()
        ///			USB�f�o�C�X����(COM**)���F������Ȃ��ꍇ�̃G���[�΍�B			//20180807 add
        ///
        ///		3.	CUsb.cs
        ///			StartComOpen()
        ///			USB�P�[�u���ؒf���̃A�v���P�[�V�����G���[�΍�B					//20180807 add
        ///		
        ///		4.	CtlJogControl.cs
        ///			ViewCultureResouceChanged()
        ///			����ݒ���p��ɕύX��A
        ///			JogControl�̓���ݒ肪���{��̌��̏C���B						//20180807 update
        /// 
        #endregion
        ///     ����������VER.1.21�����[�X20180807����������
        #region VER1.21
        /// 
        ///		1.	ctlCommandMOVE_END.cs
        ///			�������ʂŁAtxtDeceleration��txtTargetPos�̈ʒu��
        ///			���΂ɂȂ��Ă��錏���C���B										//20180925 update
        /// 
        ///		2.	SimpleControl
        ///			�ȈՃR���g���[���̑S���͉�ʂ̃^�u�I�[�_�[�����B				//20180925 update
        /// 
        ///		3.	CCommandTx.cs
        ///			WriteSvNet()
        ///			�ȈՃv���O���������A�ۑ��҂����ԏC���B1�b��2�b�҂��B			//20180925 update
        ///			
        #endregion
        ///     ����������VER.1.22�����[�X20180926����������
        #region VER1.22
        /// 
        ///		1.	Message.cs OptionSettingDialog.cs
        ///			IoMonitorForm.cs IoMonitorHikariForm ServoMonitorForm.cs
        ///			MainForm.cs ParameterForm.cs
        ///			�A�[�g�q�J���ǉ��p���Ή��B										//20181212 update
        /// 
        #endregion
        ///     ����������VER.1.23�����[�X20181212�i�A�[�g�q�J�������j����������
        #region VER1.23
        /// 
        ///		1.	CtlJogControl.cs
        ///			JogCtrl()
        ///			��Έʒu��������ŖڕW�ʒu1�ƖڕW�ʒu2�̍�����0�̎��A
        /// �@�@�@�@�ʒu���ߓ��삵�Ȃ������C���B
        ///			�ڕW�ʒu1�ւ͕K���ړ����ߏo�͂���悤�ɏC���B
        ///			�ڕW�ʒu2�ֈړ����A������0�̏ꍇ�͈ړ����ߒ�~�B				//20190311 update
        /// 
        ///		2.	CtlJogControl.cs
        ///			RadioButton_CheckedChanged()
        ///			��Έʒu�E���Έʒu�؂�ւ����A�ړ����ߒ�~�B					//20190311 update
        /// 
        #endregion
        ///     ����������VER.1.24�����[�X20190311����������
        #region VER1.24
        /// 
        ///		1.	GainControlForm.cs
        ///			ctlNumExPosFFGain��MAX�l�C���B500��100�D						//20190426 update
        /// 
        ///		2.	CtlJogControl.cs
        ///			JogCtrl()
        ///			�ʒu���䃂�[�h�ňʒu���ߓ���J�n���A
        ///			���x���������~�b�g�r�b�g�ݒ菈���ǉ��B
        ///			TAD8830�i�W���\�t�g�j�Ή��B										//20190522 add
        /// 
        ///		3.	Drive_KASHIYAMA_Mode.txt�Q��
        ///			�~�R�H�ƌ������C�A�E�g�Ή��B									//20190626 add
        /// 
        #endregion
        ///     ����������VER.1.25�����[�X20190626����������
        #region VER1.25
        /// 
        ///		1.	FFT_IF.cs ��
        ///			�{�̕W���\�t�g�Ή��ɂ��FFT�����ύX�Ή��B
        ///			�p�����^ID509�Ԃ�FFT���O���W�������ǉ��B						//20190801 update
        /// 
        ///		2.	Drive_KASHIYAMA_MODE_UPDATE.txt�Q��
        ///			�~�R�H�ƌ������C�A�E�g�Ή��B�i2��ځj							//20191001 update
        /// 
        ///		3.	AlarmHistoryForm.cs
        ///			GetAlarmInfoContent()
        ///			�A���[�������̑��T�[�{�I�����ԁA�g�[�^���I�����ԁA
        ///			�T�[�{��ԕ\���̕\���C���B										//20191010 update
        ///			
        #endregion
        ///     ����������VER.1.26�����[�X20191010����������
        #region VER1.26
        ///
        ///     1.	ParameterForm.cs
        ///     	�A�[�g�q�J���p�����[�^�����C���B							    //20191220 update
        ///   
        ///     2.  MainForm.cs/ParameterForm.cs
        ///         �A�[�g�q�J�����[�h�ŃT�[�{���́A[�p�����[�^�ۑ�]�s�Ƃ���B    //20191220 update
        ///     	
        #endregion
        ///     ����������VER.1.27�����[�X20191220����������
        #region VER1.27
        /// 
        ///     1.  CtlBodePlot.cs  CtlPlotMenu.cs  
        ///         BodeGraphForm.cs FFT_IF.cs MainForm.cs 
        ///         �~�R�H�ƌ��� FFT�O���t�z�[���h�@�\�ǉ��B                        //20200214 Kimura update
        ///         
        ///     2.  MainForm.cs 
        ///         �~�R���[�h�͒ʐM�f�[�^�ʒጸ���� �𖳏����Ɏ��{����l�ɏC���B   //20200330 Kimura add  
        #endregion
        ///     ����������VER.1.28�����[�X20200330����������
        #region VER1.28
        ///     	
        ///     1.  SplashForm.cs ParameterForm.cs OptionSettingDialog.cs  
        ///         �A�}�_������p�p�����[�^���̒ǉ��B
        /// 
        #endregion
        ///  ����������VER.1.29�����[�X20200601����������
        #region VER1.29
        /// 
        ///     1.  ParameterForm.cs  
        ///         �A�}�_������p�p�����[�^���̕ύX�B                              //20210318 Kimura update
        /// 
        #endregion
        ///  ����������VER.1.30�����[�X20210318����������
        #region VER1.30
        /// 
        ///     1.  AutoTuningAdjust.cs AutoTuningForm.cs CMonitor.cs
        ///         Message.cs WizardDialog.cs GainControlForm.cs                   //20210324  
        ///         �C�i�[�V���{���ݒ�Ή��B
        ///         
        ///     2.  MainForm.cs FirmwareUpgradeDialog.cs CCommandTx.cs              //20220106 
        ///         CUsb.cs Message.cs
        ///         �q�y�s�P�p�V���A���u�[�g���[�_�Ή�
        ///         
        ///     3.  DigitalOsilloForm.cs                                            //20220106
        ///     �@�@�g�`�\����~��A�\�����̃��O���Ԃ�菬�����l�ɕύX�����
        ///     �@�@��O�G���[(IndexOutOfRangeException)���������錏���C���B
        ///     �@�@
        ///         ���۔�����) �E���O���Ԃ�600sec�ŃI�V���\��
        ///                             ��
        ///     �@�@            �E�g�`�\����~
        ///     �@�@                    ��
        ///     �@�@            �E���O���Ԃ�10sec�ɕύX
        ///     �@�@                    ��  
        ///     �@�@            �E�}�E�X�J�[�\�����f�W�^���I�V����ʂɈړ� ���G���[����!
        ///         
        /// 
        #endregion
        ///  ����������VER.1.31�����[�X20220106����������
        #region VER1.31
        /// 
        ///     1.  TAD8821�b��Ή��B(USB�@�\����)
        ///     
        ///     2.�@�A�}�_������p�p�����[�^���̋y�ѐ����ǉ��y�ѕύX�B
        ///     
        ///     3.  �p�����[�^�ꊇ�����݋@�\�ǉ��B
        ///         (�ύX�l���ԕ����\������Ă��镔�����ꊇ������)
        ///         �� �E�B���h�E�㕔�́m�ꊇ�������݁n�{�^���܂��́A
        ///         �E�N���b�N�ŃV���[�g���j���[�́m�ꊇ�������݁n�{�^���N���b�N�Ŏ��s�B
        ///         
        ///     4.  �f�W�^���I�V���ɃA���[���������g�`������~�@�\�ǉ��B
        ///         ���m�g���K�ݒ�n- [�A���[�����g�`��~]���`�F�b�N�ŗL���B          
        /// 
        ///     5.  �f�W�^���I�V���̏����\���ݒ�ύX�B
        ///         ���x���O�����ݒ�F�u�����x
        ///         �d�����O�����ݒ�F�u���d��
        ///         
        ///     6.  �ȈՃv���O�������s���A�h���C�o�A���[�������������ꍇ�A
        ///     �@�@[�^�]��~]�{�^����[�^�]�J�n]�{�^���ɖ߂��l�ɏC���B�@
        /// 
        #endregion
        ///  ����������VER.1.32�����[�X20221108����������
        #region VER1.32
        /// 
        ///     1.  �f�W�^���I�V���̃��O�t�@�C���̊J���y�ѕۑ��̏����Ɏ��Ԃ������錏���C���B
        ///     �@�@(10���̃��O�f�[�^�ۑ��ɖ�10�����������Ă��܂��B)
        ///     �@�@
        ///     2. �A�}�_�������[�^���׎����Ή��B(�p�X���[�h:AMADATEST�ŗL��)
        ///    
        /// 
        #endregion
        ///  ����������VER.1.33�����[�X20230203����������
        #region VER1.33
        /// 
        ///     1.  ���[�^���C�����]���o���t�����u�Ή��B
        ///     
        ///     2.  �f�W�^���I�V���̏����\���ݒ�C���B
        ///         Properties.Settings.Default.WAVE_Cur_Idx = 1;       //���x���O�����ݒ�F�u�����x
        ///         Properties.Settings.Default.WAVE_Vel_Idx = 1;       //�d�����O�����ݒ�F�u���d��
        ///         
        ///     3.  �q�y�s�P�p�V���A���u�[�g���[�_�����Ή�
        ///         
        ///
        #endregion
        ///  ����������VER.1.34�����[�X20230406����������
        /// </summary>
    }
}
