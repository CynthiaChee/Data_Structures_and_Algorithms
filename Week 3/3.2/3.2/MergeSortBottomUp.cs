using System;
using System.Collections.Generic;

namespace Vector
{
    class MergeSortBottomUp : ISorter
    {
        public void Merge<K>(K[] one, K[] two, K[] sequence, IComparer<K> comparer, int start, int inc) where K : IComparable<K>
        {
            //iterative approach to merge sort. end1 and end2 limit the elements for comparison, similar to if the array is split

            //end1 = boundary for run 1; end2 = boundary for run 2
            int end1 = Math.Min(start + inc, one.Length);
            int end2 = Math.Min(start + 2 * inc, one.Length);
            int x = start;          //index into run 1
            int y = start + inc;    //index into run 2
            int z = start;          //index into output

            while(x < end1 && y < end2)
            {
                if (comparer.Compare(one[x], one[y]) < 0)
                {
                    two[z++] = one[x++];
                }
                else
                {
                    two[z++] = one[y++];
                }
            }

            //copies any additional values
            if(x < end1)
            {
                Array.Copy(one, x, two, z, end1 - x);
            }
            else if(y < end2)
            {
                Array.Copy(one, y, two, z, end2 - y);
            }
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            K[] source = sequence;
            K[] dest = new K[sequence.Length];
            K[] temp;

            //iterate through the whole array
            for (int i=1; i<sequence.Length; i*=2)      
            {
                for(int j=0; j<sequence.Length; j+=2*i)         //each pass merges two runs of length i
                {
                    Merge(source, dest, sequence, comparer, j, i);
                }
                temp = source;          //reverse the roles of the arrays
                source = dest;
                dest = temp;
            }

            if(sequence != source)
            {
                Array.Copy(source, 0, sequence, 0, sequence.Length);        //additional copy to get result to original
            }
        }
    }
}
