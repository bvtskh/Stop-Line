using SMT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMT
{
    public partial class frmLineConfig : Form
    {
        private Repository _repository = new Repository();
        public void LoadSetting()
        {
            var source = _repository.GetAllLineSetting();
            dataGridView1.DataSource = source;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["clNo"].Value = i + 1;
            }
        }
        public frmLineConfig()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmLineAddOrUpdate().ShowDialog();
            LoadSetting();
        }

        private void frmLineConfig_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string lineID = selectedRow.Cells["LINE_ID"].Value.ToString();

                new frmLineAddOrUpdate(lineID).ShowDialog();
                LoadSetting();
            }
        }
    }
}
