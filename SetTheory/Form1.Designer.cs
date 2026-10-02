namespace SetTheory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnPng = new Button();
            btnAdd = new Button();
            panelGradient2 = new Gradient.PanelGradient();
            btnDiagram = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panelGradient1 = new Gradient.PanelGradient();
            btnDeleteElemento = new Button();
            flpanel1 = new FlowLayoutPanel();
            btnAddElement = new Button();
            txtElemento = new TextBoxRGB.TextBoxP();
            label3 = new Label();
            lbElements = new ListBox();
            btnColor = new Button();
            btnRemove = new Button();
            label2 = new Label();
            pnlContenedor = new Gradient.PanelGradient();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            lblOp = new Label();
            btnUnion = new Button();
            btnDiff1 = new Button();
            btnInterseccion = new Button();
            btnDiff2 = new Button();
            btnDiffSim = new Button();
            btnClean = new Button();
            lblElemento = new Label();
            label4 = new Label();
            ColorA = new Label();
            textBoxp1 = new TextBoxRGB.TextBoxP();
            label5 = new Label();
            CharUnion = new Button();
            CharInterseccion = new Button();
            CharResta = new Button();
            CharDSimetrica = new Button();
            panelGradient3 = new Gradient.PanelGradient();
            btnPersonalizada = new Button();
            panelGradient2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelGradient1.SuspendLayout();
            pnlContenedor.SuspendLayout();
            panelGradient3.SuspendLayout();
            SuspendLayout();
            // 
            // btnPng
            // 
            btnPng.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPng.BackColor = Color.DarkSlateBlue;
            btnPng.Cursor = Cursors.Hand;
            btnPng.FlatAppearance.BorderSize = 0;
            btnPng.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnPng.FlatStyle = FlatStyle.Flat;
            btnPng.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPng.ForeColor = Color.White;
            btnPng.Image = (Image)resources.GetObject("btnPng.Image");
            btnPng.ImageAlign = ContentAlignment.MiddleLeft;
            btnPng.Location = new Point(1000, 8);
            btnPng.Name = "btnPng";
            btnPng.Size = new Size(123, 35);
            btnPng.TabIndex = 16;
            btnPng.Text = "Exportar PNG";
            btnPng.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPng.UseVisualStyleBackColor = false;
            btnPng.Click += btnPng_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkSlateBlue;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(24, 211);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 30);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Agregar";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // panelGradient2
            // 
            panelGradient2.BackColor = Color.White;
            panelGradient2.Controls.Add(btnDiagram);
            panelGradient2.Controls.Add(label1);
            panelGradient2.Controls.Add(pictureBox1);
            panelGradient2.Controls.Add(btnPng);
            panelGradient2.Dock = DockStyle.Top;
            panelGradient2.ForeColor = Color.Black;
            panelGradient2.GradientBottomColor = Color.Gray;
            panelGradient2.GradientTopColor = Color.Gray;
            panelGradient2.Location = new Point(0, 0);
            panelGradient2.Name = "panelGradient2";
            panelGradient2.Size = new Size(1184, 50);
            panelGradient2.TabIndex = 12;
            // 
            // btnDiagram
            // 
            btnDiagram.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDiagram.BackColor = Color.DarkSlateBlue;
            btnDiagram.Cursor = Cursors.Hand;
            btnDiagram.FlatAppearance.BorderSize = 0;
            btnDiagram.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnDiagram.FlatStyle = FlatStyle.Flat;
            btnDiagram.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiagram.ForeColor = Color.White;
            btnDiagram.Image = (Image)resources.GetObject("btnDiagram.Image");
            btnDiagram.ImageAlign = ContentAlignment.MiddleLeft;
            btnDiagram.Location = new Point(834, 7);
            btnDiagram.Name = "btnDiagram";
            btnDiagram.Size = new Size(160, 38);
            btnDiagram.TabIndex = 19;
            btnDiagram.Text = "Generar Diagrama";
            btnDiagram.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDiagram.UseVisualStyleBackColor = false;
            btnDiagram.Click += btnDiagram_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Gray;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(59, 16);
            label1.Name = "label1";
            label1.Size = new Size(212, 17);
            label1.TabIndex = 18;
            label1.Text = "Generador de Diagramas de Venn";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gray;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // panelGradient1
            // 
            panelGradient1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelGradient1.BackColor = Color.FromArgb(224, 224, 224);
            panelGradient1.Controls.Add(btnDeleteElemento);
            panelGradient1.Controls.Add(flpanel1);
            panelGradient1.Controls.Add(btnAddElement);
            panelGradient1.Controls.Add(txtElemento);
            panelGradient1.Controls.Add(label3);
            panelGradient1.Controls.Add(lbElements);
            panelGradient1.Controls.Add(btnColor);
            panelGradient1.Controls.Add(btnAdd);
            panelGradient1.Controls.Add(btnRemove);
            panelGradient1.Controls.Add(label2);
            panelGradient1.Dock = DockStyle.Left;
            panelGradient1.ForeColor = SystemColors.ActiveCaptionText;
            panelGradient1.GradientBottomColor = Color.Gray;
            panelGradient1.GradientTopColor = Color.Gray;
            panelGradient1.Location = new Point(0, 50);
            panelGradient1.Name = "panelGradient1";
            panelGradient1.Size = new Size(236, 584);
            panelGradient1.TabIndex = 13;
            // 
            // btnDeleteElemento
            // 
            btnDeleteElemento.BackColor = Color.Transparent;
            btnDeleteElemento.Cursor = Cursors.Hand;
            btnDeleteElemento.FlatAppearance.BorderSize = 0;
            btnDeleteElemento.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnDeleteElemento.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnDeleteElemento.FlatStyle = FlatStyle.Flat;
            btnDeleteElemento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDeleteElemento.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteElemento.Image = (Image)resources.GetObject("btnDeleteElemento.Image");
            btnDeleteElemento.Location = new Point(180, 511);
            btnDeleteElemento.Name = "btnDeleteElemento";
            btnDeleteElemento.Size = new Size(44, 35);
            btnDeleteElemento.TabIndex = 23;
            btnDeleteElemento.UseVisualStyleBackColor = false;
            btnDeleteElemento.Click += btnDeleteElemento_Click;
            // 
            // flpanel1
            // 
            flpanel1.BackColor = Color.Gray;
            flpanel1.FlowDirection = FlowDirection.TopDown;
            flpanel1.Location = new Point(12, 51);
            flpanel1.Name = "flpanel1";
            flpanel1.Size = new Size(212, 154);
            flpanel1.TabIndex = 22;
            // 
            // btnAddElement
            // 
            btnAddElement.BackColor = Color.Transparent;
            btnAddElement.Cursor = Cursors.Hand;
            btnAddElement.FlatAppearance.BorderSize = 0;
            btnAddElement.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnAddElement.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            btnAddElement.FlatStyle = FlatStyle.Flat;
            btnAddElement.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddElement.ForeColor = SystemColors.ActiveCaptionText;
            btnAddElement.Image = (Image)resources.GetObject("btnAddElement.Image");
            btnAddElement.Location = new Point(180, 470);
            btnAddElement.Name = "btnAddElement";
            btnAddElement.Size = new Size(44, 35);
            btnAddElement.TabIndex = 18;
            btnAddElement.UseVisualStyleBackColor = false;
            btnAddElement.Click += btnAddElement_Click;
            // 
            // txtElemento
            // 
            txtElemento.BackColor = Color.Gray;
            txtElemento.BorderColor = Color.MidnightBlue;
            txtElemento.BorderFocusColor = Color.FromArgb(128, 128, 255);
            txtElemento.BorderSize = 1;
            txtElemento.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtElemento.ForeColor = Color.Black;
            txtElemento.Holdertext = "\"Agregar Elemento\"";
            txtElemento.Location = new Point(9, 497);
            txtElemento.Margin = new Padding(3, 4, 3, 4);
            txtElemento.Name = "txtElemento";
            txtElemento.Padding = new Padding(2);
            txtElemento.Size = new Size(171, 25);
            txtElemento.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Gray;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(12, 284);
            label3.Name = "label3";
            label3.Size = new Size(71, 17);
            label3.TabIndex = 17;
            label3.Text = "Elementos";
            // 
            // lbElements
            // 
            lbElements.BackColor = Color.Gray;
            lbElements.BorderStyle = BorderStyle.FixedSingle;
            lbElements.ForeColor = SystemColors.ActiveCaptionText;
            lbElements.FormattingEnabled = true;
            lbElements.Location = new Point(7, 304);
            lbElements.Name = "lbElements";
            lbElements.Size = new Size(223, 152);
            lbElements.TabIndex = 16;
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.DarkSlateBlue;
            btnColor.Cursor = Cursors.Hand;
            btnColor.FlatAppearance.BorderSize = 0;
            btnColor.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnColor.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnColor.FlatStyle = FlatStyle.Flat;
            btnColor.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnColor.ForeColor = Color.White;
            btnColor.Image = (Image)resources.GetObject("btnColor.Image");
            btnColor.Location = new Point(79, 247);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(85, 30);
            btnColor.TabIndex = 15;
            btnColor.Text = "Color";
            btnColor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.DarkSlateBlue;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnRemove.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
            btnRemove.Location = new Point(132, 211);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(85, 30);
            btnRemove.TabIndex = 14;
            btnRemove.Text = "Eliminar";
            btnRemove.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Gray;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(12, 31);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 13;
            label2.Text = "Conjuntos";
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.White;
            pnlContenedor.Controls.Add(formsPlot1);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.ForeColor = Color.Black;
            pnlContenedor.GradientBottomColor = Color.Gray;
            pnlContenedor.GradientTopColor = Color.Gray;
            pnlContenedor.Location = new Point(236, 50);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(712, 584);
            pnlContenedor.TabIndex = 15;
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = Color.Gray;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(712, 584);
            formsPlot1.TabIndex = 0;
            formsPlot1.Visible = false;
            // 
            // lblOp
            // 
            lblOp.AutoSize = true;
            lblOp.BackColor = Color.Gray;
            lblOp.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOp.ForeColor = SystemColors.ActiveCaptionText;
            lblOp.Location = new Point(12, 31);
            lblOp.Name = "lblOp";
            lblOp.Size = new Size(130, 17);
            lblOp.TabIndex = 13;
            lblOp.Text = "Operaciones Basicas";
            // 
            // btnUnion
            // 
            btnUnion.BackColor = Color.DarkSlateBlue;
            btnUnion.Cursor = Cursors.Hand;
            btnUnion.FlatAppearance.BorderSize = 0;
            btnUnion.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnUnion.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnUnion.FlatStyle = FlatStyle.Flat;
            btnUnion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnUnion.ForeColor = Color.White;
            btnUnion.Location = new Point(28, 59);
            btnUnion.Name = "btnUnion";
            btnUnion.Size = new Size(179, 30);
            btnUnion.TabIndex = 15;
            btnUnion.Text = "Union (A ∪ B)";
            btnUnion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUnion.UseVisualStyleBackColor = false;
            // 
            // btnDiff1
            // 
            btnDiff1.BackColor = Color.DarkSlateBlue;
            btnDiff1.Cursor = Cursors.Hand;
            btnDiff1.FlatAppearance.BorderSize = 0;
            btnDiff1.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnDiff1.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnDiff1.FlatStyle = FlatStyle.Flat;
            btnDiff1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDiff1.ForeColor = Color.White;
            btnDiff1.Location = new Point(28, 132);
            btnDiff1.Name = "btnDiff1";
            btnDiff1.Size = new Size(179, 30);
            btnDiff1.TabIndex = 16;
            btnDiff1.Text = "Diferencia (A − B)";
            btnDiff1.UseVisualStyleBackColor = false;
            // 
            // btnInterseccion
            // 
            btnInterseccion.BackColor = Color.DarkSlateBlue;
            btnInterseccion.Cursor = Cursors.Hand;
            btnInterseccion.FlatAppearance.BorderSize = 0;
            btnInterseccion.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnInterseccion.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnInterseccion.FlatStyle = FlatStyle.Flat;
            btnInterseccion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnInterseccion.ForeColor = Color.White;
            btnInterseccion.Location = new Point(29, 95);
            btnInterseccion.Name = "btnInterseccion";
            btnInterseccion.Size = new Size(179, 30);
            btnInterseccion.TabIndex = 17;
            btnInterseccion.Text = "Interseccion (A ∩ B)";
            btnInterseccion.UseVisualStyleBackColor = false;
            // 
            // btnDiff2
            // 
            btnDiff2.BackColor = Color.DarkSlateBlue;
            btnDiff2.Cursor = Cursors.Hand;
            btnDiff2.FlatAppearance.BorderSize = 0;
            btnDiff2.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnDiff2.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnDiff2.FlatStyle = FlatStyle.Flat;
            btnDiff2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDiff2.ForeColor = Color.White;
            btnDiff2.Location = new Point(28, 168);
            btnDiff2.Name = "btnDiff2";
            btnDiff2.Size = new Size(179, 30);
            btnDiff2.TabIndex = 18;
            btnDiff2.Text = "Diferencia (B − A)";
            btnDiff2.UseVisualStyleBackColor = false;
            // 
            // btnDiffSim
            // 
            btnDiffSim.BackColor = Color.DarkSlateBlue;
            btnDiffSim.Cursor = Cursors.Hand;
            btnDiffSim.FlatAppearance.BorderSize = 0;
            btnDiffSim.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnDiffSim.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnDiffSim.FlatStyle = FlatStyle.Flat;
            btnDiffSim.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDiffSim.ForeColor = Color.White;
            btnDiffSim.Location = new Point(28, 206);
            btnDiffSim.Name = "btnDiffSim";
            btnDiffSim.Size = new Size(179, 30);
            btnDiffSim.TabIndex = 19;
            btnDiffSim.Text = "Diferencia Simétrica (A △ B)";
            btnDiffSim.UseVisualStyleBackColor = false;
            // 
            // btnClean
            // 
            btnClean.BackColor = Color.DarkSlateBlue;
            btnClean.Cursor = Cursors.Hand;
            btnClean.FlatAppearance.BorderSize = 0;
            btnClean.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnClean.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnClean.FlatStyle = FlatStyle.Flat;
            btnClean.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClean.ForeColor = Color.White;
            btnClean.Image = (Image)resources.GetObject("btnClean.Image");
            btnClean.Location = new Point(28, 262);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(179, 30);
            btnClean.TabIndex = 20;
            btnClean.Text = "Limpiar Seleccion";
            btnClean.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClean.UseVisualStyleBackColor = false;
            // 
            // lblElemento
            // 
            lblElemento.AutoSize = true;
            lblElemento.BackColor = Color.Gray;
            lblElemento.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElemento.ForeColor = SystemColors.ActiveCaptionText;
            lblElemento.Location = new Point(36, 497);
            lblElemento.Name = "lblElemento";
            lblElemento.Size = new Size(106, 17);
            lblElemento.TabIndex = 21;
            lblElemento.Text = "Elementos de A:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Gray;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(17, 558);
            label4.Name = "label4";
            label4.Size = new Size(207, 17);
            label4.TabIndex = 19;
            label4.Text = "Developed by \"Los Algoritmicos\"";
            // 
            // ColorA
            // 
            ColorA.BackColor = Color.Gray;
            ColorA.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ColorA.ForeColor = SystemColors.ActiveCaptionText;
            ColorA.Location = new Point(20, 502);
            ColorA.Name = "ColorA";
            ColorA.Size = new Size(10, 10);
            ColorA.TabIndex = 23;
            // 
            // textBoxp1
            // 
            textBoxp1.BackColor = Color.Gray;
            textBoxp1.BorderColor = Color.MidnightBlue;
            textBoxp1.BorderFocusColor = Color.FromArgb(128, 128, 255);
            textBoxp1.BorderSize = 1;
            textBoxp1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxp1.ForeColor = Color.Black;
            textBoxp1.Holdertext = "\"Ej: AuB∩C\"";
            textBoxp1.Location = new Point(17, 341);
            textBoxp1.Margin = new Padding(3, 4, 3, 4);
            textBoxp1.Name = "textBoxp1";
            textBoxp1.Padding = new Padding(2);
            textBoxp1.Size = new Size(207, 25);
            textBoxp1.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Gray;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(28, 320);
            label5.Name = "label5";
            label5.Size = new Size(170, 17);
            label5.TabIndex = 25;
            label5.Text = "Operaciones Personalizada";
            // 
            // CharUnion
            // 
            CharUnion.BackColor = Color.DarkSlateBlue;
            CharUnion.Cursor = Cursors.Hand;
            CharUnion.FlatAppearance.BorderSize = 0;
            CharUnion.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            CharUnion.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            CharUnion.FlatStyle = FlatStyle.Flat;
            CharUnion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CharUnion.ForeColor = Color.White;
            CharUnion.Image = (Image)resources.GetObject("CharUnion.Image");
            CharUnion.Location = new Point(31, 388);
            CharUnion.Name = "CharUnion";
            CharUnion.Size = new Size(30, 30);
            CharUnion.TabIndex = 26;
            CharUnion.UseVisualStyleBackColor = false;
            // 
            // CharInterseccion
            // 
            CharInterseccion.BackColor = Color.DarkSlateBlue;
            CharInterseccion.Cursor = Cursors.Hand;
            CharInterseccion.FlatAppearance.BorderSize = 0;
            CharInterseccion.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            CharInterseccion.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            CharInterseccion.FlatStyle = FlatStyle.Flat;
            CharInterseccion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CharInterseccion.ForeColor = Color.White;
            CharInterseccion.Image = (Image)resources.GetObject("CharInterseccion.Image");
            CharInterseccion.Location = new Point(80, 388);
            CharInterseccion.Name = "CharInterseccion";
            CharInterseccion.Size = new Size(30, 30);
            CharInterseccion.TabIndex = 27;
            CharInterseccion.UseVisualStyleBackColor = false;
            // 
            // CharResta
            // 
            CharResta.BackColor = Color.DarkSlateBlue;
            CharResta.Cursor = Cursors.Hand;
            CharResta.FlatAppearance.BorderSize = 0;
            CharResta.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            CharResta.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            CharResta.FlatStyle = FlatStyle.Flat;
            CharResta.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CharResta.ForeColor = Color.White;
            CharResta.Image = (Image)resources.GetObject("CharResta.Image");
            CharResta.Location = new Point(129, 388);
            CharResta.Name = "CharResta";
            CharResta.Size = new Size(30, 30);
            CharResta.TabIndex = 28;
            CharResta.UseVisualStyleBackColor = false;
            // 
            // CharDSimetrica
            // 
            CharDSimetrica.BackColor = Color.DarkSlateBlue;
            CharDSimetrica.Cursor = Cursors.Hand;
            CharDSimetrica.FlatAppearance.BorderSize = 0;
            CharDSimetrica.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            CharDSimetrica.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            CharDSimetrica.FlatStyle = FlatStyle.Flat;
            CharDSimetrica.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CharDSimetrica.ForeColor = Color.White;
            CharDSimetrica.Image = (Image)resources.GetObject("CharDSimetrica.Image");
            CharDSimetrica.Location = new Point(178, 388);
            CharDSimetrica.Name = "CharDSimetrica";
            CharDSimetrica.Size = new Size(30, 30);
            CharDSimetrica.TabIndex = 29;
            CharDSimetrica.UseVisualStyleBackColor = false;
            // 
            // panelGradient3
            // 
            panelGradient3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelGradient3.BackColor = Color.FromArgb(224, 224, 224);
            panelGradient3.Controls.Add(btnPersonalizada);
            panelGradient3.Controls.Add(CharDSimetrica);
            panelGradient3.Controls.Add(CharResta);
            panelGradient3.Controls.Add(CharInterseccion);
            panelGradient3.Controls.Add(CharUnion);
            panelGradient3.Controls.Add(label5);
            panelGradient3.Controls.Add(textBoxp1);
            panelGradient3.Controls.Add(ColorA);
            panelGradient3.Controls.Add(label4);
            panelGradient3.Controls.Add(lblElemento);
            panelGradient3.Controls.Add(btnClean);
            panelGradient3.Controls.Add(btnDiffSim);
            panelGradient3.Controls.Add(btnDiff2);
            panelGradient3.Controls.Add(btnInterseccion);
            panelGradient3.Controls.Add(btnDiff1);
            panelGradient3.Controls.Add(btnUnion);
            panelGradient3.Controls.Add(lblOp);
            panelGradient3.Dock = DockStyle.Right;
            panelGradient3.ForeColor = SystemColors.ActiveCaptionText;
            panelGradient3.GradientBottomColor = Color.Gray;
            panelGradient3.GradientTopColor = Color.Gray;
            panelGradient3.Location = new Point(948, 50);
            panelGradient3.Name = "panelGradient3";
            panelGradient3.Size = new Size(236, 584);
            panelGradient3.TabIndex = 14;
            // 
            // btnPersonalizada
            // 
            btnPersonalizada.BackColor = Color.DarkSlateBlue;
            btnPersonalizada.Cursor = Cursors.Hand;
            btnPersonalizada.FlatAppearance.BorderSize = 0;
            btnPersonalizada.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btnPersonalizada.FlatAppearance.MouseOverBackColor = Color.FromArgb(86, 81, 151);
            btnPersonalizada.FlatStyle = FlatStyle.Flat;
            btnPersonalizada.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnPersonalizada.ForeColor = Color.White;
            btnPersonalizada.Location = new Point(29, 426);
            btnPersonalizada.Name = "btnPersonalizada";
            btnPersonalizada.Size = new Size(179, 30);
            btnPersonalizada.TabIndex = 30;
            btnPersonalizada.Text = "Generar Operacion";
            btnPersonalizada.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPersonalizada.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1184, 634);
            Controls.Add(pnlContenedor);
            Controls.Add(panelGradient3);
            Controls.Add(panelGradient1);
            Controls.Add(panelGradient2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VennEasy";
            Load += Form1_Load;
            panelGradient2.ResumeLayout(false);
            panelGradient2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelGradient1.ResumeLayout(false);
            panelGradient1.PerformLayout();
            pnlContenedor.ResumeLayout(false);
            panelGradient3.ResumeLayout(false);
            panelGradient3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Gradient.PanelGradient panelGradient2;
        private Gradient.PanelGradient panelGradient1;
        private Button btnColor;
        private Button btnAdd;
        private Button btnRemove;
        private Label label2;
        private Button btnPng;
        private PictureBox pictureBox1;
        private Label label1;
        private Gradient.PanelGradient pnlContenedor;
        private Label label3;
        private TextBoxRGB.TextBoxP txtElemento;
        private Button btnAddElement;
        private Button btnDiagram;
        public ListBox lbElements;
        private FlowLayoutPanel flpanel1;
        private Button btnDeleteElemento;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label lblOp;
        private Button btnUnion;
        private Button btnDiff1;
        private Button btnInterseccion;
        private Button btnDiff2;
        private Button btnDiffSim;
        private Button btnClean;
        public Label lblElemento;
        private Label label4;
        public Label ColorA;
        private TextBoxRGB.TextBoxP textBoxp1;
        private Label label5;
        private Button CharUnion;
        private Button CharInterseccion;
        private Button CharResta;
        private Button CharDSimetrica;
        public Gradient.PanelGradient panelGradient3;
        private Button btnPersonalizada;
    }
}
