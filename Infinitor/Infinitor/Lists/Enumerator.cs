using System;
using System.Collections;
using System.Collections.Generic;

namespace Infinitor
{
    public sealed partial class InfinityList<T>
    {
        [Serializable]
        public record Enumerator : IEnumerator<T>
        {
            private readonly InfinityList<T> list;
            public int Index { get; private set; }
            public bool Disposed { get; private set; }

            public void JumpToIndex(int index) => Current = list[Index = index];

            internal Enumerator(InfinityList<T> list)
            {
                this.list = list;
                Index = 0;
                Current = default!;
            }

            public bool MoveNext()
            {
                if (Index >= list.Count) return false;
                
                Current = list[Index++];
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
                if (disposing) Reset();
                Disposed = true;
            }
            
            public void Dispose()
            {
                Dispose(true);
                // This will break the stryker.net mutator
                // but it is necessary and hard to test
                GC.SuppressFinalize(this);
            }
        }
    }
}