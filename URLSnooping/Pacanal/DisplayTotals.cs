using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MyClasses;

namespace Pacanal
{
	/// <summary>
	/// Summary description for DisplayTotals.
	/// </summary>
	public class DisplayTotals : System.Windows.Forms.Form
	{
      private System.Windows.Forms.DataGrid dataGrid1;
      private System.Data.DataSet dataSet1;
      private System.Data.DataTable dataTable1;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DisplayTotals()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.dataGrid1 = new System.Windows.Forms.DataGrid();
         this.dataSet1 = new System.Data.DataSet();
         this.dataTable1 = new System.Data.DataTable();
         this.dataColumn1 = new System.Data.DataColumn();
         this.dataColumn2 = new System.Data.DataColumn();
         this.dataColumn3 = new System.Data.DataColumn();
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
         this.SuspendLayout();
         // 
         // dataGrid1
         // 
         this.dataGrid1.DataMember = "";
         this.dataGrid1.DataSource = this.dataTable1;
         this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.dataGrid1.Name = "dataGrid1";
         this.dataGrid1.Size = new System.Drawing.Size(292, 276);
         this.dataGrid1.TabIndex = 0;
         // 
         // dataSet1
         // 
         this.dataSet1.DataSetName = "NewDataSet";
         this.dataSet1.Locale = new System.Globalization.CultureInfo("en-AU");
         this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
                                                                      this.dataTable1});
         // 
         // dataTable1
         // 
         this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
                                                                          this.dataColumn1,
                                                                          this.dataColumn2,
                                                                          this.dataColumn3});
         this.dataTable1.TableName = "Table1";
         // 
         // dataColumn1
         // 
         this.dataColumn1.ColumnName = "Source";
         // 
         // dataColumn2
         // 
         this.dataColumn2.ColumnName = "Destination";
         // 
         // dataColumn3
         // 
         this.dataColumn3.ColumnName = "Bytes";
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItem1});
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 0;
         this.menuItem1.Text = "Copy";
         this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
         // 
         // DisplayTotals
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 276);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.dataGrid1});
         this.Menu = this.mainMenu1;
         this.Name = "DisplayTotals";
         this.Text = "DisplayTotals";
         this.Load += new System.EventHandler(this.DisplayTotals_Load);
         this.Closed += new System.EventHandler(this.DisplayTotals_Closed);
         ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

      private void DisplayTotals_Load(object sender, System.EventArgs e)
      {
         foreach (DictionaryEntry de in mach2mach.Stats)
         {
            object[] row = {mach2mach.GetSourceIP((string)de.Key), mach2mach.GetDestinationIP((string)de.Key), de.Value.ToString()};
            dataTable1.Rows.Add(row);
         }
      }

      private void menuItem1_Click(object sender, System.EventArgs e)
      {
         string text = string.Empty;
         foreach (DictionaryEntry de in mach2mach.Stats)
         {
            text = text + mach2mach.GetSourceIP((string)de.Key) + "\t" + mach2mach.GetDestinationIP((string)de.Key) + "\t" + de.Value.ToString() + "\r\n";
         }
         Clipboard.SetDataObject(text, true);
      }

      private void DisplayTotals_Closed(object sender, System.EventArgs e)
      {
         mach2mach.Clear();
      }
	}
}
