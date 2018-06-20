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
            if (index >= _count) throw new ArgumentOutOfRangeException();
            if (index == 0) return _head.Key;

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

        internal void PushBack(int value)
        {
            if (IsEmpty())
            {
                _head = new LinkedListNode(value);
            }
            else
            {
                var newTail = new LinkedListNode(value);
                if(_tail == null)
                {
                    _tail = newTail;
                    _head.Next = _tail;
                }
                else
                {
                _tail.Next = newTail;
                }
            }
            _count++;
        }
    }
}
