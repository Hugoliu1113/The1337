using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The1337
{
    internal class ScratchPaper
    {
        public int ParerLength { get { return VariableArray.Length; } }

        public float[] VariableArray { get; set; }

        public string[] BlankPlenses { get; set; }


        public ScratchPaper() { }

        public ScratchPaper(float[] floats)
        {
            VariableArray = floats;
            BlankPlenses = new string[floats.Length];

            for (int i = 0; i < floats.Length; i++)
            {
                BlankPlenses[i] = floats[i].ToString();
            }
        }

    }
}
