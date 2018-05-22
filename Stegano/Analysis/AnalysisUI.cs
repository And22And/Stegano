using Stegano.GUI;
using System;

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
