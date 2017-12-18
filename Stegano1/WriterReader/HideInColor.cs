using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stegano.WriterReader
{
    class HideInColor : ContainerWriterReader
    {
        private int numberOfBit;
        private string hideColor;
        private string[][] parameters;

        public HideInColor()
        {
            parameters = new string[2][];
            parameters[0] = new string[3];
            parameters[0][0] = "r";
            parameters[0][1] = "b";
            parameters[0][2] = "g";
            parameters[1] = new string[4];
            parameters[1][0] = "1";
            parameters[1][1] = "2";
            parameters[1][2] = "3";
            parameters[1][3] = "4";
        }

        public override int BitsPerCell()
        {
            return numberOfBit;
        }

        public override Color ColorWrite(BitArray data, int position, Color color)
        {
            byte red = color.R;
            byte green = color.G;
            byte blue = color.B;
            if (hideColor.Equals("r"))
            {
                red = (byte)(red / BitByte.powerOfTwo(numberOfBit) * BitByte.powerOfTwo(numberOfBit) + BitByte.BitsToByte(data, position, numberOfBit));
            }
            if (hideColor.Equals("g"))
            {
                green = (byte)(green / BitByte.powerOfTwo(numberOfBit) * BitByte.powerOfTwo(numberOfBit) + BitByte.BitsToByte(data, position, numberOfBit));
            }
            if (hideColor.Equals("b"))
            {
                blue = (byte)(blue / BitByte.powerOfTwo(numberOfBit) * BitByte.powerOfTwo(numberOfBit) + BitByte.BitsToByte(data, position, numberOfBit));
            }
            return Color.FromArgb(red, green, blue);
        }

        public override BitArray ColorRead(Color color)
        {
            BitArray array = new BitArray(BitsPerCell());
            if (hideColor.Equals("r"))
            {
                BitByte.writeBitArray(array, 0, color.R, numberOfBit);
            }
            if (hideColor.Equals("g"))
            {
                BitByte.writeBitArray(array, 0, color.G, numberOfBit);
            }
            if (hideColor.Equals("b"))
            {
                BitByte.writeBitArray(array, 0, color.B, numberOfBit);
            }
            return array;
        }

        public override void ParametersReader(string parameters)
        {
            string[] param = parameters.Split(' ');
            hideColor = param[0];
            numberOfBit = Convert.ToInt32(param[1]);
        }

        public override string[] AllParameters()
        {
            return ParametersGenerator.ArrayCombination(parameters);
        }

        public override string HintString()
        {
            return "Two parameters: color(r=red, b=blue, g=green) and number of bit(1, 2, 3 and 4)";
        }

        public override bool HasParameters()
        {
            return true;
        }
    }
}
