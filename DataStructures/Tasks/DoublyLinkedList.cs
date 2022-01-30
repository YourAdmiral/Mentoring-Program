using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> _head;

        private Node<T> _tail;

        public Node<T> First
        {
            get
            {
                return _head;
            }
            set
            {
                _head = value;
            }
        }

        public Node<T> Last
        {
            get
            {
                return _tail;
            }
            set
            {
                _tail = value;
            }
        }

        public int Length { get; private set; }

        public DoublyLinkedList()
        {
            Length = 0;
        }

        public void Add(T e)
        {
            var newNode = new Node<T>(
                Length,
                e);

            if (_tail == null)
            {
                _head = newNode;
            }
            else
            {
                newNode.Previous = _tail;

                _tail.Next = newNode;
            }

            _tail = newNode;

            Length++;
        }

        public void AddAt(
            int index,
            T e)
        {
            var current = _head;

            var newNode = new Node<T>(index, e);

            if (index == Length)
            {
                _tail = newNode;

                current.Next = newNode;

                Length++;
            }
            else
            {
                while (current != null)
                {
                    if (current.Index == index)
                    {
                        if (current.Next == null)
                        {
                            _tail = current;
                        }
                        else
                        {
                            current.Next.Previous = newNode;
                        }

                        if (current.Previous == null)
                        {
                            _head = newNode;
                        }
                        else
                        {
                            current.Previous.Next = newNode;
                        }

                        current = null;

                        Length++;

                        continue;
                    }

                    current = current.Next;
                }
            }
        }

        public T ElementAt(int index)
        {
            if (Length != 0)
            {
                var current = _head;

                while (current != null)
                {
                    if (current.Index == index)
                    {
                        return current.Data;
                    }

                    current = current.Next;
                }

                throw new IndexOutOfRangeException();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (item.ToString() == current.Data.ToString())
                {
                    if (current.Next == null)
                    {
                        _tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == null)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    Length--;

                    current = null;

                    continue;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Index == index)
                {
                    if (current.Next == null)
                    {
                        _tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == null)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    Length--;

                    return current.Data;
                }

                current = current.Next;
            }

            throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
