using SMT.ServiceInstance;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SMT
{
    public partial class frmTokusai : Form
    {
        public frmTokusai()
        {
            InitializeComponent();
        }
        public frmTokusai(string upn)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            var bcTokusai = SingletonHelper.UsapInstance.GetBcTokusai(upn);
            if (bcTokusai != null)
            {
                var source = SingletonHelper.ErpInstance.FindTokusai(bcTokusai.EM_NO, bcTokusai.PART_FM, bcTokusai.PART_TO);
                this.dataGridView1.DataSource = source.OrderBy(r => r.PRODUCT_ID).ToList();
                this.lblRows.Text = $"{source.Count()} rows";
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var data = dataGridView1.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }
    }
}
