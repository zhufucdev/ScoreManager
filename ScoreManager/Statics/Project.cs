using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ScoreManager.Statics
{
    public class Project
    {
        public readonly string Path;
        public string Name;
        private string chiefPassword;
        public bool CanBeSaved = false;
        public DateTime TimeBegin { get; private set; }

        public bool Encryted
        {
            get { return chiefPassword != null; }
        }
        public Project(string File, string Name) {
            this.Path = File;
            this.Name = Name;
            TimeBegin = DateTime.Now;
        }
        public Project(string File, string Name, string password)
        {
            this.Path = File;
            this.Name = Name;
            TimeBegin = DateTime.Now;

            Encrypt(password);
        }
        public readonly List<Group> Groups = new List<Group>();
        public readonly List<Operation> Operations = new List<Operation>();

        public void Encrypt(string newPassword)
        {
            using (SHA256 sha = SHA256.Create())
            {
                chiefPassword = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(newPassword)));
            }
        }

        public void Save()
        {
            string str;
            try
            {
                JObject serialize = new JObject();
                JObject info = new JObject
                {
                    { "name", Name },
                    { "begin", TimeBegin.Ticks }
                };
                if (chiefPassword != null)
                {
                    info.Add("password", chiefPassword);
                }
                serialize.Add("info", info);
                

                JArray groups = new JArray();
                this.Groups.ForEach((it) => groups.Add(it.Serialize()));
                serialize.Add("groups", groups);

                str = serialize.ToString();
            }
            catch (Exception e)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                MessageBox.Show(res.GetString("error.saveProject"), e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                StreamWriter sw = File.CreateText(Path);
                sw.Write(str);
                sw.Close();
                CanBeSaved = false;
            }
            catch (Exception e)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                MessageBox.Show(res.GetString("error.saveFile"), Path + "\n" + e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Person FindPerson(Guid guid)
        {
            foreach(Group g in Groups)
            {
                Person person = g.People.Find((p) => p.ID == guid);
                if (person != null)
                    return person;
            }
            return null;
        }
        public void AddPerson(Person person)
        {
            person.Group.People.Add(person);
        }
        
        public void RemovePerson(Person person)
        {
            person.Group.People.Remove(person);
        }

        public bool ContainsPerson(string name)
        {
            foreach(Group group in Groups)
            {
                if (group.People.FindIndex((it) => it.Name == name) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        public void MovePerson(Person who, Group dest)
        {
            Group oldGroup = who.Group;
            oldGroup.Record.RemoveAll((record) => {
                bool result = record.Maker == who;
                if (result)
                {
                    dest.Record.Add(record);
                }
                return result;
            });

            oldGroup.People.Remove(who);
            dest.People.Add(who);
            who.Group = dest;
        }
        public List<Person> ChartedPeople
        {
            get
            {
                List<Person> people = new List<Person>();
                foreach(Group group in Groups)
                {
                    people.AddRange(group.People);
                }
                people.Sort((x, y) => -x.Score.CompareTo(y.Score));
                return people;
            }
        }

        public bool MatchPassword(string password)
        {
            string sha256;
            using(SHA256 sha = SHA256.Create())
            {
                sha256 = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                sha.Dispose();
            }
            return sha256 == chiefPassword;
        }

        public static Project Open(string path)
        {
            JObject obj = JObject.Parse(File.ReadAllText(path));
            JObject info = obj.Value<JObject>("info");
            Project result = new Project(path, info.Value<string>("name"))
            {
                TimeBegin = new DateTime(info.Value<long>("begin"))
            };
            if (info.ContainsKey("password"))
            {
                result.chiefPassword = info.Value<string>("password");
            }
            JArray groups = obj.Value<JArray>("groups");
            foreach(JObject group in groups)
            {
                result.Groups.Add(Group.Deserialize(group));
            }

            return result;
        }

        public event OperationDoneEventHandler OperationDone;
        public void Do(Operation operation)
        {
            OperationHeader ++;
            for (int i = OperationHeader;i < Operations.Count; i++)
            {
                Operations.RemoveAt(i);
            }
            Operations.Add(operation);

            #region free up memory
            if (Operations.Count >= 50)
            {
                Operations.RemoveAt(0);
                OperationHeader--;
                Operations.ForEach((it) => it.Header--);
            }
            #endregion

            operation.Header = OperationHeader;
            operation.Project = this;
            CanBeSaved = true;

            OperationDone.Invoke();
        }
        public Operation LastOperation
        {
            get
            {
                return OperationHeader > -1 && Operations.Count > OperationHeader ? Operations[OperationHeader] : null;
            }
        }
        public event OperationDoneEventHandler OperationHeaderChanged;
        private int mHeader = -1;
        public int OperationHeader
        {
            get
            {
                return mHeader;
            }
            set
            {
                OperationHeaderChanged.Invoke();
                mHeader = value;
            }
        }
    }
}
