using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class MyLinkedList<T> : IMyLinkedList<T>
    {
        private Node<T> _head;
        public void Delete(int position)
        {
            if (_head == null)
                throw new InvalidOperationException("List is empty.");

            if(position == 0)
            {
                _head = _head.Next;
            }
            else
            {
                Node<T> current = _head;
                int currentIndex = 0;

                while (current != null && currentIndex < position - 1)
                {
                    current = current.Next;
                    currentIndex++;
                }

                if (current == null || current.Next == null)
                    throw new ArgumentOutOfRangeException("Position is out of bounds.");

                current.Next = current.Next.Next;
            }
            
        }

        public void Insert(T item, int position)
        {
            Node<T> newNode = new Node<T>(item);

            if(position == 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                Node<T> current = _head;
                int currentIndex = 0;

                while(current != null && currentIndex < position - 1)
                {
                    current = current.Next;
                    currentIndex++;
                }

                if(current == null)
                    throw new ArgumentOutOfRangeException("Position is out of bounds.");

                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public T GetItem(int position)
        {
            if (position == 0)
            {
                return _head.Data;
            }
            else
            {
                Node<T> current = _head;
                int currentIndex = 0;

                while (current != null && currentIndex < position)
                {
                    current = current.Next;
                    currentIndex++;
                }

                if (current == null)
                    throw new ArgumentOutOfRangeException("Position is out of bounds.");

                return current.Data;
            }
        }
    }
}
