using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class ChangeGroupProperties : Operation
    {
        private Group Old, New;
        public ChangeGroupProperties(Group old, Group newGroup)
        {
            Old = old; New = newGroup;
        }
        private Group Backup;
        public override void Undo()
        {
            base.Undo();
            Backup = New.Clone() as Group;
            New.InitalScore = Old.InitalScore;
            New.Name = Old.Name;
            New.People.Clear();
            New.People.AddRange(Old.People);
            New.Record.Clear();
            New.Record.AddRange(Old.Record);
        }

        public override void Redo()
        {
            base.Redo();
            New.InitalScore = Backup.InitalScore;
            New.Name = Backup.Name;
            New.People.Clear();
            New.People.AddRange(Backup.People);
            New.Record.Clear();
            New.Record.AddRange(Backup.Record);
        }
    }
}
