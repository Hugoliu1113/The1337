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
            foreach (float[] f in GetAllArray(new float[] { 1, 3, 3, 7 }))
            {
                ScratchPaper scratchPaper = new ScratchPaper(f);

                foreach (var vTuple in MegreArray(scratchPaper))
                {
                    if (vTuple.VariableArray[0] == 10)
                    {
                        Console.WriteLine(vTuple.BlankPlenses[0]);
                        Console.WriteLine(vTuple.VariableArray[0]);
                    }
                }
            }

        }

        //將陣列兩組兩組方式合併疊加
        public IEnumerable<ScratchPaper> MegreArray(ScratchPaper iscratchPager)
        {
            if (iscratchPager.ParerLength == 1)
            {
                yield return iscratchPager;
                yield break;
            }
            foreach (char mark in new char[] { '+', '-', '*', '/' })
            {
                for (int j = 0; j < iscratchPager.ParerLength - 1; j++)
                {
                    ScratchPaper blankPaper = new ScratchPaper();
                    blankPaper.VariableArray = new float[iscratchPager.ParerLength - 1];
                    blankPaper.BlankPlenses = new string[iscratchPager.ParerLength - 1];

                    int index = 0;
                    for (int i = 0; i < iscratchPager.ParerLength - 1; i++)
                    {
                        if (i == j)
                        {
                            float x1 = iscratchPager.VariableArray[i];
                            float x2 = iscratchPager.VariableArray[i + 1];
                            string s1 = iscratchPager.BlankPlenses[i];
                            string s2 = iscratchPager.BlankPlenses[i + 1];

                            switch (mark)
                            {
                                case '+':
                                    blankPaper.VariableArray[i] = x1 + x2;
                                    blankPaper.BlankPlenses[i] = s1 + "+" + s2;
                                    break;

                                case '-':
                                    blankPaper.VariableArray[i] = x1 - x2;
                                    blankPaper.BlankPlenses[i] = s1 + "-" + s2;
                                    break;

                                case '*':
                                    if (!int.TryParse(s1, out _))
                                        s1 = "(" + s1 + ")";
                                    if (!int.TryParse(s2, out _))
                                        s2 = "(" + s2 + ")";
                                    blankPaper.VariableArray[i] = x1 * x2;
                                    blankPaper.BlankPlenses[i] = s1 + "*" + s2;
                                    break;

                                case '/':
                                    if (!int.TryParse(s1, out _))
                                        s1 = "(" + s1 + ")";
                                    if (!int.TryParse(s2, out _))
                                        s2 = "(" + s2 + ")";
                                    blankPaper.VariableArray[i] = x1 / x2;
                                    blankPaper.BlankPlenses[i] = s1 + "/" + s2;
                                    break;
                            }

                            index = 1;
                        }
                        else
                        {
                            float x1 = iscratchPager.VariableArray[i + index];
                            string s1 = iscratchPager.BlankPlenses[i + index];
                            blankPaper.VariableArray[i] = x1;
                            blankPaper.BlankPlenses[i] = s1;
                        }
                    }
                    foreach (var vTuple in MegreArray(blankPaper))
                    {
                        yield return vTuple;
                    }
                }
            }
        }

        //取得陣列所有組合
        public IEnumerable<float[]> GetAllArray(float[] iArray)
        {

            if (iArray.Length == 1)
            {
                yield return new float[] { iArray[0] };
                yield break;
            }


            for (int i = 0; i < iArray.Length; i++)
            {
                float[] nextArray = GetNextArray(iArray[i], iArray);

                foreach (float[] nArray in GetAllArray(nextArray).ToArray())
                {
                    yield return new float[] { iArray[i] }.Concat(nArray).ToArray();
                }
            }
        }

        //將傳入的陣列扣除傳入的整數
        public float[] GetNextArray(float iTrgat, float[] iArray)
        {
            float[] newArray = new float[iArray.Length - 1];

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
