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

        public override int NumberOfBlock()
        {
            return 1;
        }

        public override string StandartParameters()
        {
            return "";
        }

        public override bool ParametersReader(string parameters)
        {
            return true;
        }
    }
}
