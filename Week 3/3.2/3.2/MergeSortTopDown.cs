using System;
using System.Collections.Generic;

namespace Vector
{
    class MergeSortTopDown : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence.Length < 2) return;
            int middle = sequence.Length/2;
            K[] left = sequence[0..middle];         //splitting the arrays into 2
            K[] right = sequence[middle..sequence.Length];

            Sort(left, comparer);
            Sort(right, comparer);
            Merge(left, right, sequence, comparer);
        }

        public void Merge<K>(K[] left, K[] right, K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = 0, j = 0;
            while (i + j < sequence.Length)
            {
                //places the smaller value into the first index of the merged array
                if (j == right.Length || (i < left.Length && comparer.Compare(left[i], right[j]) < 0))
                {
                    sequence[i+j] = left[i++];
                }
                else
                {
                    sequence[i+j] = right[j++];
                }
            }
        }
    }
}
