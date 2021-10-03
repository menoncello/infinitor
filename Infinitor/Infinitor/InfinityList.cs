using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor
{
    public abstract class InfinityList<T> : IReadOnlyList<T>, ICollection<T>
    {
        protected T[] RandomItems { get; }
        protected int LimitItems { get; }

        protected InfinityList(IEnumerable<T>? randomItems = null, int limitItems = int.MaxValue)
        {
            LimitItems = limitItems;
            RandomItems = randomItems?.ToArray() ?? Array.Empty<T>();
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

        protected abstract T GetGeneratedItem(int index);

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