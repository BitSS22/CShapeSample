using System;
using System.Collections.Generic;

// 예외 처리 안함. 터지면 사용자 탓.
public class LinkedList<Type>
{
    public class Iterator
    {
        public Iterator(LinkedList<Type> _Owner, node _Node)
        {
            Owner = _Owner;
            ptr = _Node;
        }

        public LinkedList<Type> Owner = null!;
        public node ptr = null!;

        static public Iterator operator++(Iterator _this)
        {
            if (_this.Owner.DNode != _this.ptr)
            {
                _this.ptr = _this.ptr.Next;
            }

            return _this;
        }
        static public Iterator operator--(Iterator _this)
        {
            if (_this.Owner.DNode != _this.ptr.Prev)
            {
                _this.ptr = _this.ptr.Prev;
            }

            return _this;
        }
    }
    public class node
    {
        public node(Type _Item)
        {
            Data = _Item;
        }
        public node Prev = null!;
        public node Next = null!;
        public Type Data = default!;
    }

    node DNode = new(default!);
    public UInt64 size { get; private set; } = 0;

    public void PushBack(Type _Item)
    {
        node NewNode = new(_Item);

        node PrevTail = DNode.Prev;
        PrevTail.Next = NewNode;
        DNode.Prev = NewNode;

        NewNode.Prev = PrevTail;
        NewNode.Next = DNode;

        ++size;
    }

    public void PushFront(Type _Item)
    {
        node NewNode = new(_Item);

        node PrevHead = DNode.Next;
        PrevHead.Prev = NewNode;
        DNode.Next = NewNode;

        NewNode.Next = PrevHead;
        NewNode.Prev = DNode;

        ++size;
    }

    public void Insert(Iterator _Where, Type _Item)
    {
        node NewNode = new(_Item);

        node WNode = _Where.ptr;
        node PNode = WNode.Prev;

        PNode.Next = NewNode;
        WNode.Prev = NewNode;

        NewNode.Prev = PNode;
        NewNode.Next = WNode;

        ++size;
    }

    public void Erase(Iterator _Where)
    {
        node PNode = _Where.ptr.Prev;
        node NNode = _Where.ptr.Next;

        _Where.ptr.Prev = default!;
        _Where.ptr.Next = default!;

        PNode.Next = NNode;
        NNode.Prev = PNode;

        --size;
    }

    public Iterator Begin()
    {
        return new Iterator(this, DNode.Next);
    }

    public Iterator End()
    {
        return new Iterator(this, DNode);
    }
}
