using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandNOP : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x00;

        public const string Command = "NOP";

        public readonly string Help = UserText.CtlCommandNOP_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandNOP_HELP2;
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
        public ctlCommandNOP()
        {
            InitializeComponent();
        }
    }
}
