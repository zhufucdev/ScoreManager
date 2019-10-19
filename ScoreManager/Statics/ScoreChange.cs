using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Statics
{
    public class ScoreChange : Operation
    {
        Score Score;
        public ScoreChange(Score what)
        {
            Score = what;
        }

        public override void Undo()
        {
            Score.Maker.Group.Record.Remove(Score);
            base.Undo();
        }

        public override void Redo()
        {
            Score.Maker.Group.Record.Add(Score);
            base.Redo();
        }
    }
}
