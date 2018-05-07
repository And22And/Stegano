using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stegano.Order
{
    class NoneOrder:CasualOrder
    {
        public NoneOrder()
        {
            ParametersReader(AllParameters()[0]);
        }

        public override bool HasParameters()
        {
            return false;
        }

        public override string HintString()
        {
            return "This module does not require any parameters";
        }

        public override string GetName()
        {
            return "None";
        }
    }
}
