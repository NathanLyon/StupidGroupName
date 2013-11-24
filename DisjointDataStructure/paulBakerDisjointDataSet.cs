using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paulbaker
{
    class DisjointDataSet<T>
    {
        //I think I'm going to stray away from the typical design of this structure, in favor of just making it easier for myself to code and understand.
        //I went this direction because I was short on time, but it was simple and made sense to me. It's based off the descripting of "Quick Find" in this
        //youtube video. http://www.youtube.com/watch?v=gcmjC-OcWpI

        Dictionary<T, HashSet<T>> universe;

        /// <summary>
        /// Create a Disjoint Data Set
        /// </summary>
        public DisjointDataSet()
        {
            universe = new Dictionary<T, HashSet<T>>();
        }

        /// <summary>
        /// Creates a new set only consisting of the item.
        /// </summary>
        /// <param name="item">The unique item to add in the set.</param>
        /// <returns>Will return false if this item is already a member of a set, otherwise returns true indicating a new set has been created.</returns>
        public bool MakeSet(T item)
        {
            bool add = universe.ContainsKey(item);
            if (!add)
            {
                universe.Add(item, new HashSet<T>());
                universe[item].Add(item);
            }
            return add;
        }

        /// <summary>
        /// Finds the set any given item belongs to.
        /// </summary>
        /// <param name="item">The item that belongs to a given set.</param>
        /// <returns>Returns the set that the item belongs to. Returns null if the item does not exist.</returns>
        public HashSet<T> Find(T item)
        {
            HashSet<T> result = null;
            if (universe.ContainsKey(item))
            {
                result = universe[item];
            }
            return result;
        }

        /// <summary>
        /// Merges two sets of any given item.
        /// </summary>
        /// <param name="a">The first item</param>
        /// <param name="b">The second item</param>
        /// <returns></returns>
        public HashSet<T> Union(T a, T b)
        {
            HashSet<T> setA = Find(a);
            HashSet<T> setB = Find(b);
            if (setA == null || setB == null)
            {
                return null;
            }
            else if (System.Object.ReferenceEquals(setA, setB))
            {
                return setA;
            }
            HashSet<T> result = new HashSet<T>();
            result.UnionWith(setA);
            result.UnionWith(setB);
            //as the video described, this will unfortunately be in linear time...
            foreach (T item in result)
            {
                universe[item] = result;
            }
            return result;
        }
    }
}
