namespace MMD_Graph_Studio
{
  partial class NewFilterForm
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
      this.comboBox_filterelement = new System.Windows.Forms.ComboBox();
      this.textBox_filtertext = new System.Windows.Forms.TextBox();
      this.numericUpDown_filternumber = new System.Windows.Forms.NumericUpDown();
      this.comboBox_filterenum = new System.Windows.Forms.ComboBox();
      this.comboBox_filtercomperator = new System.Windows.Forms.ComboBox();
      this.comboBox_filtertype = new System.Windows.Forms.ComboBox();
      this.button_filtersave = new System.Windows.Forms.Button();
      this.button_filtercancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filternumber)).BeginInit();
      this.SuspendLayout();
      // 
      // comboBox_filterelement
      // 
      this.comboBox_filterelement.FormattingEnabled = true;
      this.comboBox_filterelement.Items.AddRange(new object[] {
            "Name"});
      this.comboBox_filterelement.Location = new System.Drawing.Point(12, 42);
      this.comboBox_filterelement.Name = "comboBox_filterelement";
      this.comboBox_filterelement.Size = new System.Drawing.Size(247, 22);
      this.comboBox_filterelement.TabIndex = 0;
      this.comboBox_filterelement.Text = "Name";
      // 
      // textBox_filtertext
      // 
      this.textBox_filtertext.Location = new System.Drawing.Point(327, 99);
      this.textBox_filtertext.Name = "textBox_filtertext";
      this.textBox_filtertext.Size = new System.Drawing.Size(156, 21);
      this.textBox_filtertext.TabIndex = 1;
      this.textBox_filtertext.Text = "*keyword*";
      // 
      // numericUpDown_filternumber
      // 
      this.numericUpDown_filternumber.Location = new System.Drawing.Point(327, 42);
      this.numericUpDown_filternumber.Name = "numericUpDown_filternumber";
      this.numericUpDown_filternumber.Size = new System.Drawing.Size(156, 21);
      this.numericUpDown_filternumber.TabIndex = 2;
      // 
      // comboBox_filterenum
      // 
      this.comboBox_filterenum.FormattingEnabled = true;
      this.comboBox_filterenum.Location = new System.Drawing.Point(327, 70);
      this.comboBox_filterenum.Name = "comboBox_filterenum";
      this.comboBox_filterenum.Size = new System.Drawing.Size(156, 22);
      this.comboBox_filterenum.TabIndex = 3;
      // 
      // comboBox_filtercomperator
      // 
      this.comboBox_filtercomperator.FormattingEnabled = true;
      this.comboBox_filtercomperator.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">=",
            "!="});
      this.comboBox_filtercomperator.Location = new System.Drawing.Point(265, 42);
      this.comboBox_filtercomperator.Name = "comboBox_filtercomperator";
      this.comboBox_filtercomperator.Size = new System.Drawing.Size(56, 22);
      this.comboBox_filtercomperator.TabIndex = 4;
      this.comboBox_filtercomperator.Text = "=";
      // 
      // comboBox_filtertype
      // 
      this.comboBox_filtertype.FormattingEnabled = true;
      this.comboBox_filtertype.Items.AddRange(new object[] {
            "Element",
            "Connection"});
      this.comboBox_filtertype.Location = new System.Drawing.Point(12, 13);
      this.comboBox_filtertype.Name = "comboBox_filtertype";
      this.comboBox_filtertype.Size = new System.Drawing.Size(187, 22);
      this.comboBox_filtertype.TabIndex = 5;
      this.comboBox_filtertype.Text = "Element";
      // 
      // button_filtersave
      // 
      this.button_filtersave.Location = new System.Drawing.Point(199, 127);
      this.button_filtersave.Name = "button_filtersave";
      this.button_filtersave.Size = new System.Drawing.Size(122, 39);
      this.button_filtersave.TabIndex = 6;
      this.button_filtersave.Text = "Save";
      this.button_filtersave.UseVisualStyleBackColor = true;
      this.button_filtersave.Click += new System.EventHandler(this.button_filtersave_Click);
      // 
      // button_filtercancel
      // 
      this.button_filtercancel.Location = new System.Drawing.Point(327, 127);
      this.button_filtercancel.Name = "button_filtercancel";
      this.button_filtercancel.Size = new System.Drawing.Size(156, 39);
      this.button_filtercancel.TabIndex = 7;
      this.button_filtercancel.Text = "Cancel";
      this.button_filtercancel.UseVisualStyleBackColor = true;
      // 
      // NewFilterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(498, 181);
      this.Controls.Add(this.button_filtercancel);
      this.Controls.Add(this.button_filtersave);
      this.Controls.Add(this.comboBox_filtertype);
      this.Controls.Add(this.comboBox_filtercomperator);
      this.Controls.Add(this.comboBox_filterenum);
      this.Controls.Add(this.numericUpDown_filternumber);
      this.Controls.Add(this.textBox_filtertext);
      this.Controls.Add(this.comboBox_filterelement);
      this.Font = new System.Drawing.Font("Source Sans Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "NewFilterForm";
      this.Text = "New Filter";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filternumber)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_filterelement;
        private System.Windows.Forms.TextBox textBox_filtertext;
        private System.Windows.Forms.NumericUpDown numericUpDown_filternumber;
        private System.Windows.Forms.ComboBox comboBox_filterenum;
        private System.Windows.Forms.ComboBox comboBox_filtercomperator;
        private System.Windows.Forms.ComboBox comboBox_filtertype;
        private System.Windows.Forms.Button button_filtersave;
        private System.Windows.Forms.Button button_filtercancel;
    }
}