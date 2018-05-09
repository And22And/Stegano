using Stegano.Analysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stegano.GUI
{
    public interface AnalysisFormInterface
    {
        void SetAnalysisParameters(Bitmap picture, AnalysisUI analysis);
    }
}
