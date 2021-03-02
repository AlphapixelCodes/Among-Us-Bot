using Among_Us_Calibrator.JSON;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Among_Us_Calibrator.Data_Management
{
    class ButtonHandle
    {
        private List<Point> points;
        private List<Color> colors;
        private readonly int checkPointLastIndex;

        //point label must be in order
        public ButtonHandle(string name,Button setButton,Button testButton,Label[] pointLabel)
        {
            Name = name;
            SetButton = setButton;
            TestButton = testButton;
            PointLabels = pointLabel;
            checkPointLastIndex = 3;
            //ToJSONAction = toJSONAction;
            setTestToolTip(testButton);
            setPointsToolTip(setButton);
            for (int i = 0; i < pointLabel.Length; i++)
            {
                pointLabel[i].Text = "Point " + (i+1) + " Unset";
            }
            Clear();
        }

        internal JSONBuilder.Action ToAction()
        {
            Deactivate();//probably dont need this but yeah so that it isnt between on points;
            List<Color> c = new List<Color>();
            List<Point> p = new List<Point>();
            List<Point> p2 = new List<Point>();
            List<Color> c2 = new List<Color>();
            if (isPointColorFull())
            {
                p = points.GetRange(0, 3);
                c = colors.GetRange(0, 3);
                for (int i = 3; i < points.Count; i++)
                {
                    p2.Add(points[i]);
                    c2.Add(colors[i]);
                }
            }
            return new JSONBuilder.Action(Name, c, p, p2, c2, isPointColorFull());
        }
        public void loadJSONData(Dictionary<string, JSONDataV2> data)
        {
            Console.WriteLine("ButtonHandle.loadJSONData(): JSONData " + (data.ContainsKey(Name)? "contains":"does not contain") + " \""+Name+"\"");
            if (!data.ContainsKey(Name))
                return;
            JSONDataV2 dat;
            if (!data.TryGetValue(Name, out dat))
                return;
            Clear();
            foreach (Tuple<Point,Color> a in dat.CheckPointColor)
            {
                addPoint(a.Item1, a.Item2);
            }
            for (int i = 0; i < dat.RandomPoint.Count; i++)
            {
                addPoint(dat.RandomPoint[i], dat.RandomColor[i]);
            }
            
            //todo fuck me in the ass
          /////////////////////////////  dat. rewrite everything so its all point color data maybe

        }
        public void Clear()
        {
            points = new List<Point>();
            colors = new List<Color>();
            foreach (Label v in PointLabels)
                unsetLabel(v);
        }

        internal void Deactivate()
        {
            SetButton.BackColor = Color.Transparent;
            SetButton.FlatStyle = FlatStyle.Standard;
            SetButton.FlatAppearance.BorderColor = Color.Empty;
            if (!isPointColorFull())
            {
                Clear();
            }
        }
        internal void Activate()
        {
            SetButton.BackColor = Color.Lime;
            SetButton.FlatStyle = FlatStyle.Flat;

            SetButton.FlatAppearance.BorderSize = 1;
            SetButton.FlatAppearance.BorderColor = Color.Lime;
            Clear();
            Owner.ActivateHandle(this);
        }

        private bool isPointColorFull()
        {
            return PointLabels.Length == points.Count;
        }
        internal void KeyEvent()
        {
            Console.WriteLine("ButtonHandle.KeyEvent[" + Name + "] called, isPointColorFull: "+isPointColorFull());
            if (!isPointColorFull())
            {
                Point p = Hooks.Mouse.GetCursorPosition();
                p.X = p.X - 1;
                p.Y = p.Y - 1;
                Color c = Hooks.Mouse.GetColorAt(p.X, p.Y);
                addPoint(p, c);
               
                if (isPointColorFull())
                {
                    Owner.DeactivateHandle();
                }
            }
            else
            {
                Owner.DeactivateHandle();
            }
        }
        internal void Click(Button x)
        {
            if (x == SetButton)
                SetPointClick();
            else
                TestButtonClick();
        }
        private void addPoint(Point p,Color c)
        {
            setLabel(PointLabels[points.Count]);
            points.Add(p);
            colors.Add(c);
        }
        private void TestButtonClick()//this is fucking wrong and I know it
        {
            Console.WriteLine("ButtonHandle.TestButtonClick(): this  whole method is fucked, like I cant determine which points are check points");
            if (!isPointColorFull())
            {
                MessageBox.Show("Cannot test, not all points are set for \""+Name+"\"");
                return;
            }
            bool res = true;
            for (int i = 0; i < checkPointLastIndex; i++)
            {
                Point p = points[i];
                if (Hooks.Mouse.GetColorAt(p.X, p.Y) != colors[i])
                {
                    res = false;
                }                    
            }
            MessageBox.Show("Test points (points 1-"+ (checkPointLastIndex)+ ") for \"" + Name + "\" came back " + (res? "Postive" : "Negative"));
           // Console.WriteLine("ButtonHandle[" + Name + "].TestButtonClick has not been made yet");
        }
        private void setLabel(Label l)
        {
            l.BackColor = Color.Lime;
            l.Text = l.Text.Replace(" Unset", " Set");
        }
        private void unsetLabel(Label l)
        {
            l.BackColor = Color.Transparent;
            l.Text = l.Text.Replace(" Set", " Unset");
        }

        //changes set points tooltip to the new char
        public void changeBindingCharTooltip(char bind)
        {
            toolTipper(SetButton, "Press '"+bind+"' to set points to mouse location");
        }


        //do the set 
        public void SetPointClick()
        {
            Console.WriteLine("ButtonHandle[" + Name + "].SetPointClick Called");
            if (Owner.ActiveHandle==(this))
                Owner.DeactivateHandle();
            else
                Activate();
            //Console.WriteLine("ButtonHandle[" + Name + "].SetPointClick has not been made yet");
        }
        public ActionMGMT Owner { get; set; }
        public string Name { get; }
        public Button SetButton { get; }
        public Button TestButton { get; }
        public Label[] PointLabels { get; }
        

        private void toolTipper(Control x, String text)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(x, text);
        }
        private void setPointsToolTip(Button x)
        {
            toolTipper(x, "Press '~' to set points to mouse location");
        }
        private void setTestToolTip(Button x)
        {
            toolTipper(x, "Test the points set");
        }
    }
}
