using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArraySolutionTask2
{
    public class SortJuggedArray
    {

        public static void SortBySumm(int[][] jaggedArray, bool option)
        {
            switch (option)
            {

                case true:
                    for (int i = 0; i < jaggedArray.Length - 1; i++)
                    {
                        for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                        {
                            if (Summ(jaggedArray[j]) < Summ(jaggedArray[j + 1]))
                            {
                                Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                            }
                        }
                    }
                    break;


                default:

                    for (int i = 0; i < jaggedArray.Length - 1; i++)
                    {
                        for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                        {
                            if (Summ(jaggedArray[i]) > Summ(jaggedArray[i + 1]))
                            {
                                Swap(ref jaggedArray[i], ref jaggedArray[i + 1]);
                            }
                        }
                    }
                    break;

            }
        }

        public static void SortByMax(int[][] jaggedArray, bool option)
        {

            switch (option)
            {
                case true:
                    for (int i = 0; i < jaggedArray.Length; i++)
                    {

                        for (int j = 0; j < jaggedArray[i].Length; j++)

                            if (FindMaxElem(jaggedArray[j]) < FindMaxElem(jaggedArray[j + 1]))
                            {
                                Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                            }
                    }
                    break;


                default:

                    for (int i = 0; i < jaggedArray.Length; i++)
                    {

                        for (int j = 0; j < jaggedArray[i].Length; j++)

                            if (FindMaxElem(jaggedArray[j]) > FindMaxElem(jaggedArray[j + 1]))
                            {
                                Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                            }
                    }
                    break;

            }
        }

        public static void SortByMin(int[][] jaggedArray, bool option)
        {

            switch (option)
            {
                case true:
                    for (int i = 0; i < jaggedArray.Length; i++)
                    {

                        for (int j = 0; j < jaggedArray[i].Length; j++)

                            if (FindMinElem(jaggedArray[j]) < FindMinElem(jaggedArray[j + 1]))
                            {
                                Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                            }
                    }

                    break;

                default:

                    for (int i = 0; i < jaggedArray.Length; i++)
                    {

                        for (int j = 0; j < jaggedArray[i].Length; j++)

                            if (FindMinElem(jaggedArray[j]) > FindMinElem(jaggedArray[j + 1]))
                            {
                                Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                            }
                    }

                    break;
            }
        }

        public static int Summ(int[] array)
        {
            int summ = 0;
            for (int i = 0; i < array.Length; i++)
            {
                summ += i;
            }

            return summ;
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

        public static int FindMinElem(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        public static void PrintMatrix(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
