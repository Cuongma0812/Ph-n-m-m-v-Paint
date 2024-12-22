using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Paint_Program
{

    public partial class Form1 : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private float zoom = 1.0f; // Default zoom level
        private PointF panOffset = new PointF(0, 0);
        private Point prevMousePosition;
        private Stack<CanvasState> undoStack = new Stack<CanvasState>();
        private Stack<CanvasState> redoStack = new Stack<CanvasState>();
        private System.Windows.Forms.TextBox activeTextBox;
        private PaletteForm paletteForm;

        private class CanvasState
        {
            public Bitmap Bitmap { get; set; }
            public float Zoom { get; set; }
            public PointF PanOffset { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            this.Text = "My Paint Program";
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.Width = 1280;
            this.Height = 920;
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
            strokeSizeComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12",
"13", "14", "15", "20", "25", "30", "35", "40", "45" , "50", "55", "60", "65", "70", "75", "80", "85", "90"});
            strokeSizeComboBox.SelectedIndex = 0; // Default size
            p.Width = float.Parse(strokeSizeComboBox.SelectedItem.ToString());
            erase.Width = float.Parse(strokeSizeComboBox.SelectedItem.ToString());
            pic_color.BackColor = Color.Black;
            new_color = pic_color.BackColor;
            printDocument.PrintPage += printDocument_PrintPage;
            panel3.MouseWheel += new MouseEventHandler(Panel_MouseWheel);

            OpenPalette();

        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog cd = new ColorDialog();
        Color new_color;
        FontDialog fontDialog = new FontDialog();
        Font selectedFont = new Font("Arial", 12);



        private PointF TransformToCanvasSpace(Point screenPoint)
        {
            float canvasX = (screenPoint.X - panOffset.X) / zoom;
            float canvasY = (screenPoint.Y - panOffset.Y) / zoom;
            return new PointF(canvasX, canvasY);
        }

        private Point TransformMouseToCanvas(Point mousePoint)
        {
            int canvasX = (int)((mousePoint.X - panOffset.X) / zoom);
            int canvasY = (int)((mousePoint.Y - panOffset.Y) / zoom);
            return new Point(canvasX, canvasY);
        }

        private Point TransformCanvasToControl(Point canvasPoint)
        {
            int controlX = (int)(canvasPoint.X * zoom + panOffset.X);
            int controlY = (int)(canvasPoint.Y * zoom + panOffset.Y);

            return new Point(controlX, controlY);
        }


        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            // If Ctrl is pressed, suppress scrolling
            if (Control.ModifierKeys == Keys.Control)
            {
                ((HandledMouseEventArgs)e).Handled = true; // Suppress panel scrolling
            }
        }


        private void pic_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                // Zoom in or out
                if (e.Delta > 0)
                {
                    zoom *= 1.1f; // Zoom in
                }
                else
                {
                    zoom *= 0.9f; // Zoom out
                }

                // Clamp zoom level
                zoom = Math.Clamp(zoom, 0.1f, 10.0f);

                // Update PictureBox size
                pic.Width = (int)(bm.Width * zoom);
                pic.Height = (int)(bm.Height * zoom);

                pic.Refresh(); // Refresh to apply changes
            }
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SaveStateForUndo();
                paint = true;

                // Transform to canvas space
                var transformedPoint = TransformToCanvasSpace(e.Location);
                py = new Point((int)transformedPoint.X, (int)transformedPoint.Y);
                cX = (int)transformedPoint.X;
                cY = (int)transformedPoint.Y;


            }
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                paint = false;

                // Transform to canvas space
                var transformedPoint = TransformToCanvasSpace(e.Location);
                int endX = (int)transformedPoint.X;
                int endY = (int)transformedPoint.Y;

                // Draw final shape directly onto the bitmap
                if (index == 3) // Ellipse
                {
                    g.DrawEllipse(p, cX, cY, endX - cX, endY - cY);
                }
                else if (index == 4) // Rectangle
                {
                    g.DrawRectangle(p, cX, cY, endX - cX, endY - cY);
                }
                else if (index == 5) // Line
                {
                    g.DrawLine(p, new Point(cX, cY), new Point(endX, endY));
                }

                pic.Refresh();
            }
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            var transformedPoint = TransformToCanvasSpace(e.Location);
            int endX = (int)transformedPoint.X;
            int endY = (int)transformedPoint.Y;
            if (paint)
            {

                px = new Point((int)transformedPoint.X, (int)transformedPoint.Y);


                if (index == 1) // Pencil
                {
                    g.DrawLine(p, px, py);
                    py = px;
                }
                else if (index == 2) // Eraser
                {
                    g.DrawLine(erase, px, py);
                    py = px;
                }
            }

            pic.Refresh();

            x = e.X;
            y = e.Y;
            sX = endX - cX;
            sY = endY - cY;
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
            btn_font.Visible = false;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
            btn_font.Visible = false;
        }

        private void btn_elipse_Click(object sender, EventArgs e)
        {
            index = 3;
            btn_font.Visible = false;
        }

        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            index = 4;
            btn_font.Visible = false;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            index = 5;
            btn_font.Visible = false;
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // High-quality rendering settings
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            // Apply zoom and pan transformations
            g.TranslateTransform(panOffset.X, panOffset.Y);
            g.ScaleTransform(zoom, zoom);

            g.Clear(Color.White);
            // Draw the current bitmap
            g.DrawImage(bm, new PointF(0, 0));

            // Draw preview shapes only when painting
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            OpenPalette();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }


        private void Validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            try
            {
                if (x >= 0 && y >= 0 && x < bm.Width && y < bm.Height)
                {
                    Color cx = bm.GetPixel(x, y);
                    if (cx.ToArgb() == old_color.ToArgb())
                    {
                        sp.Push(new Point(x, y));
                        bm.SetPixel(x, y, new_color);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error validating pixel at ({x}, {y}): {ex.Message}");
            }
        }

        private void Fill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
        {
            if (targetColor.ToArgb() == replacementColor.ToArgb()) return; // No need to fill if colors are the same

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(pt);

            while (pixels.Count > 0)
            {
                Point current = pixels.Pop();
                if (current.X < 0 || current.X >= bmp.Width || current.Y < 0 || current.Y >= bmp.Height)
                    continue; // Skip out-of-bounds pixels

                if (bmp.GetPixel(current.X, current.Y).ToArgb() == targetColor.ToArgb())
                {
                    bmp.SetPixel(current.X, current.Y, replacementColor);

                    // Add neighboring pixels
                    pixels.Push(new Point(current.X + 1, current.Y));
                    pixels.Push(new Point(current.X - 1, current.Y));
                    pixels.Push(new Point(current.X, current.Y + 1));
                    pixels.Push(new Point(current.X, current.Y - 1));
                }
            }
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 7)
            {
                Point canvasPoint = TransformMouseToCanvas(e.Location);
                Color targetColor = bm.GetPixel(canvasPoint.X, canvasPoint.Y);
                Fill(bm, canvasPoint, targetColor, new_color);
                pic.Refresh();
            }
            else if (index == 6) // Writing tool active
            {
                FinalizeActiveTextBox();
                Point canvasPoint = TransformMouseToCanvas(e.Location);
                Point textBoxPosition = TransformCanvasToControl(canvasPoint);

                activeTextBox = new System.Windows.Forms.TextBox
                {
                    Location = textBoxPosition,
                    Width = 120,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = selectedFont
                };

                pic.Controls.Add(activeTextBox);
                activeTextBox.Focus();

                activeTextBox.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter)
                    {
                        FinalizeActiveTextBox();
                    }
                };

                activeTextBox.LostFocus += (s, ev) =>
                {
                    FinalizeActiveTextBox();
                };

                activeTextBox.TextChanged += (s, ev) =>
                {
                    using (Graphics g = pic.CreateGraphics())
                    {
                        SizeF textSize = g.MeasureString(activeTextBox.Text, selectedFont);
                        activeTextBox.Width = (int)Math.Ceiling(textSize.Width) + 6;
                        activeTextBox.Height = (int)Math.Ceiling(textSize.Height) + 6;
                    }
                };
            }
        }

        private void FinalizeActiveTextBox()
        {
            if (activeTextBox != null)
            {
                if (!string.IsNullOrWhiteSpace(activeTextBox.Text))
                {
                    // Convert TextBox position back to canvas space
                    Point canvasTextLocation = TransformMouseToCanvas(activeTextBox.Location);

                    // Draw the text onto the Bitmap
                    using (Graphics gBitmap = Graphics.FromImage(bm))
                    {
                        gBitmap.DrawString(
                            activeTextBox.Text,
                            selectedFont,
                            new SolidBrush(new_color),
                            canvasTextLocation.X / zoom,
                            canvasTextLocation.Y / zoom
                        );
                    }

                    // Refresh PictureBox with updated image
                    pic.Image = bm;
                    pic.Refresh();
                }

                // Cleanup the TextBox
                pic.Controls.Remove(activeTextBox);
                if (activeTextBox != null)
                    activeTextBox.Dispose();
                activeTextBox = null;
            }
        }



        private void strokeSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strokeSizeComboBox.SelectedItem != null)
            {
                float selectedSize = float.Parse(strokeSizeComboBox.SelectedItem.ToString());
                p.Width = selectedSize;
                erase.Width = selectedSize;
            }
        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            index = 7;
            btn_font.Visible = false;
        }

        private void btn_text_Click(object sender, EventArgs e)
        {
            index = 6;
            btn_font.Visible = true;
        }

        private void btn_font_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFont = fontDialog.Font;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save your drawing";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.FileName = "MyDrawing";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the file extension
                    string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    // Save in the appropriate format
                    switch (fileExtension)
                    {
                        case ".jpg":
                            bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        default:
                            bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    MessageBox.Show("Image saved successfully!", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            SaveCanvas();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        

        private void SaveCanvas()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
                openFileDialog.Title = "Open an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image
                        Image openedImage = Image.FromFile(openFileDialog.FileName);


                        // Resize if needed
                        if (openedImage.Width > pic.Width || openedImage.Height > pic.Height)
                        {
                            // Scale the image to fit within the PictureBox dimensions
                            Bitmap resizedImage = new Bitmap(openedImage, pic.Width, pic.Height);
                            openedImage.Dispose();
                            bm = resizedImage;

                        }
                        else
                        {
                            // Use the original image if it fits
                            bm = new Bitmap(openedImage);
                        }

                        g = Graphics.FromImage(bm); // Update the Graphics object
                        pic.Image = bm;            // Display the image on the PictureBox
                        pic.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (bm != null)
            {
                // Calculate image dimensions to fit within the page
                Rectangle marginBounds = e.MarginBounds;
                Rectangle imageBounds = new Rectangle(
                    marginBounds.Left,
                    marginBounds.Top,
                    bm.Width * marginBounds.Height / bm.Height,
                    marginBounds.Height);

                // Draw the image
                e.Graphics.DrawImage(bm, imageBounds);
            }
        }

        private void SaveStateForUndo()
        {
            var currentState = new CanvasState
            {
                Bitmap = (Bitmap)bm.Clone(),
                Zoom = zoom,
                PanOffset = panOffset
            };
            undoStack.Push(currentState); // Save to the undo stack
            redoStack.Clear();
        }

        private void Undo()
        {
            if (undoStack.Count > 0)
            {
                var currentState = new CanvasState
                {
                    Bitmap = (Bitmap)bm.Clone(),
                    Zoom = zoom,
                    PanOffset = panOffset
                };
                redoStack.Push(currentState); // Save the current state for redo

                var previousState = undoStack.Pop(); // Retrieve the previous state
                bm = previousState.Bitmap;

                g = Graphics.FromImage(bm); // Update Graphics object
                pic.Image = bm; // Refresh PictureBox
                pic.Refresh();
            }
        }

        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                var currentState = new CanvasState
                {
                    Bitmap = (Bitmap)bm.Clone(),
                    Zoom = zoom,
                    PanOffset = panOffset
                };
                undoStack.Push(currentState); // Save the current state for undo

                var nextState = redoStack.Pop(); // Retrieve the next state
                bm = nextState.Bitmap;

                g = Graphics.FromImage(bm); // Update Graphics object
                pic.Image = bm; // Refresh PictureBox
                pic.Refresh();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo();
                e.Handled = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes before creating a new canvas?",
                                     "Unsaved Changes",
                                     MessageBoxButtons.YesNoCancel,
                                     MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SaveCanvas(); // Implement your save logic
            }
            else if (result == DialogResult.Cancel)
            {
                return; // Abort creating a new canvas
            }
            using (Form2 dialog = new Form2())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the new dimensions
                    int width = dialog.ImageWidth;
                    int height = dialog.ImageHeight;

                    // Create a new blank image
                    bm = new Bitmap(width, height);
                    g = Graphics.FromImage(bm);
                    g.Clear(Color.White);

                    // Assign the new image to the PictureBox
                    pic.Image = bm;
                    pic.Refresh();

                    // Clear the undo/redo stacks
                    undoStack.Clear();
                    redoStack.Clear();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes before creating a new canvas?",
                                     "Unsaved Changes",
                                     MessageBoxButtons.YesNoCancel,
                                     MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SaveCanvas(); // Implement your save logic
            }
            else if (result == DialogResult.Cancel)
            {
                return; // Abort creating a new canvas
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save your drawing";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.FileName = "MyDrawing";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the file extension
                    string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    // Save in the appropriate format
                    switch (fileExtension)
                    {
                        case ".jpg":
                            bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        default:
                            bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    MessageBox.Show("Image saved successfully!", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
                openFileDialog.Title = "Open an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image
                        Image openedImage = Image.FromFile(openFileDialog.FileName);


                        // Resize if needed
                        if (openedImage.Width > pic.Width || openedImage.Height > pic.Height)
                        {
                            // Scale the image to fit within the PictureBox dimensions
                            Bitmap resizedImage = new Bitmap(openedImage, pic.Width, pic.Height);
                            openedImage.Dispose();
                            bm = resizedImage;

                        }
                        else
                        {
                            // Use the original image if it fits
                            bm = new Bitmap(openedImage);
                        }

                        g = Graphics.FromImage(bm); // Update the Graphics object
                        pic.Image = bm;            // Display the image on the PictureBox
                        pic.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void color_picker_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(color_picker, e.Location);
            pic_color.BackColor = ((Bitmap)color_picker.Image).GetPixel(point.X, point.Y);
            new_color = pic_color.BackColor;
            p.Color = pic_color.BackColor;
        }

        private void AdjustTextBoxSize(System.Windows.Forms.TextBox textBox)
        {
            if (textBox == null || textBox.Font == null || string.IsNullOrEmpty(textBox.Text))
                return;

            // Measure the size required for the text with the current font
            Size textSize = TextRenderer.MeasureText(textBox.Text, textBox.Font);

            // Adjust the TextBox size to fit the text
            textBox.Width = textSize.Width + 10; // Add some padding
            textBox.Height = textSize.Height + 5; // Add some padding
        }

        private void AdjustTextBoxSizeForMultiline(System.Windows.Forms.TextBox textBox)
        {
            if (textBox == null || textBox.Font == null || string.IsNullOrEmpty(textBox.Text))
                return;

            // Measure the text size for multiline support
            Size textSize = TextRenderer.MeasureText(
                textBox.Text,
                textBox.Font,
                textBox.ClientSize,
                TextFormatFlags.WordBreak
            );

            // Adjust size
            textBox.Width = Math.Max(textBox.Width, textSize.Width + 10); // Maintain current width if larger
            textBox.Height = textSize.Height + 5; // Add padding for height
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void OpenPalette()
        {
            if (paletteForm == null || paletteForm.IsDisposed)
            {
                paletteForm = new PaletteForm();

                // Subscribe to the ColorSelected event
                paletteForm.ColorSelected += (selectedColor) =>
                {
                    new_color = selectedColor;
                    pic_color.BackColor = new_color;
                    p.Color = new_color;
                };

                paletteForm.Owner = this;
                paletteForm.FormClosed += (s, e) => paletteForm = null;
                paletteForm.Show(this);
            }
            else
            {
                paletteForm.Focus();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            

                var result = MessageBox.Show("Do you want to save changes before exiting?",
                                             "Unsaved Changes",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SaveCanvas();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Abort closing
                }
                // If No, simply proceed with closing

        }
    }
}




