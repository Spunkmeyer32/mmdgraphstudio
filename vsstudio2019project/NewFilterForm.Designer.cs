namespace MMDGraphStudio
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
      this.textBox_filtername = new System.Windows.Forms.TextBox();
      this.label_filtername = new System.Windows.Forms.Label();
      this.label_newfiltercaption = new System.Windows.Forms.Label();
      this.checkBox_useRegex = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filternumber)).BeginInit();
      this.SuspendLayout();
      // 
      // comboBox_filterelement
      // 
      this.comboBox_filterelement.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBox_filterelement.FormattingEnabled = true;
      this.comboBox_filterelement.Items.AddRange(new object[] {
            "Name"});
      this.comboBox_filterelement.Location = new System.Drawing.Point(4, 128);
      this.comboBox_filterelement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.comboBox_filterelement.Name = "comboBox_filterelement";
      this.comboBox_filterelement.Size = new System.Drawing.Size(217, 25);
      this.comboBox_filterelement.TabIndex = 0;
      this.comboBox_filterelement.Text = "Name";
      // 
      // textBox_filtertext
      // 
      this.textBox_filtertext.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox_filtertext.Location = new System.Drawing.Point(306, 163);
      this.textBox_filtertext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_filtertext.Name = "textBox_filtertext";
      this.textBox_filtertext.Size = new System.Drawing.Size(181, 24);
      this.textBox_filtertext.TabIndex = 1;
      this.textBox_filtertext.Text = "keyword";
      // 
      // numericUpDown_filternumber
      // 
      this.numericUpDown_filternumber.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numericUpDown_filternumber.Location = new System.Drawing.Point(306, 94);
      this.numericUpDown_filternumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.numericUpDown_filternumber.Name = "numericUpDown_filternumber";
      this.numericUpDown_filternumber.Size = new System.Drawing.Size(182, 24);
      this.numericUpDown_filternumber.TabIndex = 2;
      // 
      // comboBox_filterenum
      // 
      this.comboBox_filterenum.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBox_filterenum.FormattingEnabled = true;
      this.comboBox_filterenum.Location = new System.Drawing.Point(306, 128);
      this.comboBox_filterenum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.comboBox_filterenum.Name = "comboBox_filterenum";
      this.comboBox_filterenum.Size = new System.Drawing.Size(181, 25);
      this.comboBox_filterenum.TabIndex = 3;
      // 
      // comboBox_filtercomperator
      // 
      this.comboBox_filtercomperator.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBox_filtercomperator.FormattingEnabled = true;
      this.comboBox_filtercomperator.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">=",
            "!="});
      this.comboBox_filtercomperator.Location = new System.Drawing.Point(237, 128);
      this.comboBox_filtercomperator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.comboBox_filtercomperator.Name = "comboBox_filtercomperator";
      this.comboBox_filtercomperator.Size = new System.Drawing.Size(54, 25);
      this.comboBox_filtercomperator.TabIndex = 4;
      this.comboBox_filtercomperator.Text = "=";
      // 
      // comboBox_filtertype
      // 
      this.comboBox_filtertype.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBox_filtertype.FormattingEnabled = true;
      this.comboBox_filtertype.Items.AddRange(new object[] {
            "Element"});
      this.comboBox_filtertype.Location = new System.Drawing.Point(4, 92);
      this.comboBox_filtertype.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.comboBox_filtertype.Name = "comboBox_filtertype";
      this.comboBox_filtertype.Size = new System.Drawing.Size(217, 25);
      this.comboBox_filtertype.TabIndex = 5;
      this.comboBox_filtertype.Text = "Element";
      // 
      // button_filtersave
      // 
      this.button_filtersave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_filtersave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_filtersave.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_filtersave.Location = new System.Drawing.Point(109, 225);
      this.button_filtersave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_filtersave.Name = "button_filtersave";
      this.button_filtersave.Size = new System.Drawing.Size(182, 47);
      this.button_filtersave.TabIndex = 6;
      this.button_filtersave.Text = "Save";
      this.button_filtersave.UseVisualStyleBackColor = false;
      this.button_filtersave.Click += new System.EventHandler(this.button_filtersave_Click);
      // 
      // button_filtercancel
      // 
      this.button_filtercancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_filtercancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_filtercancel.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_filtercancel.Location = new System.Drawing.Point(306, 225);
      this.button_filtercancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_filtercancel.Name = "button_filtercancel";
      this.button_filtercancel.Size = new System.Drawing.Size(182, 47);
      this.button_filtercancel.TabIndex = 7;
      this.button_filtercancel.Text = "Cancel";
      this.button_filtercancel.UseVisualStyleBackColor = false;
      // 
      // textBox_filtername
      // 
      this.textBox_filtername.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox_filtername.Location = new System.Drawing.Point(4, 60);
      this.textBox_filtername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.textBox_filtername.Name = "textBox_filtername";
      this.textBox_filtername.Size = new System.Drawing.Size(217, 24);
      this.textBox_filtername.TabIndex = 8;
      this.textBox_filtername.Text = "unnamed filter";
      // 
      // label_filtername
      // 
      this.label_filtername.AutoSize = true;
      this.label_filtername.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_filtername.Location = new System.Drawing.Point(1, 39);
      this.label_filtername.Name = "label_filtername";
      this.label_filtername.Size = new System.Drawing.Size(43, 17);
      this.label_filtername.TabIndex = 9;
      this.label_filtername.Text = "Name:";
      // 
      // label_newfiltercaption
      // 
      this.label_newfiltercaption.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_newfiltercaption.Location = new System.Drawing.Point(5, 5);
      this.label_newfiltercaption.Name = "label_newfiltercaption";
      this.label_newfiltercaption.Size = new System.Drawing.Size(483, 34);
      this.label_newfiltercaption.TabIndex = 10;
      this.label_newfiltercaption.Text = "New Filter";
      this.label_newfiltercaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // checkBox_useRegex
      // 
      this.checkBox_useRegex.AutoSize = true;
      this.checkBox_useRegex.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBox_useRegex.Location = new System.Drawing.Point(306, 196);
      this.checkBox_useRegex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.checkBox_useRegex.Name = "checkBox_useRegex";
      this.checkBox_useRegex.Size = new System.Drawing.Size(155, 21);
      this.checkBox_useRegex.TabIndex = 11;
      this.checkBox_useRegex.Text = "Regular Expression Text";
      this.checkBox_useRegex.UseVisualStyleBackColor = true;
      // 
      // NewFilterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.ClientSize = new System.Drawing.Size(494, 280);
      this.Controls.Add(this.checkBox_useRegex);
      this.Controls.Add(this.label_newfiltercaption);
      this.Controls.Add(this.label_filtername);
      this.Controls.Add(this.textBox_filtername);
      this.Controls.Add(this.button_filtercancel);
      this.Controls.Add(this.button_filtersave);
      this.Controls.Add(this.comboBox_filtertype);
      this.Controls.Add(this.comboBox_filtercomperator);
      this.Controls.Add(this.comboBox_filterenum);
      this.Controls.Add(this.numericUpDown_filternumber);
      this.Controls.Add(this.textBox_filtertext);
      this.Controls.Add(this.comboBox_filterelement);
      this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.TextBox textBox_filtername;
        private System.Windows.Forms.Label label_filtername;
        private System.Windows.Forms.Label label_newfiltercaption;
        private System.Windows.Forms.CheckBox checkBox_useRegex;
    }
}