using System;
using System.Collections;
using System.Drawing;

namespace Stegano.WriterReader
{
    class LeastSignificantBit : ContainerWriterReader
    {
        
        private int numberOfBit;
        private byte twoPower;

        public LeastSignificantBit()
        {
        }

        public LeastSignificantBit(int numberOfBit)
        {
            if (numberOfBit > 0 && numberOfBit < 5)
            {
                this.numberOfBit = numberOfBit;
                twoPower = (byte)BitByte.powerOfTwo(numberOfBit);
            } else
            {
                throw new Exception("Wrong number of least significant bit");
            }
        } 

        public override int BitsPerCell()
        {
            return numberOfBit * 3; //red, blue and green
        }

        public override Color ColorWrite(BitArray data, int position, Color color)
        {
            byte red = (byte)(color.R / twoPower * twoPower + BitsToByte(data, position));
            byte green = (byte)(color.G / twoPower * twoPower + BitsToByte(data, position + numberOfBit));
            byte blue = (byte)(color.B / twoPower * twoPower + BitsToByte(data, position + 2 * numberOfBit));
            return Color.FromArgb(red, green, blue);
        }

        private byte BitsToByte(BitArray array, int begin)
        {
            byte result = 0;
            for (int i = 0; i < numberOfBit; i++)
            {
                if (begin + i < array.Length)
                {
                    result += (byte)((array.Get(begin +  i) ? 1 : 0) * BitByte.powerOfTwo(i));
                }
            }
            return result;
        }

        public override BitArray ColorRead(Color color)
        {
            BitArray array = new BitArray(BitsPerCell());
            writeBitArray(array, 0, color.R);
            writeBitArray(array, numberOfBit, color.G);
            writeBitArray(array, numberOfBit * 2, color.B);
            return array;
        }

        public void writeBitArray(BitArray array, int position, int color)
        {
            for(int i = 0; i < numberOfBit; i++)
            {
                array.Set(position + i, (color / BitByte.powerOfTwo(i)) % 2 == 0 ? false : true);
            }
        }

        public override string StandartParameters()
        {
            return "1";
        }

        public override bool ParametersReader(string parameters)
        {
            if(parameters.Trim().Equals("1") || parameters.Trim().Equals("2") || 
                parameters.Trim().Equals("3") || parameters.Trim().Equals("4"))
            {
                int bits = Convert.ToInt32(parameters.Trim());
                numberOfBit = bits;
                twoPower = (byte)BitByte.powerOfTwo(numberOfBit);
                return true;
            }
            return false;
        }

        public override string HintString()
        {
            return "Number of bits in pixel to hide information(can be set to 1, 2, 3 or 4)";
        }
    }
}
