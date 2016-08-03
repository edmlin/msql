/*
 * Created by SharpDevelop.
 * User: YLIN68
 * Date: 12/10/2015
 * Time: 1:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace msql
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbSelectAll;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.Button btRun;
		private System.Windows.Forms.TextBox tbUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nThreads;
		private System.Windows.Forms.Button btPassword;
		private System.Windows.Forms.Button btUser;
		private System.Windows.Forms.Button btNext;
		private System.Windows.Forms.Button btPrev;
		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbSql;
		private System.Windows.Forms.CheckBox cbShowPassword;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btReload;
		private System.Windows.Forms.ContextMenuStrip cmDelete;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btReload = new System.Windows.Forms.Button();
			this.cbShowPassword = new System.Windows.Forms.CheckBox();
			this.btNext = new System.Windows.Forms.Button();
			this.btPrev = new System.Windows.Forms.Button();
			this.tbFind = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btUser = new System.Windows.Forms.Button();
			this.btPassword = new System.Windows.Forms.Button();
			this.tbUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbSelectAll = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.nThreads = new System.Windows.Forms.NumericUpDown();
			this.btClose = new System.Windows.Forms.Button();
			this.btRun = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.cmDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbSql = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nThreads)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.cmDelete.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btReload);
			this.panel1.Controls.Add(this.cbShowPassword);
			this.panel1.Controls.Add(this.btNext);
			this.panel1.Controls.Add(this.btPrev);
			this.panel1.Controls.Add(this.tbFind);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.btUser);
			this.panel1.Controls.Add(this.btPassword);
			this.panel1.Controls.Add(this.tbUser);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbPassword);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbSelectAll);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(868, 38);
			this.panel1.TabIndex = 0;
			// 
			// btReload
			// 
			this.btReload.Location = new System.Drawing.Point(752, 9);
			this.btReload.Name = "btReload";
			this.btReload.Size = new System.Drawing.Size(88, 23);
			this.btReload.TabIndex = 12;
			this.btReload.Text = "Reload Servers";
			this.btReload.UseVisualStyleBackColor = true;
			this.btReload.Click += new System.EventHandler(this.BtReloadClick);
			// 
			// cbShowPassword
			// 
			this.cbShowPassword.Location = new System.Drawing.Point(437, 10);
			this.cbShowPassword.Name = "cbShowPassword";
			this.cbShowPassword.Size = new System.Drawing.Size(104, 24);
			this.cbShowPassword.TabIndex = 11;
			this.cbShowPassword.TabStop = false;
			this.cbShowPassword.Text = "Show Password";
			this.cbShowPassword.UseVisualStyleBackColor = true;
			this.cbShowPassword.CheckedChanged += new System.EventHandler(this.CbShowPasswordCheckedChanged);
			// 
			// btNext
			// 
			this.btNext.Location = new System.Drawing.Point(711, 8);
			this.btNext.Name = "btNext";
			this.btNext.Size = new System.Drawing.Size(24, 23);
			this.btNext.TabIndex = 10;
			this.btNext.TabStop = false;
			this.btNext.Text = ">";
			this.btNext.UseVisualStyleBackColor = true;
			this.btNext.Click += new System.EventHandler(this.BtNextClick);
			// 
			// btPrev
			// 
			this.btPrev.Location = new System.Drawing.Point(681, 8);
			this.btPrev.Name = "btPrev";
			this.btPrev.Size = new System.Drawing.Size(24, 23);
			this.btPrev.TabIndex = 9;
			this.btPrev.TabStop = false;
			this.btPrev.Text = "<";
			this.btPrev.UseVisualStyleBackColor = true;
			this.btPrev.Click += new System.EventHandler(this.BtPrevClick);
			// 
			// tbFind
			// 
			this.tbFind.Location = new System.Drawing.Point(575, 10);
			this.tbFind.Name = "tbFind";
			this.tbFind.Size = new System.Drawing.Size(100, 20);
			this.tbFind.TabIndex = 8;
			this.tbFind.TabStop = false;
			this.tbFind.TextChanged += new System.EventHandler(this.TbFindTextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(547, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Find:";
			// 
			// btUser
			// 
			this.btUser.Location = new System.Drawing.Point(205, 9);
			this.btUser.Name = "btUser";
			this.btUser.Size = new System.Drawing.Size(23, 23);
			this.btUser.TabIndex = 2;
			this.btUser.Text = "↓";
			this.btUser.UseVisualStyleBackColor = true;
			this.btUser.Click += new System.EventHandler(this.BtUserClick);
			// 
			// btPassword
			// 
			this.btPassword.Location = new System.Drawing.Point(401, 9);
			this.btPassword.Name = "btPassword";
			this.btPassword.Size = new System.Drawing.Size(23, 23);
			this.btPassword.TabIndex = 4;
			this.btPassword.Text = "↓";
			this.btPassword.UseVisualStyleBackColor = true;
			this.btPassword.Click += new System.EventHandler(this.BtPasswordClick);
			// 
			// tbUser
			// 
			this.tbUser.Location = new System.Drawing.Point(116, 11);
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size(83, 20);
			this.tbUser.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(85, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "User:";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(307, 11);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(88, 20);
			this.tbPassword.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(246, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Password:";
			// 
			// cbSelectAll
			// 
			this.cbSelectAll.Location = new System.Drawing.Point(12, 11);
			this.cbSelectAll.Name = "cbSelectAll";
			this.cbSelectAll.Size = new System.Drawing.Size(104, 24);
			this.cbSelectAll.TabIndex = 0;
			this.cbSelectAll.Text = "Select All";
			this.cbSelectAll.UseVisualStyleBackColor = true;
			this.cbSelectAll.Click += new System.EventHandler(this.CbSelectAllClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.nThreads);
			this.panel2.Controls.Add(this.btClose);
			this.panel2.Controls.Add(this.btRun);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 384);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(868, 49);
			this.panel2.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "Threads:";
			// 
			// nThreads
			// 
			this.nThreads.Location = new System.Drawing.Point(69, 16);
			this.nThreads.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nThreads.Name = "nThreads";
			this.nThreads.Size = new System.Drawing.Size(59, 20);
			this.nThreads.TabIndex = 3;
			this.nThreads.Value = new decimal(new int[] {
			5,
			0,
			0,
			0});
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(510, 14);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(75, 23);
			this.btClose.TabIndex = 2;
			this.btClose.Text = "Close";
			this.btClose.UseVisualStyleBackColor = true;
			this.btClose.Click += new System.EventHandler(this.BtCloseClick);
			// 
			// btRun
			// 
			this.btRun.Location = new System.Drawing.Point(259, 14);
			this.btRun.Name = "btRun";
			this.btRun.Size = new System.Drawing.Size(75, 23);
			this.btRun.TabIndex = 0;
			this.btRun.Text = "Run";
			this.btRun.UseVisualStyleBackColor = true;
			this.btRun.Click += new System.EventHandler(this.BtRunClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.cmDelete;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(868, 265);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.TabStop = false;
			this.dataGridView1.DataSourceChanged += new System.EventHandler(this.DataGridView1DataSourceChanged);
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellDoubleClick);
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1CellFormatting);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1CurrentCellDirtyStateChanged);
			this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView1EditingControlShowing);
			this.dataGridView1.Sorted += new System.EventHandler(this.DataGridView1Sorted);
			// 
			// cmDelete
			// 
			this.cmDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.deleteToolStripMenuItem});
			this.cmDelete.Name = "cmDelete";
			this.cmDelete.Size = new System.Drawing.Size(108, 26);
			this.cmDelete.Opening += new System.ComponentModel.CancelEventHandler(this.CmDeleteOpening);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbSql);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(868, 77);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SQL";
			// 
			// tbSql
			// 
			this.tbSql.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSql.Location = new System.Drawing.Point(3, 16);
			this.tbSql.Multiline = true;
			this.tbSql.Name = "tbSql";
			this.tbSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbSql.Size = new System.Drawing.Size(862, 58);
			this.tbSql.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 38);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(868, 346);
			this.splitContainer1.SplitterDistance = 77;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(868, 433);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "msql";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nThreads)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.cmDelete.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
