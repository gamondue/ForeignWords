using gamon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionLoopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Comuni.QuestionLoop();
            else if (args.Length == 1)
                Comuni.QuestionLoop(int.Parse(args[0]));
            else if (args.Length == 2)
                Comuni.QuestionLoop(args[0], int.Parse(args[1]));
        }
    }
}
