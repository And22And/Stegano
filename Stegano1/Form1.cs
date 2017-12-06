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
            writerReader = (ContainerWriterReader)Reflection.CreateObjectByName(writerNames[0]);
            writerReader.SetPosition((CellPosition)Reflection.CreateObjectByName(positionNames[0]));
            writerReader.GetPosition().SetOrder((CellOrder)Reflection.CreateObjectByName(orderNames[0]));
            writerReader.GetOrder().SetBlock((ContainerBlock)Reflection.CreateObjectByName(blockNames[0]));

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

        private void setParameters(ComboBox box, string[] names)
        {
            box.Items.Clear();
            for (int i = 0; i < names.Length; i++)
            {
                box.Items.Add(names[i]);
            }
            box.SelectedIndex = 0;
        }

        private void showSpaceValues()
        {
            long needed = 0;
            long avaliable = 0;
            FileInfo info = new FileInfo(chosenFileName.Text);
            if (chosenFileName.Text.Length != 0)
            {
                needed = info.Length * 8 + 64 + info.Name.Length * 16;
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
            newBlock.SetContainer(writerReader.GetContainer());
            writerReader.GetOrder().SetBlock(newBlock);
            SetGUI(newBlock, blockParameter, blockHint);
            showSpaceValues();
        }

        private void orderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(orderNames[box.SelectedIndex]);
            CellOrder newOrder = (CellOrder)Reflection.CreateObjectByName(orderNames[box.SelectedIndex]);
            newOrder.SetBlock(writerReader.GetBlock());
            writerReader.GetPosition().SetOrder(newOrder);
            SetGUI(newOrder, orderParameter, orderHint);
            showSpaceValues();
        }

        private void positionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(positionNames[box.SelectedIndex]);
            CellPosition newPosition = (CellPosition)Reflection.CreateObjectByName(positionNames[box.SelectedIndex]);
            newPosition.SetOrder(writerReader.GetOrder());
            writerReader.SetPosition(newPosition);
            SetGUI(newPosition, positionParameter, positionHint);
            showSpaceValues();
        }

        private void writerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Console.WriteLine(writerNames[box.SelectedIndex]);
            ContainerWriterReader newWriterReader = (ContainerWriterReader)Reflection.CreateObjectByName(writerNames[box.SelectedIndex]);
            newWriterReader.SetPosition(writerReader.GetPosition());
            writerReader = newWriterReader;
            SetGUI(newWriterReader, writerParameter, writerHint);
            showSpaceValues();           
        } 
        
        private void SetGUI(GUI gui, ComboBox parameters, RichTextBox hint)
        {
            if (gui.HasParameters())
            {
                setParameters(parameters, gui.AllParameters());
                gui.ParametersReader(parameters.SelectedItem.ToString());
                hint.Text = gui.HintString();
            }
            else
            {
                parameters.Enabled = false;
            }
        }      

        private void blockParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(writerReader.GetBlock(), (ComboBox)sender);
        }

        private void orderParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(writerReader.GetOrder(), (ComboBox)sender);            
        }

        private void positionParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(writerReader.GetPosition(), (ComboBox)sender);
        }

        private void writerParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(writerReader, (ComboBox)sender);
        }

        private void SelectParameter(GUI type, ComboBox sender)
        {
            if (type.HasParameters())
            {
                type.ParametersReader(sender.SelectedItem.ToString());
            }
            showSpaceValues();
        }
    }

}