
namespace KimCommander {
    partial class AutoShutDownSettingForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOffset = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbOffTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time to want to Power off";
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(12, 33);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(40, 21);
            this.txtHour.TabIndex = 1;
            this.txtHour.TextChanged += new System.EventHandler(this.TxtTime_TextChanged);
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTime_KeyPress);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(99, 33);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(40, 21);
            this.txtMin.TabIndex = 1;
            this.txtMin.TextChanged += new System.EventHandler(this.TxtTime_TextChanged);
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTime_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Set by offset";
            // 
            // cbOffset
            // 
            this.cbOffset.FormattingEnabled = true;
            this.cbOffset.Items.AddRange(new object[] {
            "None",
            "5min",
            "10min",
            "30min",
            "1hour",
            "1hour30min",
            "2hour",
            "2hour30min",
            "3hour",
            "4hour",
            "5hour",
            "6hour",
            "7hour",
            "8hour"});
            this.cbOffset.Location = new System.Drawing.Point(12, 95);
            this.cbOffset.Name = "cbOffset";
            this.cbOffset.Size = new System.Drawing.Size(127, 20);
            this.cbOffset.TabIndex = 2;
            this.cbOffset.SelectedIndexChanged += new System.EventHandler(this.CbOffset_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hour";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Min";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(189, 31);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(143, 23);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(189, 93);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(143, 23);
            this.btnReserve.TabIndex = 3;
            this.btnReserve.Text = "Reserve Power Off";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "The schedule of power off :";
            // 
            // lbOffTime
            // 
            this.lbOffTime.AutoSize = true;
            this.lbOffTime.Location = new System.Drawing.Point(179, 146);
            this.lbOffTime.Name = "lbOffTime";
            this.lbOffTime.Size = new System.Drawing.Size(11, 12);
            this.lbOffTime.TabIndex = 0;
            this.lbOffTime.Text = "-";
            // 
            // AutoShutDownSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 170);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.cbOffset);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbOffTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoShutDownSettingForm";
            this.ShowIcon = false;
            this.Text = "Auto Shutdown";
            this.Load += new System.EventHandler(this.AutoShutDownSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbOffTime;
    }
}