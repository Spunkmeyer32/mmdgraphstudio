namespace MMD_Graph_Studio
{
  partial class MainForm
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.button_store = new System.Windows.Forms.Button();
      this.button_load = new System.Windows.Forms.Button();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.graphContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.button_newgraph = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.button_app_close = new System.Windows.Forms.Button();
      this.button_app_maxmize = new System.Windows.Forms.Button();
      this.button_app_minimize = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.contextMenuStrip_MainApp = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem_max = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem_min = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem_close = new System.Windows.Forms.ToolStripMenuItem();
      this.panel3 = new System.Windows.Forms.Panel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.panel_toolpanels = new System.Windows.Forms.Panel();
      this.panel_views = new System.Windows.Forms.Panel();
      this.panel_filters = new System.Windows.Forms.Panel();
      this.label_filter = new System.Windows.Forms.Label();
      this.button_newfilter = new System.Windows.Forms.Button();
      this.listBox_filters = new System.Windows.Forms.ListBox();
      this.panel_panelchooser = new System.Windows.Forms.Panel();
      this.panel_showview = new System.Windows.Forms.Panel();
      this.panel_showfilter = new System.Windows.Forms.Panel();
      this.panelGraphPaint = new MMD_Graph_Studio.DoubleBufferedPanel();
      this.label_views = new System.Windows.Forms.Label();
      this.button_NewView = new System.Windows.Forms.Button();
      this.listBox_views = new System.Windows.Forms.ListBox();
      this.statusStrip.SuspendLayout();
      this.panel1.SuspendLayout();
      this.contextMenuStrip_MainApp.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.panel_toolpanels.SuspendLayout();
      this.panel_views.SuspendLayout();
      this.panel_filters.SuspendLayout();
      this.panel_panelchooser.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_store
      // 
      this.button_store.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_store.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_store.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_store.Location = new System.Drawing.Point(1, 98);
      this.button_store.Margin = new System.Windows.Forms.Padding(0);
      this.button_store.Name = "button_store";
      this.button_store.Size = new System.Drawing.Size(125, 45);
      this.button_store.TabIndex = 3;
      this.button_store.TabStop = false;
      this.button_store.Text = "Save as...";
      this.button_store.UseVisualStyleBackColor = false;
      this.button_store.Click += new System.EventHandler(this.button_save_Click);
      // 
      // button_load
      // 
      this.button_load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_load.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_load.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_load.Location = new System.Drawing.Point(1, 50);
      this.button_load.Margin = new System.Windows.Forms.Padding(0);
      this.button_load.Name = "button_load";
      this.button_load.Size = new System.Drawing.Size(125, 41);
      this.button_load.TabIndex = 4;
      this.button_load.TabStop = false;
      this.button_load.Text = "Load...";
      this.button_load.UseVisualStyleBackColor = false;
      this.button_load.Click += new System.EventHandler(this.button_load_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 568);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(1119, 22);
      this.statusStrip.TabIndex = 5;
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = false;
      this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.statusLabel.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(1104, 17);
      this.statusLabel.Spring = true;
      this.statusLabel.Text = "Ready.";
      this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.statusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
      // 
      // graphContextMenuStrip
      // 
      this.graphContextMenuStrip.AllowMerge = false;
      this.graphContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.graphContextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.graphContextMenuStrip.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.graphContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
      this.graphContextMenuStrip.Name = "graphContextMenuStrip";
      this.graphContextMenuStrip.ShowImageMargin = false;
      this.graphContextMenuStrip.ShowItemToolTips = false;
      this.graphContextMenuStrip.Size = new System.Drawing.Size(36, 4);
      this.graphContextMenuStrip.MouseLeave += new System.EventHandler(this.graphContextMenuStrip_MouseLeave);
      // 
      // button_newgraph
      // 
      this.button_newgraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_newgraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_newgraph.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_newgraph.Location = new System.Drawing.Point(1, 1);
      this.button_newgraph.Margin = new System.Windows.Forms.Padding(0);
      this.button_newgraph.Name = "button_newgraph";
      this.button_newgraph.Size = new System.Drawing.Size(125, 43);
      this.button_newgraph.TabIndex = 6;
      this.button_newgraph.TabStop = false;
      this.button_newgraph.Text = "New Graph";
      this.button_newgraph.UseVisualStyleBackColor = false;
      this.button_newgraph.Click += new System.EventHandler(this.button_newgraph_Click);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.panel1.Controls.Add(this.button_store);
      this.panel1.Controls.Add(this.button_newgraph);
      this.panel1.Controls.Add(this.button_load);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(127, 533);
      this.panel1.TabIndex = 7;
      // 
      // button_app_close
      // 
      this.button_app_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_app_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_app_close.BackgroundImage = global::MMD_Graph_Studio.Resources.baseline_close_black_48dp;
      this.button_app_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.button_app_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.button_app_close.FlatAppearance.BorderSize = 0;
      this.button_app_close.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
      this.button_app_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
      this.button_app_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
      this.button_app_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_app_close.Location = new System.Drawing.Point(1086, 2);
      this.button_app_close.Name = "button_app_close";
      this.button_app_close.Size = new System.Drawing.Size(32, 32);
      this.button_app_close.TabIndex = 8;
      this.button_app_close.TabStop = false;
      this.button_app_close.Text = " ";
      this.button_app_close.UseVisualStyleBackColor = false;
      this.button_app_close.Click += new System.EventHandler(this.button_app_close_Click);
      // 
      // button_app_maxmize
      // 
      this.button_app_maxmize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_app_maxmize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_app_maxmize.BackgroundImage = global::MMD_Graph_Studio.Resources.baseline_maximize_black_48dp;
      this.button_app_maxmize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.button_app_maxmize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.button_app_maxmize.FlatAppearance.BorderSize = 0;
      this.button_app_maxmize.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
      this.button_app_maxmize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
      this.button_app_maxmize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
      this.button_app_maxmize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_app_maxmize.Location = new System.Drawing.Point(1051, 2);
      this.button_app_maxmize.Name = "button_app_maxmize";
      this.button_app_maxmize.Size = new System.Drawing.Size(32, 32);
      this.button_app_maxmize.TabIndex = 9;
      this.button_app_maxmize.TabStop = false;
      this.button_app_maxmize.Text = " ";
      this.button_app_maxmize.UseVisualStyleBackColor = false;
      this.button_app_maxmize.Click += new System.EventHandler(this.button_app_maxmize_Click);
      // 
      // button_app_minimize
      // 
      this.button_app_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_app_minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_app_minimize.BackgroundImage = global::MMD_Graph_Studio.Resources.baseline_minimize_black_48dp;
      this.button_app_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.button_app_minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.button_app_minimize.FlatAppearance.BorderSize = 0;
      this.button_app_minimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
      this.button_app_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
      this.button_app_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
      this.button_app_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_app_minimize.Location = new System.Drawing.Point(1016, 2);
      this.button_app_minimize.Name = "button_app_minimize";
      this.button_app_minimize.Size = new System.Drawing.Size(32, 32);
      this.button_app_minimize.TabIndex = 10;
      this.button_app_minimize.TabStop = false;
      this.button_app_minimize.Text = " ";
      this.button_app_minimize.UseVisualStyleBackColor = false;
      this.button_app_minimize.Click += new System.EventHandler(this.button_app_minimize_Click);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Source Sans Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(656, 33);
      this.label1.TabIndex = 11;
      this.label1.Text = "MMD Graph Studio";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // contextMenuStrip_MainApp
      // 
      this.contextMenuStrip_MainApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.contextMenuStrip_MainApp.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F);
      this.contextMenuStrip_MainApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_max,
            this.toolStripMenuItem_min,
            this.toolStripMenuItem_close});
      this.contextMenuStrip_MainApp.Name = "contextMenuStrip_MainApp";
      this.contextMenuStrip_MainApp.Size = new System.Drawing.Size(128, 70);
      // 
      // toolStripMenuItem_max
      // 
      this.toolStripMenuItem_max.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.toolStripMenuItem_max.Name = "toolStripMenuItem_max";
      this.toolStripMenuItem_max.Size = new System.Drawing.Size(127, 22);
      this.toolStripMenuItem_max.Text = "Maximize";
      this.toolStripMenuItem_max.Click += new System.EventHandler(this.toolStripMenuItem_max_Click);
      // 
      // toolStripMenuItem_min
      // 
      this.toolStripMenuItem_min.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.toolStripMenuItem_min.Name = "toolStripMenuItem_min";
      this.toolStripMenuItem_min.Size = new System.Drawing.Size(127, 22);
      this.toolStripMenuItem_min.Text = "Minimize";
      this.toolStripMenuItem_min.Click += new System.EventHandler(this.toolStripMenuItem_min_Click);
      // 
      // toolStripMenuItem_close
      // 
      this.toolStripMenuItem_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.toolStripMenuItem_close.Name = "toolStripMenuItem_close";
      this.toolStripMenuItem_close.Size = new System.Drawing.Size(127, 22);
      this.toolStripMenuItem_close.Text = "Close";
      this.toolStripMenuItem_close.Click += new System.EventHandler(this.toolStripMenuItem_close_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.label1);
      this.panel3.Controls.Add(this.button_app_close);
      this.panel3.Controls.Add(this.button_app_maxmize);
      this.panel3.Controls.Add(this.button_app_minimize);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Margin = new System.Windows.Forms.Padding(0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(1119, 35);
      this.panel3.TabIndex = 1;
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.splitContainer);
      this.panel4.Controls.Add(this.panel1);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel4.Location = new System.Drawing.Point(0, 35);
      this.panel4.Margin = new System.Windows.Forms.Padding(0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(1119, 533);
      this.panel4.TabIndex = 8;
      // 
      // splitContainer
      // 
      this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.Location = new System.Drawing.Point(127, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.panelGraphPaint);
      this.splitContainer.Panel1MinSize = 200;
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.panel_toolpanels);
      this.splitContainer.Panel2.Controls.Add(this.panel_panelchooser);
      this.splitContainer.Panel2MinSize = 33;
      this.splitContainer.Size = new System.Drawing.Size(992, 533);
      this.splitContainer.SplitterDistance = 410;
      this.splitContainer.SplitterWidth = 6;
      this.splitContainer.TabIndex = 8;
      this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
      // 
      // panel_toolpanels
      // 
      this.panel_toolpanels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.panel_toolpanels.Controls.Add(this.panel_views);
      this.panel_toolpanels.Controls.Add(this.panel_filters);
      this.panel_toolpanels.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel_toolpanels.Location = new System.Drawing.Point(33, 0);
      this.panel_toolpanels.Name = "panel_toolpanels";
      this.panel_toolpanels.Size = new System.Drawing.Size(543, 533);
      this.panel_toolpanels.TabIndex = 1;
      // 
      // panel_views
      // 
      this.panel_views.Controls.Add(this.label_views);
      this.panel_views.Controls.Add(this.button_NewView);
      this.panel_views.Controls.Add(this.listBox_views);
      this.panel_views.Location = new System.Drawing.Point(280, 5);
      this.panel_views.Name = "panel_views";
      this.panel_views.Size = new System.Drawing.Size(261, 512);
      this.panel_views.TabIndex = 1;
      // 
      // panel_filters
      // 
      this.panel_filters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.panel_filters.Controls.Add(this.label_filter);
      this.panel_filters.Controls.Add(this.button_newfilter);
      this.panel_filters.Controls.Add(this.listBox_filters);
      this.panel_filters.Location = new System.Drawing.Point(6, 3);
      this.panel_filters.Name = "panel_filters";
      this.panel_filters.Size = new System.Drawing.Size(268, 514);
      this.panel_filters.TabIndex = 0;
      // 
      // label_filter
      // 
      this.label_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
      this.label_filter.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_filter.Font = new System.Drawing.Font("Source Sans Pro Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_filter.Location = new System.Drawing.Point(0, 0);
      this.label_filter.Name = "label_filter";
      this.label_filter.Size = new System.Drawing.Size(268, 20);
      this.label_filter.TabIndex = 2;
      this.label_filter.Text = "Filters";
      // 
      // button_newfilter
      // 
      this.button_newfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_newfilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_newfilter.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_newfilter.Location = new System.Drawing.Point(3, 23);
      this.button_newfilter.Name = "button_newfilter";
      this.button_newfilter.Size = new System.Drawing.Size(137, 33);
      this.button_newfilter.TabIndex = 1;
      this.button_newfilter.Text = "New";
      this.button_newfilter.UseVisualStyleBackColor = false;
      // 
      // listBox_filters
      // 
      this.listBox_filters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox_filters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.listBox_filters.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox_filters.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listBox_filters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
      this.listBox_filters.FormattingEnabled = true;
      this.listBox_filters.ItemHeight = 17;
      this.listBox_filters.Location = new System.Drawing.Point(4, 62);
      this.listBox_filters.Name = "listBox_filters";
      this.listBox_filters.Size = new System.Drawing.Size(252, 221);
      this.listBox_filters.TabIndex = 0;
      // 
      // panel_panelchooser
      // 
      this.panel_panelchooser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
      this.panel_panelchooser.Controls.Add(this.panel_showview);
      this.panel_panelchooser.Controls.Add(this.panel_showfilter);
      this.panel_panelchooser.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel_panelchooser.Location = new System.Drawing.Point(0, 0);
      this.panel_panelchooser.Name = "panel_panelchooser";
      this.panel_panelchooser.Size = new System.Drawing.Size(33, 533);
      this.panel_panelchooser.TabIndex = 0;
      // 
      // panel_showview
      // 
      this.panel_showview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.panel_showview.BackgroundImage = global::MMD_Graph_Studio.Resources.baseline_remove_red_eye_black_48dp;
      this.panel_showview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panel_showview.Location = new System.Drawing.Point(0, 64);
      this.panel_showview.Name = "panel_showview";
      this.panel_showview.Size = new System.Drawing.Size(32, 32);
      this.panel_showview.TabIndex = 1;
      this.panel_showview.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_showview_Paint);
      this.panel_showview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_showview_MouseClick);
      // 
      // panel_showfilter
      // 
      this.panel_showfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.panel_showfilter.BackgroundImage = global::MMD_Graph_Studio.Resources.baseline_filter_list_black_48dp;
      this.panel_showfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panel_showfilter.Location = new System.Drawing.Point(0, 24);
      this.panel_showfilter.Name = "panel_showfilter";
      this.panel_showfilter.Size = new System.Drawing.Size(32, 32);
      this.panel_showfilter.TabIndex = 0;
      this.panel_showfilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_showfilter_Paint);
      this.panel_showfilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_showfilter_MouseClick);
      // 
      // panelGraphPaint
      // 
      this.panelGraphPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(19)))));
      this.panelGraphPaint.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelGraphPaint.Location = new System.Drawing.Point(0, 0);
      this.panelGraphPaint.Name = "panelGraphPaint";
      this.panelGraphPaint.Size = new System.Drawing.Size(410, 533);
      this.panelGraphPaint.TabIndex = 0;
      this.panelGraphPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      this.panelGraphPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
      this.panelGraphPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
      this.panelGraphPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
      // 
      // label_views
      // 
      this.label_views.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
      this.label_views.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_views.Font = new System.Drawing.Font("Source Sans Pro Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_views.Location = new System.Drawing.Point(0, 0);
      this.label_views.Name = "label_views";
      this.label_views.Size = new System.Drawing.Size(261, 20);
      this.label_views.TabIndex = 5;
      this.label_views.Text = "Views";
      // 
      // button_NewView
      // 
      this.button_NewView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.button_NewView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button_NewView.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_NewView.Location = new System.Drawing.Point(4, 23);
      this.button_NewView.Name = "button_NewView";
      this.button_NewView.Size = new System.Drawing.Size(137, 33);
      this.button_NewView.TabIndex = 4;
      this.button_NewView.Text = "New";
      this.button_NewView.UseVisualStyleBackColor = false;
      // 
      // listBox_views
      // 
      this.listBox_views.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox_views.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
      this.listBox_views.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox_views.Font = new System.Drawing.Font("Source Sans Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listBox_views.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
      this.listBox_views.FormattingEnabled = true;
      this.listBox_views.ItemHeight = 17;
      this.listBox_views.Location = new System.Drawing.Point(6, 62);
      this.listBox_views.Name = "listBox_views";
      this.listBox_views.Size = new System.Drawing.Size(245, 170);
      this.listBox_views.TabIndex = 3;
      // 
      // MainForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
      this.ClientSize = new System.Drawing.Size(1119, 590);
      this.ControlBox = false;
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.statusStrip);
      this.Font = new System.Drawing.Font("Source Sans Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(942, 379);
      this.Name = "MainForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
      this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.contextMenuStrip_MainApp.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.panel_toolpanels.ResumeLayout(false);
      this.panel_views.ResumeLayout(false);
      this.panel_filters.ResumeLayout(false);
      this.panel_panelchooser.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DoubleBufferedPanel panelGraphPaint;
    private System.Windows.Forms.Button button_store;
    private System.Windows.Forms.Button button_load;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.ContextMenuStrip graphContextMenuStrip;
    private System.Windows.Forms.Button button_newgraph;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button_app_close;
    private System.Windows.Forms.Button button_app_maxmize;
    private System.Windows.Forms.Button button_app_minimize;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MainApp;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_max;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_min;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_close;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.Panel panel_toolpanels;
    private System.Windows.Forms.Panel panel_views;
    private System.Windows.Forms.Panel panel_filters;
    private System.Windows.Forms.Panel panel_panelchooser;
    private System.Windows.Forms.Button button_newfilter;
    private System.Windows.Forms.ListBox listBox_filters;
    private System.Windows.Forms.Panel panel_showview;
    private System.Windows.Forms.Panel panel_showfilter;
        private System.Windows.Forms.Label label_filter;
        private System.Windows.Forms.Label label_views;
        private System.Windows.Forms.Button button_NewView;
        private System.Windows.Forms.ListBox listBox_views;
    }
}

