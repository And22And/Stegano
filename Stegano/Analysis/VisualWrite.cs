using System.Drawing;

namespace Stegano.Analysis
{
    public class VisualWrite :PixelShow
    {
        private string currentParameter;
        private string[] parameters = { "red", "blue", "green", "white", "black"};

        public override Color ColorWrite()
        {
            return GetColor(currentParameter);
        }

        public override void FillPicture()
        {
            
        }

        public override string GetName()
        {
            return "Mark pixel";
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
            currentParameter = parameters;
        }
    }
}
