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
            _linkedList.Insert(3, 1);

            _linkedList.PrintList();

        }

        [Fact]
        public void Delete_RemovesNodeAtCorrectPosition()
        {
            _linkedList.Insert(1, 0);
            _linkedList.Insert(2, 1);
            _linkedList.Insert(3, 1);

            _linkedList.Delete(1);

            _linkedList.PrintList();

        }

        [Fact]
        public void Delete_InvalidPosition_ThrowsException()
        {
            _linkedList.Insert(1, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => _linkedList.Delete(10));

        }
    }
}
