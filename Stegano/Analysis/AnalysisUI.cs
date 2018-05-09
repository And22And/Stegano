using Stegano.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano.Analysis
{
    public abstract class AnalysisUI : UI, ICloneable
    {
        public abstract string GetFormName();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
