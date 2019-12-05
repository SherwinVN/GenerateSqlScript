namespace GenerateSqlScript
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_table = new System.Windows.Forms.TextBox();
            this.txt_where = new System.Windows.Forms.TextBox();
            this.but_generateSqlSript_table = new System.Windows.Forms.Button();
            this.rtb_results = new System.Windows.Forms.RichTextBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_db = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_order = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.but_login = new System.Windows.Forms.Button();
            this.txt_list_storeprodures = new System.Windows.Forms.TextBox();
            this.but_generateSqlSript_store_produres = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_store = new System.Windows.Forms.ListBox();
            this.cbtypep = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_action = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.but_refreshview = new System.Windows.Forms.Button();
            this.but_createtable = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_results2 = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dgr_result = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.but_execute = new System.Windows.Forms.Button();
            this.but_create_tab_tmp_x = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tab2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_result)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_table
            // 
            this.txt_table.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_table.Location = new System.Drawing.Point(63, 45);
            this.txt_table.Name = "txt_table";
            this.txt_table.Size = new System.Drawing.Size(299, 20);
            this.txt_table.TabIndex = 2;
            this.txt_table.Text = "SYS_CONTROLS";
            this.txt_table.TextChanged += new System.EventHandler(this.Txt_table_TextChanged);
            // 
            // txt_where
            // 
            this.txt_where.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_where.Location = new System.Drawing.Point(63, 95);
            this.txt_where.Name = "txt_where";
            this.txt_where.Size = new System.Drawing.Size(299, 20);
            this.txt_where.TabIndex = 3;
            this.txt_where.Text = "formname = \'dmvt\'";
            this.txt_where.TextChanged += new System.EventHandler(this.txt_where_TextChanged);
            // 
            // but_generateSqlSript_table
            // 
            this.but_generateSqlSript_table.Location = new System.Drawing.Point(38, 10);
            this.but_generateSqlSript_table.Name = "but_generateSqlSript_table";
            this.but_generateSqlSript_table.Size = new System.Drawing.Size(126, 23);
            this.but_generateSqlSript_table.TabIndex = 0;
            this.but_generateSqlSript_table.Text = "Generate Script Insert";
            this.but_generateSqlSript_table.UseVisualStyleBackColor = true;
            this.but_generateSqlSript_table.Click += new System.EventHandler(this.but_generateSqlSript_table_Click);
            // 
            // rtb_results
            // 
            this.rtb_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_results.HideSelection = false;
            this.rtb_results.Location = new System.Drawing.Point(3, 42);
            this.rtb_results.Name = "rtb_results";
            this.rtb_results.Size = new System.Drawing.Size(892, 309);
            this.rtb_results.TabIndex = 0;
            this.rtb_results.Text = " ";
            // 
            // txt_server
            // 
            this.txt_server.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_server.Location = new System.Drawing.Point(57, 19);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(197, 20);
            this.txt_server.TabIndex = 0;
            this.txt_server.Text = "TTV_SERVER\\SQL2005";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(57, 45);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(197, 20);
            this.txt_user.TabIndex = 1;
            this.txt_user.Text = "ttv";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(57, 71);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(197, 20);
            this.txt_pass.TabIndex = 2;
            this.txt_pass.Text = "ttvsa";
            // 
            // txt_db
            // 
            this.txt_db.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_db.Location = new System.Drawing.Point(57, 97);
            this.txt_db.Name = "txt_db";
            this.txt_db.Size = new System.Drawing.Size(197, 20);
            this.txt_db.TabIndex = 3;
            this.txt_db.Text = "TTV_MAS16_TANCANGBENTHANH";
            this.txt_db.TextChanged += new System.EventHandler(this.Txt_db_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "DB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Table";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(19, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Where";
            // 
            // txt_order
            // 
            this.txt_order.Location = new System.Drawing.Point(63, 118);
            this.txt_order.Name = "txt_order";
            this.txt_order.Size = new System.Drawing.Size(299, 20);
            this.txt_order.TabIndex = 4;
            this.txt_order.Text = "stt";
            this.txt_order.TextChanged += new System.EventHandler(this.txt_order_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(19, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Order";
            // 
            // but_login
            // 
            this.but_login.Location = new System.Drawing.Point(57, 123);
            this.but_login.Name = "but_login";
            this.but_login.Size = new System.Drawing.Size(197, 23);
            this.but_login.TabIndex = 4;
            this.but_login.Text = "Login";
            this.but_login.UseVisualStyleBackColor = true;
            this.but_login.Click += new System.EventHandler(this.But_login_Click);
            // 
            // txt_list_storeprodures
            // 
            this.txt_list_storeprodures.Location = new System.Drawing.Point(89, 19);
            this.txt_list_storeprodures.Name = "txt_list_storeprodures";
            this.txt_list_storeprodures.Size = new System.Drawing.Size(159, 20);
            this.txt_list_storeprodures.TabIndex = 0;
            // 
            // but_generateSqlSript_store_produres
            // 
            this.but_generateSqlSript_store_produres.Location = new System.Drawing.Point(89, 42);
            this.but_generateSqlSript_store_produres.Name = "but_generateSqlSript_store_produres";
            this.but_generateSqlSript_store_produres.Size = new System.Drawing.Size(159, 23);
            this.but_generateSqlSript_store_produres.TabIndex = 1;
            this.but_generateSqlSript_store_produres.Text = "CREATE/ALTER";
            this.but_generateSqlSript_store_produres.UseVisualStyleBackColor = true;
            this.but_generateSqlSript_store_produres.Click += new System.EventHandler(this.But_generateSqlSript_store_produres_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(11, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Store Produres";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_store);
            this.groupBox1.Controls.Add(this.txt_list_storeprodures);
            this.groupBox1.Controls.Add(this.but_generateSqlSript_store_produres);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(664, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 153);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create SQL Script StoreProdures";
            // 
            // lst_store
            // 
            this.lst_store.FormattingEnabled = true;
            this.lst_store.Location = new System.Drawing.Point(14, 69);
            this.lst_store.Name = "lst_store";
            this.lst_store.Size = new System.Drawing.Size(234, 69);
            this.lst_store.TabIndex = 4;
            // 
            // cbtypep
            // 
            this.cbtypep.FormattingEnabled = true;
            this.cbtypep.Items.AddRange(new object[] {
            "CREATE",
            "ALTER"});
            this.cbtypep.Location = new System.Drawing.Point(270, 19);
            this.cbtypep.Name = "cbtypep";
            this.cbtypep.Size = new System.Drawing.Size(92, 21);
            this.cbtypep.TabIndex = 1;
            this.cbtypep.Text = "CREATE";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.but_create_tab_tmp_x);
            this.groupBox2.Controls.Add(this.cbtypep);
            this.groupBox2.Controls.Add(this.cbx_action);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_table);
            this.groupBox2.Controls.Add(this.txt_where);
            this.groupBox2.Controls.Add(this.txt_order);
            this.groupBox2.Controls.Add(this.but_refreshview);
            this.groupBox2.Controls.Add(this.but_createtable);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(290, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create SQL Script Insert";
            // 
            // cbx_action
            // 
            this.cbx_action.FormattingEnabled = true;
            this.cbx_action.Items.AddRange(new object[] {
            "Custom",
            "Select",
            "Update",
            "DELETE"});
            this.cbx_action.Location = new System.Drawing.Point(63, 19);
            this.cbx_action.Name = "cbx_action";
            this.cbx_action.Size = new System.Drawing.Size(201, 21);
            this.cbx_action.TabIndex = 0;
            this.cbx_action.SelectedIndexChanged += new System.EventHandler(this.cbx_action_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(19, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Action";
            // 
            // but_refreshview
            // 
            this.but_refreshview.Location = new System.Drawing.Point(172, 69);
            this.but_refreshview.Name = "but_refreshview";
            this.but_refreshview.Size = new System.Drawing.Size(64, 20);
            this.but_refreshview.TabIndex = 10;
            this.but_refreshview.Text = "Refresh View";
            this.but_refreshview.UseVisualStyleBackColor = true;
            this.but_refreshview.Click += new System.EventHandler(this.but_refreshview_Click);
            // 
            // but_createtable
            // 
            this.but_createtable.Location = new System.Drawing.Point(63, 69);
            this.but_createtable.Name = "but_createtable";
            this.but_createtable.Size = new System.Drawing.Size(103, 20);
            this.but_createtable.TabIndex = 9;
            this.but_createtable.Text = "CREATE/ALTER";
            this.but_createtable.UseVisualStyleBackColor = true;
            this.but_createtable.Click += new System.EventHandler(this.But_createtable_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_server);
            this.groupBox3.Controls.Add(this.txt_user);
            this.groupBox3.Controls.Add(this.txt_pass);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_db);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.but_login);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(15, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 153);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Login";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Location = new System.Drawing.Point(15, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 380);
            this.tabControl1.TabIndex = 2;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.rtb_results);
            this.tab1.Controls.Add(this.groupBox6);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(898, 354);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Result";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.but_generateSqlSript_table);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(892, 39);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tool";
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.groupBox4);
            this.tab2.Controls.Add(this.groupBox5);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(898, 354);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "SQL Query";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_results2);
            this.groupBox4.Controls.Add(this.splitter1);
            this.groupBox4.Controls.Add(this.dgr_result);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(892, 309);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // rtb_results2
            // 
            this.rtb_results2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_results2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_results2.HideSelection = false;
            this.rtb_results2.Location = new System.Drawing.Point(3, 16);
            this.rtb_results2.Name = "rtb_results2";
            this.rtb_results2.Size = new System.Drawing.Size(886, 64);
            this.rtb_results2.TabIndex = 2;
            this.rtb_results2.Text = " ";
            this.rtb_results2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_results2_KeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 80);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(886, 3);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // dgr_result
            // 
            this.dgr_result.AllowUserToOrderColumns = true;
            this.dgr_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgr_result.GridColor = System.Drawing.Color.LightSeaGreen;
            this.dgr_result.Location = new System.Drawing.Point(3, 83);
            this.dgr_result.Name = "dgr_result";
            this.dgr_result.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgr_result.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgr_result.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgr_result.Size = new System.Drawing.Size(886, 223);
            this.dgr_result.TabIndex = 12;
            this.dgr_result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgr_result_KeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.but_execute);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(892, 39);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tool";
            // 
            // but_execute
            // 
            this.but_execute.Location = new System.Drawing.Point(37, 10);
            this.but_execute.Name = "but_execute";
            this.but_execute.Size = new System.Drawing.Size(84, 23);
            this.but_execute.TabIndex = 9;
            this.but_execute.Text = "ExcuteSQL";
            this.but_execute.UseVisualStyleBackColor = true;
            this.but_execute.Click += new System.EventHandler(this.but_execute_Click);
            // 
            // but_create_tab_tmp_x
            // 
            this.but_create_tab_tmp_x.Location = new System.Drawing.Point(259, 69);
            this.but_create_tab_tmp_x.Name = "but_create_tab_tmp_x";
            this.but_create_tab_tmp_x.Size = new System.Drawing.Size(103, 20);
            this.but_create_tab_tmp_x.TabIndex = 11;
            this.but_create_tab_tmp_x.Text = "CRTable/tmp/x";
            this.but_create_tab_tmp_x.UseVisualStyleBackColor = true;
            this.but_create_tab_tmp_x.Click += new System.EventHandler(this.but_create_tab_tmp_x_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(933, 563);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(630, 602);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateSqlScript";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgr_result)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_table;
        private System.Windows.Forms.TextBox txt_where;
        private System.Windows.Forms.Button but_generateSqlSript_table;
        private System.Windows.Forms.RichTextBox rtb_results;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_db;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_order;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button but_login;
        private System.Windows.Forms.TextBox txt_list_storeprodures;
        private System.Windows.Forms.Button but_generateSqlSript_store_produres;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button but_createtable;
        private System.Windows.Forms.ComboBox cbtypep;
        private System.Windows.Forms.ComboBox cbx_action;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button but_refreshview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtb_results2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dgr_result;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button but_execute;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lst_store;
        private System.Windows.Forms.Button but_create_tab_tmp_x;
    }
}

