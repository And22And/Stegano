using Stegano.Block;
using Stegano.Order;
using Stegano.Position;
using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Stegano.WriterReader
{
    abstract class ModuleWriterReader : GUI
    {
        public ModulePosition position;

        public abstract int BitsPerPixel();

        public abstract BitArray ColorRead(Color color);

        public abstract Color ColorWrite(BitArray data, int position, Color color);

        public void ToBegin()
        {
            GetBlock().ToBegin();
            GetPosition().ToBegin();
        }

        public virtual void AfterChange() {
            position.AfterChange();
        }

        public void SetPosition(Position.ModulePosition position)
        {
            this.position = position;
        }

        public ModulePosition GetPosition()
        {
            return position;
        }

        public ModuleOrder GetOrder()
        {
            return position.GetOrder();
        }

        public ModuleBlock GetBlock()
        {
            return position.GetBlock();
        }

        public virtual PixelPicture GetContainer()
        {
            return position.GetContainer();
        }

        public void WriteDataInContainer(BitArray data)
        {
            int cells = data.Length / BitsPerPixel() + (data.Length % BitsPerPixel() == 0 ? 0 : 1);
            for(int i = 0; i < cells; i++)
            {
                position.SetCurrentPosition( ColorWrite(data, i * BitsPerPixel(), position.GetCurrentPosition()));
                position.GetNextPosition();
            }
        }

        public BitArray ReadDataInContainer(int number)
        {
            BitArray data = new BitArray(number*BitsPerPixel());
            for (int i = 0; i < number; i++)
            {
                BitArray array = ColorRead(position.GetCurrentPosition());
                position.GetNextPosition();
                for(int j = 0; j  < BitsPerPixel(); j++)
                {
                    data.Set(i*BitsPerPixel() + j, array.Get(j));
                }
            }
            return data;
        }

        public BitArray ReadBytesInContainer(int numberOfBytes)
        {
            return ReadDataInContainer(numberOfBytes*8/BitsPerPixel() + (numberOfBytes * 8 % BitsPerPixel() == 0 ? 0 : 1));
        }

        public virtual void WriteFile(string fileName, BitArray data)
        {
            ToBegin();
            byte[] nameBytes = BitByte.BytesFromString(fileName);
            WriteDataInContainer(BitByte.BitsFromInt(nameBytes.Length));
            BitArray array = BitByte.BytesToBits(nameBytes);
            WriteDataInContainer(BitByte.BytesToBits(nameBytes));
            WriteDataInContainer(BitByte.BitsFromInt(data.Length / 8 + (data.Length % 8 == 0 ? 0 : 1) ));
            WriteDataInContainer(data);
        }

        public virtual void ReadFile()
        {
            ToBegin();
            BitArray nameLength = ReadBytesInContainer(4);
            BitArray fileName = ReadBytesInContainer(BitByte.IntFromBits(nameLength));
            BitArray dataLength = ReadBytesInContainer(4);
            BitArray data = ReadBytesInContainer(BitByte.IntFromBits(dataLength));
            HideFile.WriteBitArray(data, BitByte.BytesToString(BitByte.BitsToBytes(fileName)));
        }

        public int getAvaliableSpace()
        {
            return BitsPerPixel() * GetPosition().GetPositionsPerBlock() * GetBlock().NumberOfBlock();
        }        
    }
}
