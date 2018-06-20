using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList _emptyList;

        [TestInitialize]
        public void Init()
        {
            _emptyList = new LinkedList();
        }

        [TestMethod]
        public void IsEmpty_empty_by_default()
        {
            Assert.IsTrue(_emptyList.IsEmpty());
        }

        [TestMethod]
        public void Count_zero_by_default()
        {
            Assert.AreEqual(0, _emptyList.Count);
        }

        [TestMethod]
        public void PushFront_increases_count_by_1()
        {
            _emptyList.PushFront(1);
            Assert.AreEqual(1, _emptyList.Count);
            _emptyList.PushBack(1);
            Assert.AreEqual(2, _emptyList.Count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValueAt_throws_when_no_data()
        {
            _emptyList.ValueAt(0);
        }

        [TestMethod]
        public void ValueAt_returns_head_key_at_index_0()
        {
            _emptyList.PushFront(1);
            Assert.AreEqual(1, _emptyList.ValueAt(0));
        }

        [TestMethod]
        public void ValueAt_returns_correct_keys()
        {
            _emptyList.PushBack(1);
            Assert.AreEqual(1, _emptyList.ValueAt(0));

            _emptyList.PushBack(2);
            Assert.AreEqual(2, _emptyList.ValueAt(1));
        }

        [TestMethod]
        public void PushFront_adds_item_to_front_of_list()
        {
            _emptyList.PushFront(1);
            Assert.AreEqual(1, _emptyList.ValueAt(0));

            _emptyList.PushFront(2);
            Assert.AreEqual(2, _emptyList.ValueAt(0));
        }

        [TestMethod]
        public void PopFront_removes_item_from_front_and_returns_value()
        {
            _emptyList.PushFront(1);
            _emptyList.PushFront(2);
            Assert.AreEqual(2, _emptyList.PopFront());
            Assert.AreEqual(1, _emptyList.PopFront());
            Assert.IsTrue(_emptyList.IsEmpty());
        }

        [TestMethod]
        public void PushBack_add_item_to_end()
        {
            _emptyList.PushBack(1);
            Assert.IsFalse(_emptyList.IsEmpty());
            Assert.AreEqual(1, _emptyList.ValueAt(0));
            _emptyList.PushBack(2);
            Assert.AreEqual(2, _emptyList.ValueAt(1));
        }

        [TestMethod]
        public void PopBack_removes_end_item_and_returns_value()
        {
            _emptyList.PushBack(1);
            Assert.AreEqual(1, _emptyList.PopBack());
            Assert.IsTrue(_emptyList.IsEmpty());

            _emptyList.PushBack(1);
            _emptyList.PushBack(2);
            Assert.AreEqual(2, _emptyList.PopBack());
            Assert.IsFalse(_emptyList.IsEmpty());
        }
    }
}
