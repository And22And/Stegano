using System;
using System.Drawing;

namespace Stegano.Order
{
    class CasualOrder : CellOrder
    {
        public CasualOrder()
        {

        }

        public override Color getCellInOrder(int position)
        {
            return block.getCellInBlock(position % (block.endX - block.beginX), position / (block.endY - block.beginY));
        }

        public override void setCellInOrder(int position, Color color)
        {
            block.setCellInBlock(position % (block.endX - block.beginX), position / (block.endY - block.beginY), color);
        }
    }
}
