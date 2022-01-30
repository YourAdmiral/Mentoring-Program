using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class Node<T>
    {
        private int _index;

        private T _data;

        private Node<T> _next;

        private Node<T> _previous;

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public Node<T> Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }

        public Node<T> Previous
        {
            get
            {
                return _previous;
            }
            set
            {
                _previous = value;
            }
        }

        public Node(
            int index,
            T data)
        {
            _index = index;
            _data = data;
        }
    }
}
