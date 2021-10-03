using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor
{
    public abstract class InfinityList<T> : IReadOnlyList<T>, ICollection<T>
    {
        private readonly InfinityListType type;
        private readonly T[] randomItems = Array.Empty<T>();
        private readonly ProportionalItem<T>[] proportional = Array.Empty<ProportionalItem<T>>();
        private readonly int cappedValue = int.MaxValue;
        private readonly int proportionalTotal;

        /// <summary>
        /// Constructor of the InfinityList
        /// </summary>
        /// <remarks>
        /// This function is O(1)
        /// </remarks>
        protected InfinityList()
        {
            type = InfinityListType.Unlimited;
        }
        
        /// <summary>
        /// Constructor of the InfinityList
        /// </summary>
        /// <param name="proportional">
        /// List of proportional items
        /// </param>
        /// <remarks>
        /// This function is O(n)
        /// </remarks>
        protected InfinityList(IEnumerable<ProportionalItem<T>> proportional)
        {
            this.proportional = proportional.ToArray();
            proportionalTotal = this.proportional.Sum(x => x.FullIntChance);
            type = InfinityListType.Proportional;
        }
        /// <summary>
        /// Constructor of the InfinityList
        /// </summary>
        /// <param name="randomItems">
        /// List of random items, every item will be have one of thus items
        /// </param>
        /// <remarks>
        /// This function is O(1)
        /// </remarks>
        protected InfinityList(IEnumerable<T> randomItems)
        {
            this.randomItems = randomItems.ToArray();
            type = InfinityListType.LimitedItems;
        }

        /// <summary>
        /// Constructor of the InfinityList
        /// </summary>
        /// <param name="cappedValue"></param>
        /// Will limit the number of items, ex: if pass 20, will had between 0 and 19 result
        /// <remarks>
        /// This function is O(1)
        /// </remarks>
        protected InfinityList(int cappedValue)
        {
            this.cappedValue = cappedValue;
            type = InfinityListType.Capped;
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

            return type switch
                   {
                       InfinityListType.Capped => GetGeneratedCustomItem(value % cappedValue),
                       InfinityListType.LimitedItems => GetLimitedItems(value),
                       InfinityListType.Proportional => GetProportionalValue(value),
                       _ => GetGeneratedCustomItem(value)
                   };
        }

        private T GetLimitedItems(int value)
        {
            var max = Math.Min(randomItems.Length, cappedValue);
            return randomItems[value % max];
        }

        private T GetProportionalValue(int value)
        {
            var chance = value % proportionalTotal;
            var selected = default(T);

            foreach (var item in proportional)
            {
                if (chance < item.FullIntChance)
                {
                    selected = item.Value;
                    break;
                }

                chance -= item.FullIntChance;
            }

            return selected!;
        }

        protected abstract T GetGeneratedCustomItem(int randomValue);

        [Serializable]
        public record Enumerator : IEnumerator<T>
        {
            private readonly InfinityList<T> list;
            public int Index { get; private set; }
            public bool Disposed { get; private set; }

            public void JumpToIndex(int index)
            {
                Index = index;
                Current = list[Index];
            }

            internal Enumerator(InfinityList<T> list)
            {
                this.list = list;
                Index = 0;
                Current = default!;
            }

            public bool MoveNext()
            {
                if (Index >= list.Count) return false;
                
                Current = list[Index];
                Index++;
                return true;
            }

            public void Reset()
            {
                Index = 0;
                Current = default!;
            }

            public T Current { get; private set; }

            object? IEnumerator.Current => Current;

            public void Dispose(bool disposing)
            {
                if (Disposed)
                {
                    return;
                }

                if (disposing)
                {
                    Reset();
                }

                Disposed = true;
            }
            public void Dispose()
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
        }
    }

    internal enum InfinityListType
    {
        Unlimited,
        Capped,
        LimitedItems,
        Proportional
    }
}