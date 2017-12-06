using System;
using System.Drawing;

namespace Stegano.Block
{
    class FullBlock : ContainerBlock
    {       

        public FullBlock()
        {
            beginX = 0;
            beginY = 0;            
        }

        public override void SetContainer(PixelPicture container)
        {
            base.SetContainer(container);
            if (container != null)
            {
                endX = container.GetWidth();
                endY = container.GetHeight();
            }
        }

        public override int getBlockSize()
        {
            return container == null ? 0 : container.getCellNumber();
        }

        public override Color getCellInBlock(int x, int y)
        {
            return container.GetCell(x, y);
        }

        public override void setCellInBlock(int x, int y, Color color)
        {
            container.SetCell(x, y, color);
        }

        public override Color getCellInBlock(int n)
        {
            return container.GetCell(n);
        }

        public override void setCellInBlock(int n, Color color)
        {
            container.SetCell(n, color);
        }

        public override int NumberOfBlock()
        {
            return 1;
        }
    }
}
