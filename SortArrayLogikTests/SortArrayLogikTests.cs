using NUnit.Framework;
using SortArrayLogik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayLogikTests
{
    delegate int SortArrayDel(int[] left, int[] right);

    class Adapter : ICustomCompare
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
        ICustomCompare sortDesc;
        ICustomCompare sortAsc;
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

            delDesc = new SortArrayDel(sortDesc.Compare);
            delAsc = new SortArrayDel(sortAsc.Compare);
        }


        [Test]
        public void TestArraySortBySum()
        {
            SortJuggedArray.SortArrayI(jaggedArray, sortDesc);
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, sortAsc);
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, new Adapter(delDesc));
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, new Adapter(delAsc));
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

            delDesc = new SortArrayDel(sortDesc.Compare);
            delAsc = new SortArrayDel(sortDesc.Compare);
        }

        [Test]
        public void TestArraySortByMax()
        {
            SortJuggedArray.SortArrayI(jaggedArray, sortDesc);
            CollectionAssert.AreEqual(jaggedArrayDesc, jaggedArray);
            SortJuggedArray.SortArrayI(jaggedArray, sortAsc);
            CollectionAssert.AreEqual(jaggedArrayAsc, jaggedArray);
        }


    }

}
