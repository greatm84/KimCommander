using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimCommander
{    
    public partial class MainForm : Form
    {
        private const String homePageLink = "http://kaltok84.tistory.com/category/%EC%B7%A8%EB%AF%B8%EB%A1%9C%ED%95%98%EB%8A%94%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%B0%8D";
        KeyboardHook hook = new KeyboardHook();
        QuickStartForm mQuickItemForm;
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used
        Timer mainTimer = null;
        List<TimeItem> mTimeItems = null;
        List<QuickStartItem> mQuickItems = null;
        AutoShutDownItem mAutoShutDownItem = null;
        ImageList mQuickItemImageList = new ImageList();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "김커맨더입니다 (" + Utils.getAppVersion() + ") : kaltok84@gmail.com";
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            this.shutdownCancelMenuItem.Click += shutdownCancleMenuItem_Click;
            this.showtoolStripMenuItem.Click += showToolStripMenuItem_Click;
            this.exittoolStripMenuItem.Click += exitToolStripMenuItem_Click;

            groupBoxQuickItem.AllowDrop = true;
            groupBoxTimeItem.AllowDrop = true;

            mQuickItemForm = new QuickStartForm(this);

            mTimeItems = DataManager.getTimeItems();
            mQuickItems = DataManager.getQuickStartItems();
            mAutoShutDownItem = DataManager.getAutoShutdownItem();
            listViewQuickItem.SmallImageList = mQuickItemImageList;
            refreshListView();

            // timer 생성
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 1000; // 1sec
            mainTimer.Tick += new EventHandler(timer_Tick);
            mainTimer.Start();


            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + T combination as hot key.
            hook.RegisterHotKey(SettingDatas.getInst().ModifierKeys,
                SettingDatas.getInst().hotkey);
        }

        private void refreshListView()
        {
            refreshListViewTimeItem();
            refreshListViewQuickStartItems();
        }

        private void refreshListViewTimeItem()
        {
            listViewTimeItem.Items.Clear();
            if (mTimeItems != null & mTimeItems.Count > 0)
            {
                foreach (TimeItem item in mTimeItems.ToArray())
                {
                    ListViewItem lvItem = new ListViewItem(item.Name);                    
                    lvItem.SubItems.Add(item.Type.ToString());
                    lvItem.SubItems.Add(item.TimeEventType.ToString());                    
                    lvItem.SubItems.Add(item.Hour.ToString());
                    lvItem.SubItems.Add(item.Minute.ToString());
                    lvItem.SubItems.Add(item.Second.ToString());
                    lvItem.SubItems.Add(item.Param1.ToString());
                    lvItem.SubItems.Add(item.Param2.ToString());
                    lvItem.SubItems.Add(item.RunAdmin.ToString());
                    lvItem.SubItems.Add(item.AfterCheck.ToString());                    
                    listViewTimeItem.Items.Add(lvItem);
                }
            }
        }

        private void refreshListViewQuickStartItems()
        {
            listViewQuickItem.Items.Clear();
            mQuickItemImageList.Images.Clear();

            if (mQuickItems != null & mQuickItems.Count > 0)
            {
                int imageIndex = 0;
                foreach (QuickStartItem item in mQuickItems.ToArray())
                {
                    if (Utils.checkIconFileExit(item.ShortName) == false)
                    {
                        Utils.makeIconCacheFile(Utils.getIconFromAppPath(item.FilePath), item.ShortName);
                    }
                    mQuickItemImageList.Images.Add(Utils.getIconCache(item.ShortName));
                    ListViewItem lvItem = new ListViewItem(item.Name,imageIndex);
                    lvItem.SubItems.Add(item.FilePath);
                    lvItem.SubItems.Add(item.ShortName);
                    lvItem.SubItems.Add(item.Arguments);
                    lvItem.SubItems.Add(item.RunAdmin.ToString());
                    lvItem.SubItems.Add(item.PreCommand);                    
                    listViewQuickItem.Items.Add(lvItem);
                    imageIndex++;
                }
            }
        }


        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (mQuickItemForm.Visible == false)
            {
                mQuickItemForm.Show();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();
                e.Cancel = true;
                notifyIcon.Text = "김커맨더 대기중";
            }
            base.OnFormClosing(e);
        }

        private void refreshNotifyIconText()
        {
            string statusText = "";
            if (this.Visible)
            {
                statusText = "KimCommander";
            }
            else
            {
                statusText = "KimCommander Waiting";
            }

            if (mAutoShutDownItem.alive)
            {
                statusText += "\n";
                statusText += mAutoShutDownItem.hour.ToString() + "h " + mAutoShutDownItem.min.ToString() + "m " +
                    mAutoShutDownItem.sec.ToString() + "s shutdown reserved";
                shutdownCancelMenuItem.Visible = true;
            }
            else
            {
                shutdownCancelMenuItem.Visible = false;
            }
            notifyIcon.Text = statusText;
        }

        private void shutdownCancleMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMainSettingForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mQuickItemForm.Dispose();
            allowClose = true;            
            Application.Exit();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            refreshNotifyIconText();
            if(mAutoShutDownItem != null && mAutoShutDownItem.alive)
            {
                if(mAutoShutDownItem.hour == hour && mAutoShutDownItem.min == min && mAutoShutDownItem.sec == sec)
                {
                    Utils.sendShutdownCommand(60, true);
                }
            }

            // UI 쓰레드에서 실행. 
            // UI 컨트롤 직접 엑세스 가능
            if (mTimeItems != null && mTimeItems.Count > 0)
            {
                

                foreach (TimeItem item in mTimeItems)
                {
                    if (item.Alive) {
                        if (item.AfterCheck)
                        {
                            if (item.Hour < hour ||
                                (item.Hour == hour && item.Minute < min) ||
                                (item.Hour == hour && item.Minute == min && item.Second < sec))
                            {
                                item.Alive = false;
                                switch (item.TimeEventType)
                                {
                                    case TimeItem.TIMEEVENT_TYPE.TIMEEVENT_LAUNCH_APP:
                                        timeLaunchApp(item.Param1, item.Param2, item.RunAdmin);
                                        break;
                                    case TimeItem.TIMEEVENT_TYPE.TIMEEVENT_CAPTURE:
                                        timeCaptureFunction(item.Param1, item.Param2);
                                        break;
                                }                                
                            }
                        }
                        else
                        {
                            if (item.Hour == hour && item.Minute == min && item.Second == sec)
                            {
                                item.Alive = false;
                                switch (item.TimeEventType)
                                {
                                    case TimeItem.TIMEEVENT_TYPE.TIMEEVENT_LAUNCH_APP:
                                        timeLaunchApp(item.Param1, item.Param2, item.RunAdmin);
                                        break;
                                    case TimeItem.TIMEEVENT_TYPE.TIMEEVENT_CAPTURE:
                                        timeCaptureFunction(item.Param1, item.Param2);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
                        
        }

        public void timeCaptureFunction(Object param1, Object param2)
        {
            Utils.CaptureApplication((String)param1);
        }

        public void timeLaunchApp(Object param1, Object param2, bool asAdmin)
        {
            Utils.LaunchApp((String)param1, (String)param2, asAdmin);
        }

        private void btn_ExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml File|*.xml";
            saveFileDialog.Title = "Save an Xml File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                DataManager.saveDatas(saveFileDialog.FileName);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(txt_QName.Text == ""|| txt_QFilePath.Text ==""|| txt_QShortName.Text=="")
            {
                MessageBox.Show("Argument 제외하고 빈칸없이 모두 입력해주세요");
                return;
            }            
            addQuickItemDataToListView(txt_QName.Text, txt_QFilePath.Text, 
                findProperShortName(txt_QShortName.Text),
                txt_QArgument.Text, txt_QPreCommand.Text, chk_QRunAdmin.Checked);
        }

        private bool checkExistShortName(String shortName, String skipCheckShortName)
        {
            if (shortName.Equals(skipCheckShortName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            foreach (QuickStartItem item in mQuickItems)
            {
                if (item.ShortName.Equals(skipCheckShortName, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }
                if (item.ShortName.Equals(shortName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private bool checkExistShortName(String shortName)
        {            
            return checkExistShortName(shortName,"");
        }

        public String findProperShortName(String shortName)
        {
            return findProperShortName(shortName, "");
        }

        private String findProperShortName(String shortName, String skipShortName)
        {
            int i = 0;
            String newShortName = shortName;
            while (checkExistShortName(newShortName, skipShortName))
            {
                i++;
                newShortName += i.ToString();
            }
            if (i > 0)
            {
                MessageBox.Show("동일한 shorName이 있어 \"" + newShortName + " \"으로 변경됩니다");
            }
            return newShortName;
        }

        public void addQuickItemDataToListView(String name, String filePath, String shortName, String argument, String preCommand, bool asAdmin)
        {
            mQuickItems.Add(new QuickStartItem(name, filePath, shortName, argument, preCommand, asAdmin));
            if (Utils.checkIconFileExit(shortName) == false)
            {
                Utils.makeIconCacheFile(Utils.getIconFromAppPath(filePath), shortName);
            }
            mQuickItemImageList.Images.Add(Utils.getIconCache(shortName));
            ListViewItem lvItem = new ListViewItem(name, mQuickItemImageList.Images.Count - 1);
            lvItem.SubItems.Add(filePath);
            lvItem.SubItems.Add(shortName);
            lvItem.SubItems.Add(argument);
            lvItem.SubItems.Add(preCommand);
            lvItem.SubItems.Add(asAdmin.ToString());
            listViewQuickItem.Items.Add(lvItem);
            DataManager.saveDatas();
        }

        public void addTimeItemDataToListView(String name, String filePath, String shortName, String argument, String preCommand, bool asAdmin)
        {
            mQuickItems.Add(new QuickStartItem(name, filePath, shortName, argument, preCommand, asAdmin));
            if (Utils.checkIconFileExit(shortName) == false)
            {
                Utils.makeIconCacheFile(Utils.getIconFromAppPath(filePath), shortName);
            }
            mQuickItemImageList.Images.Add(Utils.getIconCache(shortName));
            ListViewItem lvItem = new ListViewItem(name, mQuickItemImageList.Images.Count - 1);
            lvItem.SubItems.Add(filePath);
            lvItem.SubItems.Add(shortName);
            lvItem.SubItems.Add(argument);
            lvItem.SubItems.Add(preCommand);
            lvItem.SubItems.Add(asAdmin.ToString());
            listViewQuickItem.Items.Add(lvItem);
            DataManager.saveDatas();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (listViewQuickItem.SelectedIndices.Count > 0)
            {
                int curIndex = listViewQuickItem.SelectedIndices[0];
                listViewQuickItem.Items.RemoveAt(curIndex);
                mQuickItemImageList.Images.RemoveAt(curIndex);
                Utils.deleteIconCacheFile(mQuickItems[curIndex].ShortName);
                mQuickItems.RemoveAt(curIndex);                
                refreshListViewQuickStartItems();
                DataManager.saveDatas();
            }
        }

        private void btn_Mod_Click(object sender, EventArgs e)
        {                     
            if (txt_QName.Text == "" || txt_QFilePath.Text == "" || txt_QShortName.Text == "")
            {
                MessageBox.Show("Argument 제외하고 빈칸없이 모두 입력해주세요");
                return;
            }            
            if (listViewQuickItem.SelectedIndices.Count > 0)
            {
                int curIndex = listViewQuickItem.SelectedIndices[0];
                QuickStartItem item = mQuickItems[curIndex];

                if (Utils.checkIconFileExit(item.ShortName))
                {
                    mQuickItemImageList.Images[curIndex].Dispose();
                    Utils.deleteIconCacheFile(item.ShortName);
                }

                item.Name = txt_QName.Text;
                item.FilePath = txt_QFilePath.Text;
                item.ShortName = findProperShortName(txt_QShortName.Text, item.ShortName);
                item.Arguments = txt_QArgument.Text;
                item.PreCommand = txt_QPreCommand.Text;
                item.RunAdmin = chk_QRunAdmin.Checked;
                Utils.makeIconCacheFile(Utils.getIconFromAppPath(item.FilePath), item.ShortName);
                mQuickItemImageList.Images[curIndex] = Utils.getIconCache(item.ShortName).ToBitmap();
                refreshListViewQuickStartItems();
                DataManager.saveDatas();
            }
        }

        private void groupBoxQuickItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void droppedQuickItem(String[] filePaths)
        {
            if (filePaths.Length > 0)
            {
                String filePath = filePaths[0];
                if (Path.HasExtension(filePath))
                {
                    // 실행파일이다
                    txt_QFilePath.Text = filePath;
                    txt_QName.Text = Path.GetFileNameWithoutExtension(filePath);
                    txt_QArgument.Text = "";
                    txt_QShortName.Text = Path.GetFileNameWithoutExtension(filePath);
                    chk_QRunAdmin.Checked = false;
                }
                else
                {
                    // 폴더다
                    txt_QFilePath.Text = filePath;
                    txt_QName.Text = new DirectoryInfo(filePath).Name;
                    txt_QArgument.Text = "";
                    txt_QShortName.Text = new DirectoryInfo(filePath).Name;
                    chk_QRunAdmin.Checked = false;
                }
            }
        }

        private void droppedTimeItem(String[] filePaths)
        {
            if (filePaths.Length > 0)
            {
                String filePath = filePaths[0];
                if (Path.HasExtension(filePath))
                {
                    // 실행파일이다
                    txt_TFilePath.Text = filePath;
                    txt_TName.Text = Path.GetFileNameWithoutExtension(filePath);
                    
                    txt_TArgument.Text = "";
                    txt_THour.Text = "7";
                    txt_TMin.Text = "0";
                    txt_TSec.Text = "0";
                    chk_TAdmin.Checked = false;;
                    chk_TNextBoot.Checked = true;
                    chk_TAfter.Checked = false;
                }
                else
                {
                    // 폴더다
                    txt_TFilePath.Text = filePath;
                    txt_TName.Text = new DirectoryInfo(filePath).Name;                    

                    txt_TArgument.Text = "";
                    txt_THour.Text = "7";
                    txt_TMin.Text = "0";
                    txt_TSec.Text = "0";
                    chk_TAdmin.Checked = false; ;
                    chk_TNextBoot.Checked = true;
                    chk_TAfter.Checked = false;
                }
            }
        }

        private void groupBoxQuickItem_DragDrop(object sender, DragEventArgs e)
        {
            String[] filePaths = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            droppedQuickItem(filePaths);
        }

        public void showMainSettingForm()
        {            
            allowVisible = true;

            Show();
            refreshNotifyIconText();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            showMainSettingForm();
        }        

        private void listViewQuickItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewQuickItem.SelectedIndices.Count > 0)
            {
                int curIndex = listViewQuickItem.SelectedIndices[0];
                ListViewItem lvItem = listViewQuickItem.SelectedItems[0];
                txt_QName.Text = lvItem.Text;
                txt_QFilePath.Text = lvItem.SubItems[1].Text;
                txt_QShortName.Text = lvItem.SubItems[2].Text;
                txt_QArgument.Text = lvItem.SubItems[3].Text;                                
                chk_QRunAdmin.Checked = lvItem.SubItems[4].Text.Equals("true", StringComparison.InvariantCultureIgnoreCase) ? true : false;
                txt_QPreCommand.Text = lvItem.SubItems[5].Text;
            }
        }        

        private void listViewQuickItem_DragDrop(object sender, DragEventArgs e)
        {
            String[] filePaths = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            if (filePaths.Length > 0)
            {
                String filePath = filePaths[0];
                if (Path.HasExtension(filePath))
                {                    
                    addQuickItemDataToListView(Path.GetFileNameWithoutExtension(filePath), filePath,
                        findProperShortName(Path.GetFileNameWithoutExtension(filePath)), "","", false);
                }
                else
                {                                        
                    addQuickItemDataToListView(new DirectoryInfo(filePath).Name, filePath, 
                        findProperShortName(new DirectoryInfo(filePath).Name), "","", false);
                }
            }            
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            SettingForm settingform = new SettingForm(hook);
            settingform.ShowDialog();
        }

        private void listViewQuickItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }        

        private void btn_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "XmlFiles(*.xml)|*.xml";            
            open.Title = "Import 할 파일을 선택해 주십시오";

            if (open.ShowDialog() == DialogResult.OK)
            {
                //this.txt_Filepath.Text = open.FileName;
                if (FileManager.getInst().CheckXmlFile(open.FileName))
                {
                    FileManager.getInst().LoadXmlFile(open.FileName, mTimeItems, mQuickItems);
                    refreshListView();
                    DataManager.saveDatas();
                }
                else
                {
                    MessageBox.Show("올바른 파일이 아닙니다");
                }
            }
        }

        private void btn_HomePage_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(homePageLink);
            }
            catch
            {

            }
        }

        private void btn_TimeAdd_Click(object sender, EventArgs e)
        {
            if (txt_TName.Text == "" || txt_TFilePath.Text == "")
            {
                MessageBox.Show("Need Name, FilePath");
                return;
            }
            addTimeItemDataToListView(txt_TName.Text, txt_TFilePath.Text, txt_TArgument.Text, txt_TPrecommand.Text,
                Convert.ToInt16(txt_THour.Text), Convert.ToInt16(txt_TMin.Text), Convert.ToInt16(txt_TSec.Text)
                , chk_TAdmin.Checked, chk_TNextBoot.Checked, chk_TAfter.Checked);
        }

        private void btn_TimeDel_Click(object sender, EventArgs e)
        {
            if(listViewTimeItem.SelectedIndices.Count > 0)
            {
                DataManager.getTimeItems().RemoveAt(listViewTimeItem.SelectedIndices[0]);
                DataManager.saveDatas();
                refreshListViewTimeItem();
            }
        }

        private void btn_TimeMod_Click(object sender, EventArgs e)
        {
            if (txt_TName.Text == "" || txt_TFilePath.Text == "")
            {
                MessageBox.Show("Need Name, FilePath");
                return;
            }
            if(listViewTimeItem.SelectedIndices.Count > 0)
            {
                int curIndex = listViewTimeItem.SelectedIndices[0];
                TimeItem item = mTimeItems[curIndex];
                item.Name = txt_TName.Text;
                item.Param1 = txt_TFilePath.Text;
                item.Param2 = txt_TArgument.Text;
                item.Hour = Convert.ToInt16(txt_THour.Text);
                item.Minute = Convert.ToInt16(txt_TMin.Text);
                item.Second = Convert.ToInt16(txt_TSec.Text);
                item.RunAdmin = chk_TAdmin.Checked;
                item.Alive = !chk_TNextBoot.Checked;
                item.AfterCheck = chk_TAfter.Checked;

                refreshListViewTimeItem();
                DataManager.saveDatas();
            }
        }

        private void btnAutoShutdown_Click(object sender, EventArgs e)
        {

        }

        private void listViewTimeItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewTimeItem.SelectedIndices.Count > 0)
            {
                TimeItem item = mTimeItems[listViewTimeItem.SelectedIndices[0]];
                txt_TName.Text = item.Name;
                txt_TFilePath.Text = item.Param1.ToString();
                txt_TArgument.Text = item.Param2.ToString();
                txt_TPrecommand.Text = "";
                txt_THour.Text = item.Hour.ToString();
                txt_TMin.Text = item.Minute.ToString();
                txt_TSec.Text = item.Second.ToString();
                chk_TAdmin.Checked = item.RunAdmin;
                chk_TAfter.Checked = item.AfterCheck;
                chk_TNextBoot.Checked = item.Alive;
            }
        }        

        private void listViewTimeItem_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(filePaths.Length > 0)
            {
                string filePath = filePaths[0];
                if (Path.HasExtension(filePath))
                {
                    addTimeItemDataToListView(Path.GetFileNameWithoutExtension(filePath), filePath
                        , "", "", 7, 0, 0, false, true, false);
                }
                else
                {
                    addTimeItemDataToListView(new DirectoryInfo(filePath).Name, filePath, "", "", 7, 0, 0, false, true, false);
                }
            }
        }

        private void listViewTimeItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void groupBoxTimeItem_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void groupBoxTimeItem_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            droppedTimeItem(filePaths);
        }

        private void addTimeItemDataToListView(string name, string filePath, string argument, string preCommand,
            int hour, int min, int sec, bool asAdmin, bool nextBootApply, bool afterCheck)
        {
            mTimeItems.Add(new TimeItem(name, TimeItem.TIMEITEM_TYPE.TIMEITEM_AT_TIME, afterCheck, hour, min, sec, TimeItem.TIMEEVENT_TYPE.TIMEEVENT_LAUNCH_APP,
                filePath, argument, Utils.getTimeStamp(), asAdmin));
            ListViewItem lvItem = new ListViewItem(name);
            lvItem.SubItems.Add(TimeItem.TIMEITEM_TYPE.TIMEITEM_AT_TIME.ToString());
            lvItem.SubItems.Add(TimeItem.TIMEEVENT_TYPE.TIMEEVENT_LAUNCH_APP.ToString());
            lvItem.SubItems.Add(hour.ToString());
            lvItem.SubItems.Add(min.ToString());
            lvItem.SubItems.Add(sec.ToString());
            lvItem.SubItems.Add(filePath);
            lvItem.SubItems.Add(argument);
            lvItem.SubItems.Add(asAdmin.ToString());
            lvItem.SubItems.Add(afterCheck.ToString());
            listViewTimeItem.Items.Add(lvItem);
            DataManager.saveDatas();
        }

        private void btnQuickToTime_Click(object sender, EventArgs e)
        {
            if(listViewQuickItem.SelectedIndices.Count > 0)
            {
                int curIndex = listViewQuickItem.SelectedIndices[0];
                QuickStartItem item = mQuickItems[curIndex];
                addTimeItemDataToListView(item.Name, item.FilePath, item.Arguments, item.PreCommand, 7, 0, 0, item.RunAdmin, true, false);
            }
        }

        private void makeRightClickContextMenu(Control control, int x, int y, Action action)
        {
            ContextMenu m = new ContextMenu();
            MenuItem m1 = new MenuItem();
            m1.Text = "Show in Explorer";
            m1.Click += (senders, es) =>
            {
                action();
            };
            m.MenuItems.Add(m1);
            m.Show(control, new Point(x, y));
        }

        private void openItemWithExplorer(string filePath)
        {
            try
            {
                Process.Start(Path.GetDirectoryName(filePath));
            }catch(Exception e) {
                MessageBox.Show("wrong path");
            }
        }
            

        private void listViewQuickItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if(listViewQuickItem.SelectedIndices.Count > 0)
                {
                    int curIndex = listViewQuickItem.SelectedIndices[0];
                    QuickStartItem item = mQuickItems[curIndex];
                    makeRightClickContextMenu(listViewQuickItem, e.X, e.Y, () => {
                        openItemWithExplorer(item.FilePath);
                    });
                }
            }
        }

        private void listViewTimeItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (listViewTimeItem.SelectedIndices.Count > 0)
                {
                    int curIndex = listViewTimeItem.SelectedIndices[0];
                    TimeItem item = mTimeItems[curIndex];
                    makeRightClickContextMenu(listViewTimeItem, e.X, e.Y, () => {
                        openItemWithExplorer(item.Param1.ToString());
                    });
                }
            }
        }
    }
}
