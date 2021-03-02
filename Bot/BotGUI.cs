using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_Us_Calibrator.Bot
{
    public partial class BotGUI : Form
    {
        private GUIs.Start Menu;
        private SkeldV3 bot;
        public BotGUI(GUIs.Start menu)
        {
            Menu = menu;
            InitializeComponent();
        }
        public void ChangeTaskLabel(String text)
        {
            CurrentTaskLabel.Text = "Last Task: " + text;
        }
        private void OpenFile(string Filename)
        {
            FileNameLabel.Text = "File Name: " + Path.GetFileName(Filename);
            //probably should kill the running bots or idk

            if (bot != null)
                bot.killIt();
            bot = new SkeldV3(JSON.JSONDataV2.loadJSON(Filename),this);
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            Thread th = new Thread(()=> {
                //Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
                bot.run();
            });
            bot.Pause();
            th.Start();
            StartPauseButton.Text = "Pause";
            BotStatus.Text = "Bot: Running";
            //bot.run();
        }
        private void setBotState(bool running)
        {
                StartPauseButton.Text = (running) ? "Pause" : "Resume";
            BotStatus.Text = "Bot Status: " + ((running) ? "Running" : "Paused");
         }
        private void StartPauseButton_Click(object sender, EventArgs e)
        {
            if (bot == null)
            {
                openFileToolStripMenuItem_Click(1,new EventArgs());
                //MessageBox.Show("No bot is running, please open a json file.");
                return;
            }
            bot.ToggleOnOff();
            setBotState(bot.isRunning());
        }
        private void BotGUI_Load(object sender, EventArgs e)
        {

        }
        //closing events
        private void BotGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillBot();
            Menu.Close();
        }

        private void KillBot()
        {
            if (bot != null)
            {
                bot.Pause();
                bot.killIt();
            }
        }

        //return home
        private void returnToHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu.Show();
            Menu = new GUIs.Start();
            this.Close();
        }
        //exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //open file
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("BotGUI.OpenFile()");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("json files (*.json)|*.json");
            ofd.RestoreDirectory = (true);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String t = ofd.FileName;
                ofd.Dispose();
                OpenFile(t);
                Console.WriteLine("WRITE ME");
            }
        }
    }
}
