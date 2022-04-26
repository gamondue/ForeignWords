using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamon.ForeignWords
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // inizializzazioni per tutta l'applicazione
            // lingua di default
            Global.LinguaCorrente = "English";
            // lingua del computer
            string linguaComputer = CultureInfo.CurrentCulture.Name.ToLower();
            foreach (string lingua in Global.Lingue)
            {
                //TODO aggiungere il codice lingua al database, così che il prossimo confronto
                // possa funzionare
                if (lingua.ToLower() == linguaComputer)
                {
                    Global.LinguaCorrente = lingua;
                }
                break;
            }
        }
        private void btnEditUICaptions_Click(object sender, EventArgs e)
        {
            frmEditUI f = new frmEditUI();
            f.Show(); 
        }
        private void btnInfinitives_Click(object sender, EventArgs e)
        {
            frmInfinitives f = new frmInfinitives();
            f.Show();
        }
    }
}
