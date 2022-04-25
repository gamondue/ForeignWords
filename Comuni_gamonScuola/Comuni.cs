using System;
using System.Collections.Generic;
using System.Text;

namespace gamon
{
    public static partial class ComuniGamonScuola
    {
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
            string[] Questionnaire = new string[NAllievi * 4 + 2];
            int lineaOpenLoop = 0, lineaOpenLoopSoluzione = 0;
            int lineaQuestionarioConcetto = NAllievi * 3 + 1, lineaQuestionarioDefinizione = 0;
            ////Questionnaire[lineaQuestionarioDefinizione - 1] = "________________________________________________________________________________";

            // mescola l'array delle definizioni. 
            // mescola prima tutto l'array, così non si prendono solo le prime domande
            for (i = 0; i < definizioni.GetLength(0) - 1; i++)
            {
                // riga a caso in cui prendere la riga da scambiare 
                int rigaACaso = r.Next(i, definizioni.GetLength(0));
                // scambio fra le righe
                Proposizione dummy = definizioni[i];
                definizioni[i] = definizioni[rigaACaso];
                definizioni[rigaACaso] = dummy;
            }

            Console.WriteLine("Generazione Question loop con " +
                (NAllievi).ToString() + " domande");
            Console.WriteLine("File originale: " + File + "\r\n");

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

                // Genera le righe della questionario
                Questionnaire[lineaQuestionarioConcetto] = "Concetto (" + (i + 1).ToString() + "): " + definizioni[i].Concetto.Informazione; lineaQuestionarioConcetto++;
                Questionnaire[lineaQuestionarioDefinizione] = "Definizione n._____"; lineaQuestionarioDefinizione++;
                Questionnaire[lineaQuestionarioDefinizione] = definizioni[i].Definizione.Informazione; lineaQuestionarioDefinizione++;
                Questionnaire[lineaQuestionarioDefinizione] = "________________________________________________________________________________"; lineaQuestionarioDefinizione++;
            }
            gamon.FileDiTesto.VettoreInFile(File + "_QL.txt", QuestionLoop, false);
            Console.WriteLine("Creato il file " + File + "_QL.txt" +
                "\r\n\t(domande del question loop)");
            gamon.FileDiTesto.VettoreInFile(File + "_QL_SOLUTION.txt", QuestionLoopSolution, false);
            Console.WriteLine("Creato il file " + File + "_QL_QUESTIONNAIRE.txt" +
                "\r\n\t(questionario ricavato dal file originale)");
            Console.WriteLine("Creato il file " + File + "_QL_SOLUTION.txt" +
                 "\r\n\t(risposte nell'ordine corretto)");
            gamon.FileDiTesto.VettoreInFile(File + "_QL_QUESTIONNAIRE.txt", Questionnaire, false);

            return 0;
        }

        public static uint QuestionLoop(int i)
        {
            return QuestionLoop("definizioni.txt", i);
        }

        public static uint QuestionLoop()
        {
            return QuestionLoop("definizioni.txt", 0);
        }

        enum statoGrafoCloze
        {
            FuoriDaParola,
            DentroParola,
            DentroParolaDaCancellare,
        }

        public static uint Cloze(string File, int MediaParole)
        {
            int mediaParole = 7; // default 

            if (MediaParole > 0)
                mediaParole = MediaParole;

            Console.WriteLine("Generazione Cloze con oscuramento ogni " +
                mediaParole.ToString() + " parole");
            Console.WriteLine("File originale: " + File);

            Random r = new Random();

            string originaleText = gamon.FileDiTesto.FileInStringa(File);

            StringBuilder originaleBuilder = new System.Text.StringBuilder(originaleText);
            string paroleCancellate = "";

            // elimina le parole e le memorizza nella lista delle paroleCancellate
            int indexOriginale = 0;
            int nParola = 0;
            statoGrafoCloze stato = statoGrafoCloze.FuoriDaParola;
            int numeroProssimaParola = prossimaParolaDaCancellare(mediaParole);
            StringBuilder parolaDaCancellare = new StringBuilder();
            char carattere;

            while (indexOriginale < originaleText.Length)
            {
                // grafo riconoscitore che conta le parole 
                carattere = originaleText[indexOriginale];
                switch (stato)
                {
                    case (statoGrafoCloze.FuoriDaParola):
                        {
                            if (letteraDiParola(carattere))
                            {   // trovata nuova parola
                                nParola++;
                                // controlla se è una parola da cancellare
                                if (nParola == numeroProssimaParola)
                                {
                                    stato = statoGrafoCloze.DentroParolaDaCancellare;
                                    originaleBuilder[indexOriginale] = '_';
                                    parolaDaCancellare = new StringBuilder();
                                    parolaDaCancellare.Append(carattere);
                                    numeroProssimaParola += prossimaParolaDaCancellare(mediaParole);
                                }
                                else
                                {   // parola da non cancellare  
                                    stato = statoGrafoCloze.DentroParola;
                                }
                            }
                            else
                            {   // ancora fuori da una parola
                            }
                            break;
                        }
                    case (statoGrafoCloze.DentroParola):
                        {
                            if (!letteraDiParola(carattere))
                            {   // parola finita
                                stato = statoGrafoCloze.FuoriDaParola;
                            }
                            else
                            {   // altra lettera dentro la parola

                            }
                            break;
                        }
                    case (statoGrafoCloze.DentroParolaDaCancellare):
                        {
                            if (!letteraDiParola(carattere))
                            {   // parola da cancellare finita
                                stato = statoGrafoCloze.FuoriDaParola;
                                paroleCancellate += parolaDaCancellare.ToString() + "\r\n";
                            }
                            else
                            {   // altra lettera dentro la parola da cancellare 
                                originaleBuilder[indexOriginale] = '_';
                                parolaDaCancellare.Append(carattere);
                            }
                            break;
                        }
                }
                indexOriginale++;
            }
            gamon.FileDiTesto.StringaInFile(File + "_Cloze.txt", originaleBuilder.ToString(), false);
            Console.WriteLine("Creato il file " + File + "_Cloze.txt (esercizio)");
            gamon.FileDiTesto.StringaInFile(File + "_Cloze_SOLUTION.txt", paroleCancellate.Replace("\r\n", ", "), false);
            Console.WriteLine("Creato il file " + File + "_Cloze_SOLUTION.txt \r\n (parole escluse nell'ordine di esclusione)");

            // mescola le parole cancellate
            string[] parole = paroleCancellate.Substring(0, paroleCancellate.Length - 2).Replace("\r", "").Split('\n');
            Console.WriteLine("Creato il file " + File + "_Cloze_WORDS.txt \r\n (elenco mischiato delle parole omesse)");
            //MescolaArrayStringhe(parole);
            Comuni.OrdinaArrayStringhe(parole);
            // metto in una sola stringa tutto l'array: 
            string file = String.Join(", ", parole);
            // gamon.FileDiTesto.VettoreInFile(File + "_Cloze_WORDS.txt", parole, false);
            gamon.FileDiTesto.StringaInFile(File + "_Cloze_WORDS.txt", file, false);
            return 0;
        }

        public static uint Cloze()
        {
            return Cloze("testo.txt", 0);
        }

        public static uint Cloze(int MediaParole)
        {
            return Cloze("testo.txt", MediaParole);
        }

        private static bool letteraDiParola(char v)
        {
            return Char.IsLetterOrDigit(v);
        }

        private static int prossimaParolaDaCancellare(int MediaParole)
        {
            return MediaParole;
        }

        public class Answer
        {
            public string AnswerText;
            public bool CheckedIsCorrect;
            public double PercentageLostIfWrong;
        }

        public class QuestionnaireQuestion
        {
            public QuestionType Type;
            public string Question;
            public List<Answer> Answers;
        }

        public enum QuestionType
        {
            Exclusive,
            Multiple,
            NonQuestion, 
        }

        public static uint Questionnaire(string File, int seed, int nDifferentTests, int nLinesPerSheet)
        {
            string quadrato = "□";
            string tondo = "⃝";
            string quadratoPieno = "X";
            string tondoPieno = "X";
            //string quadrato = "&£";
            //string tondo = "£$";

            string[,] originalMatrix = gamon.FileDiTesto.FileInMatrice(File,'\t');

            List<QuestionnaireQuestion> questionario = new List<QuestionnaireQuestion>();

            int nQuestion = 0; // row in the array of strings taken from the text file
            QuestionnaireQuestion q = null;
            string r = ""; 
            while (nQuestion < originalMatrix.GetLength(0)) 
            {
                string codice = originalMatrix[nQuestion, 0].Trim();
                string domandaORisposta = originalMatrix[nQuestion, 1].Trim();
                double percentuale = Comuni.doub(originalMatrix[nQuestion, 2]);
                QuestionType tipo = TipoDomanda(codice);
                Answer risp = new Answer();
                if (!(tipo == QuestionType.NonQuestion))
                {   // nuova domanda
                    if (q != null)
                    {
                        questionario.Add(q);
                    }
                    q = new QuestionnaireQuestion();
                    q.Type = tipo;
                    if (domandaORisposta != "")
                        q.Question = domandaORisposta;
                    q.Answers = new List<Answer>();
                }
                else
                {   // nuova risposta
                    if (domandaORisposta != "")
                    { 
                        risp.AnswerText = domandaORisposta;
                        if (codice == "X" || codice == "x")
                        {
                            risp.CheckedIsCorrect = true;
                        }
                        else
                        {
                            risp.CheckedIsCorrect = false;
                        }
                        risp.PercentageLostIfWrong = percentuale; 
                        q.Answers.Add(risp);
                    }
                }
                nQuestion++;
            }

            // creazione questionari
            if (System.IO.File.Exists(File + "_QUEST.txt"))
                System.IO.File.Delete(File + "_QUEST.txt");
            if (System.IO.File.Exists(File + "_QUEST_CORR.txt"))
                System.IO.File.Delete(File + "_QUEST_CORR.txt");

            Comuni.rng = new Random(seed);
            char formFeed = (char)0x0C;

            for (int qu = 0; qu < nDifferentTests; qu++)
            {
                Comuni.MescolaLista(questionario);

                string fileQuestionario = "Numero domande: " + questionario.Count +
                        "\t" + seed.ToString().Trim() + (qu + 1).ToString("00").Trim() + "\r\n";
                string fileCorrezione = seed.ToString().Trim() + (qu + 1).ToString("00").Trim() + "\r\n";

                int rigaAttuale = 1;
                foreach (QuestionnaireQuestion dom in questionario)
                {
                    string segno = "";
                    if (dom.Type == QuestionType.Exclusive)
                        segno = tondo;
                    else
                        segno = quadrato;
                    fileQuestionario += dom.Question + "\r\n";
                    fileCorrezione += dom.Question + "\r\n";
                    rigaAttuale++;
                    //// controlla se ci sta la prossima domanda; se no va a prossimo foglio
                    // SE UNA RIPOSTA PRENDE PIù DI UNA RIGA, IL MECCANISMO QUI SOTTO NON FUNZIONA
                    // COMMENTATO
                    //if (rigaAttuale + dom.Answers.Count > nLinesPerSheet)
                    //{
                    //    // aggiunge form feed per cambiare foglio
                    //    file += formFeed;
                    //    gamon.FileDiTesto.StringaInFile(File + "_QUEST.txt", file, true);
                    //}
                    // aggiunge tutte le risposte della domanda
                    Comuni.MescolaLista(dom.Answers);
                    foreach (Answer answ in dom.Answers)
                        if (answ.AnswerText != null)
                        {
                            string correzione ="";
                            if (answ.CheckedIsCorrect)
                                correzione = quadratoPieno + " ";
                            correzione += answ.PercentageLostIfWrong.ToString("0.##") + " "; 
                            fileQuestionario += segno + " " + answ.AnswerText.Trim() + "\r\n";
                            fileCorrezione += correzione + segno + " " + answ.AnswerText.Trim() + "\r\n";
                        }
                    rigaAttuale++;
                    fileQuestionario += "\r\n";
                    fileCorrezione += "\r\n";
                    rigaAttuale++;
                }
                // aggiunge form feed per cambiare foglio
                fileQuestionario += formFeed;
                fileCorrezione += formFeed;
                gamon.FileDiTesto.StringaInFile(File + "_QUEST.txt", fileQuestionario, true);
                gamon.FileDiTesto.StringaInFile(File + "_QUEST_CORR.txt", fileCorrezione, true);
            }
            return 0; 
        }

        private static QuestionType TipoDomanda(string rigaText)
        {
            if (rigaText == "M" || rigaText == "m")
                return QuestionType.Multiple;
            else if (rigaText == "E" || rigaText == "e")
                return QuestionType.Exclusive;
            else
                return QuestionType.NonQuestion; 
        }
    }
}
