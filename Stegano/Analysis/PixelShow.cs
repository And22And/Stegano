using Stegano.WriterReader;
using Stegano.GUI;
using System.Collections;
using System.Drawing;
using Stegano.Container;

namespace Stegano.Analysis
{
    public abstract class PixelShow : UI
    {
        private ModuleWriterReader writerReader;
        private PixelPicture picture;

        public int BitsPerPixel()
        {
            return writerReader.BitsPerPixel();
        }

        public PixelPicture GetPicture()
        {
            return picture;
        }

        public void SetWriterReader(ModuleWriterReader writerReader)
        {
            this.writerReader = writerReader;
        }

        public abstract Color ColorWrite();

        public abstract void FillPicture();

        public void ToBegin()
        {
            writerReader.GetBlock().ToBegin();
            writerReader.GetPosition().ToBegin();
        }

        public virtual void AfterChange()
        {
            writerReader.GetPosition().AfterChange();
        }

        public void WriteDataInContainer(BitArray data)
        {
            int cells = data.Length / BitsPerPixel() + (data.Length % BitsPerPixel() == 0 ? 0 : 1);
            for (int i = 0; i < cells; i++)
            {
                writerReader.GetPosition().SetCurrentPosition(ColorWrite());
                writerReader.GetPosition().GetNextPosition();
            }
        }

        public virtual void WritePicture(string fileName, BitArray data)
        {
            PixelPicture original = writerReader.GetContainer();
            picture = new PixelPicture(new Bitmap(original.GetPicture()));
            writerReader.GetBlock().SetContainer(picture);
            FillPicture();
            ToBegin();
            byte[] nameBytes = BitByte.BytesFromString(fileName);
            WriteDataInContainer(BitByte.BitsFromInt(nameBytes.Length));
            BitArray array = BitByte.BytesToBits(nameBytes);
            WriteDataInContainer(BitByte.BytesToBits(nameBytes));
            WriteDataInContainer(BitByte.BitsFromInt(data.Length / 8 + (data.Length % 8 == 0 ? 0 : 1)));
            WriteDataInContainer(data);
            writerReader.GetBlock().SetContainer(original);
        }

        public int getAvaliableSpace()
        {
            return BitsPerPixel() * writerReader.GetPosition().GetPositionsPerBlock() * writerReader.GetBlock().NumberOfBlock();
        }

        public Color GetColor(string parameter)
        {
            switch (parameter)
            {
                case "red":
                    return Color.Red;
                case "blue":
                    return Color.Blue;
                case "green":
                    return Color.Green;
                case "white":
                    return Color.White;
                case "black":
                    return Color.Black;
                case "yellow":
                    return Color.Yellow;
                case "salate":
                    return Color.SlateGray;
                default:
                    return Color.Red;
            }
        }
    }
}
