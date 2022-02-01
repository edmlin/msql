/*
 * Created by SharpDevelop.
 * User: YLIN68
 * Date: 12/10/2015
 * Time: 1:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client; // ODP.NET Oracle managed provider 
using Oracle.ManagedDataAccess.Types; 
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace msql
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		DataTable dt;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		static DataTable GetDataSources()
		{
			OracleClientFactory factory=new OracleClientFactory();
			if (factory.CanCreateDataSourceEnumerator)
			{
				DbDataSourceEnumerator dsenum = factory.CreateDataSourceEnumerator();
				DataTable dt1 = dsenum.GetDataSources();
				dt1.Columns.Remove("Protocol");
				dt1.Columns.Remove("Port");
				dt1.Columns.Add("Selected",System.Type.GetType("System.Boolean")).SetOrdinal(0);
				dt1.Columns.Add("User",System.Type.GetType("System.String"));
				dt1.Columns.Add("Password",System.Type.GetType("System.String"));
				dt1.Columns.Add("RealPassword",System.Type.GetType("System.String"));
				dt1.Columns.Add("Result",System.Type.GetType("System.String"));
				foreach(DataRow row in dt1.Rows)
				{
					row["Selected"]=false;
					row["User"]=row["Password"]=row["RealPassword"]=row["Result"]="";
				}
				return dt1;
			}
			else
			  return null;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			dataGridView1.DataSource=dt=GetDataSources();
			
			foreach(DataGridViewColumn col in dataGridView1.Columns)
			{
				if(col.Name=="RealPassword") col.Visible=false;
				if(col.Name!="Selected") col.ReadOnly=true;
			}
			dataGridView1.Columns["Selected"].SortMode= DataGridViewColumnSortMode.Automatic;
			dataGridView1.RowHeadersWidth=50;
		}
		void CbSelectAllClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				row["Selected"]=cbSelectAll.Checked;
			}
		}
		void UpdateSelectAllCheckBox()
		{
			bool allSelected=true;
			bool noneSelected=true;
			foreach(DataRow row in dt.Rows)
			{
				allSelected=allSelected && (bool)row["Selected"];
				noneSelected=noneSelected && !(bool)row["Selected"];
				if(!allSelected && !noneSelected) break;
			}
			if(allSelected) cbSelectAll.CheckState=CheckState.Checked;
			else if(noneSelected) cbSelectAll.CheckState=CheckState.Unchecked;
			else cbSelectAll.CheckState=CheckState.Indeterminate;
		}
		void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex<0) return;
			if(dataGridView1.Columns[e.ColumnIndex].Name=="Selected")
			{
				UpdateSelectAllCheckBox();
			}
		}
		void DataGridView1CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if(dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name=="Selected")
			{
				dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
		void BtCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		async void BtRunClick(object sender, EventArgs e)
		{
			string sql=tbSql.Text;
			while(sql.Trim().EndsWith(";"))
			{
				sql=sql.Trim().Substring(0,sql.Trim().Length-1);
			}
			
			if(Regex.Match(sql.ToLower(),"\\send$").Success) sql+=";";
			
			tbSql.Text=sql;
			if(sql=="") return;

			btRun.Enabled=false;
			
			int currentRow=dataGridView1.CurrentCell.RowIndex;
			int currentCol=dataGridView1.CurrentCell.ColumnIndex;
			int firstCol=dataGridView1.FirstDisplayedScrollingColumnIndex;
			int firstRow=dataGridView1.FirstDisplayedScrollingRowIndex;
			
			dataGridView1.DataSource=dt=dt.DefaultView.ToTable();
			
			dataGridView1.CurrentCell=dataGridView1.Rows[currentRow].Cells[currentCol];
			dataGridView1.FirstDisplayedScrollingColumnIndex=firstCol;
			dataGridView1.FirstDisplayedScrollingRowIndex=firstRow;
			
			List<Task> tasks=new List<Task>();
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					while(tasks.Count>=nThreads.Value)
					{
						Task task=await Task.WhenAny(tasks);
						tasks.Remove(task);
					}
					tasks.Add(RunAsync(row));
				}
			}
			await Task.WhenAll(tasks);
			btRun.Enabled=true;
		}

		async Task RunAsync(DataRow row)
		{
			string db=row["InstanceName"].ToString();
			string user=row["User"].ToString();
			string password=row["RealPassword"].ToString();

			row["Result"]="Running...";
			string result=await Task<string>.Run(()=>{return Run(db,user,password,tbSql.Text);});
			row["Result"]=result;
		}
		
		string Run(string db,string user,string password,string sql)
		{
			string oradb = String.Format("Data Source={0};User Id={1};Password={2}",db,user,password);
			string result="";

			if(sql=="") return "";
			using(System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(oradb))
			{
				try
				{
					conn.Open();
					using(System.Data.OracleClient.OracleCommand cmd=conn.CreateCommand())
					{
						//cmd.BindByName=true;
						cmd.CommandText=sql.Replace("\r\n","\n");
						System.Data.OracleClient.OracleDataReader dr=cmd.ExecuteReader();
						string[] fields=new string[dr.FieldCount];
						if(dr.Read())
						{
							for(int i=0;i<dr.FieldCount;i++)
							{
								fields[i]=dr.GetValue(i).ToString();
							}
						}
						dr.Close();
						result=string.Join(",",fields);
					}
					return result;
				}
				catch(Exception e)
				{
					return "Error: "+e.Message;
				}
			}						
		}

		void DataGridView1CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(dataGridView1.Columns[e.ColumnIndex].Name=="Result")
			{
				if(e.Value.ToString().StartsWith("Error:"))
					e.CellStyle.ForeColor=Color.Red;
				else if(e.Value.ToString().StartsWith("Running"))
					e.CellStyle.ForeColor=Color.Black;
				else
					e.CellStyle.ForeColor=Color.Blue;
			}
		}
		void BtPasswordClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					row["RealPassword"]=tbPassword.Text;
					if(cbShowPassword.Checked)
						row["Password"]=tbPassword.Text;
					else
						row["Password"]=new string('*',tbPassword.Text.Length);
				}
			}
		}
		void BtUserClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					row["User"]=tbUser.Text;
				}
			}
	
		}
		bool FindFirst(string key)
		{
			DataGridViewCell cell;
			DataGridViewRow row;
			int i=dataGridView1.CurrentRow.Index;
			do
			{
				row=dataGridView1.Rows[i];
				cell=Match(row,key);
				if(cell!=null)
				{
					dataGridView1.CurrentCell=cell;
					return true;
				}
				if(i==dataGridView1.Rows.Count-1) i=0;
				else i++;
			} while(i!=dataGridView1.CurrentRow.Index);
			return false;
		}
		bool FindNext(string key)
		{
			DataGridViewCell cell;
			DataGridViewRow row;
			int i=dataGridView1.CurrentRow.Index;
			do
			{
				if(i==dataGridView1.Rows.Count-1) i=0;
				else i++;
				row=dataGridView1.Rows[i];
				cell=Match(row,key);
				if(cell!=null)
				{
					dataGridView1.CurrentCell=cell;
					return true;
				}
			} while(i!=dataGridView1.CurrentRow.Index);
			return false;
		}
		bool FindPrev(string key)
		{
			DataGridViewCell cell;
			DataGridViewRow row;
			int i=dataGridView1.CurrentRow.Index;
			do
			{
				if(i==0) i=dataGridView1.Rows.Count-1;
				else i--;
				row=dataGridView1.Rows[i];
				cell=Match(row,key);
				if(cell!=null)
				{
					dataGridView1.CurrentCell=cell;
					return true;
				}
			} while(i!=dataGridView1.CurrentRow.Index);
			return false;
		}
		DataGridViewCell Match(DataGridViewRow row,string key)
		{
			if(row.Cells["InstanceName"].Value.ToString().ToLower().Contains(key.ToLower()))
				return row.Cells["InstanceName"];
			else if(row.Cells["ServerName"].Value.ToString().ToLower().Contains(key.ToLower()))
				return row.Cells["ServerName"];
			else if(row.Cells["ServiceName"].Value.ToString().ToLower().Contains(key.ToLower()))
				return row.Cells["ServiceName"];
			else
				return null;
		}
		void TbFindTextChanged(object sender, EventArgs e)
		{
			FindFirst(tbFind.Text);
		}
		void BtPrevClick(object sender, EventArgs e)
		{
			FindPrev(tbFind.Text);
		}
		void BtNextClick(object sender, EventArgs e)
		{
			FindNext(tbFind.Text);
		}
		void DataGridView1Sorted(object sender, EventArgs e)
		{
			ShowRowIndex();
		}
		void ShowRowIndex()
		{
			foreach(DataGridViewRow row in dataGridView1.Rows)
			{
				row.HeaderCell.Value=(row.Index+1).ToString();
			}
		}
		void DataGridView1DataSourceChanged(object sender, EventArgs e)
		{
			ShowRowIndex();
		}
		void DataGridView1EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			
			if(dataGridView1.CurrentCell.ColumnIndex == 5)//select target column
		    {
			    TextBox textBox = e.Control as TextBox;
			    if (textBox != null)
			    {
			    	if(!cbShowPassword.Checked)
			        	textBox.UseSystemPasswordChar = true;
			    	else
			    		textBox.UseSystemPasswordChar = false;
			    }
		    }
		    
		}
		void CbShowPasswordCheckedChanged(object sender, EventArgs e)
		{
			if(cbShowPassword.Checked)
			{
				tbPassword.PasswordChar='\0';
				foreach(DataRow row in dt.Rows)
				{
					row["Password"]=row["RealPassword"];
				}
			}
			else
			{
				tbPassword.PasswordChar='*';
				foreach(DataRow row in dt.Rows)
				{
					row["Password"]=new string('*',row["RealPassword"].ToString().Length);
				}
			}
		}
		void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex < 0) return;
			DataRow row=dt.DefaultView[e.RowIndex].Row;
			string db=row["InstanceName"].ToString();
			string user=row["User"].ToString();
			string password=row["RealPassword"].ToString();
			QueryForm qf=new QueryForm();
			qf.Run(db,user,password,tbSql.Text);
		}
		void BtReloadClick(object sender, EventArgs e)
		{
			MainFormLoad(null,null);
		}
		void CmDeleteOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = dataGridView1.SelectedRows.Count <= 0;
		}
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach(DataGridViewRow row in dataGridView1.SelectedRows)
			{
				(row.DataBoundItem as DataRowView).Row.Delete();
			}
			ShowRowIndex();
		}
		void BtUncheckErrorClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				if(row["Result"].ToString().StartsWith("Error:"))
				{
			   		row["Selected"]=false;
				}
			}
			UpdateSelectAllCheckBox();
		}

	}
}
