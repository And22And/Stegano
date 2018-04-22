﻿
using Stegano.Block;
using Stegano.Order;
using System;
using System.Drawing;

namespace Stegano.Position
{
    abstract class ModulePosition : GUI
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