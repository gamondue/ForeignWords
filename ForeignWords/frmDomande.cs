using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using gamon;
using gamon.ForeignWords;

namespace gamon.ForeignWords
{
    public partial class frmDomande : Form
    {
        frmVerbi mainForm;
        DataSet dSet;
        DbDataAdapter dadapVerbi;

        public frmDomande(frmVerbi mainForm)
        {
            InitializeComponent();
            Global.caricaLinguaInControlli(this);

            this.mainForm = mainForm;

            Global.LibDB.DataSetVerbi(1, ref dadapVerbi, ref dSet);  // codice 1 = esercizio di default = tutti i verbi
            DataTable dTVerbi = dSet.Tables[0];

            bindSVerbi.DataSource = dTVerbi;
            grdDati.DataSource = bindSVerbi;
            grdDati.Columns[0].ReadOnly = true;
            grdDati.Columns[0].Visible = false;
            //grdDati.Columns[5].Visible = false;
            //grdDati.Columns[6].Visible = false;

            // grdDati.DataMember = "VerbiInglesi";
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Global.LibDB.UpdateVerbi(1, ref dadapVerbi, ref dSet);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {  
            // se sono state fatte modifiche nella tabella, avverte che così verranno perse
            if (dSet.Tables[0].GetChanges() != null)
            {
                if (MessageBox.Show(Global.Captions["messModifiche"].ToString(),
                                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            this.Close(); 
        }

        private void grdDati_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EventArgs e1 = null;
            btnAbort_Click(sender, e1); 
        }
    }
}