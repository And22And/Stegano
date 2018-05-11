using Stegano.Block;
using Stegano.Order;
using Stegano.GUI;
using System.Drawing;
using Stegano.Container;

namespace Stegano.Position
{
    public abstract class ModulePosition : UI
    {
        public ModuleOrder order;
        public int currentPosition;

        public virtual int GetNextPosition()
        {
            currentPosition = NextPosition();
            if (GetBlock().isNewBlock(currentPosition))
            {
                GetBlock().NextBlock();
                ToBegin();               
            }
            return currentPosition;
        }

        public virtual Color GetCurrentPosition()
        {
            return order.getCellInOrder(currentPosition);
        }

        public void SetCurrentPosition(Color color)
        {
            order.setCellInOrder(currentPosition, color);
        }

        public virtual void AfterChange() {
            order.AfterChange();
        }

        public abstract int NextPosition();

        public abstract int GetPositionsPerBlock();

        public virtual void ToBegin()
        {
            currentPosition = 0;
        }

        public void SetOrder(Order.ModuleOrder order)
        {
            this.order = order;
        }

        public ModuleOrder GetOrder()
        {
            return order;
        }

        public ModuleBlock GetBlock()
        {
            return order.GetBlock();
        }

        public virtual PixelPicture GetContainer()
        {
            return order.GetContainer();
        }
    }
}