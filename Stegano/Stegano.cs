﻿using Stegano.Analisys;
using Stegano.Block;
using Stegano.Order;
using Stegano.Position;
using Stegano.WriterReader;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Stegano
{
    public partial class Stegano : Form
    {
        delegate void SetTextCallback(string text);

        private static string blockClass = "Stegano.Block.ModuleBlock";
        private static string orderClass = "Stegano.Order.ModuleOrder";
        private static string positionClass = "Stegano.Position.ModulePosition";
        private static string writerClass = "Stegano.WriterReader.ModuleWriterReader";
        private static string analysisClass = "Stegano.Analisys.AnalisysHistogram";
        private string[] blockNames;
        private string[] orderNames;
        private string[] positionNames;
        private string[] writerNames;
        private string[] analisysNames;
        private ModuleWriterReader writerReader = null;
        private AnalisysHistogram histogram;
        private static int cellToWrite;

        public Stegano()
        {
            InitializeComponent();    
            writerNames = Reflection.GetTypesNames(writerClass);
            positionNames = Reflection.GetTypesNames(positionClass);
            orderNames = Reflection.GetTypesNames(orderClass);
            blockNames = Reflection.GetTypesNames(blockClass);
            analisysNames = Reflection.GetTypesNames(analysisClass);

            writerReader = (ModuleWriterReader)Reflection.CreateObjectByName(writerNames[0]);
            writerReader.SetPosition((ModulePosition)Reflection.CreateObjectByName(positionNames[0]));
            writerReader.GetPosition().SetOrder((ModuleOrder)Reflection.CreateObjectByName(orderNames[0]));
            writerReader.GetOrder().SetBlock((ModuleBlock)Reflection.CreateObjectByName(blockNames[0]));
            histogram = (AnalisysHistogram)Reflection.CreateObjectByName(analisysNames[0]);

            setList(writerList, writerNames);
            setList(positionList, positionNames);
            setList(orderList, orderNames);
            setList(blockList, blockNames);
            setList(analysisList, analisysNames);

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

        private bool showSpaceValues()
        {
            int needed = 0;
            int avaliable = 0;            
            if (File.Exists(chosenFileName.Text))
            {
                FileInfo info = new FileInfo(chosenFileName.Text);
                needed = (int)info.Length * 8 + 64 + info.Name.Length * 16;
                cellToWrite = needed/writerReader.BitsPerPixel();
            }
            if (pictureBox1.Image != null)
            {
                avaliable = writerReader.getAvaliableSpace();
                writerReader.AfterChange();
            }
            string status = avaliable >= needed ? "OK" : "Not enough to contain file";             
            spaceLabel.Text = needed + "/" + avaliable + " " + status;
            return avaliable > needed && needed != 0;
        }

        public static int GetDataSize()
        {
            return cellToWrite;
        }

        public static void SetDataSize(int size)
        {
            cellToWrite = size;
        }

        private void writeBut_Click(object sender, EventArgs e)
        {
            if(!File.Exists(chosenFileName.Text))
            {
                resultText.Text = "File does not exist";
            }
            else if (pictureBox1.Image == null)
            {
                resultText.Text = "Picture is not set";
            }
            else if (showSpaceValues())
            {
                Write();
            } else
            {
                resultText.Text = "Chosen modules and image is not enough to contain file";
            }
        }

        private void Write()
        {
            try
            {
                resultText.Text = "Writing is started";
                FileInfo info = new FileInfo(chosenFileName.Text);
                writerReader.WriteFile(info.Name, HideFile.ReadBitArray(info.FullName));
                pictureBox1.Image = new Bitmap(writerReader.GetContainer().image);
                resultText.Text = "Writing is over";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                resultText.Text = "Error during writing";
                writerReader.GetBlock().SetContainer(new PixelPicture(new Bitmap(pictureBox1.Image)));
            }
        }

        private void readBut_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Read();
            } else
            {
                resultText.Text = "Picture needed to be set for reading";
            }
        }

        private void Read()
        {
            try
            {
                resultText.Text = "Start readingt";
                writerReader.ReadFile();
                resultText.Text = "Reading is over";
            }
            catch (Exception e)
            {
                resultText.Text = "Error during reading: check your methods selecting";
            }
        }

        public void ShowMyImage(String fileToDisplay)
        {
            try
            {
                pictureBox1.Image = new Bitmap(fileToDisplay);
                chosenImageName.Text = fileToDisplay;
                writerReader.GetBlock().SetContainer(new PixelPicture(new Bitmap(pictureBox1.Image)));
                showSpaceValues();
            }
            catch(Exception e)
            {
                resultText.Text = "Error during open picture " + fileToDisplay;
            }         
        }

        private void choseImageBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chose image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ShowMyImage(ofd.FileName);               
            }
        }

        private void chosenImageName_TextChanged(object sender, EventArgs e)
        {
            ShowMyImage(((TextBox)sender).Text);
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
            ModuleBlock newBlock = (ModuleBlock)Reflection.CreateObjectByName(blockNames[box.SelectedIndex]);
            newBlock.SetContainer(writerReader.GetContainer());
            writerReader.GetOrder().SetBlock(newBlock);
            SetGUI(newBlock, blockParameter, blockHint);
            showSpaceValues();
        }

        private void orderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ModuleOrder newOrder = (ModuleOrder)Reflection.CreateObjectByName(orderNames[box.SelectedIndex]);
            newOrder.SetBlock(writerReader.GetBlock());
            writerReader.GetPosition().SetOrder(newOrder);
            SetGUI(newOrder, orderParameter, orderHint);
            showSpaceValues();
        }

        private void positionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ModulePosition newPosition = (ModulePosition)Reflection.CreateObjectByName(positionNames[box.SelectedIndex]);
            newPosition.SetOrder(writerReader.GetOrder());
            writerReader.SetPosition(newPosition);
            SetGUI(newPosition, positionParameter, positionHint);
            showSpaceValues();
        }

        private void writerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ModuleWriterReader newWriterReader = (ModuleWriterReader)Reflection.CreateObjectByName(writerNames[box.SelectedIndex]);
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
                parameters.Enabled = true;
            }
            else
            {
                parameters.Items.Clear();
                parameters.Items.Add("");
                parameters.SelectedIndex = 0;
                hint.Text = "";
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

        private void analysisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            histogram = (AnalisysHistogram)Reflection.CreateObjectByName(analisysNames[box.SelectedIndex]);
            if (histogram.HasParameters())
            {
                setParameters(analisysParameters, histogram.AllParameters());
                histogram.ParametersReader(analisysParameters.SelectedItem.ToString());
                analisysParameters.Enabled = true;
            }
            else
            {
                analisysParameters.Items.Clear();
                analisysParameters.Items.Add("");
                analisysParameters.SelectedIndex = 0;
                analisysParameters.Enabled = false;
            }
            histogram = histogram;
        }

        private void analisysParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(histogram, (ComboBox)sender);
        }

        private void Analisys_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                resultText.Text = "Picture is not set";
            }
            else
            {
                AnalisysHistogram hist = (AnalisysHistogram)histogram.Clone();
                Thread newThread = new Thread(parametrs => this.AnalisysThread(hist));                
                newThread.Start();
            }
        }

        private void AnalisysThread(AnalisysHistogram hist)
        {
            SetAnalisysText("Analisys is started");
            AnalisysForm form = new AnalisysForm(new Bitmap(pictureBox1.Image), hist);
            Application.Run(form);
            SetAnalisysText("Analisys is over");
        }

        private void SetAnalisysText(string text)
        {
            if (analisysText.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetAnalisysText);
                Invoke(d, new object[] { text });
            }
            else
            {
                analisysText.Text = text;
            }
        }
    }

}