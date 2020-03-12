namespace MMDGraphStudio
{
  partial class NewPropertyForm
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
      this.comboBox_proptype = new System.Windows.Forms.ComboBox();
      this.textBox_Propertyname = new System.Windows.Forms.TextBox();
      this.textBox_enumvalues = new System.Windows.Forms.TextBox();
      this.label_propertyname = new System.Windows.Forms.Label();
      this.label_propertytype = new System.Windows.Forms.Label();
      this.label_enumvalues = new System.Windows.Forms.Label();
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
      // comboBox_proptype
      // 
      this.comboBox_proptype.FormattingEnabled = true;
      this.comboBox_proptype.Items.AddRange(new object[] {
            "Text",
            "Number",
            "Selectionlist"});
      this.comboBox_proptype.Location = new System.Drawing.Point(236, 34);
      this.comboBox_proptype.Name = "comboBox_proptype";
      this.comboBox_proptype.Size = new System.Drawing.Size(163, 25);
      this.comboBox_proptype.TabIndex = 14;
      this.comboBox_proptype.Text = "Text";
      this.comboBox_proptype.SelectedIndexChanged += new System.EventHandler(this.comboBox_proptype_SelectedIndexChanged);
      // 
      // textBox_Propertyname
      // 
      this.textBox_Propertyname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_Propertyname.Location = new System.Drawing.Point(12, 34);
      this.textBox_Propertyname.Name = "textBox_Propertyname";
      this.textBox_Propertyname.Size = new System.Drawing.Size(218, 24);
      this.textBox_Propertyname.TabIndex = 15;
      // 
      // textBox_enumvalues
      // 
      this.textBox_enumvalues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
      this.textBox_enumvalues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_enumvalues.Enabled = false;
      this.textBox_enumvalues.Location = new System.Drawing.Point(405, 34);
      this.textBox_enumvalues.Multiline = true;
      this.textBox_enumvalues.Name = "textBox_enumvalues";
      this.textBox_enumvalues.Size = new System.Drawing.Size(201, 131);
      this.textBox_enumvalues.TabIndex = 16;
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
      // label_propertytype
      // 
      this.label_propertytype.AutoSize = true;
      this.label_propertytype.Location = new System.Drawing.Point(233, 14);
      this.label_propertytype.Name = "label_propertytype";
      this.label_propertytype.Size = new System.Drawing.Size(81, 17);
      this.label_propertytype.TabIndex = 18;
      this.label_propertytype.Text = "Propertytype:";
      // 
      // label_enumvalues
      // 
      this.label_enumvalues.AutoSize = true;
      this.label_enumvalues.Location = new System.Drawing.Point(402, 14);
      this.label_enumvalues.Name = "label_enumvalues";
      this.label_enumvalues.Size = new System.Drawing.Size(128, 17);
      this.label_enumvalues.TabIndex = 19;
      this.label_enumvalues.Text = "Selection (line by line):";
      // 
      // NewPropertyForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.ClientSize = new System.Drawing.Size(619, 232);
      this.ControlBox = false;
      this.Controls.Add(this.label_enumvalues);
      this.Controls.Add(this.label_propertytype);
      this.Controls.Add(this.label_propertyname);
      this.Controls.Add(this.textBox_enumvalues);
      this.Controls.Add(this.textBox_Propertyname);
      this.Controls.Add(this.comboBox_proptype);
      this.Controls.Add(this.button_propertycancel);
      this.Controls.Add(this.button_propertysave);
      this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.Name = "NewPropertyForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "New element property";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.Button button_propertycancel;
        private System.Windows.Forms.Button button_propertysave;
        private System.Windows.Forms.ComboBox comboBox_proptype;
        private System.Windows.Forms.TextBox textBox_Propertyname;
        private System.Windows.Forms.TextBox textBox_enumvalues;
        private System.Windows.Forms.Label label_propertyname;
        private System.Windows.Forms.Label label_propertytype;
        private System.Windows.Forms.Label label_enumvalues;
    }
}