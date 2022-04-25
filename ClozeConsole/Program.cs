using System;
using gamon;

namespace ClozeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cloze.\tVersione " +
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + "\r\n" +
                "Prof. Gabriele MONTI - ITT Blaise Pascal - Cesena\r\n" +
                "Toglie da un testo delle parole sostituendole con '_'\r\ne salvando in un file (*_Cloze.txt).\r\n" +
                "Raccoglie le parole tolte in un altro file (*_Cloze_SOLUTION.txt).\r\n" +
                "Mescola le parole tolte, memorizzandole in un terzo file (*_Cloze_WORDS.txt).\r\n" +
                "Uso:\r\n" +
                "Cloze File NumeroParole\r\n" +
                "     File è percorso e nome del file originale da usare\r\n" +
                "     NumeroParole è il numero di parole oltre il quale si toglie una parola\r\n" +
                "     dal testo originale\r\n" +
                "Cloze NumeroParole\r\n" +
                "     Il file usato è 'testo.txt'\r\n" +
                "     NumeroParole è il numero di parole oltre il quale si toglie una parola\r\n" +
                "Cloze\r\n" +
                "     Il file usato è 'testo.txt'\r\n" +
                "     Il programma usa tutte le domande che trova nel file\r\n"
                );
            if (args.Length == 0)
                ComuniGamonScuola.Cloze();
            else if (args.Length == 1)
                ComuniGamonScuola.Cloze(int.Parse(args[0]));
            else if (args.Length == 2)
                ComuniGamonScuola.Cloze(args[0], int.Parse(args[1]));
            Console.WriteLine("\r\nFine programma.");
        }
    }
}

