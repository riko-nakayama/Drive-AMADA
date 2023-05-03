using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlProfileGrid : DataGridView
    {

        public ctlProfileGrid()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((keyData & Keys.KeyCode) == Keys.Enter)
            {
                //最終行・最終列のコメント以外実行（コメント入力後、確定しない為）
                if (!(this.CurrentRow.Index == (this.RowCount - 1) && this.CurrentCell.ColumnIndex == 10))
                {
                    return this.ProcessTabKey(keyData);
                }
            }
            return base.ProcessDialogKey(keyData);
        }

         protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                //最終行・最終列のコメント以外実行（コメント入力後、確定しない為）
                if (!(this.CurrentRow.Index == (this.RowCount - 1) && this.CurrentCell.ColumnIndex == 10))
                {
                    return this.ProcessTabKey(e.KeyCode);
                }
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
}
