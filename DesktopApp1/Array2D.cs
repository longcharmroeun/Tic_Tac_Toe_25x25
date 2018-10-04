using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_25x25
{
    class Array2D
    {
        public short[] Data { get; set; }
        public const int Count = 625;
        public const int Size = 25;

        public Array2D()
        {
            Data = new short[Count];
            for (int i = 0; i < 625; i++)
            {
                Data[i] = -1;
            }
        }

        public bool IsUsed(int index)
        {
            if (Data[index] == 0 || Data[index] == 1) return true;
            else return false;
        }

        public void EnermyClick(int index)
        {
            Data[index] = 1;
        }

        public void PeopleClick(int index)
        {
            Data[index] = 0;
        }

        public bool IsPeopleWin()
        {
            int sx = 0, winx = 0, winy = 0, winr1 = 0, winr2 = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int h = i; h < Count; h += 26)
                {
                    if (i >= 21) break;
                    if (Data[h] == 0)
                    {
                        winr1++;
                        if (winr1 >= 5) return true;
                    }
                    else winr1 = 0;
                }
                for (int g = i; g < Count; g += 24)
                {
                    if (g > 3)
                    {
                        if (Data[g] == 0)
                        {
                            winr2++;
                            if (winr2 >= 5) return true;
                        }
                        else winr2 = 0;
                    }
                }

                for (int k = i; k < Count; k += 25)
                {
                    if (Data[k] == 0)
                    {
                        winy++;
                        if (winy >= 5) return true;
                    }
                    else winy = 0;
                }

                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 0)
                    {
                        winx++;
                        if (winx >= 5) return true;
                    }
                    else winx = 0;
                    sx++;
                }
            }
            return false;
        }

        public bool IsEnermyWin()
        {
            int sx = 0, winx = 0, winy = 0, winr1 = 0, winr2 = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int h = i; h < Count; h += 26)
                {
                    if (i >= 21) break;
                    if (Data[h] == 1)
                    {
                        winr1++;
                        if (winr1 >= 5) return true;
                    }
                    else winr1 = 0;
                }
                for (int g = i; g < Count; g += 24)
                {
                    if (g > 3)
                    {
                        if (Data[g] == 1)
                        {
                            winr2++;
                            if (winr2 >= 5) return true;
                        }
                        else winr2 = 0;
                    }
                }

                for (int k = i; k < Count; k += 25)
                {
                    if (Data[k] == 1)
                    {
                        winy++;
                        if (winy >= 5) return true;
                    }
                    else winy = 0;
                }

                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 1)
                    {
                        winx++;
                        if (winx >= 5) return true;
                    }
                    else winx = 0;
                    sx++;
                }
            }
            return false;
        }
    }
}
