using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    class BubbleSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int i, j;
            K temp;
            bool swapped;
            for (i = 0; i < sequence.Length - 1; i++)
            {
                swapped = false;
                for (j = 0; j < sequence.Length - i - 1; j++)
                {
                    //compares two adjacent elements and swaps them if right element smaller than left one
                    if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        temp = sequence[j];
                        sequence[j] = sequence[j + 1];
                        sequence[j + 1] = temp;
                        swapped = true;
                    }
                }
                //if passes through whole array without swapping, then array is sorted
                if (swapped == false)
                    break;
            }
        }
    }
}
