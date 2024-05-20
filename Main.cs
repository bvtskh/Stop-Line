using SMT.Business;
using SMT.Common;
using SMT.DAL;
using SMT.Entities;
using SMT.MaterialWebService;
using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMT
{
    public partial class frmMain : Form
    {
        #region Property
        BackgroundWorker _bgMain = null;
        private Stopwatch _stopwatch = new Stopwatch();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IDictionary<State, string> dataMode;
        #endregion
        void DataModeInit()
        {
            dataMode = new Dictionary<State, string>();
            dataMode.Add(State.OK, Settings.DataMode.OK);
            dataMode.Add(State.NG, Settings.DataMode.NG);
            dataMode.Add(State.WR, Settings.DataMode.WR);
        }
        void DataGridViewShow(List<MATERIAL_VIEW> dataSource)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            dgvItem.DataSource = bs;
        }

        public void TreeViewShow()
        {
            treeView1.BeginUpdate();
            if (treeView1.Nodes.Count != 0) treeView1.Nodes.RemoveAt(0);
            treeView1.Nodes.Add("Lines");
            if (Settings.RunTime.Lines != null)
            {

                foreach (var item in Settings.RunTime.Lines.OrderBy(r => r))
                {
                    treeView1.Nodes[0].Nodes.Add(item);
                }
            }
            treeView1.EndUpdate();
        }

        // delegate used for Invoke
        internal delegate void StringDelegate(string data);
        public void OnStatusChanged(string status)
        {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnStatusChanged), new object[] { status });
                return;
            }
            lblCom.Text = status;
        }

        public frmMain()
        {
            InitializeComponent();
            Settings.Read();
            lblVersion.Text = Ultils.GetRunningVersion();
            this.dgvOrder.AutoGenerateColumns = false;
            TreeViewShow();
            DataModeInit();
            CommPort com = CommPort.Instance;
            com.StatusChanged += OnStatusChanged;
            com.Open();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        bool @start = false;
        private void treeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Level == 0 || @start)
            {
                return;
            }
            if (!@start) @start = true;
            lblStopWatch.Text = "Wait...";
            var lineId = e.Node.Text;
            var materialOrder = new Repository().GetListMaterialOrder(lineId);
            this.dgvOrder.DataSource = new List<MATERIAL_ORDERSEntity>() { materialOrder };
            var bgChoose = new BackgroundWorker();
            bgChoose.DoWork += BgChoose_DoWork;
            bgChoose.RunWorkerCompleted += BgChoose_RunWorkerCompleted;
            bgChoose.RunWorkerAsync(argument: new Tuple<string, MATERIAL_ORDERSEntity>(lineId, materialOrder));
            _stopwatch.Restart();
            _stopwatch.Start();
        }

        private void BgChoose_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var agument = (Tuple<string, MATERIAL_ORDERSEntity>)e.Argument;
                Repository repository = new Repository();
                var result = repository.GetListView(agument.Item2, agument.Item1);
                e.Result = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void BgChoose_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("Cancel");
            }
            else if (e.Error != null)
            {
                log.Error("Select Line NG", e.Error);
            }
            else
            {
                var result = e.Result as Tuple<List<MATERIAL_VIEW>, LineSetting>;
                var lineConfig = result.Item2;
                DataGridViewShow(result.Item1);

                foreach (DataGridViewRow item in dgvItem.Rows)
                {
                    if (item.Cells["IS_LOADED"].Value.ToString() != "Yes"
                        || item.Cells["Task"].Value.ToString() == TEXT.TASK_NOT_VERIFIED)
                    {
                        item.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        item.DefaultCellStyle.ForeColor = Color.Blue;
                    }

                }
                _stopwatch.Stop();
                lblStopWatch.Text = $"{(double)_stopwatch.ElapsedMilliseconds / 1000} s";
                @start = false;
            }
        }
        bool @taskRun = false;
        private void lblStart_Click(object sender, EventArgs e)
        {
            if (lblStart.ImageIndex == 3)
            {
                @taskRun = true;
                lblStart.ImageIndex = 2;
                lblSetting.Enabled = false;
                _bgMain = new BackgroundWorker();
                _bgMain.WorkerSupportsCancellation = true;
                _bgMain.DoWork += _bgMain_DoWork;
                _bgMain.RunWorkerCompleted += _bgMain_RunWorkerCompleted;
                _bgMain.RunWorkerAsync();
            }
            else
            {
                @taskRun = false;
                lblStart.ImageIndex = 3;
                lblSetting.Enabled = true;
                if (_bgMain.IsBusy) _bgMain.CancelAsync();
            }
        }

        private bool closePending;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_bgMain != null && _bgMain.IsBusy)
            {
                closePending = true;
                this.lblStart_Click(null, null);
                CommPort com = CommPort.Instance;
                com.Close();
                e.Cancel = true;
                this.Enabled = false;   // or this.Hide()
                return;
            }
            base.OnFormClosing(e);
        }

        private void _bgMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending)
            {

                Application.ExitThread();
                Application.Exit();
            }
            closePending = false;
        }

        private void _bgMain_DoWork(object sender, DoWorkEventArgs e)
        {
            CommPort com = CommPort.Instance;
            while (@taskRun)
            {
                Repository repository = new Repository();
                var lineSettings = repository.GetAllLineSetting();
                Program.FuncNG = "";
                foreach (TreeNode item in treeView1.Nodes[0].Nodes)
                {
                    if (_bgMain.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    string lineID = item.Text;
                    try
                    {
                        var lineConfig = lineSettings.FirstOrDefault(r => r.LINE_ID == lineID);
                        var materialItems = SingletonHelper.MaterialInstance.FindMaterialOrderItem(lineID);
                        Program.lineState = materialItems.Any(r => r.IS_LOADED == false) 
                            || materialItems == null ||
                            materialItems.Count() == 0 ? State.NG : State.OK;
                        var materialOrder = SingletonHelper.MaterialInstance.FindMaterialOrder(lineID);
                        SingletonHelper.SaveModel(materialOrder);
                        repository.CheckTokusai(materialItems, materialOrder);
                        repository.CheckFeeder(materialItems, lineConfig);
                        repository.CheckReload(materialOrder, lineConfig);
                        repository.CheckTokusaiConfirm(materialOrder, lineConfig);
                        repository.CheckRankLedConfirm(lineID, materialOrder);
                        repository.CheckVerifiedOrderItem(lineID, materialOrder, lineConfig);
                        LcaHelper.UpdateIOT2021(lineID, materialOrder);

                        var dataSend = $"#01{lineID}{dataMode[Program.lineState]}*";
                        com.Send(dataSend);
                        Debug.WriteLine("hhh:" + dataSend);
                        this.BeginInvoke(new Action(() =>
                        {
                            item.ImageIndex = Program.lineState != State.NG ? 1 : 4;
                            if (Program.lineState == State.NG)
                            {
                                Program.FuncNG += $"{lineID}\n";
                                tsSignalNG.Text = $"{dataSend} --- {Program.lineState}";
                                txbError.Text = Program.FuncNG;
                                Program.FuncNG += $"\n";
                              
                            }
                        }));
                    }


                    catch (Exception ex)
                    {
                        log.Error($" {lineID} - {Environment.MachineName} - {Ultils.GetRunningVersion()}", ex);
                    }
                }
                repository.Dispose();
                Thread.Sleep(Settings.RunTime.SleepTime);
            }
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            Task t = System.Threading.Tasks.Task.Factory.StartNew(new Action(() =>
            {
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Constant.USER_SHARE, Constant.PASS_SHARE);
                }

                var entity = new MachineIOT()
                {
                    HOST_NAME = Environment.MachineName,
                    LOCATION = Settings.RunTime.Lines == null ? "#NA" : String.Join(",", Settings.RunTime.Lines.ToArray()),
                    MAC_ADDRESS = NetworkHelper.GetMacAddress(Constant.URL),
                    IP_ADDRESS = Ultils.GetLocalIPAddress(),
                    USER = Environment.UserName,
                    SLEEP_TIME = Settings.RunTime.SleepTime,
                    VERSION = Ultils.GetRunningVersion(),
                    UPDATE_TIME = SingletonHelper.PVSInstance.GetDateTime(),
                    WINDOWS_EDITION = Ultils.FriendlyName(),
                    IS_WINDOWS_64 = Ultils.IsWindows64bit(),
                    //IS_WINDOWS_ACTIVE = Ultils.IsWindowsActivated()
                };
                Repository repository = new Repository();
                repository.UpdateInfo(entity);
            }));
            await t;
            Console.WriteLine("Task End");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            new frmConfig().ShowDialog();
            DataModeInit();
            TreeViewShow();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedCells.Count > 0)
            {
                var data = dgvItem.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }


        private void upnDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedCells.Count > 0)
            {

                int selectedrowindex = dgvItem.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvItem.Rows[selectedrowindex];
                string upn = Convert.ToString(selectedRow.Cells["UPN_ID"].Value);
                new frmTokusai(upn).ShowDialog();
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedCells.Count > 0)
            {
                var data = dgvOrder.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }

        bool IsShowNewVersion = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            if (Ultils.HasNewVersion() && !IsShowNewVersion)
            {
                this.BeginInvoke(new Action(() => {
                    MessageBox.Show("Có Version mới. Vui lòng mở lại phần mềm!");
                    IsShowNewVersion = true;
                    Application.Exit();
                }));
            }
        }
    }
}
