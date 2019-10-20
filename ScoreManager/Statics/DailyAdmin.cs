using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class DailyAdmin
    {
        public string Name;
        private string Password;
        public readonly List<DayOfWeek> WorkingDays = new List<DayOfWeek>();

        public DailyAdmin(string name, string password)
        {
            Name = name;
            ChangePassword(password);
        }

        DailyAdmin(string name)
        {
            Name = name;
        }

        public bool MatchPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(password))) == Password;
            }
        }

        public void ChangePassword(string newPassword)
        {
            using (SHA256 sha = SHA256.Create())
            {
                Password = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(newPassword)));
            }
        }

        public JObject Serialize()
        {
            JObject result = new JObject();
            result.Add("name", Name);
            result.Add("password", Password);
            JArray workingDays = new JArray();
            WorkingDays.ForEach((it) => workingDays.Add((int)it));
            result.Add("workingDays", workingDays);
            return result;
        }

        public static DailyAdmin Deserialize(JObject origin)
        {
            DailyAdmin result = new DailyAdmin(origin.Value<string>("name"))
            {
                Password = origin.Value<string>("password")
            };
            JArray array = origin.Value<JArray>("workingDays");
            foreach(int e in array)
            {
                result.WorkingDays.Add((DayOfWeek)e);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is DailyAdmin && ((DailyAdmin)obj).Name == Name && ((DailyAdmin)obj).Password == Password;
        }

        public override int GetHashCode()
        {
            int result = Name.GetHashCode() * 31;
            result += Password.GetHashCode() * 31;
            return result;
        }
    }
}
