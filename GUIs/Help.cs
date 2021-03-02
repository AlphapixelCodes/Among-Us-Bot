using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Among_Us_Calibrator.Tools;
namespace Among_Us_Calibrator.GUIs
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }
        private void YoutubeVideoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=7xzU9Qqdqww");
        }
        //open among us
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OutsideResources.OpenAmongus();
        }
        //source of this method(https://stackoverflow.com/a/3426721/7575250)
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        private void Help_Load(object sender, EventArgs e)
        {
            //);
            //PictureBox[] enlargeable = new PictureBox[] { Step2Picture1,Step2Picture2};
            Console.WriteLine(Controls.OfType<PictureBox>().Count());
            foreach (PictureBox p in GetAll(this, typeof(PictureBox))) 
            {
                //Console.WriteLine("HelpLoad");
                OutsideResources.ClickImageViewer(p);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OutsideResources.openTutorial();
        }
    }
}
