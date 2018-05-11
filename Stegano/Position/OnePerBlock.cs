namespace Stegano.Position
{
    public class OnePerBlock : ModulePosition
    {
        private int nextPos;

        public override int GetPositionsPerBlock()
        {
            return 1;
        }

        public override int NextPosition()
        {
            if(nextPos == GetBlock().CurrentBlock())
            {
                nextPos++;
                return nextPos - 1; 
            }
            return GetBlock().getBlockSize() + 1;
        }

        public override void ToBegin()
        {
            nextPos = GetBlock().CurrentBlock();
        }

        public override string GetName()
        {
            return "One per block";
        }
    }
}
