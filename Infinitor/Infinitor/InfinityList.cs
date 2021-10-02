using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infinitor
{
    public abstract class InfinityList<T> : IReadOnlyList<T>
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

        public int Count => int.MaxValue;

        public T this[int index] => GetGeneratedItem(index);

        protected abstract T GetGeneratedItem(int index);

        [Serializable]
        public record Enumerator : IEnumerator<T>
        {
            private readonly InfinityList<T> list;
            private int index;
            private bool disposed;

            internal Enumerator(InfinityList<T> list)
            {
                this.list = list;
                index = 0;
                Current = default!;
            }

            public bool MoveNext()
            {
                if (index >= list.Count) return false;
                
                Current = list[index];
                index++;
                return true;
            }

            public void Reset()
            {
                index = 0;
                Current = default!;
            }

            public T Current { get; private set; }

            object? IEnumerator.Current => Current;

            public void Dispose(bool disposing)
            {
                if (disposed)
                {
                    return;
                }

                if (disposing)
                {
                    Reset();
                }

                disposed = true;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}