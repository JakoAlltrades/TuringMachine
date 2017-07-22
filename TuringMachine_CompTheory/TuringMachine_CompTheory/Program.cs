using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine_CompTheory
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            string tape = "=999+101";
            Machine m = new Machine(tape);
            m.StartMachine();
            Console.ReadLine();
        }
        
        
    }
}
