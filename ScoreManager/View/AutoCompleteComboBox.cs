using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager.View
{
    public class AutoCompleteComboBox : ComboBox
    {
        public AutoCompleteComboBox()
        {
            this.TextUpdate += AutoCompleteComboBox_TextUpdate;
            this.DropDown += AutoCompleteComboBox_DropDown;
        }

        private void AutoCompleteComboBox_DropDown(object sender, EventArgs e)
        {
            if (AutoExpendWhenEmpty && Text.Length <= 0)
            {
                addAllOptions();
            }
        }

        public StringCollection AutoCompleteOptions { set; get; } = new StringCollection();
        public float FilterThreshold { set; get; } = 0.7f;
        public bool AutoExpendWhenEmpty { set; get; } = false;

        private float select(string selection, string selector)
        {
            float weight = 0f;
            int lastIndex = -1;
            foreach (char c in selector)
            {
                int spaces = 0;
                for (int i = lastIndex + 1; i < selection.Length; i++)
                {
                    if (selection[i] == ' ')
                    {
                        spaces++;
                    }
                    else if (char.ToLowerInvariant(selection[i]) == char.ToLowerInvariant(c))
                    {
                        weight += 1f / selector.Length - (i - (lastIndex == -1 ? 0 : lastIndex) - 1 - spaces) * 0.05f;
                        lastIndex = i;
                        break;
                    }
                }
            }

            return weight;
        }

        private Timer timer = null;
        private void addAllOptions()
        {
            BeginUpdate();
            Items.Clear();
            foreach (string option in AutoCompleteOptions)
            {
                Items.Add(option);
            }
            EndUpdate();
        }
        private void AutoCompleteComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (timer != null)
                timer.Dispose();
            timer = new Timer
            {
                Interval = 300
            };
            timer.Tick += (any, thing) =>
            {
                try
                {
                    var text = Text;
                    if (text != "")
                    {
                        StringCollection options = AutoCompleteOptions;
                        if (options == null)
                            return;

                        string pinyin = text;
                        var dictionary = new Dictionary<string, float>();
                        var list = new List<string>();
                        foreach (string option in options)
                        {
                            float weight = select(NPinyin.Pinyin.GetPinyin(option), pinyin);
                            if (weight >= FilterThreshold)
                            {
                                dictionary[option] = weight;
                                list.Add(option);
                            }
                        }
                        list.Sort((a, b) => -dictionary[a].CompareTo(dictionary[b]));

                        Items.Clear();
                        list.ForEach((it) => Items.Add(it));
                        DroppedDown = Items.Count > 0;
                        SelectionStart = Text.Length;
                        SelectionLength = 0;
                    }
                    else if (AutoExpendWhenEmpty)
                    {
                        Items.Clear();
                        DroppedDown = false;
                    }
                    else
                    {
                        addAllOptions();
                        DroppedDown = true;
                    }
                }
                catch (Exception) { }
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
