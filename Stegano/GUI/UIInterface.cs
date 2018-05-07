using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano.GUI
{
    public interface UIInterface
    {
        string HintString();

        bool HasParameters();

        string[] AllParameters();

        void ParametersReader(string parameters);

        string GetName();

        bool IsShown();
    }
}
