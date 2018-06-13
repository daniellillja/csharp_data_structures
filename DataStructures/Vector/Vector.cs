namespace DataStructures.Vector
{
    public class Vector<T>
    {
        private const int DEFAULT_CAPACITY = 3;

        private int _size;
        private T[] _underlying;

        public Vector() : this(DEFAULT_CAPACITY)
        {
        }

        public Vector(int capacity)
        {
            _size = 0;
            _underlying = new T[capacity];
        }

        internal void Push(T value)
        {
            var cap = GetCapacity();
            if (_size == cap)
            {
                _underlying = Expand(_underlying);
            }

            _underlying[_size++] = value;
        }

        private static T[] Expand(T[] old)
        {
            int cap = old.Length;

            // create new underlying, doubling size
            T[] new_underlying = new T[cap * 2];

            // copy data to new underlying
            for (int i = 0; i < cap; i++)
            {
                new_underlying[i] = old[i];
            }

            // switch pointers
            return new_underlying;
        }

        internal T At(int index)
        {
            return _underlying[index];
        }

        internal int GetCapacity()
        {
            return _underlying.Length;
        }

        internal int GetSize()
        {
            return _size;
        }

        internal bool IsEmpty()
        {
            return _size == 0;
        }

        internal void Insert(int index, T value)
        {
            if (_size == GetCapacity())
            {
                _underlying = Expand(_underlying);
            }

            // move index..end one to right
            ShiftRight(index);
            _underlying[index] = value;
            _size++;
        }

        private void ShiftRight(int index)
        {
            int last = _size - 1;
            while (last >= index)
            {
                _underlying[last + 1] = _underlying[last--];
            }
        }

        internal void Prepend(T value)
        {
            Insert(0, value);
        }

        internal void Delete(int index)
        {
            if (index_out_of_bounds(index)) return;
            for (int cursor = index; !is_last_element(cursor); cursor++)
            {
                _underlying[cursor] = _underlying[cursor + 1];
            }
            _size--;
        }

        private bool index_out_of_bounds(int index)
        {
            return index >= _size || index < 0;
        }

        private bool is_last_element(int index)
        {
            return index == _size - 1;
        }

        internal void Remove(T value)
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                if (At(i).Equals(value))
                {
                    Delete(i);
                }
            }
        }

        internal int Find(T value)
        {
            for (int i = 0; i < _size; i++)
            {
                if (At(i).Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
