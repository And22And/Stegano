using System.Drawing;

namespace Stegano.Block
{
    abstract class ContainerBlock : GUI
    {
        public PixelPicture container;
        private int currentBlock = 0;

        public void NextBlock()
        {
            currentBlock++;
        }

        public int CurrentBlock()
        {
            return currentBlock;
        }

        public void ToBegin()
        {
            currentBlock = 0;
        }

        public int getBlockSize()
        {
            return getWidth() * getHeigth();
        }

        public bool isNewBlock(int position)
        {
            return position > getBlockSize();
        }

        public abstract int getWidth();

        public abstract int getHeigth();

        public abstract int NumberOfBlock();

        public abstract void PositionTransformer(int x, int y, out int _x, out int _y);

        public virtual Color getCellInBlock(int x, int y)
        {
            int _x, _y;
            PositionTransformer(x, y, out _x, out _y);
            return container.GetCell(_x, _y);
        }

        public virtual void setCellInBlock(int x, int y, Color color)
        {
            int _x, _y;
            PositionTransformer(x, y, out _x, out _y);
            container.SetCell(_x, _y, color);
        }

        public void SetContainer(PixelPicture container)
        {
            this.container = container;
        }

        public PixelPicture GetContainer()
        {
            return container;
        }
    }
}
