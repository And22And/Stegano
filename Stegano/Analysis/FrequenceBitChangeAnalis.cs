using System;
using System.Collections.Generic;

namespace Stegano.Analysis
{
    class FrequenceBitChangeAnalis : AnalisysHistogram
    {
        private string[] parametrs;
        private string parameter;

        public FrequenceBitChangeAnalis()
        {
            parametrs = new string[3];
            parametrs[0] = "Both";
            parametrs[1] = "Horizontal";
            parametrs[2] = "Vertical";
        }

        override public void SetSeries()
        {
            AddSeries(parameter + " change");
            AddSeries(parameter + " no change");
        }

        override public void SetData()
        {
            for (int i = 1; i <= 8; i++)
            {
                List<Int32> list = new List<Int32>();
                switch (parameter){
                    case "Both":
                        List<Int32> vlist = FindVerticalFrequency(i);
                        List<Int32> hlist = FindHorizontalFrequency(i);                        
                        list.Add(vlist.ToArray()[0] + hlist.ToArray()[0]);
                        list.Add(vlist.ToArray()[1] + hlist.ToArray()[1]);
                        break;
                    case "Horizontal":
                        list = FindHorizontalFrequency(i);
                        break;
                    case "Vertical":
                        list = FindVerticalFrequency(i);
                        break;
                }
                AddColumn(i + " bit", list);
            }            
        }

        public List<Int32> FindHorizontalFrequency(int bit)
        {
            List<Int32> list = new List<Int32>();
            int change = 0;
            int nochange = 0;
            for (int i = 0; i < GetBitmap().Height; i++)
            {
                for(int j = 1; j < GetBitmap().Width; j++)
                {
                    if (BitByte.GetBitFromInt(GetBitmap().GetPixel(j - 1, i).R, bit) ==
                       BitByte.GetBitFromInt(GetBitmap().GetPixel(j, i).R, bit))
                    {
                        nochange++;
                    }
                    else
                    {
                        change++;
                    }
                    if (BitByte.GetBitFromInt(GetBitmap().GetPixel(j - 1, i).B, bit) ==
                       BitByte.GetBitFromInt(GetBitmap().GetPixel(j, i).B, bit))
                    {
                        nochange++;
                    }
                    else
                    {
                        change++;
                    }
                    if (BitByte.GetBitFromInt(GetBitmap().GetPixel(j - 1, i).G, bit) ==
                       BitByte.GetBitFromInt(GetBitmap().GetPixel(j, i).G, bit))
                    {
                        nochange++;
                    }
                    else
                    {
                        change++;
                    }
                }
            }
            list.Add(change);
            list.Add(nochange);
            return list;
        }

        public List<Int32> FindVerticalFrequency(int bit)
        {
            List<Int32> list = new List<Int32>();
            int change = 0;
            int nochange = 0;
            for (int i = 0; i < GetBitmap().Width; i++)
            {
                for (int j = 1; j < GetBitmap().Height; j++)
                {
                    if (BitByte.GetBitFromInt(GetBitmap().GetPixel(i, j - 1).R, bit) ==
                       BitByte.GetBitFromInt(GetBitmap().GetPixel(i, j).R, bit))
                    {
                        nochange++;
                    }
                    else
                    {
                        change++;
                    }
                    if (BitByte.GetBitFromInt(GetBitmap().GetPixel(i, j - 1).B, bit) ==
                        BitByte.GetBitFromInt(GetBitmap().GetPixel(i, j).B, bit))
                    {
                        nochange++;
                    }
                    else
                    {
                        change++;
                    }
                    if (BitByte.GetBitFromInt(GetBitmap().GetPixel(i, j - 1).G, bit) ==
                        BitByte.GetBitFromInt(GetBitmap().GetPixel(i, j).G, bit))
                    {
                        nochange++;
                    }
                    else
                    {
                        change++;
                    }
                }
            }
            list.Add(change);
            list.Add(nochange);
            return list;
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override string[] AllParameters()
        {
            return parametrs;
        }

        public override void ParametersReader(string parameters)
        {
            parameter = parameters;
        }

        public override string GetName()
        {
            return "Frequence bit change analysis";
        }
    }
}
