using System.Drawing;
using System.Windows.Forms;
using Stegano.Analysis;

namespace Stegano.GUI
{
    public partial class AnalysisHistogramForm : Form, AnalysisFormInterface
    {
        private AnalysisHistogram histogram;

        public AnalysisHistogramForm()
        {
            InitializeComponent();
        }

        public void SetAnalysisParameters(Bitmap picture, AnalysisUI analysis)
        {
            histogram = (AnalysisHistogram)analysis;
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
