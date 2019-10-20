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
        public Size Size;
        public bool Overflow;
        public bool Removed = false;
        public Scoreboard(string name, ScoreboardType type, bool overflow)
        {
            Name = name;
            Type = type;
            Position = new Point((int)(Screen.PrimaryScreen.Bounds.Width * 0.7), 40);
            Size = new Size(400, 300);
            Overflow = overflow;
        }

        public Scoreboard(string name, ScoreboardType type, Point position, Size size, bool overflow)
        {
            Name = name;
            Type = type;
            Position = position;
            Size = size;
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
            result.Add("size", new JObject
            {
                { "width", Size.Width },
                { "height", Size.Height }
            });
            return result.ToString();
        }

        public static Scoreboard Deserialize(string json)
        {
            JObject origin = JObject.Parse(json);
            JObject position = origin.Value<JObject>("position");
            JObject size = origin.Value<JObject>("size");
            return new Scoreboard(origin.Value<string>("name"), (ScoreboardType)origin.Value<int>("type"),
                new Point
                {
                    X = position.Value<int>("x"),
                    Y = position.Value<int>("y")
                }, new Size
                {
                    Width = size.Value<int>("width"),
                    Height = size.Value<int>("height")
                },
                origin.Value<bool>("overflow"));
        }

        public ScoreboardForm NewForm(Form1 parent)
        {
            return new ScoreboardForm(this, parent);
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
