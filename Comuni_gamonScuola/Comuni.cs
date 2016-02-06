using System;
using System.Collections.Generic;
using System.Text;

namespace gamon
{
    public static partial class Comuni
    {
        static string[] sorteggiata;
        static Proposizione[] definizioni;
        private static int nRighePerEntryInQuestionLoop = 9;

        // coppia che rappresenta l'informazione da visualizzare - mescolare 
        // e la sua posizione originale, da preservare durante il mescolamento 
        internal struct InfoEPosto
        {
            internal string Informazione;
            internal int RigaIniziale;
        }; 
        // 
        internal struct Proposizione
        {
            internal InfoEPosto Concetto;
            internal InfoEPosto Definizione;
        }; 

        public static uint QuestionLoop(string File, int NAllievi)
        {
            int i, j;

            Random r = new Random();
            string[,] definizioniOriginarie;
            definizioniOriginarie = gamon.FileDiTesto.FileInMatrice(File, "\t");
            definizioni = new Proposizione[definizioniOriginarie.GetLength(0)];
            // copia in definizioni quello che trova nel file 
            // e gli aggiunge gli indici di riga, per ricordarsi come verranno mescolate
            for (i = 0; i < definizioniOriginarie.GetLength(0); i++)
            { 
                definizioni[i].Concetto.RigaIniziale = i + 1;
                definizioni[i].Definizione.RigaIniziale = i + 1;
                for (j = 0; j < definizioniOriginarie.GetLength(1); j++)
                {
                    definizioni[i].Concetto.Informazione = definizioniOriginarie[i, 0];
                    definizioni[i].Definizione.Informazione = definizioniOriginarie[i, 1];
                }
            }
            if (NAllievi == 0 || NAllievi > definizioni.GetLength(0)) NAllievi = definizioni.GetLength(0);
            string[] QuestionLoop = new string[NAllievi * nRighePerEntryInQuestionLoop];
            string[] QuestionLoopSolution = new string[NAllievi * nRighePerEntryInQuestionLoop];
            int lineaOpenLoop = 0, lineaOpenLoopSoluzione = 0;
            // mescola l'array delle definizioni. 
            //TODO !!!! mescolare prima tutto l'array, così non si prendono solo le prime domande

            // mescola i concetti e le definizioni separatamente
            for (i = 0; i < NAllievi; i++)
            {
                // riga a caso in cui prendere il concetto da scambiare 
                int rigaACasoConcetto = r.Next(i, NAllievi);
                // riga a caso in cui prendere la definizione da scambiare 
                // non deve essere uguale alla definizione, altrimenti le due
                // cose vengono date alla stessa persona
                int rigaACasoDefinizione;
                do  // gira mentre hanno la stessa riga iniziale 
                {
                    rigaACasoDefinizione = r.Next(i, NAllievi);
                } while (definizioni[rigaACasoDefinizione].Concetto.RigaIniziale == 
                            definizioni[rigaACasoConcetto].Definizione.RigaIniziale);
                // scambio fra i concetti
                InfoEPosto dummy = definizioni[i].Concetto;
                definizioni[i].Concetto = definizioni[rigaACasoConcetto].Concetto;
                definizioni[rigaACasoConcetto].Concetto = dummy;
                // scambio fra le definizioni 
                dummy = definizioni[i].Definizione;
                definizioni[i].Definizione = definizioni[rigaACasoDefinizione].Definizione;
                definizioni[rigaACasoDefinizione].Definizione = dummy;
                Console.WriteLine(definizioni[i].ToString());
            }
            // genera il QuestionLoop
            for (i = 0; i < NAllievi; i++)
            {
                // Genera le righe del file del QuestionLoop
                QuestionLoop[lineaOpenLoop] = ""; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = "Concetto: "; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = definizioni[i].Concetto.Informazione; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = ""; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = "Definizione: "; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = definizioni[i].Definizione.Informazione; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = ""; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = "________________________________________________________________________________"; lineaOpenLoop++;
                QuestionLoop[lineaOpenLoop] = "";

                // Genera le righe della soluzione del QuestionLoop
                QuestionLoopSolution[lineaOpenLoopSoluzione] = ""; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = "Concetto (" + definizioni[i].Concetto.RigaIniziale + "):"; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = definizioni[i].Concetto.Informazione; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = ""; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = "Definizione (" + definizioni[i].Definizione.RigaIniziale + "):"; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = definizioni[i].Definizione.Informazione; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = ""; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = "________________________________________________________________________________"; lineaOpenLoopSoluzione++;
                QuestionLoopSolution[lineaOpenLoopSoluzione] = ""; 
            }
            gamon.FileDiTesto.VettoreInFile("QL_Solution_" + File, QuestionLoopSolution, false);
            gamon.FileDiTesto.VettoreInFile("QL_" + File, QuestionLoop, false);
            return 0; 
        }

        private static void ScambioRighe(string[,] definizioni, int i, int riga)
        {
            int j; 
            // copia la riga sorteggiata in un vettore temporaneo 
            for (j = 0; j < definizioni.GetLength(1); j++)
            {
                sorteggiata[j] = definizioni[riga, j];
            }
            // copia la i-esima riga su quella sorteggiata
            for (j = 0; j < definizioni.GetLength(1); j++)
            {
                definizioni[riga, j] = definizioni[i, j];
            }
            // copia nella i-esima riga la riga temporanea 
            for (j = 0; j < definizioni.GetLength(1); j++)
            {
                definizioni[i, j] = sorteggiata[j];
            }
        }

        public static uint QuestionLoop(int i)
        {
            Console.WriteLine("1 parametro");
            return QuestionLoop("definizioni.txt", i);
        }

        public static uint QuestionLoop()
        {
            return QuestionLoop("definizioni.txt", 0);
        }
    }
}
