using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace KimCommander {
    public partial class QuickStartForm : Form {
        private bool mExecuted = false;
        private string mCurComboText = "";
        private MainForm mParentForm;
        private List<QuickStartItem> mCurComboboxItems = new List<QuickStartItem>();
        private QuickStartItem mLastSelectedItem = null;
        private bool mSkipTextInputChangedEvent = false;

        private QuickStartForm() {
            InitializeComponent();
        }

        public QuickStartForm(MainForm mainForm) {
            InitializeComponent();
            mParentForm = mainForm;
        }

        private void btn_Execute_Click(object sender, EventArgs e) {
            if (mExecuted == false) {
                if (mLastSelectedItem != null) {
                    btn_Execute.Text = "Launching";
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

        private List<QuickStartItem> findDBbyText(string text) {
            List<QuickStartItem> result = new List<QuickStartItem>();
            List<QuickStartItem> items = DataManager.getQuickStartItems();
            var reg = new Regex("[*'\",_&#^@]");
            var queryText = reg.Replace(text, string.Empty);

            int textLen = text.Length;
            if (items == null || items.Count == 0) return result;
            var addedDict = new Dictionary<string, string>();
            foreach (var item in items.ToArray()) {
                var shortName = item.ShortName;
                if (shortName.Length >= textLen && Regex.IsMatch(shortName, text, RegexOptions.IgnoreCase)) {
                    result.Add(item);
                    addedDict.Add(shortName, shortName);
                }
            }
            // add contain list
            foreach(var item in items.ToArray()) {
                var shortName = item.ShortName;
                if (!addedDict.ContainsKey(shortName)) {
                    if (shortName.Constains(queryText)) {
                        result.Add(item);
                    }
                }
            }            
            return result;
        }

        private void refreshComboInputDropList(List<QuickStartItem> matchItems) {
            mCurComboText = comboInput.Text;
            comboInput.Items.Clear();
            mCurComboboxItems.Clear();

            if (matchItems.Count > 0) {
                foreach (QuickStartItem item in matchItems.ToArray()) {
                    comboInput.Items.Add(item.ShortName + " - " + item.Name);
                    mCurComboboxItems.Add(item);
                }
                mLastSelectedItem = mCurComboboxItems[0];
                updateStartAppInfo();
                comboInput.DroppedDown = true;
                comboInput.SelectedIndex = 0;
            } else {
                comboInput.Items.Add("");
            }
        }

        private void comboInput_SelectedValueChanged(object sender, EventArgs e) {
            if (comboInput.Items.Count > 0 && comboInput.SelectedIndex >= 0 && mCurComboboxItems.Count > 0) {
                mLastSelectedItem = mCurComboboxItems[comboInput.SelectedIndex];
                updateStartAppInfo();
                mCurComboText = mLastSelectedItem.ShortName + "-" + mLastSelectedItem.Name;
            }
        }

        private void updateStartAppInfo() {
            if (mLastSelectedItem != null) {
                lb_execute_name.Text = mLastSelectedItem.Name;
                if (Utils.checkIconFileExit(mLastSelectedItem.ShortName) == false) {
                    Utils.makeIconCacheFile(Utils.getIconFromAppPath(mLastSelectedItem.FilePath), mLastSelectedItem.ShortName);
                }
                pictureBox_Execute.Image = Bitmap.FromHicon(Utils.getIconCache(mLastSelectedItem.ShortName).Handle);
            }
        }

        private void QuickStartForm_Load(object sender, EventArgs e) {
            this.Activate();
        }

        private void comboInput_SelectionChangeCommitted(object sender, EventArgs e) {
            if (comboInput.SelectedIndex >= 0 && comboInput.SelectedIndex <= mCurComboboxItems.Count) {
                mLastSelectedItem = mCurComboboxItems[comboInput.SelectedIndex];
            }
            updateStartAppInfo();
            mCurComboText = mLastSelectedItem.ShortName + "-" + mLastSelectedItem.Name;
            comboInput.Text = mCurComboText;
        }

        private void QuickStartForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            e.Cancel = true;
        }

        private void QuickStartForm_VisibleChanged(object sender, EventArgs e) {
            if (this.Visible) {
                mSkipTextInputChangedEvent = true;
                txtInput.Text = "";
                this.ActiveControl = txtInput;
            }
        }

        private void btn_showMain_Click(object sender, EventArgs e) {
            if (mParentForm.Visible == false) {
                mParentForm.showMainSettingForm();
            }
        }

        private void QuickStartForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void comboInput_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboInput.Items.Count > 0) {
                var index = comboInput.SelectedIndex;
                comboInput.Text = comboInput.Items[index].ToString();
            }
        }

        private void QuickStartForm_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void QuickStartForm_DragDrop(object sender, DragEventArgs e) {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (filePaths.Length > 0) {
                string filePath = filePaths[0];
                if (Path.HasExtension(filePath)) {
                    mParentForm.addQuickItemDataToListView(Path.GetFileNameWithoutExtension(filePath), filePath,
                        mParentForm.findProperShortName(Path.GetFileNameWithoutExtension(filePath)), "", "", false);
                } else {
                    mParentForm.addQuickItemDataToListView(new DirectoryInfo(filePath).Name, filePath,
                        mParentForm.findProperShortName(new DirectoryInfo(filePath).Name), "", "", false);
                }
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e) {
            if (mSkipTextInputChangedEvent) {
                mSkipTextInputChangedEvent = false;
                return;
            }
            refreshComboInputDropList(findDBbyText(txtInput.Text));
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Up:
                case Keys.Down: {
                        if (comboInput.Items.Count > 0) {
                            var curIndex = comboInput.SelectedIndex;
                            var maxIndex = comboInput.Items.Count;

                            var nextIndex = curIndex - 1;
                            if (e.KeyCode == Keys.Down) {
                                nextIndex = curIndex + 1;
                            }
                            if (nextIndex < maxIndex && nextIndex >= 0) {
                                comboInput.SelectedIndex = nextIndex;
                            }
                        }
                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.Enter:
                    comboInput.DroppedDown = false;
                    if (mLastSelectedItem != null) {
                        btn_Execute_Click(null, null);
                    }
                    break;
                case Keys.Escape:
                    comboInput.DroppedDown = false;
                    Close();
                    break;
                default: {
                        if (mExecuted) {
                            mExecuted = false;
                            btn_Execute.Text = "Launch";
                        }
                    }
                    break;
            }
        }
    }    
}
