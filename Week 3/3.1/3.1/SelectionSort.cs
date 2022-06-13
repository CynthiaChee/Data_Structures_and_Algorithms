using System;
using System.Collections.Generic;

namespace Vector
{
    class SelectionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (comparer.Compare(sequence[j], sequence[min_idx]) < 0)
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                K temp = sequence[min_idx];
                sequence[min_idx] = sequence[i];
                sequence[i] = temp;
            }
        }
    }
}
