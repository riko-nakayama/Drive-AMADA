namespace Motion_Designer
{
    partial class AlarmHistoryForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmHistoryForm));
            this.treeViewAlarm = new System.Windows.Forms.TreeView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewAlarm
            // 
            resources.ApplyResources(this.treeViewAlarm, "treeViewAlarm");
            this.treeViewAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewAlarm.FullRowSelect = true;
            this.treeViewAlarm.HideSelection = false;
            this.treeViewAlarm.Name = "treeViewAlarm";
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // AlarmHistoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.treeViewAlarm);
            this.MaximizeBox = false;
            this.Name = "AlarmHistoryForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AlarmHistoryForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmHistoryForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewAlarm;
        private System.Windows.Forms.Button btnUpdate;
    }
}