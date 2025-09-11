using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Utility
{
    public static void Swap<T>(ref T _Left, ref T _Right)
    {
        T Temp = _Left;
        _Left = _Right;
        _Right = Temp;
    }
}
