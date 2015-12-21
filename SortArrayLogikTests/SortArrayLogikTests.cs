using NUnit.Framework;
using SortArrayLogik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogikTests
{

    class Adapter : IComparer<int[]>
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

    [TestFixture]
    public class SortArrayITest
    {
        int[][] jaggedArray;
        int[][] jaggedArrayDesc;
        int[][] jaggedArrayAsc;
        IComparer<int[]> sortDesc;
        IComparer<int[]> sortAsc;
        SortArrayDel delDesc;
        SortArrayDel delAsc;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            jaggedArray = new int[4][];
            jaggedArray[0] = new int[] { 1, 0, 1000 };
            jaggedArray[1] = new int[] { 25, 5 };
            jaggedArray[2] = new int[] { 11, 22 };
            jaggedArray[3] = new int[] { 15, -2, 20000 };
        }


        [SetUp]
        public void SetUpSortBySum()
        {


            jaggedArrayDesc = new int[4][];
            jaggedArrayDesc[0] = new int[] { 15, -2, 20000 };
            jaggedArrayDesc[1] = new int[] { 1, 0, 1000 };
            jaggedArrayDesc[2] = new int[] { 11, 22 };
            jaggedArrayDesc[3] = new int[] { 25, 5 };

            jaggedArrayAsc = new int[4][];
            jaggedArrayAsc[3] = new int[] { 15, -2, 20000 };
            jaggedArrayAsc[2] = new int[] { 1, 0, 1000 };
            jaggedArrayAsc[1] = new int[] { 11, 22 };
            jaggedArrayAsc[0] = new int[] { 25, 5 };

            sortDesc = new SortBySumDesc();
            sortAsc = new SortBySumAsc();

        }


        [Test]
        public void TestArraySortBySum()
        {
            SortJuggedArray.SortArrayI(jaggedArray, sortDesc);
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, sortAsc);
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);


        }


        [SetUp]
        public void SetUpSortByMax()
        {

            jaggedArrayDesc = new int[4][];
            jaggedArrayDesc[0] = new int[] { 15, -2, 20000 };
            jaggedArrayDesc[1] = new int[] { 1, 0, 1000 };
            jaggedArrayDesc[2] = new int[] { 25, 5 };
            jaggedArrayDesc[3] = new int[] { 11, 22 };

            jaggedArrayAsc = new int[4][];
            jaggedArrayAsc[3] = new int[] { 15, -2, 20000 };
            jaggedArrayAsc[2] = new int[] { 1, 0, 1000 };
            jaggedArrayAsc[1] = new int[] { 25, 5 };
            jaggedArrayAsc[0] = new int[] { 11, 22 };


            sortDesc = new SortByMaxDesc();
            sortAsc = new SortByMaxAsc();

        }

        [Test]
        public void TestArraySortByMax()
        {
            SortJuggedArray.SortArrayI(jaggedArray, sortDesc);
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, sortAsc);
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);
        }


        [SetUp]
        public void SetUpSortBySumDel()
        {


            jaggedArrayDesc = new int[4][];
            jaggedArrayDesc[0] = new int[] { 15, -2, 20000 };
            jaggedArrayDesc[1] = new int[] { 1, 0, 1000 };
            jaggedArrayDesc[2] = new int[] { 11, 22 };
            jaggedArrayDesc[3] = new int[] { 25, 5 };

            jaggedArrayAsc = new int[4][];
            jaggedArrayAsc[3] = new int[] { 15, -2, 20000 };
            jaggedArrayAsc[2] = new int[] { 1, 0, 1000 };
            jaggedArrayAsc[1] = new int[] { 11, 22 };
            jaggedArrayAsc[0] = new int[] { 25, 5 };

            sortDesc = new SortBySumDesc();
            sortAsc = new SortBySumAsc();

            delDesc = new SortArrayDel(sortDesc.Compare);
            delAsc = new SortArrayDel(sortAsc.Compare);
        }


        [Test]
        public void TestArraySortBySumDel()
        {
            SortJuggedArray.SortArrayI(jaggedArray, new Adapter(delDesc));
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, new Adapter(delAsc));
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);

        }


        [SetUp]
        public void SetUpSortByMaxDel()
        {

            jaggedArrayDesc = new int[4][];
            jaggedArrayDesc[0] = new int[] { 15, -2, 20000 };
            jaggedArrayDesc[1] = new int[] { 1, 0, 1000 };
            jaggedArrayDesc[2] = new int[] { 25, 5 };
            jaggedArrayDesc[3] = new int[] { 11, 22 };

            jaggedArrayAsc = new int[4][];
            jaggedArrayAsc[3] = new int[] { 15, -2, 20000 };
            jaggedArrayAsc[2] = new int[] { 1, 0, 1000 };
            jaggedArrayAsc[1] = new int[] { 25, 5 };
            jaggedArrayAsc[0] = new int[] { 11, 22 };


            sortDesc = new SortByMaxDesc();
            sortAsc = new SortByMaxAsc();

            delDesc = new SortArrayDel(sortDesc.Compare);
            delAsc = new SortArrayDel(sortAsc.Compare);
        }

        [Test]
        public void TestArraySortByMaxDel()
        {
            SortJuggedArray.SortArrayI(jaggedArray, new Adapter(delDesc));
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, new Adapter(delAsc));
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);
        }

        [SetUp]
        public void SetUpSortBySumDelegateInterfaca()
        {


            jaggedArrayDesc = new int[4][];
            jaggedArrayDesc[0] = new int[] { 15, -2, 20000 };
            jaggedArrayDesc[1] = new int[] { 1, 0, 1000 };
            jaggedArrayDesc[2] = new int[] { 11, 22 };
            jaggedArrayDesc[3] = new int[] { 25, 5 };

            jaggedArrayAsc = new int[4][];
            jaggedArrayAsc[3] = new int[] { 15, -2, 20000 };
            jaggedArrayAsc[2] = new int[] { 1, 0, 1000 };
            jaggedArrayAsc[1] = new int[] { 11, 22 };
            jaggedArrayAsc[0] = new int[] { 25, 5 };

            sortDesc = new SortBySumDesc();
            sortAsc = new SortBySumAsc();

        }


        [Test]
        public void TestArraySortBySumDelegateInterfaca()
        {
            SortJuggedArray.SortArrayD(jaggedArray, sortDesc.Compare);
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayD(jaggedArray, sortAsc.Compare);
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);


        }

        [SetUp]
        public void SetUpSortBySumDelegate()
        {


            jaggedArrayDesc = new int[4][];
            jaggedArrayDesc[0] = new int[] { 15, -2, 20000 };
            jaggedArrayDesc[1] = new int[] { 1, 0, 1000 };
            jaggedArrayDesc[2] = new int[] { 11, 22 };
            jaggedArrayDesc[3] = new int[] { 25, 5 };

            jaggedArrayAsc = new int[4][];
            jaggedArrayAsc[3] = new int[] { 15, -2, 20000 };
            jaggedArrayAsc[2] = new int[] { 1, 0, 1000 };
            jaggedArrayAsc[1] = new int[] { 11, 22 };
            jaggedArrayAsc[0] = new int[] { 25, 5 };

            sortDesc = new SortBySumDesc();
            sortAsc = new SortBySumAsc();

            delAsc = new SortArrayDel(sortAsc.Compare);
            delDesc = new SortArrayDel(sortDesc.Compare);

        }


        [Test]
        public void TestArraySortBySumDelegate()
        {
            SortJuggedArray.SortArrayD(jaggedArray, delDesc);
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayD(jaggedArray, delAsc);
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);


        }


    }

}
