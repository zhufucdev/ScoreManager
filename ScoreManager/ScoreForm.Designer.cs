namespace ScoreManager
{
    partial class ScoreForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.targetLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Location = new System.Drawing.Point(12, 9);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(56, 17);
            this.targetLabel.TabIndex = 0;
            this.targetLabel.Text = "计分目标";
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(15, 29);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(320, 26);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(147, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 68);
            this.button1.TabIndex = 2;
            this.button1.Text = "8";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnNumber);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(15, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 68);
            this.button2.TabIndex = 3;
            this.button2.Text = "7";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.OnNumber);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(284, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 68);
            this.button3.TabIndex = 4;
            this.button3.Text = "9";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.OnNumber);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(284, 193);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 68);
            this.button4.TabIndex = 7;
            this.button4.Text = "6";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.OnNumber);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(15, 193);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 68);
            this.button5.TabIndex = 6;
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.OnNumber);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(147, 193);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(131, 68);
            this.button6.TabIndex = 5;
            this.button6.Text = "5";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.OnNumber);
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Location = new System.Drawing.Point(284, 267);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 70);
            this.button7.TabIndex = 10;
            this.button7.Text = "3";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.OnNumber);
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.Location = new System.Drawing.Point(15, 267);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(127, 70);
            this.button8.TabIndex = 9;
            this.button8.Text = "1";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.OnNumber);
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.Location = new System.Drawing.Point(147, 267);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(131, 70);
            this.button9.TabIndex = 8;
            this.button9.Text = "2";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.OnNumber);
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.confirm.Location = new System.Drawing.Point(284, 343);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(126, 70);
            this.confirm.TabIndex = 13;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            this.confirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.confirm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button11.Location = new System.Drawing.Point(15, 343);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(127, 70);
            this.button11.TabIndex = 12;
            this.button11.Text = "+";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button12.Location = new System.Drawing.Point(147, 343);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(131, 70);
            this.button12.TabIndex = 11;
            this.button12.Text = "0";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.OnNumber);
            this.button12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Location = new System.Drawing.Point(341, 29);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(69, 26);
            this.button10.TabIndex = 14;
            this.button10.Text = "←";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Delete_Click);
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.button10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(12, 58);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(32, 17);
            this.reasonLabel.TabIndex = 15;
            this.reasonLabel.Text = "原因";
            // 
            // reasonBox
            // 
            this.reasonBox.FormattingEnabled = true;
            this.reasonBox.Location = new System.Drawing.Point(15, 78);
            this.reasonBox.Name = "reasonBox";
            this.reasonBox.Size = new System.Drawing.Size(395, 25);
            this.reasonBox.TabIndex = 16;
            // 
            // ScoreForm
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 425);
            this.Controls.Add(this.reasonBox);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.targetLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ScoreForm";
            this.Text = "计分";
            this.Load += new System.EventHandler(this.ScoreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.ComboBox reasonBox;
    }
}