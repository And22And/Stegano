using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano.Block
{
    class CenterDinamicBlock : ContainerBlock
    {
        private int heigth;
        private int width;

        public override int getHeigth()
        {
            return heigth;
        }

        public override int getWidth()
        {
            return width;
        }

        public override int NumberOfBlock()
        {
            return 1;
        }

        public override int getBlockSize()
        {
            return container.GetWidth() * container.GetHeigth();
        }

        public override void PositionTransformer(int x, int y, out int _x, out int _y)
        {
            _x = x + (container.GetWidth() - width) / 2;
            _y = y + (container.GetHeigth() - heigth) / 2;        
        }

        public override void ToBegin()
        {
            base.ToBegin();
            ResizeBlock();
        }

        public override void AfterChange()
        {
            ResizeBlock();
        }

        public void ResizeBlock()
        {
            double sqrt = Math.Sqrt(Stegano.GetDataSize());
            int size = (int)sqrt;
            if (sqrt % 1 != 0)
            {
                size++;
            }
            heigth = size;
            width = size;
            if (heigth > container.GetHeigth())
            {
                heigth = container.GetHeigth();
                while (heigth * width < Stegano.GetDataSize())
                {
                    width++;
                }
            }
            else if (width > container.GetWidth())
            {
                width = container.GetWidth();
                while (heigth * width < Stegano.GetDataSize())
                {
                    heigth++;
                }
            }
        }


    }
}
