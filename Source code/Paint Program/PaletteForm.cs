using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Program
{
    public partial class PaletteForm : Form
    {
        public Color SelectedColor { get; private set; } = Color.Black; // Default color
        public event Action<Color> ColorSelected; // Event to notify when a color is picked

        private FlowLayoutPanel palettePanel;
        private static List<Color> paletteColors = new List<Color>
        {
            Color.Black, Color.White, Color.Red, Color.Green, Color.Blue,
            Color.Yellow, Color.Purple, Color.Orange, Color.Gray
        };

        public PaletteForm()
        {
            InitializeComponent();
            this.Text = "Color Palette";
            this.Width = 250;
            this.Height = 400;


            palettePanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.LightGray
            };
            this.Controls.Add(palettePanel);

            PopulatePalette();

        }

        private void PopulatePalette()
        {
            for (int i = palettePanel.Controls.Count - 1; i >= 0; i--)
            {
                Control control = palettePanel.Controls[i];
                if (control is Button button && button.Text == string.Empty) // Empty text buttons are color buttons
                {
                    palettePanel.Controls.RemoveAt(i);
                }
            }

            // Add the updated color buttons
            foreach (Color color in paletteColors)
            {
                Button colorButton = new Button
                {
                    BackColor = color,
                    Width = 30,
                    Height = 30,
                    Margin = new Padding(5)
                };

                colorButton.Click += (sender, e) =>
                {
                    Color selectedColor = colorButton.BackColor;
                    OnColorPicked(selectedColor);
                };

                palettePanel.Controls.Add(colorButton);
            }
        }

        private void CustomColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    SelectedColor = cd.Color;
                    ColorSelected?.Invoke(SelectedColor); // Raise the event
                }
            }
        }


        private void OnColorPicked(Color selectedColor)
        {
            // Notify the main form of the selected color
            ColorSelected?.Invoke(selectedColor);
        }

        private void AddToPaletteButton_Click_1(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color newColor = colorDialog.Color;

                    // Avoid duplicates
                    if (!paletteColors.Contains(newColor))
                    {
                        paletteColors.Add(newColor);

                        // Create a new button for the selected color
                        Button colorButton = new Button
                        {
                            BackColor = newColor,
                            Width = 30,
                            Height = 30,
                            Margin = new Padding(5)
                        };

                        colorButton.Click += (s, args) =>
                        {
                            Color selectedColor = colorButton.BackColor;
                            OnColorPicked(selectedColor);
                        };

                        PopulatePalette();
                    }
                    else
                    {
                        MessageBox.Show("This color is already in the palette.", "Duplicate Color", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }

}
