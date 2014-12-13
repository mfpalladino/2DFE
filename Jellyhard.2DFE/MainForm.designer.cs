
namespace TwoDFE
{
    sealed partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.cmsSectorElementOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.flpParameters = new TwoDFE.UnselectableFlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblZIndex = new System.Windows.Forms.Label();
            this.lblParametersOfSelectedControl = new System.Windows.Forms.Label();
            this.gdvParameters = new TwoDFE.SectorElementParametersDataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGridX = new System.Windows.Forms.Label();
            this.nudGridX = new System.Windows.Forms.NumericUpDown();
            this.lblGridY = new System.Windows.Forms.Label();
            this.nudGridY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flpTopTools = new TwoDFE.UnselectableFlowLayoutPanel();
            this.btnAlignToLeft = new TwoDFE.UnselectableButton();
            this.btnAlignToTop = new TwoDFE.UnselectableButton();
            this.btnAlignToRight = new TwoDFE.UnselectableButton();
            this.btnAlignToBottom = new TwoDFE.UnselectableButton();
            this.btnHorizontalSpacing = new TwoDFE.UnselectableButton();
            this.btnVerticalSpacing = new TwoDFE.UnselectableButton();
            this.btnSendToBack = new TwoDFE.UnselectableButton();
            this.btnBringToFront = new TwoDFE.UnselectableButton();
            this.flpTools = new TwoDFE.UnselectableFlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.saSector = new TwoDFE.SectorArea();
            this.txtFocus = new System.Windows.Forms.TextBox();
            this.pcToolItemPreview = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmsSectorElementOptions.SuspendLayout();
            this.flpParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridY)).BeginInit();
            this.flpTopTools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.saSector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcToolItemPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "txt";
            this.sfdSave.Filter = "Text files|*.txt";
            this.sfdSave.RestoreDirectory = true;
            // 
            // ofdOpen
            // 
            this.ofdOpen.DefaultExt = "txt";
            this.ofdOpen.FileName = "openFileDialog1";
            this.ofdOpen.Filter = "Text files|*.txt";
            this.ofdOpen.RestoreDirectory = true;
            // 
            // cmsSectorElementOptions
            // 
            this.cmsSectorElementOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miParameters});
            this.cmsSectorElementOptions.Name = "cmsSectorElementOptions";
            this.cmsSectorElementOptions.Size = new System.Drawing.Size(239, 26);
            this.cmsSectorElementOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSectorElementOptions_Opening);
            // 
            // miParameters
            // 
            this.miParameters.Name = "miParameters";
            this.miParameters.Size = new System.Drawing.Size(238, 22);
            this.miParameters.Text = "Parameters (selected elements)";
            this.miParameters.Click += new System.EventHandler(this.miParameters_Click);
            // 
            // flpParameters
            // 
            this.flpParameters.AutoScroll = true;
            this.flpParameters.AutoScrollMargin = new System.Drawing.Size(0, 1000);
            this.flpParameters.BackColor = System.Drawing.Color.Gainsboro;
            this.flpParameters.Controls.Add(this.lblTitle);
            this.flpParameters.Controls.Add(this.lblType);
            this.flpParameters.Controls.Add(this.lblName);
            this.flpParameters.Controls.Add(this.lblLeft);
            this.flpParameters.Controls.Add(this.lblTop);
            this.flpParameters.Controls.Add(this.lblZIndex);
            this.flpParameters.Controls.Add(this.lblParametersOfSelectedControl);
            this.flpParameters.Controls.Add(this.gdvParameters);
            this.flpParameters.Controls.Add(this.label6);
            this.flpParameters.Controls.Add(this.lblGridX);
            this.flpParameters.Controls.Add(this.nudGridX);
            this.flpParameters.Controls.Add(this.lblGridY);
            this.flpParameters.Controls.Add(this.nudGridY);
            this.flpParameters.Controls.Add(this.label1);
            this.flpParameters.Controls.Add(this.label7);
            this.flpParameters.Controls.Add(this.label2);
            this.flpParameters.Controls.Add(this.label3);
            this.flpParameters.Controls.Add(this.label4);
            this.flpParameters.Controls.Add(this.label8);
            this.flpParameters.Controls.Add(this.label9);
            this.flpParameters.Controls.Add(this.label5);
            this.flpParameters.Controls.Add(this.label10);
            this.flpParameters.Controls.Add(this.label11);
            this.flpParameters.Controls.Add(this.label12);
            this.flpParameters.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpParameters.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpParameters.Location = new System.Drawing.Point(740, 64);
            this.flpParameters.Name = "flpParameters";
            this.flpParameters.Padding = new System.Windows.Forms.Padding(10, 10, 10, 30);
            this.flpParameters.Size = new System.Drawing.Size(308, 639);
            this.flpParameters.TabIndex = 3;
            this.flpParameters.WrapContents = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Selected element informations";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(13, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "lblType";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "lblName";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(13, 59);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(35, 13);
            this.lblLeft.TabIndex = 2;
            this.lblLeft.Text = "lblLeft";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(13, 72);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(36, 13);
            this.lblTop.TabIndex = 3;
            this.lblTop.Text = "lblTop";
            // 
            // lblZIndex
            // 
            this.lblZIndex.AutoSize = true;
            this.lblZIndex.Location = new System.Drawing.Point(13, 85);
            this.lblZIndex.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.lblZIndex.Name = "lblZIndex";
            this.lblZIndex.Size = new System.Drawing.Size(50, 13);
            this.lblZIndex.TabIndex = 7;
            this.lblZIndex.Text = "lblZIndex";
            // 
            // lblParametersOfSelectedControl
            // 
            this.lblParametersOfSelectedControl.AutoSize = true;
            this.lblParametersOfSelectedControl.Location = new System.Drawing.Point(13, 118);
            this.lblParametersOfSelectedControl.Name = "lblParametersOfSelectedControl";
            this.lblParametersOfSelectedControl.Size = new System.Drawing.Size(63, 13);
            this.lblParametersOfSelectedControl.TabIndex = 0;
            this.lblParametersOfSelectedControl.Text = "Parameters:";
            // 
            // gdvParameters
            // 
            this.gdvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvParameters.Location = new System.Drawing.Point(13, 134);
            this.gdvParameters.Name = "gdvParameters";
            this.gdvParameters.ReadOnly = true;
            this.gdvParameters.Size = new System.Drawing.Size(283, 255);
            this.gdvParameters.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 400);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Grid:";
            // 
            // lblGridX
            // 
            this.lblGridX.AutoSize = true;
            this.lblGridX.Location = new System.Drawing.Point(12, 421);
            this.lblGridX.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.lblGridX.Name = "lblGridX";
            this.lblGridX.Size = new System.Drawing.Size(17, 13);
            this.lblGridX.TabIndex = 10;
            this.lblGridX.Text = "X:";
            // 
            // nudGridX
            // 
            this.nudGridX.Location = new System.Drawing.Point(12, 436);
            this.nudGridX.Margin = new System.Windows.Forms.Padding(2);
            this.nudGridX.Name = "nudGridX";
            this.nudGridX.Size = new System.Drawing.Size(70, 20);
            this.nudGridX.TabIndex = 8;
            this.nudGridX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGridX.ValueChanged += new System.EventHandler(this.nudGridX_ValueChanged);
            this.nudGridX.Leave += new System.EventHandler(this.nudGridX_Leave);
            // 
            // lblGridY
            // 
            this.lblGridY.AutoSize = true;
            this.lblGridY.Location = new System.Drawing.Point(12, 458);
            this.lblGridY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGridY.Name = "lblGridY";
            this.lblGridY.Size = new System.Drawing.Size(17, 13);
            this.lblGridY.TabIndex = 11;
            this.lblGridY.Text = "Y:";
            // 
            // nudGridY
            // 
            this.nudGridY.Location = new System.Drawing.Point(12, 473);
            this.nudGridY.Margin = new System.Windows.Forms.Padding(2);
            this.nudGridY.Name = "nudGridY";
            this.nudGridY.Size = new System.Drawing.Size(70, 20);
            this.nudGridY.TabIndex = 9;
            this.nudGridY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGridY.ValueChanged += new System.EventHandler(this.nudGridY_ValueChanged);
            this.nudGridY.Leave += new System.EventHandler(this.nudGridY_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 503);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Atalhos estranhos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 516);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "ESC: Desmarca a ferramenta atualmente selecionada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 529);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ctrl+A: Elementos selecionados para frente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 542);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ctrl+Z: Elementos selecionados para trás";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 555);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Shift+setas: ajuste fino da posição";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 568);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 26);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ctrl+Shift+W: Assume a largura do elemento selecionado como GridX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 594);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 26);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ctrl+Shift+H: Assume a altura do elemento selecionado como GridY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 620);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Botão direito do mouse em uma área limpa do editor: menu de contexto";
            // 
            // flpTopTools
            // 
            this.flpTopTools.BackColor = System.Drawing.Color.Gainsboro;
            this.flpTopTools.Controls.Add(this.btnAlignToLeft);
            this.flpTopTools.Controls.Add(this.btnAlignToTop);
            this.flpTopTools.Controls.Add(this.btnAlignToRight);
            this.flpTopTools.Controls.Add(this.btnAlignToBottom);
            this.flpTopTools.Controls.Add(this.btnHorizontalSpacing);
            this.flpTopTools.Controls.Add(this.btnVerticalSpacing);
            this.flpTopTools.Controls.Add(this.btnSendToBack);
            this.flpTopTools.Controls.Add(this.btnBringToFront);
            this.flpTopTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTopTools.Location = new System.Drawing.Point(180, 0);
            this.flpTopTools.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.flpTopTools.Name = "flpTopTools";
            this.flpTopTools.Size = new System.Drawing.Size(868, 64);
            this.flpTopTools.TabIndex = 1;
            // 
            // btnAlignToLeft
            // 
            this.btnAlignToLeft.Location = new System.Drawing.Point(3, 3);
            this.btnAlignToLeft.Name = "btnAlignToLeft";
            this.btnAlignToLeft.Size = new System.Drawing.Size(97, 24);
            this.btnAlignToLeft.TabIndex = 0;
            this.btnAlignToLeft.Text = "Align lefts";
            this.btnAlignToLeft.UseVisualStyleBackColor = true;
            this.btnAlignToLeft.Click += new System.EventHandler(this.btnAlignToLeft_Click);
            // 
            // btnAlignToTop
            // 
            this.btnAlignToTop.Location = new System.Drawing.Point(106, 3);
            this.btnAlignToTop.Name = "btnAlignToTop";
            this.btnAlignToTop.Size = new System.Drawing.Size(97, 24);
            this.btnAlignToTop.TabIndex = 1;
            this.btnAlignToTop.Text = "Align tops";
            this.btnAlignToTop.UseVisualStyleBackColor = true;
            this.btnAlignToTop.Click += new System.EventHandler(this.btnAlignToTop_Click);
            // 
            // btnAlignToRight
            // 
            this.btnAlignToRight.Location = new System.Drawing.Point(209, 3);
            this.btnAlignToRight.Name = "btnAlignToRight";
            this.btnAlignToRight.Size = new System.Drawing.Size(97, 24);
            this.btnAlignToRight.TabIndex = 2;
            this.btnAlignToRight.Text = "Align rights";
            this.btnAlignToRight.UseVisualStyleBackColor = true;
            this.btnAlignToRight.Click += new System.EventHandler(this.btnAlignToRight_Click);
            // 
            // btnAlignToBottom
            // 
            this.btnAlignToBottom.Location = new System.Drawing.Point(312, 3);
            this.btnAlignToBottom.Name = "btnAlignToBottom";
            this.btnAlignToBottom.Size = new System.Drawing.Size(97, 24);
            this.btnAlignToBottom.TabIndex = 3;
            this.btnAlignToBottom.Text = "Align bottoms";
            this.btnAlignToBottom.UseVisualStyleBackColor = true;
            this.btnAlignToBottom.Click += new System.EventHandler(this.btnAlignToBottom_Click);
            // 
            // btnHorizontalSpacing
            // 
            this.btnHorizontalSpacing.Location = new System.Drawing.Point(415, 3);
            this.btnHorizontalSpacing.Name = "btnHorizontalSpacing";
            this.btnHorizontalSpacing.Size = new System.Drawing.Size(200, 24);
            this.btnHorizontalSpacing.TabIndex = 4;
            this.btnHorizontalSpacing.Text = "Adjust horizontal spacing";
            this.btnHorizontalSpacing.UseVisualStyleBackColor = true;
            this.btnHorizontalSpacing.Click += new System.EventHandler(this.btnHorizontalSpacing_Click);
            // 
            // btnVerticalSpacing
            // 
            this.btnVerticalSpacing.Location = new System.Drawing.Point(621, 3);
            this.btnVerticalSpacing.Name = "btnVerticalSpacing";
            this.btnVerticalSpacing.Size = new System.Drawing.Size(200, 24);
            this.btnVerticalSpacing.TabIndex = 5;
            this.btnVerticalSpacing.Text = "Adjust vertical spacing";
            this.btnVerticalSpacing.UseVisualStyleBackColor = true;
            this.btnVerticalSpacing.Click += new System.EventHandler(this.btnVerticalSpacing_Click);
            // 
            // btnSendToBack
            // 
            this.btnSendToBack.Location = new System.Drawing.Point(3, 33);
            this.btnSendToBack.Name = "btnSendToBack";
            this.btnSendToBack.Size = new System.Drawing.Size(200, 24);
            this.btnSendToBack.TabIndex = 6;
            this.btnSendToBack.Text = "Send to back";
            this.btnSendToBack.UseVisualStyleBackColor = true;
            this.btnSendToBack.Click += new System.EventHandler(this.btnSendToBack_Click);
            // 
            // btnBringToFront
            // 
            this.btnBringToFront.Location = new System.Drawing.Point(209, 33);
            this.btnBringToFront.Name = "btnBringToFront";
            this.btnBringToFront.Size = new System.Drawing.Size(200, 24);
            this.btnBringToFront.TabIndex = 7;
            this.btnBringToFront.Text = "Bring to front";
            this.btnBringToFront.UseVisualStyleBackColor = true;
            this.btnBringToFront.Click += new System.EventHandler(this.btnBringToFront_Click);
            // 
            // flpTools
            // 
            this.flpTools.AutoScroll = true;
            this.flpTools.AutoScrollMargin = new System.Drawing.Size(0, 1000);
            this.flpTools.BackColor = System.Drawing.Color.Gainsboro;
            this.flpTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTools.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTools.Location = new System.Drawing.Point(0, 0);
            this.flpTools.Name = "flpTools";
            this.flpTools.Padding = new System.Windows.Forms.Padding(10, 10, 10, 30);
            this.flpTools.Size = new System.Drawing.Size(180, 703);
            this.flpTools.TabIndex = 0;
            this.flpTools.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(180, 684);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 19);
            this.panel1.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(5, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 0;
            // 
            // saSector
            // 
            this.saSector.AllowDrop = true;
            this.saSector.AutoScroll = true;
            this.saSector.BackColor = System.Drawing.Color.White;
            this.saSector.ContextMenuStrip = this.cmsSectorElementOptions;
            this.saSector.Controls.Add(this.txtFocus);
            this.saSector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saSector.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.saSector.ImeMode = System.Windows.Forms.ImeMode.On;
            this.saSector.Location = new System.Drawing.Point(180, 64);
            this.saSector.Name = "saSector";
            this.saSector.Size = new System.Drawing.Size(560, 620);
            this.saSector.TabIndex = 12;
            // 
            // txtFocus
            // 
            this.txtFocus.Location = new System.Drawing.Point(-87, 162);
            this.txtFocus.Margin = new System.Windows.Forms.Padding(2);
            this.txtFocus.Name = "txtFocus";
            this.txtFocus.Size = new System.Drawing.Size(76, 20);
            this.txtFocus.TabIndex = 0;
            // 
            // pcToolItemPreview
            // 
            this.pcToolItemPreview.Location = new System.Drawing.Point(474, 326);
            this.pcToolItemPreview.Name = "pcToolItemPreview";
            this.pcToolItemPreview.Size = new System.Drawing.Size(100, 50);
            this.pcToolItemPreview.TabIndex = 13;
            this.pcToolItemPreview.TabStop = false;
            this.pcToolItemPreview.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 646);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ctrl+S: Salvar arquivo atualmente carregado";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 659);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Ctrl+Shift+A: Selecionar tudo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 672);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(270, 26);
            this.label12.TabIndex = 23;
            this.label12.Text = "Shift+Botão esquerdo do mouse: Marca ou desmarca o controle clicado sem afetar a " +
    "seleção";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 703);
            this.Controls.Add(this.pcToolItemPreview);
            this.Controls.Add(this.saSector);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpParameters);
            this.Controls.Add(this.flpTopTools);
            this.Controls.Add(this.flpTools);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 599);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jellyborn sector editor";
            this.cmsSectorElementOptions.ResumeLayout(false);
            this.flpParameters.ResumeLayout(false);
            this.flpParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridY)).EndInit();
            this.flpTopTools.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.saSector.ResumeLayout(false);
            this.saSector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcToolItemPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UnselectableFlowLayoutPanel flpTools;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private UnselectableFlowLayoutPanel flpTopTools;
        private UnselectableButton btnAlignToRight;
        private UnselectableButton btnAlignToBottom;
        private UnselectableButton btnAlignToTop;
        private UnselectableButton btnAlignToLeft;
        private UnselectableButton btnHorizontalSpacing;
        private UnselectableButton btnVerticalSpacing;
        private System.Windows.Forms.ContextMenuStrip cmsSectorElementOptions;
        private System.Windows.Forms.ToolStripMenuItem miParameters;
        private UnselectableFlowLayoutPanel flpParameters;
        private System.Windows.Forms.Label lblParametersOfSelectedControl;
        private SectorElementParametersDataGridView gdvParameters;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblTop;
        private UnselectableButton btnSendToBack;
        private UnselectableButton btnBringToFront;
        private System.Windows.Forms.Label lblZIndex;
        private System.Windows.Forms.NumericUpDown nudGridX;
        private System.Windows.Forms.NumericUpDown nudGridY;
        private System.Windows.Forms.Label lblGridX;
        private System.Windows.Forms.Label lblGridY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private SectorArea saSector;
        private System.Windows.Forms.TextBox txtFocus;
        private System.Windows.Forms.PictureBox pcToolItemPreview;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

