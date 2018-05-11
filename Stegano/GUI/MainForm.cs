using Stegano.Analysis;
using Stegano.Block;
using Stegano.Container;
using Stegano.Order;
using Stegano.Position;
using Stegano.WriterReader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Stegano.GUI
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string text);

        private static string blockClass = "Stegano.Block.ModuleBlock";
        private static string orderClass = "Stegano.Order.ModuleOrder";
        private static string positionClass = "Stegano.Position.ModulePosition";
        private static string writerClass = "Stegano.WriterReader.ModuleWriterReader";
        private static string analysisClass = "Stegano.Analysis.AnalysisUI";
        private static string preanalysisClass = "Stegano.Analysis.PixelShow";
        private List<string> blockNames;
        private List<string> orderNames;
        private List<string> positionNames;
        private List<string> writerNames;
        private List<string> analysisNames;
        private List<string> preanalysisNames;
        private ModuleWriterReader writerReader = null;
        private AnalysisUI analysis;
        private PixelShow preanalysis;
        private static int cellToWrite;

        public MainForm()
        {
            InitializeComponent();

            writerNames = ClearList(new List<string>(Reflection.GetTypesNames(writerClass)));
            positionNames = ClearList(new List<string>(Reflection.GetTypesNames(positionClass)));
            orderNames = ClearList(new List<string>(Reflection.GetTypesNames(orderClass)));
            blockNames = ClearList(new List<string>(Reflection.GetTypesNames(blockClass)));
            analysisNames = ClearList(new List<string>(Reflection.GetTypesNames(analysisClass)));
            preanalysisNames = ClearList(new List<string>(Reflection.GetTypesNames(preanalysisClass)));

            writerReader = (ModuleWriterReader)Reflection.CreateObjectByName(writerNames[0]);
            writerReader.SetPosition((ModulePosition)Reflection.CreateObjectByName(positionNames[0]));
            writerReader.GetPosition().SetOrder((ModuleOrder)Reflection.CreateObjectByName(orderNames[0]));
            writerReader.GetOrder().SetBlock((ModuleBlock)Reflection.CreateObjectByName(blockNames[0]));

            setList(writerList, writerNames);
            setList(positionList, positionNames);
            setList(orderList, orderNames);
            setList(blockList, blockNames);
            setList(analysisList, analysisNames);
            setList(preanalysisList, preanalysisNames);

            showSpaceValues();
        }

        private List<string> ClearList(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                UI item;
                if (!Reflection.TypeByName(names[i]).IsAbstract && (item = (UI)Reflection.CreateObjectByName(names[i])).IsShown())
                {
                    if (item.GetName().Equals("None"))
                    {
                        string noneName = names[i];
                        names.RemoveAt(i);
                        names.Insert(0, noneName);
                    }
                }
                else
                {
                    names.RemoveAt(i);
                }
            }
            return names;
        }

        private void setList(ComboBox box, List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                UI item = (UI)Reflection.CreateObjectByName(names[i]);
                box.Items.Add(item.GetName());
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
            if (container.Image != null)
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
            else if (container.Image == null)
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
                container.Image = new Bitmap(writerReader.GetContainer().GetPicture());
                resultText.Text = "Writing is over";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                resultText.Text = "Error during writing";
                writerReader.GetBlock().SetContainer(new PixelPicture(new Bitmap(container.Image)));
            }
        }

        private void readBut_Click(object sender, EventArgs e)
        {
            if (container.Image != null)
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
                container.Image = new Bitmap(fileToDisplay);
                chosenImageName.Text = fileToDisplay;
                writerReader.GetBlock().SetContainer(new PixelPicture(new Bitmap(container.Image)));
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
                container.Image.Save(sfd.FileName, container.Image.RawFormat);
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

        private void SetGUI(UI gui, ComboBox parameters, RichTextBox hint)
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
                hint.Text = gui.HintString();
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

        private void SelectParameter(UI type, ComboBox sender)
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
            analysis = (AnalysisUI)Reflection.CreateObjectByName(analysisNames[box.SelectedIndex]);
            if (analysis.HasParameters())
            {
                setParameters(analysisParameters, analysis.AllParameters());
                analysis.ParametersReader(analysisParameters.SelectedItem.ToString());
                analysisParameters.Enabled = true;
            }
            else
            {
                analysisParameters.Items.Clear();
                analysisParameters.Items.Add("");
                analysisParameters.SelectedIndex = 0;
                analysisParameters.Enabled = false;
            }
        }

        private void analisysParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(analysis, (ComboBox)sender);
        }

        private void Analisys_Click(object sender, EventArgs e)
        {
            if (container.Image == null)
            {
                analisysText.Text = "Picture is not set";
            }
            else
            {
                AnalysisUI hist = (AnalysisUI)analysis.Clone();
                Thread newThread = new Thread(parametrs => this.AnalisysThread(hist));                
                newThread.Start();
            }
        }

        private void AnalisysThread(AnalysisUI hist)
        {
            SetAnalisysText("Analysis is started");
            AnalysisFormInterface form = (AnalysisFormInterface)Reflection.CreateObjectByName(hist.GetFormName());
            form.SetAnalysisParameters(new Bitmap(container.Image), hist);
            Application.Run((Form)form);
            SetAnalisysText("Analysis is over");
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

        private void clearImage_Click(object sender, EventArgs e)
        {
            ShowMyImage(chosenImageName.Text);
        }

        private void preanalysis_Click(object sender, EventArgs e)
        {
            if (!File.Exists(chosenFileName.Text))
            {
                analisysText.Text = "File does not exist";
            }
            else if (container.Image == null)
            {
                analisysText.Text = "Picture is not set";
            }
            else if (showSpaceValues())
            {
                Preanalysis();
            }
            else
            {
                analisysText.Text = "Chosen modules and image is not enough to contain file";
            }
        }

        private void Preanalysis()
        {
            try
            {
                analisysText.Text = "Preanalysis is started";
                FileInfo info = new FileInfo(chosenFileName.Text);
                preanalysis.SetWriterReader(writerReader);
                preanalysis.WritePicture(info.Name, HideFile.ReadBitArray(info.FullName));
                preanalysisPicture.Image = new Bitmap(preanalysis.GetPicture().GetPicture());
                analisysText.Text = "Preanalysis is over";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                analisysText.Text = "Error during preanalysis";
                writerReader.GetBlock().SetContainer(new PixelPicture(new Bitmap(container.Image)));
            }
        }

        private void preanalysisParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParameter(preanalysis, (ComboBox)sender);
        }

        private void preanalysisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            preanalysis = (PixelShow)Reflection.CreateObjectByName(preanalysisNames[box.SelectedIndex]);
            if (preanalysis.HasParameters())
            {
                setParameters(preanalysisParameters, preanalysis.AllParameters());
                preanalysis.ParametersReader(preanalysisParameters.SelectedItem.ToString());
                preanalysisParameters.Enabled = true;
            }
            else
            {
                preanalysisParameters.Items.Clear();
                preanalysisParameters.Items.Add("");
                preanalysisParameters.SelectedIndex = 0;
                preanalysisParameters.Enabled = false;
            }
        }
    }

}