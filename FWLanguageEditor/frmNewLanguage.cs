using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gamon.ForeignWords
{
    public partial class frmNewLanguage : Form
    {
        public frmNewLanguage(ref string NewLanguage)
        {
            InitializeComponent();
            txtNewLanguage.Text = NewLanguage; 
        }

        public frmNewLanguage()
        {
            InitializeComponent();
            // TODO: Complete member initialization
            // CONTROLLARE SE SERVE
        }
        private void frmNewLanguage_Load(object sender, EventArgs e)
        {

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Please check carefully the spelling of the new languages' name!\nIs it correct?",
                    "Caution!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (r == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
