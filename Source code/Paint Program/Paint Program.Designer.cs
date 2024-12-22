namespace Paint_Program
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
            panel1 = new Panel();
            color_picker = new PictureBox();
            btn_text = new Button();
            btn_line = new Button();
            btn_rectangle = new Button();
            btn_elipse = new Button();
            btn_pencil = new Button();
            btn_eraser = new Button();
            btn_fill = new Button();
            btn_color = new Button();
            pic_color = new Button();
            btn_font = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            strokeSizeComboBox = new ComboBox();
            pic = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            fontDialog1 = new FontDialog();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)color_picker).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSlateGray;
            panel1.Controls.Add(color_picker);
            panel1.Controls.Add(btn_text);
            panel1.Controls.Add(btn_line);
            panel1.Controls.Add(btn_rectangle);
            panel1.Controls.Add(btn_elipse);
            panel1.Controls.Add(btn_pencil);
            panel1.Controls.Add(btn_eraser);
            panel1.Controls.Add(btn_fill);
            panel1.Controls.Add(btn_color);
            panel1.Controls.Add(pic_color);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 652);
            panel1.TabIndex = 0;
            // 
            // color_picker
            // 
            color_picker.Anchor = AnchorStyles.Left;
            color_picker.Image = (Image)resources.GetObject("color_picker.Image");
            color_picker.Location = new Point(18, 468);
            color_picker.Name = "color_picker";
            color_picker.Size = new Size(128, 128);
            color_picker.SizeMode = PictureBoxSizeMode.StretchImage;
            color_picker.TabIndex = 9;
            color_picker.TabStop = false;
            color_picker.MouseClick += color_picker_MouseClick;
            // 
            // btn_text
            // 
            btn_text.Anchor = AnchorStyles.Left;
            btn_text.Cursor = Cursors.Hand;
            btn_text.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_text.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_text.FlatStyle = FlatStyle.Flat;
            btn_text.ForeColor = Color.White;
            btn_text.Image = (Image)resources.GetObject("btn_text.Image");
            btn_text.ImageAlign = ContentAlignment.TopCenter;
            btn_text.Location = new Point(12, 363);
            btn_text.Name = "btn_text";
            btn_text.Size = new Size(64, 64);
            btn_text.TabIndex = 7;
            btn_text.Text = "Text";
            btn_text.TextAlign = ContentAlignment.BottomCenter;
            btn_text.UseVisualStyleBackColor = true;
            btn_text.Click += btn_text_Click;
            // 
            // btn_line
            // 
            btn_line.Anchor = AnchorStyles.Left;
            btn_line.Cursor = Cursors.Hand;
            btn_line.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_line.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_line.FlatStyle = FlatStyle.Flat;
            btn_line.ForeColor = Color.White;
            btn_line.Image = Properties.Resources.line;
            btn_line.ImageAlign = ContentAlignment.TopCenter;
            btn_line.Location = new Point(82, 224);
            btn_line.Name = "btn_line";
            btn_line.Size = new Size(64, 64);
            btn_line.TabIndex = 6;
            btn_line.Text = "Line";
            btn_line.TextAlign = ContentAlignment.BottomCenter;
            btn_line.UseVisualStyleBackColor = true;
            btn_line.Click += btn_line_Click;
            // 
            // btn_rectangle
            // 
            btn_rectangle.Anchor = AnchorStyles.Left;
            btn_rectangle.Cursor = Cursors.Hand;
            btn_rectangle.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_rectangle.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_rectangle.FlatStyle = FlatStyle.Flat;
            btn_rectangle.ForeColor = Color.White;
            btn_rectangle.Image = Properties.Resources.rectangle;
            btn_rectangle.ImageAlign = ContentAlignment.TopCenter;
            btn_rectangle.Location = new Point(12, 294);
            btn_rectangle.Name = "btn_rectangle";
            btn_rectangle.Size = new Size(134, 64);
            btn_rectangle.TabIndex = 5;
            btn_rectangle.Text = "Rectangle";
            btn_rectangle.TextAlign = ContentAlignment.BottomCenter;
            btn_rectangle.UseVisualStyleBackColor = true;
            btn_rectangle.Click += btn_rectangle_Click;
            // 
            // btn_elipse
            // 
            btn_elipse.Anchor = AnchorStyles.Left;
            btn_elipse.Cursor = Cursors.Hand;
            btn_elipse.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_elipse.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_elipse.FlatStyle = FlatStyle.Flat;
            btn_elipse.ForeColor = Color.White;
            btn_elipse.Image = Properties.Resources.circle;
            btn_elipse.ImageAlign = ContentAlignment.TopCenter;
            btn_elipse.Location = new Point(12, 224);
            btn_elipse.Name = "btn_elipse";
            btn_elipse.Size = new Size(64, 64);
            btn_elipse.TabIndex = 4;
            btn_elipse.Text = "Elipse";
            btn_elipse.TextAlign = ContentAlignment.BottomCenter;
            btn_elipse.UseVisualStyleBackColor = true;
            btn_elipse.Click += btn_elipse_Click;
            // 
            // btn_pencil
            // 
            btn_pencil.Anchor = AnchorStyles.Left;
            btn_pencil.Cursor = Cursors.Hand;
            btn_pencil.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_pencil.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_pencil.FlatStyle = FlatStyle.Flat;
            btn_pencil.ForeColor = Color.White;
            btn_pencil.Image = Properties.Resources.pencil;
            btn_pencil.ImageAlign = ContentAlignment.MiddleLeft;
            btn_pencil.Location = new Point(12, 154);
            btn_pencil.Name = "btn_pencil";
            btn_pencil.Size = new Size(64, 64);
            btn_pencil.TabIndex = 3;
            btn_pencil.Text = "Pencil";
            btn_pencil.TextAlign = ContentAlignment.BottomCenter;
            btn_pencil.UseVisualStyleBackColor = true;
            btn_pencil.Click += btn_pencil_Click;
            // 
            // btn_eraser
            // 
            btn_eraser.Anchor = AnchorStyles.Left;
            btn_eraser.Cursor = Cursors.Hand;
            btn_eraser.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_eraser.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_eraser.FlatStyle = FlatStyle.Flat;
            btn_eraser.ForeColor = Color.White;
            btn_eraser.Image = Properties.Resources.eraser;
            btn_eraser.ImageAlign = ContentAlignment.MiddleLeft;
            btn_eraser.Location = new Point(82, 154);
            btn_eraser.Name = "btn_eraser";
            btn_eraser.Size = new Size(64, 64);
            btn_eraser.TabIndex = 3;
            btn_eraser.Text = "Eraser";
            btn_eraser.TextAlign = ContentAlignment.BottomCenter;
            btn_eraser.UseVisualStyleBackColor = true;
            btn_eraser.Click += btn_eraser_Click;
            // 
            // btn_fill
            // 
            btn_fill.Anchor = AnchorStyles.Left;
            btn_fill.Cursor = Cursors.Hand;
            btn_fill.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_fill.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_fill.FlatStyle = FlatStyle.Flat;
            btn_fill.ForeColor = Color.White;
            btn_fill.Image = Properties.Resources.bucket;
            btn_fill.Location = new Point(82, 84);
            btn_fill.Name = "btn_fill";
            btn_fill.Size = new Size(64, 64);
            btn_fill.TabIndex = 2;
            btn_fill.Text = "Fill";
            btn_fill.TextAlign = ContentAlignment.BottomCenter;
            btn_fill.UseVisualStyleBackColor = true;
            btn_fill.Click += btn_fill_Click;
            // 
            // btn_color
            // 
            btn_color.Anchor = AnchorStyles.Left;
            btn_color.Cursor = Cursors.Hand;
            btn_color.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            btn_color.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            btn_color.FlatStyle = FlatStyle.Flat;
            btn_color.ForeColor = Color.White;
            btn_color.Image = Properties.Resources.color;
            btn_color.Location = new Point(12, 84);
            btn_color.Name = "btn_color";
            btn_color.Size = new Size(64, 64);
            btn_color.TabIndex = 1;
            btn_color.Text = "color";
            btn_color.TextAlign = ContentAlignment.BottomCenter;
            btn_color.UseVisualStyleBackColor = true;
            btn_color.Click += btn_color_Click;
            // 
            // pic_color
            // 
            pic_color.Anchor = AnchorStyles.Left;
            pic_color.BackColor = Color.White;
            pic_color.Location = new Point(12, 433);
            pic_color.Name = "pic_color";
            pic_color.Size = new Size(134, 29);
            pic_color.TabIndex = 0;
            pic_color.UseVisualStyleBackColor = false;
            // 
            // btn_font
            // 
            btn_font.Anchor = AnchorStyles.Top;
            btn_font.BackColor = SystemColors.ButtonHighlight;
            btn_font.Cursor = Cursors.Hand;
            btn_font.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 192);
            btn_font.FlatAppearance.MouseOverBackColor = Color.Cyan;
            btn_font.FlatStyle = FlatStyle.Flat;
            btn_font.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_font.ForeColor = Color.Black;
            btn_font.ImageAlign = ContentAlignment.TopCenter;
            btn_font.Location = new Point(262, 40);
            btn_font.Name = "btn_font";
            btn_font.Size = new Size(160, 32);
            btn_font.TabIndex = 8;
            btn_font.Text = "Font";
            btn_font.TextAlign = ContentAlignment.BottomCenter;
            btn_font.UseVisualStyleBackColor = false;
            btn_font.Visible = false;
            btn_font.Click += btn_font_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1092, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, saveToolStripMenuItem, openToolStripMenuItem, printToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(181, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(181, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(181, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(181, 26);
            printToolStripMenuItem.Text = "Print";
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(179, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(179, 26);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // strokeSizeComboBox
            // 
            strokeSizeComboBox.Anchor = AnchorStyles.Top;
            strokeSizeComboBox.FormattingEnabled = true;
            strokeSizeComboBox.IntegralHeight = false;
            strokeSizeComboBox.Location = new Point(581, 44);
            strokeSizeComboBox.Name = "strokeSizeComboBox";
            strokeSizeComboBox.Size = new Size(151, 28);
            strokeSizeComboBox.TabIndex = 7;
            strokeSizeComboBox.SelectedIndexChanged += strokeSizeComboBox_SelectedIndexChanged;
            // 
            // pic
            // 
            pic.BackColor = Color.White;
            pic.Location = new Point(-3, 0);
            pic.Name = "pic";
            pic.Size = new Size(920, 547);
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.TabIndex = 1;
            pic.TabStop = false;
            pic.Paint += pic_Paint;
            pic.MouseClick += pic_MouseClick;
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
            pic.MouseWheel += pic_MouseWheel;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btn_font);
            panel2.Controls.Add(strokeSizeComboBox);
            panel2.Controls.Add(menuStrip1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1092, 87);
            panel2.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(467, 47);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 10;
            label1.Text = "Brush Width:";
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(pic);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(172, 87);
            panel3.Name = "panel3";
            panel3.Size = new Size(920, 652);
            panel3.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 739);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)color_picker).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button pic_color;
        private PictureBox pic;
        private Button btn_color;
        private Button btn_fill;
        private Button btn_pencil;
        private Button btn_eraser;
        private Button btn_line;
        private Button btn_rectangle;
        private Button btn_elipse;
        private ComboBox strokeSizeComboBox;
        private Panel panel2;
        private Button btn_text;
        private Button btn_font;
        private FontDialog fontDialog1;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private PictureBox color_picker;
        private Label label1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
    }
}
