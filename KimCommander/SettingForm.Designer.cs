namespace KimCommander
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.chk_regApp = new System.Windows.Forms.CheckBox();
            this.comboBox_modifier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_hotkeySet = new System.Windows.Forms.Button();
            this.comboBoxHotkey = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chk_regApp
            // 
            this.chk_regApp.AutoSize = true;
            this.chk_regApp.Location = new System.Drawing.Point(12, 161);
            this.chk_regApp.Name = "chk_regApp";
            this.chk_regApp.Size = new System.Drawing.Size(140, 16);
            this.chk_regApp.TabIndex = 3;
            this.chk_regApp.Text = "부팅시 프로그램 실행";
            this.chk_regApp.UseVisualStyleBackColor = true;
            this.chk_regApp.CheckedChanged += new System.EventHandler(this.chk_regApp_CheckedChanged);
            // 
            // comboBox_modifier
            // 
            this.comboBox_modifier.FormattingEnabled = true;
            this.comboBox_modifier.Items.AddRange(new object[] {
            "Shift",
            "Alt",
            "Ctrl",
            "Shift+Alt",
            "Shift+Ctrl",
            "Alt+Ctrl"});
            this.comboBox_modifier.Location = new System.Drawing.Point(14, 57);
            this.comboBox_modifier.Name = "comboBox_modifier";
            this.comboBox_modifier.Size = new System.Drawing.Size(164, 20);
            this.comboBox_modifier.TabIndex = 0;
            this.comboBox_modifier.Text = "Shift";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "단축키 설정";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "조합키";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "+";
            // 
            // btn_hotkeySet
            // 
            this.btn_hotkeySet.Location = new System.Drawing.Point(359, 56);
            this.btn_hotkeySet.Name = "btn_hotkeySet";
            this.btn_hotkeySet.Size = new System.Drawing.Size(117, 21);
            this.btn_hotkeySet.TabIndex = 2;
            this.btn_hotkeySet.Text = "단축키 설정완료";
            this.btn_hotkeySet.UseVisualStyleBackColor = true;
            this.btn_hotkeySet.Click += new System.EventHandler(this.btn_hotkeySet_Click);
            // 
            // comboBoxHotkey
            // 
            this.comboBoxHotkey.FormattingEnabled = true;
            this.comboBoxHotkey.Items.AddRange(new object[] {
            "Space",
            "D0",
            "D1",
            "D2",
            "D3",
            "D4",
            "D5",
            "D6",
            "D7",
            "D8",
            "D9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.comboBoxHotkey.Location = new System.Drawing.Point(201, 57);
            this.comboBoxHotkey.Name = "comboBoxHotkey";
            this.comboBoxHotkey.Size = new System.Drawing.Size(121, 20);
            this.comboBoxHotkey.TabIndex = 9;
            this.comboBoxHotkey.Text = "Space";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 189);
            this.Controls.Add(this.comboBoxHotkey);
            this.Controls.Add(this.btn_hotkeySet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_modifier);
            this.Controls.Add(this.chk_regApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "설정 화면입니다";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SettingForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_regApp;
        private System.Windows.Forms.ComboBox comboBox_modifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_hotkeySet;
        private System.Windows.Forms.ComboBox comboBoxHotkey;
    }
}