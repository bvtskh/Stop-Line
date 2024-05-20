using SMT.Business;
using SMT.DAL;
using SMT.Entities;
using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMT
{
    public partial class frmConfig : Form
    {
        public void LoadDeviceNames()
        {
            cbbSerialPort.DataSource = SerialPort.GetPortNames();
            cbbSerialPort.Text = Settings.Port.PortName;
            cbbBaudrate.DataSource = new List<int>() { 9600, 14400, 19200, 38400, 57600, 115200, 128000, 134400, 161280 };
            cbbBaudrate.Text = Settings.Port.BaudRate.ToString();
            cbbDatabit.DataSource = new List<int>() { 8, 9 };
            cbbParity.DataSource = new List<string>() { "Even", "Odd", "None", "Mark", "Space" };
            cbbStopbit.DataSource = new List<double>() { 1, 2, 1.5 };
            var source = SingletonHelper.GetAllLine();
            BindingSource bs = new BindingSource();
            bs.DataSource = source;
            cbbLine.DataSource = bs;
            Default();
        }
        private void GetLineConfig()
        {
            var source = SingletonHelper.GetAllLine();
            BindingSource bs = new BindingSource();
            bs.DataSource = source;
            cbbLine.DataSource = bs;
        }
        private void GetDataMode()
        {
            txtRun.Text = Settings.DataMode.OK;
            txtStop.Text = Settings.DataMode.NG;
            txtWaring.Text = Settings.DataMode.WR;
        }
        public void LoadSetting()
        {
            CommPort com = CommPort.Instance;
            int found = 0;
            string[] portList = com.GetAvailablePorts();
            for (int i = 0; i < portList.Length; i++)
            {
                string name = portList[i];
                cbbSerialPort.Items.Add(name);
                if (name == Settings.Port.PortName)
                {
                    found = i;
                }
            }
            if (portList.Length > 0)
            {
                cbbSerialPort.SelectedIndex = found;
            }
            Int32[] baudRates = { 9600, 14400, 19200, 38400, 57600, 115200, 128000, 134400, 161280 };
            found = 0;
            for (int i = 0; i < baudRates.Length; ++i)
            {
                cbbBaudrate.Items.Add(baudRates[i].ToString());
                if (baudRates[i] == Settings.Port.BaudRate)
                    found = i;
            }
            cbbBaudrate.SelectedIndex = found;
            cbbDatabit.Items.Add("5");
            cbbDatabit.Items.Add("6");
            cbbDatabit.Items.Add("7");
            cbbDatabit.Items.Add("8");
            cbbDatabit.SelectedIndex = Settings.Port.DataBits - 5;

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                cbbParity.Items.Add(s);
            }
            cbbParity.SelectedIndex = (int)Settings.Port.Parity;

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                cbbStopbit.Items.Add(s);
            }
            cbbStopbit.SelectedIndex = (int)Settings.Port.StopBits;
            GetDataMode();
            nSleepTime.Value = Settings.RunTime.SleepTime;
            if (Settings.RunTime.Lines != null)
            {
                Settings.RunTime.Lines.ForEach(r =>
                {
                    dgvLine.Rows.Add(r);
                });

            }
            GetLineConfig();
        }
        public void Default()
        {
            cbbBaudrate.SelectedIndex = 3;
            cbbDatabit.Text = "8";
            cbbParity.Text = "None";
            cbbStopbit.Text = "1";
        }

        public frmConfig()
        {
            InitializeComponent();
        }
        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string comOK = txtRun.Text.Trim();
            string comNG = txtStop.Text.Trim();
            if (comOK == comNG)
            {
                MessageBox.Show("Tín hiệu COM không được giống nhau");
                return;
            }
            Settings.Port.PortName = cbbSerialPort.Text;
            Settings.Port.BaudRate = Int32.Parse(cbbBaudrate.Text);
            Settings.Port.DataBits = cbbDatabit.SelectedIndex + 5;
            Settings.Port.Parity = (Parity)cbbParity.SelectedIndex;
            Settings.Port.StopBits = (StopBits)cbbStopbit.SelectedIndex;
            Settings.DataMode.OK = comOK;
            Settings.DataMode.NG = comNG;
            Settings.DataMode.WR = txtWaring.Text;
            Settings.RunTime.SleepTime = Math.Max(10000, Convert.ToInt32(nSleepTime.Value));
            Settings.RunTime.Lines.Clear();

            foreach (DataGridViewRow item in dgvLine.Rows)
            {
                string line = item.Cells[0].Value.ToString();
                Settings.RunTime.Lines.Add(line);
            }
            //Ultils.WriteRegistry(path, "Lines", String.Join(",", lines.OrderBy(r => r).ToArray()));
            CommPort com = CommPort.Instance;
            com.Open();
            Settings.Write();
            MessageBox.Show("Save success!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void frmConfig_Load(object sender, EventArgs e)
        {
            //LoadDeviceNames();
            //BinDataToControls();
            LoadSetting();
        }
        private void btnTestSend_Click(object sender, EventArgs e)
        {
            CommPort com = CommPort.Instance;
            Settings.Port.PortName = cbbSerialPort.Text;
            com.Send(txtRun.Text);
            MessageBox.Show("Gửi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // SentValueToCom(txtRun.Text);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            CommPort com = CommPort.Instance;
            Settings.Port.PortName = cbbSerialPort.Text;
            com.Send(txtStop.Text);
            MessageBox.Show("Gửi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //SentValueToCom(txtStop.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lineSelect = cbbLine.Text;
            if (LineExist(dgvLine, lineSelect))
            {
                MessageBox.Show("Line exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dgvLine.Rows.Add(new string[] { lineSelect });
            }
        }
        private bool LineExist(DataGridView dgv, string line)
        {
            if (dgv.RowCount == 0)
            {
                return false;
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["clLine"].Value.ToString().Contains(line))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvLine.RowCount != 0)
            {
                int selectedRowCount = dgvLine.CurrentCell.RowIndex;
                dgvLine.Rows.RemoveAt(selectedRowCount);
            }
        }
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            cbbSerialPort.DataSource = SerialPort.GetPortNames();
        }

        private void btnWaring_Click(object sender, EventArgs e)
        {
            CommPort com = CommPort.Instance;
            Settings.Port.PortName = cbbSerialPort.Text;
            com.Send(txtWaring.Text);
            MessageBox.Show("Gửi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void lblUser_Click(object sender, EventArgs e)
        {
            if (Program._user == null)
            {
                new frmLogin().ShowDialog();
                if (Program._user != null)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        lblUser.Text = "Hi " + Program._user.NAME;
                        //grOption.Enabled = Program._isAdmin;
                    }));
                }
            }

        }
        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program._user = null;
        }
    }
}
