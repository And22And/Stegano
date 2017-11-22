using System.Drawing;

namespace Stegano.Block
{
    abstract class ContainerBlock
    {
        public PixelPicture container;
        public int beginX, beginY, endX, endY;

        public abstract int getBlockSize();

        public abstract Color getCellInBlock(int x, int y);

        public abstract void setCellInBlock(int x, int y, Color cell);

        public virtual void SetContainer(PixelPicture container)
        {
            this.container = container;
        }

        public virtual PixelPicture GetContainer()
        {
            return container;
        }

        public abstract int NumberOfBlock();

        public virtual string HintString()
        {
            return "This does not requare any parameters";
        }

        public abstract string StandartParameters();

        public abstract bool ParametersReader(string parameters);
    }
}
