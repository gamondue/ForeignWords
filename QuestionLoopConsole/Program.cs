using System;
using gamon;

namespace QuestionLoopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuestionLoop.\tVersione " +
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + "\r\n" +
                "Prof. Gabriele MONTI - ITT Blaise Pascal - Cesena\r\n" +
                "Mescola un insieme di 'Concetti' e 'Definizioni' in modo da creare\r\n un question loop.\r\n" +
                "Uso:\r\nQuestionLoop File NumeroAllievi\r\n" +
                "     File: percorso e nome del file da usare\r\n" +
                "     NumeroAllievi: è il numero di domande per il loop\r\n" +
                "QuestionLoop NumeroAllievi\r\n" +
                "     Il file usato è 'definizioni.txt'\r\n" +
                "     NumeroAllievi: è il numero di domande per il loop\r\n" +
                "QuestionLoop\r\n" +
                "     Il file usato è 'definizioni.txt'\r\n" +
                "     Il programma usa tutte le domande che trova nel file\r\n"
                );
            if (args.Length == 0)
                ComuniGamonScuola.QuestionLoop();
            else if (args.Length == 1)
                ComuniGamonScuola.QuestionLoop(int.Parse(args[0]));
            else if (args.Length == 2)
                ComuniGamonScuola.QuestionLoop(args[0], int.Parse(args[1]));
            Console.WriteLine("\r\nFine programma.");
        }
    }
}

