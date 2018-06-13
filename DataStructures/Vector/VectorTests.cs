using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Vector
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

        [TestMethod]
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

        [TestMethod]
        public void Find_an_element()
        {
            Vector<string> v = new Vector<string>(1);
            v.Push("a");
            v.Push("b");
            v.Push("c");
            Assert.AreEqual(1, v.Find("b"));
        }

        [TestMethod]
        public void Find_returns_neg1_when_cannot_find()
        {
            Vector<string> v = new Vector<string>(1);
            v.Push("a");
            Assert.AreEqual(-1, v.Find("b"));
        }
    }
}
