using System;
using System.Collections.Generic;

namespace Missing_Ranges
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 5, 9, 11 };
            Console.WriteLine(string.Join("\n",FindMissingRanges(nums, 1, 10)));
        }

        static IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            IList<string> result = new List<string>();
            int next = lower;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < lower) continue;
                if (nums[i] == lower)
                {
                    next++;
                    continue;
                }

                result.Add(AddRange(next, nums[i] - 1));
                next = nums[i] + 1;
            }

            if (next <= upper) result.Add(AddRange(next, upper));
            return result;
        }

        static string AddRange(int n1, int n2)
        {
            return n1 == n2 ? n1.ToString() : string.Format("{0}->{1}", n1, n2);
        }
    }
}
