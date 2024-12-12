using System;
using System.Collections.Generic;

namespace Priority_Queue_csharp
{
    public class PriorityQueue<T>
    {
        private List<(T item, int priority)> _elements;

        public PriorityQueue()
        {
            _elements = new List<(T item, int priority)>();
        }

        public void Enqueue(T item, int priority)
        {
            var newElement = (item, priority);
            int i = 0;

            while (i < _elements.Count && _elements[i].priority >= priority)
            {
                i++;
            }

            _elements.Insert(i, newElement);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var highestPriorityElement = _elements[0];
            _elements.RemoveAt(0);
            return highestPriorityElement.item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _elements[0].item;
        }

        public bool IsEmpty()
        {
            return _elements.Count == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pq = new PriorityQueue<string>();

            pq.Enqueue("Low priority task", 1);
            pq.Enqueue("Medium priority task", 5);
            pq.Enqueue("High priority task", 10);

            Console.WriteLine("Elements in Priority Queue:");

            while (!pq.IsEmpty())
            {
                Console.WriteLine(pq.Dequeue());
            }
        }
    }
}
