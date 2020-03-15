using System;

namespace _200313
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            for (Node<T> x = head; x != null; x = x.Next)
                action(x.Data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            int sum = 0;int max =9;int min = 0;
            intlist.ForEach(x => Console.WriteLine(x));
            intlist.ForEach(x =>  sum += x);
            intlist.ForEach(x=> { if (x > max) x = max; });
            intlist.ForEach(x => { if (x <min) x = min; });
            Console.WriteLine(sum);
            Console.WriteLine(max);
            Console.WriteLine(min);

        }

    }
}
