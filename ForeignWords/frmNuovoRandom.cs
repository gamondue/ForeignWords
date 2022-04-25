using System;
using System.Windows.Forms;

namespace gamon.ForeignWords
{
    public partial class frmNuovoRandom : Form
    {
        public frmNuovoRandom()
        {
            InitializeComponent();
            Global.caricaLinguaInControlli(this);
            rdRandom.Checked = true;
        }
        Random rnd;
        public Random RandomSeq {
            get { return rnd; }
        }
        bool mescola = false;
        public bool DeveMescolare
        {
            get { return mescola; }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdDeterminata.Checked)
            {
                rnd = new Random(int.Parse(txtSeme.Text));
            }
            if (rdRandom.Checked)
            {
                rnd = new Random();
            }
            if (rdNulla.Checked)
            {
                rnd = new Random(1);
            }   
            this.Close();
        }
        private void frmNuovoRandom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                object s = null;
                EventArgs ev = null;
                btnOK_Click(s, ev);
            }
        }
        private void rdRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRandom.Checked)
            {
                mescola = true;
                txtSeme.Enabled = false;
            }
        }
        private void rdDeterminata_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDeterminata.Checked)
            {
                mescola = true;
                txtSeme.Enabled = true;
                txtSeme.Focus();
            }
        }
        private void rdNulla_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNulla.Checked)
            {
                mescola = false;
                txtSeme.Enabled = false;
            }
        }
        private void frmNuovoRandom_Load(object sender, EventArgs e)
        {
            rdRandom.Checked = true;
        }
    }
}