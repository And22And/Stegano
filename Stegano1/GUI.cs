using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano
{
    abstract class GUI
    {
        public virtual string HintString()
        {
            return "This does not requare any parameters";
        }

        public virtual bool HasParameters()
        {
            return false;
        }

        public virtual string[] AllParameters()
        {
            throw new NotSupportedException();
        }

        public virtual void ParametersReader(string parameters)
        {
            throw new NotSupportedException();
        }
    }
}
