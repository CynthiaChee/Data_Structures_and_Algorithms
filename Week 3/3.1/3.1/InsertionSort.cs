using System;
using System.Collections.Generic;

namespace Vector
{
    class InsertionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            for (int i = 1; i < sequence.Length; ++i)
            {
                K key = sequence[i];
                int j = i - 1;

                //shifts elements larger than key to the right
                while (j >= 0 && (comparer.Compare(sequence[j], key) > 0))
                {
                    sequence[j + 1] = sequence[j];
                    j--;
                }
                //places value of key in the correct position
                sequence[j + 1] = key;
            }
        }
    }
}
