using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_25x25.Event;

namespace Tic_Tac_Toe_25x25
{
    class Array2D
    {
        protected WinEventArgs winEventArgs;
        protected EnermyEventArgs enermyEventArgs;
        protected PeopleNearWinEventArgs peopleNearWin;
        protected EnermyNearWinEventArgs enermyNearWinEvent;

        public event EventHandler<WinEventArgs> WinEvent;
        public event EventHandler<EnermyEventArgs> EnermyEvent;
        public event EventHandler<PeopleNearWinEventArgs> PeopleNearWinEvent;
        public event EventHandler<EnermyNearWinEventArgs> EnermyNearWinEvent;

        protected short[] Data { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
       
        public Array2D(int Size)
        {
            EventImplementClass();

            Array2D array2D = this;
            array2D.Size = Size;
            Count = Size * Size;
            Data = new short[Count];
            for (int i = 0; i < Count; i++)
            {
                Data[i] = -1;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < Count; i++)
            {
                Data[i] = -1;
            }
        }

        private void EventImplementClass()
        {
            winEventArgs = new WinEventArgs();
            enermyEventArgs = new EnermyEventArgs();
            peopleNearWin = new PeopleNearWinEventArgs();
            enermyNearWinEvent = new EnermyNearWinEventArgs();
        }

        //bug here
        protected bool Win2RoadForWard(int Size, int code = 2)
        {
            if (code == 0)
            {
                //FirstIndex
                //Rigth
                if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                    !IsLastColumn(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsUpRow(peopleNearWin.FirstIndex))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Left
                else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsFirstColumn(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsLastColumn(peopleNearWin.FirstIndex))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsFirstColumn(peopleNearWin.FirstIndex - (Size)) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size)) &&
                    !IsLastColumn(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }

            else if (code == 1)
            {
                //LastIndex
                //Right
                if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Left
                else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                    !IsFirstColumn(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsDownRow(peopleNearWin.LastIndex))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                    !IsFirstColumn(peopleNearWin.LastIndex - (Size)) &&
                    !IsLastColumn(peopleNearWin.LastIndex + (Size)) &&
                    !IsDownRow(peopleNearWin.LastIndex + (Size)) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }


            else if (code == 2)
            {
                if (!IsUsed(peopleNearWin.FirstIndex) && !IsUsed(peopleNearWin.LastIndex))
                {
                    //FirstIndex
                    //Rigth
                    if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsUpRow(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Left
                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                        !IsUpRow(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsLastColumn(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex - (Size)) &&
                        !IsUpRow(peopleNearWin.FirstIndex - (Size)) &&
                        !IsDownRow(peopleNearWin.FirstIndex + (Size)) &&
                        !IsLastColumn(peopleNearWin.FirstIndex + (Size)))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //LastIndex
                    //Right
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Left
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                        !IsFirstColumn(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsUpRow(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex - (Size)) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size)) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size)) &&
                        !IsUpRow(peopleNearWin.LastIndex - (Size)))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

            else if (!(code >= 0 && code <= 2))
            {
                throw new System.ArgumentException("(0) For FirstIndex" +
                    "(1) For LastIndex" +
                    "(2) For Bot LastIndex And FirstIndex");
            }

            else return false;
        }

        protected bool Win2RoadBackWard(int Size, int code = 2)
        {
            if (code == 0)
            {
                //FirstIndex
                //Rigth
                if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                    !IsLastColumn(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsUpRow(peopleNearWin.FirstIndex))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Left
                else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsFirstColumn(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsLastColumn(peopleNearWin.FirstIndex))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsFirstColumn(peopleNearWin.FirstIndex - (Size)) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size)) &&
                    !IsLastColumn(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }

            else if (code == 1)
            {
                //LastIndex
                //Right
                if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Left
                else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                    !IsFirstColumn(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsDownRow(peopleNearWin.LastIndex))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                    !IsFirstColumn(peopleNearWin.LastIndex - (Size)) &&
                    !IsLastColumn(peopleNearWin.LastIndex + (Size)) &&
                    !IsDownRow(peopleNearWin.LastIndex + (Size)) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }


            else if (code == 2)
            {
                if (!IsUsed(peopleNearWin.FirstIndex) && !IsUsed(peopleNearWin.LastIndex))
                {
                    //FirstIndex
                    //Rigth
                    if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.FirstIndex + (Size) * 2)&&
                        !IsUpRow(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Left
                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                        !IsUpRow(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex - (Size) * 2)&&
                        !IsLastColumn(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex - (Size)) &&
                        !IsUpRow(peopleNearWin.FirstIndex - (Size)) &&
                        !IsDownRow(peopleNearWin.FirstIndex + (Size)) &&
                        !IsLastColumn(peopleNearWin.FirstIndex + (Size)))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //LastIndex
                    //Right
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Left
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                        !IsFirstColumn(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsUpRow(peopleNearWin.LastIndex - (Size) * 2)&&
                        !IsDownRow(peopleNearWin.LastIndex))
                    {                        
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex - (Size)) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size)) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size)) &&
                        !IsUpRow(peopleNearWin.LastIndex - (Size)))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

            else if (!(code >= 0 && code <= 2))
            {
                throw new System.ArgumentException("(0) For FirstIndex" +
                    "(1) For LastIndex" +
                    "(2) For Bot LastIndex And FirstIndex");
            }

            else return false;
        }

        protected bool Win2RoadRow(int Size,int code = 2)
        {
            if (code == 0)
            {
                //FirstIndex
                //Down
                if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Up
                else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size)) &&
                    !IsDownRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsUpRow(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }

            else if (code == 1)
            {
                //LastIndex
                //down
                if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                    !IsDownRow(peopleNearWin.LastIndex + (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Up
                else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size)) &&
                    !IsDownRow(peopleNearWin.LastIndex + (Size)) &&
                    !IsDownRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsUpRow(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }


            else if (code == 2)
            {
                if (!IsUsed(peopleNearWin.FirstIndex) && !IsUsed(peopleNearWin.LastIndex))
                {
                    //FirstIndex
                    //Rigth
                    if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsUpRow(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Left
                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsUpRow(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex - (Size)) &&
                        !IsDownRow(peopleNearWin.FirstIndex) &&
                        !IsUpRow(peopleNearWin.FirstIndex) &&
                        !IsLastColumn(peopleNearWin.FirstIndex + (Size)) &&
                        !IsLastColumn(peopleNearWin.FirstIndex - (Size)) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex + (Size)))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }

                    //LastIndex
                    //Right
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Left
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                        !IsFirstColumn(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsDownRow(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.LastIndex - (Size)) &&
                        !IsFirstColumn(peopleNearWin.LastIndex + (Size)) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size)) &&
                        !IsLastColumn(peopleNearWin.LastIndex - (Size)) &&
                        !IsUpRow(peopleNearWin.LastIndex) &&
                        !IsDownRow(peopleNearWin.LastIndex)) 
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

            else if (!(code >= 0 && code <= 2))
            {
                throw new System.ArgumentException("(0) For FirstIndex" +
                    "(1) For LastIndex" +
                    "(2) For Bot LastIndex And FirstIndex");
            }

            else return false;
        }

        protected bool Win2RoadColumn(int Size, int code = 2)
        {
            if (code == 0)
            {
                //FirstIndex
                //Down
                if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Up
                else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                    !IsUpRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsDownRow(peopleNearWin.FirstIndex + (Size))&&
                    !IsDownRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsUpRow(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.LastIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }

            else if (code == 1)
            {
                //LastIndex
                //down
                if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3)&&
                    !IsDownRow(peopleNearWin.LastIndex + (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Up
                else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3)&&
                    !IsUpRow(peopleNearWin.LastIndex - (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                //Both
                else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                    IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                    !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                    !IsUpRow(peopleNearWin.LastIndex - (Size)) &&
                    !IsDownRow(peopleNearWin.LastIndex + (Size))&&
                    !IsDownRow(peopleNearWin.FirstIndex - (Size)) &&
                    !IsUpRow(peopleNearWin.FirstIndex + (Size)))
                {
                    peopleNearWin.FirstIndex = -1;
                    PeopleNearWinEvent(this, peopleNearWin);
                    return true;
                }
                else return false;
            }


            else if (code == 2)
            {
                if (!IsUsed(peopleNearWin.FirstIndex) && !IsUsed(peopleNearWin.LastIndex))
                {
                    //FirstIndex
                    //Down
                    if (!IsEnermyUsed(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 3) &&
                        !IsDownRow(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Up
                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 3) &&
                        !IsUpRow(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.FirstIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.FirstIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.FirstIndex + (Size) * 2) &&
                        !IsFirstColumn(peopleNearWin.FirstIndex + (Size)) &&
                        !IsDownRow(peopleNearWin.FirstIndex + (Size)) &&
                        !IsUpRow(peopleNearWin.FirstIndex - (Size)))
                    {
                        peopleNearWin.LastIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }

                    //LastIndex
                    //Down
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 3) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsLastColumn(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Up
                    else if (!IsEnermyUsed(peopleNearWin.LastIndex + (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 3) &&
                        !IsUpRow(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsLastColumn(peopleNearWin.LastIndex))
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    //Both
                    else if (IsPeopleUse(peopleNearWin.LastIndex - (Size)) &&
                        IsPeopleUse(peopleNearWin.LastIndex + (Size)) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex - (Size) * 2) &&
                        !IsEnermyUsed(peopleNearWin.LastIndex + (Size) * 2) &&
                        !IsUpRow(peopleNearWin.LastIndex - (Size)) &&
                        !IsDownRow(peopleNearWin.LastIndex + (Size)) &&
                        !IsLastColumn(peopleNearWin.LastIndex + (Size)))  
                    {
                        peopleNearWin.FirstIndex = -1;
                        PeopleNearWinEvent(this, peopleNearWin);
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

            else if (!(code >= 0 && code <= 2))
            {
                throw new System.ArgumentException("(0) For FirstIndex" +
                    "(1) For LastIndex" +
                    "(2) For Bot LastIndex And FirstIndex");
            }

            else return false;
        }

        //

        public bool IsUsed(int index)
        {
            if (index >= 0 && index < Count)
            {
                if (Data[index] == 0 || Data[index] == 1) return true;
                else return false;
            }
            else return false;
        }

        public bool IsPeopleUse(int index)
        {
            if (!IsOutBound(index))
            {
                if (Data[index] == 0) return true;
                else return false;
            }
            else return false;
        }

        public bool IsEnermyUsed(int index)
        {
            if (!IsOutBound(index))
            {
                if (Data[index] == 1) return true;
                else return false;
            }
            else return false;
        }

        public bool IsOutBound(int index)
        {
            if (index >= 0 && index < Count) return false;
            else return true;
        }

        protected bool IsLastColumn(int index)
        {
            for (int i = Size-1; i < Count; i+=Size)
            {
                if (index == i) return true;
            }
            return false;
        }

        protected bool IsFirstColumn(int index)
        {
            for (int i = 0; i < Count; i+=Size)
            {
                if (index == i) return true;
            }
            return false;
        }

        protected bool IsUpRow(int index)
        {
            for (int i = 0; i < Size; i++)
            {
                if (index == i) return true;
            }
            return false;
        }

        protected bool IsDownRow(int index)
        {
            for (int i = Count - Size; i < Count; i++)
            {
                if (index == i) return true;
            }
            return false;
        }

        public void EnermyClick(int index)
        {
            Data[index] = 1;
            EnermyWinForWard();
            EnermyWinBackWard();
            EnermyWinUpDown();
        }

        public void PeopleClick(int index)
        {
            if (IsFirstColumn(index))
            {
                if (index == 0)
                {

                    enermyEventArgs.Size(3);
                    enermyEventArgs.Index[0] = index + Size;
                    enermyEventArgs.Index[1] = index + 1;
                    enermyEventArgs.Index[2] = index + (Size + 1);
                }
                else if (index == 600)
                {
                    enermyEventArgs.Size(3);
                    enermyEventArgs.Index[1] = index - Size;
                    enermyEventArgs.Index[2] = index - (Size - 1);
                    enermyEventArgs.Index[0] = index + 1;
                }
                else
                {
                    enermyEventArgs.Size(5);
                    enermyEventArgs.Index[1] = index - Size;
                    enermyEventArgs.Index[2] = index - (Size - 1);
                    enermyEventArgs.Index[4] = index + 1;
                    enermyEventArgs.Index[0] = index + (Size + 1);
                    enermyEventArgs.Index[3] = index + Size;
                }               
            }
            else if (IsLastColumn(index))
            {
                if (index == 24)
                {
                    enermyEventArgs.Size(3);
                    enermyEventArgs.Index[0] = index + Size;
                    enermyEventArgs.Index[1] = index + (Size - 1);
                    enermyEventArgs.Index[2] = index - 1;
                }
                else if (index == 624)
                {
                    enermyEventArgs.Size(3);
                    enermyEventArgs.Index[0] = index - (Size + 1);
                    enermyEventArgs.Index[1] = index - Size;
                    enermyEventArgs.Index[2] = index - 1;
                }
                else
                {
                    enermyEventArgs.Size(5);
                    enermyEventArgs.Index[1] = index - Size;
                    enermyEventArgs.Index[0] = index - (Size + 1);
                    enermyEventArgs.Index[2] = index + (Size - 1);
                    enermyEventArgs.Index[4] = index + Size;
                    enermyEventArgs.Index[3] = index - 1;
                }               
            }
            else if (IsUpRow(index))
            {
                enermyEventArgs.Size(5);
                enermyEventArgs.Index[3] = index - 1;
                enermyEventArgs.Index[4] = index + 1;
                enermyEventArgs.Index[0] = index + (Size + 1);
                enermyEventArgs.Index[1] = index + (Size - 1);
                enermyEventArgs.Index[2] = index + Size;
            }
            else if (IsDownRow(index))
            {
                enermyEventArgs.Size(5);
                enermyEventArgs.Index[0] = index - (Size + 1);
                enermyEventArgs.Index[1] = index - Size;
                enermyEventArgs.Index[2] = index - (Size - 1);
                enermyEventArgs.Index[3] = index - 1;
                enermyEventArgs.Index[4] = index + 1;
            }
            else
            {
                enermyEventArgs.Size(8);
                enermyEventArgs.Index[3] = index - 1;
                enermyEventArgs.Index[4] = index + 1;
                enermyEventArgs.Index[1] = index - Size;
                enermyEventArgs.Index[6] = index + Size;
                enermyEventArgs.Index[0] = index - (Size + 1);
                enermyEventArgs.Index[7] = index + (Size + 1);
                enermyEventArgs.Index[2] = index - (Size - 1);
                enermyEventArgs.Index[5] = index + (Size - 1);
            }
           
            Data[index] = 0;
            PeopleWinUpDown();
            PeopleWinBackWard();
            PeopleWinForWard();
            if (!EnermyNearWin4Line()){
                if (!EnermyNearLost())
                {
                    if (!EnermyNearWin3Line())
                    {
                        if (!EnermyNearWin2Line())
                        {
                            EnermyEvent(this, enermyEventArgs);
                        }
                    }
                }
            }
        }


        protected bool EnermyLostBackWard()
        {
            int index = 0, win = 0, count = Size - 1;
            int[] Used = new int[Size];
            for (int i = 4; i < Size; i++)
            {
                index = i;
                for (int j = i; j <= i + i; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (!IsUpRow(index) && !IsFirstColumn(index + (Size - 1) * 3) && !IsFirstColumn(index))
                        {
                            if (!IsUsed(index + (Size - 1) * 1) && IsPeopleUse(index + (Size - 1) * 2) && IsPeopleUse(index + (Size - 1) * 3) && !IsEnermyUsed(index - (Size - 1) * 1) && !IsEnermyUsed(index + (Size - 1) * 4))
                            {
                                peopleNearWin.FirstIndex = index + (Size - 1) * 1;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                            else if (IsPeopleUse(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsPeopleUse(index + (Size - 1) * 3) && !IsEnermyUsed(index - (Size - 1) * 1) && !IsEnermyUsed(index + (Size - 1) * 4))
                            {
                                
                                peopleNearWin.FirstIndex = index + (Size - 1) * 2;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                        }
                        if (IsPeopleUse(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsPeopleUse(index + (Size - 1) * 3) && IsPeopleUse(index + (Size - 1) * 4))
                        {
                            peopleNearWin.FirstIndex = index + (Size - 1) * 2;
                            peopleNearWin.LastIndex = -1;
                            PeopleNearWinEvent(this, peopleNearWin);
                            return true;
                        }
                        Used[win] = index;
                        win++;

                        if (win == 2)
                        {
                            if (!IsUpRow(Used[0]) && !IsFirstColumn(Used[1]))
                            {
                                peopleNearWin.LastIndex = Used[1] - 1 + Size;
                                peopleNearWin.FirstIndex = Used[0] + 1 - Size;

                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1)) return true;

                                //2Road Win Column and ForWard
                                //if (Win2Road(Size + 1)) return true;


                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size + 1)) return true;

                                else if (Win2RoadBackWard(Size)) return true;

                                
                            }
                        }

                        else if (win == 3 && !IsFirstColumn(Used[0]) && !IsLastColumn(Used[0]))
                        {
                            peopleNearWin.FirstIndex = Used[0] + 1 - Size;
                            peopleNearWin.LastIndex = Used[2] - 1 + Size;

                            if (IsDownRow(Used[2]) && !IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size, 0)) return true;
                            }
                            if (IsUpRow(Used[0]) && !IsUsed(peopleNearWin.LastIndex))
                            {                             
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size, 1)) return true;
                            }
                            if (!IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size, 0)) return true;

                                
                            }
                            if (!IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                if (Win2RoadBackWard(Size, 1)) return true;

                                
                            }
                        }

                        if (win >= 3)
                        {
                            if (!IsUpRow(Used[0]) && !IsFirstColumn(Used[2]))
                            {
                                peopleNearWin.LastIndex = Used[2] - 1 + Size;
                                peopleNearWin.FirstIndex = Used[0] + 1 - Size;
                                if (!IsUsed(peopleNearWin.LastIndex) && !IsUsed(peopleNearWin.FirstIndex) &&
                                    !IsOutBound(peopleNearWin.FirstIndex) && !IsOutBound(peopleNearWin.LastIndex)
                                    && !IsEnermyUsed(peopleNearWin.LastIndex) && !IsEnermyUsed(peopleNearWin.FirstIndex))
                                {
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }

                            if (win >= 4)
                            {
                                if (IsUpRow(Used[0]))
                                {
                                    peopleNearWin.LastIndex = Used[3] - 1 + Size;
                                    peopleNearWin.FirstIndex = -1;
                                    if (!IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else if (IsFirstColumn(Used[3]))
                                {
                                    peopleNearWin.LastIndex = -1;
                                    peopleNearWin.FirstIndex = Used[0] + 1 - Size;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else
                                {
                                    peopleNearWin.LastIndex = Used[3] - 1 + Size;
                                    peopleNearWin.FirstIndex = Used[0] + 1 - Size; ;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex) && IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.LastIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.FirstIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
            }
            win = 0;
            index = 0;
        
            for (int i = 24 + 25; i <= this.Count; i += Size)
            {
                index = i;
                for (int j = i; j < i + count; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (!IsLastColumn(index) && !IsDownRow(index + (Size - 1) * 3) && !IsDownRow(index))
                        {
                            if (!IsUsed(index + (Size - 1) * 1) && IsPeopleUse(index + (Size - 1) * 2) && IsPeopleUse(index + (Size - 1) * 3) && !IsEnermyUsed(index - (Size - 1) * 1) && !IsEnermyUsed(index + (Size - 1) * 4))
                            {
                                peopleNearWin.FirstIndex = index + (Size - 1) * 1;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                            else if (IsPeopleUse(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsPeopleUse(index + (Size - 1) * 3) && !IsEnermyUsed(index - (Size - 1) * 1) && !IsEnermyUsed(index + (Size - 1) * 4))
                            {

                                peopleNearWin.FirstIndex = index + (Size - 1) * 2;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                        }
                        if (IsPeopleUse(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsPeopleUse(index + (Size - 1) * 3) && IsPeopleUse(index + (Size - 1) * 4))
                        {
                            peopleNearWin.FirstIndex = index + (Size - 1) * 2;
                            peopleNearWin.LastIndex = -1;
                            PeopleNearWinEvent(this, peopleNearWin);
                            return true;
                        }
                        Used[win] = index;
                        win++;

                        if (win == 2)
                        {
                            if (!IsUpRow(Used[0]) && !IsFirstColumn(Used[1]))
                            {
                                peopleNearWin.LastIndex = Used[1] - 1 + Size;
                                peopleNearWin.FirstIndex = Used[0] + 1 - Size;

                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1)) return true;

                                //2Road Win Column and ForWard
                                //if (Win2Road(Size + 1)) return true;


                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size + 1)) return true;

                                else if (Win2RoadBackWard(Size)) return true;

                                
                            }
                        }

                        else if (win == 3 && !IsFirstColumn(Used[0]) && !IsLastColumn(Used[0]))
                        {
                            peopleNearWin.FirstIndex = Used[0] + 1 - Size;
                            peopleNearWin.LastIndex = Used[2] - 1 + Size;

                            if (IsDownRow(Used[2]) && !IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size, 0)) return true;
                            }
                            if (IsUpRow(Used[0]) && !IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size, 1)) return true;
                            }
                            if (!IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadBackWard(Size, 0)) return true;

                                
                            }
                            if (!IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadBackWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadBackWard(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                if (Win2RoadBackWard(Size, 1)) return true;

                                
                            }
                        }

                        if (win >= 3)
                        {
                            if (!IsLastColumn(Used[0]) && !IsDownRow(Used[2]))
                            {
                                peopleNearWin.LastIndex = Used[2] - 1 + Size;
                                peopleNearWin.FirstIndex = Used[0] + 1 - Size;
                                if (!IsUsed(peopleNearWin.LastIndex) && !IsUsed(peopleNearWin.FirstIndex) &&
                                    !IsOutBound(peopleNearWin.FirstIndex) && !IsOutBound(peopleNearWin.LastIndex)
                                    && !IsEnermyUsed(peopleNearWin.LastIndex) && !IsEnermyUsed(peopleNearWin.FirstIndex))
                                {
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }

                            if (win >= 4)
                            {
                                if (IsLastColumn(Used[0]))
                                {
                                    peopleNearWin.LastIndex = Used[3] - 1 + Size;
                                    peopleNearWin.FirstIndex = -1;
                                    if (!IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else if (IsDownRow(Used[3]))
                                {
                                    peopleNearWin.LastIndex = -1;
                                    peopleNearWin.FirstIndex = Used[0] + 1 - Size;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else
                                {
                                    peopleNearWin.LastIndex = Used[3] - 1 + Size;
                                    peopleNearWin.FirstIndex = Used[0] + 1 - Size; ;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex) && IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.LastIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.FirstIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
            return false;
        }


        protected bool EnermyNearLostForWard()
        {
            int index = 0, win = 0, count = Size - 1;
            int[] Used = new int[Size];

            for (int i = Size - 5; i >= 0; i--)
            {
                index = i;
                for (int j = i; j < Size; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (!IsUpRow(index) && !IsLastColumn(index + (Size + 1) * 3) && !IsLastColumn(index)) 
                        {
                            if (!IsUsed(index + (Size + 1) * 1) && IsPeopleUse(index + (Size + 1) * 2) && IsPeopleUse(index + (Size + 1) * 3) && !IsEnermyUsed(index - (Size + 1) * 1) && !IsEnermyUsed(index + (Size + 1) * 4))
                            {
                                peopleNearWin.FirstIndex = index + (Size + 1) * 1;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                            else if (IsPeopleUse(index + (Size + 1) * 1) && !IsUsed(index + (Size + 1) * 2) && IsPeopleUse(index + (Size + 1) * 3) && !IsEnermyUsed(index - (Size + 1) * 1) && !IsEnermyUsed(index + (Size + 1) * 4))
                            {
                                peopleNearWin.FirstIndex = index + (Size + 1) * 2;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                        }
                        if (IsPeopleUse(index + (Size + 1) * 1) && !IsUsed(index + (Size + 1) * 2) && IsPeopleUse(index + (Size + 1) * 3) && IsPeopleUse(index + (Size + 1) * 4))
                        {
                            peopleNearWin.FirstIndex = index + (Size + 1) * 2;
                            peopleNearWin.LastIndex = -1;
                            PeopleNearWinEvent(this, peopleNearWin);
                            return true;
                        }

                        Used[win] = index;
                        win++;

                        if (win == 2)
                        {
                            if (!IsUpRow(Used[0]) && !IsFirstColumn(Used[1]))
                            {
                                peopleNearWin.LastIndex = Used[1] + (Size + 1);
                                peopleNearWin.FirstIndex = Used[0] - (Size + 1);

                                //2Road Win Row and Column
                                if (Win2RoadForWard(1)) return true;

                                //2Road Win Column and ForWard
                                //if (Win2Road(Size + 1)) return true;


                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size - 1)) return true;

                                else if (Win2RoadForWard(Size)) return true;

                            }
                        }

                        else if (win == 3 && !IsFirstColumn(Used[0]) && !IsLastColumn(Used[0]))
                        {
                            peopleNearWin.FirstIndex = Used[0] - (Size + 1);
                            peopleNearWin.LastIndex = Used[2] + (Size + 1);

                            if (IsDownRow(Used[2]) && !IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size, 0)) return true;
                            }
                            if (IsUpRow(Used[0]) && !IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size, 1)) return true;
                            }
                            if (!IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size, 0)) return true;

                                
                            }
                            if (!IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 1)) return true;

                                //2Road Win Column and BackWard
                                if (Win2RoadForWard(Size, 1)) return true;

                                
                            }
                        }

                        if (win >= 3)
                        {
                            if (!IsUpRow(Used[0]) && !IsLastColumn(Used[2]))
                            {
                                peopleNearWin.LastIndex = Used[2] + Size + 1;
                                peopleNearWin.FirstIndex = Used[0] - Size - 1;
                                if (!IsUsed(peopleNearWin.LastIndex) && !IsUsed(peopleNearWin.FirstIndex) &&
                                    !IsOutBound(peopleNearWin.FirstIndex) && !IsOutBound(peopleNearWin.LastIndex)
                                    && !IsEnermyUsed(peopleNearWin.LastIndex) && !IsEnermyUsed(peopleNearWin.FirstIndex))
                                {
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }

                            if (win >= 4)
                            {
                                if (IsUpRow(Used[0]))
                                {
                                    peopleNearWin.LastIndex = Used[3] + Size + 1;
                                    peopleNearWin.FirstIndex = -1;
                                    if (!IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else if (IsLastColumn(Used[3]))
                                {
                                    peopleNearWin.LastIndex = -1;
                                    peopleNearWin.FirstIndex = Used[0] - Size - 1;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else
                                {
                                    peopleNearWin.LastIndex = Used[3] + Size + 1;
                                    peopleNearWin.FirstIndex = Used[0] - Size - 1;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex) && IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.LastIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.FirstIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;


            }
            for (int i = Size; i < this.Count; i += Size)
            {
                index = i;
                for (int j = 0; j < count; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (!IsFirstColumn(index) && !IsDownRow(index + 26 * 3) && !IsDownRow(index))
                        {
                            if (!IsUsed(index + 26 * 1) && IsPeopleUse(index + 26 * 2) && IsPeopleUse(index + 26 * 3) && !IsEnermyUsed(index - 26 * 1) && !IsEnermyUsed(index + 26 * 4))
                            {
                                peopleNearWin.FirstIndex = index + 26 * 1;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                            else if (IsPeopleUse(index + 26 * 1) && !IsUsed(index + 26 * 2) && IsPeopleUse(index + 26 * 3) && !IsEnermyUsed(index - 26 * 1) && !IsEnermyUsed(index + 26 * 4))
                            {
                                peopleNearWin.FirstIndex = index + 26 * 2;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                        }
                        if (IsPeopleUse(index + (Size + 1) * 1) && !IsUsed(index + (Size + 1) * 2) && IsPeopleUse(index + (Size + 1) * 3) && IsPeopleUse(index + (Size + 1) * 4))
                        {
                            peopleNearWin.FirstIndex = index + (Size + 1) * 2;
                            peopleNearWin.LastIndex = -1;
                            PeopleNearWinEvent(this, peopleNearWin);
                            return true;
                        }

                        Used[win] = index;
                        win++;

                        if (win == 2)
                        {
                            if (!IsUpRow(Used[0]) && !IsFirstColumn(Used[1]))
                            {
                                peopleNearWin.LastIndex = Used[1] + (Size + 1);
                                peopleNearWin.FirstIndex = Used[0] - (Size + 1);

                                //2Road Win Row and Column
                                if (Win2RoadForWard(1)) return true;

                                //2Road Win Column and ForWard
                                //if (Win2Road(Size + 1)) return true;


                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size - 1)) return true;

                                else if (Win2RoadForWard(Size)) return true;

                                
                            }
                        }

                        else if (win == 3 && !IsFirstColumn(Used[0]) && !IsLastColumn(Used[0]))
                        {
                            peopleNearWin.FirstIndex = Used[0] - (Size + 1);
                            peopleNearWin.LastIndex = Used[2] + (Size + 1);

                            if (IsDownRow(Used[2]) && !IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size, 0)) return true;
                            }
                            if (IsUpRow(Used[0]) && !IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size, 1)) return true;
                            }
                            if (!IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadForWard(Size, 0)) return true;

                                
                            }
                            if (!IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadForWard(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadForWard(Size - 1, 1)) return true;

                                //2Road Win Column and BackWard
                                if (Win2RoadForWard(Size, 1)) return true;

                                
                            }
                        }

                        if (win >= 3)
                        {
                            if (!IsFirstColumn(Used[0]) && !IsDownRow(Used[2]))
                            {
                                peopleNearWin.LastIndex = Used[2] + Size + 1;
                                peopleNearWin.FirstIndex = Used[0] - Size - 1;
                                if (!IsUsed(peopleNearWin.LastIndex) && !IsUsed(peopleNearWin.FirstIndex) &&
                                    !IsOutBound(peopleNearWin.FirstIndex) && !IsOutBound(peopleNearWin.LastIndex)
                                    && !IsEnermyUsed(peopleNearWin.LastIndex) && !IsEnermyUsed(peopleNearWin.FirstIndex))
                                {
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }

                            if (win >= 4)
                            {
                                if (IsFirstColumn(Used[0]))
                                {
                                    peopleNearWin.LastIndex = Used[3] + Size + 1;
                                    peopleNearWin.FirstIndex = -1;
                                    if (!IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else if (IsDownRow(Used[3]))
                                {
                                    peopleNearWin.LastIndex = -1;
                                    peopleNearWin.FirstIndex = Used[0] - Size - 1;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else
                                {
                                    peopleNearWin.LastIndex = Used[3] + Size + 1;
                                    peopleNearWin.FirstIndex = Used[0] - Size - 1;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex) && IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.LastIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.FirstIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
            return false;
        }

        protected bool EnermyNearLost()
        {
            int sx = 0, winx = 0, winy = 0;
            int[] UsedX = new int[Size];
            int[] UsedY = new int[Size];

            //BackWard
            if (EnermyLostBackWard())
            {
                return true;
            }

            //ForWard
            if (EnermyNearLostForWard()) {
                return true;
            }

            //Row
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 0)
                    {
                        if (j <= Count - (Size * 4) + i)
                        {
                            if (!IsUpRow(j) && !IsDownRow(j + Size * 3))  
                            {
                                if (!IsUsed(j + Size * 1) && IsPeopleUse(j + Size * 2) && IsPeopleUse(j + Size * 3) && !IsEnermyUsed(j - Size * 1) && !IsEnermyUsed(j + Size * 4))
                                {
                                    peopleNearWin.FirstIndex = j + Size * 1;
                                    peopleNearWin.LastIndex = -1;
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                                else if (IsPeopleUse(j + Size * 1) && !IsUsed(j + Size * 2) && IsPeopleUse(j + Size * 3) && !IsEnermyUsed(j - Size * 1) && !IsEnermyUsed(j + Size * 4))
                                {
                                    peopleNearWin.FirstIndex = j + Size * 2;
                                    peopleNearWin.LastIndex = -1;
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }
                            if (IsPeopleUse(j + Size * 1) && !IsUsed(j + Size * 2) && IsPeopleUse(j + Size * 3) && IsPeopleUse(j + Size * 4))
                            {
                                peopleNearWin.FirstIndex = j + Size * 2;
                                peopleNearWin.LastIndex = -1;
                                PeopleNearWinEvent(this, peopleNearWin);
                                return true;
                            }
                        }

                        UsedY[winy] = j;
                        winy++;

                        
                        if (winy == 2)
                        {
                            if (!IsUpRow(UsedY[0]) && !IsDownRow(UsedY[1]) && !IsFirstColumn(UsedY[0]) && !IsLastColumn(UsedY[0])) 
                            {
                                peopleNearWin.LastIndex = UsedY[1] + Size;
                                peopleNearWin.FirstIndex = UsedY[0] - Size;

                                //2Road Win Row and Column
                                if (Win2RoadRow(1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadRow(Size + 1)) return true;


                                //2Road Win Column and BackWard
                                else if (Win2RoadRow(Size - 1)) return true;

                                
                            }
                        }
                        else if (winy == 3 && !IsFirstColumn(UsedY[0]) && !IsLastColumn(UsedY[0]))
                        {
                            peopleNearWin.FirstIndex = UsedY[0] - Size;
                            peopleNearWin.LastIndex = UsedY[2] + Size;

                            if (IsDownRow(UsedY[2]) && !IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadRow(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadRow(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadRow(Size - 1, 0)) return true;
                            }
                            if (IsUpRow(UsedY[0]) && !IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadRow(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadRow(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadRow(Size - 1, 1)) return true;
                            }
                            if (!IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadRow(1, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadRow(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadRow(Size - 1, 0)) return true;

                                
                            }
                            if (!IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadRow(1, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadRow(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadRow(Size - 1, 1)) return true;

                                
                            }
                        }

                        if (winy >= 3)
                        {
                            if (!IsUpRow(UsedY[0]) && !IsDownRow(UsedY[2]))
                            {
                                peopleNearWin.LastIndex = UsedY[2] + Size;
                                peopleNearWin.FirstIndex = UsedY[0] - Size;
                                if (!IsUsed(peopleNearWin.LastIndex) && !IsUsed(peopleNearWin.FirstIndex) &&
                                    !IsOutBound(peopleNearWin.FirstIndex) && !IsOutBound(peopleNearWin.LastIndex)
                                    && !IsEnermyUsed(peopleNearWin.LastIndex) && !IsEnermyUsed(peopleNearWin.FirstIndex))
                                {
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }
                            if (winy >= 4)
                            {
                                if (IsUpRow(UsedY[0]))
                                {
                                    peopleNearWin.LastIndex = UsedY[3] + Size;
                                    peopleNearWin.FirstIndex = -1;
                                    if (!IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else if (IsDownRow(UsedY[3]))
                                {
                                    peopleNearWin.LastIndex = -1;
                                    peopleNearWin.FirstIndex = UsedY[0] - Size;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else
                                {
                                    peopleNearWin.LastIndex = UsedY[3] + Size;
                                    peopleNearWin.FirstIndex = UsedY[0] - Size;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex) && IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.LastIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.FirstIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else winy = 0;
                }
                winy = 0;
                

                //Column
                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 0)
                    {
                        if (sx >= i * Size && sx <= (i * Size) + Size - 4)
                        {
                            if (!IsFirstColumn(sx) && !IsLastColumn(sx + 3)) 
                            {
                                if (!IsUsed(sx + 1) && IsPeopleUse(sx + 2) && IsPeopleUse(sx + 3) && !IsEnermyUsed(sx - 1) && !IsEnermyUsed(sx + 4))  
                                {
                                    peopleNearWin.FirstIndex = sx + 1;
                                    peopleNearWin.LastIndex = -1;
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                                else if (IsPeopleUse(sx + 1) && !IsUsed(sx + 2) && IsPeopleUse(sx + 3) && !IsEnermyUsed(sx - 1) && !IsEnermyUsed(sx + 4))
                                {
                                    peopleNearWin.FirstIndex = sx + 2;
                                    peopleNearWin.LastIndex = -1;
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }
                        }
                        if (IsPeopleUse(sx + 1) && !IsUsed(sx + 2) && IsPeopleUse(sx + 3) && IsPeopleUse(sx + 4))
                        {
                            peopleNearWin.FirstIndex = sx + 2;
                            peopleNearWin.LastIndex = -1;
                            PeopleNearWinEvent(this, peopleNearWin);
                            return true;
                        }

                        UsedX[winx] = sx;
                        winx++;


                        //2Road Win
                        if (winx == 2 && !IsUpRow(UsedX[0]) && !IsDownRow(UsedX[0]) && !IsFirstColumn(UsedX[0]) && !IsLastColumn(UsedX[1]))
                        {
                            peopleNearWin.FirstIndex = UsedX[0] - 1;
                            peopleNearWin.LastIndex = UsedX[1] + 1;


                            //2Road Win Row and Column
                            if (Win2RoadColumn(Size)) return true;

                            //2Road Win Column and ForWard
                            else if (Win2RoadColumn(Size + 1)) return true;


                            //2Road Win Column and BackWard
                            else if (Win2RoadColumn(Size - 1)) return true;

                            else
                            {
                                peopleNearWin.FirstIndex = UsedX[0] - 1 * 2;
                                peopleNearWin.LastIndex = UsedX[1] + 1 * 2;

                                //2Road Win Row and Column
                                if (Win2RoadColumn(Size)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadColumn(Size + 1)) return true;


                                //2Road Win Column and BackWard
                                else if (Win2RoadColumn(Size - 1)) return true;
                            }
                        }
                        else if (winx == 3 && !IsUpRow(UsedX[0]) && !IsDownRow(UsedX[0]))
                        {
                            peopleNearWin.FirstIndex = UsedX[0] - 1;
                            peopleNearWin.LastIndex = UsedX[2] + 1;

                            if (IsLastColumn(UsedX[2]) && !IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadColumn(Size, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadColumn(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadColumn(Size - 1, 0)) return true;
                            }
                            if (IsFirstColumn(UsedX[0]) && !IsUsed(peopleNearWin.LastIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadColumn(Size, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadColumn(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadColumn(Size - 1, 1)) return true;
                            }
                            if (!IsUsed(peopleNearWin.FirstIndex))
                            {
                                //2Road Win Row and Column
                                if (Win2RoadColumn(Size, 0)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadColumn(Size + 1, 0)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadColumn(Size - 1, 0)) return true;

                                else
                                {
                                    peopleNearWin.FirstIndex = UsedX[0] - 1 * 2;
                                    peopleNearWin.LastIndex = UsedX[2] + 1 * 2;

                                    if (IsLastColumn(UsedX[2]) && !IsUsed(peopleNearWin.FirstIndex))
                                    {
                                        //2Road Win Row and Column
                                        if (Win2RoadColumn(Size, 0)) return true;

                                        //2Road Win Column and ForWard
                                        else if (Win2RoadColumn(Size + 1, 0)) return true;

                                        //2Road Win Column and BackWard
                                        else if (Win2RoadColumn(Size - 1, 0)) return true;
                                    }

                                    if (!IsUsed(peopleNearWin.FirstIndex))
                                    {
                                        //2Road Win Row and Column
                                        if (Win2RoadColumn(Size, 0)) return true;

                                        //2Road Win Column and ForWard
                                        else if (Win2RoadColumn(Size + 1, 0)) return true;

                                        //2Road Win Column and BackWard
                                        else if (Win2RoadColumn(Size - 1, 0)) return true;
                                    }

                                    
                                }
                            }
                            if (!IsUsed(peopleNearWin.LastIndex))
                            {
                                
                                //2Road Win Row and Column
                                if (Win2RoadColumn(Size, 1)) return true;

                                //2Road Win Column and ForWard
                                else if (Win2RoadColumn(Size + 1, 1)) return true;

                                //2Road Win Column and BackWard
                                else if (Win2RoadColumn(Size - 1, 1)) return true;

                                else
                                {
                                    peopleNearWin.FirstIndex = UsedX[0] - 1 * 2;
                                    peopleNearWin.LastIndex = UsedX[2] + 1 * 2;

                                    if (IsFirstColumn(UsedX[0]) && !IsUsed(peopleNearWin.LastIndex))
                                    {
                                        //2Road Win Row and Column
                                        if (Win2RoadColumn(Size, 1)) return true;

                                        //2Road Win Column and ForWard
                                        else if (Win2RoadColumn(Size + 1, 1)) return true;

                                        //2Road Win Column and BackWard
                                        else if (Win2RoadColumn(Size - 1, 1)) return true;
                                    }

                                    if (!IsUsed(peopleNearWin.LastIndex))
                                    {
                                        //2Road Win Row and Column
                                        if (Win2RoadColumn(Size, 1)) return true;

                                        //2Road Win Column and ForWard
                                        else if (Win2RoadColumn(Size + 1, 1)) return true;

                                        //2Road Win Column and BackWard
                                        else if (Win2RoadColumn(Size - 1, 1)) return true;
                                    }


                                }
                            }
                        }


                        if (winx >= 3)
                        {
                            if (!IsFirstColumn(UsedX[0]) && !IsLastColumn(UsedX[2])) 
                            {
                                peopleNearWin.LastIndex = UsedX[2] + 1;
                                peopleNearWin.FirstIndex = UsedX[0] - 1;
                                if (!IsUsed(peopleNearWin.LastIndex) && !IsUsed(peopleNearWin.FirstIndex) &&
                                    !IsOutBound(peopleNearWin.FirstIndex) && !IsOutBound(peopleNearWin.LastIndex)
                                    && !IsEnermyUsed(peopleNearWin.LastIndex) && !IsEnermyUsed(peopleNearWin.FirstIndex))  
                                {
                                    PeopleNearWinEvent(this, peopleNearWin);
                                    return true;
                                }
                            }
                            if (winx >= 4)
                            {
                                if (IsFirstColumn(UsedX[0]))
                                {
                                    peopleNearWin.LastIndex = UsedX[3] + 1;
                                    peopleNearWin.FirstIndex = -1;
                                    if (!IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else if (IsLastColumn(UsedX[3]))
                                {
                                    peopleNearWin.LastIndex = -1;
                                    peopleNearWin.FirstIndex = UsedX[0] - 1;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                                else
                                {
                                    peopleNearWin.LastIndex = UsedX[3] + 1;
                                    peopleNearWin.FirstIndex = UsedX[0] - 1;
                                    if (!IsEnermyUsed(peopleNearWin.FirstIndex) && IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.LastIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        peopleNearWin.FirstIndex = -1;
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                    else if (!IsEnermyUsed(peopleNearWin.FirstIndex) && !IsEnermyUsed(peopleNearWin.LastIndex))
                                    {
                                        PeopleNearWinEvent(this, peopleNearWin);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else winx = 0;
                    sx++;
                }
                winx = 0;
            }
            return false;
        }

        protected void PeopleWinForWard()
        {
            int index = 0, win = 0, count = Size - 1;
            for (int i = Size - 5; i >= 0; i--)
            {
                index = i;
                for (int j = i; j < Size; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
            }

            for (int i = Size; i < this.Count; i += Size)
            {
                index = i;
                for (int j = 0; j < count; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
        }

        protected void PeopleWinBackWard()
        {
            int index = 0, win = 0, count = Size - 1;
            for (int i = 4; i < Size; i++)
            {
                index = i;
                for (int j = i; j <= i+i; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
            }
            win = 0;
            index = 0;

            for (int i = 24+25; i <= this.Count; i+=Size)
            {
                index = i;
                for (int j = i; j < i+count; j++)
                {
                    if (Data[index] == 0)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
        }

        protected void PeopleWinUpDown()
        {
            int sx = 0, winx = 0, winy = 0;
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size) 
                {
                    if (Data[j] == 0)
                    {
                        if (winy >= 0 && winy < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[winy] = j;
                        }                        
                        winy++;
                        if (winy >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winy = 0;
                }
                winy = 0;

                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 0)
                    {
                        if (winx >= 0 && winx < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[winx] = sx;
                        }
                        winx++;
                        if (winx >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winx = 0;
                    sx++;
                }
                winx = 0;
            }
        }

        protected void EnermyWinForWard()
        {
            int index = 0, win = 0, count = Size - 1;
            for (int i = Size - 5; i >= 0; i--)
            {
                index = i;
                for (int j = i; j < Size; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
            }

            for (int i = Size; i < this.Count; i += Size)
            {
                index = i;
                for (int j = 0; j < count; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }   
        }

        protected void EnermyWinBackWard()
        {
            int index = 0, win = 0, count = Size - 1;
            for (int i = 4; i < Size; i++)
            {
                index = i;
                for (int j = i; j <= i + i; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
            }
            win = 0;
            index = 0;

            for (int i = 24 + 25; i <= this.Count; i += Size)
            {
                index = i;
                for (int j = i; j < i + count; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (win >= 0 && win < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[win] = index;
                        }
                        win++;
                        if (win >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
        }
            
        protected void EnermyWinUpDown()
        {
            int index = 0, winx = 0, winy = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 1)
                    {
                        if (winy >= 0 && winy < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[winy] = j;
                        }
                        winy++;
                        if (winy >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winy = 0;
                }
                winy = 0;

                for (int j = 0; j < Size; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (winx >= 0 && winx < winEventArgs.WinIndex.Length)
                        {
                            winEventArgs.WinIndex[winx] = index;
                        }
                        winx++;
                        if (winx >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winx = 0;
                    index++;
                }
                winx = 0;
            }
        }

        //
        protected bool EnermyNearWin4Line()
        {
            int sx = 0, winx = 0, winy = 0;
            int[] UsedX = new int[Size];
            int[] UsedY = new int[Size];
            //BackWard
            if (EnermyNearWinBackWard4Line())
            {
                return true;
            }

            //ForWard
            if (EnermyNearWinForWard4Line())
            {
                return true;
            }

            //Row
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 1)
                    {
                        

                        UsedY[winy] = j;
                        winy++;

                        if (winy >= 4)
                        {
                            if (IsUpRow(UsedY[0]))
                            {
                                enermyNearWinEvent.LastIndex = UsedY[3] + Size;
                                enermyNearWinEvent.FirstIndex = -1;
                                if (!IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else if (IsDownRow(UsedY[3]))
                            {
                                enermyNearWinEvent.LastIndex = -1;
                                enermyNearWinEvent.FirstIndex = UsedY[0] - Size;
                                if (!IsEnermyUsed(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else
                            {
                                enermyNearWinEvent.LastIndex = UsedY[3] + Size;
                                enermyNearWinEvent.FirstIndex = UsedY[0] - Size;
                                if (!IsEnermyUsed(enermyNearWinEvent.FirstIndex) && IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsEnermyUsed(enermyNearWinEvent.FirstIndex) && !IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.FirstIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (!IsEnermyUsed(enermyNearWinEvent.FirstIndex) && !IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                    }
                    else winy = 0;
                }
                winy = 0;


                //Column
                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 1)
                    {
                        

                        UsedX[winx] = sx;
                        winx++;




                        if (winx >= 4)
                        {
                            if (IsFirstColumn(UsedX[0]))
                            {
                                enermyNearWinEvent.LastIndex = UsedX[3] + 1;
                                enermyNearWinEvent.FirstIndex = -1;
                                if (!IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else if (IsLastColumn(UsedX[3]))
                            {
                                enermyNearWinEvent.LastIndex = -1;
                                enermyNearWinEvent.FirstIndex = UsedX[0] - 1;
                                if (!IsEnermyUsed(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else
                            {
                                enermyNearWinEvent.LastIndex = UsedX[3] + 1;
                                enermyNearWinEvent.FirstIndex = UsedX[0] - 1;
                                if (!IsEnermyUsed(enermyNearWinEvent.FirstIndex) && IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsEnermyUsed(enermyNearWinEvent.FirstIndex) && !IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.FirstIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (!IsEnermyUsed(enermyNearWinEvent.FirstIndex) && !IsEnermyUsed(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                    }
                    else winx = 0;
                    sx++;
                }
                winx = 0;
            }
            return false;
        }

        protected bool EnermyNearWinForWard4Line()
        {
            int index = 0, win = 0, count = Size - 1;
            int[] Used = new int[Size];

            for (int i = Size - 5; i >= 0; i--)
            {
                index = i;
                for (int j = i; j < Size; j++)
                {
                    if (Data[index] == 1)
                    {
                        

                        Used[win] = index;
                        win++;


                        if (win >= 4)
                        {
                            if (IsUpRow(Used[0]))
                            {
                                enermyNearWinEvent.LastIndex = Used[3] + Size + 1;
                                enermyNearWinEvent.FirstIndex = -1;
                                if (!IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else if (IsLastColumn(Used[3]))
                            {
                                enermyNearWinEvent.LastIndex = -1;
                                enermyNearWinEvent.FirstIndex = Used[0] - Size - 1;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else
                            {
                                enermyNearWinEvent.LastIndex = Used[3] + Size + 1;
                                enermyNearWinEvent.FirstIndex = Used[0] - Size - 1;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.FirstIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;


            }
            for (int i = Size; i < this.Count; i += Size)
            {
                index = i;
                for (int j = 0; j < count; j++)
                {
                    if (Data[index] == 1)
                    {
                        

                        Used[win] = index;
                        win++;



                        if (win >= 4)
                        {
                            if (IsFirstColumn(Used[0]))
                            {
                                enermyNearWinEvent.LastIndex = Used[3] + Size + 1;
                                enermyNearWinEvent.FirstIndex = -1;
                                if (!IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else if (IsDownRow(Used[3]))
                            {
                                enermyNearWinEvent.LastIndex = -1;
                                enermyNearWinEvent.FirstIndex = Used[0] - Size - 1;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else
                            {
                                enermyNearWinEvent.LastIndex = Used[3] + Size + 1;
                                enermyNearWinEvent.FirstIndex = Used[0] - Size - 1;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.FirstIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
            return false;
        }

        protected bool EnermyNearWinBackWard4Line()
        {
            int index = 0, win = 0, count = Size - 1;
            int[] Used = new int[Size];
            for (int i = 4; i < Size; i++)
            {
                index = i;
                for (int j = i; j <= i + i; j++)
                {
                    if (Data[index] == 1)
                    {
                        
                        Used[win] = index;
                        win++;


                        if (win >= 4)
                        {
                            if (IsUpRow(Used[0]))
                            {
                                enermyNearWinEvent.LastIndex = Used[3] - 1 + Size;
                                enermyNearWinEvent.FirstIndex = -1;
                                if (!IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else if (IsFirstColumn(Used[3]))
                            {
                                enermyNearWinEvent.LastIndex = -1;
                                enermyNearWinEvent.FirstIndex = Used[0] + 1 - Size;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else
                            {
                                enermyNearWinEvent.LastIndex = Used[3] - 1 + Size;
                                enermyNearWinEvent.FirstIndex = Used[0] + 1 - Size; ;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.FirstIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
            }
            win = 0;
            index = 0;

            for (int i = 24 + 25; i <= this.Count; i += Size)
            {
                index = i;
                for (int j = i; j < i + count; j++)
                {
                    if (Data[index] == 1)
                    {
                        
                        Used[win] = index;
                        win++;



                        if (win >= 4)
                        {
                            if (IsLastColumn(Used[0]))
                            {
                                enermyNearWinEvent.LastIndex = Used[3] - 1 + Size;
                                enermyNearWinEvent.FirstIndex = -1;
                                if (!IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else if (IsDownRow(Used[3]))
                            {
                                enermyNearWinEvent.LastIndex = -1;
                                enermyNearWinEvent.FirstIndex = Used[0] + 1 - Size;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            else
                            {
                                enermyNearWinEvent.LastIndex = Used[3] - 1 + Size;
                                enermyNearWinEvent.FirstIndex = Used[0] + 1 - Size; ;
                                if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    enermyNearWinEvent.FirstIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (!IsPeopleUse(enermyNearWinEvent.FirstIndex) && !IsPeopleUse(enermyNearWinEvent.LastIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
            return false;
        }

        //

        protected bool EnermyNearWin3Line()
        {
            int sx = 0, winx = 0, winy = 0;
            int[] UsedX = new int[Size];
            int[] UsedY = new int[Size];
            //BackWard
            if (EnermyNearWinBackWard3Line())
            {
                return true;
            }

            //ForWard
            if (EnermyNearWinForWard3Line())
            {
                return true;
            }

            //Row
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 1)
                    {
                        if (j <= Count - (Size * 4) + i)
                        {
                            if (!IsUpRow(j) && !IsDownRow(j + Size * 3))
                            {
                                if (!IsUsed(j + Size * 1) && IsEnermyUsed(j + Size * 2) && IsEnermyUsed(j + Size * 3) && !IsPeopleUse(j - Size * 1) && !IsPeopleUse(j + Size * 4))
                                {
                                    enermyNearWinEvent.FirstIndex = j + Size * 1;
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsEnermyUsed(j + Size * 1) && !IsUsed(j + Size * 2) && IsEnermyUsed(j + Size * 3) && !IsPeopleUse(j - Size * 1) && !IsPeopleUse(j + Size * 4))
                                {
                                    enermyNearWinEvent.FirstIndex = j + Size * 2;
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            if (IsEnermyUsed(j + Size * 1) && !IsUsed(j + Size * 2) && IsEnermyUsed(j + Size * 3) && IsEnermyUsed(j + Size * 4))
                            {
                                enermyNearWinEvent.FirstIndex = j + Size * 2;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                        }

                        UsedY[winy] = j;
                        winy++;

                        if (winy >= 3)
                        {
                            if (!IsUpRow(UsedY[0]) && !IsDownRow(UsedY[2]))
                            {
                                enermyNearWinEvent.LastIndex = UsedY[2] + Size;
                                enermyNearWinEvent.FirstIndex = UsedY[0] - Size;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsEnermyUsed(enermyNearWinEvent.LastIndex) && !IsEnermyUsed(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            
                        }
                    }
                    else winy = 0;
                }
                winy = 0;


                //Column
                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 1)
                    {
                        if (sx >= i * Size && sx <= (i * Size) + Size - 4)
                        {
                            if (!IsFirstColumn(sx) && !IsLastColumn(sx + 3))
                            {
                                if (!IsUsed(sx + 1) && IsEnermyUsed(sx + 2) && IsEnermyUsed(sx + 3) && !IsPeopleUse(sx - 1) && !IsPeopleUse(sx + 4))
                                {
                                    enermyNearWinEvent.FirstIndex = sx + 1;
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                                else if (IsEnermyUsed(sx + 1) && !IsUsed(sx + 2) && IsEnermyUsed(sx + 3) && !IsPeopleUse(sx - 1) && !IsPeopleUse(sx + 4))
                                {
                                    enermyNearWinEvent.FirstIndex = sx + 2;
                                    enermyNearWinEvent.LastIndex = -1;
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                        }
                        if (IsEnermyUsed(sx + 1) && !IsUsed(sx + 2) && IsEnermyUsed(sx + 3) && IsEnermyUsed(sx + 4))
                        {
                            enermyNearWinEvent.FirstIndex = sx + 2;
                            enermyNearWinEvent.LastIndex = -1;
                            EnermyNearWinEvent(this, enermyNearWinEvent);
                            return true;
                        }

                        UsedX[winx] = sx;
                        winx++;




                        if (winx >= 3)
                        {
                            if (!IsFirstColumn(UsedX[0]) && !IsLastColumn(UsedX[2]))
                            {
                                enermyNearWinEvent.LastIndex = UsedX[2] + 1;
                                enermyNearWinEvent.FirstIndex = UsedX[0] - 1;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsEnermyUsed(enermyNearWinEvent.LastIndex) && !IsEnermyUsed(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }
                            
                        }
                    }
                    else winx = 0;
                    sx++;
                }
                winx = 0;
            }
            return false;
        }

        protected bool EnermyNearWinForWard3Line()
        {
            int index = 0, win = 0, count = Size - 1;
            int[] Used = new int[Size];

            for (int i = Size - 5; i >= 0; i--)
            {
                index = i;
                for (int j = i; j < Size; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (!IsUpRow(index) && !IsLastColumn(index + (Size + 1) * 3) && !IsLastColumn(index))
                        {
                            if (!IsUsed(index + (Size + 1) * 1) && IsEnermyUsed(index + (Size + 1) * 2) && IsEnermyUsed(index + (Size + 1) * 3) && !IsPeopleUse(index - (Size + 1) * 1) && !IsPeopleUse(index + (Size + 1) * 4))
                            {
                                enermyNearWinEvent.FirstIndex = index + (Size + 1) * 1;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                            else if (IsEnermyUsed(index + (Size + 1) * 1) && !IsUsed(index + (Size + 1) * 2) && IsEnermyUsed(index + (Size + 1) * 3) && !IsPeopleUse(index - (Size + 1) * 1) && !IsPeopleUse(index + (Size + 1) * 4))
                            {
                                enermyNearWinEvent.FirstIndex = index + (Size + 1) * 2;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                        }
                        if (IsEnermyUsed(index + (Size + 1) * 1) && !IsUsed(index + (Size + 1) * 2) && IsEnermyUsed(index + (Size + 1) * 3) && IsEnermyUsed(index + (Size + 1) * 4))
                        {
                            enermyNearWinEvent.FirstIndex = index + (Size + 1) * 2;
                            enermyNearWinEvent.LastIndex = -1;
                            EnermyNearWinEvent(this, enermyNearWinEvent);
                            return true;
                        }

                        Used[win] = index;
                        win++;


                        if (win >= 3)
                        {
                            if (!IsUpRow(Used[0]) && !IsLastColumn(Used[2]))
                            {
                                enermyNearWinEvent.LastIndex = Used[2] + Size + 1;
                                enermyNearWinEvent.FirstIndex = Used[0] - Size - 1;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsPeopleUse(enermyNearWinEvent.LastIndex) && !IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }

                            
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;


            }
            for (int i = Size; i < this.Count; i += Size)
            {
                index = i;
                for (int j = 0; j < count; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (!IsFirstColumn(index) && !IsDownRow(index + 26 * 3) && !IsDownRow(index))
                        {
                            if (!IsUsed(index + 26 * 1) && IsEnermyUsed(index + 26 * 2) && IsEnermyUsed(index + 26 * 3) && !IsPeopleUse(index - 26 * 1) && !IsPeopleUse(index + 26 * 4))
                            {
                                enermyNearWinEvent.FirstIndex = index + 26 * 1;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                            else if (IsEnermyUsed(index + 26 * 1) && !IsUsed(index + 26 * 2) && IsEnermyUsed(index + 26 * 3) && !IsPeopleUse(index - 26 * 1) && !IsPeopleUse(index + 26 * 4))
                            {
                                enermyNearWinEvent.FirstIndex = index + 26 * 2;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                        }
                        if (IsEnermyUsed(index + (Size + 1) * 1) && !IsUsed(index + (Size + 1) * 2) && IsEnermyUsed(index + (Size + 1) * 3) && IsEnermyUsed(index + (Size + 1) * 4))
                        {
                            enermyNearWinEvent.FirstIndex = index + (Size + 1) * 2;
                            enermyNearWinEvent.LastIndex = -1;
                            EnermyNearWinEvent(this, enermyNearWinEvent);
                            return true;
                        }

                        Used[win] = index;
                        win++;



                        if (win >= 3)
                        {
                            if (!IsFirstColumn(Used[0]) && !IsDownRow(Used[2]))
                            {
                                enermyNearWinEvent.LastIndex = Used[2] + Size + 1;
                                enermyNearWinEvent.FirstIndex = Used[0] - Size - 1;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsPeopleUse(enermyNearWinEvent.LastIndex) && !IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }

                            
                        }
                    }
                    else win = 0;
                    index += 26;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
            return false;
        }

        protected bool EnermyNearWinBackWard3Line()
        {
            int index = 0, win = 0, count = Size - 1;
            int[] Used = new int[Size];
            for (int i = 4; i < Size; i++)
            {
                index = i;
                for (int j = i; j <= i + i; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (!IsUpRow(index) && !IsFirstColumn(index + (Size - 1) * 3) && !IsFirstColumn(index))
                        {
                            if (!IsUsed(index + (Size - 1) * 1) && IsEnermyUsed(index + (Size - 1) * 2) && IsEnermyUsed(index + (Size - 1) * 3) && !IsPeopleUse(index - (Size - 1) * 1) && !IsPeopleUse(index + (Size - 1) * 4))
                            {
                                enermyNearWinEvent.FirstIndex = index + (Size - 1) * 1;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                            else if (IsEnermyUsed(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsEnermyUsed(index + (Size - 1) * 3) && !IsPeopleUse(index - (Size - 1) * 1) && !IsPeopleUse(index + (Size - 1) * 4))
                            {

                                enermyNearWinEvent.FirstIndex = index + (Size - 1) * 2;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                        }
                        if (IsEnermyUsed(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsEnermyUsed(index + (Size - 1) * 3) && IsEnermyUsed(index + (Size - 1) * 4))
                        {
                            enermyNearWinEvent.FirstIndex = index + (Size - 1) * 2;
                            enermyNearWinEvent.LastIndex = -1;
                            EnermyNearWinEvent(this, enermyNearWinEvent);
                            return true;
                        }

                        Used[win] = index;
                        win++;


                        if (win >= 3)
                        {
                            if (!IsUpRow(Used[0]) && !IsFirstColumn(Used[2]))
                            {
                                enermyNearWinEvent.LastIndex = Used[2] - 1 + Size;
                                enermyNearWinEvent.FirstIndex = Used[0] + 1 - Size;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsPeopleUse(enermyNearWinEvent.LastIndex) && !IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }

                            
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
            }
            win = 0;
            index = 0;

            for (int i = 24 + 25; i <= this.Count; i += Size)
            {
                index = i;
                for (int j = i; j < i + count; j++)
                {
                    if (Data[index] == 1)
                    {
                        if (!IsLastColumn(index) && !IsDownRow(index + (Size - 1) * 3) && !IsDownRow(index))
                        {
                            if (!IsUsed(index + (Size - 1) * 1) && IsEnermyUsed(index + (Size - 1) * 2) && IsEnermyUsed(index + (Size - 1) * 3) && !IsPeopleUse(index - (Size - 1) * 1) && !IsPeopleUse(index + (Size - 1) * 4))
                            {
                                enermyNearWinEvent.FirstIndex = index + (Size - 1) * 1;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                            else if (IsEnermyUsed(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsEnermyUsed(index + (Size - 1) * 3) && !IsPeopleUse(index - (Size - 1) * 1) && !IsPeopleUse(index + (Size - 1) * 4))
                            {

                                enermyNearWinEvent.FirstIndex = index + (Size - 1) * 2;
                                enermyNearWinEvent.LastIndex = -1;
                                EnermyNearWinEvent(this, enermyNearWinEvent);
                                return true;
                            }
                        }
                        if (IsEnermyUsed(index + (Size - 1) * 1) && !IsUsed(index + (Size - 1) * 2) && IsEnermyUsed(index + (Size - 1) * 3) && IsEnermyUsed(index + (Size - 1) * 4))
                        {
                            enermyNearWinEvent.FirstIndex = index + (Size - 1) * 2;
                            enermyNearWinEvent.LastIndex = -1;
                            EnermyNearWinEvent(this, enermyNearWinEvent);
                            return true;
                        }

                        Used[win] = index;
                        win++;



                        if (win >= 3)
                        {
                            if (!IsLastColumn(Used[0]) && !IsDownRow(Used[2]))
                            {
                                enermyNearWinEvent.LastIndex = Used[2] - 1 + Size;
                                enermyNearWinEvent.FirstIndex = Used[0] + 1 - Size;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsPeopleUse(enermyNearWinEvent.LastIndex) && !IsPeopleUse(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }

                            
                        }
                    }
                    else win = 0;
                    index += 24;
                }
                win = 0;
                index = 0;
                if (count < 4) break;
                count--;
            }
            return false;
        }

        //

        protected bool EnermyNearWin2Line()
        {
            int sx = 0, winx = 0, winy = 0;
            int[] UsedX = new int[Size];
            int[] UsedY = new int[Size];
            //BackWard
            //if (EnermyNearWinBackWard3Line())
            //{
              //  return true;
            //}

            //ForWard
            //if (EnermyNearWinForWard3Line())
            //{
              //  return true;
            //}

            //Row
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 1)
                    {


                        UsedY[winy] = j;
                        winy++;

                        if (winy >= 2)
                        {
                            if (!IsUpRow(UsedY[0]) && !IsDownRow(UsedY[2]))
                            {
                                enermyNearWinEvent.LastIndex = UsedY[2] + Size;
                                enermyNearWinEvent.FirstIndex = UsedY[0] - Size;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsEnermyUsed(enermyNearWinEvent.LastIndex) && !IsEnermyUsed(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }

                        }
                    }
                    else winy = 0;
                }
                winy = 0;


                //Column
                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 1)
                    {


                        UsedX[winx] = sx;
                        winx++;




                        if (winx >= 2)
                        {
                            if (!IsFirstColumn(UsedX[0]) && !IsLastColumn(UsedX[2]))
                            {
                                enermyNearWinEvent.LastIndex = UsedX[2] + 1;
                                enermyNearWinEvent.FirstIndex = UsedX[0] - 1;
                                if (!IsUsed(enermyNearWinEvent.LastIndex) && !IsUsed(enermyNearWinEvent.FirstIndex) &&
                                    !IsOutBound(enermyNearWinEvent.FirstIndex) && !IsOutBound(enermyNearWinEvent.LastIndex)
                                    && !IsEnermyUsed(enermyNearWinEvent.LastIndex) && !IsEnermyUsed(enermyNearWinEvent.FirstIndex))
                                {
                                    EnermyNearWinEvent(this, enermyNearWinEvent);
                                    return true;
                                }
                            }

                        }
                    }
                    else winx = 0;
                    sx++;
                }
                winx = 0;
            }
            return false;
        }
    }
}
