using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gamon.ParoleInglesi
{
    public partial class frmNuovoRandom : Form
    {
        public frmNuovoRandom()
        {
            InitializeComponent();
        }

        Random rnd;

        public Random RandomSeq {
            get { return rnd; }
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
            txtSeme.Enabled = false;
        }

        private void rdDeterminata_CheckedChanged(object sender, EventArgs e)
        {
            txtSeme.Enabled = true;
            txtSeme.Focus();
        }
    }
}