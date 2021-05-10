namespace UserDataBinding
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TBName = new System.Windows.Forms.TextBox();
            this.TBCommand = new System.Windows.Forms.TextBox();
            this.TBData = new System.Windows.Forms.NumericUpDown();
            this.TBStatus = new System.Windows.Forms.CheckBox();
            this.txt_UserInput = new System.Windows.Forms.TextBox();
            this.lbl_description = new System.Windows.Forms.Label();
            this.TBData2 = new System.Windows.Forms.NumericUpDown();
            this.TBStatus2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TBData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBData2)).BeginInit();
            this.SuspendLayout();
            // 
            // TBName
            // 
            this.TBName.Location = new System.Drawing.Point(308, 12);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(228, 22);
            this.TBName.TabIndex = 0;
            // 
            // TBCommand
            // 
            this.TBCommand.Location = new System.Drawing.Point(308, 68);
            this.TBCommand.Name = "TBCommand";
            this.TBCommand.Size = new System.Drawing.Size(228, 22);
            this.TBCommand.TabIndex = 2;
            // 
            // TBData
            // 
            this.TBData.Location = new System.Drawing.Point(308, 40);
            this.TBData.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TBData.Name = "TBData";
            this.TBData.Size = new System.Drawing.Size(120, 22);
            this.TBData.TabIndex = 3;
            // 
            // TBStatus
            // 
            this.TBStatus.AutoSize = true;
            this.TBStatus.Location = new System.Drawing.Point(434, 41);
            this.TBStatus.Name = "TBStatus";
            this.TBStatus.Size = new System.Drawing.Size(55, 16);
            this.TBStatus.TabIndex = 6;
            this.TBStatus.Text = "Empty";
            this.TBStatus.UseVisualStyleBackColor = true;
            // 
            // txt_UserInput
            // 
            this.txt_UserInput.Location = new System.Drawing.Point(12, 10);
            this.txt_UserInput.Name = "txt_UserInput";
            this.txt_UserInput.Size = new System.Drawing.Size(191, 22);
            this.txt_UserInput.TabIndex = 0;
            this.txt_UserInput.TextChanged += new System.EventHandler(this.txt_UserInput_TextChanged);
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(10, 50);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(110, 48);
            this.lbl_description.TabIndex = 8;
            this.lbl_description.Text = "根據輸入值\r\n1.顯示輸入值\r\n2.分析輸入字元數量\r\n3.將輸入值變成大寫";
            // 
            // TBData2
            // 
            this.TBData2.Location = new System.Drawing.Point(308, 103);
            this.TBData2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TBData2.Name = "TBData2";
            this.TBData2.Size = new System.Drawing.Size(120, 22);
            this.TBData2.TabIndex = 3;
            // 
            // TBStatus2
            // 
            this.TBStatus2.AutoSize = true;
            this.TBStatus2.Location = new System.Drawing.Point(434, 104);
            this.TBStatus2.Name = "TBStatus2";
            this.TBStatus2.Size = new System.Drawing.Size(55, 16);
            this.TBStatus2.TabIndex = 6;
            this.TBStatus2.Text = "Empty";
            this.TBStatus2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 137);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.txt_UserInput);
            this.Controls.Add(this.TBStatus2);
            this.Controls.Add(this.TBStatus);
            this.Controls.Add(this.TBData2);
            this.Controls.Add(this.TBData);
            this.Controls.Add(this.TBCommand);
            this.Controls.Add(this.TBName);
            this.Name = "MainForm";
            this.Text = "8";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TBData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBData2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.TextBox TBCommand;
        private System.Windows.Forms.NumericUpDown TBData;
        private System.Windows.Forms.CheckBox TBStatus;

        #endregion

        private System.Windows.Forms.TextBox txt_UserInput;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.NumericUpDown TBData2;
        private System.Windows.Forms.CheckBox TBStatus2;
    }
}

