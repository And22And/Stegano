namespace Stegano.Position
{
    public class NonePositions : ModulePosition
    {
        public override int GetPositionsPerBlock()
        {
            return GetBlock().getBlockSize();
        }

        public override int NextPosition()
        {
            return currentPosition + 1;
        }

        public override string GetName()
        {
            return "None";
        }
    }
}
