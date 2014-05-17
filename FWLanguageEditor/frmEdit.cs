using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace gamon.ForeignWords
{

    public partial class frmEdit : Form
    {
        DataSet dSetEsercizi;
        DbDataAdapter dadapCaptions;
        ArrayList chkLingue = new ArrayList();

        string newLanguage = ""; 

        public frmEdit()
        {
            InitializeComponent();
            // Global.caricaLinguaInControlli(this);

            doCheckBoxes();
            collegaGriglia();
        }

        private void doCheckBoxes()
        {
            // legge le lingue e fa i checkbox
            ArrayList lingue = Global.LibDB.LinguePresenti();
            Point punto = new Point(7, 7);
            foreach (object lingua in lingue)
            {
                chk chk1 = new chk(this.Controls, "chk" + lingua.ToString());
                chk1.Tag = lingua;
                chk1.Text = lingua.ToString();
                chk1.Location = punto;
                punto = new Point(punto.X, punto.Y + chk1.Height);
                chkLingue.Add(chk1);
                if (lingua.ToString() == "English")
                    chk1.Checked = true;
                chk1.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            }
        }

        private void collegaGriglia()
        {

            // DataSet e griglia

            ArrayList lingue = Global.LibDB.LinguePresenti();
            Point punto = new Point(7, 7);

            string lingueVisualizzate = "";
            foreach (CheckBox ch in chkLingue)
            {
                if (ch.Checked)
                    lingueVisualizzate += "'" + ch.Tag.ToString() + "',";
            }
            if (lingueVisualizzate.Length == 0) return;
            lingueVisualizzate = lingueVisualizzate.Substring(0, lingueVisualizzate.Length - 1);
            Global.LibDB.DataSetCaptionLingue(ref dadapCaptions, ref dSetEsercizi, lingueVisualizzate);

            DataTable dTCaptions = dSetEsercizi.Tables[0];

            bindCaptions.DataSource = dTCaptions;
            grdDati.DataSource = bindCaptions;
            grdDati.Columns[0].ReadOnly = true;
            //grdDati.Columns[0].Visible = false;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            DbConnection conn = Global.LibDB.Connetti();
            DbCommand comm = conn.CreateCommand();

            dadapCaptions.Update(dSetEsercizi);
            dSetEsercizi.Clear();
            dadapCaptions.Fill(dSetEsercizi);

            grdDati.Refresh();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            // se sono state fatte modifiche nella tabella, avverte che così verranno perse
            if (dSetEsercizi.Tables[0].GetChanges() != null)
            {
                if (MessageBox.Show("Changes have been made. Confirm change abortion?",
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

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            collegaGriglia();
        }

        private void btnNuova_Click(object sender, EventArgs e)
        {
            frmNewLanguage nuovo = new frmNewLanguage(ref newLanguage);

            if (nuovo.ShowDialog() == DialogResult.OK && nuovo.txtNewLanguage.Text != "")
            {
                // controlla che la nuova lingua non ci sia già 
                //TODO 

                // Inserisce la nuova lingua
                Global.LibDB.NuovaLingua(nuovo.txtNewLanguage.Text);
                doCheckBoxes();
            }
        }

        private void btnCopyDatabaseFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
        }
    }
}

