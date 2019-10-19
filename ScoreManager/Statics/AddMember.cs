using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class AddMember : Operation
    {
        private Person who;
        public AddMember(Person who)
        {
            this.who = who;
        }
        public override void Undo()
        {
            Project.RemovePerson(who);
            base.Undo();
        }

        public override void Redo()
        {
            Project.AddPerson(who);
            base.Redo();
        }
    }
}
