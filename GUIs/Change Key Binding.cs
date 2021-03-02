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
    public partial class Change_Key_Binding : Form
    {
        private Action<char> returnAct;
        public Change_Key_Binding(Action<char> BindingReturn)
        {
            returnAct = BindingReturn;
            InitializeComponent();
        }
        private String setChar ="";

        private void Reset_Click(object sender, EventArgs e)
        {
            setChar = "";
            updateOutput();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (setChar != "")
            {
                returnAct(setChar.ToCharArray()[0]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cannot confirm without binding key");
            }
        }
        private void updateOutput()
        {
            if (setChar != "")
                Output.Text = setChar;
            else
                Output.Text = "Output";
        }
        private void KeyPressM(object sender, KeyPressEventArgs e)
        {
           // Console.WriteLine("Change_Key_Binding.KeyPressM(): " + e.KeyChar);
            if (setChar != "")
                return;
            setChar = e.KeyChar.ToString();
            updateOutput();


        }
    }
}
