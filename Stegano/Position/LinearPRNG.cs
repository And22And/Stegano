using System;

namespace Stegano.Position
{
    public class LinearPRNG : ModulePosition
    {
        private int a;
        private int b;
        private int cur;
        private int blockSize = 0;
        private int par1, par2, par3;
        private string[] parameters = { "7 3 5", "7 2 3", "3 9 7", "5 3 4", "2 5 3" };

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

        public override void AfterChange()
        {
            base.AfterChange();
            ToBegin();
        }

        public override void ToBegin()
        {
            currentPosition = blockSize / par1 + blockSize / par2 - blockSize / par3;
            b = currentPosition % 2 == 0 ? currentPosition + 1 : currentPosition;
            while (GCD(b, blockSize) != 1)
            {
                b += 2;
            }
            if (blockSize != GetBlock().getBlockSize()) {
                blockSize = GetBlock().getBlockSize();
                a = GenA(blockSize);                
            }
            cur = 0;
            currentPosition = blockSize / 2;
        }

        int GCD(int a, int b)
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

        int GenA(int m)
        {            
            int i = 2, a = 1;
            if (m % 4 == 0)
            {
                a = 4;
                while(m % 2 == 0)
                {
                    m /= 2;
                }
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
            while(a < GetBlock().getBlockSize() / 3)
            {
                a *= 2;
            }
            return a + 1;
        }

        public override string[] AllParameters()
        {
            return parameters;
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override string HintString()
        {
            return "Parameters for different dispersion of PRNG";
        }

        public override void ParametersReader(string parameters)
        {
            string[] paramets = parameters.Split(' ');
            par1 = Convert.ToInt32(paramets[0]);
            par2 = Convert.ToInt32(paramets[1]);
            par3 = Convert.ToInt32(paramets[2]);
        }

        public override string GetName()
        {
            return "Linear PRNG";
        }
    }
}
