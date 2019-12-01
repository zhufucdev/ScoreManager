using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager
{
    public class Person
    {
        public string Name;
        public readonly Guid ID;
        public Group Group;
        public long Score
        {
            get
            {
                long result = 0;
                Group.Record.ForEach((s) =>
                {
                    if (s.Maker == this)
                        result += s.Value;
                });
                return result;
            }
        }
        public List<Score> Record
        {
            get
            {
                List<Score> scores = new List<Score>();
                Group.Record.ForEach((it) =>
                {
                    if (it.Maker == this)
                    {
                        scores.Add(it);
                    }
                });
                return scores;
            }
        }
        public Person(string name, ref Group group)
        {
            this.Name = name;
            Group = group;
            ID = Guid.NewGuid();
        }

        public Person(string name, ref Group group, Guid id)
        {
            this.Name = name;
            Group = group;
            ID = id;
        }

        public JObject Serialize()
        {
            return new JObject
            {
                { "name", Name },
                { "id", ID.ToString() }
            };
        }

        public override bool Equals(object obj)
        {
            return obj is Person
                && ((Person)obj).ID == ID;
        }

        public override int GetHashCode()
        {
            int hash = Name.GetHashCode();
            hash += 31 * Group.GetHashCode();
            return hash;
        }
    }
}
