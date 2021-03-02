using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_Us_Calibrator.GUIs
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Calibration(object sender, EventArgs e)
        {
            this.Hide();
            new Calibrator(this).Show();
        }

        private void Bot_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bot.BotGUI(this).Show();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            Tools.OutsideResources.toolTipper(Calib, "Start With Me!!!!");
            Tools.OutsideResources.toolTipper(Bot, "Don't start with me");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Help().Show();
        }
    }
}
