using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {
        //Calculates Cindy's coins based on Alex's maximum possible amount of coins, then calculate the difference
        public static int Solve(int[] boxes)
        {
            int sum = Sum(boxes);
            int alexCoins = AlexCoins(boxes);
            int cindyCoins = sum - alexCoins;
            return alexCoins - cindyCoins;
        }

        //Obtains total sum of coins in the box
        public static int Sum(int[] boxes)
        {
            int sum = 0;
            foreach (int item in boxes)
            {
                sum += item;
            }
            return sum;
        }

        //Obtains the maximum number of coins Alex can get
        //This function breaks down the problem into smaller subproblems and creates a table which stores the solutions to the subproblems
        //the subproblems
        //gap increments to different starting positions in the table
        //i and j are pointers to rows and columns in the table
        //x, y and z are pointers to sums or solutions to the subproblems
        public static int AlexCoins(int[] boxes)
        {
            int n = boxes.Length;
            int[,] table = new int[n, n];
            int gap, i, j, x, y, z;

            for (gap = 0; gap < n; gap++)
            {
                for (i = 0, j = gap; j < n; ++i, ++j)
                {
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0;
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0;
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0;

                    table[i, j] = Math.Max(boxes[i] + Math.Min(x, y), boxes[j] + Math.Min(y, z));
                }
            }
            return table[0, n - 1]; //the maximum value that can be obtained by Alex
        }

        //Time complexity is O(n^2)
        //Space complexity is also O(n^2) since a table is constructed to store states
    }
}
