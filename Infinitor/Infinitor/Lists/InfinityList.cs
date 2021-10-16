using System;
using System.Collections;
using System.Collections.Generic;
using Infinitor.Strategies;

namespace Infinitor
{
    public sealed partial class InfinityList<T> : IReadOnlyList<T>, ICollection<T>
    {
        private readonly IGenerationStrategy<T> strategy;
 
        /// <summary>
        /// Constructor of the InfinityList
        /// </summary>
        /// <remarks>
        /// This function is O(1)
        /// </remarks>
        public InfinityList(IGenerationStrategy<T> strategy)
        {
            this.strategy = strategy;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new InfinityListReadOnlyException();
        }

        public void Clear()
        {
            throw new InfinityListReadOnlyException();
        }

        public bool Contains(T item)
        {
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new TooLargeToCopyException();
        }

        public bool Remove(T item)
        {
            throw new InfinityListReadOnlyException();
        }

        /// <summary>
        /// Total items on this list
        /// This will be always 2,147,483,647 this is the limit of positive integer
        /// </summary>
        /// <example>
        /// Console.WriteLine(list.Count);
        /// // Will print 2147483647
        /// </example>
        /// <remarks>
        /// This function is O(1)
        /// </remarks>
        public int Count => int.MaxValue;
        
        /// <summary>
        /// Check if this list is a Read Only list
        /// This will return always true
        /// </summary>
        /// <remarks>
        /// This function is O(1)
        /// </remarks>
        public bool IsReadOnly => true;

        public T this[int index] => GetGeneratedItem(index);

        private T GetGeneratedItem(int index)
        {
            var rnd = new Random(index);
            var value = rnd.Next();
            return strategy.Generate(value);
        }
    }
}