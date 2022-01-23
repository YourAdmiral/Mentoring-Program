using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private IDoublyLinkedList<T> _storage;

        public HybridFlowProcessor()
        {
            _storage = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (_storage.Length > 0)
            {
                return _storage.RemoveAt(0);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Enqueue(T item)
        {
            _storage.Add(item);
        }

        public T Pop()
        {
            if (_storage.Length > 0)
            {
                int lastIndex = _storage.Length - 1;

                return _storage.ElementAt(lastIndex);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Push(T item)
        {
            _storage.Add(item);
        }
    }
}
