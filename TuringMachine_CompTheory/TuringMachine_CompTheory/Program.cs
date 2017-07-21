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
            string tape = "=1+1";
            Machine m = new Machine(tape);
            m.StartMachine();
            Console.ReadLine();
        }
        
        
    }
}
