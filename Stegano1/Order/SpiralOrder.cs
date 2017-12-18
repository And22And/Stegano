using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stegano.Order
{
    class SpiralOrder : CellOrder
    {

        private string[][] parameters;
        private string corner;
        private string orientation;

        public SpiralOrder()
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
            int a, b;
            a = block.getWidth();
            b = block.getHeigth();            
            while(number > (a + b)*2 - 4)
            {
                number -= (a + b) * 2 - 4;
                if (a > 2)
                {
                    a -= 2;
                }
                if (b > 2)
                {
                    b -= 2;
                }
            }
            if (orientation.Equals(parameters[2][0]))
            {
                if( number >= a)
                {
                    number -= a-1;
                    if(number >= b)
                    {
                        number -= b-1;
                        if(number >= a)
                        {
                            number -= a-1;
                            x = (block.getWidth() - a) / 2;
                            y = (block.getHeigth() - b) / 2 + b - number - 1;
                        } else
                        {
                            x = (block.getWidth() - a) / 2 + a - number - 1;
                            y = (block.getHeigth() - b) / 2 + b - 1;
                        }
                    } else
                    {
                        x = (block.getWidth() - a) / 2 + a - 1;
                        y = (block.getHeigth() - b) / 2 + number;
                    }
                } else
                {
                    x = (block.getWidth() - a)/2 + number;
                    y = (block.getHeigth() - b) / 2;
                }
            }
            else
            {
                if (number >= b)
                {
                    number -= b-1;
                    if (number >= a)
                    {
                        number -= a-1;
                        if (number >= b)
                        {
                            number -= b-1;
                            x = (block.getWidth() - a) / 2 + a - number - 1;
                            y = (block.getHeigth() - b) / 2;
                        }
                        else
                        {
                            x = (block.getWidth() - a) / 2 + a - 1;
                            y = (block.getHeigth() - b) / 2 + b - number - 1;
                        }
                    }
                    else
                    {
                        x = (block.getWidth() - a) / 2 + number;
                        y = (block.getHeigth() - b) / 2 + b - 1;
                    }
                }
                else
                {
                    x = (block.getWidth() - a) / 2;
                    y = (block.getHeigth() - b) / 2 + number;
                }
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
    }
}
