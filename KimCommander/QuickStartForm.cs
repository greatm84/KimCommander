using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace KimCommander
{
    public partial class QuickStartForm : Form
    {
        private bool mExecuted = false;
        private String mCurComboText = "";
        private MainForm mParentForm;
        private List<QuickStartItem> mCurComboboxItems = new List<QuickStartItem>();
        private QuickStartItem mLastSelectedItem = null;

        private QuickStartForm()
        {
            InitializeComponent();                 
        }

        public QuickStartForm(MainForm mainForm)
        {
            InitializeComponent();
            mParentForm = mainForm;
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            if (mExecuted == false)
            {
                if (mLastSelectedItem != null)
                {                    
                    btn_Execute.Text = "실행중";
                    updateStartAppInfo();
                    mCurComboText = mLastSelectedItem.ShortName + "-" + mLastSelectedItem.Name;
                    Utils.sendWindCommand(mLastSelectedItem.PreCommand);
                    Utils.LaunchApp(mLastSelectedItem.FilePath, mLastSelectedItem.Arguments, mLastSelectedItem.RunAdmin);
                    this.Invalidate();
                    mExecuted = true;                    
                    Close();
                }                
            }
        }

        private List<QuickStartItem> findDBbyText(String text)
        {
            List<QuickStartItem> result = new List<QuickStartItem>();
            List<QuickStartItem> items = DataManager.getQuickStartItems();
            int textLen = text.Length;
            if (items == null) return result;
            foreach (QuickStartItem item in items.ToArray())
            {
                if (item.ShortName.Length >= textLen && Regex.IsMatch(item.ShortName,text,RegexOptions.IgnoreCase))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private void refreshComboInputDropList(List<QuickStartItem> matchItems)
        {
            mCurComboText = comboInput.Text;
            comboInput.Items.Clear();
            mCurComboboxItems.Clear();
            String inputText = comboInput.Text;            
            if (matchItems.Count > 0)
            {
                foreach (QuickStartItem item in matchItems.ToArray())
                {
                    comboInput.Items.Add(item.ShortName + " - " + item.Name);
                    mCurComboboxItems.Add(item);
                }
                mLastSelectedItem = mCurComboboxItems[0];
                updateStartAppInfo();
                comboInput.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }else
            {
                comboInput.Items.Add("");
            }
            comboInput.Text = mCurComboText;
            comboInput.SelectionStart = comboInput.Text.Length;
        }

        private void comboInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mLastSelectedItem != null)
                {
                    btn_Execute_Click(null, null);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else
            {
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                    (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || e.KeyCode == Keys.Back)
                {
                    refreshComboInputDropList(findDBbyText(comboInput.Text));
                }
                if (mExecuted)
                {
                    mExecuted = false;
                    btn_Execute.Text = "실행";
                }
            }
        }

        private void comboInput_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboInput.Items.Count > 0 && comboInput.SelectedIndex >= 0 && mCurComboboxItems.Count > 0)
            {
                mLastSelectedItem = mCurComboboxItems[comboInput.SelectedIndex];
                updateStartAppInfo();
                mCurComboText = mLastSelectedItem.ShortName + "-" + mLastSelectedItem.Name;
            }
        }

        private void updateStartAppInfo()
        {
            if (mLastSelectedItem != null)
            {
                lb_execute_name.Text = mLastSelectedItem.Name;    
                if(Utils.checkIconFileExit(mLastSelectedItem.ShortName)==false)
                {
                    Utils.makeIconCacheFile(Utils.getIconFromAppPath(mLastSelectedItem.FilePath), mLastSelectedItem.ShortName);
                }
                pictureBox_Execute.Image = Bitmap.FromHicon(Utils.getIconCache(mLastSelectedItem.ShortName).Handle);
            }            
        }

        private void QuickStartForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            //comboInput.Focus();
        }

        private void comboInput_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboInput.SelectedIndex >= 0 && comboInput.SelectedIndex <= mCurComboboxItems.Count)
            {
                mLastSelectedItem = mCurComboboxItems[comboInput.SelectedIndex];
            }
            updateStartAppInfo();
            mCurComboText = mLastSelectedItem.ShortName + "-" + mLastSelectedItem.Name;
        }

        private void QuickStartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void QuickStartForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                comboInput.Text = "";
                this.ActiveControl = comboInput;
            }
        }

        private void btn_showMain_Click(object sender, EventArgs e)
        {
            if (mParentForm.Visible == false)
            {
                mParentForm.showMainSettingForm();
            }
        }

        private void QuickStartForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void comboInput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuickStartForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void QuickStartForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(filePaths.Length > 0)
            {
                string filePath = filePaths[0];
                if (Path.HasExtension(filePath))
                {
                    mParentForm.addQuickItemDataToListView(Path.GetFileNameWithoutExtension(filePath), filePath,
                        mParentForm.findProperShortName(Path.GetFileNameWithoutExtension(filePath)), "", "", false);
                }
                else
                {
                    mParentForm.addQuickItemDataToListView(new DirectoryInfo(filePath).Name, filePath,
                        mParentForm.findProperShortName(new DirectoryInfo(filePath).Name), "", "", false);
                }
            }
        }
    }
}
