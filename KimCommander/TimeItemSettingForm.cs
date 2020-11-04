using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimCommander
{
    public partial class TimeItemSettingForm : Form
    {
        int mDataIndex = -1;        
        
        public TimeItemSettingForm()
        {
            InitializeComponent();
        }   

        public TimeItemSettingForm(int dataIndex)
        {
            mDataIndex = dataIndex;
            InitializeComponent();            
        }

        private void TimeItemSettingForm_Load(object sender, EventArgs e)
        {
            if(mDataIndex >= 0)
            {
                TimeItem itemInfo = DataManager.getTimeItems()[mDataIndex];
                String filePath = itemInfo.Param1.ToString();
                txt_FilePath.Text = filePath;
                txt_Name.Text = itemInfo.Name.Equals("") ? Path.GetFileNameWithoutExtension(txt_FilePath.Text) : itemInfo.Name;
                txt_Hour.Text = itemInfo.Hour.ToString();
                txt_Min.Text = itemInfo.Minute.ToString();
                txt_Sec.Text = itemInfo.Second.ToString();
                txt_Argument.Text = itemInfo.Param2.ToString();
                chk_after.Checked = itemInfo.AfterCheck;
                chk_Admin.Checked = itemInfo.RunAdmin;
            }            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(txt_Hour.Text.Length> 0 &&
                txt_Min.Text.Length>0 &&
                txt_Sec.Text.Length> 0 &&
                txt_FilePath.Text.Length > 0)
            {
                if(mDataIndex >= 0)
                {
                    TimeItem item = DataManager.getTimeItems()[mDataIndex];
                    item.Alive = !chk_NextBoot.Checked;
                    item.modifyTimeItem(txt_Name.Text,
                        TimeItem.TIMEITEM_TYPE.TIMEITEM_AT_TIME,
                        chk_after.Checked,
                        Convert.ToInt16(txt_Hour.Text),
                        Convert.ToInt16(txt_Min.Text),
                        Convert.ToInt16(txt_Sec.Text),
                        TimeItem.TIMEEVENT_TYPE.TIMEEVENT_LAUNCH_APP,
                        (Object)txt_FilePath.Text, (Object)txt_Argument.Text,
                        Utils.getTimeStamp(), chk_Admin.Checked);
                }
                else
                {
                    TimeItem item = new TimeItem(txt_Name.Text,
                        TimeItem.TIMEITEM_TYPE.TIMEITEM_AT_TIME,
                        chk_after.Checked,
                        Convert.ToInt16(txt_Hour.Text),
                        Convert.ToInt16(txt_Min.Text),
                        Convert.ToInt16(txt_Sec.Text),
                        TimeItem.TIMEEVENT_TYPE.TIMEEVENT_LAUNCH_APP,
                        (Object)txt_FilePath.Text, (Object)txt_Argument.Text,
                        Utils.getTimeStamp(), chk_Admin.Checked
                        );
                    item.Alive = !chk_NextBoot.Checked;
                    DataManager.getTimeItems().Add(item);
                }
                Close();
            }else
            {
                MessageBox.Show("이름,시간, 파라미터를 입력해주세요");
            }
        }

        private void TimeItemSettingForm_DragDrop(object sender, DragEventArgs e)
        {
            String[] filePaths = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            if (filePaths.Length > 0)
            {
                String filePath = filePaths[0];
                txt_FilePath.Text = filePath;
            }
        }

        private void TimeItemSettingForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
