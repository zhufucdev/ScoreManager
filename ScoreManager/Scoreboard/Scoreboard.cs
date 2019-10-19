using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager.Scoreboard
{
    public class Scoreboard
    {
        public ScoreboardType Type;
        public string Name;
        public Point Position;
        public bool Overflow;
        public Scoreboard(string name, ScoreboardType type, bool overflow)
        {
            Name = name;
            Type = type;
            Position = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.7), Screen.PrimaryScreen.Bounds.Height);
            Overflow = overflow;
        }

        public Scoreboard(string name, ScoreboardType type, Point position, bool overflow)
        {
            Name = name;
            Type = type;
            Position = position;
            Overflow = overflow;
        }

        public override string ToString()
        {
            JObject result = new JObject
            {
                { "name", Name },
                { "type", (int)Type },
                { "overflow", Overflow }
            };
            result.Add("position", new JObject
            {
                { "x", Position.X },
                { "y", Position.Y }
            });
            return result.ToString();
        }

        public static Scoreboard Deserialize(string json)
        {
            JObject origin = JObject.Parse(json);
            JObject position = origin.Value<JObject>("position");
            Console.WriteLine(position);
            return new Scoreboard(origin.Value<string>("name"), (ScoreboardType)origin.Value<int>("type"),
                new Point()
                {
                    X = position.Value<int>("x"),
                    Y = position.Value<int>("y")
                }, origin.Value<bool>("overflow"));
        }

        public override bool Equals(object obj)
        {
            return obj is Scoreboard && ((Scoreboard)obj).Name == Name && ((Scoreboard)obj).Type == Type;
        }

        public override int GetHashCode()
        {
            int result = Name.GetHashCode() * 31;
            result += Type.GetHashCode();
            return result;
        }
    }
}
