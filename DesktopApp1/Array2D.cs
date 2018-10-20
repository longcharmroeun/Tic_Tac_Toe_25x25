using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_25x25
{
    class EnermyEventArgs : EventArgs
    {
        
    }

    class PeopleNearWinEventArgs : EventArgs
    {
        public int LastIndex { get; set; }
        public int FirstIndex { get; set; }
    }

    class Array2D
    {
        private WinEventArgs winEventArgs;
        private readonly EnermyEventArgs enermyEventArgs;
        private readonly PeopleNearWinEventArgs peopleNearWin;

        public event EventHandler<WinEventArgs> WinEvent;
        public event EventHandler<EnermyEventArgs> EnermyEvent;
        public event EventHandler<PeopleNearWinEventArgs> PeopleNearWinEvent; 

        public short[] Data { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
       
        public Array2D()
        {
            winEventArgs = new WinEventArgs();
            enermyEventArgs = new EnermyEventArgs();
            peopleNearWin = new PeopleNearWinEventArgs();

            Size = 25;
            Count = Size * Size;
            Data = new short[Count];
            for (int i = 0; i < 625; i++)
            {
                Data[i] = -1;
            }
        }

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

        private bool IsLastColumn(int index)
        {
            for (int i = Size-1; i < Count; i+=Size)
            {
                if (index == i) return true;
            }
            return false;
        }

        private bool IsFirstColumn(int index)
        {
            for (int i = 0; i < Count; i+=Size)
            {
                if (index == i) return true;
            }
            return false;
        }

        private bool IsUpRow(int index)
        {
            for (int i = 0; i < Size; i++)
            {
                if (index == i) return true;
            }
            return false;
        }

        private bool IsDownRow(int index)
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
            Data[index] = 0;
            PeopleWinUpDown();
            PeopleWinBackWard();
            PeopleWinForWard();
            if(!EnermyNearLost()) EnermyEvent(this, enermyEventArgs); ;
        }


        private bool EnermyLostBackWard()
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


        private bool EnermyNearLostForWard()
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

        private bool EnermyNearLost()
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
                    else winx = 0;
                    sx++;
                }
                winx = 0;
            }
            return false;
        }

        private void PeopleWinForWard()
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

        private void PeopleWinBackWard()
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

        private void PeopleWinUpDown()
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

        public void EnermyWinForWard()
        {
            int index = 0, win = 0, count = Size - 1;
            for (int i = Size - 5; i >= 0; i--)
            {
                index = i;
                for (int j = i; j < Size; j++)
                {
                    if (Data[index] == 1)
                    {
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

        public void EnermyWinBackWard()
        {
            int index = 0, win = 0, count = Size - 1;
            for (int i = 4; i < Size; i++)
            {
                index = i;
                for (int j = i; j <= i + i; j++)
                {
                    if (Data[index] == 1)
                    {
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
            
        public void EnermyWinUpDown()
        {
            int index = 0, winx = 0, winy = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 1)
                    {
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

        public bool IsEnermyNearLose(out int FirstUsed3, out int LastUsed3)
        {
            int sx = 0;
            int use3x = 0, use3y = 0, use3r2 = 0, use3r1 = 0;
            int[] used3 = new int[9];
            int index = 0;
            bool Near = false;


            for (int i = 0; i < Size; i++)
            {
                
                for (int j = i; j < Count; j += Size + 1)
                {
                    if (Data[j] == 1) { Near = true; }
                    else if (Data[j] == -1) Near = false;
                    if (Data[j] == 0)
                    {
                        used3[index] = j;
                        index++;
                        use3r1++;
                        if (use3r1 >= 3)
                        {
                            if (!Near)
                            {
                                FirstUsed3 = used3[0] - Size - 1;
                                LastUsed3 = used3[2] + 1 + Size;
                                if (!IsUsed(LastUsed3)) { return true; }
                                else if (!IsUsed(FirstUsed3)) { return true; }
                                else index = 0;
                            }
                        }
                        if (use3r1 >= 4)
                        {
                            FirstUsed3 = used3[0] - Size - 1;
                            LastUsed3 = used3[3] + 1 + Size;
                            if (!IsUsed(LastUsed3)) { return true; }
                            else if (!IsUsed(FirstUsed3)) { return true; }
                            else index = 0;
                        }

                    }
                    else
                    {
                        index = 0;
                        use3r1 = 0;
                    }
                }


                for (int j = i; j < Count; j += Size - 1)
                {
                    if (Data[j] == 1) { Near = true; }
                    else if (Data[j] == -1) Near = false;
                    if (Data[j] == 0)
                    {
                        used3[index] = j;
                        index++;
                        use3r2++;
                        if (use3r2 >= 3)
                        {
                            if (!Near)
                            {
                                FirstUsed3 = used3[0] + 1 - Size;
                                LastUsed3 = used3[2] - 1 + Size;
                                if (!IsUsed(LastUsed3)) { return true; }
                                else if (!IsUsed(FirstUsed3)) { return true; }
                                else index = 0;
                            }
                        }
                        if (use3r2 >= 4)
                        {
                            FirstUsed3 = used3[0] + 1 - Size;
                            LastUsed3 = used3[3] - 1 + Size;
                            if (!IsUsed(LastUsed3)) { return true; }
                            else if (!IsUsed(FirstUsed3)) { return true; }
                            else index = 0;
                        }
                    }
                    else
                    {
                        index = 0;
                        use3r2 = 0;
                    }
                }


                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 1) { Near = true; }
                    else if (Data[j] == -1) Near = false;

                    if (Data[j] == 0)
                    {
                        used3[index] = j;
                        index++;
                        use3y++;
                        if (use3y >= 3)
                        {
                            if (!Near)
                            {
                                FirstUsed3 = used3[0] - Size;
                                LastUsed3 = used3[2] + Size;
                                if (!IsUsed(LastUsed3)) { return true; }
                                else if (!IsUsed(FirstUsed3)) { return true; }
                                else index = 0;
                            }
                        }
                        if (use3y >= 4)
                        {
                            FirstUsed3 = used3[0] - Size;
                            LastUsed3 = used3[3] + Size;
                            if (!IsUsed(LastUsed3)) { return true; }
                            else if (!IsUsed(FirstUsed3)) { return true; }
                            else index = 0;
                        }
                    }
                    else
                    {
                        index = 0;
                        use3y = 0;
                    }
                }
                

                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 1) { Near = true; }
                    else if (Data[sx] == -1) Near = false;

                    if (Data[sx] == 0)
                    {
                        used3[index] = sx;
                        index++;
                        use3x++;
                        if (use3x >= 3)
                        {
                            if (!Near)
                            {
                                LastUsed3 = used3[2] + 1;
                                FirstUsed3 = used3[0] - 1;
                                if (!IsUsed(LastUsed3) && !IsUsed(FirstUsed3))
                                {
                                    return true;
                                }
                                else index = 0;
                            }                            
                        }
                        if (use3x >= 4)
                        {
                            LastUsed3 = used3[3] + 1;
                            FirstUsed3 = used3[0] - 1;
                            if (!IsUsed(LastUsed3))
                            {
                                return true;
                            }
                            else if (!IsUsed(FirstUsed3))
                            {
                                return true;
                            }
                            else index = 0;
                        }
                    }
                    else
                    {
                        index = 0;
                        use3x = 0;
                    }
                    sx++;
                }
            }
            FirstUsed3 = -1;
            LastUsed3 = -1;
            return false;
        }
        
    }
}
