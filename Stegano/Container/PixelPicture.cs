using System.Drawing;

namespace Stegano.Container
{
    public class PixelPicture
    {
        private Bitmap image;

        public PixelPicture(Bitmap image)
        {
            this.image = image;
        }

        public Bitmap GetPicture()
        {
            return image;
        }

        public int getCellNumber()
        {
            return image.Width * image.Height;
        }

        public Color GetCell(int n)
        {
            return image.GetPixel(n % image.Width, n / image.Width);
        }

        public void SetCell(int n, Color color)
        {
            image.SetPixel(n % image.Width, n / image.Width, color);            
        }

        public Color GetCell(int x, int y)
        {
            return image.GetPixel(x, y);
        }

        public void SetCell(int x, int y, Color color)
        {
            image.SetPixel(x, y, color);
        }

        public int GetHeigth()
        {
            return image.Height;
        }

        public int GetWidth()
        {
            return image.Width;
        }
    }
}
