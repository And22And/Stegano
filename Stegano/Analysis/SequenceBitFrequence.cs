using System;
using System.Collections.Generic;

namespace Stegano.Analysis
{
    class SequenceBitFrequence : AnalysisHistogram
    {
        private int numberOfBit;
        private string[] parametrs;

        public SequenceBitFrequence()
        {
            parametrs = new string[4];
            parametrs[0] = "1";
            parametrs[1] = "2";
            parametrs[2] = "3";
            parametrs[3] = "4";
        }

        public void SetNumberOfBit(int number)
        {
            numberOfBit = number;
        }

        public override void SetData()
        {
            int[] sequences = FindNumberOfSequence();
            for(int i = 0; i < sequences.Length; i++)
            {
                List<int> list = new List<int>();
                list.Add(sequences[i]);
                AddColumn(Convert.ToString(i, 2), list);
            }
        }

        public override void SetSeries()
        {
            AddSeries("Number of sequence");
        }

        public int[] FindNumberOfSequence()
        {
            int powerOfTwo = BitByte.powerOfTwo(numberOfBit);
            int[] sequences = new int[powerOfTwo];
            for (int i = 0; i < sequences.Length; i++)
            {
                sequences[i] = 0;
            }
            for (int i = 0; i < GetBitmap().Height; i++)
            {
                for (int j = 1; j < GetBitmap().Width; j++)
                {
                    sequences[(GetBitmap().GetPixel(j, i).R % powerOfTwo)]++;
                    sequences[(GetBitmap().GetPixel(j, i).B % powerOfTwo)]++;
                    sequences[(GetBitmap().GetPixel(j, i).G % powerOfTwo)]++;
                }
            }
            return sequences;
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override string[] AllParameters()
        {
            return parametrs;
        }

        public override void ParametersReader(string parameters)
        {
            SetNumberOfBit(Convert.ToInt32(parameters));
        }

        public override string GetName()
        {
            return "Sequence bit frequence analysis";
        }
    }
}
