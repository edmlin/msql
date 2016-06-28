/*
 * Created by SharpDevelop.
 * User: YLIN68
 * Date: 1/21/2016
 * Time: 10:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace msql
{
	/// <summary>
	/// Description of QueryForm.
	/// </summary>
	public partial class QueryForm : Form
	{
		string db,user,password;
		DataTable dt=new DataTable();
		System.Data.OracleClient.OracleDataAdapter da;
		System.Data.OracleClient.OracleConnection conn;
		public QueryForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void Run(string db,string user,string password,string sql)
		{
			this.db=db;
			this.user=user;
			this.password=password;
			while(sql.Trim().EndsWith(";"))
			{
				sql=sql.Trim().Substring(0,sql.Trim().Length-1);
			}
			tbSql.Text=sql;
			Text=Text+" - "+db;
			conn=new System.Data.OracleClient.OracleConnection(String.Format("Data Source={0};User Id={1};Password={2}",db,user,password));
			Show();
			btRun.PerformClick();
		}
		void BtRunClick(object sender, EventArgs e)
		{
			string sql=tbSql.Text;
			while(sql.Trim().EndsWith(";"))
			{
				sql=sql.Trim().Substring(0,sql.Trim().Length-1);
			}
			tbSql.Text=sql;
			if(sql=="") return;
			numPage.Value=1;
			try
			{
				if(conn.State!=ConnectionState.Open) conn.Open();
				if(da!=null) da.Dispose();
				da=new System.Data.OracleClient.OracleDataAdapter(sql,conn);
				dt.Clear();
				dt.Columns.Clear();
				da.Fill((int)((numPage.Value-1)*numRecords.Value),(int)numRecords.Value,dt);
				dataGridView1.DataSource=dt;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Error");
			}
		}
		void BtCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void NumPageValueChanged(object sender, EventArgs e)
		{
			dt.Clear();
			da.Fill((int)((numPage.Value-1)*numRecords.Value),(int)numRecords.Value,dt);
		}
		void QueryFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(da!=null) da.Dispose();
			if(conn!=null) conn.Dispose();
		}
	}
}
