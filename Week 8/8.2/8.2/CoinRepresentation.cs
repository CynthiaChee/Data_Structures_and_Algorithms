using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace CoinRepresentation
{
    public class CoinRepresentation
    {
        // stores cache in a hashtable
        private static Hashtable memory = new Hashtable();

        public static long Solve(long sum)
        {
            if (sum < 0) return 0;  // value exceeded, invalid tree
            if (sum == 0) return 1; // complete combination found

            //If a key for the sum has not been added into the hashtable (i.e. solution not found yet)
            if (!memory.ContainsKey(sum))
            {
                // Breaks into smaller subproblems, also considers odd subproblems to include the 1s in the coin possibilities
                if (sum % 2 == 0)
                {
                    memory.Add(sum, Solve(sum / 2) + Solve(sum / 2 - 1));
                }
                else
                {
                    memory.Add(sum, Solve((sum - 1) / 2));
                }
            }

            //returns the solution which is stored in memory[sum]
            return Convert.ToInt64(memory[sum]);
        }

    }
}