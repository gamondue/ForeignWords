using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace gamon.ForeignWords
{
    public static class Common
    {
        private static string linguaCorrente;

        private static ArrayList lingue;
        public static Hashtable Captions;

        public static libDBForeignWords LibDB = new libDBForeignWords(libDBForeignWords.TipoDB.SQLite);

        #region proprietà
        public static string LinguaCorrente
        {
          get { return Common.linguaCorrente; }
          set { 
              Common.linguaCorrente = value;
              lingue = LibDB.LinguePresenti();
              Captions = LibDB.Prompts(Common.LinguaCorrente);
          }
        }

        public static ArrayList Lingue
        {
            get { 
                lingue = LibDB.LinguePresenti();
                return lingue;
            }
            //set { Global.lingue = value; }
        }

        #endregion

        public static void caricaLinguaInControlli(Form form)
        {
            // per ogni controllo o menu indicato nel database delle caption
            foreach (object oCaption in Common.Captions)
            {
                DictionaryEntry caption = (DictionaryEntry)oCaption;
                // i menù vengono trattati in un modo diverso
                if (caption.Key.ToString().IndexOf("mnu") < 0)
                    {   // se non è un menu, cerca fra i controlli
                        // ricerca del controllo che ha il nome uguale alle colonne nel database delle caption
                    foreach (Control ctrl in form.Controls)
                    {
                        if (ctrl.Name == caption.Key.ToString())
                        {
                            // modifica della caption del controllo
                            ctrl.Text = caption.Value.ToString();
                            break;
                        }
                    }
                }
                // se è il form ne cambia la caption
                if (caption.Key.ToString().IndexOf(form.Name) >= 0) 
                //    if (lingue[0, j].IndexOf(form.Name) >= 0)
                    {
                        form.Text = caption.Value.ToString(); 
                }
            }
        }

        public static void caricaLinguaInMenu(MenuStrip menu)
        {
            // per ogni controllo o menu indicato nel database delle caption
            foreach (object oCaption in Common.Captions)
            {
                DictionaryEntry caption = (DictionaryEntry)oCaption;
                // se è un menù 
                if (caption.Key.ToString().IndexOf("mnu") >= 0)
                    // cerca in modo ricorsivo fra i menu Item del menu
                    foreach (ToolStripMenuItem item in menu.Items)
                    {
                        if (cercaECambiaInMenu(item, caption.Key.ToString(), caption.Value.ToString()))                           
                            break;
                    }
            }
        }

        private static bool cercaECambiaInMenu(ToolStripMenuItem item, string menuName, string newMenuCaption)
        {
            if (item.Name == menuName) // lingue[0, j])
            {
                // modifica della caption del controllo
                if (newMenuCaption != "")
                    item.Text = newMenuCaption;
                return true;
            }
            foreach (ToolStripMenuItem itemFiglio in item.DropDownItems)
            {
                // per ogni menu indicato dalla riga
                if (itemFiglio.Name == menuName) // lingue[0, j])
                {
                    if (newMenuCaption != "")
                    {
                        // modifica della caption del controllo
                        itemFiglio.Text = newMenuCaption;
                    }
                    return true;
                }
                else
                    cercaECambiaInMenu(itemFiglio, menuName, newMenuCaption);
            }
            return false;
        }

        //public static string Prompt(string nomeElemento)
        //{
        //    return "XXXXXXXXXXX";
        //}
    }
}
