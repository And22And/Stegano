using System;

namespace Stegano.Block
{
    class LineBlock : ModuleBlock
    {
        private int lineNumber;
        private string[] parameters = { "2", "3", "4", "5", "6"};

        public override int getHeigth()
        {
            return container.GetHeigth();
        }

        public override int getWidth()
        {
            return container.GetWidth()/2/lineNumber*lineNumber;
        }

        public override int NumberOfBlock()
        {
            return 1;
        }

        public override void PositionTransformer(int x, int y, out int _x, out int _y)
        {
            _y = y;
            int xChange = 0;
            while(x > getWidth()/ lineNumber)
            {
                x -= getWidth() / lineNumber;
                xChange++;
            }
            _x = x + xChange * getWidth() / lineNumber * 2;
        }

        public override string[] AllParameters()
        {
            return parameters;
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override void ParametersReader(string parameters)
        {
            lineNumber = Convert.ToInt32(parameters);
        }

        public override string HintString()
        {
            return "Number of lines block";
        }

        public override string GetName()
        {
            return "Line block";
        }
    }
}