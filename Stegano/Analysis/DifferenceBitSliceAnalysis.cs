using System;
using System.Drawing;

namespace Stegano.Analysis
{
    class ReverseBitSliceAnalysis : AnalysisPicture
    {
        private string[] parameters = { "1", "2", "3", "4", "5", "6", "7", "8" };
        private int numberOfBit;

        public override string GetName()
        {
            return "Bit slice difference";
        }

        public override string[] AllParameters()
        {
            return parameters;
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override void ParametersReader(string parameters)
        {
            numberOfBit = Convert.ToInt32(parameters) - 1;
        }

        public override Bitmap CreateAnalysisPicture()
        {
            Bitmap analysisPicture = new Bitmap(GetPicture().Width, GetPicture().Height);
            Color pixel;
            int power2 = BitByte.powerOfTwo(numberOfBit);
            for (int i = 0; i < analysisPicture.Width; i++)
            {
                for (int j = 0; j < analysisPicture.Height; j++)
                {
                    analysisPicture.SetPixel(i, j,
                        Color.FromArgb(
                            GetPicture().GetPixel(i, j).R - ((GetPicture().GetPixel(i, j).R / power2) % 2) * power2,
                            GetPicture().GetPixel(i, j).G - ((GetPicture().GetPixel(i, j).G / power2) % 2) * power2,
                            GetPicture().GetPixel(i, j).B - ((GetPicture().GetPixel(i, j).B / power2) % 2) * power2
                    ));
                }
            }
            return analysisPicture;
        }
    }
}
