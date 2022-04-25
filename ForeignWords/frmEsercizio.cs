using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gamon;
using System.Data.Common;
using gamon.ForeignWords;

namespace gamon.ForeignWords
{   
    public partial class frmEsercizio : Form
    {
        frmVerbi mainForm;
        DataSet dSetTutti;
        DataSet dSetEsercizio;
        
        DbDataAdapter dadapVerbiTutti;
        DbDataAdapter dadapVerbiEsercizio;
        int codEsercizio;

        public frmEsercizio(int CodEsercizio, string esercizio, frmVerbi mainForm)
        {
            InitializeComponent();
            Common.caricaLinguaInControlli(this);

            this.mainForm = mainForm;
            
            codEsercizio = CodEsercizio;
            txtEsercizio.Text = esercizio;

            if (CodEsercizio == 1)
            {
                MessageBox.Show(Common.Captions["messEsercizio1"].ToString());
                //MessageBox.Show("L'esercizio di codice 1 contiene tutti i verbi. Non si può modificare!");
                return;
            }

            txtCodice.Text = CodEsercizio.ToString();

            // DataSet e griglia per tutti i verbi
            Common.LibDB.DataSetVerbiCheNonCiSono(CodEsercizio, ref dadapVerbiTutti, ref dSetTutti);  // codice 1 = esercizio di default = tutti i verbi
            DataTable dTVerbiTutti = dSetTutti.Tables[0];

            bindSVerbiTutti.DataSource = dTVerbiTutti;
            grdTutti.DataSource = bindSVerbiTutti;
            grdTutti.Columns[0].ReadOnly = true;
            grdTutti.Columns[0].Visible = false;
            //grdTutti.Columns[5].Visible = false;
            //grdTutti.Columns[6].Visible = false;

            // DataSet e griglia per i verbi di questo esercizio
            Common.LibDB.DataSetVerbi(CodEsercizio, ref dadapVerbiEsercizio, ref dSetEsercizio);  // codice 1 = esercizio di default = tutti i verbi
            DataTable dTVerbiEsercizio = dSetEsercizio.Tables[0];

            bindSVerbiEsercizio.DataSource = dTVerbiEsercizio;
            grdEsercizio.DataSource = bindSVerbiEsercizio;
            grdEsercizio.Columns[0].ReadOnly = true;
            grdEsercizio.Columns[0].Visible = false;
            ////////grdEsercizio.Columns[5].Visible = false;
            ////////grdEsercizio.Columns[6].Visible = false;
        }

        public void btnDestra_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow riga in grdTutti.SelectedRows)
            {
                // prende la riga dalla DataGridView e la converte in una riga
                // di DataTable
                DataRow dRiga = ((DataRowView)riga.DataBoundItem).Row;
                // aggiunge la riga di DataTable alla DataTable di destinazione
                dSetEsercizio.Tables[0].ImportRow(dRiga);
            }
            // cancella dalla griglia di origine
            while (grdTutti.SelectedRows.Count > 0)
            {
                grdTutti.Rows.Remove(grdTutti.SelectedRows[0]);
                // Remove toglie dalla griglia e dal DataSet, ma non permette l'update
                // per poter fare l'update bisognerebbe fare la Delete (a noi qui non importa)
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSinistra_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow riga in grdEsercizio.SelectedRows)
            {
                // prende la riga dalla DataGridView e la converte in una riga
                // di DataTable
                DataRow dRiga = ((DataRowView)riga.DataBoundItem).Row;
                // aggiunge la riga di DataTable alla DataTable di destinazione
                dSetTutti.Tables[0].ImportRow(dRiga);
            }
            // cancella dalla griglia di origine
            while (grdEsercizio.SelectedRows.Count > 0)
            {
                grdEsercizio.Rows.Remove(grdEsercizio.SelectedRows[0]);
                // Remove toglie dalla griglia e dal DataSet, ma non permette l'update
                // per poter fare l'update bisognerebbe fare la Delete (a noi qui non importa)
            }
        }

        private void btnDestra2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow riga in grdTutti.Rows)
            {
                // prende la riga dalla DataGridView e la converte in una riga
                // di DataTable
                if (riga.DataBoundItem != null)
                {
                    DataRow dRiga = ((DataRowView)riga.DataBoundItem).Row;
                    // aggiunge la riga di DataTable alla DataTable di destinazione
                    dSetEsercizio.Tables[0].ImportRow(dRiga);
                }
            }
            // cancella dalla griglia di origine
            foreach (DataGridViewRow riga in grdTutti.Rows)
            {
                if (!riga.IsNewRow)
                {
                    grdTutti.Rows.Remove(riga);
                }
                // Remove toglie dalla griglia e dal DataSet, ma non permette l'update
                // per poter fare l'update bisognerebbe fare la Delete (a noi qui non importa)
            }
        }

        private void btnSinistra2_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // cancella tutte le righe che appartengono a questo esercizio
            DbConnection conn = Common.LibDB.Connetti();
            DbCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM VerbiEsercizi WHERE (IdEsercizio =" + codEsercizio + ");";
            comm.ExecuteNonQuery();
            // scrive le righe che sono in questo momento nella tabella una alla volta
            foreach (DataRow riga in dSetEsercizio.Tables[0].Rows){
                if (riga.RowState != DataRowState.Deleted)
                {
                    comm.CommandText = "INSERT INTO VerbiEsercizi (IdEsercizio, IdVerbo) VALUES (" + codEsercizio +
                        "," + riga["IdVerbo"] + ");";
                    comm.ExecuteNonQuery();
                }
            }
            this.Close();
        }

        private void frmEsercizio_Load(object sender, EventArgs e)
        {
            if (codEsercizio == 1) this.Close();
        }
    }
}