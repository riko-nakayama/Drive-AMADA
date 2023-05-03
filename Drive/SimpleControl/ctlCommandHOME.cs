using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandHOME : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x2a;

        public const string Command = "HOME";

        public readonly string Help = UserText.CtlCommandHOME_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandHOME_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandHOME_HELP3;

        public string Comment = "";

        #endregion

        #region プロパティ

        /// <summary>
        /// プログラムＩＤを取得します。
        /// </summary>
        public Int32 ID
        {
            get { return ProgID; }
        }

        /// <summary>
        /// ニューメリックコード取得
        /// </summary>
        public string MnemonicCode
        {
            get { return Command + " ;" + Comment; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandHOME()
        {
            InitializeComponent();
        }
    }
}
