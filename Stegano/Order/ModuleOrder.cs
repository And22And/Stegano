using Stegano.Block;
using Stegano.Container;
using Stegano.GUI;
using System.Drawing;

namespace Stegano.Order
{
    public abstract class ModuleOrder : UI
    {
        public ModuleBlock block;

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

        public void SetBlock(ModuleBlock block)
        {
            this.block = block;
        }

        public ModuleBlock GetBlock()
        {
            return block;
        }

        public virtual PixelPicture GetContainer()
        {
            return block.GetContainer();
        }
    }
}
