using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace gamon
{
    public static class FileDiTesto
    {
        private static StreamWriter openFileOut(string nomeFile)
        {
            Encoding fileEncoding = Encoding.Default;
            try
            {
                //prova ad aprire il file
                FileStream fsOut = new FileStream(nomeFile, FileMode.Truncate, FileAccess.Write, FileShare.Read);
                StreamWriter fOut = new StreamWriter(fsOut, fileEncoding);

                return (fOut);
            }
            catch
            {	// il nome del file è sbagliato o non si riesce ad aprirlo
                Console.WriteLine("Non si riesce ad aprire il file. Provo a crearlo" + nomeFile);
                // lo apro creandolo
                FileStream fsOut = new FileStream(nomeFile, FileMode.Create, FileAccess.Write, FileShare.Read);
                StreamWriter fOut = new StreamWriter(fsOut, fileEncoding);

                return (fOut);
            }
        }

        public static void CreaFileVuoto(string nomeFile, string stringa)
        {
            Encoding fileEncoding = Encoding.Default;
            FileStream fsOut = new FileStream(nomeFile, FileMode.Create, FileAccess.Write, FileShare.Read);
            StreamWriter fOut = new StreamWriter(fsOut, fileEncoding);

            fOut.WriteLine(stringa);

            fOut.Close();
        }

        public static bool StringaInFile(string nomeFile, string stringa)
        {   // scrive una stringa in un file di testo
            StreamWriter fileOut;
            fileOut = openFileOut(nomeFile);
            try
            {
                fileOut.Write(stringa);
                fileOut.Close();
                return true;
            } catch {
                return false; 
            }
        }

        public static string FileInStringa(string nFile)
        {
            // legge riga per riga in un array di stringhe un file di testo
            string stringaFile = "";

            try
            {
                // prova ad aprire il file
                Encoding fileEncoding = Encoding.Default;
                FileStream fsIn = new FileStream(nFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fsIn, fileEncoding, true);

                stringaFile = sr.ReadToEnd();
                //nLine = 0;
                //// lettura nella stringa di tutte le righe del file
                //for (string Line = sr.ReadLine(); Line != null; Line = sr.ReadLine())
                //{
                //    stringaFile += Line + "\r\n";
                //    nLine++;
                //}
                //// toglie l'ultima andata a capo che era sata aggiunta
                //stringaFile = stringaFile.Substring(0, stringaFile.Length - 2);

                // chiusura dello StreamReader
                sr.Close();
            }
            catch
            {	// il nome del file è sbagliato o non si riesce al leggerlo
                if (nFile != "")
                {
                    Console.WriteLine("Il file " + nFile + " non è leggibile");
                }
                return null;
            }
            return (stringaFile);
        }

        public static bool VettoreInFile(string nomeFile, string[] stringa)
        {   // scrive riga per riga un array di stringhe in un file di testo
            StreamWriter fileOut;
            try
            {
                fileOut = openFileOut(nomeFile);

                foreach (string st in stringa)
                {
                    fileOut.WriteLine(st);
                }
                fileOut.Close();
                return true;

            } catch {
                return false ;
            }
        }

        public static string[] FileInVettore(string nFile)
        {
            // legge riga per riga in un array di stringhe un file di testo
            int nLine = 0;
            string[] stringaFile = new string[0];

            Array.Resize(ref stringaFile, 0);

            try
            {
                // prova ad aprire il file
                Encoding fileEncoding = Encoding.Default;
                FileStream fsIn = new FileStream(nFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fsIn, fileEncoding, true);

                nLine = 0;
                // lettura nell'array di tutte le righe del file
                for (string Line = sr.ReadLine(); Line != null; Line = sr.ReadLine())
                {
                    Array.Resize(ref stringaFile, stringaFile.Length + 1);
                    stringaFile[nLine] = Line;
                    nLine++;
                }
                // chiusura dello StreamReader
                sr.Close();
            }
            catch
            {	// il nome del file è sbagliato o non si riesce al leggerlo
                if (nFile != "")
                {
                    Console.WriteLine("Il file " + nFile + " non è leggibile");
                }
                return null;
            }
            return (stringaFile);
        }

        public static string[,] FileInMatrice(string nFile, char separatore)
        {
            // legge riga per riga in un array di stringhe un file di testo
            int nLine = 0;
            string[,] MatriceFile = new string[0, 0]; // inizializzazione fittizia, quella buona dopo

            try
            {
                // prova ad aprire il file
                Encoding fileEncoding = Encoding.Default;
                FileStream fsIn = new FileStream(nFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fsIn, fileEncoding, true);
                // prima lettura del file per determinare il numero delle righe e delle colonne
                int nRighe = 0;
                int nColonne = 0;
                // lettura nell'array di tutte le righe del file
                for (string Line = sr.ReadLine(); Line != null; Line = sr.ReadLine())
                {
                    string[] campi = Line.Split(separatore);
                    if (campi.Length > nColonne)
                        nColonne = campi.Length;
                    nRighe++;
                }
                // chiusura dello StreamReader
                sr.Close();

                // creazione della matrice
                MatriceFile = new string[nRighe, nColonne];

                // riapertura del file per il riempimento della matrice
                fsIn = new FileStream(nFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fsIn, fileEncoding, true);
                nLine = 0;
                // lettura nella matrice di tutte le righe del file
                for (string Line = sr.ReadLine(); Line != null; Line = sr.ReadLine())
                {
                    string[] campi = Line.Split(separatore);
                    for (int j = 0; j < campi.Length; j++)
                    {
                        MatriceFile[nLine, j] = campi[j];
                    }
                    nLine++;
                }
                // chiusura dello StreamReader
                sr.Close();
            }
            catch
            {	// il nome del file è sbagliato o non si riesce al leggerlo
                if (nFile != "")
                {
                    Console.WriteLine("Il file " + nFile + " non è leggibile");
                }
                return (null);
            }
            return (MatriceFile);
        }

        public static string[,] FileInMatrice(string nFile, char separatore, ref string[] primaRiga)
        {
            /// legge riga per riga in un array di stringhe un file di testo
            /// la prima riga viene separata dal resto del file e scritta nel vettore primaRiga
            int nLine = 0;
            string Line;
            string[,] MatriceFile = new string[0, 0]; // inizializzazione fittizia, quella buona dopo
            try
            {
                // prova ad aprire il file
                Encoding fileEncoding = Encoding.Default;
                FileStream fsIn = new FileStream(nFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fsIn, fileEncoding, true);
                // prima lettura del file per determinare il numero delle righe e delle colonne
                int nRighe = 0;
                int nColonne = 0;
                // lettura nell'array di tutte le righe del file
                for (Line = sr.ReadLine(); Line != null; Line = sr.ReadLine())
                {
                    string[] campi = Line.Split(separatore);
                    if (campi.Length > nColonne)
                        nColonne = campi.Length;
                    nRighe++;
                }
                // chiusura dello StreamReader
                sr.Close();

                // creazione della matrice
                MatriceFile = new string[nRighe -1, nColonne];

                // riapertura del file per il riempimento della matrice
                fsIn = new FileStream(nFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fsIn, fileEncoding, true);
                nLine = 0;
                // lettura nella stringa primaRiga della prima riga del file
                Line = sr.ReadLine();
                primaRiga = Line.Split(separatore);

                // lettura nella matrice di tutte le righe del file
                for (Line = sr.ReadLine(); Line != null; Line = sr.ReadLine())
                {
                    string[] campi = Line.Split(separatore);
                    for (int j = 0; j < campi.Length; j++)
                    {
                        MatriceFile[nLine, j] = campi[j]; // OCCHIO, QUI SE C'è UN CAMPO NULL SI INCHIODA!!!
                    }
                    nLine++;
                }
                // chiusura dello StreamReader
                sr.Close();
            }
            catch
            {	// il nome del file è sbagliato o non si riesce al leggerlo
                if (nFile != "")
                {
                    Console.WriteLine("Il file " + nFile + " non è leggibile");
                }
                return(null);
            }
            return (MatriceFile);
        }

        public static bool MatriceInFile(string nomeFile, string[,] Matrice, char separatore)
        {   /// scrive riga per riga un array di stringhe in un file di testo
            StreamWriter fileOut;
            try
            {
                fileOut = openFileOut(nomeFile);
                for (int i = 0; i < Matrice.GetLength(0); i++)
                {
                    string linea = Matrice[i, 0];
                    for (int j = 1; j < Matrice.GetLength(1); j++)
                    {
                        linea += separatore + Matrice[i, j];
                    }
                    fileOut.WriteLine(linea);
                }
                fileOut.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool MatriceInFile(string nomeFile, string[,] Matrice, char separatore, string[] primaRiga)
        {   /// scrive riga per riga un array di stringhe in un file di testo
            /// la prima riga viene gestita separatamente. Viene scritta la prima riga, poi il contenuto di tutta la matice. 
            StreamWriter fileOut;
            try
            {
                fileOut = openFileOut(nomeFile);
                if (fileOut != null)
                {
                    string linea = primaRiga[0];
                    for (int j = 1; j < Matrice.GetLength(1); j++)
                    {
                        linea += separatore + primaRiga[j];
                    }
                    fileOut.WriteLine(linea);
                    for (int i = 0; i < Matrice.GetLength(0); i++)
                    {
                        linea = Matrice[i, 0];
                        for (int j = 1; j < Matrice.GetLength(1); j++)
                        {
                            linea += separatore + Matrice[i, j];
                        }
                        fileOut.WriteLine(linea);
                    }
                    fileOut.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
