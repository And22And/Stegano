namespace Stegano.Block
{
    public class NoneBlock : ModuleBlock
    {

        public override int getWidth()
        {
            return GetContainer().GetWidth();
        }

        public override int getHeigth()
        {
            return GetContainer().GetHeigth();
        }

        public override int NumberOfBlock()
        {
            return 1;
        }

        public override void PositionTransformer(int x, int y, out int _x, out int _y)
        {
            _x = x;
            _y = y;
        }

        public override string GetName()
        {
            return "None";
        }
    }
}
