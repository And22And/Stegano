using System;
using System.Collections;
using System.Drawing;

namespace Stegano.WriterReader
{
    class LeastSignificantBit : ContainerWriterReader
    {
        
        private int numberOfBit;
        private byte twoPower;
        private string[] parameters = {"1", "2", "3", "4"};

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
            byte red = (byte)(color.R / twoPower * twoPower + BitByte.BitsToByte(data, position, numberOfBit));
            byte green = (byte)(color.G / twoPower * twoPower + BitByte.BitsToByte(data, position + numberOfBit, numberOfBit));
            byte blue = (byte)(color.B / twoPower * twoPower + BitByte.BitsToByte(data, position + 2 * numberOfBit, numberOfBit));
            return Color.FromArgb(red, green, blue);
        }

        

        public override BitArray ColorRead(Color color)
        {
            BitArray array = new BitArray(BitsPerCell());
            BitByte.writeBitArray(array, 0, color.R, numberOfBit);
            BitByte.writeBitArray(array, numberOfBit, color.G, numberOfBit);
            BitByte.writeBitArray(array, numberOfBit * 2, color.B, numberOfBit);
            return array;
        }

        public override string[] AllParameters()
        {
            return parameters;
        }

        public override void ParametersReader(string parameters)
        {
           numberOfBit = Convert.ToInt32(parameters.Trim());
           twoPower = (byte)BitByte.powerOfTwo(numberOfBit);
        }

        public override string HintString()
        {
            return "Number of bits in pixel to hide information(can be set to 1, 2, 3 or 4)";
        }

        public override bool HasParameters()
        {
            return true;
        }
    }
}
