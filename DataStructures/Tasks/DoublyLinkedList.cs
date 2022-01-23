using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private List<T> _list;

        public int Length { get; private set; }

        public DoublyLinkedList()
        {
            _list = new List<T>();

            Length = 0;
        }

        public void Add(T e)
        {
            _list.Add(e);

            Length++;
        }

        public void AddAt(int index, T e)
        {
            _list.Insert(index, e);

            Length++;
        }

        public T ElementAt(int index)
        {
            if (Length != 0 
                && index >= 0
                && index < Length)
            {
                return _list[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.Cast<T>().GetEnumerator();
        }

        public void Remove(T item)
        {
            if (_list.Contains(item))
            {
                _list.Remove(item);

                Length--;
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= 0 && index < Length)
            {
                T item = _list[index];

                _list.RemoveAt(index);

                Length--;

                return item;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
