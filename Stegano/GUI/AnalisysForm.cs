using System.Drawing;
using System.Windows.Forms;
using Stegano.Analysis;

namespace Stegano.GUI
{
    public partial class AnalisysForm : Form
    {
        private Bitmap bitmap;
        private AnalisysHistogram histogram;

        public AnalisysForm(Bitmap picture, AnalisysHistogram hist)
        {
            InitializeComponent();
            histogram = hist;
            bitmap = picture;
            histogram.SetBitmap(picture);
            histogram.SetChart(analisisHistogram);
            histogram.Clear();
            histogram.SetHistogrammProperties();
        }

        private void showButton_Click(object sender, System.EventArgs e)
        {
            histogram.DisplayValue(true);
        }

        private void hideButton_Click(object sender, System.EventArgs e)
        {
            histogram.DisplayValue(false);
        }
    }
}
