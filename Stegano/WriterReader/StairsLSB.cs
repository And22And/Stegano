using System.Collections;
using System.Drawing;

namespace Stegano.WriterReader
{
    class StairsLSB : ModuleWriterReader
    {

        private string[] parameters = { "red", "green", "blue"};
        private string[] colors;

        public override int BitsPerPixel()
        {
            return 6;
        }

        public override BitArray ColorRead(Color color)
        {
            BitArray array = new BitArray(BitsPerPixel());
            int number = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == parameters[0])
                {
                    BitByte.writeBitArray(array, number, color.R, i+1);
                }
                if (colors[i] == parameters[1])
                {
                    BitByte.writeBitArray(array, number, color.G, i + 1);
                }
                if (colors[i] == parameters[2])
                {
                    BitByte.writeBitArray(array, number, color.B, i + 1);
                }
                number += i + 1;
            }
            return array;
        }

        public override Color ColorWrite(BitArray data, int position, Color color)
        {
            byte red = color.R;
            byte green = color.G;
            byte blue = color.B;
            int number = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if(colors[i] == parameters[0])
                {
                    red = (byte)(color.R / BitByte.powerOfTwo(i+1) * BitByte.powerOfTwo(i + 1) + BitByte.BitsToByte(data, position + number, i + 1));
                }
                if (colors[i] == parameters[1])
                {
                    green = (byte)(color.G / BitByte.powerOfTwo(i + 1) * BitByte.powerOfTwo(i + 1) + BitByte.BitsToByte(data, position + number, i + 1));
                }
                if (colors[i] == parameters[2])
                {
                    blue = (byte)(color.B / BitByte.powerOfTwo(i + 1) * BitByte.powerOfTwo(i + 1) + BitByte.BitsToByte(data, position + number, i + 1));
                }
                number += i + 1;
            }
            return Color.FromArgb(red, green, blue);
        }

        public override string[] AllParameters()
        {
            return ParametersGenerator.OrderCombination(parameters);
        }

        public override void ParametersReader(string parameters)
        {
            colors = parameters.Split(' ');
        }

        public override string HintString()
        {
            return "Order of colors wich will contain 1, 2 and 3 bits of information";
        }

        public override bool HasParameters()
        {
            return true;
        }
    }
}
