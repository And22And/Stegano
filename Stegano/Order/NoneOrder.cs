namespace Stegano.Order
{
    public class NoneOrder :CasualOrder
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
