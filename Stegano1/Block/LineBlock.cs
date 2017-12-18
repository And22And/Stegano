using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano.Block
{
    class LineBlock : ContainerBlock
    {
        public override int getHeigth()
        {
            return container.GetHeigth();
        }

        public override int getWidth()
        {
            return container.GetWidth()/12*6;
        }

        public override int NumberOfBlock()
        {
            return 1;
        }

        public override void PositionTransformer(int x, int y, out int _x, out int _y)
        {
            _y = y;
            int xChange = 0;
            while(x > getWidth()/6)
            {
                x -= getWidth() / 6;
                xChange++;
            }
            _x = x + xChange * getWidth() / 3;
        }
    }
}
