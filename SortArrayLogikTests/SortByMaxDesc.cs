using SortArrayLogik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogikTests
{
    class SortByMaxDesc : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (FindMaxElem(left) > FindMaxElem(right))
                return 1;
            if (FindMaxElem(left) < FindMaxElem(right))
                return -1;
            else
                return 0;

        }

        public static int FindMaxElem(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}
