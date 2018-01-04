using System;
namespace Stegano.Position
{
    class PositionsWithHole : ModulePosition
    {
        private int hole;
        private string[] parameters = { "1", "2", "3", "4", "5" };

        public override int GetPositionsPerBlock()
        {
            return GetBlock().getBlockSize() / (hole+1);
        }

        public override int NextPosition()
        {
            return currentPosition + hole + 1;
        }

        public override string[] AllParameters()
        {
            return parameters;
        }

        public override string HintString()
        {
            return "Distanse betwin two pixel that is written";
        }

        public override void ParametersReader(string parameters)
        {
            hole = Convert.ToInt32(parameters);
        }

        public override bool HasParameters()
        {
            return true;
        }
    }
}
