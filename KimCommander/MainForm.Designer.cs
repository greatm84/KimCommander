namespace KimCommander
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shutdownCancelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ExportData = new System.Windows.Forms.Button();
            this.listViewTimeItem = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chParam1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chParam2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRunAdmin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAfterCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewQuickItem = new System.Windows.Forms.ListView();
            this.chQName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQShortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQArgument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQRunAdmin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQPreCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxQuickItem = new System.Windows.Forms.GroupBox();
            this.chk_QRunAdmin = new System.Windows.Forms.CheckBox();
            this.txt_QFilePath = new System.Windows.Forms.TextBox();
            this.txt_QArgument = new System.Windows.Forms.TextBox();
            this.txt_QShortName = new System.Windows.Forms.TextBox();
            this.txt_QPreCommand = new System.Windows.Forms.TextBox();
            this.txt_QName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Mod = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_TimeAdd = new System.Windows.Forms.Button();
            this.btn_TimeDel = new System.Windows.Forms.Button();
            this.btn_TimeMod = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_HomePage = new System.Windows.Forms.Button();
            this.btnAutoShutdown = new System.Windows.Forms.Button();
            this.groupBoxTimeItem = new System.Windows.Forms.GroupBox();
            this.txt_TSec = new System.Windows.Forms.TextBox();
            this.txt_TMin = new System.Windows.Forms.TextBox();
            this.txt_THour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chk_TAfter = new System.Windows.Forms.CheckBox();
            this.chk_TNextBoot = new System.Windows.Forms.CheckBox();
            this.chk_TAdmin = new System.Windows.Forms.CheckBox();
            this.txt_TFilePath = new System.Windows.Forms.TextBox();
            this.txt_TArgument = new System.Windows.Forms.TextBox();
            this.txt_TPrecommand = new System.Windows.Forms.TextBox();
            this.txt_TName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnQuickToTime = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxQuickItem.SuspendLayout();
            this.groupBoxTimeItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "김커맨더 대기중";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownCancelMenuItem,
            this.showtoolStripMenuItem,
            this.exittoolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(151, 70);
            // 
            // shutdownCancelMenuItem
            // 
            this.shutdownCancelMenuItem.Name = "shutdownCancelMenuItem";
            this.shutdownCancelMenuItem.Size = new System.Drawing.Size(150, 22);
            this.shutdownCancelMenuItem.Text = "종료예약취소";
            // 
            // showtoolStripMenuItem
            // 
            this.showtoolStripMenuItem.Name = "showtoolStripMenuItem";
            this.showtoolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.showtoolStripMenuItem.Text = "메인화면 보기";
            // 
            // exittoolStripMenuItem
            // 
            this.exittoolStripMenuItem.Name = "exittoolStripMenuItem";
            this.exittoolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exittoolStripMenuItem.Text = "프로그램 종료";
            // 
            // btn_ExportData
            // 
            this.btn_ExportData.Location = new System.Drawing.Point(1298, 12);
            this.btn_ExportData.Name = "btn_ExportData";
            this.btn_ExportData.Size = new System.Drawing.Size(115, 23);
            this.btn_ExportData.TabIndex = 3;
            this.btn_ExportData.Text = "Items Export";
            this.btn_ExportData.UseVisualStyleBackColor = true;
            this.btn_ExportData.Click += new System.EventHandler(this.btn_ExportData_Click);
            // 
            // listViewTimeItem
            // 
            this.listViewTimeItem.AllowDrop = true;
            this.listViewTimeItem.BackColor = System.Drawing.SystemColors.Window;
            this.listViewTimeItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chType,
            this.chEventType,
            this.chHour,
            this.chMin,
            this.chSec,
            this.chParam1,
            this.chParam2,
            this.chRunAdmin,
            this.chAfterCheck});
            this.listViewTimeItem.FullRowSelect = true;
            this.listViewTimeItem.LabelEdit = true;
            this.listViewTimeItem.Location = new System.Drawing.Point(12, 291);
            this.listViewTimeItem.Name = "listViewTimeItem";
            this.listViewTimeItem.Size = new System.Drawing.Size(618, 378);
            this.listViewTimeItem.TabIndex = 2;
            this.listViewTimeItem.UseCompatibleStateImageBehavior = false;
            this.listViewTimeItem.View = System.Windows.Forms.View.Details;
            this.listViewTimeItem.SelectedIndexChanged += new System.EventHandler(this.listViewTimeItem_SelectedIndexChanged);
            this.listViewTimeItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewTimeItem_DragDrop);
            this.listViewTimeItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewTimeItem_DragEnter);
            this.listViewTimeItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewTimeItem_MouseClick);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 54;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 50;
            // 
            // chEventType
            // 
            this.chEventType.Text = "EventType";
            this.chEventType.Width = 50;
            // 
            // chHour
            // 
            this.chHour.Text = "Hour";
            this.chHour.Width = 30;
            // 
            // chMin
            // 
            this.chMin.Text = "Minute";
            this.chMin.Width = 30;
            // 
            // chSec
            // 
            this.chSec.Text = "Second";
            this.chSec.Width = 30;
            // 
            // chParam1
            // 
            this.chParam1.Text = "FilePath";
            this.chParam1.Width = 200;
            // 
            // chParam2
            // 
            this.chParam2.Text = "Argument";
            // 
            // chRunAdmin
            // 
            this.chRunAdmin.DisplayIndex = 9;
            this.chRunAdmin.Text = "Admin";
            // 
            // chAfterCheck
            // 
            this.chAfterCheck.DisplayIndex = 8;
            this.chAfterCheck.Text = "AfterCheck";
            this.chAfterCheck.Width = 50;
            // 
            // listViewQuickItem
            // 
            this.listViewQuickItem.AllowDrop = true;
            this.listViewQuickItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQName,
            this.chQFilePath,
            this.chQShortName,
            this.chQArgument,
            this.chQRunAdmin,
            this.chQPreCommand});
            this.listViewQuickItem.FullRowSelect = true;
            this.listViewQuickItem.LabelEdit = true;
            this.listViewQuickItem.Location = new System.Drawing.Point(670, 205);
            this.listViewQuickItem.Name = "listViewQuickItem";
            this.listViewQuickItem.Size = new System.Drawing.Size(743, 464);
            this.listViewQuickItem.TabIndex = 2;
            this.listViewQuickItem.UseCompatibleStateImageBehavior = false;
            this.listViewQuickItem.View = System.Windows.Forms.View.Details;
            this.listViewQuickItem.SelectedIndexChanged += new System.EventHandler(this.listViewQuickItem_SelectedIndexChanged);
            this.listViewQuickItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewQuickItem_DragDrop);
            this.listViewQuickItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewQuickItem_DragEnter);
            this.listViewQuickItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewQuickItem_MouseClick);
            // 
            // chQName
            // 
            this.chQName.Text = "Name";
            this.chQName.Width = 100;
            // 
            // chQFilePath
            // 
            this.chQFilePath.Text = "FilePath";
            this.chQFilePath.Width = 300;
            // 
            // chQShortName
            // 
            this.chQShortName.Text = "ShortName";
            this.chQShortName.Width = 80;
            // 
            // chQArgument
            // 
            this.chQArgument.Text = "Argument";
            this.chQArgument.Width = 100;
            // 
            // chQRunAdmin
            // 
            this.chQRunAdmin.Text = "Admin";
            // 
            // chQPreCommand
            // 
            this.chQPreCommand.Text = "PreCommand";
            this.chQPreCommand.Width = 100;
            // 
            // groupBoxQuickItem
            // 
            this.groupBoxQuickItem.Controls.Add(this.chk_QRunAdmin);
            this.groupBoxQuickItem.Controls.Add(this.txt_QFilePath);
            this.groupBoxQuickItem.Controls.Add(this.txt_QArgument);
            this.groupBoxQuickItem.Controls.Add(this.txt_QShortName);
            this.groupBoxQuickItem.Controls.Add(this.txt_QPreCommand);
            this.groupBoxQuickItem.Controls.Add(this.txt_QName);
            this.groupBoxQuickItem.Controls.Add(this.label4);
            this.groupBoxQuickItem.Controls.Add(this.label3);
            this.groupBoxQuickItem.Controls.Add(this.label2);
            this.groupBoxQuickItem.Controls.Add(this.label6);
            this.groupBoxQuickItem.Controls.Add(this.label1);
            this.groupBoxQuickItem.Controls.Add(this.btn_Mod);
            this.groupBoxQuickItem.Controls.Add(this.btn_Del);
            this.groupBoxQuickItem.Controls.Add(this.btn_Add);
            this.groupBoxQuickItem.Location = new System.Drawing.Point(670, 84);
            this.groupBoxQuickItem.Name = "groupBoxQuickItem";
            this.groupBoxQuickItem.Size = new System.Drawing.Size(742, 115);
            this.groupBoxQuickItem.TabIndex = 3;
            this.groupBoxQuickItem.TabStop = false;
            this.groupBoxQuickItem.Text = "QuickStartItem";
            this.groupBoxQuickItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxQuickItem_DragDrop);
            this.groupBoxQuickItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBoxQuickItem_DragEnter);
            // 
            // chk_QRunAdmin
            // 
            this.chk_QRunAdmin.AutoSize = true;
            this.chk_QRunAdmin.Location = new System.Drawing.Point(558, 84);
            this.chk_QRunAdmin.Name = "chk_QRunAdmin";
            this.chk_QRunAdmin.Size = new System.Drawing.Size(103, 16);
            this.chk_QRunAdmin.TabIndex = 7;
            this.chk_QRunAdmin.Text = "Run as admin";
            this.chk_QRunAdmin.UseVisualStyleBackColor = true;
            // 
            // txt_QFilePath
            // 
            this.txt_QFilePath.Location = new System.Drawing.Point(99, 43);
            this.txt_QFilePath.Name = "txt_QFilePath";
            this.txt_QFilePath.Size = new System.Drawing.Size(231, 21);
            this.txt_QFilePath.TabIndex = 2;
            // 
            // txt_QArgument
            // 
            this.txt_QArgument.Location = new System.Drawing.Point(429, 43);
            this.txt_QArgument.Name = "txt_QArgument";
            this.txt_QArgument.Size = new System.Drawing.Size(123, 21);
            this.txt_QArgument.TabIndex = 2;
            // 
            // txt_QShortName
            // 
            this.txt_QShortName.Location = new System.Drawing.Point(336, 43);
            this.txt_QShortName.Name = "txt_QShortName";
            this.txt_QShortName.Size = new System.Drawing.Size(87, 21);
            this.txt_QShortName.TabIndex = 2;
            // 
            // txt_QPreCommand
            // 
            this.txt_QPreCommand.Location = new System.Drawing.Point(8, 82);
            this.txt_QPreCommand.Name = "txt_QPreCommand";
            this.txt_QPreCommand.Size = new System.Drawing.Size(544, 21);
            this.txt_QPreCommand.TabIndex = 2;
            // 
            // txt_QName
            // 
            this.txt_QName.Location = new System.Drawing.Point(6, 43);
            this.txt_QName.Name = "txt_QName";
            this.txt_QName.Size = new System.Drawing.Size(87, 21);
            this.txt_QName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Argument";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "ShortName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "FilePath";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Precommand";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // btn_Mod
            // 
            this.btn_Mod.Location = new System.Drawing.Point(680, 40);
            this.btn_Mod.Name = "btn_Mod";
            this.btn_Mod.Size = new System.Drawing.Size(56, 25);
            this.btn_Mod.TabIndex = 6;
            this.btn_Mod.Text = "수정";
            this.btn_Mod.UseVisualStyleBackColor = true;
            this.btn_Mod.Click += new System.EventHandler(this.btn_Mod_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(620, 40);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(56, 25);
            this.btn_Del.TabIndex = 5;
            this.btn_Del.Text = "삭제";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(558, 40);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(56, 25);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "추가";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_TimeAdd
            // 
            this.btn_TimeAdd.Location = new System.Drawing.Point(480, 42);
            this.btn_TimeAdd.Name = "btn_TimeAdd";
            this.btn_TimeAdd.Size = new System.Drawing.Size(59, 23);
            this.btn_TimeAdd.TabIndex = 6;
            this.btn_TimeAdd.Text = "추가";
            this.btn_TimeAdd.UseVisualStyleBackColor = true;
            this.btn_TimeAdd.Click += new System.EventHandler(this.btn_TimeAdd_Click);
            // 
            // btn_TimeDel
            // 
            this.btn_TimeDel.Location = new System.Drawing.Point(543, 42);
            this.btn_TimeDel.Name = "btn_TimeDel";
            this.btn_TimeDel.Size = new System.Drawing.Size(52, 23);
            this.btn_TimeDel.TabIndex = 6;
            this.btn_TimeDel.Text = "삭제";
            this.btn_TimeDel.UseVisualStyleBackColor = true;
            this.btn_TimeDel.Click += new System.EventHandler(this.btn_TimeDel_Click);
            // 
            // btn_TimeMod
            // 
            this.btn_TimeMod.Location = new System.Drawing.Point(480, 80);
            this.btn_TimeMod.Name = "btn_TimeMod";
            this.btn_TimeMod.Size = new System.Drawing.Size(117, 23);
            this.btn_TimeMod.TabIndex = 6;
            this.btn_TimeMod.Text = "수정";
            this.btn_TimeMod.UseVisualStyleBackColor = true;
            this.btn_TimeMod.Click += new System.EventHandler(this.btn_TimeMod_Click);
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(1013, 12);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(77, 23);
            this.btn_setting.TabIndex = 1;
            this.btn_setting.Text = "설정";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(1177, 12);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(115, 23);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "Items Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // btn_HomePage
            // 
            this.btn_HomePage.Location = new System.Drawing.Point(932, 12);
            this.btn_HomePage.Name = "btn_HomePage";
            this.btn_HomePage.Size = new System.Drawing.Size(75, 23);
            this.btn_HomePage.TabIndex = 0;
            this.btn_HomePage.Text = "개발페이지";
            this.btn_HomePage.UseVisualStyleBackColor = true;
            this.btn_HomePage.Click += new System.EventHandler(this.btn_HomePage_Click);
            // 
            // btnAutoShutdown
            // 
            this.btnAutoShutdown.Location = new System.Drawing.Point(1096, 12);
            this.btnAutoShutdown.Name = "btnAutoShutdown";
            this.btnAutoShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnAutoShutdown.TabIndex = 9;
            this.btnAutoShutdown.Text = "자동종료";
            this.btnAutoShutdown.UseVisualStyleBackColor = true;
            this.btnAutoShutdown.Click += new System.EventHandler(this.btnAutoShutdown_Click);
            // 
            // groupBoxTimeItem
            // 
            this.groupBoxTimeItem.Controls.Add(this.txt_TSec);
            this.groupBoxTimeItem.Controls.Add(this.txt_TMin);
            this.groupBoxTimeItem.Controls.Add(this.txt_THour);
            this.groupBoxTimeItem.Controls.Add(this.label7);
            this.groupBoxTimeItem.Controls.Add(this.label11);
            this.groupBoxTimeItem.Controls.Add(this.label12);
            this.groupBoxTimeItem.Controls.Add(this.chk_TAfter);
            this.groupBoxTimeItem.Controls.Add(this.chk_TNextBoot);
            this.groupBoxTimeItem.Controls.Add(this.chk_TAdmin);
            this.groupBoxTimeItem.Controls.Add(this.txt_TFilePath);
            this.groupBoxTimeItem.Controls.Add(this.txt_TArgument);
            this.groupBoxTimeItem.Controls.Add(this.txt_TPrecommand);
            this.groupBoxTimeItem.Controls.Add(this.txt_TName);
            this.groupBoxTimeItem.Controls.Add(this.btn_TimeMod);
            this.groupBoxTimeItem.Controls.Add(this.label5);
            this.groupBoxTimeItem.Controls.Add(this.btn_TimeDel);
            this.groupBoxTimeItem.Controls.Add(this.label8);
            this.groupBoxTimeItem.Controls.Add(this.btn_TimeAdd);
            this.groupBoxTimeItem.Controls.Add(this.label9);
            this.groupBoxTimeItem.Controls.Add(this.label10);
            this.groupBoxTimeItem.Location = new System.Drawing.Point(12, 84);
            this.groupBoxTimeItem.Name = "groupBoxTimeItem";
            this.groupBoxTimeItem.Size = new System.Drawing.Size(618, 185);
            this.groupBoxTimeItem.TabIndex = 10;
            this.groupBoxTimeItem.TabStop = false;
            this.groupBoxTimeItem.Text = "시간 지정 자동 실행";
            this.groupBoxTimeItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxTimeItem_DragDrop);
            this.groupBoxTimeItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBoxTimeItem_DragEnter);
            // 
            // txt_TSec
            // 
            this.txt_TSec.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_TSec.Location = new System.Drawing.Point(100, 148);
            this.txt_TSec.Name = "txt_TSec";
            this.txt_TSec.Size = new System.Drawing.Size(29, 21);
            this.txt_TSec.TabIndex = 26;
            // 
            // txt_TMin
            // 
            this.txt_TMin.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_TMin.Location = new System.Drawing.Point(57, 148);
            this.txt_TMin.Name = "txt_TMin";
            this.txt_TMin.Size = new System.Drawing.Size(29, 21);
            this.txt_TMin.TabIndex = 25;
            // 
            // txt_THour
            // 
            this.txt_THour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_THour.Location = new System.Drawing.Point(14, 148);
            this.txt_THour.Name = "txt_THour";
            this.txt_THour.Size = new System.Drawing.Size(29, 21);
            this.txt_THour.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "Second";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "Minute";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 12);
            this.label12.TabIndex = 23;
            this.label12.Text = "Hour";
            // 
            // chk_TAfter
            // 
            this.chk_TAfter.AutoSize = true;
            this.chk_TAfter.Location = new System.Drawing.Point(492, 153);
            this.chk_TAfter.Name = "chk_TAfter";
            this.chk_TAfter.Size = new System.Drawing.Size(89, 16);
            this.chk_TAfter.TabIndex = 20;
            this.chk_TAfter.Text = "After Check";
            this.chk_TAfter.UseVisualStyleBackColor = true;
            // 
            // chk_TNextBoot
            // 
            this.chk_TNextBoot.AutoSize = true;
            this.chk_TNextBoot.Location = new System.Drawing.Point(492, 131);
            this.chk_TNextBoot.Name = "chk_TNextBoot";
            this.chk_TNextBoot.Size = new System.Drawing.Size(115, 16);
            this.chk_TNextBoot.TabIndex = 19;
            this.chk_TNextBoot.Text = "Next Boot Apply";
            this.chk_TNextBoot.UseVisualStyleBackColor = true;
            // 
            // chk_TAdmin
            // 
            this.chk_TAdmin.AutoSize = true;
            this.chk_TAdmin.Location = new System.Drawing.Point(492, 109);
            this.chk_TAdmin.Name = "chk_TAdmin";
            this.chk_TAdmin.Size = new System.Drawing.Size(103, 16);
            this.chk_TAdmin.TabIndex = 18;
            this.chk_TAdmin.Text = "Run as admin";
            this.chk_TAdmin.UseVisualStyleBackColor = true;
            // 
            // txt_TFilePath
            // 
            this.txt_TFilePath.Location = new System.Drawing.Point(105, 43);
            this.txt_TFilePath.Name = "txt_TFilePath";
            this.txt_TFilePath.Size = new System.Drawing.Size(231, 21);
            this.txt_TFilePath.TabIndex = 13;
            // 
            // txt_TArgument
            // 
            this.txt_TArgument.Location = new System.Drawing.Point(351, 43);
            this.txt_TArgument.Name = "txt_TArgument";
            this.txt_TArgument.Size = new System.Drawing.Size(123, 21);
            this.txt_TArgument.TabIndex = 14;
            // 
            // txt_TPrecommand
            // 
            this.txt_TPrecommand.Location = new System.Drawing.Point(14, 82);
            this.txt_TPrecommand.Name = "txt_TPrecommand";
            this.txt_TPrecommand.Size = new System.Drawing.Size(460, 21);
            this.txt_TPrecommand.TabIndex = 16;
            // 
            // txt_TName
            // 
            this.txt_TName.Location = new System.Drawing.Point(12, 43);
            this.txt_TName.Name = "txt_TName";
            this.txt_TName.Size = new System.Drawing.Size(87, 21);
            this.txt_TName.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Argument";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "FilePath";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "Precommand";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "Name";
            // 
            // btnQuickToTime
            // 
            this.btnQuickToTime.Location = new System.Drawing.Point(636, 437);
            this.btnQuickToTime.Name = "btnQuickToTime";
            this.btnQuickToTime.Size = new System.Drawing.Size(28, 23);
            this.btnQuickToTime.TabIndex = 11;
            this.btnQuickToTime.Text = "<";
            this.btnQuickToTime.UseVisualStyleBackColor = true;
            this.btnQuickToTime.Click += new System.EventHandler(this.btnQuickToTime_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1424, 681);
            this.Controls.Add(this.btnQuickToTime);
            this.Controls.Add(this.groupBoxTimeItem);
            this.Controls.Add(this.btnAutoShutdown);
            this.Controls.Add(this.btn_HomePage);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.groupBoxQuickItem);
            this.Controls.Add(this.listViewQuickItem);
            this.Controls.Add(this.listViewTimeItem);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_ExportData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "김커맨더입니다(v1.0.11)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxQuickItem.ResumeLayout(false);
            this.groupBoxQuickItem.PerformLayout();
            this.groupBoxTimeItem.ResumeLayout(false);
            this.groupBoxTimeItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exittoolStripMenuItem;
        private System.Windows.Forms.Button btn_ExportData;
        private System.Windows.Forms.ListView listViewTimeItem;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chEventType;
        private System.Windows.Forms.ColumnHeader chHour;
        private System.Windows.Forms.ColumnHeader chMin;
        private System.Windows.Forms.ColumnHeader chSec;
        private System.Windows.Forms.ColumnHeader chParam1;
        private System.Windows.Forms.ColumnHeader chParam2;
        private System.Windows.Forms.ListView listViewQuickItem;
        private System.Windows.Forms.ColumnHeader chQName;
        private System.Windows.Forms.ColumnHeader chQFilePath;
        private System.Windows.Forms.ColumnHeader chQShortName;
        private System.Windows.Forms.ColumnHeader chQArgument;
        private System.Windows.Forms.ColumnHeader chAfterCheck;
        private System.Windows.Forms.GroupBox groupBoxQuickItem;
        private System.Windows.Forms.Button btn_Mod;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox txt_QFilePath;
        private System.Windows.Forms.TextBox txt_QArgument;
        private System.Windows.Forms.TextBox txt_QShortName;
        private System.Windows.Forms.TextBox txt_QName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_TimeAdd;
        private System.Windows.Forms.Button btn_TimeDel;
        private System.Windows.Forms.Button btn_TimeMod;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_HomePage;
        private System.Windows.Forms.TextBox txt_QPreCommand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_QRunAdmin;
        private System.Windows.Forms.ColumnHeader chRunAdmin;
        private System.Windows.Forms.ColumnHeader chQRunAdmin;
        private System.Windows.Forms.ColumnHeader chQPreCommand;
        private System.Windows.Forms.Button btnAutoShutdown;
        private System.Windows.Forms.GroupBox groupBoxTimeItem;
        private System.Windows.Forms.CheckBox chk_TAfter;
        private System.Windows.Forms.CheckBox chk_TNextBoot;
        private System.Windows.Forms.CheckBox chk_TAdmin;
        private System.Windows.Forms.TextBox txt_TFilePath;
        private System.Windows.Forms.TextBox txt_TArgument;
        private System.Windows.Forms.TextBox txt_TPrecommand;
        private System.Windows.Forms.TextBox txt_TName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_TSec;
        private System.Windows.Forms.TextBox txt_TMin;
        private System.Windows.Forms.TextBox txt_THour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnQuickToTime;
        private System.Windows.Forms.ToolStripMenuItem shutdownCancelMenuItem;
    }
}

