using Stegano.Block;
using System.Drawing;

namespace Stegano.Order
{
    abstract class CellOrder : GUI
    {
        public ContainerBlock block;

        public abstract Color getCellInOrder(int position);

        public abstract void setCellInOrder(int position, Color color);

        public void SetBlock(ContainerBlock block)
        {
            this.block = block;
        }

        public ContainerBlock GetBlock()
        {
            return block;
        }

        public virtual PixelPicture GetContainer()
        {
            return block.GetContainer();
        }        
    }
}
