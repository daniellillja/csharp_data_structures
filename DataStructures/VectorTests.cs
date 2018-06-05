using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures
{
    [TestClass]
    public class VectorTests
    {
        private Vector<string> _defaultVector;

        [TestInitialize]
        public void Init()
        {
            _defaultVector = new Vector<string>();
        }

        [TestMethod]
        public void Default_vector_size()
        {
            int size = _defaultVector.GetSize();
            Assert.AreEqual(0, size);
        }

        [TestMethod]
        public void Default_vector_is_empty()
        {
            bool isEmpty = _defaultVector.IsEmpty();
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void Default_vector_capacity()
        {
            int cap = _defaultVector.GetCapacity();
            Assert.AreEqual(3, cap);
        }

        [TestMethod]
        public void Push_increases_size()
        {
            _defaultVector.Push("a");
            int size = _defaultVector.GetSize();
            Assert.AreEqual(1, size);

            string first = _defaultVector.At(0);
            Assert.AreEqual("a", first);
        }

        [TestMethod]
        public void Push_increases_capacity_if_needed()
        {
            Vector<string> v = new Vector<string>(1);
            v.Push("a");
            v.Push("b");

            int size = v.GetSize();
            Assert.AreEqual(2, size);

            int cap = v.GetCapacity();
            Assert.AreEqual(2, cap);

            string first = v.At(0);
            Assert.AreEqual("a", first);
        }

        [TestMethod]
        public void Insert_increases_size()
        {
            Vector<string> v = new Vector<string>(3);
            v.Push("a");
            v.Push("b");
            v.Insert(1, "c");

            int size = v.GetSize();
            Assert.AreEqual(3, size);

            int cap = v.GetCapacity();
            Assert.AreEqual(3, cap);
        }

        [TestMethod]
        public void Insert_shifts_elements_right()
        {
            Vector<string> v = new Vector<string>(4);
            v.Push("a");
            v.Push("b");
            v.Push("c");
            v.Insert(1, "d");

            Assert.AreEqual("a", v.At(0));
            Assert.AreEqual("d", v.At(1));
            Assert.AreEqual("b", v.At(2));
            Assert.AreEqual("c", v.At(3));
        }

        [TestMethod]
        public void Insert_expands_if_needed()
        {
            Vector<string> v = new Vector<string>(2);
            v.Push("a");
            v.Push("b");
            v.Insert(1, "c");

            Assert.AreEqual(v.GetCapacity(), 4);
            Assert.AreEqual(v.GetSize(), 3);

            Assert.AreEqual("a", v.At(0));
            Assert.AreEqual("c", v.At(1));
            Assert.AreEqual("b", v.At(2));
        }

        private class Vector<T>
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
        }
    }
}
