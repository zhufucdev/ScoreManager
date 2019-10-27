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
        }

        public StringCollection AutoCompleteOptions
        {
            set
            {
                autocompleteOptions = value;
            }
            get
            {
                return autocompleteOptions;
            }
        }
        public float FilterThreshold
        {
            set
            {
                threshold = value;
            }
            get
            {
                return threshold;
            }
        }

        private StringCollection autocompleteOptions = new StringCollection();
        private float threshold = 0.7f;

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
                        lastIndex = i;
                        weight += 1f / selector.Length - (i - lastIndex - 1 - spaces) * 0.1f;
                        break;
                    }
                }
            }

            return weight;
        }

        private DateTime lastEdit;
        private void AutoCompleteComboBox_TextUpdate(object sender, EventArgs e)
        {
            Timer timer = new Timer
            {
                Interval = 300
            };
            lastEdit = DateTime.Now;
            timer.Tick += (any, thing) =>
            {
                if ((DateTime.Now - lastEdit).TotalMilliseconds > 300)
                {
                    try
                    {
                        var text = Text;
                        if (text != "")
                        {
                            StringCollection options = autocompleteOptions;
                            if (options == null)
                                return;

                            string pinyin = text;
                            var dictionary = new Dictionary<string, float>();
                            var list = new List<string>();
                            foreach (string option in options)
                            {
                                float weight = select(NPinyin.Pinyin.GetPinyin(option), pinyin);
                                if (weight >= threshold)
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
                        else
                        {
                            Items.Clear();
                            DroppedDown = false;
                        }
                    }
                    catch (Exception ignored) { }
                }
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            
        }
    }
}
