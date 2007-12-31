namespace krchhto
{
    partial class frmCalendar
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
            this.components = new System.ComponentModel.Container();
            this.tabsCalendar = new System.Windows.Forms.TabControl();
            this.tbpCalendarAr = new System.Windows.Forms.TabPage();
            this.dgvCalendarAr = new System.Windows.Forms.DataGridView();
            this.mnuCalendarAr = new System.Windows.Forms.MenuStrip();
            this.tmiCalendarInsertAr = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCalendarEditAr = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCalendarEraseAr = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpCalendarEn = new System.Windows.Forms.TabPage();
            this.dgvCalendarEn = new System.Windows.Forms.DataGridView();
            this.mnuCalendarEn = new System.Windows.Forms.MenuStrip();
            this.tmiCalendarInsertEn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCalendarEditEn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCalendarEraseEn = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpCalendarFa = new System.Windows.Forms.TabPage();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.mnuCalendar = new System.Windows.Forms.MenuStrip();
            this.tmiCalendarInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCalendarEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCalendarErase = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCalendarAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miCalendarEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miCalendarErase = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsCalendar.SuspendLayout();
            this.tbpCalendarAr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendarAr)).BeginInit();
            this.mnuCalendarAr.SuspendLayout();
            this.tbpCalendarEn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendarEn)).BeginInit();
            this.mnuCalendarEn.SuspendLayout();
            this.tbpCalendarFa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.mnuCalendar.SuspendLayout();
            this.ctxCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsCalendar
            // 
            this.tabsCalendar.Controls.Add(this.tbpCalendarAr);
            this.tabsCalendar.Controls.Add(this.tbpCalendarEn);
            this.tabsCalendar.Controls.Add(this.tbpCalendarFa);
            this.tabsCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsCalendar.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabsCalendar.Location = new System.Drawing.Point(0, 0);
            this.tabsCalendar.Name = "tabsCalendar";
            this.tabsCalendar.SelectedIndex = 0;
            this.tabsCalendar.Size = new System.Drawing.Size(544, 368);
            this.tabsCalendar.TabIndex = 0;
            this.tabsCalendar.SelectedIndexChanged += new System.EventHandler(this.tabsCalendar_SelectedIndexChanged);
            // 
            // tbpCalendarAr
            // 
            this.tbpCalendarAr.Controls.Add(this.dgvCalendarAr);
            this.tbpCalendarAr.Controls.Add(this.mnuCalendarAr);
            this.tbpCalendarAr.Location = new System.Drawing.Point(4, 30);
            this.tbpCalendarAr.Name = "tbpCalendarAr";
            this.tbpCalendarAr.Size = new System.Drawing.Size(536, 334);
            this.tbpCalendarAr.TabIndex = 0;
            this.tbpCalendarAr.Text = "التقويم";
            this.tbpCalendarAr.UseVisualStyleBackColor = true;
            // 
            // dgvCalendarAr
            // 
            this.dgvCalendarAr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendarAr.ContextMenuStrip = this.ctxCalendar;
            this.dgvCalendarAr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalendarAr.Location = new System.Drawing.Point(0, 29);
            this.dgvCalendarAr.Name = "dgvCalendarAr";
            this.dgvCalendarAr.ReadOnly = true;
            this.dgvCalendarAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCalendarAr.Size = new System.Drawing.Size(536, 305);
            this.dgvCalendarAr.TabIndex = 3;
            this.dgvCalendarAr.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCalendar_CellMouseClick);
            this.dgvCalendarAr.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendar_CellEnter);
            // 
            // mnuCalendarAr
            // 
            this.mnuCalendarAr.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mnuCalendarAr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCalendarInsertAr,
            this.tmiCalendarEditAr,
            this.tmiCalendarEraseAr});
            this.mnuCalendarAr.Location = new System.Drawing.Point(0, 0);
            this.mnuCalendarAr.Name = "mnuCalendarAr";
            this.mnuCalendarAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuCalendarAr.Size = new System.Drawing.Size(536, 29);
            this.mnuCalendarAr.TabIndex = 2;
            // 
            // tmiCalendarInsertAr
            // 
            this.tmiCalendarInsertAr.Name = "tmiCalendarInsertAr";
            this.tmiCalendarInsertAr.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tmiCalendarInsertAr.Size = new System.Drawing.Size(66, 25);
            this.tmiCalendarInsertAr.Text = "درج   F5";
            this.tmiCalendarInsertAr.Click += new System.EventHandler(this.tmiCalendarInsert_Click);
            // 
            // tmiCalendarEditAr
            // 
            this.tmiCalendarEditAr.Enabled = false;
            this.tmiCalendarEditAr.Name = "tmiCalendarEditAr";
            this.tmiCalendarEditAr.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tmiCalendarEditAr.Size = new System.Drawing.Size(82, 25);
            this.tmiCalendarEditAr.Text = "ویرایش   F6";
            this.tmiCalendarEditAr.Click += new System.EventHandler(this.tmiCalendarEdit_Click);
            // 
            // tmiCalendarEraseAr
            // 
            this.tmiCalendarEraseAr.Enabled = false;
            this.tmiCalendarEraseAr.Name = "tmiCalendarEraseAr";
            this.tmiCalendarEraseAr.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tmiCalendarEraseAr.Size = new System.Drawing.Size(70, 25);
            this.tmiCalendarEraseAr.Text = "حذف   F8";
            this.tmiCalendarEraseAr.Click += new System.EventHandler(this.tmiCalendarErase_Click);
            // 
            // tbpCalendarEn
            // 
            this.tbpCalendarEn.Controls.Add(this.dgvCalendarEn);
            this.tbpCalendarEn.Controls.Add(this.mnuCalendarEn);
            this.tbpCalendarEn.Location = new System.Drawing.Point(4, 30);
            this.tbpCalendarEn.Name = "tbpCalendarEn";
            this.tbpCalendarEn.Size = new System.Drawing.Size(536, 334);
            this.tbpCalendarEn.TabIndex = 1;
            this.tbpCalendarEn.Text = "Calendar";
            this.tbpCalendarEn.UseVisualStyleBackColor = true;
            // 
            // dgvCalendarEn
            // 
            this.dgvCalendarEn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendarEn.ContextMenuStrip = this.ctxCalendar;
            this.dgvCalendarEn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalendarEn.Location = new System.Drawing.Point(0, 29);
            this.dgvCalendarEn.Name = "dgvCalendarEn";
            this.dgvCalendarEn.ReadOnly = true;
            this.dgvCalendarEn.Size = new System.Drawing.Size(536, 305);
            this.dgvCalendarEn.TabIndex = 3;
            this.dgvCalendarEn.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCalendar_CellMouseClick);
            this.dgvCalendarEn.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendar_CellEnter);
            // 
            // mnuCalendarEn
            // 
            this.mnuCalendarEn.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mnuCalendarEn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCalendarInsertEn,
            this.tmiCalendarEditEn,
            this.tmiCalendarEraseEn});
            this.mnuCalendarEn.Location = new System.Drawing.Point(0, 0);
            this.mnuCalendarEn.Name = "mnuCalendarEn";
            this.mnuCalendarEn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuCalendarEn.Size = new System.Drawing.Size(536, 29);
            this.mnuCalendarEn.TabIndex = 2;
            // 
            // tmiCalendarInsertEn
            // 
            this.tmiCalendarInsertEn.Name = "tmiCalendarInsertEn";
            this.tmiCalendarInsertEn.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tmiCalendarInsertEn.Size = new System.Drawing.Size(66, 25);
            this.tmiCalendarInsertEn.Text = "درج   F5";
            this.tmiCalendarInsertEn.Click += new System.EventHandler(this.tmiCalendarInsert_Click);
            // 
            // tmiCalendarEditEn
            // 
            this.tmiCalendarEditEn.Enabled = false;
            this.tmiCalendarEditEn.Name = "tmiCalendarEditEn";
            this.tmiCalendarEditEn.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tmiCalendarEditEn.Size = new System.Drawing.Size(82, 25);
            this.tmiCalendarEditEn.Text = "ویرایش   F6";
            this.tmiCalendarEditEn.Click += new System.EventHandler(this.tmiCalendarEdit_Click);
            // 
            // tmiCalendarEraseEn
            // 
            this.tmiCalendarEraseEn.Enabled = false;
            this.tmiCalendarEraseEn.Name = "tmiCalendarEraseEn";
            this.tmiCalendarEraseEn.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tmiCalendarEraseEn.Size = new System.Drawing.Size(70, 25);
            this.tmiCalendarEraseEn.Text = "حذف   F8";
            this.tmiCalendarEraseEn.Click += new System.EventHandler(this.tmiCalendarErase_Click);
            // 
            // tbpCalendarFa
            // 
            this.tbpCalendarFa.Controls.Add(this.dgvCalendar);
            this.tbpCalendarFa.Controls.Add(this.mnuCalendar);
            this.tbpCalendarFa.Location = new System.Drawing.Point(4, 30);
            this.tbpCalendarFa.Name = "tbpCalendarFa";
            this.tbpCalendarFa.Size = new System.Drawing.Size(536, 334);
            this.tbpCalendarFa.TabIndex = 2;
            this.tbpCalendarFa.Text = "تقویم";
            this.tbpCalendarFa.UseVisualStyleBackColor = true;
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.ContextMenuStrip = this.ctxCalendar;
            this.dgvCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalendar.Location = new System.Drawing.Point(0, 29);
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.ReadOnly = true;
            this.dgvCalendar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCalendar.Size = new System.Drawing.Size(536, 305);
            this.dgvCalendar.TabIndex = 1;
            this.dgvCalendar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCalendar_CellMouseClick);
            this.dgvCalendar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendar_CellEnter);
            // 
            // mnuCalendar
            // 
            this.mnuCalendar.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mnuCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCalendarInsert,
            this.tmiCalendarEdit,
            this.tmiCalendarErase});
            this.mnuCalendar.Location = new System.Drawing.Point(0, 0);
            this.mnuCalendar.Name = "mnuCalendar";
            this.mnuCalendar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuCalendar.Size = new System.Drawing.Size(536, 29);
            this.mnuCalendar.TabIndex = 0;
            // 
            // tmiCalendarInsert
            // 
            this.tmiCalendarInsert.Name = "tmiCalendarInsert";
            this.tmiCalendarInsert.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tmiCalendarInsert.Size = new System.Drawing.Size(66, 25);
            this.tmiCalendarInsert.Text = "درج   F5";
            this.tmiCalendarInsert.Click += new System.EventHandler(this.tmiCalendarInsert_Click);
            // 
            // tmiCalendarEdit
            // 
            this.tmiCalendarEdit.Enabled = false;
            this.tmiCalendarEdit.Name = "tmiCalendarEdit";
            this.tmiCalendarEdit.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tmiCalendarEdit.Size = new System.Drawing.Size(82, 25);
            this.tmiCalendarEdit.Text = "ویرایش   F6";
            this.tmiCalendarEdit.Click += new System.EventHandler(this.tmiCalendarEdit_Click);
            // 
            // tmiCalendarErase
            // 
            this.tmiCalendarErase.Enabled = false;
            this.tmiCalendarErase.Name = "tmiCalendarErase";
            this.tmiCalendarErase.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tmiCalendarErase.Size = new System.Drawing.Size(70, 25);
            this.tmiCalendarErase.Text = "حذف   F8";
            this.tmiCalendarErase.Click += new System.EventHandler(this.tmiCalendarErase_Click);
            // 
            // ctxCalendar
            // 
            this.ctxCalendar.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctxCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCalendarAdd,
            this.miCalendarEdit,
            this.miCalendarErase});
            this.ctxCalendar.Name = "ctxCalendar";
            this.ctxCalendar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxCalendar.Size = new System.Drawing.Size(117, 82);
            // 
            // miCalendarAdd
            // 
            this.miCalendarAdd.Name = "miCalendarAdd";
            this.miCalendarAdd.Size = new System.Drawing.Size(116, 26);
            this.miCalendarAdd.Text = "درج";
            this.miCalendarAdd.Click += new System.EventHandler(this.tmiCalendarInsert_Click);
            // 
            // miCalendarEdit
            // 
            this.miCalendarEdit.Name = "miCalendarEdit";
            this.miCalendarEdit.Size = new System.Drawing.Size(116, 26);
            this.miCalendarEdit.Text = "ویرایش";
            this.miCalendarEdit.Click += new System.EventHandler(this.tmiCalendarEdit_Click);
            // 
            // miCalendarErase
            // 
            this.miCalendarErase.Name = "miCalendarErase";
            this.miCalendarErase.Size = new System.Drawing.Size(116, 26);
            this.miCalendarErase.Text = "حذف";
            this.miCalendarErase.Click += new System.EventHandler(this.tmiCalendarErase_Click);
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 368);
            this.Controls.Add(this.tabsCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuCalendar;
            this.MaximizeBox = false;
            this.Name = "frmCalendar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تقویم";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            this.tabsCalendar.ResumeLayout(false);
            this.tbpCalendarAr.ResumeLayout(false);
            this.tbpCalendarAr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendarAr)).EndInit();
            this.mnuCalendarAr.ResumeLayout(false);
            this.mnuCalendarAr.PerformLayout();
            this.tbpCalendarEn.ResumeLayout(false);
            this.tbpCalendarEn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendarEn)).EndInit();
            this.mnuCalendarEn.ResumeLayout(false);
            this.mnuCalendarEn.PerformLayout();
            this.tbpCalendarFa.ResumeLayout(false);
            this.tbpCalendarFa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.mnuCalendar.ResumeLayout(false);
            this.mnuCalendar.PerformLayout();
            this.ctxCalendar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsCalendar;
        private System.Windows.Forms.TabPage tbpCalendarAr;
        private System.Windows.Forms.TabPage tbpCalendarEn;
        private System.Windows.Forms.TabPage tbpCalendarFa;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.MenuStrip mnuCalendar;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarInsert;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarEdit;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarErase;
        private System.Windows.Forms.DataGridView dgvCalendarAr;
        private System.Windows.Forms.MenuStrip mnuCalendarAr;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarInsertAr;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarEditAr;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarEraseAr;
        private System.Windows.Forms.DataGridView dgvCalendarEn;
        private System.Windows.Forms.MenuStrip mnuCalendarEn;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarInsertEn;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarEditEn;
        private System.Windows.Forms.ToolStripMenuItem tmiCalendarEraseEn;
        private System.Windows.Forms.ContextMenuStrip ctxCalendar;
        private System.Windows.Forms.ToolStripMenuItem miCalendarAdd;
        private System.Windows.Forms.ToolStripMenuItem miCalendarEdit;
        private System.Windows.Forms.ToolStripMenuItem miCalendarErase;
    }
}