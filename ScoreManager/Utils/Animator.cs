using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager.Utils
{
    class Animator
    {
        private decimal from, to;
        private int mode;

        public long Duration { set; get; }
        public Action<decimal> Action { private get; set; } = null;

        Animator()
        {
        }

        public void Start()
        {
            long times = Duration / 10, count = 0;
            var timer = new Timer
            {
                Interval = 10
            };
            if (mode == 0)
            {
                double delta = 1.0 * ((int)to - (int)from) / Duration * 10;
                if (Action != null)
                    timer.Tick += (e, g) =>
                    {
                        Action.Invoke((int)Math.Round(delta * count, MidpointRounding.AwayFromZero));
                        count++;
                        if (count >= times)
                        {
                            timer.Stop();
                            timer.Dispose();
                        }
                    };
            }
            else if (mode == 1)
            {
                float delta = 1F * ((float)to - (float)from) / Duration * 10;
                if (Action != null)
                    timer.Tick += (e, g) =>
                    {
                        Action.Invoke(new decimal(delta * count));
                        count++;
                        if (count >= times)
                        {
                            timer.Stop();
                            timer.Dispose();
                        }
                    };
            }
        }

        public static Animator OfInt(int from, int to) => new Animator
        {
            from = from,
            to = to,
            mode = 0
        };

        public static Animator OfFloat(float from, float to) => new Animator
        {
            from = new decimal(from),
            to = new decimal(to),
            mode = 0
        };
    }
}
