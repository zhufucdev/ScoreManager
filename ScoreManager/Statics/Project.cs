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
        public List<DailyAdmin> DailyAdmins;
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
            DailyAdmins = new List<DailyAdmin>();
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
                if (Encryted)
                {
                    info.Add("password", chiefPassword);

                    JArray admins = new JArray();
                    DailyAdmins.ForEach((it) => admins.Add(it.Serialize()));
                    info.Add("admins", admins);
                }
                serialize.Add("info", info);

                JArray groups = new JArray();
                Groups.ForEach((it) => groups.Add(it.Serialize()));
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
        public Person FindPerson(string name)
        {
            string realName = name;
            string groupName = null;
            if (name.EndsWith(")"))
            {
                int index = name.LastIndexOf('(');
                if (index > 0)
                {
                    groupName = name.Substring(index + 1, name.Length - index - 2);
                    realName = name.Substring(0, index);
                }
            }
            foreach (Group g in Groups)
            {
                Person person = g.People.Find((p) => p.Name == realName 
                && (groupName == null || p.Group.Name == groupName));
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

        public List<DailyAdmin> TodaysAdmins
        {
            get
            {
                return DailyAdmins.FindAll((it) => it.WorkingDays.Contains(DateTime.Today.DayOfWeek));
            }
        }
        public MatchResult MatchPassword(string password)
        {
            if (!Encryted)
                return MatchResult.ChiefAdmin;
            string sha256;
            using(SHA256 sha = SHA256.Create())
            {
                sha256 = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
                sha.Dispose();
            }
            if (chiefPassword == sha256)
            {
                return MatchResult.ChiefAdmin;
            }
            else
            {
                foreach (DailyAdmin it in TodaysAdmins)
                {
                    if (it.MatchPassword(password))
                        return new MatchResult(it);
                }
                return MatchResult.Locked;
            }
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
                result.DailyAdmins = new List<DailyAdmin>();
                JArray admins = info.Value<JArray>("admins");
                foreach(JObject admin in admins)
                {
                    result.DailyAdmins.Add(DailyAdmin.Deserialize(admin));
                }
            }
            JArray groups = obj.Value<JArray>("groups");
            foreach(JObject group in groups)
            {
                result.Groups.Add(Group.Deserialize(group));
            }

            return result;
        }

        public class ProjectImporter
        {
            public ProjectImporter() { }
            public event ElementDuplicatedHandler MemberDuplicated;
            public event ElementDuplicatedHandler GroupDuplicated;
            public void Import(Project to, Project from)
            {
                if (from == null)
                {
                    throw new ArgumentNullException(nameof(from));
                }
                if (to == null)
                {
                    throw new ArgumentNullException(nameof(to));
                }
                if (from.Equals(to))
                {
                    throw new FieldAccessException();
                }

                foreach (Group g in from.Groups)
                {
                    Group sameName = to.Groups.Find((it) => it.Name == g.Name);
                    if (sameName == null)
                    {
                        var clone = g.Clone() as Group;
                        clone.Record.Clear();
                        to.Groups.Add(clone);
                    }
                    else
                    {
                        bool cancel = false;
                        switch (GroupDuplicated.Invoke(sameName, g))
                        {
                            case DialogResult.Yes:
                                foreach (Person p in g.People)
                                {
                                    Person duplicate = sameName.People.Find((it) => it.Name == p.Name);
                                    if (duplicate == null)
                                    {
                                        sameName.People.Add(p);
                                    }
                                    else
                                    {
                                        switch (MemberDuplicated.Invoke(duplicate, p))
                                        {
                                            case DialogResult.Yes:
                                                sameName.People.Remove(duplicate);
                                                sameName.People.Add(p);
                                                break;
                                            case DialogResult.Cancel:
                                                cancel = true;
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (cancel)
                                        break;
                                }
                                if (!cancel)
                                {
                                    sameName.InitalScore = g.InitalScore;
                                    sameName.ChosenColor = g.ChosenColor;
                                }
                                break;
                            case DialogResult.Cancel:
                                cancel = true;
                                break;
                            default:
                                break;
                        }

                        if (cancel)
                            break;
                    }
                }
                if (from.Encryted)
                    from.DailyAdmins.ForEach((it) =>
                    {
                        if (!to.DailyAdmins.Contains(it))
                        {
                            to.DailyAdmins.Add(it);
                        }
                    });
            }
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

            #region Free up memory
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
            
            if (OperationDone != null)
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
                if (OperationHeaderChanged != null)
                    OperationHeaderChanged.Invoke();
                mHeader = value;
            }
        }

        public class MatchResult
        {
            public Permission Permission;
            public DailyAdmin Admin = null;
            public bool CanChangeScore
            {
                get
                {
                    return Permission != Permission.Locked;
                }
            }
            public bool CanChangeMember
            {
                get
                {
                    return Permission == Permission.ChiefAdmin;
                }
            }
            MatchResult(Permission permission)
            {
                Permission = permission;
            }
            public MatchResult(DailyAdmin admin)
            {
                Permission = Permission.DailyAdmin;
                Admin = admin;
            }
            public static MatchResult Locked
            {
                get
                {
                    return new MatchResult(Permission.Locked);
                }
            }
            public static MatchResult ChiefAdmin
            {
                get
                {
                    return new MatchResult(Permission.ChiefAdmin);
                }
            }

            public override bool Equals(object obj)
            {
                return obj is MatchResult && ((MatchResult)obj).Permission == Permission && ((MatchResult)obj).Admin == Admin;
            }
        }
        public enum Permission
        {
            Locked, ChiefAdmin, DailyAdmin
        }
    }
}
