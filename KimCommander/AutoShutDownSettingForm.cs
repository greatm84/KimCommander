using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimCommander {
    public partial class AutoShutDownSettingForm : Form {

        int reserveOffset = 0;
        bool reserved = false;

        public AutoShutDownSettingForm() {
            InitializeComponent();
        }

        private void btnInit_Click(object sender, EventArgs e) {
            Init();
        }

        private void btnReserve_Click(object sender, EventArgs e) {
            if(reserved == false && IsValueSet()) {
                int curHour = Convert.ToInt16(DateTime.Now.ToString("HH"));
                int curMin = Convert.ToInt16(DateTime.Now.ToString("mm"));                

                var offMin = (reserveOffset % 3600) / 60;
                var offHour = (reserveOffset / 3600);

                curHour += offHour;
                curMin += offMin;

                if(curMin > 59) {
                    curHour++;
                    curMin -= 60;
                }
                if(curHour > 23) {
                    curHour -= 23;
                }
                lbOffTime.Text = curHour.ToString() + "h" + curMin.ToString() + "m scheduled";

                SendCmd(reserveOffset, true);

                btnReserve.Text = "Cancel Reservation";
            } else {                
                Init();
            }
        }

        private void TxtTime_TextChanged(object sender, EventArgs e) {
            cbOffset.SelectedIndex = 0;
        }

        private void CbOffset_SelectedIndexChanged(object sender, EventArgs e) {
            txtHour.Text = "";
            txtMin.Text = "";
        }

        private void InitAutoShutdownReserveTime() {
            SetAutoShutdownReserveTime(false, 0, 0, 0);
        }

        private void SetAutoShutdownReserveTime(bool v1, int v2, int v3, int v4) {
            throw new NotImplementedException();
        }

        private bool IsValueSet() {
            var curHour = Convert.ToInt16(DateTime.Now.ToString("HH"));
            var curMin = Convert.ToInt16(DateTime.Now.ToString("mm"));

            if(cbOffset.SelectedIndex > 0) {
                int[] indexValues = {
                    0, // 미지정
                    300, // 5
                    600, // 10
                    1800, // 30
                    3600, // 1
                    5400, // 1 30
                    7200, // 2
                    9000, // 2 30
                    10800, // 3
                    14400, // 4
                    18000, // 5
                    21600, // 6
                    25200, // 7
                    28800 // 8
                };
                reserveOffset = indexValues[cbOffset.SelectedIndex];
                return true;
            }

            if(txtHour.Text != "" && txtMin.Text != "") {
                var hour = Convert.ToInt16(txtHour.Text);
                var min = Convert.ToInt16(txtMin.Text);

                if(hour < 0 || hour > 23) {
                    MessageBox.Show("Wrong hour");
                    return false;
                }
                if(min <0 || min > 59) {
                    MessageBox.Show("Wrong min");
                    return false;
                }

                if(curHour > hour) {
                    //다음날로
                    hour += 24;
                    MessageBox.Show("Warning! it's tomorrow");
                }
                if(curHour == hour && min < curMin) {
                    hour += 24;
                    MessageBox.Show("Warning! it's tomorrow");
                }

                reserveOffset = (hour - curHour) * 3600 + (min - curMin) * 60;

                return true;
            }

            MessageBox.Show("Somethings wrong");
            return false;
        }

        private void SendCmd(int offsetTime, bool timerOn) {
            var cmdStrOn = "-s -f -t";
            var cmdStrOff = "-a";

            var cmd = new ProcessStartInfo("ShutDown.exe");
            var process = new Process();
            if (timerOn) {
                cmd.Arguments = cmdStrOn + offsetTime.ToString();
            } else {
                cmd.Arguments = cmdStrOff;
            }

            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;
            cmd.UseShellExecute = false;
            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        private void TxtTime_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))){
                e.Handled = true;
            }
        }

        private void AutoShutDownSettingForm_Load(object sender, EventArgs e) {
            Init();
        }

        private void Init() {
            txtMin.Text = "";
            txtHour.Text = "";
            cbOffset.SelectedIndex = 0;
            lbOffTime.Text = "-";
            btnReserve.Text = "Reserve";
            reserved = false;
            SendCmd(0, false);
        }
    }
}
