using SMT.DAL;
using SMT.ServiceInstance;
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
    public partial class frmLineAddOrUpdate : Form
    {
        Repository repository = new Repository();
        public frmLineAddOrUpdate()
        {
            InitializeComponent();
        }
        public frmLineAddOrUpdate(string lineID)
        {
            InitializeComponent();
            var entity = repository.GetLineSetting(lineID);
            if (entity != null)
            {
                this.txtLineID.Text = entity.LINE_ID;
                this.feederSpec.Value = Convert.ToDecimal(entity.FEEDER_DAY_USE);
                this.chkFeeder.Checked = Convert.ToBoolean(entity.IS_CHECK_FEEDER);
                this.chkReload.Checked = Convert.ToBoolean(entity.IS_CHECK_RELOAD);
                this.chkTokusai.Checked = (bool)entity.IS_CONFIRM_TOKUSAI;
                this.cbVerify.Checked = (bool)entity.IS_CHECK_VERIFY;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LineSetting lineInfo = new LineSetting()
            {
                LINE_ID = txtLineID.Text.Trim(),
                FEEDER_DAY_USE = Convert.ToInt32(feederSpec.Value),
                IS_CHECK_FEEDER = chkFeeder.Checked,
                IS_CHECK_RELOAD = chkReload.Checked,
                IS_CONFIRM_TOKUSAI = chkTokusai.Checked,
                IS_CHECK_VERIFY = cbVerify.Checked,
                UPDATE_TIME = SingletonHelper.GetDateTime(),
                UPDATER = $"{Program._user.ID}-{Program._user.NAME}"
            };
            bool save = repository.LineAddOrUpdate(lineInfo);
            if (save)
            {
                MessageBox.Show("Save Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save Errors", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
