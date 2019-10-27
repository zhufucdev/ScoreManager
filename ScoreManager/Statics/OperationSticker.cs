using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class OperationSticker : Operation
    {
        public Operation[] Operations;
        public OperationSticker(params Operation[] operations)
        {
            Operations = operations;
        }

        public override void Undo()
        {
            foreach(Operation operation in Operations)
            {
                operation.Header = Header;
                operation.Project = Project;
                operation.Undo();
            }
            base.Undo();
        }

        public override void Redo()
        {
            foreach (Operation operation in Operations)
            {
                operation.Header = Header;
                operation.Redo();
            }
            base.Redo();
        }
    }
}
