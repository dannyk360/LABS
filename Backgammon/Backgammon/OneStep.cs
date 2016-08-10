using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public struct OneStep
    {
        public int _from;
        public int _to;


        public OneStep(int from, int to) 
        {
            _from = from;
            _to = to;
        }
    }
}
