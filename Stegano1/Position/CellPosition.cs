
using Stegano.Block;
using Stegano.Order;
using System.Drawing;

namespace Stegano.Position
{
    abstract class CellPosition : GUI
    {
        public CellOrder order;
        public int currentPosition;

        public virtual Color GetNextPosition()
        {
            NextPosition();
            return GetCurrentPosition();
        }

        public virtual Color GetCurrentPosition()
        {
            return order.getCellInOrder(currentPosition);
        }

        public void SetCurrentPosition(Color color)
        {
            order.setCellInOrder(currentPosition, color);
        }

        public abstract int NextPosition();

        public abstract int GetPositionsPerBlock();

        public virtual void ToBegin()
        {
            currentPosition = 0;
        }

        public void SetOrder(CellOrder order)
        {
            this.order = order;
        }

        public CellOrder GetOrder()
        {
            return order;
        }

        public ContainerBlock GetBlock()
        {
            return order.GetBlock();
        }

        public virtual PixelPicture GetContainer()
        {
            return order.GetContainer();
        }        
    }
}
