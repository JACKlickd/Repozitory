using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStruct
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }

    public class MyStruct<T> : IEnumerable<T>
    {
        Node<T> head, tail;
        int count;
        T max;

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (tail == null)
                tail = node;
            else
            {
                head.Previous = node;
                node.Next = head;
            }
            head = node;
            if (max == null || Convert.ToDouble(max) < Convert.ToDouble(item))
                max = item;
            count++;
        }

        public bool Remove(T data)
        {
            if (IsEmpty)
                return false;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                tail = current.Previous;
            }
            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }
            count--;
            return true;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public double Average()
        {
            if (IsEmpty)
                return 0;
            Node<T> current = head;
            double sum = 0;
            while (current != null)
            {
                sum += Convert.ToDouble(current.Data);
                current = current.Next;
            }
            return sum / count;
        }

        public int SmallerThanAverageCount()
        {
            if (IsEmpty)
                return 0;
            Node<T> current = head;
            double a = Average();
            int count = 0;
            while (current != null)
            {
                if (Convert.ToDouble(current.Data) < a)
                    count++;
                current = current.Next;
            }
            return count;
        }

        public bool RemoveAllElementsAfterTheMax()
        {
            if (IsEmpty)
                return false;
            Node<T> current = head;
            do
            {
                current = current.Next;
            } while (Convert.ToDouble(current.Data) != Convert.ToDouble(max));
            while (current != null)
            {
                Remove(current.Data);
                current = current.Next;
            }
            return true;
        }

        public void Show()
        {
            Node<T> current = head;
            Console.WriteLine("List:");
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            Console.WriteLine();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
