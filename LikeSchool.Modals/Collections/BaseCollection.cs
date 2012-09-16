using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Modals
{
    public class BaseCollection<T> : IList<T> where T : new()
    {
        private List<T> modals;
        internal List<T> Modals
        {
            get
            {
                if (modals == null)
                    modals = new List<T>();

                return modals;
            }
        }
        public int IndexOf(T item)
        {
            return Modals.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Modals.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Modals.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return Modals[index];
            }
            set
            {
                Modals[index] = value;
            }
        }

        public void Add(T item)
        {
            Modals.Add(item);
        }

        public void Clear()
        {
            Modals.Clear();
        }

        public bool Contains(T item)
        {
            return Modals.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Modals.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Modals.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            return Modals.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Modals.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
