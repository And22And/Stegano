using Stegano.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stegano.Analysis
{
    public abstract class AnalysisPicture : AnalysisUI
    {
        private Bitmap picture;

        public Bitmap GetPicture()
        {
            return picture;
        }

        public void SetPicture(Bitmap pict)
        {
            picture = pict;
        }

        public override string GetFormName()
        {
            return "Stegano.GUI.AnalysisPictureForm";
        }

        public abstract Bitmap CreateAnalysisPicture();

    }
}
