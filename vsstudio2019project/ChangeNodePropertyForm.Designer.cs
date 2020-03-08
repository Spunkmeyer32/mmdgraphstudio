namespace MMDGraphStudio
{
  partial class ChangeNodePropertyForm
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
      this.listBox_graphNodeProperties = new System.Windows.Forms.ListBox();
      this.listBox_usedNodeProperties = new System.Windows.Forms.ListBox();
      this.button_propertyedit = new System.Windows.Forms.Button();
      this.button_propertynew = new System.Windows.Forms.Button();
      this.button_useproperty = new System.Windows.Forms.Button();
      this.button_propertydelete = new System.Windows.Forms.Button();
      this.button_propertyremove = new System.Windows.Forms.Button();
      this.button_propertyCloseWindow = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label_Nodename = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // listBox_graphNodeProperties
      // 
      this.listBox_graphNodeProperties.FormattingEnabled = true;
      this.listBox_graphNodeProperties.ItemHeight = 17;
      this.listBox_graphNodeProperties.Location = new System.Drawing.Point(6, 78);
      this.listBox_graphNodeProperties.Name = "listBox_graphNodeProperties";
      this.listBox_graphNodeProperties.Size = new System.Drawing.Size(210, 276);
      this.listBox_graphNodeProperties.TabIndex = 0;
      // 
      // listBox_usedNodeProperties
      // 
      this.listBox_usedNodeProperties.FormattingEnabled = true;
      this.listBox_usedNodeProperties.ItemHeight = 17;
      this.listBox_usedNodeProperties.Location = new System.Drawing.Point(235, 78);
      this.listBox_usedNodeProperties.Name = "listBox_usedNodeProperties";
      this.listBox_usedNodeProperties.Size = new System.Drawing.Size(210, 276);
      this.listBox_usedNodeProperties.TabIndex = 1;
      // 
      // button_propertyedit
      // 
      this.button_propertyedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertyedit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertyedit.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertyedit.Location = new System.Drawing.Point(343, 361);
      this.button_propertyedit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertyedit.Name = "button_propertyedit";
      this.button_propertyedit.Size = new System.Drawing.Size(102, 32);
      this.button_propertyedit.TabIndex = 13;
      this.button_propertyedit.Text = "Edit";
      this.button_propertyedit.UseVisualStyleBackColor = false;
      this.button_propertyedit.Click += new System.EventHandler(this.button_propertyedit_Click);
      // 
      // button_propertynew
      // 
      this.button_propertynew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertynew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertynew.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertynew.Location = new System.Drawing.Point(6, 401);
      this.button_propertynew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertynew.Name = "button_propertynew";
      this.button_propertynew.Size = new System.Drawing.Size(102, 32);
      this.button_propertynew.TabIndex = 14;
      this.button_propertynew.Text = "New";
      this.button_propertynew.UseVisualStyleBackColor = false;
      this.button_propertynew.Click += new System.EventHandler(this.button_propertynew_Click);
      // 
      // button_useproperty
      // 
      this.button_useproperty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_useproperty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_useproperty.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_useproperty.Location = new System.Drawing.Point(6, 361);
      this.button_useproperty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_useproperty.Name = "button_useproperty";
      this.button_useproperty.Size = new System.Drawing.Size(210, 32);
      this.button_useproperty.TabIndex = 15;
      this.button_useproperty.Text = "Use";
      this.button_useproperty.UseVisualStyleBackColor = false;
      this.button_useproperty.Click += new System.EventHandler(this.button_useproperty_Click);
      // 
      // button_propertydelete
      // 
      this.button_propertydelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertydelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertydelete.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertydelete.Location = new System.Drawing.Point(114, 401);
      this.button_propertydelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertydelete.Name = "button_propertydelete";
      this.button_propertydelete.Size = new System.Drawing.Size(102, 32);
      this.button_propertydelete.TabIndex = 17;
      this.button_propertydelete.Text = "Delete";
      this.button_propertydelete.UseVisualStyleBackColor = false;
      // 
      // button_propertyremove
      // 
      this.button_propertyremove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertyremove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertyremove.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertyremove.Location = new System.Drawing.Point(235, 361);
      this.button_propertyremove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertyremove.Name = "button_propertyremove";
      this.button_propertyremove.Size = new System.Drawing.Size(102, 32);
      this.button_propertyremove.TabIndex = 18;
      this.button_propertyremove.Text = "Remove";
      this.button_propertyremove.UseVisualStyleBackColor = false;
      // 
      // button_propertyCloseWindow
      // 
      this.button_propertyCloseWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_propertyCloseWindow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_propertyCloseWindow.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_propertyCloseWindow.Location = new System.Drawing.Point(235, 401);
      this.button_propertyCloseWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button_propertyCloseWindow.Name = "button_propertyCloseWindow";
      this.button_propertyCloseWindow.Size = new System.Drawing.Size(210, 32);
      this.button_propertyCloseWindow.TabIndex = 19;
      this.button_propertyCloseWindow.Text = "Close";
      this.button_propertyCloseWindow.UseVisualStyleBackColor = false;
      this.button_propertyCloseWindow.Click += new System.EventHandler(this.button_propertyCloseWindow_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 58);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(115, 17);
      this.label1.TabIndex = 21;
      this.label1.Text = "Available properties";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(232, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(92, 17);
      this.label2.TabIndex = 22;
      this.label2.Text = "Used properties";
      // 
      // label_Nodename
      // 
      this.label_Nodename.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_Nodename.Location = new System.Drawing.Point(4, 9);
      this.label_Nodename.Name = "label_Nodename";
      this.label_Nodename.Size = new System.Drawing.Size(441, 46);
      this.label_Nodename.TabIndex = 24;
      this.label_Nodename.Text = "NodeName";
      this.label_Nodename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ChangeNodePropertyForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.ClientSize = new System.Drawing.Size(451, 439);
      this.ControlBox = false;
      this.Controls.Add(this.label_Nodename);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button_propertyCloseWindow);
      this.Controls.Add(this.button_propertyremove);
      this.Controls.Add(this.button_propertydelete);
      this.Controls.Add(this.button_useproperty);
      this.Controls.Add(this.button_propertynew);
      this.Controls.Add(this.button_propertyedit);
      this.Controls.Add(this.listBox_usedNodeProperties);
      this.Controls.Add(this.listBox_graphNodeProperties);
      this.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(467, 478);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(467, 478);
      this.Name = "ChangeNodePropertyForm";
      this.ShowIcon = false;
      this.Text = "Properties of Element";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ListBox listBox_graphNodeProperties;
        private System.Windows.Forms.ListBox listBox_usedNodeProperties;
        private System.Windows.Forms.Button button_propertyedit;
        private System.Windows.Forms.Button button_propertynew;
        private System.Windows.Forms.Button button_useproperty;
        private System.Windows.Forms.Button button_propertydelete;
        private System.Windows.Forms.Button button_propertyremove;
        private System.Windows.Forms.Button button_propertyCloseWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Nodename;
    }
}