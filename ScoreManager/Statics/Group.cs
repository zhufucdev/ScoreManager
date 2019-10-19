using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager
{
    public class Group
    {
        public long InitalScore;
        public string Name;
        public long Score
        {
            get
            {
                long result = InitalScore;
                record.ForEach((it) => result += it.Value);
                return result;
            }
        }
        public List<Person> People
        {
            get
            {
                return people;
            }
        }
        public List<Score> Record
        {
            get
            {
                return record;
            }
        }
        private List<Person> people = new List<Person>();
        private List<Score> record = new List<Score>();
        public Group(string Name, long InitalScore)
        {
            this.Name = Name;
            this.InitalScore = InitalScore;
        }

        public JObject Serialize()
        {
            JObject result = new JObject
            {
                { "name", Name },
                { "inital", InitalScore }
            };
            

            JArray people = new JArray();
            this.people.ForEach((it) =>
            {
                people.Add(it.Serialize());
            });
            result.Add("people", people);

            JArray record = new JArray();
            this.record.ForEach((it) =>
            {
                record.Add(it.Serialize());
            });
            result.Add("record", record);
            return result;
        }

        public static Group Deserialize(JObject former)
        {
            Group result = new Group(former.GetValue("name").ToString(), former.GetValue("inital").ToObject<long>());
            foreach(JObject obj in former.GetValue("people").ToObject<JArray>())
            {
                Person person = new Person(obj.GetValue("name").ToString(), result, Guid.Parse(obj.GetValue("id").ToString()));
                result.People.Add(person);
            }
            foreach(JObject obj in former.GetValue("record").ToObject<JArray>())
            {
                Guid makerID = Guid.Parse(obj.Value<string>("maker"));
                result.Record.Add(
                    new Score(
                        obj.Value<int>("value"), 
                        obj.Value<string>("reason"),
                        result.People.Find((p) => p.ID == makerID),
                        new DateTime(obj.Value<long>("time"))
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
                && ((Group)obj).People == this.People;
        }

        public override int GetHashCode()
        {
            int hash = people.GetHashCode();
            hash += Name.GetHashCode() * 31;
            hash += InitalScore.GetHashCode() * 31;
            return hash;
        }
    }
}
