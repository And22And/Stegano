using Stegano.Block;
using System.Drawing;

namespace Stegano.Order
{
    abstract class CellOrder : GUI
    {
        public ContainerBlock block;

        public abstract void PositionTransform(int number, out int x, out int y);

        public virtual Color getCellInOrder(int position)
        {
            int x, y;
            PositionTransform(position, out x, out y);
            return block.getCellInBlock(x, y);
        }

        public virtual void setCellInOrder(int position, Color color)
        {
            int x, y;
            PositionTransform(position, out x, out y);
            block.setCellInBlock(x, y, color);
        }

        public virtual void AfterChange() {
            block.AfterChange();
        }

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
