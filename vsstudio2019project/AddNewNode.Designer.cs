namespace MMD_Graph_Studio
{
    partial class AddNewNode
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
      this.button_add = new System.Windows.Forms.Button();
      this.textBox_name = new System.Windows.Forms.TextBox();
      this.button_cancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button_add
      // 
      this.button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_add.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_add.Location = new System.Drawing.Point(3, 57);
      this.button_add.Name = "button_add";
      this.button_add.Size = new System.Drawing.Size(105, 33);
      this.button_add.TabIndex = 1;
      this.button_add.Text = "Add";
      this.button_add.UseVisualStyleBackColor = false;
      this.button_add.Click += new System.EventHandler(this.button_add_Click);
      // 
      // textBox_name
      // 
      this.textBox_name.Location = new System.Drawing.Point(3, 29);
      this.textBox_name.Name = "textBox_name";
      this.textBox_name.Size = new System.Drawing.Size(216, 21);
      this.textBox_name.TabIndex = 0;
      this.textBox_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_name_KeyUp);
      // 
      // button_cancel
      // 
      this.button_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_cancel.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_cancel.Location = new System.Drawing.Point(114, 57);
      this.button_cancel.Name = "button_cancel";
      this.button_cancel.Size = new System.Drawing.Size(105, 33);
      this.button_cancel.TabIndex = 2;
      this.button_cancel.Text = "Cancel";
      this.button_cancel.UseVisualStyleBackColor = false;
      this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(2, 2);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(219, 25);
      this.label1.TabIndex = 3;
      this.label1.Text = "New Element";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // AddNewNode
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.ClientSize = new System.Drawing.Size(223, 98);
      this.ControlBox = false;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button_cancel);
      this.Controls.Add(this.textBox_name);
      this.Controls.Add(this.button_add);
      this.Font = new System.Drawing.Font("Source Sans Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(223, 98);
      this.MinimumSize = new System.Drawing.Size(223, 98);
      this.Name = "AddNewNode";
      this.Text = "AddNewNode";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label1;
    }
}