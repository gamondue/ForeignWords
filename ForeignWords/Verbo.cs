using System;
using System.Collections.Generic;
using System.Text;

namespace gamon.ForeignWords
{
    class Verbo
    {
        public int IdVerbo;
        public string Infinito;
        public string Passato;
        public string ParticipioPassato;
        public string InfinitoInLingua;
        
        public override string ToString() {
            return IdVerbo + "|" + Infinito + "|" + Passato + "|" + ParticipioPassato + "|" + InfinitoInLingua;
        }
    }
}
