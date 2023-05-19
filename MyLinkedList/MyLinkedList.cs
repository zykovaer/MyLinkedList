using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    internal class MyLinkedList<T> : IEnumerable<T>
    {
        class Item
        {
            public T Value;
            public Item Next;
        }

        private Item Head;

        public IEnumerator<T> GetEnumerator()
        {
            Item item = Head;
            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }

        public void AddLast(T value)
        {
            Item item = new Item() { Value = value};
            if (Head == null)
            {
                Head = item;
                return;
            }

            Item current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = item;
            
        }

        public void AddFirst(T value)
        {
            Item item = new Item() { Value = value };
            item.Next = Head;
            Head = item;
        }

        public bool Contains(T value)
        {
            Item current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value)) return true;
                current = current.Next;
            }
            return false;
        }

        public T Search(int i)
        {
            if (Head == null) throw new NullReferenceException("Список пуст");

            Item current = Head;
            int index = 0;
            while (current != null)
            {
                if (index == i)
                    return current.Value;
                current = current.Next;
                index++;
                
            }
            throw new Exception("Индекс находятся за пределами списка");
        }
        public int Count
        {
            get
            {
                if (Head == null)
                {
                    return 0;
                }
                else
                {
                    int count = 0;
                    Item current = Head;
                    while (current != null)
                    {
                        count++;
                        current = current.Next;
                    }
                    return count;
                }
            }
        }
        public void AddBefore(T value, int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            if (index == 0)
            {
                this.AddFirst(value);
            }
            else
            {
                Item newEl = new Item() { Value = value };

                Item tmp = Head;
                Item prev = tmp;
                for (int i = 1; i <= index; i++)
                {
                    prev = tmp;
                    tmp = tmp.Next;
                }

                newEl.Next = tmp;
                prev.Next = newEl;
            }
        }

        public void AddAfter(T value, int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            Item newEl = new Item() { Value = value };

            Item tmp = Head;
            Item next = tmp.Next;
            for (int i = 1; i <= index; i++)
            {
                tmp = tmp.Next;
                next = tmp.Next;
            }

            tmp.Next = newEl;
            newEl.Next = next;
        }

        public T PopFirst()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                T c = Head.Value;
                Head = Head.Next;
                return c;
            }
        }

        public T PopBack()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                if (Head.Next == null)
                {
                    T c = Head.Value;
                    Head = null;
                    return c;
                }
                else
                {
                    Item tmp = Head;
                    while (tmp.Next.Next != null)
                    {
                        tmp = tmp.Next;
                    }
                    T c = tmp.Next.Value;
                    tmp.Next = null;
                    return c;
                }
            }
        }

        public T PopAfter(int index)
        {
            if (index >= this.Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            Item tmp = Head;
            int count = 0;
            while (count != index)
            {
                tmp = tmp.Next;
                count++;
            }
            T result = tmp.Value;
            tmp.Next = tmp.Next.Next;
            return result;
        }
        public T PopBefore(int index)
        {
            if (index >= this.Count || index < 1)
            {
                throw new IndexOutOfRangeException("Индекс находился вне границ списка");
            }

            if (index == 1)
            {
                return PopFirst();
            }
            else
            {
                Item tmp = Head;
                int count = 0;
                while (count != index - 2)
                {
                    tmp = tmp.Next;
                    count++;
                }
                T result = tmp.Value;
                tmp.Next = tmp.Next.Next;
                return result;
            }
        }

        /// <summary>
        /// Вставить после каждого элемента, занимающего четную позицию в списке, 
        /// новый элемент Е1. Первый элемент имеет значение позиции равный 0
        /// </summary>
        /// <param name="value"></param>
        public void InsertAfterEven(T value)
        {
            if (Head == null) return;

            Item current = Head;
            int index = 0;
            while (current!=null)
            {
                if(index % 2 == 0)
                {
                    Item item = new Item() { Value = value };
                    item.Next = current.Next;
                    current.Next = item;
                    current = current.Next;
                }
                current = current.Next;
                index++;
            }
        }

        public static MyLinkedList<T> operator +(MyLinkedList<T> myLinkedList1, MyLinkedList<T> myLinkedList2)
        {
            if (myLinkedList1.Count != myLinkedList2.Count) throw new ArgumentException("Списки должны быть одинаковой длинны");

            MyLinkedList<T> result = new MyLinkedList<T>();
            for (int i = 0; i < myLinkedList1.Count; i++)
            {
                result.AddLast(myLinkedList1.Search(i));
                result.AddLast(myLinkedList2.Search(i));
            }
            return result;
        }
    }
}
