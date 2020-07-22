using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoTask_GridSerialization
{
    public partial class MainForm : Form
    {
        Operations operations { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                operations = new Operations();
                operations.MyDelegate = new UpdateDataDelegate(UpdateBindingData);
                operations.DeserializeData();
                employeeBindingSource.DataSource = operations.Staff;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }
   
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddForm frmAdd = new AddForm(operations);
                // dataGridView1.AllowUserToAddRows = true;
                // operations.Selected_Operation = "";
                //frmAdd.UpdateItemsCallback = new UpdateDataDelegate(this.UpdateBindingData);
                frmAdd.ShowDialog();
                // dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }      
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dataGridView1.CurrentRow;

                if (SelectedRow != null)
                {
                    AddForm frmAdd = new AddForm(operations);
                    operations.Selected_Operation = "update";
                    frmAdd.index = SelectedRow.Index;
                    frmAdd.AddData(Convert.ToInt32(SelectedRow.Cells[0].Value.ToString()),
                                                   SelectedRow.Cells[1].Value.ToString(),
                                    Convert.ToInt32(SelectedRow.Cells[2].Value.ToString()),
                                    Convert.ToInt32(SelectedRow.Cells[3].Value.ToString()),
                                    Convert.ToInt32(SelectedRow.Cells[4].Value.ToString()));
                    frmAdd.Show();
                    // frmAdd.UpdateItemsCallback = new UpdateDataDelegate(this.UpdateBindingData);
                }
                else
                {
                    MessageBox.Show("Please Select A Record to Update");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }  
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AddForm frmAdd = new AddForm(operations);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateBindingData()
        {
            try
            {
                employeeBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
