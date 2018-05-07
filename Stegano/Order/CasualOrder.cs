using Stegano.GUI;

namespace Stegano.Order
{
    class CasualOrder : ModuleOrder
    {
        private string[][] parameters;
        private string corner;
        private string orientation;

        public CasualOrder()
        {
            parameters = new string[3][];
            parameters[0] = new string[2];
            parameters[1] = new string[2];
            parameters[2] = new string[2];
            parameters[0][0] = "left";
            parameters[0][1] = "right";
            parameters[1][0] = "top";
            parameters[1][1] = "bottom";
            parameters[2][0] = "horizontal";
            parameters[2][1] = "vertical";
        }

        public override void PositionTransform(int number, out int x, out int y)
        {
            if (orientation.Equals(parameters[2][0]))
            {
                x = number % block.getWidth();
                y = number / block.getWidth();
            }
            else
            {
                y = number % block.getHeigth();
                x = number / block.getHeigth();
            }
            if (corner.Equals(parameters[0][0] + parameters[1][0]))
            {
               //noting
            }
            if (corner.Equals(parameters[0][0] + parameters[1][1]))
            {
                y = block.getHeigth() - y - 1;                
            }
            if (corner.Equals(parameters[0][1] + parameters[1][0]))
            {
                x = block.getWidth() - x - 1;                
            }
            if (corner.Equals(parameters[0][1] + parameters[1][1]))
            {                
                x = block.getWidth() - x - 1;
                y = block.getHeigth() - y - 1;                
            }
        }        

        public override string[] AllParameters()
        {
            return ParametersGenerator.ArrayCombination(parameters);
        }

        public override void ParametersReader(string parameters)
        {
            string[] splits = parameters.Split(' ');
            corner = splits[0] + splits[1];
            orientation = splits[2];
        }

        public override string HintString()
        {
            return "Start corner and orientation";
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override string GetName()
        {
            return "Casual order";
        }
    }
}
