namespace Stegano.GUI
{
    partial class MainForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private System.Windows.Forms.PictureBox container;
        private System.Windows.Forms.TextBox chosenFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button writeBut;
        private System.Windows.Forms.Button readBut;
        private System.Windows.Forms.Button choseImageBut;
        private System.Windows.Forms.Button saveImageBut;

        private void InitializeComponent()
        {
            this.container = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chosenFileName = new System.Windows.Forms.TextBox();
            this.choseImageBut = new System.Windows.Forms.Button();
            this.saveImageBut = new System.Windows.Forms.Button();
            this.writeBut = new System.Windows.Forms.Button();
            this.readBut = new System.Windows.Forms.Button();
            this.choseFileBut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearImageBut = new System.Windows.Forms.Button();
            this.chosenImageName = new System.Windows.Forms.TextBox();
            this.resultText = new System.Windows.Forms.RichTextBox();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.writerParameter = new System.Windows.Forms.ComboBox();
            this.positionParameter = new System.Windows.Forms.ComboBox();
            this.orderParameter = new System.Windows.Forms.ComboBox();
            this.blockParameter = new System.Windows.Forms.ComboBox();
            this.errorText = new System.Windows.Forms.RichTextBox();
            this.writerHint = new System.Windows.Forms.RichTextBox();
            this.positionHint = new System.Windows.Forms.RichTextBox();
            this.orderHint = new System.Windows.Forms.RichTextBox();
            this.blockHint = new System.Windows.Forms.RichTextBox();
            this.writerLabel = new System.Windows.Forms.Label();
            this.writerList = new System.Windows.Forms.ComboBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionList = new System.Windows.Forms.ComboBox();
            this.OrderLabel = new System.Windows.Forms.Label();
            this.orderList = new System.Windows.Forms.ComboBox();
            this.BlockLabel = new System.Windows.Forms.Label();
            this.blockList = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.preanalysisBut = new System.Windows.Forms.Button();
            this.preanalysisParameters = new System.Windows.Forms.ComboBox();
            this.preanalysisList = new System.Windows.Forms.ComboBox();
            this.preanalysisPicture = new System.Windows.Forms.PictureBox();
            this.analysisParameters = new System.Windows.Forms.ComboBox();
            this.analisysText = new System.Windows.Forms.RichTextBox();
            this.analysisList = new System.Windows.Forms.ComboBox();
            this.AnalisysBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preanalysisPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.InitialImage = null;
            this.container.Location = new System.Drawing.Point(10, 13);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(388, 229);
            this.container.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.container.TabIndex = 0;
            this.container.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File";
            // 
            // chosenFileName
            // 
            this.chosenFileName.Location = new System.Drawing.Point(72, 294);
            this.chosenFileName.Name = "chosenFileName";
            this.chosenFileName.Size = new System.Drawing.Size(239, 20);
            this.chosenFileName.TabIndex = 2;
            // 
            // choseImageBut
            // 
            this.choseImageBut.Location = new System.Drawing.Point(314, 257);
            this.choseImageBut.Name = "choseImageBut";
            this.choseImageBut.Size = new System.Drawing.Size(84, 23);
            this.choseImageBut.TabIndex = 3;
            this.choseImageBut.Text = "Chose image";
            this.choseImageBut.UseVisualStyleBackColor = true;
            this.choseImageBut.Click += new System.EventHandler(this.choseImageBut_Click);
            // 
            // saveImageBut
            // 
            this.saveImageBut.Location = new System.Drawing.Point(10, 326);
            this.saveImageBut.Name = "saveImageBut";
            this.saveImageBut.Size = new System.Drawing.Size(91, 23);
            this.saveImageBut.TabIndex = 4;
            this.saveImageBut.Text = "Save image";
            this.saveImageBut.UseVisualStyleBackColor = true;
            this.saveImageBut.Click += new System.EventHandler(this.saveImageBut_Click);
            // 
            // writeBut
            // 
            this.writeBut.Location = new System.Drawing.Point(210, 326);
            this.writeBut.Name = "writeBut";
            this.writeBut.Size = new System.Drawing.Size(88, 23);
            this.writeBut.TabIndex = 5;
            this.writeBut.Text = "Write file";
            this.writeBut.UseVisualStyleBackColor = true;
            this.writeBut.Click += new System.EventHandler(this.writeBut_Click);
            // 
            // readBut
            // 
            this.readBut.Location = new System.Drawing.Point(304, 326);
            this.readBut.Name = "readBut";
            this.readBut.Size = new System.Drawing.Size(94, 23);
            this.readBut.TabIndex = 6;
            this.readBut.Text = "Read file";
            this.readBut.UseVisualStyleBackColor = true;
            this.readBut.Click += new System.EventHandler(this.readBut_Click);
            // 
            // choseFileBut
            // 
            this.choseFileBut.Location = new System.Drawing.Point(314, 292);
            this.choseFileBut.Name = "choseFileBut";
            this.choseFileBut.Size = new System.Drawing.Size(84, 23);
            this.choseFileBut.TabIndex = 7;
            this.choseFileBut.Text = "Chose file";
            this.choseFileBut.UseVisualStyleBackColor = true;
            this.choseFileBut.Click += new System.EventHandler(this.choseFileBut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.clearImageBut);
            this.groupBox1.Controls.Add(this.container);
            this.groupBox1.Controls.Add(this.chosenImageName);
            this.groupBox1.Controls.Add(this.choseFileBut);
            this.groupBox1.Controls.Add(this.resultText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.readBut);
            this.groupBox1.Controls.Add(this.writeBut);
            this.groupBox1.Controls.Add(this.spaceLabel);
            this.groupBox1.Controls.Add(this.choseImageBut);
            this.groupBox1.Controls.Add(this.chosenFileName);
            this.groupBox1.Controls.Add(this.saveImageBut);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(221, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 448);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Image";
            // 
            // clearImageBut
            // 
            this.clearImageBut.Location = new System.Drawing.Point(107, 326);
            this.clearImageBut.Name = "clearImageBut";
            this.clearImageBut.Size = new System.Drawing.Size(97, 23);
            this.clearImageBut.TabIndex = 20;
            this.clearImageBut.Text = "Clear image";
            this.clearImageBut.UseVisualStyleBackColor = true;
            this.clearImageBut.Click += new System.EventHandler(this.clearImage_Click);
            // 
            // chosenImageName
            // 
            this.chosenImageName.Location = new System.Drawing.Point(72, 259);
            this.chosenImageName.Name = "chosenImageName";
            this.chosenImageName.Size = new System.Drawing.Size(239, 20);
            this.chosenImageName.TabIndex = 19;
            this.chosenImageName.TextChanged += new System.EventHandler(this.chosenImageName_TextChanged);
            // 
            // resultText
            // 
            this.resultText.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultText.Cursor = System.Windows.Forms.Cursors.Default;
            this.resultText.Enabled = false;
            this.resultText.ForeColor = System.Drawing.Color.Red;
            this.resultText.Location = new System.Drawing.Point(6, 383);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(388, 36);
            this.resultText.TabIndex = 17;
            this.resultText.Text = "";
            // 
            // spaceLabel
            // 
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.Location = new System.Drawing.Point(7, 432);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(24, 13);
            this.spaceLabel.TabIndex = 0;
            this.spaceLabel.Text = "0/0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.writerParameter);
            this.groupBox2.Controls.Add(this.positionParameter);
            this.groupBox2.Controls.Add(this.orderParameter);
            this.groupBox2.Controls.Add(this.blockParameter);
            this.groupBox2.Controls.Add(this.errorText);
            this.groupBox2.Controls.Add(this.writerHint);
            this.groupBox2.Controls.Add(this.positionHint);
            this.groupBox2.Controls.Add(this.orderHint);
            this.groupBox2.Controls.Add(this.blockHint);
            this.groupBox2.Controls.Add(this.writerLabel);
            this.groupBox2.Controls.Add(this.writerList);
            this.groupBox2.Controls.Add(this.positionLabel);
            this.groupBox2.Controls.Add(this.positionList);
            this.groupBox2.Controls.Add(this.OrderLabel);
            this.groupBox2.Controls.Add(this.orderList);
            this.groupBox2.Controls.Add(this.BlockLabel);
            this.groupBox2.Controls.Add(this.blockList);
            this.groupBox2.Location = new System.Drawing.Point(3, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 451);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // writerParameter
            // 
            this.writerParameter.FormattingEnabled = true;
            this.writerParameter.Location = new System.Drawing.Point(9, 339);
            this.writerParameter.Name = "writerParameter";
            this.writerParameter.Size = new System.Drawing.Size(197, 21);
            this.writerParameter.TabIndex = 20;
            this.writerParameter.SelectedIndexChanged += new System.EventHandler(this.writerParameter_SelectedIndexChanged);
            // 
            // positionParameter
            // 
            this.positionParameter.FormattingEnabled = true;
            this.positionParameter.Location = new System.Drawing.Point(9, 232);
            this.positionParameter.Name = "positionParameter";
            this.positionParameter.Size = new System.Drawing.Size(197, 21);
            this.positionParameter.TabIndex = 19;
            this.positionParameter.SelectedIndexChanged += new System.EventHandler(this.positionParameter_SelectedIndexChanged);
            // 
            // orderParameter
            // 
            this.orderParameter.FormattingEnabled = true;
            this.orderParameter.Location = new System.Drawing.Point(10, 136);
            this.orderParameter.Name = "orderParameter";
            this.orderParameter.Size = new System.Drawing.Size(197, 21);
            this.orderParameter.TabIndex = 18;
            this.orderParameter.SelectedIndexChanged += new System.EventHandler(this.orderParameter_SelectedIndexChanged);
            // 
            // blockParameter
            // 
            this.blockParameter.FormattingEnabled = true;
            this.blockParameter.Location = new System.Drawing.Point(10, 40);
            this.blockParameter.Name = "blockParameter";
            this.blockParameter.Size = new System.Drawing.Size(197, 21);
            this.blockParameter.TabIndex = 17;
            this.blockParameter.SelectedIndexChanged += new System.EventHandler(this.blockParameter_SelectedIndexChanged);
            // 
            // errorText
            // 
            this.errorText.BackColor = System.Drawing.SystemColors.ControlLight;
            this.errorText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorText.Cursor = System.Windows.Forms.Cursors.Default;
            this.errorText.Enabled = false;
            this.errorText.ForeColor = System.Drawing.Color.Red;
            this.errorText.Location = new System.Drawing.Point(8, 412);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(199, 36);
            this.errorText.TabIndex = 16;
            this.errorText.Text = "";
            // 
            // writerHint
            // 
            this.writerHint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.writerHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.writerHint.Cursor = System.Windows.Forms.Cursors.Default;
            this.writerHint.Enabled = false;
            this.writerHint.Location = new System.Drawing.Point(6, 366);
            this.writerHint.Name = "writerHint";
            this.writerHint.Size = new System.Drawing.Size(200, 36);
            this.writerHint.TabIndex = 14;
            this.writerHint.Text = "";
            // 
            // positionHint
            // 
            this.positionHint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.positionHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.positionHint.Cursor = System.Windows.Forms.Cursors.Default;
            this.positionHint.Enabled = false;
            this.positionHint.Location = new System.Drawing.Point(7, 265);
            this.positionHint.Name = "positionHint";
            this.positionHint.Size = new System.Drawing.Size(199, 36);
            this.positionHint.TabIndex = 12;
            this.positionHint.Text = "";
            // 
            // orderHint
            // 
            this.orderHint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.orderHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderHint.Cursor = System.Windows.Forms.Cursors.Default;
            this.orderHint.Enabled = false;
            this.orderHint.Location = new System.Drawing.Point(7, 163);
            this.orderHint.Name = "orderHint";
            this.orderHint.Size = new System.Drawing.Size(199, 36);
            this.orderHint.TabIndex = 10;
            this.orderHint.Text = "";
            // 
            // blockHint
            // 
            this.blockHint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.blockHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.blockHint.Cursor = System.Windows.Forms.Cursors.Default;
            this.blockHint.Enabled = false;
            this.blockHint.Location = new System.Drawing.Point(7, 64);
            this.blockHint.Name = "blockHint";
            this.blockHint.Size = new System.Drawing.Size(199, 36);
            this.blockHint.TabIndex = 8;
            this.blockHint.Text = "";
            // 
            // writerLabel
            // 
            this.writerLabel.AutoSize = true;
            this.writerLabel.Location = new System.Drawing.Point(6, 310);
            this.writerLabel.Name = "writerLabel";
            this.writerLabel.Size = new System.Drawing.Size(35, 13);
            this.writerLabel.TabIndex = 7;
            this.writerLabel.Text = "Writer";
            // 
            // writerList
            // 
            this.writerList.FormattingEnabled = true;
            this.writerList.Location = new System.Drawing.Point(58, 307);
            this.writerList.Name = "writerList";
            this.writerList.Size = new System.Drawing.Size(148, 21);
            this.writerList.TabIndex = 6;
            this.writerList.SelectedIndexChanged += new System.EventHandler(this.writerList_SelectedIndexChanged);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(6, 208);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(44, 13);
            this.positionLabel.TabIndex = 5;
            this.positionLabel.Text = "Position";
            // 
            // positionList
            // 
            this.positionList.FormattingEnabled = true;
            this.positionList.Location = new System.Drawing.Point(58, 205);
            this.positionList.Name = "positionList";
            this.positionList.Size = new System.Drawing.Size(148, 21);
            this.positionList.TabIndex = 4;
            this.positionList.SelectedIndexChanged += new System.EventHandler(this.positionList_SelectedIndexChanged);
            // 
            // OrderLabel
            // 
            this.OrderLabel.AutoSize = true;
            this.OrderLabel.Location = new System.Drawing.Point(6, 109);
            this.OrderLabel.Name = "OrderLabel";
            this.OrderLabel.Size = new System.Drawing.Size(33, 13);
            this.OrderLabel.TabIndex = 3;
            this.OrderLabel.Text = "Order";
            // 
            // orderList
            // 
            this.orderList.FormattingEnabled = true;
            this.orderList.Location = new System.Drawing.Point(58, 106);
            this.orderList.Name = "orderList";
            this.orderList.Size = new System.Drawing.Size(148, 21);
            this.orderList.TabIndex = 2;
            this.orderList.SelectedIndexChanged += new System.EventHandler(this.orderList_SelectedIndexChanged);
            // 
            // BlockLabel
            // 
            this.BlockLabel.AutoSize = true;
            this.BlockLabel.Location = new System.Drawing.Point(6, 16);
            this.BlockLabel.Name = "BlockLabel";
            this.BlockLabel.Size = new System.Drawing.Size(34, 13);
            this.BlockLabel.TabIndex = 1;
            this.BlockLabel.Text = "Block";
            // 
            // blockList
            // 
            this.blockList.FormattingEnabled = true;
            this.blockList.Location = new System.Drawing.Point(58, 13);
            this.blockList.Name = "blockList";
            this.blockList.Size = new System.Drawing.Size(148, 21);
            this.blockList.TabIndex = 0;
            this.blockList.SelectedIndexChanged += new System.EventHandler(this.blockList_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.preanalysisBut);
            this.groupBox3.Controls.Add(this.preanalysisParameters);
            this.groupBox3.Controls.Add(this.preanalysisList);
            this.groupBox3.Controls.Add(this.preanalysisPicture);
            this.groupBox3.Controls.Add(this.analysisParameters);
            this.groupBox3.Controls.Add(this.analisysText);
            this.groupBox3.Controls.Add(this.analysisList);
            this.groupBox3.Controls.Add(this.AnalisysBut);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(638, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 448);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // preanalysisBut
            // 
            this.preanalysisBut.Location = new System.Drawing.Point(319, 254);
            this.preanalysisBut.Name = "preanalysisBut";
            this.preanalysisBut.Size = new System.Drawing.Size(75, 23);
            this.preanalysisBut.TabIndex = 24;
            this.preanalysisBut.Text = "Show";
            this.preanalysisBut.UseVisualStyleBackColor = true;
            this.preanalysisBut.Click += new System.EventHandler(this.preanalysis_Click);
            // 
            // preanalysisParameters
            // 
            this.preanalysisParameters.FormattingEnabled = true;
            this.preanalysisParameters.Location = new System.Drawing.Point(183, 257);
            this.preanalysisParameters.Name = "preanalysisParameters";
            this.preanalysisParameters.Size = new System.Drawing.Size(130, 21);
            this.preanalysisParameters.TabIndex = 23;
            this.preanalysisParameters.SelectedIndexChanged += new System.EventHandler(this.preanalysisParameters_SelectedIndexChanged);
            // 
            // preanalysisList
            // 
            this.preanalysisList.FormattingEnabled = true;
            this.preanalysisList.Location = new System.Drawing.Point(6, 257);
            this.preanalysisList.Name = "preanalysisList";
            this.preanalysisList.Size = new System.Drawing.Size(171, 21);
            this.preanalysisList.TabIndex = 22;
            this.preanalysisList.SelectedIndexChanged += new System.EventHandler(this.preanalysisList_SelectedIndexChanged);
            // 
            // preanalysisPicture
            // 
            this.preanalysisPicture.InitialImage = null;
            this.preanalysisPicture.Location = new System.Drawing.Point(6, 13);
            this.preanalysisPicture.Name = "preanalysisPicture";
            this.preanalysisPicture.Size = new System.Drawing.Size(388, 229);
            this.preanalysisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preanalysisPicture.TabIndex = 21;
            this.preanalysisPicture.TabStop = false;
            // 
            // analysisParameters
            // 
            this.analysisParameters.FormattingEnabled = true;
            this.analysisParameters.Location = new System.Drawing.Point(183, 296);
            this.analysisParameters.Name = "analysisParameters";
            this.analysisParameters.Size = new System.Drawing.Size(130, 21);
            this.analysisParameters.TabIndex = 20;
            this.analysisParameters.SelectedIndexChanged += new System.EventHandler(this.analisysParameters_SelectedIndexChanged);
            // 
            // analisysText
            // 
            this.analisysText.BackColor = System.Drawing.SystemColors.ControlLight;
            this.analisysText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.analisysText.Cursor = System.Windows.Forms.Cursors.Default;
            this.analisysText.Enabled = false;
            this.analisysText.ForeColor = System.Drawing.Color.Blue;
            this.analisysText.Location = new System.Drawing.Point(0, 383);
            this.analisysText.Name = "analisysText";
            this.analisysText.Size = new System.Drawing.Size(388, 36);
            this.analisysText.TabIndex = 18;
            this.analisysText.Text = "";
            // 
            // analysisList
            // 
            this.analysisList.FormattingEnabled = true;
            this.analysisList.Location = new System.Drawing.Point(6, 296);
            this.analysisList.Name = "analysisList";
            this.analysisList.Size = new System.Drawing.Size(171, 21);
            this.analysisList.TabIndex = 5;
            this.analysisList.SelectedIndexChanged += new System.EventHandler(this.analysisList_SelectedIndexChanged);
            // 
            // AnalisysBut
            // 
            this.AnalisysBut.Location = new System.Drawing.Point(319, 294);
            this.AnalisysBut.Name = "AnalisysBut";
            this.AnalisysBut.Size = new System.Drawing.Size(75, 23);
            this.AnalisysBut.TabIndex = 0;
            this.AnalisysBut.Text = "Analysis";
            this.AnalisysBut.UseVisualStyleBackColor = true;
            this.AnalisysBut.Click += new System.EventHandler(this.Analisys_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1044, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.preanalysisPicture)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button choseFileBut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox blockHint;
        private System.Windows.Forms.Label writerLabel;
        private System.Windows.Forms.ComboBox writerList;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.ComboBox positionList;
        private System.Windows.Forms.Label OrderLabel;
        private System.Windows.Forms.ComboBox orderList;
        private System.Windows.Forms.Label BlockLabel;
        private System.Windows.Forms.ComboBox blockList;
        private System.Windows.Forms.RichTextBox writerHint;
        private System.Windows.Forms.RichTextBox positionHint;
        private System.Windows.Forms.RichTextBox orderHint;
        private System.Windows.Forms.Label spaceLabel;
        private System.Windows.Forms.RichTextBox errorText;
        private System.Windows.Forms.RichTextBox resultText;
        private System.Windows.Forms.ComboBox writerParameter;
        private System.Windows.Forms.ComboBox positionParameter;
        private System.Windows.Forms.ComboBox orderParameter;
        private System.Windows.Forms.ComboBox blockParameter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AnalisysBut;
        private System.Windows.Forms.ComboBox analysisList;
        private System.Windows.Forms.RichTextBox analisysText;
        private System.Windows.Forms.TextBox chosenImageName;
        private System.Windows.Forms.ComboBox analysisParameters;
        private System.Windows.Forms.PictureBox preanalysisPicture;
        private System.Windows.Forms.Button clearImageBut;
        private System.Windows.Forms.Button preanalysisBut;
        private System.Windows.Forms.ComboBox preanalysisParameters;
        private System.Windows.Forms.ComboBox preanalysisList;
        private System.Windows.Forms.Label label2;
    }
}