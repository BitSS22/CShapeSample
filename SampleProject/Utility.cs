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

    public static void Add(int[,] _Map ,int _Y, int _X)
    {
        _add(_Map, _Y + 1, _X + 1);
        _add(_Map, _Y - 1, _X + 1);
        _add(_Map, _Y + 1, _X - 1);
        _add(_Map, _Y - 1, _X - 1);
    }

    static void _add(int[,] _Map, int _Y, int _X)
    {
        if (_Y < 0 || _X < 0 || _Y >= _Map.GetLength(0) || _X >= _Map.GetLength(1))
            return;
        ++_Map[_Y, _X];
    }

}
