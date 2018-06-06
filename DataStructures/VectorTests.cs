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

        [TestMethod]
        public void Prepend_inserts_first()
        {
            Vector<string> v = new Vector<string>(2);
            v.Push("a");
            v.Prepend("b");

            Assert.AreEqual("b", v.At(0));
            Assert.AreEqual("a", v.At(1));
        }

        [TestMethod]
        public void Delete_removes_and_shifts_elements_left()
        {
            Vector<string> v = new Vector<string>(3);
            v.Push("a");
            v.Push("b");
            v.Push("c");
            v.Delete(0);

            Assert.AreEqual("b", v.At(0));
            Assert.AreEqual("c", v.At(1));
            Assert.AreEqual(2, v.GetSize());
        }

        [TestMethod]
        public void Delete_invalid_index()
        {
            Vector<string> v = new Vector<string>(1);
            v.Push("a");
            v.Delete(1);
            v.Delete(-1);

            Assert.AreEqual("a", v.At(0));
        }

        [TestMethod]
        public void Remove_an_element()
        {
            Vector<string> v = new Vector<string>(1);
            v.Push("a");
            v.Push("b");
            v.Remove("a");

            Assert.AreEqual(1, v.GetSize());
            Assert.AreEqual("b", v.At(0));
            Assert.AreEqual("b", v.At(1));
        }

        [TestMethod, Ignore("Not working")]
        public void Remove_all_elements()
        {
            Vector<string> v = new Vector<string>(1);
            v.Push("a");
            v.Push("a");
            v.Remove("a");

            Assert.AreEqual(0, v.GetSize());
            Assert.AreEqual("a", v.At(0));
            Assert.AreEqual("a", v.At(1));
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

            internal void Prepend(T value)
            {
                Insert(0, value);
            }

            internal void Delete(int index)
            {
                if (index_out_of_bounds(index)) return;
                for(int cursor = index; !is_last_element(cursor); cursor++)
                {
                    _underlying[cursor] = _underlying[cursor+1];
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
                int initial_size = _size;
                for (int i = 0; i < initial_size; i++)
                {
                    if (At(i).Equals(value))
                    {
                        Delete(i);
                    }
                }
            }
        }
    }
}
