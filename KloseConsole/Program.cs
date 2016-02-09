﻿using gamon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClozeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuestionLoop.\r\nVersione " +
    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + "\r\n" +
    "Mescola un insieme di 'Concetti' e 'Definizioni' in modo da creare\r\n un question loop.\r\n" +
    "Uso:\r\nQuestionLoop File NumeroAllievi\r\n" +
    "     File è percorso e nome del file da usare\r\n" +
    "     NumeroAllievi è il numero di domande per il loop\r\n" +
    "QuestionLoop NumeroAllievi\r\n" +
    "     Il file usato è 'definizioni.txt'\r\n" +
    "     NumeroAllievi è il numero di domande per il loop\r\n" +
    "QuestionLoop\r\n" +
    "     Il file usato è 'definizioni.txt'\r\n" +
    "     Il programma usa tutte le domande che trova nel file\r\n"
    );
            if (args.Length == 0)
                Comuni.Cloze();
            else if (args.Length == 1)
                Comuni.Cloze(args[0]);
            else if (args.Length == 2)
                Comuni.Cloze(args[0], int.Parse(args[1]));
        }
    }
}