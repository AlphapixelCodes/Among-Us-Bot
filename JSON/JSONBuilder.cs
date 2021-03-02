using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace Among_Us_Calibrator
{
  public class JSONBuilder
    {
        private List<Action> actions;
        public JSONBuilder()
        {
            actions = new List<Action>();
        }
        public void addAction(Action x)
        {
            actions.Add(x);
        }
        public void addAction(String name, List<Color> checkColor, List<Point> checkPoint, List<Color> pointColorDataColor, List<Point> pointColorDataPoint, List<Point> randomPoints, List<Color> randomColors, bool active)
        {
            actions.Add(new Action(name, checkColor, checkPoint, randomPoints, randomColors, active));
        }
        public String toString
        {
            get
            {
                string ret = "{\"actions\":[";
                for (int i = 0; i < actions.Count; i++)
                {
                    ret += actions[i].toString;
                    if (actions.Count-1 != i)
                        ret += ",";
                    ret += "\n";
                }
                return ret+ "\n]\n}";
            }
        }
        public class Action
        {
            private readonly string name;
            private readonly List<Color> checkColor;
            private readonly List<Point> checkPoint;
            private readonly List<Point> randomPoints;
            private readonly List<Color> randomColors;
            private readonly bool active;
            public Action(String name, List<Color> checkColor, List<Point> checkPoint, List<Point> randomPoints, List<Color> randomColors, bool active)
            {
                this.name = name;
                this.checkColor = checkColor;
                this.checkPoint = checkPoint;
                this.randomPoints = randomPoints ?? new List<Point>();
                this.randomColors = randomColors ?? new List<Color>();
                this.active = active;
            }
            private static String ColorListToJSON(List<Color> color)
            {
                List<String> r = new List<string>();
                foreach (Color a in color)
                {
                    r.Add(String.Format("[{0},{1},{2},{3}]", a.A, a.R, a.G, a.B));
                }   
                return "[" + string.Join(",", r) + "]";
            }
            private static String PointListToJSON(List<Point> point)
            {
                List<String> r = new List<string>();
                foreach (Point a in point)
                {
                    r.Add(String.Format("[{0},{1}]", a.X, a.Y));
                }
                return "[" + string.Join(",", r) + "]";
            }
            public String toString
            {
                get
                {
                    String ret = "{";
                    ret += "\"name\": " +'"'+ name+"\",\n";
                    ret += "\"checkColor\":" + ColorListToJSON(checkColor)+",\n";
                    ret += "\"checkPoint\":" + PointListToJSON(checkPoint) + ",\n";
                    ret += "\"randomPoints\":" + PointListToJSON(randomPoints) + ",\n";
                    ret += "\"randomColors\":"+ColorListToJSON(randomColors)+",\n";
                    ret += "\"Active\":\""+active+"\"\n}";
                    return ret;
                }
            }
        }
    }
}
