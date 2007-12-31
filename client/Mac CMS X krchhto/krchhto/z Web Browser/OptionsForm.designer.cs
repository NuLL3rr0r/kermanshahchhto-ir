namespace krchhto
{
  partial class OptionsForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
        this.popupBlockerGroupBox = new System.Windows.Forms.GroupBox();
        this.label6 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.filterLevelHighRadioButton = new System.Windows.Forms.RadioButton();
        this.filterLevelMediumRadioButton = new System.Windows.Forms.RadioButton();
        this.filterLevelLowRadioButton = new System.Windows.Forms.RadioButton();
        this.filterLevelNoneRadioButton = new System.Windows.Forms.RadioButton();
        this.okButton = new System.Windows.Forms.Button();
        this.cancelButton = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.label2 = new System.Windows.Forms.Label();
        this.doNotShowScriptErrorsCheckBox = new System.Windows.Forms.CheckBox();
        this.popupBlockerGroupBox.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // popupBlockerGroupBox
        // 
        this.popupBlockerGroupBox.Controls.Add(this.filterLevelHighRadioButton);
        this.popupBlockerGroupBox.Controls.Add(this.filterLevelMediumRadioButton);
        this.popupBlockerGroupBox.Controls.Add(this.filterLevelLowRadioButton);
        this.popupBlockerGroupBox.Controls.Add(this.filterLevelNoneRadioButton);
        this.popupBlockerGroupBox.Controls.Add(this.label6);
        this.popupBlockerGroupBox.Controls.Add(this.label5);
        this.popupBlockerGroupBox.Controls.Add(this.label4);
        this.popupBlockerGroupBox.Controls.Add(this.label3);
        resources.ApplyResources(this.popupBlockerGroupBox, "popupBlockerGroupBox");
        this.popupBlockerGroupBox.Name = "popupBlockerGroupBox";
        this.popupBlockerGroupBox.TabStop = false;
        // 
        // label6
        // 
        resources.ApplyResources(this.label6, "label6");
        this.label6.Name = "label6";
        // 
        // label5
        // 
        resources.ApplyResources(this.label5, "label5");
        this.label5.Name = "label5";
        // 
        // label4
        // 
        resources.ApplyResources(this.label4, "label4");
        this.label4.Name = "label4";
        // 
        // label3
        // 
        resources.ApplyResources(this.label3, "label3");
        this.label3.Name = "label3";
        // 
        // filterLevelHighRadioButton
        // 
        resources.ApplyResources(this.filterLevelHighRadioButton, "filterLevelHighRadioButton");
        this.filterLevelHighRadioButton.Name = "filterLevelHighRadioButton";
        this.filterLevelHighRadioButton.TabStop = true;
        this.filterLevelHighRadioButton.UseVisualStyleBackColor = true;
        // 
        // filterLevelMediumRadioButton
        // 
        resources.ApplyResources(this.filterLevelMediumRadioButton, "filterLevelMediumRadioButton");
        this.filterLevelMediumRadioButton.Name = "filterLevelMediumRadioButton";
        this.filterLevelMediumRadioButton.TabStop = true;
        this.filterLevelMediumRadioButton.UseVisualStyleBackColor = true;
        // 
        // filterLevelLowRadioButton
        // 
        resources.ApplyResources(this.filterLevelLowRadioButton, "filterLevelLowRadioButton");
        this.filterLevelLowRadioButton.Name = "filterLevelLowRadioButton";
        this.filterLevelLowRadioButton.TabStop = true;
        this.filterLevelLowRadioButton.UseVisualStyleBackColor = true;
        // 
        // filterLevelNoneRadioButton
        // 
        resources.ApplyResources(this.filterLevelNoneRadioButton, "filterLevelNoneRadioButton");
        this.filterLevelNoneRadioButton.Name = "filterLevelNoneRadioButton";
        this.filterLevelNoneRadioButton.TabStop = true;
        this.filterLevelNoneRadioButton.UseVisualStyleBackColor = true;
        // 
        // okButton
        // 
        resources.ApplyResources(this.okButton, "okButton");
        this.okButton.Name = "okButton";
        this.okButton.UseVisualStyleBackColor = true;
        this.okButton.Click += new System.EventHandler(this.okButton_Click);
        // 
        // cancelButton
        // 
        this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        resources.ApplyResources(this.cancelButton, "cancelButton");
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.UseVisualStyleBackColor = true;
        this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
        // 
        // label1
        // 
        resources.ApplyResources(this.label1, "label1");
        this.label1.Name = "label1";
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.doNotShowScriptErrorsCheckBox);
        this.groupBox2.Controls.Add(this.label2);
        resources.ApplyResources(this.groupBox2, "groupBox2");
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.TabStop = false;
        // 
        // label2
        // 
        resources.ApplyResources(this.label2, "label2");
        this.label2.Name = "label2";
        // 
        // doNotShowScriptErrorsCheckBox
        // 
        resources.ApplyResources(this.doNotShowScriptErrorsCheckBox, "doNotShowScriptErrorsCheckBox");
        this.doNotShowScriptErrorsCheckBox.Name = "doNotShowScriptErrorsCheckBox";
        this.doNotShowScriptErrorsCheckBox.UseVisualStyleBackColor = true;
        // 
        // OptionsForm
        // 
        this.AcceptButton = this.okButton;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.CancelButton = this.cancelButton;
        resources.ApplyResources(this, "$this");
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.cancelButton);
        this.Controls.Add(this.okButton);
        this.Controls.Add(this.popupBlockerGroupBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "OptionsForm";
        this.Load += new System.EventHandler(this.OptionsForm_Load);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
        this.popupBlockerGroupBox.ResumeLayout(false);
        this.popupBlockerGroupBox.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox popupBlockerGroupBox;
    private System.Windows.Forms.RadioButton filterLevelHighRadioButton;
    private System.Windows.Forms.RadioButton filterLevelMediumRadioButton;
    private System.Windows.Forms.RadioButton filterLevelLowRadioButton;
    private System.Windows.Forms.RadioButton filterLevelNoneRadioButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.CheckBox doNotShowScriptErrorsCheckBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
  }
}