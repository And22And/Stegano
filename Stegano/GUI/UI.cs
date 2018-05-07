using System;

namespace Stegano.GUI
{
    public abstract class UI:UIInterface
    {
        public virtual string HintString()
        {
            return "This does not require any parameters";
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

        public abstract string GetName();

        public virtual bool IsShown()
        {
            return true;
        }
    }
}
