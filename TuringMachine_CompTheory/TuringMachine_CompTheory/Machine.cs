using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine_CompTheory
{
    public class Machine
    {
        int curPos = 0;
        Enum curState = states.SeekPlus;
        private string initialTape;
        string curTape;
        enum states
        {
            SeekPlus,
            SeekNumL,
            Move0L,
            Move1L,
            Move2L,
            Move3L,
            Move4L,
            Move5L,
            Move6L,
            Move7L,
            Move8L,
            Move9L
        }

        public Machine(string tape)
        {
            initialTape = tape;
            curTape = initialTape;
        }

        public void MoveLeft()
        {
            curPos = curPos - 1;
        }

        public void MoveRight()
        {
            curPos = curPos + 1;
        }

        
    }
}
