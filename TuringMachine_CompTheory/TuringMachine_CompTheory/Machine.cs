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
        bool tapeIsDone = false;
        bool goToEnd = false;
        bool goToBegin = false;
        bool carryToNextSpace = false;
        enum states
        {
            SeekPlus,
            SeekPlusAfterCarry,
            SeekNumLAfterCarry,
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
            Place0,
            Place1,
            Place2,
            Place3,
            Place4,
            Place5,
            Place6,
            Place7,
            Place8,
            Place9,
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
            while(!tapeIsDone)
            {
                TapeProcess();
            }
        }

        private void TapeProcess()
        {
            char[] tapeArray = curTape.ToArray();
            char seek, replace;
            char curChar = curTape[curPos];
            if(curState.Equals(states.SeekPlus))
            {
                seek = '+';
                replace = '+';
                if(curChar == seek)
                {
                    tapeArray[curPos] = replace;
                    curState = states.SeekNumL;
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else if(curState.Equals(states.SeekNumL))
            {
                if (!carryToNextSpace)
                {
                    //This state has multipleSeek Characters ie (0-9)
                    replace = 'x';
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0L;
                                break;
                            case '1':
                                curState = states.Move1L;
                                break;
                            case '2':
                                curState = states.Move2L;
                                break;
                            case '3':
                                curState = states.Move3L;
                                break;
                            case '4':
                                curState = states.Move4L;
                                break;
                            case '5':
                                curState = states.Move5L;
                                break;
                            case '6':
                                curState = states.Move6L;
                                break;
                            case '7':
                                curState = states.Move7L;
                                break;
                            case '8':
                                curState = states.Move8L;
                                break;
                            case '9':
                                curState = states.Move9L;
                                break;
                        }
                    }
                    else if (curChar == '=')//the second number longer ie: =2+13
                    {
                        curState = states.Move0L;
                    }
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.SeekPlusAfterCarry))
            {
                seek = '+';
                replace = '+';
                if (curChar == seek)
                {
                    tapeArray[curPos] = replace;
                    curState = states.SeekNumLAfterCarry;
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else if (curState.Equals(states.SeekNumLAfterCarry))
            {
                //This state has multipleSeek Characters ie (0-9)
                replace = 'x';
                if (curChar >= 48 && curChar <= 57)
                {
                    tapeArray[curPos] = replace;
                    switch (curChar)
                    {
                        case '0':
                            curState = states.Move1L;
                            break;
                        case '1':
                            curState = states.Move2L;
                            break;
                        case '2':
                            curState = states.Move3L;
                            break;
                        case '3':
                            curState = states.Move4L;
                            break;
                        case '4':
                            curState = states.Move5L;
                            break;
                        case '5':
                            curState = states.Move6L;
                            break;
                        case '6':
                            curState = states.Move7L;
                            break;
                        case '7':
                            curState = states.Move8L;
                            break;
                        case '8':
                            curState = states.Move9L;
                            break;
                        case '9':
                            curState = states.Move0L;
                            carryToNextSpace = true;
                            break;
                    }
                }
                else if (curChar == '=')//the second number longer ie: =2+13
                {
                    curState = states.Move1L;
                }
                MoveLeft();
            }
            else if (curState.Equals(states.Move0L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '0';
                char[] zeroArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = zeroArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter0;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '1';
                char[] oneArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = oneArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter1;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '2';
                char[] twoArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = twoArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter2;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '3';
                char[] threeArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = threeArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter3;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '4';
                char[] fourArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = fourArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter4;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '5';
                char[] fiveArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = fiveArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter5;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '6';
                char[] sixArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = sixArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter6;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '7';
                char[] sevenArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = sevenArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter7;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '8';
                char[] eightArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = eightArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter8;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9L))
            {
                //actually checking if curPos is 0 for all basically
                seek = '=';
                replace = '9';
                char[] nineArray = { replace };
                if (curPos == 0)
                {
                    tapeArray = nineArray.Concat(tapeArray).ToArray();
                    curState = states.SeekNumRAfter9;
                    MoveRight();
                    goToEnd = true;
                }
                else
                {
                    MoveLeft();
                }
            }
            else if(curState.Equals(states.SeekNumRAfter0))
            {
                //basically seeking the end of the string
                replace = 'x';
                if(curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd) {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After0;
                                break;
                            case '1':
                                curState = states.Move1After0;
                                break;
                            case '2':
                                curState = states.Move2After0;
                                break;
                            case '3':
                                curState = states.Move3After0;
                                break;
                            case '4':
                                curState = states.Move4After0;
                                break;
                            case '5':
                                curState = states.Move5After0;
                                break;
                            case '6':
                                curState = states.Move6After0;
                                break;
                            case '7':
                                curState = states.Move7After0;
                                break;
                            case '8':
                                curState = states.Move8After0;
                                break;
                            case '9':
                                curState = states.Move9After0;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the numbers same length ie: =2+1
                    {
                        curState = states.Move0After0;
                        if (!carryToNextSpace)
                        {
                            tapeIsDone = true;
                        }
                        else
                        {
                            goToBegin = true;
                        }
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else if (curState.Equals(states.SeekNumRAfter1))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After1;
                                break;
                            case '1':
                                curState = states.Move1After1;
                                break;
                            case '2':
                                curState = states.Move2After1;
                                break;
                            case '3':
                                curState = states.Move3After1;
                                break;
                            case '4':
                                curState = states.Move4After1;
                                break;
                            case '5':
                                curState = states.Move5After1;
                                break;
                            case '6':
                                curState = states.Move6After1;
                                break;
                            case '7':
                                curState = states.Move7After1;
                                break;
                            case '8':
                                curState = states.Move8After1;
                                break;
                            case '9':
                                curState = states.Move9After1;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After1;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else if (curState.Equals(states.SeekNumRAfter2))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After2;
                                break;
                            case '1':
                                curState = states.Move1After2;
                                break;
                            case '2':
                                curState = states.Move2After2;
                                break;
                            case '3':
                                curState = states.Move3After2;
                                break;
                            case '4':
                                curState = states.Move4After2;
                                break;
                            case '5':
                                curState = states.Move5After2;
                                break;
                            case '6':
                                curState = states.Move6After2;
                                break;
                            case '7':
                                curState = states.Move7After2;
                                break;
                            case '8':
                                curState = states.Move8After2;
                                break;
                            case '9':
                                curState = states.Move9After2;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After2;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }

            }
            else if (curState.Equals(states.SeekNumRAfter3))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After3;
                                break;
                            case '1':
                                curState = states.Move1After3;
                                break;
                            case '2':
                                curState = states.Move2After3;
                                break;
                            case '3':
                                curState = states.Move3After3;
                                break;
                            case '4':
                                curState = states.Move4After3;
                                break;
                            case '5':
                                curState = states.Move5After3;
                                break;
                            case '6':
                                curState = states.Move6After3;
                                break;
                            case '7':
                                curState = states.Move7After3;
                                break;
                            case '8':
                                curState = states.Move8After3;
                                break;
                            case '9':
                                curState = states.Move9After3;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After3;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }

            }
            else if (curState.Equals(states.SeekNumRAfter4))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After4;
                                break;
                            case '1':
                                curState = states.Move1After4;
                                break;
                            case '2':
                                curState = states.Move2After4;
                                break;
                            case '3':
                                curState = states.Move3After4;
                                break;
                            case '4':
                                curState = states.Move4After4;
                                break;
                            case '5':
                                curState = states.Move5After4;
                                break;
                            case '6':
                                curState = states.Move6After4;
                                break;
                            case '7':
                                curState = states.Move7After4;
                                break;
                            case '8':
                                curState = states.Move8After4;
                                break;
                            case '9':
                                curState = states.Move9After4;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After4;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else if (curState.Equals(states.SeekNumRAfter5))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After5;
                                break;
                            case '1':
                                curState = states.Move1After5;
                                break;
                            case '2':
                                curState = states.Move2After5;
                                break;
                            case '3':
                                curState = states.Move3After5;
                                break;
                            case '4':
                                curState = states.Move4After5;
                                break;
                            case '5':
                                curState = states.Move5After5;
                                break;
                            case '6':
                                curState = states.Move6After5;
                                break;
                            case '7':
                                curState = states.Move7After5;
                                break;
                            case '8':
                                curState = states.Move8After5;
                                break;
                            case '9':
                                curState = states.Move9After5;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After5;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else if (curState.Equals(states.SeekNumRAfter6))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After6;
                                break;
                            case '1':
                                curState = states.Move1After6;
                                break;
                            case '2':
                                curState = states.Move2After6;
                                break;
                            case '3':
                                curState = states.Move3After6;
                                break;
                            case '4':
                                curState = states.Move4After6;
                                break;
                            case '5':
                                curState = states.Move5After6;
                                break;
                            case '6':
                                curState = states.Move6After6;
                                break;
                            case '7':
                                curState = states.Move7After6;
                                break;
                            case '8':
                                curState = states.Move8After6;
                                break;
                            case '9':
                                curState = states.Move9After6;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After6;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }

            }
            else if (curState.Equals(states.SeekNumRAfter7))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After7;
                                break;
                            case '1':
                                curState = states.Move1After7;
                                break;
                            case '2':
                                curState = states.Move2After7;
                                break;
                            case '3':
                                curState = states.Move3After7;
                                break;
                            case '4':
                                curState = states.Move4After7;
                                break;
                            case '5':
                                curState = states.Move5After7;
                                break;
                            case '6':
                                curState = states.Move6After7;
                                break;
                            case '7':
                                curState = states.Move7After7;
                                break;
                            case '8':
                                curState = states.Move8After7;
                                break;
                            case '9':
                                curState = states.Move9After7;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After7;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }

            }
            else if (curState.Equals(states.SeekNumRAfter8))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After8;
                                break;
                            case '1':
                                curState = states.Move1After8;
                                break;
                            case '2':
                                curState = states.Move2After8;
                                break;
                            case '3':
                                curState = states.Move3After8;
                                break;
                            case '4':
                                curState = states.Move4After8;
                                break;
                            case '5':
                                curState = states.Move5After8;
                                break;
                            case '6':
                                curState = states.Move6After8;
                                break;
                            case '7':
                                curState = states.Move7After8;
                                break;
                            case '8':
                                curState = states.Move8After8;
                                break;
                            case '9':
                                curState = states.Move9After8;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After8;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }

            }
            else if (curState.Equals(states.SeekNumRAfter9))
            {
                //basically seeking the end of the string
                replace = 'x';
                if (curPos == tapeArray.Length - 1)
                {
                    goToEnd = false;
                }
                if (!goToEnd)
                {
                    if (curChar >= 48 && curChar <= 57)
                    {
                        tapeArray[curPos] = replace;
                        switch (curChar)
                        {
                            case '0':
                                curState = states.Move0After9;
                                break;
                            case '1':
                                curState = states.Move1After9;
                                break;
                            case '2':
                                curState = states.Move2After9;
                                break;
                            case '3':
                                curState = states.Move3After9;
                                break;
                            case '4':
                                curState = states.Move4After9;
                                break;
                            case '5':
                                curState = states.Move5After9;
                                break;
                            case '6':
                                curState = states.Move6After9;
                                break;
                            case '7':
                                curState = states.Move7After9;
                                break;
                            case '8':
                                curState = states.Move8After9;
                                break;
                            case '9':
                                curState = states.Move9After9;
                                break;
                        }
                        goToBegin = true;
                    }
                    else if (curChar == '+')//the first number os longer ie: =12+1
                    {
                        curState = states.Move0After9;
                        goToBegin = true;
                    }
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }

            }
            else if (curState.Equals(states.Move0After0))
            {
                seek = '0';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After0))
            {
                seek = '0';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After0))
            {
                seek = '0';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After0))
            {
                seek = '0';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After0))
            {
                seek = '0';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After0))
            {
                seek = '0';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After0))
            {
                seek = '0';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After0))
            {
                seek = '0';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After0))
            {
                seek = '0';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After0))
            {
                seek = '0';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After1))
            {
                seek = '1';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After1))
            {
                seek = '1';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After1))
            {
                seek = '1';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After1))
            {
                seek = '1';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After1))
            {
                seek = '1';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After1))
            {
                seek = '1';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After1))
            {
                seek = '1';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After1))
            {
                seek = '1';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After1))
            {
                seek = '1';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After1))
            {
                seek = '1';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After2))
            {
                seek = '2';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After2))
            {
                seek = '2';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After2))
            {
                seek = '2';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After2))
            {
                seek = '2';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After2))
            {
                seek = '2';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After2))
            {
                seek = '2';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After2))
            {
                seek = '2';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After2))
            {
                seek = '2';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After2))
            {
                seek = '2';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After2))
            {
                seek = '2';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After3))
            {
                seek = '3';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After3))
            {
                seek = '3';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After3))
            {
                seek = '3';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After3))
            {
                seek = '3';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After3))
            {
                seek = '3';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After3))
            {
                seek = '3';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After3))
            {
                seek = '3';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After3))
            {
                seek = '3';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After3))
            {
                seek = '3';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After3))
            {
                seek = '3';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After4))
            {
                seek = '4';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After4))
            {
                seek = '4';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After4))
            {
                seek = '4';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After4))
            {
                seek = '4';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After4))
            {
                seek = '4';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After4))
            {
                seek = '4';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After4))
            {
                seek = '4';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After4))
            {
                seek = '4';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After4))
            {
                seek = '4';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After4))
            {
                seek = '4';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After5))
            {
                seek = '5';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After5))
            {
                seek = '5';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After5))
            {
                seek = '5';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After5))
            {
                seek = '5';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After5))
            {
                seek = '5';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After5))
            {
                seek = '5';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After5))
            {
                seek = '5';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After5))
            {
                seek = '5';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After5))
            {
                seek = '5';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlus;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After5))
            {
                seek = '5';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After6))
            {
                seek = '6';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After6))
            {
                seek = '6';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After6))
            {
                seek = '6';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After6))
            {
                seek = '6';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After6))
            {
                seek = '6';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After6))
            {
                seek = '6';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After6))
            {
                seek = '6';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After6))
            {
                seek = '6';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After6))
            {
                seek = '6';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After6))
            {
                seek = '6';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After7))
            {
                seek = '7';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After7))
            {
                seek = '7';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After7))
            {
                seek = '7';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After7))
            {
                seek = '7';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After7))
            {
                seek = '7';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After6))
            {
                seek = '7';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After6))
            {
                seek = '7';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After7))
            {
                seek = '7';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After7))
            {
                seek = '7';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After7))
            {
                seek = '7';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After8))
            {
                seek = '8';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After8))
            {
                seek = '8';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if (!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After8))
            {
                seek = '8';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After8))
            {
                seek = '8';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After8))
            {
                seek = '8';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After8))
            {
                seek = '8';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After8))
            {
                seek = '8';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After8))
            {
                seek = '8';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After8))
            {
                seek = '8';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After8))
            {
                seek = '8';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move0After9))
            {
                seek = '9';
                replace = '9';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        if(!carryToNextSpace)
                        {
                            curState = states.SeekPlus;
                        }
                        else
                        {
                            curState = states.SeekPlusAfterCarry;
                            carryToNextSpace = false;
                        }
                        
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move1After9))
            {
                seek = '9';
                replace = '0';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move2After9))
            {
                seek = '9';
                replace = '1';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move3After9))
            {
                seek = '9';
                replace = '2';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move4After9))
            {
                seek = '9';
                replace = '3';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move5After9))
            {
                seek = '9';
                replace = '4';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move6After9))
            {
                seek = '9';
                replace = '5';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move7After9))
            {
                seek = '9';
                replace = '6';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move8After9))
            {
                seek = '9';
                replace = '7';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else if (curState.Equals(states.Move9After9))
            {
                seek = '9';
                replace = '8';
                if (curPos == 0)
                {
                    goToBegin = false;
                }
                if (!goToBegin)
                {
                    if (curChar == seek)
                    {
                        tapeArray[curPos] = replace;
                        curState = states.SeekPlusAfterCarry;
                    }
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            curTape = TapeArrayToString(tapeArray);
           Console.WriteLine(TapeArrayToString(tapeArray));
        }

        private string TapeArrayToString(char[] tapeArray)
        {
            string result = "";
            for(int j = 0; j < tapeArray.Length; j++)
            {
                result += tapeArray[j];
            }
            return result;  
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