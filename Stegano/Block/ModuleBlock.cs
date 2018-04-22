﻿using System;
using System.Drawing;

namespace Stegano.Block
{
    abstract class ModuleBlock : GUI
    {
        public PixelPicture container;
        private int currentBlock = 0;

        public void NextBlock()
        {
            currentBlock++;
            if(currentBlock > NumberOfBlock())
            {
                throw new Exception("Insufficient number of block");
            }
        }

        public int CurrentBlock()
        {
            return currentBlock;
        }

        public virtual void ToBegin()
        {
            currentBlock = 0;
        }

        public virtual int getBlockSize()
        {
            return getWidth() * getHeigth();
        }

        public bool isNewBlock(int position)
        {
            return position >= getBlockSize();
        }

        public abstract int getWidth();

        public abstract int getHeigth();

        public abstract int NumberOfBlock();

        public abstract void PositionTransformer(int x, int y, out int _x, out int _y);

        public virtual void AfterChange() { }

        public virtual Color getCellInBlock(int x, int y)
        {
            int _x, _y;
            PositionTransformer(x, y, out _x, out _y);
            return container.GetCell(_x, _y);
        }

        public virtual void setCellInBlock(int x, int y, Color color)
        {
            int _x, _y;
            PositionTransformer(x, y, out _x, out _y);
            container.SetCell(_x, _y, color);
        }

        public void SetContainer(PixelPicture container)
        {
            this.container = container;
        }

        public PixelPicture GetContainer()
        {
            return container;
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
