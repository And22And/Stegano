using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stegano.WriterReader
{
    class VisualWrite : ContainerWriterReader
    {
        private string[] parameters = { "1", "1/2", "1/3", "1/4", "file" };
        private string currentParameter;

        public override int BitsPerCell()
        {
            return 8;
        }

        public override BitArray ColorRead(Color color)
        {
            throw new NotImplementedException();
        }

        public override Color ColorWrite(BitArray data, int position, Color color)
        {
            throw new NotImplementedException();
        }

        public override void ReadFile()
        {
            throw new NotImplementedException();
        }

        public void WriteRed(int number)
        {
            for(int i = 0; i < number; i++)
            {
                position.SetCurrentPosition(Color.Red);
                position.GetNextPosition();
            }
        }

        public override void WriteFile(string fileName, BitArray data)
        {
            int writeCells = 0;
            switch (currentParameter)
            {
                case "1":
                    writeCells = getAvaliableSpace() / BitsPerCell();
                    break;
                case "1/2":
                    writeCells = getAvaliableSpace() / BitsPerCell() / 2;
                    break;
                case "1/3":
                    writeCells = getAvaliableSpace() / BitsPerCell() / 3;
                    break;
                case "1/4":
                    writeCells = getAvaliableSpace() / BitsPerCell() / 4;
                    break;
                case "file":
                    byte[] nameBytes = BitByte.BytesFromString(fileName);
                    writeCells = nameBytes.Length + data.Length + 4 + 4;
                    break;
            }
            Stegano.SetDataSize(writeCells);
            AfterChange();
            ToBegin();
            WriteRed(writeCells);              
        }

        public override bool HasParameters()
        {
            return true;
        }

        public override string HintString()
        {
            return "Test method to show how data is writen";
        }

        public override void ParametersReader(string parameters)
        {
            currentParameter = parameters;
        }

        public override string[] AllParameters()
        {
            return parameters;
        }
    }
}
