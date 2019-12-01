using Newtonsoft.Json.Linq;
using ScoreManager.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager
{
    public class Score
    {
        public int Value;
        public string Reason;
        private Person maker;
        private KeyValuePair<Project, Guid> context;
        public Person Maker 
        {
            get
            {
                if (maker == null)
                {
                    maker = context.Key.FindPerson(context.Value);
                }
                return maker;
            }
        }
        public readonly DateTime Time;
        public Score(int Value, string Reason, Person Maker)
        {
            this.Value = Value;
            this.Reason = Reason;
            maker = Maker;
            Time = DateTime.Now;
        }

        public Score(int Value, string Reason, Guid Maker, DateTime Time, Project Context)
        {
            this.Value = Value;
            this.Reason = Reason;
            context = new KeyValuePair<Project, Guid>(Context, Maker);
            this.Time = Time;
        }

        public JObject Serialize()
        {
            return new JObject
            {
                { "value", Value },
                { "maker", Maker.ID.ToString()},
                { "time", Time.Ticks },
                { "reason", Reason }
            };
        }


        public override bool Equals(object obj)
        {
            return obj is Score
                && ((Score)obj).Time == this.Time
                && ((Score)obj).Value == this.Value
                && ((Score)obj).Reason == this.Reason
                && ((Score)obj).Maker == this.Maker;
        }

        public override int GetHashCode()
        {
            int hash = Value.GetHashCode();
            hash += Reason.GetHashCode() * 31;
            hash += Maker.GetHashCode() * 31;
            return hash;
        }

        public string DateString
        {
            get
            {
                return Time.ToShortDateString() + " " + Time.ToShortTimeString();
            }
        }
    }
}
