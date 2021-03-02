using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Among_Us_Calibrator.JSON
{
    public class JSONDataV2
    {
        public readonly string Name;
        public readonly List<Tuple<Point, Color>> CheckPointColor;
        public readonly List<Point> RandomPoint;
        public readonly List<Color> RandomColor;
        public readonly bool Active;
        public JSONDataV2(string name, List<Tuple<Point, Color>> checkPointColor, List<Point> randomPoint, List<Color> randomColor, bool active)
        {
            Active = active;
            Name = name;
            CheckPointColor = checkPointColor;
            RandomPoint = randomPoint;
            RandomColor = randomColor;

        }
        private static List<JToken> JEnumerableToList(JEnumerable<JToken> input)
        {
            List<JToken> ret = new List<JToken>();
            foreach (JToken item in input)
            {
                ret.Add(item);
            }
            return ret;
        }
        private static Color ArrayToColor(JToken c)
        {
            List<JToken> xy = JEnumerableToList(c.Children());
            return Color.FromArgb(int.Parse(xy[0] + ""), int.Parse(xy[1] + ""), int.Parse(xy[2] + ""), int.Parse(xy[3] + ""));
        }
        private static Point ArrayToPoint(JToken p)
        {
            List<JToken> xy = JEnumerableToList(p.Children());
            return new Point(int.Parse(xy[0] + ""), int.Parse(xy[1] + ""));
        }
        public static Dictionary<string, JSONDataV2> loadJSON(string filename)
        {
            Console.WriteLine("JSONLoader Start:");
            string data = File.ReadAllText(filename);
            JObject o = JObject.Parse(data);
            JEnumerable<JToken> actions = o.GetValue("actions").Children();
            Dictionary<string, JSONDataV2> JData = new Dictionary<string, JSONDataV2>();
            foreach (JToken item in actions)
            {
                //start checkpointcolor 
                List<JToken> CJcolor = JEnumerableToList(item["checkColor"].Children());
                List<JToken> CJpoint = JEnumerableToList(item["checkPoint"].Children());
                List<Tuple<Point, Color>> checkTuple = new List<Tuple<Point, Color>>();
                //assume that CJcolor and CJpoint are the same size or fuck
                for (int i = 0; i < CJcolor.Count; i++)
                {
                    checkTuple.Add(new Tuple<Point, Color>(ArrayToPoint(CJpoint[i]), ArrayToColor(CJcolor[i])));
                }
                //end checkpointcolor


                //start randomPoints 
                List<Point> randomPoints = new List<Point>();
                foreach (JToken a in item["randomPoints"].Children())
                {
                    randomPoints.Add(ArrayToPoint(a));
                }
                //end random points
                //start random colors
                List<Color> randomColors = new List<Color>();
                foreach (JToken a in item["randomColors"].Children())
                {
                    randomColors.Add(ArrayToColor(a));
                }
                //end random colors
                string name = item["name"] + "";
                JData.Add(name, new JSONDataV2(
                    name,
                    checkTuple,
                    randomPoints,
                    randomColors,
                    bool.Parse(item["Active"] + "")
                    ));

                Console.Write(item["name"] + ":");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Loaded");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("JSONLoader End");
            return JData;
        }
    }

}
