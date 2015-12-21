
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogik
{
    public delegate int SortArrayDel(int[] left, int[] right);

    public class SortJuggedArray
    {

        public static void SortArrayI(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (comparator.Compare(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }

        }

        public static void SortArrayD(int[][] jaggedArray, SortArrayDel del)
        {
            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (del(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }

        }



        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

    }


}
