using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace gamon.ForeignWords
{
    public partial class frmInfinitives : Form
    {
        DataSet dSetInfinitives;
        DbDataAdapter dAdapInfinitives;
        ArrayList chkLingue = new ArrayList();
        public frmInfinitives()
        {
            InitializeComponent();
            doCheckBoxes();
        }
        private void frmInfinitives_Load(object sender, EventArgs e)
        {
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
                chk1.CheckedChanged += new System.EventHandler(chk_CheckedChanged);
                if (chk1.Name.IndexOf("English") >= 0)
                {
                    chk1.Checked = true;
                    chk1.Enabled = false;
                }
            }
        }
        private void collegaGriglia()
        {
            // DataSet e griglia
            ArrayList lingue = Global.LibDB.LinguePresenti();
            Global.LibDB.DataSetInfinitiDeiVerbi(ref dAdapInfinitives, ref dSetInfinitives);

            DataTable dtInfinitives = dSetInfinitives.Tables[0];

            boundInfinitives.DataSource = dtInfinitives;
            grdDati.DataSource = boundInfinitives;
            grdDati.Columns[0].ReadOnly = true;
            // visualizza solo le colonne che corrispondono ai check selezionati 
            foreach (CheckBox ch in chkLingue)
            {
                // la lingua Inglese non deve essere messa in 
                if (ch.Name.IndexOf("English") < 0)
                    grdDati.Columns[ch.Name.Replace("chk", "Inf")].Visible = ch.Checked;
            }
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            collegaGriglia();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false; 

            DbConnection conn = Global.LibDB.Connetti();
            DbCommand comm = conn.CreateCommand();

            if (dSetInfinitives.Tables[0].GetChanges() != null)
            {
                dAdapInfinitives.Update(dSetInfinitives);
                dSetInfinitives.Clear();
                dAdapInfinitives.Fill(dSetInfinitives);

                grdDati.Refresh();
            }
            Global.LibDB.Disconnetti();
            btnSave.Enabled = true;
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            // se sono state fatte modifiche nella tabella, avverte che così verranno perse
            if (dSetInfinitives.Tables[0].GetChanges() != null)
            {
                //TODO mettere nel database !!!!!!!!!!!!!
                if (MessageBox.Show(Global.Captions["messModifiche"].ToString(),
                                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }
    }
}
