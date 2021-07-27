using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CustomList<T>:IEnumerator<T>,ICollection<T>
    {
        private int size = 0;
        private int currentIndex = 0;
        private Nested<T> head;
        private Nested<T> tail;
        public T Current { get; private set; }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public bool IsReadOnly { get { return false; } }

        object IEnumerator.Current => Current;

        public void Add(T item)
        {   
            if(head is null)
            {
                head = tail = new Nested<T>(item);
            }
            else
            {
                tail.next = new Nested<T>(item);
                tail = tail.next; 
            }
            size++;
        }

        public void Clear()
        {
            size = currentIndex = 0;
        }

        public bool Contains(T item)
        {
            if ((object)item is null) return false;

            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            Nested<T> temp = head;
            for (int i = 0; i < this.size; i++)
            {
                if (equalityComparer.Equals(temp.item, item))
                    return true;
                temp = temp.next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public T this[int index] {

            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                
                Nested<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next; 
                }
                return temp.item;
            }
            set
            {
                if(index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                Nested<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                temp.item = value;
            }
        }


        public bool MoveNext()
        {
            if (currentIndex >= size)
            {
                Reset();
                return false;
            }

            Current = this[currentIndex++]; 
            return true;
        }

        public bool Remove(T item)
        {
            if ((object)item is null) return false;

            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            Nested<T> temp = head;
            Nested<T> prev = null;
            for (int i = 0; i < this.size; i++)
            {
                if(equalityComparer.Equals(temp.item, item))
                {
                    if (prev is null)
                        head = head.next;
                    else if (temp.next is null)
                        prev.next = null;
                    else
                        prev.next = temp.next;

                    size--;
                    return true;
                }
                prev = temp;
                temp = temp.next;
            }
            return false;
        }

        public void Reset()
        {
            currentIndex = 0;
        }

       

        class Nested<U>
        {
            public U item;
            public Nested<U> next;
            public Nested(U item, Nested<U> next = null)
            {
                this.next = next;
                this.item = item;
            }
        }
    }
}
