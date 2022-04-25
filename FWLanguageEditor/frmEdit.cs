using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

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

            // inizializzazioni per tutta l'applicazione
            // lingua di default
            Common.LinguaCorrente = "English";
            // lingua del computer
            string linguaComputer = CultureInfo.CurrentCulture.Name.ToLower();
            foreach (string lingua in Common.Lingue)
            {
                //TODO aggiungere il codice lingua al database, così che il prossimo confronto
                // possa funzionare
                if (lingua.ToLower() == linguaComputer)
                {
                    Common.LinguaCorrente = lingua;
                }
                break;
            }

            doCheckBoxes();
            collegaGriglia();
        }

        private void doCheckBoxes()
        {
            // legge le lingue e fa i checkbox
            ArrayList lingue = Common.LibDB.LinguePresenti();
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

            ArrayList lingue = Common.LibDB.LinguePresenti();
            Point punto = new Point(7, 7);

            string lingueVisualizzate = "";
            foreach (CheckBox ch in chkLingue)
            {
                if (ch.Checked)
                    lingueVisualizzate += "'" + ch.Tag.ToString() + "',";
            }
            if (lingueVisualizzate.Length == 0) return;
            lingueVisualizzate = lingueVisualizzate.Substring(0, lingueVisualizzate.Length - 1);
            Common.LibDB.DataSetCaptionLingue(ref dadapCaptions, ref dSetEsercizi, lingueVisualizzate);

            DataTable dTCaptions = dSetEsercizi.Tables[0];

            bindCaptions.DataSource = dTCaptions;
            grdDati.DataSource = bindCaptions;
            grdDati.Columns[0].ReadOnly = true;
            //grdDati.Columns[0].Visible = false;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            DbConnection conn = Common.LibDB.Connetti();
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
//TODO mettere nel database !!!!!!!!!!!!!
                if (MessageBox.Show(Common.Captions["messModifiche"].ToString(),
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
            frmNewLanguage nuovo = new frmNewLanguage();

            if (nuovo.ShowDialog() == DialogResult.OK && nuovo.txtNewLanguage.Text != "")
            {
                // controlla che la nuova lingua non ci sia già 
                for (int i = 0; i < Common.Lingue.Count; i++)
                {
                    if (Common.Lingue[i].ToString() == nuovo.txtNewLanguage.Text)
                    {
                        MessageBox.Show(Common.Captions["messLinguaggioPresente"].ToString(),
                            "", MessageBoxButtons.OK);
                        return; 
                    }
                }
                // Inserisce la nuova lingua
                Common.LibDB.NuovaLingua(nuovo.txtNewLanguage.Text);
                doCheckBoxes();
            }
        }

        private void btnCopyDatabaseFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = ""; 
            saveFileDialog.FileName = "ForeignWords_" + DateTime.Now.ToString("yyyy.MM.dd") + ".sqlite";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(Common.LibDB.NomeEPathDatabase, saveFileDialog.FileName, true);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO DO!");
            return;
            // TODO cercare un metodo migliore di quello qui sotto? 

            // TODO fare una finestra per la configurazione del server smtp 
            //gamon.Net.MailSender mail = new Net.MailSender("Server smtp");

            //string nomeFileCopiato = ".\\ForeignWords_" + 
            //    DateTime.Now.ToString("yyyy.MM.dd") + username + "_" + ".sqlite"; 
            
            // copia il file sqlite del database cambiandogli di nome
            //System.IO.File.Copy(".\\dbForeignWords_Standard.sqlite", nomeFileCopiato, false); 

            //ArrayList allegati = new ArrayList();
            //allegati.Add(Global.LibDB.NomeEPathDatabase);

            //MessageBox.Show("A mail will be automatically sent to gamon@ingmonti.it. " + 
            //    "It will have as an attachment a copy of the file " + 
            //    Global.LibDB.NomeEPathDatabase + 
            //    " from your computer"); 

            //mail.SendWithAttachment(nomeFileCopiato, from, username, password, to, subject,
            //    "Find here enclosed the ForeignWords file I modified \r\n" + Datetime.Now + " " + username,
            //    null, false);
        }

        private void btnLeggiDatabase_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "*.sqlite";
            openFileDialog.Filter = "database files (*.sqlite)|*.sqlite|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("WARNING! Your existing database will be overwritten by " + openFileDialog.FileName
                                    + "\nShould I overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Copy(openFileDialog.FileName, Common.LibDB.NomeEPathDatabase, true);
                }
            }
        }
    }
}

