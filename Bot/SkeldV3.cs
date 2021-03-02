using Among_Us_Calibrator.JSON;
using InputManager;
//using Among_Us_Calibrator.Hooks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Among_Us_Calibrator.Bot
{
    class SkeldV3
    {
        public static void press()
        {
            Mouse.ButtonDown(Mouse.MouseKeys.Left);
        }
        public static void release()
        {
            Mouse.ButtonUp(Mouse.MouseKeys.Left);
        }
        public static void moveNoDelay(int x, int y)
        {
            Mouse.Move(x, y);
        }
        public static void moveNoDelay(Point p)
        {
            moveNoDelay(p.X, p.Y);
        }
        public static void move(Point p)
        {
            move(p.X, p.Y);
        }
        public static void move(int x, int y)
        {
            Thread.Sleep(20);
            Mouse.Move(x, y);
            Thread.Sleep(50);
        }
        public static void clickNoDelay()
        {
            Mouse.ButtonDown(Mouse.MouseKeys.Left);
            Mouse.ButtonUp(Mouse.MouseKeys.Left);
        }
        public static void clickNoDelay(int x, int y)
        {
            moveNoDelay(x, y);
            clickNoDelay();
        }
        public static void clickNoDelay(Point p)
        {
            clickNoDelay(p.X, p.Y);
        }
        public static void click(Point p)
        {
            click(p.X, p.Y);
        }
        public static void click(int x, int y)
        {
            move(x, y);
            click();
        }
        public static void click()
        {
            Thread.Sleep(20);
            Mouse.ButtonDown(Mouse.MouseKeys.Left);
            Thread.Sleep(50);
            Mouse.ButtonUp(Mouse.MouseKeys.Left);
        }
        /// <summary>
        /// Checks points for this color
        /// </summary>
        public static bool checkPoints(JSONDataV2 data)
        {
            if (!data.Active)
                return false;
            foreach (Tuple<Point, Color> item in data.CheckPointColor)
            {
                if (!ColorGet.GetColorAt(item.Item1).Equals(item.Item2))
                    return false;
            }
            return true;
        }

        private BotGUI BotGUI;

        private Dictionary<string, JSONDataV2> DATA;
        private delegate void fuckme(String x);
        public void ChangeTask(String x)
        {
            fuckme Fuckme = new fuckme(BotGUI.ChangeTaskLabel); 
            
            BotGUI.BeginInvoke(Fuckme,x);
        }
        private bool running, kill;
        //private Action<String> ChangeTask;
        public SkeldV3(Dictionary<string, JSONDataV2> data,BotGUI gui)
        {
            BotGUI = gui;
            DATA = data;
        }
        public bool isRunning()
        {
            return running;
        }
        public void Pause()
        {
            running = false;
        }
        public void Resume()
        {
            running = true;
            
        }
        //pause/resume running thread
        public void ToggleOnOff()
        {
            running = !running;
        }
        //kill running thread
        public void killIt()
        {
            kill = true;
        }
        public void run()
        {
            running = true;
            kill = false;
            while (!kill) {
                while (running)
                {
                    Refuel();
                    Thread.Sleep(20);
                    Lights();
                    Thread.Sleep(20);
                    CardSwipe();
                    Thread.Sleep(20);
                    DivertPower();
                    Thread.Sleep(20);
                    AcceptDivertedPower();
                    Thread.Sleep(20);
                    Shields();
                    Thread.Sleep(20);
                    EmptyGarbage();
                    Thread.Sleep(20);
                    StabilizeSteering();
                    Thread.Sleep(20);
                    CalibrateDistributor();
                    Thread.Sleep(20);
                    AlignEngine();
                    Thread.Sleep(20);
                    Wires();
                    Thread.Sleep(20);
                    InspectSample();
                    Thread.Sleep(20);
                    UploadData();
                    Thread.Sleep(400);
                }
                Thread.Sleep(300);
            }
            Console.WriteLine("Bot Exiting");
        }
        public void Refuel()
        {
            JSONDataV2 RefuelData;
            if (!DATA.TryGetValue("Refuel", out RefuelData))
                return;
            if (!checkPoints(RefuelData))
                return;
            ChangeTask("Refuel");
            Console.WriteLine("Refuel");
            Color ledColor = RefuelData.RandomColor[0];
            Point ledPoint = RefuelData.RandomPoint[0];
            Point buttonPoint = RefuelData.RandomPoint[1];
            move(buttonPoint);
            press();
            while (ColorGet.GetColorAt(ledPoint).Equals(ledColor))
            {
                Thread.Sleep(100);
            }
            release();
        }
        public void Lights()
        {
            JSONDataV2 LightsData;
            if (!DATA.TryGetValue("Lights", out LightsData))
                return;
            if (!checkPoints(LightsData))
                return;
            Console.WriteLine("Lights");
            ChangeTask("Lights");
            Point SwitchY = LightsData.RandomPoint[0];//random point 0

            Point[] leds = LightsData.RandomPoint.GetRange(1, 5).ToArray();//random point 1-5

            for (var i = 0; i < leds.Length; i++)
            {
                if (ColorGet.GetColorAt(leds[i]).Equals(LightsData.RandomColor[6]))//random color 0
                    click(leds[i].X, SwitchY.Y);
            }
        }
        public void CardSwipe()
        {
            JSONDataV2 CardSwipeData;
            if (!DATA.TryGetValue("CardSwipe", out CardSwipeData))
                return;
            if (!checkPoints(CardSwipeData))
                return;
            ChangeTask("Card Swipe");
            Console.WriteLine("Card Swipe");
            Point card = CardSwipeData.RandomPoint[0];//random point 0
            Point StartSwipe = CardSwipeData.RandomPoint[1]; //random point 1
            Point EndPoint = CardSwipeData.RandomPoint[2];//random point 2 
            click(card);
            Thread.Sleep(450);
            move(StartSwipe);
            press();
            Console.WriteLine(EndPoint.X - StartSwipe.X + "px");
            /* move(StartSwipe.X+50,StartSwipe.Y);
             Thread.Sleep(480);
             move(EndPoint.X, StartSwipe.Y);*/
            //960/30
            int b = 0;
            int a = (EndPoint.X - StartSwipe.X) / 32;//so that it does it 32 times
            for (var i = StartSwipe.X; i < EndPoint.X; i += a)
            {
                i++;
                moveNoDelay(i, StartSwipe.Y);
                Thread.Sleep(15);
            }
            /* int i = 0;//temp
             for (var a = StartSwipe.X; a < EndPoint.X; a += 30)
             {
                 i++;
                 moveNoDelay(a, StartSwipe.Y);
                 Thread.Sleep(15);
             }*/
            //480ms is valid 
            Console.WriteLine(b + " 30px, 15ms");
            release();
            Console.WriteLine("MAKE CARD SWIPE WORD FOR OTHER GRAPHICS, DYNAMICALLY YK");
        }
        public void DivertPower()
        {
            JSONDataV2 DivertPowerData;
            if (!DATA.TryGetValue("DivertPower", out DivertPowerData))
                return;
            if (!checkPoints(DivertPowerData))
                return;
            ChangeTask("Divert Power");
            Console.WriteLine("Divert Power");
            Point[] sliders = DivertPowerData.RandomPoint.ToArray();//all of random points
            for (var i = 0; i < sliders.Length; i++)
            {
                //if red is higher than 150
                if (ColorGet.GetColorAt(sliders[i]).R > 150)
                {
                    move(sliders[i]);
                    press();
                    Thread.Sleep(30);
                    move(sliders[i].X, 0);
                    release();
                }
            }
        }
        public void AcceptDivertedPower()
        {
            JSONDataV2 AcceptDivertedPowerData;
            if (!DATA.TryGetValue("AcceptDivertedPower", out AcceptDivertedPowerData))
                return;
            if (!checkPoints(AcceptDivertedPowerData))
                return;
            ChangeTask("Accept Diverted Power");
            Console.WriteLine("Accept Diverted Power");
            Point butt = AcceptDivertedPowerData.RandomPoint[0];
            click(butt);
        }
        public void Shields()
        {
            JSONDataV2 ShieldsData;
            if (!DATA.TryGetValue("Shields", out ShieldsData))
                return;
            if (!checkPoints(ShieldsData))
                return;
            ChangeTask("Shields");
            Console.WriteLine("Shields");
            Point[] s = ShieldsData.RandomPoint.ToArray();
            for (var i = 0; i < s.Length; i++)
            {
                if (ColorGet.GetColorAt(s[i]).G < 150)//it appears that the active sheilds greens are higher than 150 and reds are lower
                    click(s[i]);
            }
        }
        public void EmptyGarbage()
        {
            
            JSONDataV2 GarbageData;
            if (!DATA.TryGetValue("EmptyGarbage", out GarbageData))
                return;
            if (!checkPoints(GarbageData))
                return;
            ChangeTask("Empty Garbage");
            Console.WriteLine("Empty Garbage");
            Point handle = GarbageData.RandomPoint[0];//random point 0
            Point handledown = GarbageData.RandomPoint[1];//random point 1
            move(handle);
            Mouse.ButtonDown(Mouse.MouseKeys.Left);
            move(handledown);
            Thread.Sleep(1500);
            Mouse.ButtonUp(Mouse.MouseKeys.Left);

        }
        public void StabilizeSteering()
        {
            
            JSONDataV2 SteeringData;
            if (!DATA.TryGetValue("StabilizeSteering", out SteeringData))
                return;
            if (!checkPoints(SteeringData))
                return;
            ChangeTask("Stabilize Steering");
            Console.WriteLine("Stabilize Steering");
            Point center = SteeringData.RandomPoint[0];//random point 0
            click(center);
        }
        public void CalibrateDistributor()
        {
            JSONDataV2 DistributorData;
            if (!DATA.TryGetValue("CalibrateDistributor", out DistributorData))
                return;
            if (!checkPoints(DistributorData))
                return;
            ChangeTask("Calibrate Distributor");
            Console.WriteLine("Calibrate Distributor");
            Point[] leds = DistributorData.RandomPoint.GetRange(0, 3).ToArray();
            Console.WriteLine();
            Point[] buttons = DistributorData.RandomPoint.GetRange(3, 3).ToArray();//random point 3-5
            for (var i = 0; i < leds.Length; i++)
            {
                int a = 0;
                while (checkPoints(DistributorData) && a < 200)
                {
                    if (!ColorGet.GetColorAt(leds[i]).Equals(Color.FromArgb(255, 0, 0, 0)))
                    {
                        clickNoDelay(buttons[i]);
                        Thread.Sleep(200);
                        if (!ColorGet.GetColorAt(leds[i]).Equals(Color.FromArgb(255, 0, 0, 0)))
                            a = 300;
                    }
                    a++;
                    Thread.Sleep(10);
                }
            }

        }
        public void AlignEngine()
        {
            JSONDataV2 AlignEngineData;
            if (!DATA.TryGetValue("AlignEngine", out AlignEngineData))
                return;
            if (!checkPoints(AlignEngineData))
                return;
            ChangeTask("Align Engine");
            Console.WriteLine("Align Engine");
            List<Point> rp = AlignEngineData.RandomPoint;
            Point top = rp[0];
            Point bottom = rp[1];//random p 1
            Point center = rp[2];//random p 2
            //Color thingColor = Color.FromArgb(255, 163, 163, 178);
            for (var a = top.Y; a < bottom.Y; a += 10)//scan for the thingy
            {
                Color color = ColorGet.GetColorAt(top.X, a);
                //get difference between rgb if its over 5 then its the pointer, probably
                int diff = Math.Max(Math.Max(color.R, color.B), color.G)
                 - Math.Min(Math.Min(color.R, color.B), color.G);
                if (diff > 5)
                {
                    move(top.X, a);
                    press();
                    move(center);
                    release();
                    return;
                }
            }
        }
        public void Wires()
        {
            JSONDataV2 WiresData;
            if (!DATA.TryGetValue("Wires", out WiresData))
                return;
            if (!checkPoints(WiresData))
                return;
            ChangeTask("Wires");
            Console.WriteLine("WIRES, fix me so it works every time");
            Point[] leftWires = WiresData.RandomPoint.GetRange(0, 4).ToArray();//rp 0x4
            Point[] rightWires = WiresData.RandomPoint.GetRange(4, 4).ToArray();

            for (var l = 0; l < leftWires.Length; l++)
            {
                Color leftColor = ColorGet.GetColorAt(leftWires[l]);
                for (var r = 0; r < rightWires.Length; r++)
                {
                    if (ColorGet.GetColorAt(rightWires[r]).Equals(leftColor))
                    {
                        //connect wires
                        move(leftWires[l]);
                        Mouse.ButtonDown(Mouse.MouseKeys.Left);
                        move(rightWires[r]);
                        Mouse.ButtonUp(Mouse.MouseKeys.Left);
                    }
                }
            }
        }
        public void InspectSample()
        {
            JSONDataV2 Sample;
            if (!DATA.TryGetValue("InspectSample", out Sample))
                return;
            if (!checkPoints(Sample))
                return;
            ChangeTask("Inspect Sample");
            Console.WriteLine("Inspect Sample");
            click(Sample.RandomPoint[0]);//point 0 button
            Point[] tubePos = Sample.RandomPoint.GetRange(2, 5).ToArray();//point 2x5

            Point button = Sample.RandomPoint[1];//point 1 

            for (var t = 0; t < tubePos.Length; t++)
            {
                Color a = ColorGet.GetColorAt(tubePos[t]);
                if (a.R > a.B)//check if tube is more red than blue
                {
                    click(tubePos[t].X, button.Y);
                    return;
                }
            }
        }
        public void UploadData()
        {
            JSONDataV2 DataUp;
            if (!DATA.TryGetValue("Data", out DataUp))
                return;
            if (!checkPoints(DataUp))
                return;
            ChangeTask("Upload Data");
            Console.WriteLine("Upload Data");
            click(DataUp.RandomPoint[0]);//point 0
        }
    }
}
