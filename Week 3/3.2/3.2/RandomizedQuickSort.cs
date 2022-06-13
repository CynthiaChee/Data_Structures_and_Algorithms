using System;
using System.Collections.Generic;

namespace Vector
{
    class RandomizedQuickSort : ISorter
    {
        Random rand = new Random();
        private int RandPivot(int a, int b)
        {
            return rand.Next(a, b);         //selects a random pivot
        }

        public void Swap<K>(K[] sequence, int a, int b)
        {
            K temp = sequence[a];
            sequence[a] = sequence[b];
            sequence[b] = temp;
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            Sort(sequence, comparer, 0, sequence.Length - 1);
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer, int a, int b) where K : IComparable<K>
        {
            if (a >= b) { return; }
            int left = a;
            int right = b - 1;
            Swap(sequence, RandPivot(a, b), b); //move pivot to the rightmost position
            K pivot = sequence[b];

            while (left <= right)
            {
                while (left <= right && (comparer.Compare(sequence[left], pivot) < 0)) left++;  //if left < pivot
                while (left <= right && (comparer.Compare(sequence[right], pivot) > 0)) right--; //if right > pivot
                if (left <= right)  //swap values less than pivot to left, greater than pivot to right
                {
                    Swap(sequence, left, right);
                    left++;
                    right--;
                }
            }
            Swap(sequence, left, b);    //places pivot into correct position
            Sort(sequence, comparer, a, left - 1);  //separates array into two with pivot as separating point, then repeat process
            Sort(sequence, comparer, left + 1, b);
        }


    }
}
