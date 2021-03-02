using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_Us_Calibrator
{
    public partial class ImageViewer : Form
    {
        public ImageViewer(PictureBox x)
        {
            InitializeComponent();
            pictureBox1.Image = x.Image;
        }
    }
}
