namespace KimCommander
{
    partial class QuickStartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickStartForm));
            this.comboInput = new System.Windows.Forms.ComboBox();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_execute_name = new System.Windows.Forms.Label();
            this.btn_showMain = new System.Windows.Forms.Button();
            this.pictureBox_Execute = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Execute)).BeginInit();
            this.SuspendLayout();
            // 
            // comboInput
            // 
            this.comboInput.FormattingEnabled = true;
            this.comboInput.Location = new System.Drawing.Point(12, 69);
            this.comboInput.Name = "comboInput";
            this.comboInput.Size = new System.Drawing.Size(424, 20);
            this.comboInput.TabIndex = 0;
            this.comboInput.SelectionChangeCommitted += new System.EventHandler(this.comboInput_SelectionChangeCommitted);
            this.comboInput.SelectedValueChanged += new System.EventHandler(this.comboInput_SelectedValueChanged);
            this.comboInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboInput_KeyUp);
            // 
            // btn_Execute
            // 
            this.btn_Execute.Location = new System.Drawing.Point(442, 69);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(112, 19);
            this.btn_Execute.TabIndex = 1;
            this.btn_Execute.Text = "실행";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "실행 될 프로그램";
            // 
            // lb_execute_name
            // 
            this.lb_execute_name.AutoSize = true;
            this.lb_execute_name.Location = new System.Drawing.Point(174, 43);
            this.lb_execute_name.Name = "lb_execute_name";
            this.lb_execute_name.Size = new System.Drawing.Size(11, 12);
            this.lb_execute_name.TabIndex = 2;
            this.lb_execute_name.Text = "-";
            // 
            // btn_showMain
            // 
            this.btn_showMain.Location = new System.Drawing.Point(442, 44);
            this.btn_showMain.Name = "btn_showMain";
            this.btn_showMain.Size = new System.Drawing.Size(111, 19);
            this.btn_showMain.TabIndex = 3;
            this.btn_showMain.Text = "메인폼보기";
            this.btn_showMain.UseVisualStyleBackColor = true;
            this.btn_showMain.Click += new System.EventHandler(this.btn_showMain_Click);
            // 
            // pictureBox_Execute
            // 
            this.pictureBox_Execute.Location = new System.Drawing.Point(118, 12);
            this.pictureBox_Execute.Name = "pictureBox_Execute";
            this.pictureBox_Execute.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Execute.TabIndex = 4;
            this.pictureBox_Execute.TabStop = false;
            // 
            // QuickStartForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 101);
            this.Controls.Add(this.pictureBox_Execute);
            this.Controls.Add(this.btn_showMain);
            this.Controls.Add(this.lb_execute_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Execute);
            this.Controls.Add(this.comboInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuickStartForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.Text = "빠른실행";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuickStartForm_FormClosing);
            this.Load += new System.EventHandler(this.QuickStartForm_Load);
            this.VisibleChanged += new System.EventHandler(this.QuickStartForm_VisibleChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.QuickStartForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.QuickStartForm_DragEnter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickStartForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Execute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboInput;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_execute_name;
        private System.Windows.Forms.Button btn_showMain;
        private System.Windows.Forms.PictureBox pictureBox_Execute;
    }
}