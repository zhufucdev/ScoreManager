using Newtonsoft.Json.Linq;
using ScoreManager.Statics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager
{
    public class Group : ICloneable
    {
        public long InitalScore;
        public string Name;
        public Color ChosenColor;
        public long Score
        {
            get
            {
                long result = InitalScore;
                Record.ForEach((it) => result += it.Value);
                return result;
            }
        }
        public List<Person> People { get; } = new List<Person>();
        public List<Score> Record { get; } = new List<Score>();

        private static Random random = new Random();
        public Group(string Name, long InitalScore)
        {
            this.Name = Name;
            this.InitalScore = InitalScore;
            ChosenColor = Color.FromArgb(random.Next(int.MinValue, int.MaxValue));
        }

        public JObject Serialize()
        {
            JObject result = new JObject
            {
                { "name", Name },
                { "inital", InitalScore }
            };
            result.Add("color", ChosenColor.ToArgb());

            JArray people = new JArray();
            this.People.ForEach((it) =>
            {
                people.Add(it.Serialize());
            });
            result.Add("people", people);

            JArray record = new JArray();
            this.Record.ForEach((it) =>
            {
                record.Add(it.Serialize());
            });
            result.Add("record", record);
            return result;
        }

        public static Group Deserialize(JObject former, Project context)
        {
            Group result = new Group(former.GetValue("name").ToString(), former.GetValue("inital").ToObject<long>());
            if (former.ContainsKey("color"))
            {
                result.ChosenColor = Color.FromArgb(former.Value<int>("color"));
            }

            foreach(JObject obj in former.GetValue("people").ToObject<JArray>())
            {
                Person person = new Person(obj.GetValue("name").ToString(), ref result, Guid.Parse(obj.GetValue("id").ToString()));
                result.People.Add(person);
            }
            foreach(JObject obj in former.GetValue("record").ToObject<JArray>())
            {
                Guid makerID = Guid.Parse(obj.Value<string>("maker"));
                result.Record.Add(
                    new Score(
                        obj.Value<int>("value"), 
                        obj.Value<string>("reason"),
                        makerID,
                        new DateTime(obj.Value<long>("time")),
                        context
                    )
                );
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Group
                && ((Group)obj).Name == this.Name
                && ((Group)obj).InitalScore == this.InitalScore
                && ((Group)obj).People.Equals(this.People);
        }

        public override int GetHashCode()
        {
            int hash = People.GetHashCode();
            hash += Name.GetHashCode() * 31;
            hash += InitalScore.GetHashCode() * 31;
            return hash;
        }

        public object Clone()
        {
            var result = new Group(Name, InitalScore);
            result.People.AddRange(People);
            result.Record.AddRange(Record);
            return result;
        }
    }
}
