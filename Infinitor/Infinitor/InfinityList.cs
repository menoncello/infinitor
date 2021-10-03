using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor
{
    public abstract class InfinityList<T> : IReadOnlyList<T>, ICollection<T>
    {
        private T[] RandomItems { get; }
        private ProportionalItem<T>[] Proportional { get; }
        protected int LimitItems { get; }
        private readonly int proportionalTotal;

        protected InfinityList(IEnumerable<ProportionalItem<T>>? proportional = null,
            IEnumerable<T>? randomItems = null, int limitItems = int.MaxValue)
        {
            Proportional = proportional?.ToArray() ?? Array.Empty<ProportionalItem<T>>();
            LimitItems = limitItems;
            RandomItems = randomItems?.ToArray() ?? Array.Empty<T>();
            proportionalTotal = Proportional.Sum(x => x.FullIntChance);
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

        public int Count => int.MaxValue;
        public bool IsReadOnly => true;

        public T this[int index] => GetGeneratedItem(index);

        private T GetGeneratedItem(int index)
        {
            var rnd = new Random(index);
            
            var value = rnd.Next();

            if (RandomItems.Any())
            {
                var max = Math.Min(RandomItems.Length, LimitItems);
                return RandomItems[value % max];
            }
            if (Proportional.Any())
            {
                var chance = value % proportionalTotal;
                var selected = default(T);

                foreach (var item in Proportional)
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

            return GetGeneratedCustomItem(value);
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
}