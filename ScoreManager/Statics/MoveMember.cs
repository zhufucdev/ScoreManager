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
        bool record;
        public MoveMember(Person who, Group from, Group to, bool moveRecords)
        {
            person = who;
            this.from = from;
            this.to = to;
            record = moveRecords;
        }

        public override void Undo()
        {
            Project.MovePerson(person, from, record);
            base.Undo();
        }

        public override void Redo()
        {
            Project.MovePerson(person, to, record);
            base.Redo();
        }
    }
}
