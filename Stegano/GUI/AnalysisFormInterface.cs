using Stegano.Analysis;
using System.Drawing;

namespace Stegano.GUI
{
    public interface AnalysisFormInterface
    {
        void SetAnalysisParameters(Bitmap picture, AnalysisUI analysis);
    }
}
