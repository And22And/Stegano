﻿
using System;
using System.Drawing;

namespace Stegano.Position
{
    class NarrowPosition : CellPosition
    {
        public NarrowPosition()
        {

        }

        public override int GetPositionsPerBlock()
        {
            return GetBlock().getBlockSize();
        }

        public override int NextPosition()
        {
            return currentPosition++;
        }
    }
}
