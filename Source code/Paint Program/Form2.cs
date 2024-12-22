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
    public partial class Form2 : Form
    {
        public int ImageWidth => (int)numericUpDownWidth.Value;
        public int ImageHeight => (int)numericUpDownHeight.Value;
        public Form2()
        {
            InitializeComponent();
            numericUpDownWidth.Minimum = 1;
            numericUpDownHeight.Minimum = 1;
            numericUpDownWidth.Maximum = 10000; // Adjust as needed
            numericUpDownHeight.Maximum = 10000;
        }
    }
}
