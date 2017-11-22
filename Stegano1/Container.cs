using System.Drawing;

namespace Stegano
{
    abstract class Container
    {
        public abstract int getCellNumber();

        public abstract Color GetCell(int n);

        public abstract Color GetCell(int x, int y);

        public abstract void SetCell(int n, Color color);

        public abstract void SetCell(int x, int y, Color color);


    }
}
