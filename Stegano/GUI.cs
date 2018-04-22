using System;

namespace Stegano
{
    interface GUI
    {
        string HintString();

        bool HasParameters();

        string[] AllParameters();

        void ParametersReader(string parameters);
    }
}
