using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

namespace gamon.ParoleInglesi
{
    public partial class frmSceltaEsercizio : Form  
    {
        frmVerbi frmPadre;
        DataSet dSetEsercizi;

        DbDataAdapter dadapEsercizi;
        int codEsercizio;

        public frmSceltaEsercizio(ref int CodEsercizio, string esercizio, frmVerbi frmPadre)
        {
            InitializeComponent();

            txtEsercizio.Text = esercizio;
            txtCodice.Text = "";

            codEsercizio = CodEsercizio;
            this.frmPadre = frmPadre;

            riempiGriglia();

            DbConnection conn = frmPadre.LibDB.Connetti();

            DbCommand comm = conn.CreateCommand();
            // conteggio degli esercizi che si chiamano come la stringa passata e creazione del nome di default
            comm.CommandText = "SELECT count(*) FROM Esercizi WHERE Descrizione LIKE '%" + esercizio + "%'";
            int nNomiSimili = (int) ((long) comm.ExecuteScalar());
            string nomeEsercizio = esercizio;
            if (nNomiSimili > 0) nomeEsercizio += " " + nNomiSimili;
            txtEsercizio.Text = nomeEsercizio;

            conn.Close();
        }

        private void riempiGriglia()
        {
            // DataSet e griglia
            frmPadre.LibDB.DataSetEsercizi(codEsercizio, ref dadapEsercizi, ref dSetEsercizi);

            DataTable dTEsercizi = dSetEsercizi.Tables[0];

            bindEsercizi.DataSource = dTEsercizi;
            grdDati.DataSource = bindEsercizi;
            grdDati.Columns[0].ReadOnly = true;
            //grdDati.Columns[0].Visible = false;
        }

        private void grdDati_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodice.Text = grdDati.CurrentRow.Cells[0].Value.ToString();
            txtEsercizio.Text = grdDati.CurrentRow.Cells[1].Value.ToString();
        }

        private void grdDati_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodice.Text = grdDati.CurrentRow.Cells[0].Value.ToString();
            txtEsercizio.Text = grdDati.CurrentRow.Cells[1].Value.ToString();
        }

        private void grdDati_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            txtCodice.Text = grdDati.CurrentRow.Cells[0].Value.ToString();
            txtEsercizio.Text = grdDati.CurrentRow.Cells[1].Value.ToString();
        }

        private void grdDati_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCodice.Text = grdDati.CurrentRow.Cells[0].Value.ToString();
            txtEsercizio.Text = grdDati.CurrentRow.Cells[1].Value.ToString();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            DbConnection conn = frmPadre.LibDB.Connetti();
            DbCommand comm = conn.CreateCommand();

            // gestione del codice del vecchio o del nuovo esercizio
            if (txtCodice.Text != "")
            {
                if (MessageBox.Show("Si vogliono memorizzare le risposte sbagliate nell'esercizio '" +
                                  txtEsercizio.Text + "', codice " + txtCodice.Text + "?",
                                  "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {   // eliminazione delle domande del questionario che si cancella
                    comm.CommandText = "DELETE FROM VerbiEsercizi WHERE IdEsercizio =" + txtCodice.Text + ";";
                    comm.ExecuteNonQuery();
                    codEsercizio = int.Parse(txtCodice.Text);
                }
                else
                {   // non vuole distruggere l'esercizio indicato: non salva niente ed esce
                    return;
                }
            }
            else
            {   // nuovo esercizio con gli errori
                // creazione di una nuova riga nella tabella esercizi
                comm.CommandText = "INSERT INTO Esercizi (Descrizione) VALUES ('" + txtEsercizio.Text + "');";
                comm.ExecuteNonQuery();
                comm.CommandText = "SELECT last_insert_rowid();";  // riga specifica di SQLite!
                txtCodice.Text = comm.ExecuteScalar().ToString();
                codEsercizio = int.Parse(txtCodice.Text);
            }
            this.Close();
        }

        public int ShowDialog(){
            base.ShowDialog();
            return codEsercizio; 
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDati_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // se sono state fatte modifiche nella tabella, avverte che così verranno perse
            if (dSetEsercizi.Tables[0].GetChanges() != null)
            {
                if (MessageBox.Show("Sono state fatte delle modifiche. Conferma che vuole annullarle?",
                                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            EventArgs e1 = null;
            btnAbort_Click(sender, e1); 
        }
    }
}
