using System;
using System.Collections;
using System.Text;

namespace Stegano
{
    class BitByte
    {
        public static int powerOfTwo(int n)
        {
            int power = 1;
            for(int i = 0; i < n; i++)
            {
                power *= 2;
            }
            return power;
        }

        public static BitArray BytesToBits(byte[] bytes)
        {
            BitArray bitArray = new BitArray(bytes.Length * 8);
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bitArray.Set(i * 8 + j, (bytes[i] & (int)Math.Pow(2, 7 - j)) != 0);
                }
            }
            return bitArray;
        }

        public static byte[] BitsToBytes(BitArray bits)
        {
            byte[] bytes = new byte[bits.Length/8];
            for (int i = 0; i < bits.Length/8; i++)
            {
                bytes[i] = 0;
                for (int j = 0; j < 8; j++)
                {
                    bytes[i] += (byte) ((bits.Get(i * 8 + j) ? 1 : 0) * Math.Pow(2, 7 - j));
                }
            }
            return bytes;
        }

        public static byte[] BytesFromString(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        public static string BytesToString(byte[] bytes)
        {
            return Encoding.Unicode.GetString(bytes);            
        }

        public static int IntFromBits(BitArray array) 
        {
            if(array.Length < 32)
            {
                throw new Exception("not enough bit to form int: there " + array.Length + ", but needs 32");
            }
            int result = 0;
            for(int i = 0; i < 32; i++)
            {
                result += (array[31 - i] ? 1 : 0) * (int)Math.Pow(2, i);
            }
            return result;
            //byte[] bytes = BitsToBytes(array);
            //return BitConverter.ToInt32(bytes, 0);
        }

        public static byte[] BytesFromInt(int number)
        {
            byte[] bytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bytes[3 - i] = 0;
                for (int j = 0; j < 8; j++)
                {
                    bytes[3 - i] += (byte)((number / (int)Math.Pow(2, i * 8 + j) % 2) * (int)Math.Pow(2, j));
                }
            }
            return bytes;
        }

        public static BitArray BitsFromInt(int number)
        {
            return BytesToBits(BytesFromInt(number));
        }

        public static byte BitsToByte(BitArray array, int begin, int numberOfBit)
        {
            byte result = 0;
            for (int i = 0; i < numberOfBit; i++)
            {
                if (begin + i < array.Length)
                {
                    result += (byte)((array.Get(begin + i) ? 1 : 0) * BitByte.powerOfTwo(i));
                }
            }
            return result;
        }

        public static void writeBitArray(BitArray array, int position, int color, int numberOfBit)
        {
            for (int i = 0; i < numberOfBit; i++)
            {
                array.Set(position + i, (color / BitByte.powerOfTwo(i)) % 2 == 0 ? false : true);
            }
        }
    }
}
