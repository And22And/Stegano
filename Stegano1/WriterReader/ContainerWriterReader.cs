using Stegano.Block;
using Stegano.Order;
using Stegano.Position;
using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Stegano.WriterReader
{
    abstract class ContainerWriterReader
    {
        public CellPosition position;

        public abstract int BitsPerCell();

        public abstract Color ColorWrite(BitArray data, int position, Color color);

        public abstract BitArray ColorRead(Color color);

        public void SetPosition(CellPosition position)
        {
            this.position = position;
        }

        public CellPosition GetPosition()
        {
            return position;
        }

        public CellOrder GetOrder()
        {
            return position.GetOrder();
        }

        public ContainerBlock GetBlock()
        {
            return position.GetBlock();
        }

        public virtual PixelPicture GetContainer()
        {
            return position.GetContainer();
        }

        public void WriteDataInContainer(BitArray data)
        {
            int cells = data.Length / BitsPerCell() + (data.Length % BitsPerCell() == 0 ? 0 : 1);
            for(int i = 0; i < cells; i++)
            {
                position.SetCurrentPosition( ColorWrite(data, i * BitsPerCell(), position.GetCurrentPosition()));
                position.NextPosition();
            }
        }

        public BitArray ReadDataInContainer(int number)
        {
            BitArray data = new BitArray(number*BitsPerCell());
            for (int i = 0; i < number; i++)
            {
                BitArray array = ColorRead(position.GetCurrentPosition());
                position.NextPosition();
                for(int j = 0; j  < BitsPerCell(); j++)
                {
                    data.Set(i*BitsPerCell() + j, array.Get(j));
                }
            }
            return data;
        }

        public BitArray ReadBytesInContainer(int numberOfBytes)
        {
            return ReadDataInContainer(numberOfBytes*8/BitsPerCell() + (numberOfBytes * 8 % BitsPerCell() == 0 ? 0 : 1));
        }

        public void WriteFile(string fileName, BitArray data)
        {
            GetPosition().ToBegin();
            byte[] nameBytes = BitByte.BytesFromString(fileName);
            WriteDataInContainer(BitByte.BitsFromInt(nameBytes.Length));
            BitArray array = BitByte.BytesToBits(nameBytes);
            WriteDataInContainer(BitByte.BytesToBits(nameBytes));
            WriteDataInContainer(BitByte.BitsFromInt(data.Length / 8 + (data.Length % 8 == 0 ? 0 : 1) ));
            WriteDataInContainer(data);
        }

        public void ReadFile()
        {
            GetPosition().ToBegin();
            BitArray nameLength = ReadBytesInContainer(4);
            BitArray fileName = ReadBytesInContainer(BitByte.IntFromBits(nameLength));
            BitArray dataLength = ReadBytesInContainer(4);
            BitArray data = ReadBytesInContainer(BitByte.IntFromBits(dataLength));
            HideFile.WriteBitArray(data, BitByte.BytesToString(BitByte.BitsToBytes(fileName)));
        }

        public long getAvaliableSpace()
        {
            return BitsPerCell() * GetPosition().GetPositionsPerBlock() * GetBlock().NumberOfBlock();
        }

        public virtual string HintString()
        {
            return "This does not requare any parameters";
        }

        public abstract string StandartParameters();

        public abstract bool ParametersReader(string parameters);
    }
}
