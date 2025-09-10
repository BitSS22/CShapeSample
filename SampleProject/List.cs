using System;

// 예외 처리 안함. 터지면 사용자 탓.
public class List<Type>
{
    Type[] arr = Array.Empty<Type>();
    public System.UInt64 size { get; private set; } = 0;
    public System.UInt64 capacity { get; private set; } = 0;
    public Type this[UInt64 _Index]
    {
        get => arr[_Index];
        set => arr[_Index] = value;
    }

    public void PushBack(Type _Item)
    {
        if (size >= capacity)
        {
            UInt64 NewCapacity = capacity == 0 ? 1 : capacity * 2;
            ReAllocate(NewCapacity);
        }

        arr[size++] = _Item;
    }

    public void PopBack()
    {
        arr[--size] = default!;
    }

    public void Erase(UInt64 _Index)
    {
        --size;

        for (UInt64 i = _Index; i < size; ++i)
        {
            arr[_Index] = arr[_Index + 1];
        }

        arr[size] = default!;
    }

    void ReAllocate(System.UInt64 _NewCapacity)
    {
        Type[] NewArr = new Type[_NewCapacity];

        for (UInt64 i = 0; i < size; ++i)
        {
            NewArr[i] = arr[i];
        }

        arr = NewArr;
        capacity = _NewCapacity;
    }

}
