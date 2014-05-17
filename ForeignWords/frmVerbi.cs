using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gamon;
using System.Data.Common; 
using System.Collections; 

namespace gamon.ForeignWords
{
    public partial class frmVerbi : Form
    {
        string esercizioDefault = "Tutti i verbi";
        int codEsercizioDefault = 1;
        string esercizioCorrente;
        int codEsercizioCorrente;

        bool esercizioIniziato = false;
        bool domandaFinita = false; 
        double tempoRimastoInS = 0;
        double tempoTotaleInS = 0;

        Random randomSeq = new Random();

        int domandaCorrente = 0;
        Verbo[] verbi;

        bool[] sbagliate;   // domande che l'utente ha sbagliato l'ultima volta

        DateTime istanteInizioEsercizio;
        DateTime istanteInizioDomanda;
        double tMaxRisposta = 60, tInizioPenalit‡Risposta = 15; 
        double punteggioDomanda;
        double punteggioTotale;

        public frmVerbi()
        {
            InitializeComponent();

            // inizializzazioni per tutta l'applicazione
            // liguaggio di default
            Global.LinguaCorrente = "English";
            AggiuntaMenu(mnuLanguage);
            nascondiInfinito();

            // inizializzazioni per questo form
            esercizioCorrente = esercizioDefault;
            codEsercizioCorrente = codEsercizioDefault;
            txtEsercizio.Text = esercizioCorrente;
            txtCodice.Text = "1";
            pbarTotale.Value = pbarTotale.Maximum;

            Global.caricaLinguaInControlli(this);
            Global.caricaLinguaInMenu(menuStrip1);
            // alla partenza del programma legge l'esercizio di default nell'array dei verbi
            verbi = leggiVerbiDaDB(codEsercizioCorrente);
        }

        private Verbo[] leggiVerbiDaDB(int CodEsercizio)
        {
            DbDataAdapter dadapVerbi =null;

            DataSet dSet=null;
            Global.LibDB.DataSetVerbi(CodEsercizio, ref dadapVerbi, ref dSet);
            DataTable dTable = dSet.Tables[0];
            
            int nColonne = dTable.Columns.Count;
            int nRighe = dTable.Rows.Count;
            Verbo[] VettoreVerbi = new Verbo[nRighe]; 
            {
                int i = 0;
                foreach (DataRow riga in dTable.Rows)
                {
                    Verbo tempVerbo= new Verbo();
                    tempVerbo.IdVerbo = int.Parse(riga["IdVerb"].ToString());
                    tempVerbo.Infinito = (string)riga["Infinitive"];
                    if ((Global.LinguaCorrente != "English"))
                    {
                        tempVerbo.InfinitoInLingua = Global.LibDB.GetSafeString(riga["Inf" + Global.LinguaCorrente]);
                    }
                    else
                    {
                        tempVerbo.InfinitoInLingua = "";
                    }
                    tempVerbo.ParticipioPassato = (string)riga["PastParticiple"];
                    tempVerbo.Passato = (string)riga["PastTense"];

                    VettoreVerbi[i] = tempVerbo;

                    i++;
                }
            }
            return (VettoreVerbi);
        }

        private void btnVerbo_Click(object sender, EventArgs e)
        {
            txtInfinito.Text = "";
            txtInfinito.BackColor = Color.White;
            txtInfinito.ForeColor = Color.Black;
            txtPassato.Text = "";
            txtPassato.BackColor = Color.White;
            txtPassato.ForeColor = Color.Black;
            txtParticipio.Text = "";
            txtParticipio.BackColor = Color.White;
            txtParticipio.ForeColor = Color.Black;
            txtItaliano.Text = "";
            txtItaliano.BackColor = Color.White;
            txtItaliano.ForeColor = Color.Black;

            txtInfinitoGiusto.Text = "";
            txtPassatoGiusto.Text = "";
            txtParticipioGiusto.Text = "";
            txtItalianoGiusto.Text = "";

            istanteInizioDomanda = DateTime.Now;
            int nEstraibili;
            if (Global.LinguaCorrente != "English")
            {
                nEstraibili = 4;
            }
            else
            {
                nEstraibili = 3;
            }
            switch (randomSeq.Next(nEstraibili))
            {
                case 0:
                    txtInfinito.Text = verbi[domandaCorrente].Infinito ;
                    break;
                case 1:
                    txtPassato.Text = verbi[domandaCorrente].Passato;
                    break;
                case 2:
                    txtParticipio.Text = verbi[domandaCorrente].ParticipioPassato;
                    break;
                case 3:
                    txtItaliano.Text = verbi[domandaCorrente].InfinitoInLingua;
                    break;
            }
            int temp = domandaCorrente + 1;
            displayDomanda.Text = temp.ToString();

            btnCorreggi.Visible = true;
            btnVerbo.Visible = false;

            txtInfinito.Focus();

            domandaFinita = false;
        }

        private void btnCorreggi_Click(object sender, EventArgs e)
        {
            pbarPrima.Visible = false;
            if (domandaFinita){
                pbarDopo.Visible = false;
                lblConPenalit‡.Visible = false;
            }
            lblSenzaPenalit‡.Visible = false;
            txtInfinitoGiusto.Text = verbi[domandaCorrente].Infinito;
            txtPassatoGiusto.Text = verbi[domandaCorrente].Passato ;
            txtParticipioGiusto.Text = verbi[domandaCorrente].ParticipioPassato;
            txtItalianoGiusto.Text = verbi[domandaCorrente].InfinitoInLingua;
            int giuste = 0;
            if (uguale(txtInfinito.Text, txtInfinitoGiusto.Text))
            {
                txtInfinito.BackColor = Color.Green;
                txtInfinito.ForeColor = Color.White;
                giuste++;
            }
            else
            {
                txtInfinito.BackColor = Color.Red;
                txtInfinito.ForeColor = Color.White;
            }
            if (uguale(txtPassato.Text, txtPassatoGiusto.Text))
            {
                txtPassato.BackColor = Color.Green;
                txtPassato.ForeColor = Color.White;
                giuste++;
            }
            else
            {
                txtPassato.BackColor = Color.Red;
                txtPassato.ForeColor = Color.White;
            }

            if (uguale(txtParticipio.Text, txtParticipioGiusto.Text))
            {
                txtParticipio.BackColor = Color.Green;
                txtParticipio.ForeColor = Color.White;
                giuste++;
            }
            else
            {
                txtParticipio.BackColor = Color.Red;
                txtParticipio.ForeColor = Color.White;
            }
            if (uguale(txtItaliano.Text, txtItalianoGiusto.Text))
            {
                txtItaliano.BackColor = Color.Green;
                txtItaliano.ForeColor = Color.White;
                giuste++;
            }
            else
            {
                txtItaliano.BackColor = Color.Red;
                txtItaliano.ForeColor = Color.White;
            }

            // assegnazione del punteggio
            double tempo = (DateTime.Now.Ticks - istanteInizioDomanda.Ticks) / 1E7;
            giuste--; // una giusta c'Ë sempre: quella che d‡ lui!
            giuste *= 20; // 20 punti per ogni domanda giusta
            punteggioDomanda = giuste;
            if (punteggioDomanda == 60)
            {
                sbagliate[domandaCorrente] = false;
            }
            else
            {
                sbagliate[domandaCorrente] = true;
            }
            if (tempo >= tInizioPenalit‡Risposta)
            {
                // se Ë scaduto il tempo per la domanda: cala il punteggio
                punteggioDomanda -= giuste * (tempo - tInizioPenalit‡Risposta) / (tMaxRisposta - tInizioPenalit‡Risposta);
                if (punteggioDomanda <0) punteggioDomanda = 0;
            }
            punteggioTotale += punteggioDomanda;
            lblDisplayPunteggioDomanda.Text = punteggioDomanda.ToString("0");
            lblDisplayPunteggioTotale.Text = punteggioTotale.ToString("0");

            btnCorreggi.Visible = false;
            btnVerbo.Visible = true;

            domandaFinita = true;
            domandaCorrente++;
            // controllo se le domande sono finite
            if (domandaCorrente == verbi.Length)
            {
                // fine del questionario
                
                MessageBox.Show(Global.Captions["messFineEsercizio"].ToString()); 
                finisciEsercizio();
            }
        }

        private void Verbi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (esercizioIniziato)
            {
                if (e.KeyChar == '\r')
                    if (btnCorreggi.Visible)
                    {
                        Object o = null;
                        EventArgs ev = null;
                        btnCorreggi_Click(o, ev);
                    }
                    else
                    {
                        Object o = null;
                        EventArgs ev = null;
                        btnVerbo_Click(o, ev);
                    }
            }
        }

        private bool uguale(string s1, string s2)
        {
            string[] campi1 = s1.Split(',');
            string[] campi2 = s2.Split(',');

            foreach (string sUtente in campi1)
            {
                foreach (string sGiusta in campi2)
                {
                    if (sUtente.Trim().ToLower() == sGiusta.Trim().ToLower())
                        return true;
                }
            }
            return false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout a = new frmAbout();
            a.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (esercizioIniziato)
            {
                double tempo = (DateTime.Now.Ticks - istanteInizioDomanda.Ticks) / 1E7;
                double tempoPassatoInS = (DateTime.Now.Ticks - istanteInizioEsercizio.Ticks) / 1E7;
                tempoRimastoInS = tempoTotaleInS - tempoPassatoInS;
                if (tempo <= tInizioPenalit‡Risposta)
                {
                    // diminuisci barra prima 
                    pbarPrima.Maximum = (int)tInizioPenalit‡Risposta;
                    pbarPrima.Value = (int)tempo;
                    pbarPrima.Visible = true;
                    lblSenzaPenalit‡.Visible = true;
                    pbarDopo.Visible = false;
                    lblConPenalit‡.Visible = false;
                }
                else
                {
                    pbarDopo.Minimum = (int)tInizioPenalit‡Risposta;
                    pbarDopo.Maximum = (int)tMaxRisposta;
                    if (tempo <= tMaxRisposta)
                        pbarDopo.Value = (int)tempo;
                    else
                        pbarDopo.Value = (int)tMaxRisposta;

                    pbarPrima.Visible = false;
                    if (!domandaFinita)
                    {
                        pbarDopo.Visible = true;
                        lblConPenalit‡.Visible = true;
                    }
                    lblSenzaPenalit‡.Visible = false;
                }
                if (tempoRimastoInS > 0)
                {
                    pbarTotale.Value = (int)tempoRimastoInS;
                }
                else
                {
                    timer1.Enabled = false;
                    MessageBox.Show(Global.Captions["messTempoFinito"].ToString());
                    // chiude l'esercizio simulando il bottone di fine
                    object ob = null;
                    EventArgs ev = null;
                    btnEsercizio_Click(ob, ev);
                }
            }
        }

        private void sorteggioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuovoRandom();
        }

        private void nuovoRandom()
        {
            domandaCorrente = 0;
            btnCorreggi.Visible = true;
            btnVerbo.Visible = false;
            pbarPrima.Visible = false;
            pbarDopo.Visible = false;
            btnCorreggi.Visible = false;
            lblSenzaPenalit‡.Visible = false;
            lblConPenalit‡.Visible = false;
            btnVerbo.Visible = true;

            //// rilettura daccapo del file per essere nelle stesse condizioni dell'inizio
            //verbi = leggiVerbiDaDB(codEsercizioCorrente); //TODO ???????????? vedere se Ë necessario rimettere questa
            frmNuovoRandom frm = new frmNuovoRandom();
            frm.ShowDialog();
            // prende la sequenza random generata dentro il form
            randomSeq = frm.RandomSeq;

            // rimescola con la nuova sequenza (se deve!)
            if (frm.DeveMescolare)
                mescola();
            else
                ordina();
        }

        private void mescola(){
            // mescola i verbi            
            for (int i = 0; i < verbi.Length; i++)
            {
                int rigaCasuale = randomSeq.Next(verbi.Length);
                // scambio della riga I con la riga rigaCasuale
                Verbo temp;
                temp = verbi[rigaCasuale];
                verbi[rigaCasuale] = verbi[i];
                verbi[i] = temp;
                verbi[i].InfinitoInLingua = verbi[i].InfinitoInLingua.ToLower();
                verbi[i].Infinito = verbi[i].Infinito.ToLower();
                verbi[i].ParticipioPassato = verbi[i].ParticipioPassato.ToLower();
                verbi[i].Passato = verbi[i].Passato.ToLower();
            }
        }

        private void ordina()
        {
            // ordina i verbi            
            for (int i = 0; i < verbi.Length -1; i++)
            {
                if (verbi[i].InfinitoInLingua.Length >0)
                    verbi[i].InfinitoInLingua = verbi[i].InfinitoInLingua.ToLower();
                verbi[i].Infinito = verbi[i].Infinito.ToLower();
                verbi[i].ParticipioPassato = verbi[i].ParticipioPassato.ToLower();
                verbi[i].Passato = verbi[i].Passato.ToLower();

                string min = verbi[i].Infinito; 
                int jMax = i;
                for (int j = i + 1; j < verbi.Length; j++)
                {
                    if (verbi[j].Infinito.CompareTo(min)== -1)
                    {
                        jMax = j;
                        min = verbi[j].Infinito;
                    }
                }
                // scambio della riga i con la riga del minimo
                Verbo temp;
                temp = verbi[jMax];
                verbi[jMax] = verbi[i];
                verbi[i] = temp;
            }
        }

        private void leggiFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuttiEsercizi sceltaEsercizio = new frmTuttiEsercizi(false, codEsercizioCorrente, esercizioCorrente, this);
            sceltaEsercizio.ShowDialog();
            esercizioCorrente = sceltaEsercizio.txtEsercizio.Text;
            if (sceltaEsercizio.txtCodice.Text != "")
                codEsercizioCorrente = int.Parse(sceltaEsercizio.txtCodice.Text);
            else
            {
                sceltaEsercizio.txtCodice.Text = "1";
                codEsercizioCorrente = 1;
                esercizioCorrente = esercizioDefault;
            }
            txtCodice.Text = codEsercizioCorrente.ToString();
            verbi = leggiVerbiDaDB(codEsercizioCorrente);  // il codice 1 c'Ë gi‡ nel database: Ë l'esercizio con tutti i verbi

            displayNDomande.Text = verbi.Length.ToString();
            txtEsercizio.Text = esercizioCorrente;
        }

        private void verbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDomande frm = new frmDomande(this);
            frm.ShowDialog();
        }

        private string[] daClasseAStringhe(Verbo[] verbi)
        {
            string[] arr = new string[verbi.Length + 1];
            int i =0;
            arr[0] = "VerbId| " + Global.Captions["lblInfinito"].ToString() + "|" +
                Global.Captions["lblPassato"].ToString() + "|" + Global.Captions["lblParticipioPassato"].ToString() + "|" +
                Global.Captions["lblInfinitoItaliano"].ToString();
            foreach (Verbo v in verbi)
            {
                arr[i] = v.ToString();
                i++;
            }
            return arr;
        }

        private void eserciziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEsercizio frm = new frmEsercizio(codEsercizioCorrente, esercizioCorrente, this);
            frm.ShowDialog();
            verbi = leggiVerbiDaDB(codEsercizioCorrente);
        }

        private void iniziaEsercizio()
        {
            if (verbi.Length == 0)
            {
                MessageBox.Show(Global.Captions["messNoQUestions"].ToString(), "Errore", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            esercizioIniziato = true; 

            txtInfinito.Enabled = true;
            txtInfinitoGiusto.Enabled = true;
            txtPassato.Enabled = true;
            txtPassatoGiusto.Enabled = true;
            txtParticipio.Enabled = true;
            txtParticipioGiusto.Enabled = true;
            txtItaliano.Enabled = true;
            txtItalianoGiusto.Enabled = true;
            btnVerbo.Enabled = true;
            btnCorreggi.Enabled = true;

            displayNDomande.Text = verbi.Length.ToString();
            displayDomanda.Text = "";
            lblDisplayPunteggioDomanda.Text = "";
            lblDisplayPunteggioTotale.Text = "";

            sbagliate = new bool[verbi.Length];
            // per default tutte le domande sono sbagliate
            int i = 0;
            foreach (Verbo v in verbi)
            {
                sbagliate[i] = true;
                i++;
            }
            domandaCorrente = 0;

            punteggioDomanda = 0;
            punteggioTotale = 0;

            txtInfinito.Text = "";
            txtItaliano.Text = "";
            txtParticipio.Text = "";
            txtPassato.Text = "";

            imbiancaTextBox(); 

            txtInfinitoGiusto.Text = "";
            txtItalianoGiusto.Text = "";
            txtParticipioGiusto.Text = "";
            txtPassatoGiusto.Text = "";

            btnCorreggi.Visible = false;
            btnVerbo.Visible = true;

            pbarDopo.Visible = false;
            pbarPrima.Visible = false;

            // estrae il primo verbo
            Object o = null;
            EventArgs ev = null;
            btnVerbo_Click(o, ev);

            tempoTotaleInS = double.Parse(txtTempoTotale.Text) * 60;
            pbarTotale.Maximum = (int)tempoTotaleInS;
            istanteInizioEsercizio = DateTime.Now;
            btnEsercizio.Text = Global.Captions["messFineEsercizio"].ToString();
            mnuModify.Enabled = false;
            mnuRandomize.Enabled = false;
            mnuLanguage.Enabled = false;
            timer1.Enabled = true;
        }

        private void finisciEsercizio (){
            timer1.Enabled = false;
            esercizioIniziato = false;

            txtInfinito.Enabled = false;
            txtInfinitoGiusto.Enabled = false;
            txtPassato.Enabled = false;
            txtPassatoGiusto.Enabled = false;
            txtParticipio.Enabled = false;
            txtParticipioGiusto.Enabled = false;
            txtItaliano.Enabled = false;
            txtItalianoGiusto.Enabled = false;
            btnVerbo.Enabled = false;
            btnCorreggi.Enabled = false;
            btnEsercizio.Text = Global.Captions["messInizioEsercizio"].ToString();
            mnuModify.Enabled = true;
            mnuRandomize.Enabled = true;
            mnuLanguage.Enabled = true;

            int codEsercizioSbagliati = 0;
            bool almenoUnErrore = false;
            foreach (bool s in sbagliate)
            {
                if (s)
                {
                    almenoUnErrore = true;
                    break;
                }
            }
            if (almenoUnErrore) {
                if (MessageBox.Show(Global.Captions["messSalvaSbagliate"].ToString(),
                            Global.Captions["messErrori"].ToString(), MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //frmSceltaEsercizio eser = new frmSceltaEsercizio(ref codEsercizioSbagliati, "Verbi sbagliati",
                    //                          this);
                    frmTuttiEsercizi eser = new frmTuttiEsercizi(true, codEsercizioSbagliati, Global.Captions["messErrori"].ToString(),
                          this);

                    codEsercizioSbagliati = eser.ShowDialog();
                    if (codEsercizioSbagliati != 0)
                    {
                        // creazione delle domande dell'esercizio
                        DbConnection conn = Global.LibDB.Connetti();
                        DbCommand comm = conn.CreateCommand();
                        for (int i = 0; i < verbi.Length; i++)
                        {
                            if (sbagliate[i])
                            {
                                comm.CommandText = "INSERT INTO VerbiEsercizi " +
                                              "(IdVerbo, IdEsercizio) VALUES (" + verbi[i].IdVerbo +
                                                 "," + codEsercizioSbagliati + ");";
                                comm.ExecuteNonQuery();
                            }
                        }
                        conn.Close();
                    }
                }
                if (MessageBox.Show(Global.Captions["messRiprovaSbagliati"].ToString(),
                                Global.Captions["messFine"].ToString(), MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // conteggio delle domande sbagliate:
                    int nSbagliate = 0;
                    for (int i = 0; i < verbi.Length; i++)
                    {
                        if (sbagliate[i])
                        {
                            nSbagliate++;
                        }
                    }
                    // nuova matrice con dentro solo le domande precedentemente sbagliate
                    Verbo[] tmpMat = new Verbo[nSbagliate];
                    int nuovaRiga = 0;
                    for (int i = 0; i < verbi.Length; i++)
                    {
                        // copia solo le domande sbagliate
                        if (sbagliate[i])
                        {
                            tmpMat[nuovaRiga] = verbi[i];
                            nuovaRiga++;
                        }
                    }
                    verbi = tmpMat;
                }
            }
            else
            {
                MessageBox.Show(Global.Captions["messTuttoBene"].ToString(), Global.Captions["messBene"].ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            imbiancaTextBox();
            displayNDomande.Text = verbi.Length.ToString();
            displayNDomande.Text = "";
        }

        private void imbiancaTextBox()
        {
            txtInfinito.BackColor = Color.White;
            txtItaliano.BackColor = Color.White;
            txtParticipio.BackColor = Color.White;
            txtPassato.BackColor = Color.White;

            txtInfinito.ForeColor = Color.Black;
            txtItaliano.ForeColor = Color.Black;
            txtParticipio.ForeColor = Color.Black;
            txtPassato.ForeColor = Color.Black;

            pbarDopo.Value = pbarDopo.Minimum;
            pbarPrima.Value = pbarPrima.Minimum;
            pbarTotale.Value = pbarTotale.Maximum;
        }

        private void btnEsercizio_Click(object sender, EventArgs e)
        {
            if (esercizioIniziato)
            {
                finisciEsercizio();
            }
            else
            {
                iniziaEsercizio();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("help.txt");
        }

        private void mnuToDo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ToDo list and known issues.txt");
        }
        #region gestione men˘ linguaggi

        public void AggiuntaMenu(ToolStripMenuItem ItemPadre)
        {
            ArrayList lin = Global.LibDB.LinguePresenti();
            // aggiorno il menu con i linguaggi supportati
            foreach (object o in lin)
            {
                creaMenuItem(o.ToString(), ItemPadre);
            }
        }

        private ToolStripMenuItem creaMenuItem(string testo, ToolStripMenuItem ItemPadre)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(testo);
            ItemPadre.DropDownItems.AddRange
                (new System.Windows.Forms.ToolStripItem[] { menuItem }
                );
            menuItem.Name = "mnu" + testo;
            //menuItem.Size = new System.Drawing.Size(155, 22);
            menuItem.Click += new System.EventHandler(this.MenuItem_Click);
            
            return menuItem;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem men = (ToolStripMenuItem)sender;
            Global.LinguaCorrente = men.Text;
            Global.caricaLinguaInControlli(this);
            Global.caricaLinguaInMenu(menuStrip1);
            verbi = leggiVerbiDaDB(codEsercizioCorrente);
            nascondiInfinito();
        }
        #endregion

        private void nascondiInfinito()
        {
            if (Global.LinguaCorrente == "English")
            {
                lblInfinitoItaliano.Visible = false;
                txtItaliano.Visible=false;
                txtItalianoGiusto.Visible=false;
            }
            else
            {
                lblInfinitoItaliano.Visible = true;
                txtItaliano.Visible = true;
                txtItalianoGiusto.Visible = true;
            }
        }
    }
}