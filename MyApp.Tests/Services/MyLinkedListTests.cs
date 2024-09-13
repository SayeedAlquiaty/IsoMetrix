using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Tests.Services
{
    public class MyLinkedListTests
    {
        private readonly IMyLinkedList<int> _linkedList;

        public MyLinkedListTests() => _linkedList = new MyLinkedList<int>();

        [Fact]
        public void Insert_AddsNodeAtCorrectPosition()
        {
            _linkedList.Insert(1, 0);
            _linkedList.Insert(2, 1);
            _linkedList.Insert(3, 2);

            var item1 = _linkedList.GetItem(0);
            var item2 = _linkedList.GetItem(1);
            var item3 = _linkedList.GetItem(2);


            Assert.Equal(1, item1);
            Assert.Equal(2, item2);
            Assert.Equal(3, item3);

        }

        [Fact]
        public void Delete_RemovesNodeAtCorrectPosition()
        {
            _linkedList.Insert(1, 0);
            _linkedList.Insert(2, 1);
            _linkedList.Insert(3, 2);

            var itemBefore = _linkedList.GetItem(1);
            var item3 = _linkedList.GetItem(2);

            _linkedList.Delete(1);

            var itemAfter = _linkedList.GetItem(1);

            Assert.NotEqual(itemBefore, itemAfter);
            Assert.Equal(item3, itemAfter);

        }

        [Fact]
        public void Delete_InvalidPosition_ThrowsException()
        {
            _linkedList.Insert(1, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => _linkedList.Delete(10));

        }
    }
}
