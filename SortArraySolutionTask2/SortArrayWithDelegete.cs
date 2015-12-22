using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogik
{


    public class SortArrayWithDelegete
    {
        public static void SortArrayD(int[][] jaggedArray, SortArrayDel del)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j] == null || jaggedArray[j + 1] == null)
                    {
                        throw new ArgumentNullException();
                    }
                    if (del(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }

        }

        public static void SortArrayD(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            SortArrayD(jaggedArray, comparator.Compare);
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
    }
}
