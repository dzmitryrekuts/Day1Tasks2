
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogik
{
    public delegate int SortArrayDel(int[] left, int[] right);

    public class SortArrayWithInterface
    {

        public static void SortArrayI(int[][] jaggedArray, IComparer<int[]> comparator)
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

                    if (comparator.Compare(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }

        }

        public static void SortArrayI(int[][] jaggedArray, SortArrayDel del)
        {
            SortArrayI(jaggedArray, new Adapter(del));
        }


        private class Adapter : IComparer<int[]>
        {
            SortArrayDel del;

            public Adapter(SortArrayDel del)
            {
                this.del = del;
            }


            public int Compare(int[] left, int[] right)
            {
                return del(left, right);
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
