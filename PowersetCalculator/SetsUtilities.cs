using System;
using System.Collections.Generic;
using System.Linq;

namespace PowersetCalculator
{
    /// <summary>
    ///     This class contains methods for performing various sets operations
    /// </summary>
    public static class SetsUtilities
    {
        /// <summary>
        ///     Returns all the possible combinations for a given set.
        /// </summary>
        /// <param name="set">The input set</param>
        /// <returns></returns>
        public static IEnumerable<int[]> Powerset(int[] set)
        {
            return Enumerable.Range(0, set.Length + 1).SelectMany(k => Combinations(set, k)).ToList();
        }

        /// <summary>
        ///     Lazily returns the different combinations (without repetition)
        ///     This assumes the set contains distinct values, as the combination calculation
        ///     is based on the indices, not the actual values.
        ///     For instance, all combinations of 2 items in {1,1,2} will return
        ///     {1,1} {1,2} and {1,2}
        ///
        ///     This algorithm has a O(n!) complexity in time.
        /// </summary>
        /// <param name="set">The input set</param>
        /// <param name="k">The number of elements</param>
        /// <returns></returns>
        public static IEnumerable<int[]> Combinations(int[] set, int k)
        {
            var n = set.Length;
            if (k > n)
            {
                throw new ArgumentOutOfRangeException(nameof(k));
            }

            var indices = Enumerable.Range(0, k).ToArray();

            var subsets = new List<int[]>();
            //subsets.Add(set.Subset(indices));
            yield return set.Subset(indices);

            ///var done = false;
            while (true)
            {
                //Find the next index to update, starting from the 
                var indexToIncrement = 0;
                var done = true;
                for (indexToIncrement = k - 1; indexToIncrement >= 0; indexToIncrement--)
                {
                    //done = true;
                    if (indices[indexToIncrement] != indexToIncrement + n - k)
                    {
                        done = false;
                        break;
                    }
                }

                if (done) break; //didn't find index to increment

                indices[indexToIncrement] += 1;

                //Increment the indices above, if need be
                for (var i = indexToIncrement + 1; i < k; i++)
                {
                    indices[i] = indices[i - 1] + 1;
                }

                yield return set.Subset(indices);
                //subsets.Add(set.Subset(indices));
            }

            //return subsets;
        }

        /// <summary>
        ///     Returns a subset of the set at the given indices
        /// </summary>
        /// <param name="set">The input set</param>
        /// <param name="indices">The indices</param>
        /// <returns></returns>
        public static int[] Subset(this int[] set, int[] indices)
        {
            var subset = new int[indices.Length];
            var count = 0;
            foreach (var index in indices)
            {
                subset[count] = set[index];
                count++;
            }

            return subset;
        }
    }
}