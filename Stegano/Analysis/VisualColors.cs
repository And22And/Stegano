using System.Drawing;

namespace Stegano.Analysis
{
    class VisualColors : PixelShow
    {
        private string[] parameters = {"white black"};
        private string[] currentParameters;

        public override Color ColorWrite()
        {
            return GetColor(currentParameters[1]);
        }

        public override void FillPicture()
        {
            for(int i = 0; i < GetPicture().GetPicture().Width; i++)
            {
                for(int j = 0; j < GetPicture().GetPicture().Height; j++)
                {
                    GetPicture().GetPicture().SetPixel(i, j, GetColor(currentParameters[0]));
                }
            }
        }

        public override string GetName()
        {
            return "Pixel distribution";
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
            currentParameters = parameters.Split(' ');
        }
    }
}
