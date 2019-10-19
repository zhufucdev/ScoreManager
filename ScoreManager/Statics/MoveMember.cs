using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class MoveMember : Operation
    {
        Person person;
        Group from, to;
        public MoveMember(Person who, Group from, Group to)
        {
            person = who;
            this.from = from;
            this.to = to;
        }

        public override void Undo()
        {
            Project.MovePerson(person, from);
            base.Undo();
        }

        public override void Redo()
        {
            Project.MovePerson(person, to);
            base.Redo();
        }
    }
}
