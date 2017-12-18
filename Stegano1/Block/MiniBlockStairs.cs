using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stegano.Block
{
    class MiniBlockStairs : ContainerBlock
    {
        private string[] parameters = {"5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"};
        private int blockSize;


        public override int getHeigth()
        {
            return blockSize;
        }

        public override int getWidth()
        {
            return blockSize;
        }

        public override int NumberOfBlock()
        {
            return container.GetHeigth() / blockSize;
        }

        public override void PositionTransformer(int x, int y, out int _x, out int _y)
        {          
                _x = x + (CurrentBlock() % (container.GetWidth() / blockSize)) * blockSize;
                _y = y + CurrentBlock() * blockSize;
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override string[] AllParameters()
        {
            return parameters;
        }

        public override void ParametersReader(string parameters)
        {
            blockSize = Convert.ToInt32(parameters);
        }

        public override string HintString()
        {
            return "Set size of block";
        }
    }
}
