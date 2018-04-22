using Stegano.Block;
using System;
using System.Drawing;

namespace Stegano.Order
{
    abstract class ModuleOrder : GUI
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

        public virtual string HintString()
        {
            return "This does not requare any parameters";
        }

        public virtual bool HasParameters()
        {
            return false;
        }

        public virtual string[] AllParameters()
        {
            throw new NotSupportedException();
        }

        public virtual void ParametersReader(string parameters)
        {
            throw new NotSupportedException();
        }
    }
}
