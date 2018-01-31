namespace Stegano.Position
{
    class NarrowPosition : ModulePosition
    {
        public override int GetPositionsPerBlock()
        {
            return GetBlock().getBlockSize();
        }

        public override int NextPosition()
        {
            return currentPosition + 1;
        }
    }
}
