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
        WinEventArgs winEventArgs = new WinEventArgs();
        public event EventHandler<WinEventArgs> WinEvent;

        public short[] Data { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
       
        public Array2D()
        {
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
            if (Data[index] == 0 || Data[index] == 1) return true;
            else return false;
        }

        public bool IsPeopleUse(int index)
        {
            if (Data[index] == 0) return true;
            else return false;
        }

        public void EnermyClick(int index)
        {
            Data[index] = 1;
            EnermyTurn();
        }

        public void PeopleClick(int index)
        {
            Data[index] = 0;
            PeopleTurn();
        }

        public void PeopleTurn()
        {
            int sx = 0, winx = 0, winy = 0, winr1 = 0, winr2 = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Count; j += Size+1)
                {
                    if (i > 21) break;
                    if (Data[j] == 0)
                    {
                        winr1++;
                        if (winr1 >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winr1 = 0;
                }
                for (int j = i; j < Count; j += Size-1)
                {
                    if (j > 3)
                    {
                        if (Data[j] == 0)
                        {
                            winr2++;
                            if (winr2 >= 5)
                            {
                                winEventArgs.IsPeoPleWin = true;
                                WinEvent(this, winEventArgs);
                            }
                        }
                        else winr2 = 0;
                    }
                }

                for (int j = i; j < Count; j += Size)
                {
                    if (Data[j] == 0)
                    {
                        winy++;
                        if (winy >= 5)
                        {
                            winEventArgs.IsPeoPleWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winy = 0;
                }

                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 0)
                    {
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
            }
        }

        public void EnermyTurn()
        {
            int sx = 0, winx = 0, winy = 0, winr1 = 0, winr2 = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int h = i; h < Count; h += Size+1)
                {
                    if (i > 21) break;
                    if (Data[h] == 1)
                    {
                        winr1++;
                        if (winr1 >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winr1 = 0;
                }
                for (int g = i; g < Count; g += Size-1)
                {
                    if (g > 3)
                    {
                        if (Data[g] == 1)
                        {
                            winr2++;
                            if (winr2 >= 5)
                            {
                                winEventArgs.IsEnermyWin = true;
                                WinEvent(this, winEventArgs);
                            }
                        }
                        else winr2 = 0;
                    }
                }

                for (int k = i; k < Count; k += Size)
                {
                    if (Data[k] == 1)
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

                for (int j = 0; j < Size; j++)
                {
                    if (Data[sx] == 1)
                    {
                        winx++;
                        if (winx >= 5)
                        {
                            winEventArgs.IsEnermyWin = true;
                            WinEvent(this, winEventArgs);
                        }
                    }
                    else winx = 0;
                    sx++;
                }
            }
        }

        public bool Is3Or4Used(out int FirstUsed3, out int LastUsed3)
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
                                if (!IsUsed(LastUsed3)) { return true; }
                                else if (!IsUsed(FirstUsed3)) { return true; }
                                else index = 0;
                            }                            
                        }
                        if (use3x >= 4)
                        {
                            LastUsed3 = used3[3] + 1;
                            FirstUsed3 = used3[0] - 1;
                            if (!IsUsed(LastUsed3)) { return true; }
                            else if (!IsUsed(FirstUsed3)) { return true; }
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
