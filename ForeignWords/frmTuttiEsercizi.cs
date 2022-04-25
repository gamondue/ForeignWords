using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gamon.ForeignWords;

namespace gamon.ForeignWords
{
    public partial class frmTuttiEsercizi : Form
    {
        frmVerbi frmPadre;
        DataSet dSetEsercizi;
        
        DbDataAdapter dadapEsercizi;
        int codEsercizio;

        public frmTuttiEsercizi(bool cercaNomiSimili, int CodEsercizio, string esercizio, frmVerbi frmPadre)
        {
            InitializeComponent();
            Common.caricaLinguaInControlli(this);

            if (cercaNomiSimili) this.Text = "Salvataggio dell'esercizio degli errori";
            codEsercizio = CodEsercizio;
            this.frmPadre = frmPadre;

            txtEsercizio.Text = esercizio;
            txtCodice.Text = CodEsercizio.ToString();

            collegaGriglia();

            // se viene passato un nome "suggerito" per l'esercizio da scegliere
            // si va a vedere se ci sono già nomi come quello ed eventualmente gli si aggiunge 
            // in fondo un numero
            if (esercizio != "")
            {
                DbConnection conn = Common.LibDB.Connetti();

                DbCommand comm = conn.CreateCommand();
                // conteggio degli esercizi che si chiamano come la stringa passata e creazione del nome di default
                comm.CommandText = "SELECT count(*) FROM Esercizi WHERE Descrizione LIKE '%" + esercizio + "%'";
                int nNomiSimili = (int)((long)comm.ExecuteScalar());
                string nomeEsercizio = esercizio;
                if (nNomiSimili > 0) nomeEsercizio += " " + nNomiSimili;
                txtEsercizio.Text = nomeEsercizio;
                txtCodice.Text = "";

                conn.Close();

                ////DataRowCollection rowCollection = table.Rows;
                //DataRow newRow = dSetEsercizi.Tables[0].NewRow();
                //newRow[1] = nomeEsercizio;
                //dSetEsercizi.Tables[0].Rows.Add(newRow);
            }
        }

        public new int ShowDialog()
        {
            base.ShowDialog();
            return codEsercizio;
        }  

        private void collegaGriglia(){

            // DataSet e griglia
            Common.LibDB.DataSetEsercizi(codEsercizio, ref dadapEsercizi, ref dSetEsercizi);

            DataTable dTEsercizi = dSetEsercizi.Tables[0];

            bindEsercizi.DataSource = dTEsercizi;
            grdDati.DataSource = bindEsercizi;
            grdDati.Columns[0].ReadOnly = true;
            //grdDati.Columns[0].Visible = false;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            DbConnection conn = Common.LibDB.Connetti();
            DbCommand comm = conn.CreateCommand();

            // gestione del codice del vecchio o del nuovo esercizio
            if (txtCodice.Text != "")
            {
                if (MessageBox.Show("Si vogliono memorizzare le risposte sbagliate al posto dell'esercizio '" +
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

            dadapEsercizi.Update(dSetEsercizi);
            dSetEsercizi.Clear();
            dadapEsercizi.Fill (dSetEsercizi);

            grdDati.Refresh();
            
            // non chiude il form perchè l'utente potrebbe non avere ancora scelto l'esercizio
        }

        private void grdDati_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodice.Text = grdDati.CurrentRow.Cells[0].Value.ToString() ;
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

        private void btnAbort_Click(object sender, EventArgs e)
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
            this.Close();
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
                if (grdDati.SelectedRows[0] != null){
                    if (MessageBox.Show ("Cancellazione totale dell'esercizio '" +
                                       grdDati.SelectedRows[0].Cells[1].Value.ToString() + "'.\r\n" +
                                       "Conferma l'operazione", "Cancella", 
                                       MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DbConnection conn = Common.LibDB.Connetti();
                        DbCommand comm = conn.CreateCommand();
                        comm.CommandText = "DELETE FROM Esercizi" +
                                            " WHERE IdEsercizio ='" +
                                            grdDati.SelectedRows[0].Cells[0].Value.ToString() +
                                            "';";
                        comm.ExecuteNonQuery();
                        comm.CommandText = "DELETE FROM VerbiEsercizi" +
                                            " WHERE IdEsercizio =" +
                                            grdDati.SelectedRows[0].Cells[0].Value.ToString() +
                                            ";";
                        comm.ExecuteNonQuery();

                        dSetEsercizi.Clear();
                        dadapEsercizi.Fill(dSetEsercizi);
                    }
                }
            }

            private void grdDati_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                EventArgs e1 = null;
                btnAbort_Click(sender, e1); 
            }
        }
    }

