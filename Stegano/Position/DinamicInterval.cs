namespace Stegano.Position
{
    public class DinamicInterval : ModulePosition
    {
        private int hole;
        private int[] holes = { 3, 1, 4, 2}; 

        public override int GetPositionsPerBlock()
        {
            return GetBlock().getBlockSize() / 14 * 4;
        }

        public override int NextPosition()
        {
            hole++;
            hole %= 4;
            return currentPosition + holes[hole] + 1;
        }

        public override void ToBegin()
        {
            base.ToBegin();
            hole = 0;
        }

        public override string GetName()
        {
            return "Dinamic interval";
        }
    }
}
