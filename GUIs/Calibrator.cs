using Among_Us_Calibrator.Data_Management;
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

namespace Among_Us_Calibrator
{
    public partial class Calibrator : Form
    {
        private ActionMGMT Manager;
        private GUIs.Start GuiThatwillBeClosed;
        public Calibrator()
        {
            InitializeComponent();
        }
        public Calibrator(GUIs.Start start)
        {
            GuiThatwillBeClosed = start;
            InitializeComponent();
        }
        private void CirclePicture(PictureBox x)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(4, 4, x.Width - 8, x.Height - 8);
            Region rg = new Region(gp);
            x.Region = rg;
        }
        private void Calibrator_Load(object sender, EventArgs e)
        {
            CirclePicture(YoutubePicture);

            this.DoubleBuffered = true;
            //flowLayoutPanel1.
            //CardPointLabel6.Visible = false;//label straight up disappeared
            Manager = new ActionMGMT();
            //add all pictureboxes that I want enlarged
            LoadEnlargedPicture(new PictureBox[] { DataPicture1, RefuelPicture1, CardPicture, DPowerPicture,ADPPicture , ShieldPicture ,GarbagePicture, SteerPicture, DistPicture, AlignPicture, WiresPicture,SampPicture, LightPicture });
            //all of the handles for the group boxes
            Manager.AddHandle(new ButtonHandle("Data", DataSetPointButton, DataTestButton, new Label[] { DataPointLabel1, DataPointLabel2, DataPointLabel3, DataPointLabel4 }));
            Manager.AddHandle(new ButtonHandle("Refuel", RefuelSetPointButton, RefuelTestButton, new Label[] { RefuelPointLabel1, RefuelPointLabel2, RefuelPointLabel3, RefuelPointLabel4,RefuelPointLabel5 }));
            Manager.AddHandle(new ButtonHandle("CardSwipe", CardSetPointButton, CardTestButton, new Label[] { CardPointLabel1, CardPointLabel2, CardPointLabel3, CardPointLabel4, CardPointLabel5,CardPointLabel7 }));
            Manager.AddHandle(new ButtonHandle("DivertPower", DPowerPointButton, DPowerTestButton, new Label[] { DPowerPointLabel1, DPowerPointLabel2, DPowerPointLabel3, DPowerPointLabel4, DPowerPointLabel5, DPowerPointLabel6,DPowerPointLabel7, DPowerPointLabel8, DPowerPointLabel9, DPowerPointLabel10, DPowerPointLabel11 }));
            Manager.AddHandle(new ButtonHandle("AcceptDivertedPower", ADPPointButton, ADPTestButton, new Label[] { ADPPointLabel1, ADPPointLabel2, ADPPointLabel3, ADPPointLabel4 }));
            Manager.AddHandle(new ButtonHandle("Shields", ShieldPointButton, ShieldTestButton, new Label[] { SheildPointLabel1, SheildPointLabel2, SheildPointLabel3, SheildPointLabel4, SheildPointLabel5, SheildPointLabel6, SheildPointLabel7, SheildPointLabel8, SheildPointLabel9, SheildPointLabel10}));
            Manager.AddHandle(new ButtonHandle("EmptyGarbage", GarbagePointButton, GarbageTestButton, new Label[] { GrabagePointLabel1, GrabagePointLabel2, GrabagePointLabel3, GrabagePointLabel4, GrabagePointLabel5 }));
            Manager.AddHandle(new ButtonHandle("StabilizeSteering", SteerPointButton, SteerTestButton, new Label[] { SteerPointLabel1, SteerPointLabel2, SteerPointLabel3, SteerPointLabel4 }));
            Manager.AddHandle(new ButtonHandle("CalibrateDistributor", DistPointButton, DistTestButton, new Label[] { DistPointLabel1, DistPointLabel2, DistPointLabel3, DistPointLabel4, DistPointLabel5, DistPointLabel6, DistPointLabel7, DistPointLabel8, DistPointLabel9 }));
            Manager.AddHandle(new ButtonHandle("AlignEngine", AlignPointButton, AlignTestButton, new Label[] { AlignPointLabel1, AlignPointLabel2, AlignPointLabel3, AlignPointLabel4, AlignPointLabel5, AlignPointLabel6 }));
            Manager.AddHandle(new ButtonHandle("Wires", WiresPointButton, WiresTestButton, new Label[] { WiresPointLabel1, WiresPointLabel2, WiresPointLabel3, WiresPointLabel4, WiresPointLabel5, WiresPointLabel6, WiresPointLabel7, WiresPointLabel8, WiresPointLabel9, WiresPointLabel10, WiresPointLabel11 }));
            Manager.AddHandle(new ButtonHandle("InspectSample", SampPointButton, SampTestButton, new Label[] { SampPointLabel1, SampPointLabel2, SampPointLabel3, SampPointLabel4, SampPointLabel5, SampPointLabel6, SampPointLabel7, SampPointLabel8, SampPointLabel9, SampPointLabel10 }));
            Manager.AddHandle(new ButtonHandle("Lights", LightPointButton, LightTestButton, new Label[] { LightPointLabel1, LightPointLabel2, LightPointLabel3, LightPointLabel4, LightPointLabel5, LightPointLabel6, LightPointLabel7, LightPointLabel8, LightPointLabel9, LightPointLabel10 }));
        }

       

        //handles all data set button clicks
        private void TestSetPointClick(object sender, EventArgs e)
        {
            Manager.ButtonClick((Button)sender);
            //Console.WriteLine(((Button)sender).Name);
        }
        //sets click event to picture click and changes hover text
        private void LoadEnlargedPicture(PictureBox[] x)
        {
            foreach (Control c in x)
            {
                Tools.OutsideResources.ClickImageViewer((PictureBox)c);
            }
            
        }


        private void TheKeyPress(object sender, KeyPressEventArgs e)
        {
            Manager.keyPress(e);
        }
        //save menu button
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter=("json files (*.json)|*.json");
            sfd.RestoreDirectory=(true);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                String t = sfd.FileName;
                sfd.Dispose();
                Manager.SaveToFile(t);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            Console.WriteLine("Calibator.OpenFile()");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter= ("json files (*.json)|*.json");
            ofd.RestoreDirectory = (true);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String t = ofd.FileName;
                ofd.Dispose();
                Manager.OpenFile(t);
            }
        }

        private void ResetClick(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to reset everything?",
                                       "Reset Calibration",
                                       MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Manager.ResetAll();
            }
        }

        private void SettingsToolbarClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HelpClick(object sender, EventArgs e)
        {
            GUIs.Help H = new GUIs.Help();
            H.Show();
        }
        //youtube video change me
        private void YoutubeVideoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Console.WriteLine("Calibrator.YoutubeVideoLink_LinkClicked(): CHANGE THE FUCKING YOUTUBE VIDEO");
            Process.Start("https://www.youtube.com/watch?v=7xzU9Qqdqww");
        }
        public void changeBindingReturnAction(char key)
        {
            Manager.changeBindingKeyChar(key);
            //Console.WriteLine("Calibrator.changeBindingReturnAction() called: "+ key);
        }
        private GUIs.Change_Key_Binding bindgui;
        //open binding GUI
        private void changeBindingClick(object sender, EventArgs e)
        {
            if (bindgui != null)
            {
                bindgui.Close();
                bindgui.Dispose();
                bindgui = null;
            }
            bindgui = new GUIs.Change_Key_Binding(changeBindingReturnAction);
            bindgui.Show();
        }

        private void Calibrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuiThatwillBeClosed.Close();
        }
        //closes this gui and returns it to menu
        private void returnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuiThatwillBeClosed.Show();
            GuiThatwillBeClosed = new GUIs.Start();
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //opens among us game
        private void AmongUsOpenButton(object sender, EventArgs e)
        {
            Tools.OutsideResources.OpenAmongus();
        }
        //open youtube
        private void YoutubeLogoClick(object sender, EventArgs e)
        {
            Tools.OutsideResources.OpenYoutubeChanel();
        }

        private void GitHubLogo_Click(object sender, EventArgs e)
        {
            Tools.OutsideResources.OpenGithub();
        }

        private void ContactMeClick(object sender, EventArgs e)
        {
            Tools.OutsideResources.ContactMe();
        }

        private void TutorialIconClick(object sender, EventArgs e)
        {
            Tools.OutsideResources.openTutorial();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Tools.OutsideResources.OpenAmongus();
        }
    }
}
