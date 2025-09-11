

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> l = new LinkedList<int>();
        for (int i = 0; i < 10; ++i)
        {
            l.PushBack(i);
        }

        

        for (var iter = l.Begin(); iter != l.End(); ++iter)
        {
            Console.WriteLine(iter.ptr);
        }
    }
}

