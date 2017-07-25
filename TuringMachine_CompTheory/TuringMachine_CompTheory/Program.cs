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
            string tape;
            bool run = true;
            while (run)
            {
                Console.WriteLine("Please enter an addition formula or quit. (ie: =5+5)");
                tape = Console.ReadLine();
                if(tape == "quit")
                {
                    run = false;
                }
                else if (tape != "")
                {
                    Machine m = new Machine(tape);
                    m.StartMachine();
                }
            }
           
            
        }
        
        
    }
}
