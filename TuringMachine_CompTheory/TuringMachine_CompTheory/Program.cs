using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine_CompTheory
{
    public class Program
    {
        string tape = "=7+2";
        public static void Main(string[] args)
        {
            Machine m = new Machine(tape);
        }
        
        
    }
}
