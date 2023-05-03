using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandEND_V : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x2e;

        public const string Command = "END_V";

        public readonly string Help = UserText.CtlCommandEND_V_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandEND_V_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandEND_V_HELP3 + Environment.NewLine +
                                      UserText.CtlCommandEND_V_HELP4;

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
        public ctlCommandEND_V()
        {
            InitializeComponent();
        }
    }
}
