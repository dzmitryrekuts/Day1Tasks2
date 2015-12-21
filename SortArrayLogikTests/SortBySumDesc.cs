using SortArrayLogik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogikTests
{
    public class SortBySumDesc : IComparer<int[]>
    {
        public int Compare(int[] left, int[] right)
        {
            if (Summ(left) > Summ(right))
                return 1;
            if (Summ(left) < Summ(right))
                return -1;
            else
                return 0;
        }

        public static int Summ(int[] array)
        {
            int summ = 0;
            for (int i = 0; i < array.Length; i++)
            {
                summ += array[i];
            }
            return summ;
        }
    }
}
