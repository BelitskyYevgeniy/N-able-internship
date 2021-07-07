using System;
using System.Collections;
using System.Collections.Generic;

namespace Sort
{


    public class List<T> : ICollection<T>, IEnumerator<T>
    {
        protected class Node : IDisposable
        {
            protected List<T> _container;

            public Node Next { get; set; }
            public T Value { get; set; }

            public Node(List<T> container) : base()
            {
                _container = container;
            }
            public Node(List<T> container, T value) : this(container)
            {
                this.Value = value;
            }

            public void Dispose()
            {
                if (Value is IDisposable)
                {
                    (Value as IDisposable).Dispose();
                }
                return;
            }
        }

        protected Node _start = null;
        protected bool IsIterator { get; set; } = false;
        protected Node _iterator;
        private void ClearIteration(Node item)
        {
            if (item.Next == null)
            {
                return;
            }
            ClearIteration(item.Next);
            (item as IDisposable).Dispose();
        }
        private void Add(Node previous, T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            Node newNode = new Node(this, item);
            if (previous == null)
            {
                newNode.Next = _start;
                _start = newNode;
                return;
            }
            Node next = previous.Next;
            previous.Next = newNode;
            newNode.Next = next;
        }

        protected virtual Node Search(T item, out Node previous)
        {
            previous = null;
            Node node = _start;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return node;
                }
                previous = node;
                node = node.Next;
            }
            return null;
        }
        protected virtual Node TakeLast()
        {
            Node node = _start;
            if (_start == null)
                return null;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node;
        }

        public int Count
        {
            get
            {
                var node = _start;
                int count = 0;
                while (node != null)
                {
                    count++;
                    node = node.Next;
                }
                return count;
            }
        }

        public bool IsReadOnly => true;

        public T Current
        {
            get
            {
                if (_start == null || _iterator == null || _iterator.Next == _start)
                {
                    throw new InvalidOperationException();
                }
                return _iterator.Value;
            }

        }

        object IEnumerator.Current 
        {
            get 
            {
                return Current;
            }
        }

        public void Add(T item)
        {
            Add(TakeLast(), item);
        }
       
        public bool Remove(T item)
        {
            Node previous;
            Search(item, out previous);
            return Remove(previous);
        }
        private bool Remove(Node previousItem)
        {
            Node item = previousItem.Next;
            if(item == null || item.Next == _start)
            {
                return false;
            }
            if (item == _start)
            {
                _start = item.Next;
            }
            else
            {
                previousItem.Next = item.Next;
                item.Dispose();
            }

            return true;
        }
        public bool Remove(IEnumerator<T> previousItem)
        {
            return Remove((previousItem as List<T>)._iterator);
        }

        public void Add(IEnumerator previous, T item)
        {
            Node previousNode = (previous as List<T>)._iterator;
            if(previousNode.Next == _start)
                previousNode = null;
            Add(previousNode, item);
        }

        public void Clear()
        {
            if(_start is IDisposable)
            {
                ClearIteration(_start);
            }
            _start = null;
            
        }

        public IEnumerator GetEnumerator()
        {
            List<T> iterator =  new List<T>();
            iterator.IsIterator = true;
            iterator._start = _start;
            iterator.Reset();
            return iterator;
        }

        public bool Contains(T item)
        {
            Node previous;
            return Search(item, out previous) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var iterator = GetEnumerator();
            if (array == null || iterator.MoveNext())
            {
                throw new ArgumentNullException();
            }
            
            int index = 0;
            while(index != arrayIndex)
            { 
                if(!iterator.MoveNext())
                {
                    throw new ArgumentOutOfRangeException();
                }
                index++;
            }
            index = 0;
            do
            {
                if(index == array.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
               // array[index] = (iterator as Node).Current;
            }
            while (iterator.MoveNext());
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator() as IEnumerator<T>;
        }///

        public void Dispose()
        {
            if (IsIterator)
            {
                Clear();
            }
        }

        public bool MoveNext()
        {
            if (_start == null || _iterator == null)
            {
                throw new InvalidOperationException();
            }
            bool isEnd = _iterator.Next != null;
            _iterator = _iterator.Next;
            return isEnd;
        }
        
        public void Reset()
        {
            _iterator = new Node(this);
            _iterator.Next = _start;
        }
    }
}
