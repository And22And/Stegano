using Stegano.Analysis;
using System.Drawing;
using System.Windows.Forms;

namespace Stegano.GUI
{
    public partial class AnalysisPictureForm : Form, AnalysisFormInterface
    {
        private AnalysisPicture analysisPicture;

        public AnalysisPictureForm()
        {
            InitializeComponent();
        }

        public void SetAnalysisParameters(Bitmap picture, AnalysisUI analysis)
        {
            analysisPicture = (AnalysisPicture)analysis;
            analysisPicture.SetPicture(picture);
            analysisImage.Image = analysisPicture.CreateAnalysisPicture();
        }
    }
}
