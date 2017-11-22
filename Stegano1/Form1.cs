using Stegano.Block;
using Stegano.Order;
using Stegano.Position;
using Stegano.WriterReader;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Stegano
{
    public partial class Form1 : Form
    {
        private static string blockClass = "Stegano.Block.ContainerBlock";
        private static string orderClass = "Stegano.Order.CellOrder";
        private static string positionClass = "Stegano.Position.CellPosition";
        private static string writerClass = "Stegano.WriterReader.ContainerWriterReader";
        private string[] blockNames;
        private string[] orderNames;
        private string[] positionNames;
        private string[] writerNames;
        private ContainerWriterReader writerReader = null;


        public Form1()
        {
            InitializeComponent();            
            blockNames = Reflection.GetTypesNames(blockClass);
            orderNames = Reflection.GetTypesNames(orderClass);
            positionNames = Reflection.GetTypesNames(positionClass);
            writerNames = Reflection.GetTypesNames(writerClass);

            //order of next lines must be the same 
            setList(writerList, writerNames);
            setList(positionList, positionNames);
            setList(orderList, orderNames);
            setList(blockList, blockNames);

            showSpaceValues();
        }

        private void setList(ComboBox box, string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                box.Items.Add(names[i].Substring(names[i].LastIndexOf(".") + 1));
            }
            box.SelectedIndex = 0;
        }

        private void showSpaceValues()
        {
            long needed = 0;
            long avaliable = 0;
            if (chosenFileName.Text.Length != 0)
            {
                needed = new FileInfo(chosenFileName.Text).Length * 8;
            }
            if (pictureBox1.Image != null)
            {
                avaliable = writerReader.getAvaliableSpace();
            }
            string status = avaliable >= needed ? "OK" : "Chosen method and image is not enough to contain file";             
            spaceLabel.Text = needed + "/" + avaliable + " " + status;
        }

        private void writeBut_Click(object sender, EventArgs e)
        {
            writerReader.GetPosition().ToBegin();
            FileInfo info = new FileInfo(chosenFileName.Text);
            writerReader.WriteFile(info.Name, HideFile.ReadBitArray(info.FullName));
            pictureBox1.Image = new Bitmap(writerReader.GetContainer().image);
            resultText.Text = "Writing is over";
        }

        private void readBut_Click(object sender, EventArgs e)
        {
            writerReader.GetPosition().ToBegin();
            writerReader.ReadFile();
            resultText.Text = "Reading is over";
        }

        public void ShowMyImage(String fileToDisplay)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap(fileToDisplay);            
        }

        private void choseImageBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chose image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ShowMyImage(ofd.FileName);
                writerReader.GetBlock().SetContainer(new PixelPicture(new Bitmap(pictureBox1.Image)));
                showSpaceValues();
            }
        }

        private void saveImageBut_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save image";
            sfd.Filter = "BMP Image (*.bmp)|*.bmp";
            sfd.DefaultExt = "bmp";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName, pictureBox1.Image.RawFormat);
            }
        }

        private void choseFileBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chose file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                chosenFileName.Text = ofd.FileName;
                showSpaceValues();
            }
        }

        private void blockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(blockNames[box.SelectedIndex]);
            ContainerBlock newBlock = (ContainerBlock)Reflection.CreateObjectByName(blockNames[box.SelectedIndex]);
            if (writerReader.GetBlock() != null)
            {
                newBlock.SetContainer(writerReader.GetContainer());
            }
            else
            {
                newBlock.SetContainer(null);
            }
            newBlock.ParametersReader(newBlock.StandartParameters());
            blockHint.Text = newBlock.HintString();
            if (newBlock.StandartParameters().Equals(""))
            {
                blockParameter.Enabled = false;
            }
            if (writerReader.GetBlock() != null)
            {
                writerReader.GetOrder().SetBlock(newBlock);
                showSpaceValues();
            }
            writerReader.GetOrder().SetBlock(newBlock);
            blockParameter.Text = newBlock.StandartParameters();
        }

        private void orderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(orderNames[box.SelectedIndex]);
            CellOrder newOrder = (CellOrder)Reflection.CreateObjectByName(orderNames[box.SelectedIndex]);
            if (writerReader.GetOrder() != null)
            {
                newOrder.SetBlock(writerReader.GetBlock());
            }
            else
            {
                newOrder.SetBlock(null);
            }
            newOrder.ParametersReader(newOrder.StandartParameters());
            orderHint.Text = newOrder.HintString();
            if (newOrder.StandartParameters().Equals(""))
            {
                orderParameter.Enabled = false;
            }
            if (writerReader.GetOrder() != null)
            {
                writerReader.GetPosition().SetOrder(newOrder);
                showSpaceValues();
            }
            writerReader.GetPosition().SetOrder(newOrder);
            orderParameter.Text = newOrder.StandartParameters();
        }

        private void positionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(positionNames[box.SelectedIndex]);
            CellPosition newPosition = (CellPosition)Reflection.CreateObjectByName(positionNames[box.SelectedIndex]);
            if (writerReader.GetPosition() != null)
            {
                newPosition.SetOrder(writerReader.GetOrder());
            }
            else
            {
                newPosition.SetOrder(null);
            }
            newPosition.ParametersReader(newPosition.StandartParameters());
            positionHint.Text = newPosition.HintString();
            if (newPosition.StandartParameters().Equals(""))
            {
                positionParameter.Enabled = false;
            }
            if (writerReader.GetPosition() != null)
            {
                writerReader.SetPosition(newPosition);
                showSpaceValues();
            }
            writerReader.SetPosition(newPosition);
            positionParameter.Text = newPosition.StandartParameters();
        }

        private void writerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(writerNames[box.SelectedIndex]);
            ContainerWriterReader newWriterReader = (ContainerWriterReader)Reflection.CreateObjectByName(writerNames[box.SelectedIndex]);
            if (writerReader != null)
            {
                newWriterReader.SetPosition(writerReader.GetPosition());
            }
            else
            {
                newWriterReader.SetPosition(null);
            }
            newWriterReader.ParametersReader(newWriterReader.StandartParameters());
            writerHint.Text = newWriterReader.HintString();
            if(newWriterReader.StandartParameters().Equals(""))
            {
                writerParameter.Enabled = false;
            }
            if (writerReader != null)
            {
                writerReader = newWriterReader;
                showSpaceValues();
            }
            writerReader = newWriterReader;
            writerParameter.Text = newWriterReader.StandartParameters();
        }

        private void blockParameter_TextChanged(object sender, EventArgs e)
        {
            if(!writerReader.GetBlock().ParametersReader(blockParameter.Text))
            {
                errorText.Text = "Block parameters is not right. Please change them";
            } else
            {
                showSpaceValues();
                errorText.Text = "";
            }
        }

        private void orderParameter_TextChanged(object sender, EventArgs e)
        {
            if (!writerReader.GetOrder().ParametersReader(orderParameter.Text))
            {
                errorText.Text = "Order parameters is not right. Please change them";
            }
            else
            {
                showSpaceValues();
                errorText.Text = "";
            }
        }

        private void positionParameter_TextChanged(object sender, EventArgs e)
        {
            if (!writerReader.GetPosition().ParametersReader(positionParameter.Text))
            {
                errorText.Text = "Position parameters is not right. Please change them";
            }
            else
            {
                showSpaceValues();
                errorText.Text = "";
            }
        }

        private void writerParameter_TextChanged(object sender, EventArgs e)
        {
            if (!writerReader.ParametersReader(writerParameter.Text))
            {
                errorText.Text = "Writer parameters is not right. Please change them";
            }
            else
            {
                showSpaceValues();
                errorText.Text = "";
            }
        }
    }

}