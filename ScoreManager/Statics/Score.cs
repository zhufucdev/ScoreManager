using Newtonsoft.Json.Linq;
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
        public readonly Person Maker;
        public readonly DateTime Time;
        public Score(int Value, string Reason, Person Maker)
        {
            this.Value = Value;
            this.Reason = Reason;
            this.Maker = Maker;
            Time = DateTime.Now;
        }

        public Score(int Value, string Reason, Person Maker, DateTime Time)
        {
            this.Value = Value;
            this.Reason = Reason;
            this.Maker = Maker;
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
    }
}
