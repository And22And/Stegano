using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano.Position
{
    class PositionLinearPRNG : CellPosition
    {
        private int a;
        private int b;
        private int cur;
        private int blockSize = 0;

        public override int GetPositionsPerBlock()
        {
            return GetBlock().getBlockSize();
        }

        public override int NextPosition()
        {
            cur++;
            long z = 1;
            long c = (a * z * currentPosition + b) % GetBlock().getBlockSize();
            return (int)c;
        }

        public override int GetNextPosition()
        {
            currentPosition = NextPosition();
            if (GetBlock().isNewBlock(cur))
            {
                GetBlock().NextBlock();
                ToBegin();
            }
            return currentPosition;
        }

        public override void ToBegin()
        {
            if (blockSize != GetBlock().getBlockSize()) {
                blockSize = GetBlock().getBlockSize();
                currentPosition = blockSize / 2;
                a = genA(blockSize);
                b = currentPosition % 2 == 0 ? currentPosition + 1 : currentPosition;
                while (gcd(b, blockSize) != 1)
                {
                    b += 2;
                }
            }
            cur = 0;
            currentPosition = blockSize / 2;
        }

        int gcd(int a, int b)
        {
            if (a == 0) return b;
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        int genA(int m)
        {            
            int i = 2, a = 1;
            if (m % 4 == 0)
            {
                a = 4;
            }
            while (m != 1)
            {
                if(m % i == 0)
                {
                    m /= i;
                    if(a % i != 0)
                    {
                        a *= i;
                    }
                } else
                {
                    i++;
                }
            }
            return a + 1;
        }
    }
}
