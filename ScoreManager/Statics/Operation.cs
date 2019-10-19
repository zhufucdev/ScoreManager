using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    abstract public class Operation
    {
        public Project Project;
        public int Header = -1;
        virtual public void Undo()
        {
            if (Header > -1)
            {
                Project.OperationHeader = Header - 1;
                Project.CanBeSaved = true;
            }
            else
                throw new NullReferenceException();
        }
        virtual public void Redo()
        {
            if (Header > -1)
            {
                Project.OperationHeader = Header;
                Project.CanBeSaved = true;
            }
            else
                throw new NullReferenceException();
        }
    }
}
