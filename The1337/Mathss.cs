using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The1337
{
    internal class Mathss
    {
        public void Start()
        {
            int[] iQuert = { 1, 2, 3, 4 };
            string[] sQuert = { "1", "2", "3", "4" };
            foreach (var vTuple in MegreArray(sQuert, iQuert))
            {
                Console.WriteLine(vTuple.Item1);
                Console.WriteLine(vTuple.Item2);
            }

        }

        //將陣列兩組兩組方式合併疊加
        public IEnumerable<(string, int)> MegreArray(string[] sArray, int[] iArray)
        {
            if (iArray.Length == 1)
            {
                yield return (sArray[0], iArray[0]);
                yield break;
            }
            for (int j = 0; j < iArray.Length - 1; j++)
            {
                int[] ints = new int[iArray.Length - 1];
                string[] inLog = new string[iArray.Length - 1];
                int index = 0;
                for (int i = 0; i < iArray.Length - 1; i++)
                {
                    if (i == j)
                    {
                        ints[i] = iArray[i] + iArray[i + 1];
                        inLog[i] = "(" + sArray[i] + "+" + sArray[i + 1] + ")";
                        index = 1;
                    }
                    else
                    {
                        ints[i] = iArray[i + index];
                        inLog[i] = sArray[i + index].ToString();
                    }
                }
                foreach (var vTuple in MegreArray(inLog, ints))
                {
                    yield return vTuple;
                }
            }

        }



        //取得陣列所有組合
        public IEnumerable<int[]> GetAllArray(int[] iArray)
        {
            int[] iOneArray = null;

            if (iArray.Length == 1)
            {
                yield return new int[] { iArray[0] };
                yield break;
            }


            for (int i = 0; i < iArray.Length; i++)
            {
                int[] nextArray = GetNextArray(iArray[i], iArray);

                foreach (int[] nArray in GetAllArray(nextArray).ToArray())
                {
                    yield return iOneArray = new int[] { iArray[i] }.Concat(nArray).ToArray();
                }
            }
        }


        //將傳入的陣列扣除傳入的整數
        public int[] GetNextArray(int iTrgat, int[] iArray)
        {
            int[] newArray = new int[iArray.Length - 1];

            int index = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (iArray[i + index] == iTrgat)
                    index += 1;
                if (i + index == iArray.Length)
                    break;
                newArray[i] = iArray[i + index];
            }

            return newArray;
        }


        public IEnumerable<string> Aa(int[] iArray, string sNow)
        {
            if (iArray.Length < 1)
            {
                yield return sNow;
                yield break;
            }
            for (int i = 0; i < iArray.Length; i++)
            {
                int iNow = iArray[i];
                int[] iTemp = new int[iArray.Length - 1];

                int index = 0;
                for (int d = 0; d < iArray.Length - 1; d++)
                {
                    if (d + index == i)
                        index = 1;
                    if (d + index == iArray.Length)
                        break;
                    iTemp[d] = iArray[d + index];
                }

                for (int ii = 0; ii < 2; ii++)
                {
                    //if (iArray.Length == 1 && ii == 1)
                    //    continue;
                    switch (ii)
                    {
                        case 0:
                            string sAnser = "(" + sNow + ") + " + iNow;
                            foreach (string sAns in Aa(iTemp, sAnser))
                            {
                                yield return sAns;
                            }
                            break;

                        case 1:
                            foreach (string sAns in Aa(iTemp, sNow))
                            {
                                yield return "(" + sAns + ") - " + iNow;
                            }
                            break;
                    }
                }
            }
        }
    }
}
