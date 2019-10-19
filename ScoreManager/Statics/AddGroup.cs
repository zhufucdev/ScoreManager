using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class AddGroup : Operation
    {
        Group Group;
        int GroupIndex;
        public AddGroup(Group which)
        {
            Group = which;
        }

        public override void Undo()
        {
            GroupIndex = Project.Groups.IndexOf(Group);
            Project.Groups.Remove(Group);
            base.Undo();
        }

        public override void Redo()
        {
            Project.Groups.Insert(GroupIndex, Group);
            base.Redo();
        }
    }
}
