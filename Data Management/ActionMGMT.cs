using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_Us_Calibrator.Data_Management
{
    class ActionMGMT
    {
        private char keyChar='`';//for if I want to change the thing from ~ or whatever
        public ButtonHandle ActiveHandle;//which one gets the keypress(keychar) events
        private List<ButtonHandle> handles;
        
        public ActionMGMT()
        {
            handles = new List<ButtonHandle>();
        }
        public void SaveToFile(String filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            DeactivateHandle();
            JSONBuilder builder = new JSONBuilder();
            foreach (ButtonHandle bh in handles)
            {
                builder.addAction(bh.ToAction());
            }
            File.WriteAllText(filename, builder.toString);
        }
        public void AddHandle(ButtonHandle x)
        {
            x.Owner = this;
            handles.Add(x);
        }

        public void ButtonClick(Button x)
        {
            FindButtonHandle(x).Click(x);
        }
        public void DeactivateHandle()
        {
            if (ActiveHandle != null)
            {
                ActiveHandle.Deactivate();
                ActiveHandle = null;
            }
        }
        internal void ActivateHandle(ButtonHandle buttonHandle)
        {
            Console.WriteLine("ActionMGMT.ActivateHandle: \""+buttonHandle.Name+"\" Activated");
                
            DeactivateHandle();
            ActiveHandle = buttonHandle;
        }
        public void keyPress(KeyPressEventArgs e)
        {
            if (keyChar==e.KeyChar&&ActiveHandle != null)
                ActiveHandle.KeyEvent();
            Console.WriteLine("ActionMGMT.cs keyPress(): keyPressed: " + e.KeyChar+" check ActionMGMT.keyChar");
            
        }
        public void changeBindingKeyChar(char newBinding)
        {
            keyChar = newBinding;
            foreach (ButtonHandle bh in handles)
            {
                bh.changeBindingCharTooltip(newBinding);
            }
        }
 

        //finds button handle from handles for both test buttons and setpoint buttons
        private ButtonHandle FindButtonHandle(Button x)
        {
            foreach (ButtonHandle bh in handles)
            {
                if (bh.SetButton == x || bh.TestButton == x)
                    return bh;
            }
            Console.WriteLine("ActionMGMT.findButtonHandle could not find handle for button: " +x.Name+"["+x.Text+"]");
            return null;
        }

        internal void OpenFile(string t)
        {
            Dictionary<string,JSON.JSONDataV2> data = JSON.JSONDataV2.loadJSON(t);
            foreach (ButtonHandle bh in handles)
            {
                bh.loadJSONData(data);
            }
        }

        internal void ResetAll()
        {
            foreach (ButtonHandle bh in handles)
            {
                bh.Clear();
            }
        }
    }
}
