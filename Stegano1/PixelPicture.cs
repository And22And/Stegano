using System;
using System.Drawing;

namespace Stegano
{
    class PixelPicture:Container
    {
        public Bitmap image;

        public PixelPicture(Bitmap image)
        {
            this.image = image;
        }

        public override int getCellNumber()
        {
            return image.Width * image.Height;
        }

        public override Color GetCell(int n)
        {
            return image.GetPixel(n % image.Width, n / image.Width);
        }

        public override void SetCell(int n, Color color)
        {
            image.SetPixel(n % image.Width, n / image.Width, color);            
        }

        public override Color GetCell(int x, int y)
        {
            return image.GetPixel(x, y);
        }

        public override void SetCell(int x, int y, Color color)
        {
            image.SetPixel(x, y, color);
        }

        public int GetHeight()
        {
            return image.Height;
        }

        public int GetWidth()
        {
            return image.Width;
        }
    }
}
