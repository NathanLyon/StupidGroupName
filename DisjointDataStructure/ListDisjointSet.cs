using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasFivas.DisjointSet
{
    public class ListDisjointSet<T> : ICollection<T>
    {
        #region inner classes
        public class ItemAlreadyExistsException : Exception { }
        #endregion

        #region fields, properties, and constructor
        private Dictionary<T, Set<T>> universe;

        public int Count
        {
            get { return universe.Count; }
        }
        public Set<T>[] Sets
        {
            get { return universe.Values.ToArray(); }
        }

        public ListDisjointSet()
        {
            universe = new Dictionary<T,Set<T>>();
            IsReadOnly = false;
        }
        #endregion

        #region ICollection
        public bool IsReadOnly { get; private set; }
        
        public void Clear()
        {
            universe.Clear();
        }

        public void CopyTo(T[] array, int index)
        {
            foreach (T key in universe.Keys)
            {
                array[index] = key;
                index++;
            }
        }

        public bool Contains(T item)
        {
            return universe.ContainsKey(item);
        }

        public void Add(T item)
        {
            MakeSet(item);
        }

        public void Add(T item, T setKey)
        {
            universe[setKey].Add(item);
            universe.Add(item, universe[setKey]);
        }

        public bool Remove(T item)
        {
            if (universe.ContainsKey(item))
            {
                universe[item].Remove(item);
                universe.Remove(item);
                return true;
            }
            return false;
        }
        #endregion

        #region Disjoint Set stuff
        public Set<T> Find(T item) 
        {
            return universe[item];
        }

        public void Union(Set<T> keptSet, Set<T> absorbedSet)
        {
            if (keptSet != absorbedSet)
                for (int i = 0; i < absorbedSet.Count; i++)
                {
                    T item = absorbedSet[i];
                    keptSet.Add(item);
                    universe[item] = keptSet;
                }
        }

        public void MakeSet(T item)
        {
            if (!universe.ContainsKey(item))
            {
                Set<T> set = new Set<T>(item);
                universe.Add(item, set);
            }
            else
                throw new ItemAlreadyExistsException();
        }

        public bool TryMakeSet(T item)
        {
            if (!universe.Keys.Contains(item))
            {
                MakeSet(item);
                return true;
            }
            else return false;
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return universe.Keys.GetEnumerator();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return universe.Keys.GetEnumerator();
        }
    }




    public class Set<T> : List<T>
    {
        public string Name { get; set; }
        public Set(T item)
            : base()
        {
            Name = string.Format("Set of \"{0}\"", item);
            base.Add(item);
        }
    }
}
