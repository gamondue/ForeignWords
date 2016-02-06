using System;
using System.Collections.Generic;
using System.Text;

namespace gamon.scuola
{
    class QuestionLoop
    {
        string file = "definizioni.txt";
        string[,] definizioni; 

        public QuestionLoop()
        {
            definizioni = gamon.FileDiTesto.FileInMatrice(file, "\t");
            int nAllievi = definizioni.GetLength(0);
        }
        public QuestionLoop(string File, int NAllievi)
        {
            file = File; 
            string[,] definizioni = gamon.FileDiTesto.FileInMatrice(File, "\t"); 
        }

    }
}
