﻿using System;
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
            while (true)
            {
                tape = Console.ReadLine();
                Machine m = new Machine(tape);
                m.StartMachine();
            }
           
            
        }
        
        
    }
}
