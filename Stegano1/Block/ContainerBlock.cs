using System.Drawing;

namespace Stegano.Block
{
    abstract class ContainerBlock : GUI
    {
        public PixelPicture container;
        public int beginX, beginY, endX, endY;

        public abstract int getBlockSize();

        public abstract int NumberOfBlock();

        public virtual Color getCellInBlock(int x, int y)
        {
            return container.GetCell(x, y);
        }

        public virtual void setCellInBlock(int x, int y, Color color)
        {
            container.SetCell(x, y, color);
        }

        public virtual Color getCellInBlock(int n)
        {
            return container.GetCell(n);
        }

        public virtual void setCellInBlock(int n, Color color)
        {
            container.SetCell(n, color);
        }

        public virtual void SetContainer(PixelPicture container)
        {
            this.container = container;
        }

        public virtual PixelPicture GetContainer()
        {
            return container;
        }
    }
}
