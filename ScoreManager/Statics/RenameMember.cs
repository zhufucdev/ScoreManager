using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class RenameMember : Operation
    {
        Person Member;
        string OldName, NewName;
        public RenameMember(Person who, string oldName, string newName)
        {
            Member = who;
            OldName = oldName;
            NewName = newName;
        }

        public override void Undo()
        {
            Member.Name = OldName;
            base.Undo();
        }

        public override void Redo()
        {
            Member.Name = NewName;
            base.Redo();
        }
    }
}
