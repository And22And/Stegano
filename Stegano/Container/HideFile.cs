using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Stegano.Container
{
    class HideFile
    {
        public static BitArray ReadBitArray(string path)
        {
            return BitByte.BytesToBits(File.ReadAllBytes(path));
        }

        public static void WriteBitArray(BitArray bitArray, string fileName)
        {
            byte[] bytes = BitByte.BitsToBytes(bitArray);
            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                File.WriteAllBytes(path + "\\" + fileName.Replace("\0", ""), bytes);
            }
        }
    }
}
