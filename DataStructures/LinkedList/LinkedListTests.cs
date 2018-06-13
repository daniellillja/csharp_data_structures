using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList _defaultList;

        [TestInitialize]
        public void Init()
        {
            _defaultList = new LinkedList();
        }

        [TestMethod]
        public void IsEmpty_empty_by_default()
        {
            Assert.IsTrue(_defaultList.IsEmpty());
        }

        [TestMethod]
        public void Count_zero_by_default()
        {
            Assert.AreEqual(0, _defaultList.Count);
        }

        [TestMethod]
        public void Add_increases_count_by_1()
        {
            _defaultList.Add(1);
            Assert.AreEqual(1, _defaultList.Count);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void At_throws_by_default()
        {
            _defaultList.At(0);
        }

        [TestMethod]
        public void At_returns_head_key_at_index_0()
        {
            _defaultList.Add(1);
            Assert.AreEqual(1, _defaultList.At(0));
        }

        [TestMethod]
        public void At_returns_correct_key_at_index_1()
        {
            _defaultList.Add(1);
            _defaultList.Add(2);
            Assert.AreEqual(2, _defaultList.At(1));
        }
    }
}
