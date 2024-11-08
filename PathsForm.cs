using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floyd
{
    public partial class PathsForm : Form
    {
        public PathsForm(string text)
        {
            InitializeComponent();
            richTextBox.Text = text;
        }
    }
}
