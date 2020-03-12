namespace MMDGraphStudio
{
  partial class NewPropertyValue
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
      this.button_propertycancel = new System.Windows.Forms.Button();
      this.button_propertysave = new System.Windows.Forms.Button();
      this.textBox_Propertyname = new System.Windows.Forms.TextBox();
      this.label_propertyname = new System.Windows.Forms.Label();
      this.textBox_PropertyText = new System.Windows.Forms.TextBox();
      this.comboBox_PropertySelection = new System.Windows.Forms.ComboBox();
      this.textBox_numbervalue = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // button_propertycancel
      // 
      this.button_propertycancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertycancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertycancel.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertycancel.Location = new System.Drawing.Point(405, 172);
      this.button_propertycancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertycancel.Name = "button_propertycancel";
      this.button_propertycancel.Size = new System.Drawing.Size(201, 47);
      this.button_propertycancel.TabIndex = 12;
      this.button_propertycancel.Text = "Cancel";
      this.button_propertycancel.UseVisualStyleBackColor = false;
      this.button_propertycancel.Click += new System.EventHandler(this.button_propertycancel_Click);
      // 
      // button_propertysave
      // 
      this.button_propertysave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertysave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertysave.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertysave.Location = new System.Drawing.Point(236, 172);
      this.button_propertysave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertysave.Name = "button_propertysave";
      this.button_propertysave.Size = new System.Drawing.Size(163, 47);
      this.button_propertysave.TabIndex = 11;
      this.button_propertysave.Text = "Save";
      this.button_propertysave.UseVisualStyleBackColor = false;
      this.button_propertysave.Click += new System.EventHandler(this.button_propertysave_Click);
      // 
      // textBox_Propertyname
      // 
      this.textBox_Propertyname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
      this.textBox_Propertyname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_Propertyname.Enabled = false;
      this.textBox_Propertyname.Location = new System.Drawing.Point(12, 34);
      this.textBox_Propertyname.Name = "textBox_Propertyname";
      this.textBox_Propertyname.Size = new System.Drawing.Size(218, 24);
      this.textBox_Propertyname.TabIndex = 15;
      // 
      // label_propertyname
      // 
      this.label_propertyname.AutoSize = true;
      this.label_propertyname.Location = new System.Drawing.Point(9, 14);
      this.label_propertyname.Name = "label_propertyname";
      this.label_propertyname.Size = new System.Drawing.Size(89, 17);
      this.label_propertyname.TabIndex = 17;
      this.label_propertyname.Text = "Propertyname:";
      // 
      // textBox_PropertyText
      // 
      this.textBox_PropertyText.Location = new System.Drawing.Point(236, 95);
      this.textBox_PropertyText.Multiline = true;
      this.textBox_PropertyText.Name = "textBox_PropertyText";
      this.textBox_PropertyText.Size = new System.Drawing.Size(370, 70);
      this.textBox_PropertyText.TabIndex = 18;
      // 
      // comboBox_PropertySelection
      // 
      this.comboBox_PropertySelection.FormattingEnabled = true;
      this.comboBox_PropertySelection.Location = new System.Drawing.Point(236, 33);
      this.comboBox_PropertySelection.Name = "comboBox_PropertySelection";
      this.comboBox_PropertySelection.Size = new System.Drawing.Size(370, 25);
      this.comboBox_PropertySelection.TabIndex = 20;
      // 
      // textBox_numbervalue
      // 
      this.textBox_numbervalue.Location = new System.Drawing.Point(236, 65);
      this.textBox_numbervalue.Name = "textBox_numbervalue";
      this.textBox_numbervalue.Size = new System.Drawing.Size(370, 24);
      this.textBox_numbervalue.TabIndex = 21;
      // 
      // NewPropertyValue
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.ClientSize = new System.Drawing.Size(619, 227);
      this.ControlBox = false;
      this.Controls.Add(this.textBox_numbervalue);
      this.Controls.Add(this.comboBox_PropertySelection);
      this.Controls.Add(this.textBox_PropertyText);
      this.Controls.Add(this.label_propertyname);
      this.Controls.Add(this.textBox_Propertyname);
      this.Controls.Add(this.button_propertycancel);
      this.Controls.Add(this.button_propertysave);
      this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.Name = "NewPropertyValue";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Property Value";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button_propertycancel;
    private System.Windows.Forms.Button button_propertysave;
    private System.Windows.Forms.TextBox textBox_Propertyname;
    private System.Windows.Forms.Label label_propertyname;
    private System.Windows.Forms.TextBox textBox_PropertyText;
    private System.Windows.Forms.ComboBox comboBox_PropertySelection;
    private System.Windows.Forms.TextBox textBox_numbervalue;
  }
}