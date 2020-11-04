using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimCommander
{
    public partial class SettingForm : Form
    {
        KeyboardHook mKeyBoardHook;        
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        public SettingForm(KeyboardHook keyboard)
        {
            InitializeComponent();
            mKeyBoardHook = keyboard;
        }

        private void chk_regApp_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_regApp.Checked)
            {
                if (registryKey.GetValue(Define.APP_NAME) == null)
                {
                    registryKey.SetValue(Define.APP_NAME, Application.ExecutablePath.ToString());
                }
            }
            else
            {
                if (registryKey.GetValue(Define.APP_NAME) != null)
                {
                    registryKey.DeleteValue(Define.APP_NAME, false);
                }
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (registryKey.GetValue(Define.APP_NAME) == null)
            {
                chk_regApp.Checked = false;
            }
            else
            {
                chk_regApp.Checked = true;
            }

            comboBox_modifier.Text = SettingDatas.getInst().getModifierKeysbyComboValue();
            comboBoxHotkey.Text = SettingDatas.getInst().hotkey.ToString();
        }

        private void btn_hotkeySet_Click(object sender, EventArgs e)
        {            
            SettingDatas.getInst().setModifierKeysByComboValue(comboBox_modifier.Text);
            SettingDatas.getInst().hotkey = Utils.EnumConv<Keys>.Parse(comboBoxHotkey.Text);
            mKeyBoardHook.RegisterHotKey(SettingDatas.getInst().ModifierKeys, SettingDatas.getInst().hotkey);
            DataManager.saveDatas();
        }

        private void SettingForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
