using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList
{
    internal class LinkedList
    {
        private int _count;
        private LinkedListNode _head;
        private LinkedListNode _tail;

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        internal bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(int item)
        {
            if (IsEmpty())
            {
                _head = new LinkedListNode(item);
                _tail = _head;
            }
            else if (_head == _tail)
            {
                _tail = new LinkedListNode(item);
                _head.Next = _tail;
            }

            _count++;
        }

        class LinkedListNode
        {
            public int Key { get; set; }
            public LinkedListNode Next { get; set; }
            public LinkedListNode(int key) : this(key, null)
            {
            }
            public LinkedListNode(int key, LinkedListNode next)
            {
                Key = key;
                Next = next;
            }
        }

        public int ValueAt(int index)
        {
            if (IsEmpty()) throw new ArgumentOutOfRangeException();

            LinkedListNode cursor = _head;
            var cursorIndex = 0;
            while (cursorIndex != index)
            {
                cursor = cursor.Next;
                cursorIndex++;
            }

            return cursor.Key;
        }

        internal void PushFront(int value)
        {
            if (IsEmpty())
            {
                _head = new LinkedListNode(value);
            }
            else
            {
                _head = new LinkedListNode(value, _head);
            }
            _count++;
        }

        internal int PopFront()
        {
            var frontValue = _head.Key;
            _head = _head.Next;
            _count--;
            return frontValue;
        }
    }
}
