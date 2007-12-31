namespace krchhto
{
    partial class SearchDialog
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
            this.matchCase = new System.Windows.Forms.CheckBox();
            this.matchWholeWord = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downButton = new System.Windows.Forms.RadioButton();
            this.upButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.searchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // matchCase
            // 
            this.matchCase.AutoSize = true;
            this.matchCase.Location = new System.Drawing.Point(343, 69);
            this.matchCase.Name = "matchCase";
            this.matchCase.Size = new System.Drawing.Size(15, 14);
            this.matchCase.TabIndex = 13;
            this.matchCase.Tag = "";
            this.matchCase.UseVisualStyleBackColor = true;
            // 
            // matchWholeWord
            // 
            this.matchWholeWord.AutoSize = true;
            this.matchWholeWord.Location = new System.Drawing.Point(343, 47);
            this.matchWholeWord.Name = "matchWholeWord";
            this.matchWholeWord.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.matchWholeWord.Size = new System.Drawing.Size(15, 14);
            this.matchWholeWord.TabIndex = 12;
            this.matchWholeWord.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.downButton);
            this.groupBox1.Controls.Add(this.upButton);
            this.groupBox1.Location = new System.Drawing.Point(102, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 47);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ÃÂ ";
            // 
            // downButton
            // 
            this.downButton.AutoSize = true;
            this.downButton.Location = new System.Drawing.Point(6, 19);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(51, 25);
            this.downButton.TabIndex = 1;
            this.downButton.TabStop = true;
            this.downButton.Text = "Å«∆Ì‰";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.AutoSize = true;
            this.upButton.Location = new System.Drawing.Point(65, 19);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(41, 25);
            this.upButton.TabIndex = 0;
            this.upButton.TabStop = true;
            this.upButton.Text = "»«·«";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cancelButton.Location = new System.Drawing.Point(12, 43);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "·€Ê";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.findButton.Location = new System.Drawing.Point(12, 13);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "Ì«› ‰ »⁄œÌ";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // searchString
            // 
            this.searchString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchString.Location = new System.Drawing.Point(101, 14);
            this.searchString.Name = "searchString";
            this.searchString.Size = new System.Drawing.Size(207, 21);
            this.searchString.TabIndex = 8;
            this.searchString.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ã” ÃÊÌ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = " ÿ«»ﬁ œﬁÌﬁ Õ—Ê›";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "›ﬁÿ Ì«› ‰ ﬂ·„Â Ì ﬂ«„·";
            // 
            // SearchDialog
            // 
            this.AcceptButton = this.findButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(368, 103);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.matchCase);
            this.Controls.Add(this.matchWholeWord);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.searchString);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ﬂ«œ— Ã” ÃÊ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox matchCase;
        private System.Windows.Forms.CheckBox matchWholeWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton downButton;
        private System.Windows.Forms.RadioButton upButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox searchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}