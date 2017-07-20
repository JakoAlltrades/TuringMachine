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
            Move9L,
            SeekEnd,
            SeekNumRAfter0,
            SeekNumRAfter1,
            SeekNumRAfter2,
            SeekNumRAfter3,
            SeekNumRAfter4,
            SeekNumRAfter5,
            SeekNumRAfter6,
            SeekNumRAfter7,
            SeekNumRAfter8,
            SeekNumRAfter9,
            Move0After0,
            Move0After1,
            Move0After2,
            Move0After3,
            Move0After4,
            Move0After5,
            Move0After6,
            Move0After7,
            Move0After8,
            Move0After9,
            Move1After0,
            Move1After1,
            Move1After2,
            Move1After3,
            Move1After4,
            Move1After5,
            Move1After6,
            Move1After7,
            Move1After8,
            Move1After9,
            Move2After0,
            Move2After1,
            Move2After2,
            Move2After3,
            Move2After4,
            Move2After5,
            Move2After6,
            Move2After7,
            Move2After8,
            Move2After9,
            Move3After0,
            Move3After1,
            Move3After2,
            Move3After3,
            Move3After4,
            Move3After5,
            Move3After6,
            Move3After7,
            Move3After8,
            Move3After9,
            Move4After0,
            Move4After1,
            Move4After2,
            Move4After3,
            Move4After4,
            Move4After5,
            Move4After6,
            Move4After7,
            Move4After8,
            Move4After9,
            Move5After0,
            Move5After1,
            Move5After2,
            Move5After3,
            Move5After4,
            Move5After5,
            Move5After6,
            Move5After7,
            Move5After8,
            Move5After9,
            Move6After0,
            Move6After1,
            Move6After2,
            Move6After3,
            Move6After4,
            Move6After5,
            Move6After6,
            Move6After7,
            Move6After8,
            Move6After9,
            Move7After0,
            Move7After1,
            Move7After2,
            Move7After3,
            Move7After4,
            Move7After5,
            Move7After6,
            Move7After7,
            Move7After8,
            Move7After9,
            Move8After0,
            Move8After1,
            Move8After2,
            Move8After3,
            Move8After4,
            Move8After5,
            Move8After6,
            Move8After7,
            Move8After8,
            Move8After9,
            Move9After0,
            Move9After1,
            Move9After2,
            Move9After3,
            Move9After4,
            Move9After5,
            Move9After6,
            Move9After7,
            Move9After8,
            Move9After9,
            Carry1AndPlace0,
            Carry1AndPlace1,
            Carry1AndPlace2,
            Carry1AndPlace3,
            Carry1AndPlace4,
            Carry1AndPlace5,
            Carry1AndPlace6,
            Carry1AndPlace7,
            Carry1AndPlace8
        }

        public void StartMachine()
        {

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
